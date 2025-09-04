using MainUI.PowerSupplyControl;
using System.IO.Ports;
using static MainUI.PowerSupplyControl.PowerSupplyProtocol;
using Timer = System.Windows.Forms.Timer;

namespace MainUI.PowerSupplyControl
{
    /// <summary>
    /// 电源服务类 - 统一管理电源设备的连接、数据读取和控制操作
    /// 采用单例模式确保全局只有一个电源连接实例
    /// 通过事件机制实现与UI层的松耦合通信
    /// </summary>
    public class PowerSupplyService : IDisposable
    {
        #region 单例模式实现
        private static readonly Lazy<PowerSupplyService> _instance =
            new Lazy<PowerSupplyService>(() => new PowerSupplyService());

        /// <summary>
        /// 获取电源服务的全局唯一实例
        /// </summary>
        public static PowerSupplyService Instance => _instance.Value;
        #endregion

        #region 私有字段
        /// <summary>
        /// 电源通信协议实例，负责与设备的实际通信
        /// </summary>
        private PowerSupplyProtocol _powerSupply;

        /// <summary>
        /// 当前电源数据，存储最新读取的所有电源参数
        /// </summary>
        private PowerSupplyData _currentData;

        /// <summary>
        /// 数据刷新定时器，定期从设备读取数据并触发更新事件
        /// </summary>
        private Timer _refreshTimer;

        /// <summary>
        /// 连接状态标志
        /// </summary>
        private bool _isConnected = false;

        /// <summary>
        /// 当前连接的串口号
        /// </summary>
        private string _currentComPort = "";

        /// <summary>
        /// 线程安全锁对象
        /// </summary>
        private readonly object _lockObject = new object();
        #endregion

        #region 公开属性
        /// <summary>
        /// 获取当前连接状态
        /// </summary>
        public bool IsConnected
        {
            get
            {
                lock (_lockObject)
                {
                    return _isConnected;
                }
            }
        }

        /// <summary>
        /// 获取当前电源数据的只读副本
        /// </summary>
        public PowerSupplyData CurrentData
        {
            get
            {
                lock (_lockObject)
                {
                    return _currentData?.Clone() ?? new PowerSupplyData { IsConnected = false };
                }
            }
        }

        /// <summary>
        /// 获取当前连接的串口号
        /// </summary>
        public string CurrentComPort
        {
            get
            {
                lock (_lockObject)
                {
                    return _currentComPort;
                }
            }
        }
        #endregion

        #region 事件定义
        /// <summary>
        /// 数据更新事件 - 当电源数据刷新时触发
        /// 参数：最新的电源数据
        /// </summary>
        public event Action<PowerSupplyData> DataUpdated;

        /// <summary>
        /// 连接状态变化事件 - 当连接建立或断开时触发
        /// 参数：连接状态(true=已连接, false=已断开)
        /// </summary>
        public event Action<bool> ConnectionStatusChanged;

        /// <summary>
        /// 操作结果事件 - 当执行控制命令后触发
        /// 参数：操作描述, 操作结果
        /// </summary>
        public event Action<string, bool> OperationCompleted;
        #endregion

        #region 构造函数
        /// <summary>
        /// 私有构造函数，确保单例模式
        /// 初始化数据对象和定时器
        /// </summary>
        private PowerSupplyService()
        {
            InitializeData();
            SetupTimer();
        }

        /// <summary>
        /// 初始化电源数据对象
        /// </summary>
        private void InitializeData()
        {
            _currentData = new PowerSupplyData
            {
                UpdateTime = DateTime.Now,
                IsConnected = false,
                // 初始化所有数值为0，避免空值异常
                VoltageU = 0,
                VoltageV = 0,
                VoltageW = 0,
                CurrentU = 0,
                CurrentV = 0,
                CurrentW = 0,
                PowerU = 0,
                PowerV = 0,
                PowerW = 0,
                Frequency = 0,
                FaultStatus = FaultType.Normal
            };
        }

        /// <summary>
        /// 设置数据刷新定时器
        /// </summary>
        private void SetupTimer()
        {
            _refreshTimer = new Timer
            {
                Interval = 1000, // 1秒刷新间隔，平衡实时性和稳定性
                Enabled = false  // 初始禁用，连接成功后启动
            };
            _refreshTimer.Tick += OnRefreshTimer_Tick;
        }
        #endregion

