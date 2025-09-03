using System.IO.Ports;
using static MainUI.CurrencyHelper.PowerSupplyProtocol;
using Timer = System.Windows.Forms.Timer;

namespace MainUI
{
    public partial class frmPowerSupplyForm : Form
    {
        private PowerSupplyProtocol powerSupply;
        private Timer refreshTimer;
        private PowerSupplyData currentData;
        private bool isConnected = false;

        public frmPowerSupplyForm()
        {
            InitializeComponent();
            InitializeData();
            SetupTimer();
            LoadComPorts();
            SetupDefaultValues();
        }

        private void SetupDefaultValues()
        {
            // 设置默认值
            if (cmbControlMode.Items.Count > 0) cmbControlMode.SelectedIndex = 1; // 电脑控制
            if (cmbOutputRange.Items.Count > 0) cmbOutputRange.SelectedIndex = 1; // 低档
        }

        private void LoadComPorts()
        {
            // 加载可用串口
            string[] ports = SerialPort.GetPortNames();
            cmbComPort.Items.Clear();
            cmbComPort.Items.AddRange(ports);
            if (cmbComPort.Items.Count > 0) cmbComPort.SelectedIndex = 0;
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

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (!isConnected || powerSupply == null) return;

            // 防止重叠执行
            refreshTimer.Enabled = false;

            try
            {
                // 使用CancellationToken控制超时
                using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(1500)); // 总超时1.5秒
                // 分批异步读取数据，避免一次性读取太多导致卡死
                var tasks = new List<Task>();

                // 第一批：电压数据
                var voltageTask = Task.Run(async () =>
                {
                    try
                    {
                        return await powerSupply.ReadAllVoltagesAsync(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        return (0.0, 0.0, 0.0);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"读取电压失败: {ex.Message}");
                        return (0.0, 0.0, 0.0);
                    }
                }, cts.Token);

                // 第二批：电流数据  
                var currentTask = Task.Run(async () =>
                {
                    try
                    {
                        return await powerSupply.ReadAllCurrentsAsync(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        return (0.0, 0.0, 0.0);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"读取电流失败: {ex.Message}");
                        return (0.0, 0.0, 0.0);
                    }
                }, cts.Token);

                // 第三批：功率和频率
                var powerTask = Task.Run(async () =>
                {
                    try
                    {
                        return await powerSupply.ReadAllPowersAsync(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        return (0.0, 0.0, 0.0);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"读取功率失败: {ex.Message}");
                        return (0.0, 0.0, 0.0);
                    }
                }, cts.Token);

                var frequencyTask = Task.Run(async () =>
                {
                    try
                    {
                        return await powerSupply.ReadFrequencyAsync(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        return 0.0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"读取频率失败: {ex.Message}");
                        return 0.0;
                    }
                }, cts.Token);

                var faultTask = Task.Run(async () =>
                {
                    try
                    {
                        return await powerSupply.QueryFaultStatusAsync(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        return FaultType.Normal;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"读取故障状态失败: {ex.Message}");
                        return FaultType.Normal;
                    }
                }, cts.Token);

                // 等待所有任务完成或超时
                try
                {
                    await Task.WhenAll(voltageTask, currentTask, powerTask, frequencyTask, faultTask);

                    // 更新数据
                    (double voltagesU, double voltagesV, double voltagesW) = await voltageTask;
                    (double currentsU, double currentsV, double currentsW) = await currentTask;
                    (double powersU, double powersV, double powersW)  = await powerTask;
                    var frequency = await frequencyTask;
                    var faultStatus = await faultTask;

                    currentData.VoltageU = voltagesU;
                    currentData.VoltageV = voltagesV;
                    currentData.VoltageW = voltagesW;
                    currentData.CurrentU = currentsU;
                    currentData.CurrentV = currentsV;
                    currentData.CurrentW = currentsW;
                    currentData.PowerU = powersU;
                    currentData.PowerV = powersV;
                    currentData.PowerW = powersW;
                    currentData.Frequency = frequency;
                    currentData.FaultStatus = faultStatus;
                    currentData.UpdateTime = DateTime.Now;
                    currentData.IsConnected = true;

                    // 更新UI显示
                    UpdateUI();
                }
                catch (OperationCanceledException)
                {
                    // 超时处理
                    ShowMessage("数据读取超时");
                    currentData.IsConnected = false;
                }
            }
            catch (Exception ex)
            {
                // 通讯异常处理
                currentData.IsConnected = false;
                ShowMessage($"通讯异常: {ex.Message}");

                // 考虑自动重连或暂停刷新
                HandleCommunicationError();
            }
            finally
            {
                // 确保定时器重新启动
                if (isConnected)
                {
                    refreshTimer.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 处理通讯错误
        /// </summary>
        private void HandleCommunicationError()
        {
            // 连续失败计数
            int failureCount = 0;
            failureCount++;

            if (failureCount >= 3) // 连续失败3次后暂停刷新
            {
                refreshTimer.Interval = 2000; // 延长刷新间隔到2秒
                ShowMessage("检测到连续通讯失败，已降低刷新频率");
            }

            if (failureCount >= 10) // 连续失败10次后自动断开
            {
                ShowMessage("通讯持续失败，自动断开连接");
                Disconnect();
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

            // 更新连接状态
            lblConnectionStatus.Text = currentData.IsConnected ? $"已连接 - {currentData.UpdateTime:HH:mm:ss}" : "连接断开";
            lblConnectionStatus.ForeColor = currentData.IsConnected ? Color.Green : Color.Red;
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

        // 事件处理方法
        private async void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbComPort.SelectedItem == null)
                {
                    ShowMessage("请选择串口");
                    return;
                }

                // 禁用连接按钮防止重复点击
                btnConnect.Enabled = false;
                btnConnect.Text = "连接中...";

                string portName = cmbComPort.SelectedItem.ToString();

                // 异步初始化串口
                await Task.Run(() =>
                {
                    powerSupply = new PowerSupplyProtocol(portName, 9600);
                    powerSupply.Open();

                    // 测试通讯是否正常
                    var testResult = powerSupply.QueryFaultStatus();
                });

                isConnected = true;
                btnConnect.Enabled = false;
                btnConnect.Text = "连接";
                btnDisconnect.Enabled = true;
                cmbComPort.Enabled = false;

                // 重置刷新间隔
                refreshTimer.Interval = 1000;
                refreshTimer.Start();
                ShowMessage("连接成功");
            }
            catch (Exception ex)
            {
                btnConnect.Enabled = true;
                btnConnect.Text = "连接";
                ShowMessage($"连接失败: {ex.Message}");
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            refreshTimer.Stop();
            isConnected = false;

            powerSupply?.Close();
            powerSupply?.Dispose();
            powerSupply = null;

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            cmbComPort.Enabled = true;

            currentData.IsConnected = false;
            UpdateUI();

            ShowMessage("已断开连接");
        }

        private async void BtnSetControlMode_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnSetControlMode.Enabled = false;
                btnSetControlMode.Text = "设置中...";

                var mode = cmbControlMode.SelectedIndex == 0 ?
                    PowerSupplyProtocol.ControlMode.Local : PowerSupplyProtocol.ControlMode.Remote;

                bool success = await Task.Run(() => powerSupply.SetControlMode(mode));
                ShowMessage($"设置控制模式: {(success ? "成功" : "失败")}");
            }
            catch (Exception ex)
            {
                ShowMessage($"设置失败: {ex.Message}");
            }
            finally
            {
                btnSetControlMode.Enabled = true;
                btnSetControlMode.Text = "设置";
            }
        }

