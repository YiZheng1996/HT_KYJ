using static MainUI.PowerSupplyControl.PowerSupplyProtocol;
using Timer = System.Windows.Forms.Timer;

namespace MainUI.PowerSupplyControl
{
    public partial class frmPowerSupplyForm : UIForm
    {
        #region 私有字段修改
        /// <summary>
        /// 电源服务实例，负责所有电源相关的操作
        /// </summary>
        private readonly PowerSupplyService _powerService;

        /// <summary>
        /// 界面刷新定时器，定期更新UI显示
        /// </summary>
        private Timer refreshTimer;

        /// <summary>
        /// 当前显示的电源数据
        /// </summary>
        private PowerSupplyData currentData;
        #endregion

        /// <summary>
        /// 接收电源服务实例
        /// </summary>
        /// <param name="powerService">电源服务实例</param>
        public frmPowerSupplyForm(PowerSupplyService powerService)
        {
            InitializeComponent();

            // 保存电源服务引用
            _powerService = powerService ?? throw new ArgumentNullException(nameof(powerService));

            // 初始化数据和UI
            InitializeData();
            SetupTimer();
            SetupDefaultValues();

            // 订阅电源服务事件
            SubscribePowerServiceEvents();

            // 初始化UI状态
            UpdateConnectionUI();
        }

        #region 事件订阅和处理
        /// <summary>
        /// 订阅电源服务事件
        /// </summary>
        private void SubscribePowerServiceEvents()
        {
            _powerService.DataUpdated += OnPowerServiceDataUpdated;
            _powerService.ConnectionStatusChanged += OnPowerServiceConnectionChanged;
            _powerService.OperationCompleted += OnPowerServiceOperationCompleted;
        }

        /// <summary>
        /// 取消订阅电源服务事件
        /// </summary>
        private void UnsubscribePowerServiceEvents()
        {
            _powerService.DataUpdated -= OnPowerServiceDataUpdated;
            _powerService.ConnectionStatusChanged -= OnPowerServiceConnectionChanged;
            _powerService.OperationCompleted -= OnPowerServiceOperationCompleted;
        }