        #region 连接管理方法
        /// <summary>
        /// 连接到指定串口的电源设备
        /// </summary>
        /// <param name="comPort">串口号，如COM1、COM2等</param>
        /// <returns>连接是否成功</returns>
        public async Task<bool> ConnectAsync(string comPort)
        {
            try
            {
                NlogHelper.Default.Info($"尝试连接电源设备，串口: {comPort}");

                // 如果已有连接，先断开
                if (_isConnected)
                {
                    await DisconnectAsync();
                }

                // 在后台线程中建立连接，避免阻塞UI
                await Task.Run(() =>
                {
                    lock (_lockObject)
                    {
                        _powerSupply = new PowerSupplyProtocol(comPort, 9600);
                        _powerSupply.Open();

                        // 测试通讯是否正常 - 尝试查询故障状态
                        var testResult = _powerSupply.QueryFaultStatus();

                        // 更新连接状态
                        _isConnected = true;
                        _currentComPort = comPort;
                        _currentData.IsConnected = true;
                    }
                });

                // 启动数据刷新定时器
                _refreshTimer.Start();

                // 触发连接状态变化事件
                ConnectionStatusChanged?.Invoke(true);

                NlogHelper.Default.Info($"电源设备连接成功: {comPort}");
                OperationCompleted?.Invoke($"连接到{comPort}", true);

                return true;
            }
            catch (Exception ex)
            {
                // 连接失败时确保状态正确
                lock (_lockObject)
                {
                    _isConnected = false;
                    _currentComPort = "";
                    _currentData.IsConnected = false;
                }

                NlogHelper.Default.Error($"电源设备连接失败: {comPort}, 错误: {ex.Message}");
                OperationCompleted?.Invoke($"连接到{comPort}", false);

                return false;
            }
        }

        /// <summary>
        /// 断开电源设备连接
        /// </summary>
        public async Task DisconnectAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    NlogHelper.Default.Info("断开电源设备连接");

                    // 停止数据刷新
                    _refreshTimer?.Stop();

                    lock (_lockObject)
                    {
                        // 关闭并释放串口资源
                        if (_powerSupply != null)
                        {
                            _powerSupply.Close();
                            _powerSupply.Dispose();
                            _powerSupply = null;
                        }

                        // 更新连接状态
                        _isConnected = false;
                        _currentComPort = "";
                        _currentData.IsConnected = false;
                    }

                    // 触发连接状态变化事件
                    ConnectionStatusChanged?.Invoke(false);

