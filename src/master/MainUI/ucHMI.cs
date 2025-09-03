using AntdUI;
using MainUI.PowerSupplyControl;
using MainUI.Service;
using System.IO.Ports;
using Label = System.Windows.Forms.Label;
using Timer = System.Windows.Forms.Timer;

namespace MainUI
{
    public partial class UcHMI : UserControl
    {
        #region 全局变量
        private readonly frmMainMenu frm = new();
        public delegate void RunStatusHandler(bool obj);
        public event RunStatusHandler EmergencyStatusChanged;
        private static ParaConfig paraconfig;
        private readonly List<ItemPointModel> _itemPoints = [];
        private readonly ControlMappings controls = new();
        private readonly ControlInitializationService _controlInitService;
        public delegate void TestStateHandler(bool isTesting);
        public event TestStateHandler TestStateChanged;
        private readonly string reportPath;
        private readonly string dslPath;
        private readonly OPCEventRegistration _opcEventRegistration;
        private readonly DSLService _dslService;
        private readonly TestExecutionService _testService;
        private readonly ReportService _reportService;
        private readonly TableService _tableService;
        private readonly CountdownService _countdownService;

        #endregion
        public UcHMI()
        {
            InitializeComponent();
            _opcEventRegistration = new OPCEventRegistration(this);
            reportPath = Path.Combine(Application.StartupPath, Constants.ReportsPath);
            dslPath = Path.Combine(Application.StartupPath, Constants.ProcedurePath);
            _dslService = new DSLService(dslPath);
            _reportService = new ReportService(reportPath);
            _testService = new TestExecutionService(_dslService, TableColor);
            _tableService = new TableService(TableItemPoint, _itemPoints);
            _countdownService = new CountdownService(LabTestTime);
            _controlInitService = new ControlInitializationService(controls);
        }

