using AntdUI;
using MainUI.PowerSupplyControl;
using MainUI.Service;
using Label = System.Windows.Forms.Label;

namespace MainUI
{
    public partial class UcHMI : UserControl
    {
        #region 全局变量
        private readonly RW.UI.Controls.Report.RWReport rWReport = new();
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
            _reportService = new ReportService(reportPath, rWReport);
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
                //电源柜断电重启后默认本地控制为3，需要手动写入默认远程控制
                OPCHelper.PowerControlGrp[0] = 2;
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
            switch (index)
            {
                case 0:
                    LabTemperature01.Text = value.ToString("f1");
                    break;
                case 1:
                    LabTemperature02.Text = value.ToString("f1");
                    break;
                case 2:
                    LabTemperature03.Text = value.ToString("f1");
                    break;
                default:
                    break;
            }
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

                // 初始化报表
                InitializeReport(paraconfig.RptFile);
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

        /// <summary>
        /// 初始化报表
        /// </summary>
        /// <param name="reportFileName">报表文件名</param>
        private void InitializeReport(string reportFileName)
        {
            try
            {
                if (string.IsNullOrEmpty(reportFileName))
                    return;

                reportFileName = ReportService.GetDefaultReportPath() + reportFileName;

                // 检查文件是否存在
                if (!_reportService.FileExists(reportFileName))
                {
                    MessageHelper.MessageOK($"报表文件不存在：{reportFileName}", TType.Error);
                    return;
                }

                string workingPath = ReportService.GetWorkingReportPath();

                // 如果当前加载的不是这个文件，则重新加载
                //if (rWReport.Filename != workingPath)
                {
                    // 准备报表控件
                    rWReport.Dock = DockStyle.Fill;
                    if (!panelReport.Controls.Contains(rWReport))
                        panelReport.Controls.Add(rWReport);

                    // 关闭Excel进程
                    SystemHelper.KillProcess("EXCEL");
                    Thread.Sleep(200);

                    // 复制文件到工作目录
                    _reportService.CopyReportFile(reportFileName, workingPath);

                    // 初始化报表控件
                    rWReport.Filename = workingPath;
                    rWReport.Init();
                }
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error("报表加载错误：", ex);
                MessageHelper.MessageOK($"报表加载错误：{ex.Message}", TType.Error);
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
        /// <summary>
        /// 向上翻页
        /// </summary>
        private void btnPageUp_Click(object sender, EventArgs e)
        {
            try
            {
                int pageSize = Convert.ToInt32(inputNumber.Value);
                var (currentRows, upEnabled, downEnabled) = _reportService.PageUp(pageSize);

                // 更新按钮状态
                btnPageUp.Enabled = upEnabled;
                btnPageDown.Enabled = downEnabled;

                // 显示当前页信息
                // XX.Text = $"第 {currentRows} 行";
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK($"向上翻页失败：{ex.Message}", TType.Error);
                NlogHelper.Default.Error("报表向上翻页失败", ex);
            }
        }

        /// <summary>
        /// 向下翻页
        /// </summary>
        private void btnPageDown_Click(object sender, EventArgs e)
        {
            try
            {
                int pageSize = Convert.ToInt32(inputNumber.Value);
                var (currentRows, upEnabled, downEnabled) = _reportService.PageDown(pageSize);

                // 更新按钮状态
                btnPageUp.Enabled = upEnabled;
                btnPageDown.Enabled = downEnabled;

                // 显示当前页信息
                // XX.Text = $"第 {currentRows} 行";
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK($"向下翻页失败：{ex.Message}", TType.Error);
                NlogHelper.Default.Error("报表向下翻页失败", ex);
            }
        }
        #endregion

        #region 报表控件
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSaveParameters()) return;// 参数校验

                if (!ConfirmSaveReport()) return;  // 提示确认

                string saveFilePath = ReportService.BuildSaveFilePath(VarHelper.TestViewModel.ModelName); // 保存路径

                // 保存测试记录
                var testRecord = new TestRecordModel
                {
                    KindID = VarHelper.TestViewModel.ModelTypeID,
                    ModelID = VarHelper.TestViewModel.ID,
                    TestID = txtNumber.Text.Trim(),
                    Tester = NewUsers.NewUserInfo.Username,
                    TestTime = DateTime.Now,
                    ReportPath = saveFilePath
                };

                if (ReportService.SaveTestRecord(testRecord))
                {
                    rWReport.SaveAS(saveFilePath);
                    MessageHelper.MessageOK("保存成功", TType.Success);
                }
                else
                {
                    MessageHelper.MessageOK("保存失败", TType.Error);
                }
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
                rWReport.Print();
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
            tabs1.SelectedIndex = 1;
            NavigationButtonStyles.UpdateNavigationButtons
                (tabs1.SelectedIndex, controls);
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            tabs1.SelectedIndex = 0;
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

        private void BtnFMPowerSupply_Click(object sender, EventArgs e)
        {
            ShowPowerControlDialog();
        }

        /// <summary>
        /// 显示电源控制弹窗对话框
        /// 提供完整的电源监控和控制界面
        /// </summary>
        public void ShowPowerControlDialog()
        {
            try
            {
                using var dialog = new frmPowerSupplyForm();
                VarHelper.ShowDialogWithOverlay(FindForm(), dialog);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"显示电源控制对话框失败: {ex.Message}");
                MessageBox.Show($"打开电源控制面板失败: {ex.Message}",
                    "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}