                    NlogHelper.Default.Info("电源设备连接已断开");
                    OperationCompleted?.Invoke("断开连接", true);
                }
                catch (Exception ex)
                {
                    NlogHelper.Default.Error($"断开电源设备连接时发生错误: {ex.Message}");
                    OperationCompleted?.Invoke("断开连接", false);
                }
            });
        }
        #endregion

        #region 设备控制方法
        /// <summary>
        /// 设置电源控制模式
        /// </summary>
        /// <param name="mode">控制模式</param>
        /// <returns>设置是否成功</returns>
        public async Task<bool> SetControlModeAsync(ControlMode mode)
        {
            if (!_isConnected)
            {
                OperationCompleted?.Invoke("设置控制模式", false);
                return false;
            }

            try
            {
                bool result = await Task.Run(() =>
                {
                    lock (_lockObject)
                    {
                        return _powerSupply?.SetControlMode(mode) ?? false;
                    }
                });

                string modeText = mode == ControlMode.Remote ? "电脑控制" : "本机控制";
                NlogHelper.Default.Info($"设置控制模式为{modeText}: {(result ? "成功" : "失败")}");
                OperationCompleted?.Invoke($"设置控制模式为{modeText}", result);

                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"设置控制模式失败: {ex.Message}");
                OperationCompleted?.Invoke("设置控制模式", false);
                return false;
            }
        }

        /// <summary>
        /// 设置输出档位
        /// </summary>
        /// <param name="range">输出档位</param>
        /// <returns>设置是否成功</returns>
        public async Task<bool> SetOutputRangeAsync(OutputRange range)
        {
            if (!_isConnected)
            {
                OperationCompleted?.Invoke("设置输出档位", false);
                return false;
            }

            try
            {
                bool result = await Task.Run(() =>
                {
                    lock (_lockObject)
                    {
                        return _powerSupply?.SetOutputRange(range) ?? false;
                    }
                });

                string rangeText = range == OutputRange.High ? "高档" : "低档";
                NlogHelper.Default.Info($"设置输出档位为{rangeText}: {(result ? "成功" : "失败")}");
                OperationCompleted?.Invoke($"设置输出档位为{rangeText}", result);

                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"设置输出档位失败: {ex.Message}");
                OperationCompleted?.Invoke("设置输出档位", false);
                return false;
            }
        }

        /// <summary>
        /// 设置输出电压
        /// </summary>
        /// <param name="voltage">电压值</param>
        /// <param name="range">输出档位，默认为低档</param>
        /// <returns>设置是否成功</returns>
        public async Task<bool> SetVoltageAsync(double voltage, OutputRange range = OutputRange.Low)
        {
            if (!_isConnected)
            {
                OperationCompleted?.Invoke("设置输出电压", false);
                return false;
            }

            try
            {
                bool result = await Task.Run(() =>
                {
                    lock (_lockObject)
                    {
                        // SetVoltage方法需要两个参数：电压值和输出档位
                        return _powerSupply?.SetVoltage(voltage, range) ?? false;
                    }
                });

                string rangeText = range == OutputRange.High ? "高档" : "低档";
                NlogHelper.Default.Info($"设置输出电压为{voltage}V({rangeText}): {(result ? "成功" : "失败")}");
                OperationCompleted?.Invoke($"设置输出电压为{voltage}V({rangeText})", result);

                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"设置输出电压失败: {ex.Message}");
                OperationCompleted?.Invoke("设置输出电压", false);
                return false;
            }
        }

        /// <summary>
        /// 设置输出频率
        /// </summary>
        /// <param name="frequency">频率值</param>
        /// <returns>设置是否成功</returns>
        public async Task<bool> SetFrequencyAsync(double frequency)
        {
            if (!_isConnected)
            {
                OperationCompleted?.Invoke("设置输出频率", false);
                return false;
            }

            try
            {
                bool result = await Task.Run(() =>
                {
                    lock (_lockObject)
                    {
                        return _powerSupply?.SetFrequency(frequency) ?? false;
                    }
                });

                NlogHelper.Default.Info($"设置输出频率为{frequency}Hz: {(result ? "成功" : "失败")}");
                OperationCompleted?.Invoke($"设置输出频率为{frequency}Hz", result);

                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"设置输出频率失败: {ex.Message}");
                OperationCompleted?.Invoke("设置输出频率", false);
                return false;
            }
        }

        /// <summary>
        /// 执行电源复位
        /// </summary>
        /// <returns>复位是否成功</returns>
        public async Task<bool> PowerResetAsync()
        {
            if (!_isConnected)
            {
                OperationCompleted?.Invoke("电源复位", false);
                return false;
            }

            try
            {
                bool result = await Task.Run(() =>
                {
                    lock (_lockObject)
                    {
                        return _powerSupply?.PowerReset() ?? false;
                    }
                });

                NlogHelper.Default.Info($"电源复位: {(result ? "成功" : "失败")}");
                OperationCompleted?.Invoke("电源复位", result);

                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"电源复位失败: {ex.Message}");
                OperationCompleted?.Invoke("电源复位", false);
                return false;
            }
        }

        /// <summary>
        /// 快速启动 - 设置为电脑控制模式并切换到低档输出
        /// </summary>
        /// <returns>快速启动是否成功</returns>
        public async Task<bool> QuickStartAsync()
        {
            if (!_isConnected)
            {
                OperationCompleted?.Invoke("快速启动", false);
                return false;
            }

            try
            {
                bool result1 = await SetControlModeAsync(ControlMode.Remote);
                bool result2 = await SetOutputRangeAsync(OutputRange.Low);

                bool success = result1 && result2;
                OperationCompleted?.Invoke("快速启动", success);

                return success;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"快速启动失败: {ex.Message}");
                OperationCompleted?.Invoke("快速启动", false);
                return false;
            }
        }

        /// <summary>
        /// 紧急停止 - 复位电源并切换到本机控制
        /// </summary>
        /// <returns>紧急停止是否成功</returns>
        public async Task<bool> EmergencyStopAsync()
        {
            if (!_isConnected)
            {
                OperationCompleted?.Invoke("紧急停止", false);
                return false;
            }

            try
            {
                bool result1 = await PowerResetAsync();
                await Task.Delay(100); // 等待复位完成
                bool result2 = await SetControlModeAsync(ControlMode.Local);

                bool success = result1 && result2;
                OperationCompleted?.Invoke("紧急停止", success);

                return success;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"紧急停止失败: {ex.Message}");
                OperationCompleted?.Invoke("紧急停止", false);
                return false;
            }
        }
        #endregion

        #region 工具方法
        /// <summary>
        /// 获取系统可用串口列表
        /// </summary>
        /// <returns>串口名称数组</returns>
        public string[] GetAvailableComPorts()
        {
            try
            {
                return SerialPort.GetPortNames();
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"获取可用串口列表失败: {ex.Message}");
                return new string[0];
            }
        }
        #endregion

        #region 私有事件处理
        /// <summary>
        /// 定时器事件处理 - 定期读取电源数据
        /// </summary>
        private async void OnRefreshTimer_Tick(object sender, EventArgs e)
        {
            if (!_isConnected) return;

            try
            {
                // 在后台线程中读取数据，避免阻塞UI
                await Task.Run(() =>
                {
                    lock (_lockObject)
                    {
                        if (_powerSupply == null) return;

                        // 读取所有电源数据
                        _currentData.VoltageU = _powerSupply.ReadVoltage(Phase.U);
                        _currentData.VoltageV = _powerSupply.ReadVoltage(Phase.V);
                        _currentData.VoltageW = _powerSupply.ReadVoltage(Phase.W);

                        _currentData.CurrentU = _powerSupply.ReadCurrent(Phase.U);
                        _currentData.CurrentV = _powerSupply.ReadCurrent(Phase.V);
                        _currentData.CurrentW = _powerSupply.ReadCurrent(Phase.W);

                        _currentData.PowerU = _powerSupply.ReadPower(Phase.U);
                        _currentData.PowerV = _powerSupply.ReadPower(Phase.V);
                        _currentData.PowerW = _powerSupply.ReadPower(Phase.W);

                        _currentData.Frequency = _powerSupply.ReadFrequency();
                        _currentData.FaultStatus = _powerSupply.QueryFaultStatus();

                        _currentData.UpdateTime = DateTime.Now;
                        _currentData.IsConnected = true;
                    }
                });

                // 触发数据更新事件（在UI线程中执行）
                DataUpdated?.Invoke(CurrentData);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"电源数据读取失败: {ex.Message}");

                // 通信异常时更新连接状态
                lock (_lockObject)
                {
                    _currentData.IsConnected = false;
                    _isConnected = false;
                }

                // 停止定时器并通知连接断开
                _refreshTimer.Stop();
                ConnectionStatusChanged?.Invoke(false);
            }
        }
        #endregion

        #region 资源释放
        /// <summary>
        /// 释放所有资源
        /// </summary>
        public void Dispose()
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();

            lock (_lockObject)
            {
                _powerSupply?.Close();
                _powerSupply?.Dispose();
            }
        }
        #endregion
    }
}

/// <summary>
/// PowerSupplyData扩展方法
/// </summary>
public static class PowerSupplyDataExtensions
{
    /// <summary>
    /// 创建PowerSupplyData的深拷贝
    /// </summary>
    public static PowerSupplyData Clone(this PowerSupplyData original)
    {
        return new PowerSupplyData
        {
            VoltageU = original.VoltageU,
            VoltageV = original.VoltageV,
            VoltageW = original.VoltageW,
            CurrentU = original.CurrentU,
            CurrentV = original.CurrentV,
            CurrentW = original.CurrentW,
            PowerU = original.PowerU,
            PowerV = original.PowerV,
            PowerW = original.PowerW,
            Frequency = original.Frequency,
            FaultStatus = original.FaultStatus,
            UpdateTime = original.UpdateTime,
            IsConnected = original.IsConnected
        };
    }
}