        #region 初始化
        public void Init()
        {
            try
            {
                // 1. 初始化OPC连接和组 - 与PLC通信基础
                InitializeOPC();
                // 2. 初始化界面控件和数据绑定
                InitializeControls();
                // 3. 注册OPC组事件处理程序 - 处理PLC数据变化
                RegisterOPCHandlers();
                // 4. 注册测试状态和提示事件处理程序
                RegisterTestEventHandlers();
                // 5. 设置控件初始状态和默认值
                SetInitialState();
                // 6. 初始化电源监控系统
                InitializePowerSupply();
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"HMI系统初始化失败: {ex.Message}");
                MessageBox.Show($"HMI系统初始化失败:{ex.Message}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 初始化OPC连接和组
        private void InitializeOPC()
        {
            OPCHelper.Init();
        }

        // 初始化控件和数据
        private void InitializeControls()
        {
            _controlInitService.InitializeAllControls(this);
            _tableService.InitColumns();
        }

        private Table.CellStyleInfo TableItemPoint_SetRowStyle(object sender, TableSetRowStyleEventArgs e)
        {
            return _tableService.SetRowStyle(e.Record);
        }

        private void TableItemPoint_CheckedChanged(object sender, TableCheckEventArgs e)
        {
            _tableService.HandleCheckedChanged(e);
        }

        // 注册OPC组事件处理程序
        private void RegisterOPCHandlers()
        {
            _opcEventRegistration.RegisterAll();
        }

        // 注册测试状态和提示事件处理程序
        private void RegisterTestEventHandlers()
        {
            BaseTest.TestStateChanged += BaseTest_TestStateChanged;
            BaseTest.TipsChanged += BaseTest_TipsChanged;
        }

        // 设置初始状态
        private void SetInitialState()
        {
            btnStopTest.Enabled = false;
        }

        private void BaseTest_TipsChanged(object sender, object info)
        {
            AppendText(info.ToString());
        }

        private void BaseTest_TestStateChanged(bool isTesting)
        {
            Disable(isTesting);
        }

        /// <summary>
        /// 根据测试状态启用或禁用控件
        /// </summary>
        /// <param name="isTesting">是否正在测试中</param>
        private void Disable(bool isTesting)
        {
            btnStopTest.Enabled = isTesting;  // 停止按钮在测试时启用
            btnStartTest.Enabled = !isTesting; // 开始按钮在测试时禁用

            // 在测试进行时禁用的控件组
            var controlsToDisable = new Control[]
            {
                btnProductSelection, // 产品选择按钮
                TableItemPoint,    // 测试项表格
                panelHand         // 手动控制面板
            };

            // 批量设置控件状态
            foreach (var control in controlsToDisable)
            {
                control.Enabled = !isTesting;
            }

            Refresh(); // 触发UI更新
        }
        #endregion

        #region 值改变事件
        public void TestCongrp_TestConGroupChanged(object sender, int index, object value)
        {
            if (controls.DigitalOutputs.TryGetValue(index, out UISwitch iSwitch))
            {
                iSwitch.Active = value.ToBool();
            }
            if (controls.DigitalOutputButtons.TryGetValue(index, out UIButton btn))
            {
                NavigationButtonStyles.BtnColor(btn, value.ToBool());
            }
        }

        public void AIgrp_AIvalueGrpChanged(object sender, int index, double value)
        {
            if (controls.AnalogInputs.TryGetValue(index, out Label label))
            {
                label.Text = value.ToString("f1");
            }
        }

        public void AOgrp_AOvalueGrpChanged(object sender, int index, double value)
        {
            switch (index)
            {
                default:
                    break;
            }
        }
        public void DIgrp_DIGroupChanged(object sender, int index, bool value)
        {
            try
            {
                if (index == 0)
                {
                    if (!value) IsTestEnd();
                    EmergencyStatusChanged?.Invoke(value);
                }
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error("DI模块事件报错：" + ex.Message);
            }
        }

        public void DOgrp_DOgrpChanged(object sender, int index, bool value) { }

        // 温湿度
        public void WSDvalueGrpChaned(object sender, int index, double value)
        {
            if (index == 0)
            {
                LabSD.Text = value.ToString("f1");
            }
            else
            {
                LabWD.Text = value.ToString("f1");
            }
        }

        // 环境压力
        public void HJYLvalueGrpChaned(object sender, int index, double value)
        {
            LabHJYL.Text = value.ToString("f1");
        }

        // 泄露储气压力
        public void YL01valueGrpChaned(object sender, int index, double value)
        {
            LabPressure01.Text = value.ToString("f1");
        }

        // 负荷储气压力
        public void YL02valueGrpChaned(object sender, int index, double value)
        {
            LabPressure02.Text = value.ToString("f1");
        }

        // 计测储气压力
        public void YL03valueGrpChaned(object sender, int index, double value)
        {
            LabPressure03.Text = value.ToString("f1");
        }

        // 温度传感器
        public void TemperaturevalueGrpChaned(object sender, int index, double value)
        {
            LabTemperature01.Text = value.ToString("f1");
        }


        #endregion

        #region 参数
        private void InitParaConfig()
        {
            try
            {
                if (VarHelper.TestViewModel == null) return;

                // 初始化和加载参数配置
                paraconfig = new ParaConfig();
                paraconfig.SetSectionName(VarHelper.ModelTypeName);
                paraconfig.Load();
                BaseTest.para = paraconfig;

                //// 初始化测试项
                //_tableService.LoadTestItems();

                //// 加载DSL
                //_dslService.LoadDSL(VarHelper.TestViewModel.ID, paraconfig);

                // 处理报表文件
                if (!string.IsNullOrEmpty(paraconfig.RptFile))
                {
                    ucGrid1.LoadFile(_reportService
                        .InitializeReportFile(paraconfig));
                }
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK($"加载参数错误：{ex.Message}");
                NlogHelper.Default.Error($"加载参数错误", ex);
            }
        }

        //刷新型号
        public void ParaRefresh()
        {
            try
            {
                if (string.IsNullOrEmpty(VarHelper.TestViewModel.ModelTypeName)) return;
                InitParaConfig();
            }
            catch (Exception ex)
            {
                MessageHelper.MessageYes("刷新型号错误：" + ex.Message);
            }
        }
        #endregion

        #region 自动试验
        private CancellationTokenSource _cancellationTokenSource = new();
        private async void btnStartTest_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 检查前置条件
                (bool Result, string txt) = FrmText();
                if (!Result)
                {
                    MessageHelper.MessageOK(txt, TType.Error);
                    return;
                }

                // 2. 设置UI状态
                Disable(true);
                TestStateChanged?.Invoke(true);

                // 3. 初始化取消计时器令牌
                _cancellationTokenSource = new CancellationTokenSource();

                // 4. 并行执行倒计时和测试
                var countdownTask = _countdownService.StartCountdown(
                    paraconfig.SprayTime.ToInt(),
                    _cancellationTokenSource.Token
                );

                var testTask = _testService.StartTest(_itemPoints);

                // 5. 等待所有任务完成
                await Task.WhenAll(countdownTask, testTask);
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine($"试验已取消：{ex.Message}");
            }
            catch (OperationCanceledException ex)
            {
                Debug.WriteLine($"试验已取消: {ex}");
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK($"试验开始错误：{ex.Message}");
            }
        }

