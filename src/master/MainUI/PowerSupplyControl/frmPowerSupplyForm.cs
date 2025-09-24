using Timer = System.Windows.Forms.Timer;

namespace MainUI.PowerSupplyControl
{
    public partial class frmPowerSupplyForm : UIForm
    {
        #region 私有字段修改

        /// <summary>
        /// 界面刷新定时器，定期更新UI显示
        /// </summary>
        private Timer refreshTimer;

        #endregion

        /// <summary>
        /// 接收电源服务实例
        /// </summary>
        /// <param name="powerService">电源服务实例</param>
        public frmPowerSupplyForm()
        {
            InitializeComponent();

            SetupTimer();
            SetupDefaultValues();
        }

        private void SetupDefaultValues()
        {
            // 设置默认值
            if (cmbControlMode.Items.Count > 0) cmbControlMode.SelectedIndex = 1; // 电脑控制
            if (cmbOutputRange.Items.Count > 0) cmbOutputRange.SelectedIndex = 0; // 高档

            numVoltage.Value = (decimal)(OPCHelper.PowerControlGrp[3] / 10.0 * 1.732);
            numFrequency.Value = (decimal)(OPCHelper.PowerControlGrp[2] / 10.0);
        }

        private void SetupTimer()
        {
            refreshTimer = new()
            {
                Interval = 300
            };
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        /// <summary>
        /// 界面刷新定时器事件处理
        /// 现在主要用于定期更新UI显示，数据由服务事件提供
        /// </summary>
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
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
            lblVoltageU.Text = $"U: {OPCHelper.PowerReadGrp[4]:F1}V";
            lblVoltageV.Text = $"V: {OPCHelper.PowerReadGrp[5]:F1}V";
            lblVoltageW.Text = $"W: {OPCHelper.PowerReadGrp[6]:F1}V";
            lbTotalVoltage.Text = $"W: {OPCHelper.PowerReadGrp[7]:F1}A";

            // 更新电流显示
            lblCurrentU.Text = $"U: {OPCHelper.PowerReadGrp[0]:F1}A";
            lblCurrentV.Text = $"V: {OPCHelper.PowerReadGrp[1]:F1}A";
            lblCurrentW.Text = $"W: {OPCHelper.PowerReadGrp[2]:F1}A";
            lbTotalCurrent.Text = $"W: {OPCHelper.PowerReadGrp[3]:F1}A";

            // 更新功率显示
            lblPowerU.Text = $"U: {OPCHelper.PowerReadGrp[12]:F1}KW";
            lblPowerV.Text = $"V: {OPCHelper.PowerReadGrp[13]:F1}KW";
            lblPowerW.Text = $"W: {OPCHelper.PowerReadGrp[14]:F1}KW";
            lblTotalPower.Text = $"总功率: {OPCHelper.PowerReadGrp[15]:F1}KW";

            // 更新功率因数显示
            //lblFactorU.Text = $"U: {OPCHelper.PowerReadGrp[24]:F1}";
            //lblFactorV.Text = $"V: {OPCHelper.PowerReadGrp[25]:F1}";
            //lblFactorW.Text = $"W: {OPCHelper.PowerReadGrp[26]:F1}";
            lbTotalFactor.Text = $"功率因素: {OPCHelper.PowerReadGrp[27]:F2}";

            // 更新频率和状态
            lblFrequency.Text = $"频率: {OPCHelper.PowerReadGrp[28]:F1}HZ";
            lblFaultStatus.Text = $"状态: {GetFaultStatusText(OPCHelper.PowerControlGrp[5].ToInt32())}";
            lblFaultStatus.BackColor = OPCHelper.PowerControlGrp[5].ToInt32() > 0 ? Color.Red : Color.LightGreen;

            // 更新按钮状态
            btnReset.BackColor = OPCHelper.PowerControlGrp[6] == 1 ? TrueColor : FalseColor;
            if (OPCHelper.PowerControlGrp[4] == 1)
            {
                btnQuickStart.BackColor = TrueColor;
                btnEmergencyStop.BackColor = FalseColor;
            }
            else
            {
                btnQuickStart.BackColor = FalseColor;
                btnEmergencyStop.BackColor = TrueColor;
            }
        }

        private string GetFaultStatusText(int faultType)
        {
            return faultType switch
            {
                0 => "正常",
                1 => "过压报警",
                2 => "过流报警",
                3 => "过温报警",
                4 => "故障报警",
                _ => "未知状态"
            };
        }

        private readonly Color TrueColor = Color.LightGreen;
        private readonly Color FalseColor = Color.WhiteSmoke;

        #region 设备控制事件处理
        /// <summary>
        /// 设置控制模式按钮点击事件
        /// </summary>
        private void BtnSetControlMode_Click(object sender, EventArgs e)
        {
            try
            {
                int SelectValue = cmbControlMode.SelectedIndex;
                if (SelectValue == 0)
                {
                    OPCHelper.PowerControlGrp[0] = 3;// 本机
                }
                else
                {
                    OPCHelper.PowerControlGrp[0] = 2;// 远程
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"设置控制模式时发生异常: {ex.Message}");
            }
        }
        /// <summary>
        /// 设置输出档位按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetOutputRange_Click(object sender, EventArgs e)
        {
            try
            {
                int SelectValue = cmbOutputRange.SelectedIndex;
                if (SelectValue == 0)
                {
                    OPCHelper.PowerControlGrp[1] = 2;// 高档
                }
                else
                {
                    OPCHelper.PowerControlGrp[1] = 1;// 低档
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"设置输出档位时发生异常: {ex.Message}");
            }
        }

        /// <summary>
        /// 设置输出电压按钮点击事件
        /// </summary>

        private void BtnSetVoltage_Click(object sender, EventArgs e)
        {

            try
            {
                double voltage = (double)numVoltage.Value;
                // 协议要求输入线电压，默认为相电压输出，转换成线电压需要除以1.732
                OPCHelper.PowerControlGrp[3] = ((voltage * 10) / 1.732);
            }
            catch (Exception ex)
            {
                ShowMessage($"设置输出电压时发生异常: {ex.Message}");
            }
        }

        /// <summary>
        /// 设置输出频率按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetFrequency_Click(object sender, EventArgs e)
        {
            try
            {
                double frequency = (double)numFrequency.Value;
                OPCHelper.PowerControlGrp[2] = (frequency * 10);
            }
            catch (Exception ex)
            {
                ShowMessage($"设置输出频率时发生异常: {ex.Message}");
            }
        }

        /// <summary>
        /// 电源复位按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                OPCHelper.PowerControlGrp[6] = 1;
            }
            catch (Exception ex)
            {
                ShowMessage($"电源复位时发生异常: {ex.Message}");
            }
        }

        /// <summary>
        /// 快速启动按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuickStart_Click(object sender, EventArgs e)
        {
            try
            {
                OPCHelper.PowerControlGrp[4] = 1;
            }
            catch (Exception ex)
            {
                ShowMessage($"快速启动时发生异常: {ex.Message}");
            }
        }

        /// <summary>
        /// 紧急停止按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEmergencyStop_Click(object sender, EventArgs e)
        {
            try
            {
                OPCHelper.PowerControlGrp[4] = 0;
            }
            catch (Exception ex)
            {
                ShowMessage($"紧急停止时发生异常: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