        private async void BtnSetOutputRange_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnSetOutputRange.Enabled = false;
                btnSetOutputRange.Text = "设置中...";

                var range = cmbOutputRange.SelectedIndex == 0 ?
                    PowerSupplyProtocol.OutputRange.High : PowerSupplyProtocol.OutputRange.Low;

                bool success = await Task.Run(() => powerSupply.SetOutputRange(range));
                ShowMessage($"设置输出档位: {(success ? "成功" : "失败")}");
            }
            catch (Exception ex)
            {
                ShowMessage($"设置失败: {ex.Message}");
            }
            finally
            {
                btnSetOutputRange.Enabled = true;
                btnSetOutputRange.Text = "设置";
            }
        }

        private async void BtnSetVoltage_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnSetVoltage.Enabled = false;
                btnSetVoltage.Text = "设置中...";

                var range = cmbOutputRange.SelectedIndex == 0 ?
                    PowerSupplyProtocol.OutputRange.High : PowerSupplyProtocol.OutputRange.Low;

                bool success = await Task.Run(() =>
                    powerSupply.SetVoltage((double)numVoltage.Value, range));
                ShowMessage($"设置电压: {(success ? "成功" : "失败")}");
            }
            catch (Exception ex)
            {
                ShowMessage($"设置失败: {ex.Message}");
            }
            finally
            {
                btnSetVoltage.Enabled = true;
                btnSetVoltage.Text = "设置";
            }
        }

        private async void BtnSetFrequency_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnSetFrequency.Enabled = false;
                btnSetFrequency.Text = "设置中...";

                bool success = await Task.Run(() =>
                    powerSupply.SetFrequency((double)numFrequency.Value));
                ShowMessage($"设置频率: {(success ? "成功" : "失败")}");
            }
            catch (Exception ex)
            {
                ShowMessage($"设置失败: {ex.Message}");
            }
            finally
            {
                btnSetFrequency.Enabled = true;
                btnSetFrequency.Text = "设置";
            }
        }

        private async void BtnReset_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                btnReset.Enabled = false;
                btnReset.Text = "复位中...";

                bool success = await Task.Run(() => powerSupply.PowerReset());
                ShowMessage($"电源复位: {(success ? "成功" : "失败")}");
            }
            catch (Exception ex)
            {
                ShowMessage($"复位失败: {ex.Message}");
            }
            finally
            {
                btnReset.Enabled = true;
                btnReset.Text = "电源复位";
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(this, $"[{DateTime.Now:HH:mm:ss}] {message}");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Disconnect();
            base.OnFormClosing(e);
        }

        // 快捷操作事件处理
        private void BtnQuickStart_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ShowMessage("请先连接设备");
                return;
            }

            try
            {
                // 快速启动：设置为电脑控制模式 + 低档输出
                bool success1 = powerSupply.SetControlMode(PowerSupplyProtocol.ControlMode.Remote);
                bool success2 = powerSupply.SetOutputRange(PowerSupplyProtocol.OutputRange.Low);

                if (success1 && success2)
                {
                    // 更新UI显示
                    cmbControlMode.SelectedIndex = 1;
                    cmbOutputRange.SelectedIndex = 1;
                    ShowMessage("快速启动成功");
                }
                else
                {
                    ShowMessage("快速启动失败");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"快速启动失败: {ex.Message}");
            }
        }

        private void BtnEmergencyStop_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ShowMessage("设备未连接");
                return;
            }

            try
            {
                // 紧急停止：复位电源并设置为本机控制
                bool resetSuccess = powerSupply.PowerReset();
                Thread.Sleep(100); // 等待复位完成
                bool modeSuccess = powerSupply.SetControlMode(PowerSupplyProtocol.ControlMode.Local);

                if (resetSuccess && modeSuccess)
                {
                    cmbControlMode.SelectedIndex = 0;
                    ShowMessage("紧急停止执行完成");
                }
                else
                {
                    ShowMessage("紧急停止执行失败");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"紧急停止失败: {ex.Message}");
            }
        }
    }
}