        // 设置行颜色
        private void TableColor(ItemPointModel itemPoint, int state)
        {
            itemPoint.ColorState = state;
            TableItemPoint.Invalidate();
        }

        private void btnStopTest_Click(object sender, EventArgs e) => IsTestEnd();

        private static (bool Result, string txt) FrmText()
        {
            if (!OPCHelper.DIgrp[0])
            {
                return (false, "请注意，急停情况下无法启动自动试验!");
            }
            if (string.IsNullOrEmpty(VarHelper.TestViewModel.ModelName))
            {
                return (false, "未选择型号，无法启动自动试验!");
            }
            if (!OPCHelper.TestCongrp[39].ToBool())
            {
                return (false, "请注意，手动情况下无法启动自动试验!");
            }
            if (string.IsNullOrEmpty(paraconfig.SprayTime) || string.IsNullOrEmpty(paraconfig.ApplyPressure))
            {
                return (false, "请注意，该型号试验参数未设置，无法启动自动试验!");
            }
            return (true, "");
        }

        // 结束试验操作
        private void IsTestEnd()
        {
            try
            {
                Disable(false);
                AppendText("试验结束");
                OPCHelper.TestCongrp[41] = true;
                TestStateChanged?.Invoke(false);

                // 停止测试服务
                _testService.StopTest();
                _countdownService.StopCountdown();
                _cancellationTokenSource.Cancel();
            }
            catch (OperationCanceledException ex)
            {
                Debug.WriteLine($"Task被取消: {ex}");
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"结束试验错误：{ex.Message}", ex);
                MessageHelper.MessageOK(frm, $"结束试验错误：{ex.Message}");
            }
        }
        #endregion