        /// <summary>
        /// 处理电源服务数据更新事件
        /// </summary>
        /// <param name="data">最新电源数据</param>
        private void OnPowerServiceDataUpdated(PowerSupplyData data)
        {
            try
            {
                // 确保在UI线程中执行
                if (InvokeRequired)
                {
                    Invoke(new Action<PowerSupplyData>(OnPowerServiceDataUpdated), data);
                    return;
                }

                // 更新当前数据并刷新UI
                currentData = data;
                UpdateUI();
            }
            catch (Exception ex)
            {
                ShowMessage($"更新数据显示失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 处理电源服务连接状态变化事件
        /// </summary>
        /// <param name="isConnected">连接状态</param>
        private void OnPowerServiceConnectionChanged(bool isConnected)
        {
            try
            {
                // 确保在UI线程中执行
                if (InvokeRequired)
                {
                    Invoke(new Action<bool>(OnPowerServiceConnectionChanged), isConnected);
                    return;
                }

                // 更新连接相关UI状态
                UpdateConnectionUI();
            }
            catch (Exception ex)
            {
                ShowMessage($"更新连接状态显示失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 处理电源服务操作完成事件
        /// </summary>
        /// <param name="operation">操作描述</param>
        /// <param name="success">操作结果</param>
        private void OnPowerServiceOperationCompleted(string operation, bool success)
        {
            try
            {
                // 确保在UI线程中执行
                if (InvokeRequired)
                {
                    Invoke(new Action<string, bool>(OnPowerServiceOperationCompleted), operation, success);
                    return;
                }

                // 显示操作结果
                ShowMessage($"{operation}: {(success ? "成功" : "失败")}");
            }
            catch (Exception ex)
            {
                // 避免在错误处理中再次显示消息框造成循环
                System.Diagnostics.Debug.WriteLine($"显示操作结果失败: {ex.Message}");
            }
        }
        #endregion

        /// <summary>
        /// 更新连接相关的UI状态
        /// </summary>
        private void UpdateConnectionUI()
        {
            try
            {
                bool isConnected = _powerService.IsConnected;
                string currentPort = _powerService.CurrentComPort;

                // 更新连接状态标签
                if (isConnected)
                {
                    lblConnectionStatus.Text = $"已连接 - {currentPort}";
                    lblConnectionStatus.ForeColor = Color.Green;
                }
                else
                {
                    lblConnectionStatus.Text = "未连接";
                    lblConnectionStatus.ForeColor = Color.Red;
                }

                // 更新当前数据（如果有的话）
                currentData = _powerService.CurrentData;
                UpdateUI();
            }
            catch (Exception ex)
            {
                ShowMessage($"更新连接UI状态失败: {ex.Message}");
            }
        }

        private void SetupDefaultValues()
        {
            // 设置默认值
            if (cmbControlMode.Items.Count > 0) cmbControlMode.SelectedIndex = 1; // 电脑控制
            if (cmbOutputRange.Items.Count > 0) cmbOutputRange.SelectedIndex = 1; // 低档
        }


        private void InitializeData()
        {
            currentData = new PowerSupplyData
            {
                UpdateTime = DateTime.Now,
                IsConnected = false
            };
        }

        private void SetupTimer()
        {
            refreshTimer = new()
            {
                Interval = 1000 // 增加到1000ms刷新一次，降低通讯频率
            };
            refreshTimer.Tick += RefreshTimer_Tick;
        }

        /// <summary>
        /// 界面刷新定时器事件处理
        /// 现在主要用于定期更新UI显示，数据由服务事件提供
        /// </summary>
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 从服务获取最新数据并更新UI
                currentData = _powerService.CurrentData;
                UpdateUI();
            }
            catch (Exception ex)
            {
                // 定时器中的异常不应显示消息框，只记录日志
                NlogHelper.Default.Error($"界面刷新定时器异常: {ex.Message}", ex);
            }
        }

        private void UpdateUI()
        {
            // 确保在UI线程中更新
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateUI));
                return;
            }

            // 更新电压显示
            lblVoltageU.Text = $"U: {currentData.VoltageU:F1}V";
            lblVoltageV.Text = $"V: {currentData.VoltageV:F1}V";
            lblVoltageW.Text = $"W: {currentData.VoltageW:F1}V";

            // 更新电流显示
            lblCurrentU.Text = $"U: {currentData.CurrentU:F1}A";
            lblCurrentV.Text = $"V: {currentData.CurrentV:F1}A";
            lblCurrentW.Text = $"W: {currentData.CurrentW:F1}A";

            // 更新功率显示
            lblPowerU.Text = $"U: {currentData.PowerU:F0}W";
            lblPowerV.Text = $"V: {currentData.PowerV:F0}W";
            lblPowerW.Text = $"W: {currentData.PowerW:F0}W";
            lblTotalPower.Text = $"总功率: {currentData.TotalPower:F0}W";

            // 更新频率和状态
            lblFrequency.Text = $"频率: {currentData.Frequency:F1}HZ";
            lblFaultStatus.Text = $"状态: {GetFaultStatusText(currentData.FaultStatus)}";
            lblFaultStatus.ForeColor = currentData.FaultStatus == FaultType.Normal ? Color.Green : Color.Red;

            // 更新进度条
            progressVoltageU.Value = Math.Min((int)currentData.VoltageU, progressVoltageU.Maximum);
            progressVoltageV.Value = Math.Min((int)currentData.VoltageV, progressVoltageV.Maximum);
            progressVoltageW.Value = Math.Min((int)currentData.VoltageW, progressVoltageW.Maximum);

            progressCurrentU.Value = Math.Min((int)currentData.CurrentU, progressCurrentU.Maximum);
            progressCurrentV.Value = Math.Min((int)currentData.CurrentV, progressCurrentV.Maximum);
            progressCurrentW.Value = Math.Min((int)currentData.CurrentW, progressCurrentW.Maximum);
        }

        private string GetFaultStatusText(FaultType faultType)
        {
            return faultType switch
            {
                FaultType.Normal => "正常",
                FaultType.OverTemperature => "过温保护",
                FaultType.Overload => "过载保护",
                FaultType.OverVoltage => "过压保护",
                FaultType.PowerFailure => "输入掉电保护",
                FaultType.ShortCircuit => "短路保护",
                _ => "未知状态"
            };
        }

        #region 设备控制事件处理
        /// <summary>
        /// 设置控制模式按钮点击事件
        /// </summary>
        private async void BtnSetControlMode_Click(object sender, EventArgs e)
        {
            if (!_powerService.IsConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnSetControlMode.Enabled = false;
                btnSetControlMode.Text = "设置中...";

                var mode = cmbControlMode.SelectedIndex == 0 ?
                    ControlMode.Local : ControlMode.Remote;

                // 使用电源服务异步设置控制模式
                bool success = await _powerService.SetControlModeAsync(mode);

                // 结果通过OperationCompleted事件显示
            }
            catch (Exception ex)
            {
                ShowMessage($"设置控制模式时发生异常: {ex.Message}");
            }
            finally
            {
                btnSetControlMode.Enabled = true;
                btnSetControlMode.Text = "设置";
            }
        }
        /// <summary>
        /// 设置输出档位按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnSetOutputRange_Click(object sender, EventArgs e)
        {
            if (!_powerService.IsConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnSetOutputRange.Enabled = false;
                btnSetOutputRange.Text = "设置中...";

                var range = cmbOutputRange.SelectedIndex == 0 ?
                    OutputRange.High : OutputRange.Low;

                // 使用电源服务异步设置输出档位
                bool success = await _powerService.SetOutputRangeAsync(range);

                // 结果通过OperationCompleted事件显示
            }
            catch (Exception ex)
            {
                ShowMessage($"设置输出档位时发生异常: {ex.Message}");
            }
            finally
            {
                btnSetOutputRange.Enabled = true;
                btnSetOutputRange.Text = "设置";
            }
        }

        /// <summary>
        /// 设置输出电压按钮点击事件
        /// </summary>

        private async void BtnSetVoltage_Click(object sender, EventArgs e)
        {
            if (!_powerService.IsConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnSetVoltage.Enabled = false;
                btnSetVoltage.Text = "设置中...";

                double voltage = (double)numVoltage.Value;

                // 根据当前选择的档位来设置电压
                var range = cmbOutputRange.SelectedIndex == 0 ?
                    OutputRange.High : OutputRange.Low;

                // 使用电源服务异步设置电压，传递档位参数
                bool success = await _powerService.SetVoltageAsync(voltage, range);

                // 结果通过OperationCompleted事件显示
            }
            catch (Exception ex)
            {
                ShowMessage($"设置输出电压时发生异常: {ex.Message}");
            }
            finally
            {
                btnSetVoltage.Enabled = true;
                btnSetVoltage.Text = "设置";
            }
        }

        /// <summary>
        /// 设置输出频率按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnSetFrequency_Click(object sender, EventArgs e)
        {
            if (!_powerService.IsConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnSetFrequency.Enabled = false;
                btnSetFrequency.Text = "设置中...";

                double frequency = (double)numFrequency.Value;

                // 使用电源服务异步设置频率
                bool success = await _powerService.SetFrequencyAsync(frequency);

                // 结果通过OperationCompleted事件显示
            }
            catch (Exception ex)
            {
                ShowMessage($"设置输出频率时发生异常: {ex.Message}");
            }
            finally
            {
                btnSetFrequency.Enabled = true;
                btnSetFrequency.Text = "设置";
            }
        }

        /// <summary>
        /// 电源复位按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnReset_Click(object sender, EventArgs e)
        {
            if (!_powerService.IsConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnReset.Enabled = false;
                btnReset.Text = "复位中...";

                // 使用电源服务异步执行复位
                bool success = await _powerService.PowerResetAsync();

                // 结果通过OperationCompleted事件显示
            }
            catch (Exception ex)
            {
                ShowMessage($"电源复位时发生异常: {ex.Message}");
            }
            finally
            {
                btnReset.Enabled = true;
                btnReset.Text = "电源复位";
            }
        }

        /// <summary>
        /// 快速启动按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnQuickStart_Click(object sender, EventArgs e)
        {
            if (!_powerService.IsConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnQuickStart.Enabled = false;
                btnQuickStart.Text = "启动中...";

                // 使用电源服务异步执行快速启动
                bool success = await _powerService.QuickStartAsync();

                if (success)
                {
                    // 更新UI显示为对应设置
                    cmbControlMode.SelectedIndex = 1; // 电脑控制
                    cmbOutputRange.SelectedIndex = 1; // 低档
                }

                // 结果通过OperationCompleted事件显示
            }
            catch (Exception ex)
            {
                ShowMessage($"快速启动时发生异常: {ex.Message}");
            }
            finally
            {
                btnQuickStart.Enabled = true;
                btnQuickStart.Text = "快速启动\r\n(电脑控制+低档)";
            }
        }

        /// <summary>
        /// 紧急停止按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnEmergencyStop_Click(object sender, EventArgs e)
        {
            if (!_powerService.IsConnected)
            {
                ShowMessage("设备未连接");
                return;
            }

            try
            {
                btnEmergencyStop.Enabled = false;
                btnEmergencyStop.Text = "停止中...";

                // 使用电源服务异步执行紧急停止
                bool success = await _powerService.EmergencyStopAsync();

                if (success)
                {
                    // 更新UI显示为对应设置
                    cmbControlMode.SelectedIndex = 0; // 本机控制
                }

                // 结果通过OperationCompleted事件显示
            }
            catch (Exception ex)
            {
                ShowMessage($"紧急停止时发生异常: {ex.Message}");
            }
            finally
            {
                btnEmergencyStop.Enabled = true;
                btnEmergencyStop.Text = "紧急停止";
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(this, $"[{DateTime.Now:HH:mm:ss}] {message}");
        }

        /// <summary>
        /// 窗体关闭前的清理工作
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                // 停止界面刷新定时器
                refreshTimer?.Stop();

                // 取消订阅电源服务事件
                UnsubscribePowerServiceEvents();

                // 注意：不要在这里断开电源连接，因为其他地方可能还在使用
                // 电源连接由服务统一管理，窗体关闭不应影响连接状态
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"窗体关闭清理时发生异常: {ex.Message}", ex);
            }
            finally
            {
                base.OnFormClosing(e);
            }
        }
        #endregion
    }
}