        #region 模拟量设置
        private void btnNozzleMotor_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as UIButton;
                using frmSetOutValue fs = new(OPCHelper.TestCongrp[btn.Tag.ToInt32()].ToDouble(), btn.Text, 10000);
                VarHelper.ShowDialogWithOverlay(frm, fs);
                if (fs.DialogResult == DialogResult.OK)
                {
                    ControlHelper.ButtonClickAsync(sender, () =>
                    {
                        //LabAO01.Text = fs.OutValue.ToString();
                        OPCHelper.TestCongrp[btn.Tag.ToInt32()] = fs.OutValue;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK(frm, $"模拟量设定错误：{ex.Message}");
            }
        }
        #endregion

        #region 报表翻页控制
        private const int DefaultPageSize = 29; // 默认每页显示行数
        private int currentRowIndex = 0; // 当前行索引
        private bool isScrollingDown = false; // 是否向下滚动标记

        /// <summary>
        /// 向上翻页
        /// </summary>
        private void btnPageUp_Click(object sender, EventArgs e)
        {
            int pageSize = LabelNumber.Value.ToInt32();

            // 如果之前是向下滚动,需要先回到起始位置
            if (isScrollingDown)
            {
                currentRowIndex -= DefaultPageSize;
                isScrollingDown = false;
            }

            // 向上翻页,减少行索引
            currentRowIndex = Math.Max(0, currentRowIndex - pageSize);

            // 执行翻页
            ucGrid1.PageTurning(currentRowIndex);
        }

        /// <summary>
        /// 向下翻页
        /// </summary>
        private void btnPageDown_Click(object sender, EventArgs e)
        {
            int pageSize = LabelNumber.Value.ToInt32();

            // 如果是首次向下滚动,需要先移动到默认页大小位置
            if (!isScrollingDown)
            {
                currentRowIndex = DefaultPageSize;
                isScrollingDown = true;
            }
            else
            {
                // 继续向下翻页,增加行索引
                currentRowIndex += pageSize;
            }

            // 执行翻页
            ucGrid1.PageTurning(currentRowIndex);
        }
        #endregion

        #region 报表控件
        string saveFilePath;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSaveParameters()) return;// 参数校验

                if (!ConfirmSaveReport()) return;  // 提示确认

                saveFilePath = _reportService.BuildSaveFilePath(VarHelper.TestViewModel.ModelName); // 保存路径

                _reportService.SaveTestRecord(saveFilePath, new TestRecordModel
                {
                    KindID = VarHelper.TestViewModel.ModelTypeID,
                    ModelID = VarHelper.TestViewModel.ID,
                    TestID = txtNumber.Text,
                    Tester = NewUsers.NewUserInfo.Username,
                    TestTime = DateTime.Now,
                    ReportPath = saveFilePath,
                }); // 保存记录

                ucGrid1.SaveAsPdf(saveFilePath, saveFilePath);  // 导出PDF

                MessageHelper.MessageOK("保存成功", TType.Success);
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK($"保存失败: {ex.Message}", TType.Error);
            }
        }

        // 保存试验报告前参数校验
        private bool ValidateSaveParameters()
        {
            if (string.IsNullOrEmpty(paraconfig?.RptFile))
            {
                MessageHelper.MessageOK("报表模板未设置，无法保存！", TType.Warn);
                return false;
            }

            if (string.IsNullOrEmpty(VarHelper.TestViewModel.ModelName))
            {
                MessageHelper.MessageOK("型号未选择！", TType.Warn);
                return false;
            }
            return true;
        }

        // 确认保存报表
        private static bool ConfirmSaveReport() =>
            MessageHelper.MessageYes("是否保存试验结果？") == DialogResult.OK;

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                ucGrid1.Print(saveFilePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("打印失败：" + ex.StackTrace);
                NlogHelper.Default.Fatal("打印失败：", ex);
            }
        }
        #endregion

        #region 其他
        private void AppendText(string text)
        {
            //txtTestRecord.AppendText($"{DateTime.Now:HH:mm:ss}：{text}\n");
            //txtTestRecord.ScrollToCaret();
        }

        private void btnTechnology_Click(object sender, EventArgs e)
        {
            tabs1.SelectedIndex = 0;
            NavigationButtonStyles.UpdateNavigationButtons
                (tabs1.SelectedIndex, controls);
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            tabs1.SelectedIndex = 1;
            NavigationButtonStyles.UpdateNavigationButtons
                (tabs1.SelectedIndex, controls);
        }

        private void btnProductSelection_Click(object sender, EventArgs e)
        {
            using frmSpec frmSpec = new();
            VarHelper.ShowDialogWithOverlay(frm, frmSpec);
            if (frmSpec.DialogResult == DialogResult.OK)
            {
                alert.Text = $"产品类型：{VarHelper.TestViewModel.ModelTypeName} 产品类型：{VarHelper.TestViewModel.ModelTypeName}";
                alert.Visible = true;
                //txtModel.Text = VarHelper.TestViewModel.ModelName;
                //txtDrawingNo.Text = VarHelper.TestViewModel.DrawingNo;
                ParaRefresh();
            }
        }

        private void RadioAuto_Click(object sender, EventArgs e)
        {
            OPCHelper.TestCongrp[39] = RadioAuto.Checked;
        }

        private void btnWaterPumpStart_Click(object sender, EventArgs e)
        {
            var btn = sender as UIButton;
            OPCHelper.TestCongrp[btn.Tag.ToInt32()] =
                !OPCHelper.TestCongrp[btn.Tag.ToInt32()].ToBool();
        }

        private async void btnFaultRemoval_Click(object sender, EventArgs e)
        {
            var btn = sender as UIButton;
            await FaultClearingAsync(btn);
        }
        private async Task FaultClearingAsync(UIButton btn)
        {
            OPCHelper.TestCongrp[btn.Tag.ToInt32()] = true;
            await Task.Delay(1000);
            OPCHelper.TestCongrp[btn.Tag.ToInt32()] = false;
        }

        private void uiSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            var sder = sender as UISwitch;
            OPCHelper.TestCongrp[sder.Tag.ToInt32()] = true;
        }

        private void uiSwitch_MouseUp(object sender, MouseEventArgs e)
        {
            var sder = sender as UISwitch;
            OPCHelper.TestCongrp[sder.Tag.ToInt32()] = false;
        }


        #endregion

        #region 电源控制公开接口方法
        /// <summary>
        /// 连接指定串口的电源设备
        /// 关闭现有连接后创建新的连接，成功后启动数据刷新
        /// </summary>
        /// <param name="comPort">串口号，如COM1、COM2等</param>
        /// <returns>连接是否成功</returns>
        public bool ConnectPowerSupply(string comPort)
        {
            try
            {
                NlogHelper.Default.Info($"尝试连接电源设备，串口: {comPort}");

                // 如果已有连接，先释放现有资源
                if (_powerSupply != null)
                {
                    _powerTimer.Stop();  // 停止数据刷新
                    _powerSupply.Close(); // 关闭串口
                    _powerSupply.Dispose(); // 释放资源
                    _powerSupply = null;
                }

                // 创建新的电源协议实例，配置串口参数
                _powerSupply = new PowerSupplyProtocol(comPort, 9600);
                _powerSupply.Open(); // 打开串口连接

                // 更新连接状态和当前串口信息
                _powerConnected = true;
                _currentComPort = comPort;

                // 启动数据刷新定时器
                _powerTimer.Start();

                NlogHelper.Default.Info($"电源设备连接成功: {comPort}");
                return true;
            }
            catch (Exception ex)
            {
                // 连接失败时确保状态正确
                _powerConnected = false;
                _currentComPort = "";
                _currentPowerData.IsConnected = false;

                NlogHelper.Default.Error($"电源设备连接失败: {comPort}, 错误: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 断开电源设备连接
        /// 停止数据刷新，关闭串口，释放所有相关资源
        /// </summary>
        public void DisconnectPowerSupply()
        {
            try
            {
                NlogHelper.Default.Info("断开电源设备连接");

                // 停止数据刷新定时器
                _powerTimer?.Stop();

                // 关闭并释放串口资源
                if (_powerSupply != null)
                {
                    _powerSupply.Close();
                    _powerSupply.Dispose();
                    _powerSupply = null;
                }

                // 更新连接状态
                _powerConnected = false;
                _currentComPort = "";
                _currentPowerData.IsConnected = false;

                NlogHelper.Default.Info("电源设备连接已断开");
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"断开电源设备连接时发生错误: {ex.Message}");
            }
        }

        /// <summary>
        /// 获取当前电源数据的副本
        /// 返回最新读取到的所有电源参数，包括电压、电流、功率、频率等
        /// </summary>
        /// <returns>电源数据对象，如果未连接则IsConnected为false</returns>
        public PowerSupplyData GetPowerData()
        {
            // 返回当前数据的副本，避免外部修改影响内部状态
            return _currentPowerData ?? new PowerSupplyData { IsConnected = false };
        }

        /// <summary>
        /// 获取电源设备连接状态
        /// </summary>
        /// <returns>true表示已连接且可正常通信，false表示未连接或通信异常</returns>
        public bool IsPowerConnected => _powerConnected;

        /// <summary>
        /// 获取当前连接的串口号
        /// </summary>
        /// <returns>串口号字符串，如COM1；未连接时返回空字符串</returns>
        public string GetCurrentComPort() => _currentComPort;

        /// <summary>
        /// 设置电源控制模式
        /// </summary>
        /// <param name="isRemote">true为电脑控制模式，false为本机控制模式</param>
        /// <returns>设置是否成功</returns>
        public bool SetControlMode(bool isRemote)
        {
            if (!_powerConnected)
            {
                NlogHelper.Default.Warn("电源未连接，无法设置控制模式");
                return false;
            }

            try
            {
                var mode = isRemote ? PowerSupplyProtocol.ControlMode.Remote : PowerSupplyProtocol.ControlMode.Local;
                bool result = _powerSupply.SetControlMode(mode);

                string modeText = isRemote ? "电脑控制" : "本机控制";
                NlogHelper.Default.Info($"设置控制模式为{modeText}: {(result ? "成功" : "失败")}");

                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"设置控制模式失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 设置电源输出档位
        /// </summary>
        /// <param name="isLow">true为低档(0-150V/42A)，false为高档(0-300V/21A)</param>
        /// <returns>设置是否成功</returns>
        public bool SetOutputRange(bool isLow)
        {
            if (!_powerConnected)
            {
                NlogHelper.Default.Warn("电源未连接，无法设置输出档位");
                return false;
            }

            try
            {
                var range = isLow ? PowerSupplyProtocol.OutputRange.Low : PowerSupplyProtocol.OutputRange.High;
                bool result = _powerSupply.SetOutputRange(range);

                string rangeText = isLow ? "低档(0-150V/42A)" : "高档(0-300V/21A)";
                NlogHelper.Default.Info($"设置输出档位为{rangeText}: {(result ? "成功" : "失败")}");

                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"设置输出档位失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 设置电源输出电压
        /// </summary>
        /// <param name="voltage">目标电压值</param>
        /// <param name="isLowRange">是否为低档模式，影响电压设置范围</param>
        /// <returns>设置是否成功</returns>
        public bool SetVoltage(double voltage, bool isLowRange = true)
        {
            if (!_powerConnected)
            {
                NlogHelper.Default.Warn("电源未连接，无法设置电压");
                return false;
            }

            try
            {
                var range = isLowRange ? PowerSupplyProtocol.OutputRange.Low : PowerSupplyProtocol.OutputRange.High;
                bool result = _powerSupply.SetVoltage(voltage, range);

                string rangeText = isLowRange ? "低档" : "高档";
                NlogHelper.Default.Info($"设置电压为{voltage}V({rangeText}): {(result ? "成功" : "失败")}");

                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"设置电压失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 设置电源输出频率
        /// </summary>
        /// <param name="frequency">目标频率值，有效范围40-70Hz</param>
        /// <returns>设置是否成功</returns>
        public bool SetFrequency(double frequency)
        {
            if (!_powerConnected)
            {
                NlogHelper.Default.Warn("电源未连接，无法设置频率");
                return false;
            }

            try
            {
                bool result = _powerSupply.SetFrequency(frequency);
                NlogHelper.Default.Info($"设置频率为{frequency}Hz: {(result ? "成功" : "失败")}");
                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"设置频率失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 执行电源复位操作
        /// 用于清除电源设备的故障状态或重置设备
        /// </summary>
        /// <returns>复位是否成功</returns>
        public bool ResetPowerSupply()
        {
            if (!_powerConnected)
            {
                NlogHelper.Default.Warn("电源未连接，无法执行复位操作");
                return false;
            }
            try
            {
                bool result = _powerSupply.PowerReset();
                NlogHelper.Default.Info($"电源复位操作: {(result ? "成功" : "失败")}");
                return result;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"电源复位操作失败: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 显示电源控制弹窗对话框
        /// 提供完整的电源监控和控制界面
        /// </summary>
        public void ShowPowerControlDialog()
        {
            try
            {
                using var dialog = new frmPowerSupplyForm(this);
                // 使用项目统一的弹窗显示方法，支持遮罩效果
                VarHelper.ShowDialogWithOverlay(FindForm(), dialog);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"显示电源控制对话框失败: {ex.Message}");
                MessageBox.Show($"打开电源控制面板失败: {ex.Message}",
                    "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 获取系统中所有可用的串口列表
        /// 用于用户选择连接的串口
        /// </summary>
        /// <returns>可用串口名称数组</returns>
        public string[] GetAvailableComPorts()
        {
            try
            {
                return SerialPort.GetPortNames();
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"获取可用串口列表失败: {ex.Message}");
                return new string[0]; // 返回空数组而不是null
            }
        }
        #endregion

        #region 电源监控相关变量
        /// <summary>
        /// 电源通信协议实例，负责与调频电源设备进行串口通信
        /// </summary>
        private PowerSupplyProtocol _powerSupply;

        /// <summary>
        /// 当前电源数据缓存，存储最新读取到的所有电源参数
        /// 包括三相电压、电流、功率、频率、故障状态等信息
        /// </summary>
        private PowerSupplyData _currentPowerData;

        /// <summary>
        /// 电源数据刷新定时器，定时读取电源设备的实时数据
        /// 默认1000ms刷新间隔，避免通信频率过高导致设备响应异常
        /// </summary>
        private Timer _powerTimer;

        /// <summary>
        /// 电源连接状态标志，true表示已连接并可正常通信
        /// 用于控制数据读取和命令发送的前置条件检查
        /// </summary>
        private bool _powerConnected = false;

        /// <summary>
        /// 当前使用的串口号，用于记录已连接的COM端口
        /// 便于重连和状态显示
        /// </summary>
        private string _currentComPort = "";
        #endregion

        #region 调频电源相关

        /// <summary>
        /// 初始化电源监控
        /// </summary>
        private void InitializePowerSupply()
        {
            try
            {
                NlogHelper.Default.Info("开始初始化电源监控系统");

                // 1. 初始化电源数据对象，设置默认状态为未连接
                _currentPowerData = new PowerSupplyData
                {
                    IsConnected = false,
                    UpdateTime = DateTime.Now,
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
                    FaultStatus = PowerSupplyProtocol.FaultType.Normal
                };

                // 2. 创建并配置数据刷新定时器
                _powerTimer = new Timer
                {
                    Interval = 1000,  // 1秒刷新间隔，平衡实时性和通信稳定性
                    Enabled = false   // 初始状态禁用，连接成功后启动
                };
                _powerTimer.Tick += PowerTimer_Tick;  // 绑定定时器事件处理方法

                // 3. 从INI配置文件读取串口号并尝试自动连接
                string configuredComPort = GetPowerSupplyComPortFromConfig();

                if (!string.IsNullOrEmpty(configuredComPort))
                {
                    NlogHelper.Default.Info($"从配置文件读取到电源串口号: {configuredComPort}");

                    // 尝试连接配置的串口，失败不抛异常，记录日志即可
                    bool connectResult = ConnectPowerSupply(configuredComPort);
                    if (connectResult)
                    {
                        NlogHelper.Default.Info($"电源自动连接成功: {configuredComPort}");
                    }
                    else
                    {
                        NlogHelper.Default.Warn($"电源自动连接失败: {configuredComPort}，可稍后手动连接");
                    }
                }
                else
                {
                    NlogHelper.Default.Info("未配置电源串口号，跳过自动连接");
                }
                NlogHelper.Default.Info("电源监控系统初始化完成");
            }
            catch (Exception ex)
            {
                // 电源初始化失败不应影响整个HMI系统启动，只记录错误
                NlogHelper.Default.Error($"电源监控系统初始化失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 从INI配置文件读取电源串口号
        /// </summary>
        /// <returns>配置的串口号，如COM1、COM2等；如果未配置则返回空字符串</returns>
        private string GetPowerSupplyComPortFromConfig()
        {
            try
            {
                string comPort = "";
                return comPort;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"读取电源串口配置失败: {ex.Message}");
                return "";  // 当前返回空字符串，表示未配置
            }
        }

        /// <summary>
        /// 电源数据刷新定时器事件处理方法
        /// 定时读取电源设备的实时数据，更新内存中的数据缓存
        /// 采用停止-执行-启动的模式防止定时器重叠执行
        /// </summary>
        /// <param name="sender">定时器对象</param>
        /// <param name="e">事件参数</param>
        private void PowerTimer_Tick(object sender, EventArgs e)
        {
            // 检查连接状态和电源协议对象是否有效
            if (!_powerConnected || _powerSupply == null)
            {
                return;
            }

            // 暂停定时器，防止数据读取过程中定时器再次触发
            _powerTimer.Stop();

            try
            {
                // 执行电源数据读取操作
                ReadPowerData();
            }
            catch (Exception ex)
            {
                // 数据读取异常通常表示通信中断，标记为断开状态
                NlogHelper.Default.Error($"电源数据读取失败: {ex.Message}");
                _powerConnected = false;
                _currentPowerData.IsConnected = false;
            }
            finally
            {
                // 如果仍保持连接状态，重新启动定时器继续数据刷新
                if (_powerConnected)
                {
                    _powerTimer.Start();
                }
            }
        }

        /// <summary>
        /// 读取电源设备的所有实时数据
        /// 按顺序读取三相电压、电流、功率、频率和故障状态
        /// 采用同步串行读取方式，避免并发访问串口导致的通信冲突
        /// </summary>
        private void ReadPowerData()
        {
            try
            {
                // 读取三相电压数据 (U、V、W三相)
                _currentPowerData.VoltageU = _powerSupply.ReadVoltage(PowerSupplyProtocol.Phase.U);
                _currentPowerData.VoltageV = _powerSupply.ReadVoltage(PowerSupplyProtocol.Phase.V);
                _currentPowerData.VoltageW = _powerSupply.ReadVoltage(PowerSupplyProtocol.Phase.W);

                // 读取三相电流数据
                _currentPowerData.CurrentU = _powerSupply.ReadCurrent(PowerSupplyProtocol.Phase.U);
                _currentPowerData.CurrentV = _powerSupply.ReadCurrent(PowerSupplyProtocol.Phase.V);
                _currentPowerData.CurrentW = _powerSupply.ReadCurrent(PowerSupplyProtocol.Phase.W);

                // 读取三相功率数据
                _currentPowerData.PowerU = _powerSupply.ReadPower(PowerSupplyProtocol.Phase.U);
                _currentPowerData.PowerV = _powerSupply.ReadPower(PowerSupplyProtocol.Phase.V);
                _currentPowerData.PowerW = _powerSupply.ReadPower(PowerSupplyProtocol.Phase.W);

                // 读取输出频率
                _currentPowerData.Frequency = _powerSupply.ReadFrequency();

                // 查询故障状态
                _currentPowerData.FaultStatus = _powerSupply.QueryFaultStatus();

                // 更新数据时间戳和连接状态
                _currentPowerData.UpdateTime = DateTime.Now;
                _currentPowerData.IsConnected = true;

                // 记录数据读取成功信息（可选，仅用于调试）
                // NlogHelper.Default.Debug($"电源数据读取成功 - 频率:{_currentPowerData.Frequency:F1}Hz, 总功率:{_currentPowerData.TotalPower:F0}W");
            }
            catch (Exception ex)
            {
                // 重新抛出异常，由上层处理连接状态更新
                throw new InvalidOperationException($"电源数据读取过程中发生错误: {ex.Message}", ex);
            }
        }
        #endregion
    }
}