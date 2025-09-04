namespace MainUI.PowerSupplyControl
{
    partial class frmPowerSupplyForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region 控件声明

        private Sunny.UI.UIPanel grpConnection;
        private System.Windows.Forms.Label lblConnectionStatus;

        private Sunny.UI.UIPanel grpDataDisplay;
        private Sunny.UI.UILabel lblVoltageTitle;
        private Sunny.UI.UILabel lblVoltageU;
        private Sunny.UI.UILabel lblVoltageV;
        private Sunny.UI.UILabel lblVoltageW;
        private Sunny.UI.UILabel lblCurrentTitle;
        private Sunny.UI.UILabel lblCurrentU;
        private Sunny.UI.UILabel lblCurrentV;
        private Sunny.UI.UILabel lblCurrentW;
        private Sunny.UI.UILabel lblPowerTitle;
        private Sunny.UI.UILabel lblPowerU;
        private Sunny.UI.UILabel lblPowerV;
        private Sunny.UI.UILabel lblPowerW;
        private Sunny.UI.UILabel lblTotalPower;
        private Sunny.UI.UILabel lblFrequency;
        private Sunny.UI.UILabel lblFaultStatus;

        private Sunny.UI.UIPanel grpProgress;
        private System.Windows.Forms.Label lblProgressVoltage;
        private System.Windows.Forms.ProgressBar progressVoltageU;
        private System.Windows.Forms.ProgressBar progressVoltageV;
        private System.Windows.Forms.ProgressBar progressVoltageW;
        private System.Windows.Forms.Label lblProgressCurrent;
        private System.Windows.Forms.ProgressBar progressCurrentU;
        private System.Windows.Forms.ProgressBar progressCurrentV;
        private System.Windows.Forms.ProgressBar progressCurrentW;

        private Sunny.UI.UIPanel grpControl;
        private Sunny.UI.UILabel lblControlMode;
        private Sunny.UI.UIComboBox cmbControlMode;
        private Sunny.UI.UIButton btnSetControlMode;
        private Sunny.UI.UILabel lblOutputRange;
        private Sunny.UI.UIComboBox cmbOutputRange;
        private Sunny.UI.UIButton btnSetOutputRange;
        private Sunny.UI.UILabel lblVoltageSet;
        private System.Windows.Forms.NumericUpDown numVoltage;
        private Sunny.UI.UIButton btnSetVoltage;
        private Sunny.UI.UILabel lblFrequencySet;
        private System.Windows.Forms.NumericUpDown numFrequency;
        private System.Windows.Forms.Button btnSetFrequency;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnQuickStart;
        private System.Windows.Forms.Button btnEmergencyStop;

        #endregion

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPowerSupplyForm));
            grpConnection = new UIPanel();
            uiLabel1 = new UILabel();
            lblConnectionStatus = new Label();
            grpDataDisplay = new UIPanel();
            uiLine2 = new UILine();
            lblFaultStatus = new UILabel();
            lblFrequency = new UILabel();
            lblTotalPower = new UILabel();
            lblPowerW = new UILabel();
            lblPowerV = new UILabel();
            lblPowerU = new UILabel();
            lblPowerTitle = new UILabel();
            lblCurrentW = new UILabel();
            lblCurrentV = new UILabel();
            lblCurrentU = new UILabel();
            lblCurrentTitle = new UILabel();
            lblVoltageW = new UILabel();
            lblVoltageV = new UILabel();
            lblVoltageU = new UILabel();
            lblVoltageTitle = new UILabel();
            grpProgress = new UIPanel();
            uiLine3 = new UILine();
            progressCurrentW = new ProgressBar();
            progressCurrentV = new ProgressBar();
            progressCurrentU = new ProgressBar();
            lblProgressCurrent = new Label();
            progressVoltageW = new ProgressBar();
            progressVoltageV = new ProgressBar();
            progressVoltageU = new ProgressBar();
            lblProgressVoltage = new Label();
            grpControl = new UIPanel();
            uiLine1 = new UILine();
            btnEmergencyStop = new Button();
            btnQuickStart = new Button();
            btnReset = new Button();
            btnSetFrequency = new Button();
            numFrequency = new NumericUpDown();
            lblFrequencySet = new UILabel();
            btnSetVoltage = new UIButton();
            numVoltage = new NumericUpDown();
            lblVoltageSet = new UILabel();
            btnSetOutputRange = new UIButton();
            cmbOutputRange = new UIComboBox();
            lblOutputRange = new UILabel();
            btnSetControlMode = new UIButton();
            cmbControlMode = new UIComboBox();
            lblControlMode = new UILabel();
            grpConnection.SuspendLayout();
            grpDataDisplay.SuspendLayout();
            grpProgress.SuspendLayout();
            grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFrequency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVoltage).BeginInit();
            SuspendLayout();
            // 
            // grpConnection
            // 
            grpConnection.Controls.Add(uiLabel1);
            grpConnection.Controls.Add(lblConnectionStatus);
            grpConnection.FillColor = Color.White;
            grpConnection.FillColor2 = Color.White;
            grpConnection.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            grpConnection.Location = new Point(12, 47);
            grpConnection.Margin = new Padding(4, 5, 4, 5);
            grpConnection.MinimumSize = new Size(1, 1);
            grpConnection.Name = "grpConnection";
            grpConnection.Padding = new Padding(0, 32, 0, 0);
            grpConnection.RectColor = Color.FromArgb(65, 100, 204);
            grpConnection.Size = new Size(966, 60);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = null;
            grpConnection.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Transparent;
            uiLabel1.Font = new Font("微软雅黑", 11F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(23, 20);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(80, 23);
            uiLabel1.TabIndex = 5;
            uiLabel1.Text = "连接状态:";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.BackColor = Color.Transparent;
            lblConnectionStatus.Font = new Font("微软雅黑", 11F);
            lblConnectionStatus.ForeColor = Color.Red;
            lblConnectionStatus.Location = new Point(113, 20);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(262, 23);
            lblConnectionStatus.TabIndex = 4;
            lblConnectionStatus.Text = "未连接";
            lblConnectionStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpDataDisplay
            // 
            grpDataDisplay.Controls.Add(uiLine2);
            grpDataDisplay.Controls.Add(lblFaultStatus);
            grpDataDisplay.Controls.Add(lblFrequency);
            grpDataDisplay.Controls.Add(lblTotalPower);
            grpDataDisplay.Controls.Add(lblPowerW);
            grpDataDisplay.Controls.Add(lblPowerV);
            grpDataDisplay.Controls.Add(lblPowerU);
            grpDataDisplay.Controls.Add(lblPowerTitle);
            grpDataDisplay.Controls.Add(lblCurrentW);
            grpDataDisplay.Controls.Add(lblCurrentV);
            grpDataDisplay.Controls.Add(lblCurrentU);
            grpDataDisplay.Controls.Add(lblCurrentTitle);
            grpDataDisplay.Controls.Add(lblVoltageW);
            grpDataDisplay.Controls.Add(lblVoltageV);
            grpDataDisplay.Controls.Add(lblVoltageU);
            grpDataDisplay.Controls.Add(lblVoltageTitle);
            grpDataDisplay.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            grpDataDisplay.Location = new Point(12, 117);
            grpDataDisplay.Margin = new Padding(4, 5, 4, 5);
            grpDataDisplay.MinimumSize = new Size(1, 1);
            grpDataDisplay.Name = "grpDataDisplay";
            grpDataDisplay.Padding = new Padding(0, 32, 0, 0);
            grpDataDisplay.RectColor = Color.FromArgb(65, 100, 204);
            grpDataDisplay.Size = new Size(595, 199);
            grpDataDisplay.TabIndex = 1;
            grpDataDisplay.TabStop = false;
            grpDataDisplay.Text = null;
            grpDataDisplay.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiLine2
            // 
            uiLine2.BackColor = Color.Transparent;
            uiLine2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine2.LineColor = Color.FromArgb(65, 100, 204);
            uiLine2.Location = new Point(13, 6);
            uiLine2.MinimumSize = new Size(1, 1);
            uiLine2.Name = "uiLine2";
            uiLine2.Size = new Size(563, 29);
            uiLine2.TabIndex = 16;
            uiLine2.Text = "实时数据";
            uiLine2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFaultStatus
            // 
            lblFaultStatus.BackColor = Color.LightGreen;
            lblFaultStatus.BorderStyle = BorderStyle.Fixed3D;
            lblFaultStatus.Font = new Font("微软雅黑", 11F);
            lblFaultStatus.ForeColor = Color.FromArgb(48, 48, 48);
            lblFaultStatus.Location = new Point(151, 155);
            lblFaultStatus.Name = "lblFaultStatus";
            lblFaultStatus.Size = new Size(150, 23);
            lblFaultStatus.TabIndex = 14;
            lblFaultStatus.Text = "状态: 正常";
            lblFaultStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFrequency
            // 
            lblFrequency.BackColor = Color.LightGreen;
            lblFrequency.BorderStyle = BorderStyle.Fixed3D;
            lblFrequency.Font = new Font("微软雅黑", 11F);
            lblFrequency.ForeColor = Color.FromArgb(48, 48, 48);
            lblFrequency.Location = new Point(21, 155);
            lblFrequency.Name = "lblFrequency";
            lblFrequency.Size = new Size(120, 23);
            lblFrequency.TabIndex = 13;
            lblFrequency.Text = "频率: 1000.0HZ";
            lblFrequency.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalPower
            // 
            lblTotalPower.BackColor = Color.Orange;
            lblTotalPower.BorderStyle = BorderStyle.Fixed3D;
            lblTotalPower.Font = new Font("微软雅黑", 11F);
            lblTotalPower.ForeColor = Color.FromArgb(48, 48, 48);
            lblTotalPower.Location = new Point(433, 114);
            lblTotalPower.Name = "lblTotalPower";
            lblTotalPower.Size = new Size(135, 23);
            lblTotalPower.TabIndex = 12;
            lblTotalPower.Text = "总功率: 0W";
            lblTotalPower.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPowerW
            // 
            lblPowerW.BackColor = Color.LightYellow;
            lblPowerW.BorderStyle = BorderStyle.Fixed3D;
            lblPowerW.Font = new Font("微软雅黑", 11F);
            lblPowerW.ForeColor = Color.FromArgb(48, 48, 48);
            lblPowerW.Location = new Point(324, 114);
            lblPowerW.Name = "lblPowerW";
            lblPowerW.Size = new Size(99, 23);
            lblPowerW.TabIndex = 11;
            lblPowerW.Text = "W: 0W";
            lblPowerW.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPowerV
            // 
            lblPowerV.BackColor = Color.LightYellow;
            lblPowerV.BorderStyle = BorderStyle.Fixed3D;
            lblPowerV.Font = new Font("微软雅黑", 11F);
            lblPowerV.ForeColor = Color.FromArgb(48, 48, 48);
            lblPowerV.Location = new Point(215, 114);
            lblPowerV.Name = "lblPowerV";
            lblPowerV.Size = new Size(99, 23);
            lblPowerV.TabIndex = 10;
            lblPowerV.Text = "V: 0W";
            lblPowerV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPowerU
            // 
            lblPowerU.BackColor = Color.LightYellow;
            lblPowerU.BorderStyle = BorderStyle.Fixed3D;
            lblPowerU.Font = new Font("微软雅黑", 11F);
            lblPowerU.ForeColor = Color.FromArgb(48, 48, 48);
            lblPowerU.Location = new Point(106, 114);
            lblPowerU.Name = "lblPowerU";
            lblPowerU.Size = new Size(99, 23);
            lblPowerU.TabIndex = 9;
            lblPowerU.Text = "U: 0W";
            lblPowerU.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPowerTitle
            // 
            lblPowerTitle.Font = new Font("微软雅黑", 11F);
            lblPowerTitle.ForeColor = Color.FromArgb(48, 48, 48);
            lblPowerTitle.Location = new Point(16, 114);
            lblPowerTitle.Name = "lblPowerTitle";
            lblPowerTitle.Size = new Size(80, 23);
            lblPowerTitle.TabIndex = 8;
            lblPowerTitle.Text = "三相功率(W):";
            lblPowerTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentW
            // 
            lblCurrentW.BackColor = Color.LightBlue;
            lblCurrentW.BorderStyle = BorderStyle.Fixed3D;
            lblCurrentW.Font = new Font("微软雅黑", 11F);
            lblCurrentW.ForeColor = Color.FromArgb(48, 48, 48);
            lblCurrentW.Location = new Point(324, 80);
            lblCurrentW.Name = "lblCurrentW";
            lblCurrentW.Size = new Size(99, 23);
            lblCurrentW.TabIndex = 7;
            lblCurrentW.Text = "W: 0.0A";
            lblCurrentW.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentV
            // 
            lblCurrentV.BackColor = Color.LightBlue;
            lblCurrentV.BorderStyle = BorderStyle.Fixed3D;
            lblCurrentV.Font = new Font("微软雅黑", 11F);
            lblCurrentV.ForeColor = Color.FromArgb(48, 48, 48);
            lblCurrentV.Location = new Point(215, 80);
            lblCurrentV.Name = "lblCurrentV";
            lblCurrentV.Size = new Size(99, 23);
            lblCurrentV.TabIndex = 6;
            lblCurrentV.Text = "V: 0.0A";
            lblCurrentV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentU
            // 
            lblCurrentU.BackColor = Color.LightBlue;
            lblCurrentU.BorderStyle = BorderStyle.Fixed3D;
            lblCurrentU.Font = new Font("微软雅黑", 11F);
            lblCurrentU.ForeColor = Color.FromArgb(48, 48, 48);
            lblCurrentU.Location = new Point(106, 80);
            lblCurrentU.Name = "lblCurrentU";
            lblCurrentU.Size = new Size(99, 23);
            lblCurrentU.TabIndex = 5;
            lblCurrentU.Text = "U: 0.0A";
            lblCurrentU.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentTitle
            // 
            lblCurrentTitle.Font = new Font("微软雅黑", 11F);
            lblCurrentTitle.ForeColor = Color.FromArgb(48, 48, 48);
            lblCurrentTitle.Location = new Point(16, 80);
            lblCurrentTitle.Name = "lblCurrentTitle";
            lblCurrentTitle.Size = new Size(80, 23);
            lblCurrentTitle.TabIndex = 4;
            lblCurrentTitle.Text = "三相电流(A):";
            lblCurrentTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVoltageW
            // 
            lblVoltageW.BackColor = Color.LightGray;
            lblVoltageW.BorderStyle = BorderStyle.Fixed3D;
            lblVoltageW.Font = new Font("微软雅黑", 11F);
            lblVoltageW.ForeColor = Color.FromArgb(48, 48, 48);
            lblVoltageW.Location = new Point(324, 46);
            lblVoltageW.Name = "lblVoltageW";
            lblVoltageW.Size = new Size(99, 23);
            lblVoltageW.TabIndex = 3;
            lblVoltageW.Text = "W: 0.0V";
            lblVoltageW.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVoltageV
            // 
            lblVoltageV.BackColor = Color.LightGray;
            lblVoltageV.BorderStyle = BorderStyle.Fixed3D;
            lblVoltageV.Font = new Font("微软雅黑", 11F);
            lblVoltageV.ForeColor = Color.FromArgb(48, 48, 48);
            lblVoltageV.Location = new Point(215, 46);
            lblVoltageV.Name = "lblVoltageV";
            lblVoltageV.Size = new Size(99, 23);
            lblVoltageV.TabIndex = 2;
            lblVoltageV.Text = "V: 0.0V";
            lblVoltageV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVoltageU
            // 
            lblVoltageU.BackColor = Color.LightGray;
            lblVoltageU.BorderStyle = BorderStyle.Fixed3D;
            lblVoltageU.Font = new Font("微软雅黑", 11F);
            lblVoltageU.ForeColor = Color.FromArgb(48, 48, 48);
            lblVoltageU.Location = new Point(106, 46);
            lblVoltageU.Name = "lblVoltageU";
            lblVoltageU.Size = new Size(99, 23);
            lblVoltageU.TabIndex = 1;
            lblVoltageU.Text = "U: 0.0V";
            lblVoltageU.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVoltageTitle
            // 
            lblVoltageTitle.Font = new Font("微软雅黑", 11F);
            lblVoltageTitle.ForeColor = Color.FromArgb(48, 48, 48);
            lblVoltageTitle.Location = new Point(16, 46);
            lblVoltageTitle.Name = "lblVoltageTitle";
            lblVoltageTitle.Size = new Size(80, 23);
            lblVoltageTitle.TabIndex = 0;
            lblVoltageTitle.Text = "三相电压(V):";
            lblVoltageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpProgress
            // 
            grpProgress.Controls.Add(uiLine3);
            grpProgress.Controls.Add(progressCurrentW);
            grpProgress.Controls.Add(progressCurrentV);
            grpProgress.Controls.Add(progressCurrentU);
            grpProgress.Controls.Add(lblProgressCurrent);
            grpProgress.Controls.Add(progressVoltageW);
            grpProgress.Controls.Add(progressVoltageV);
            grpProgress.Controls.Add(progressVoltageU);
            grpProgress.Controls.Add(lblProgressVoltage);
            grpProgress.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            grpProgress.Location = new Point(628, 117);
            grpProgress.Margin = new Padding(4, 5, 4, 5);
            grpProgress.MinimumSize = new Size(1, 1);
            grpProgress.Name = "grpProgress";
            grpProgress.Padding = new Padding(0, 32, 0, 0);
            grpProgress.RectColor = Color.FromArgb(65, 100, 204);
            grpProgress.Size = new Size(350, 199);
            grpProgress.TabIndex = 2;
            grpProgress.TabStop = false;
            grpProgress.Text = null;
            grpProgress.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiLine3
            // 
            uiLine3.BackColor = Color.Transparent;
            uiLine3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine3.LineColor = Color.FromArgb(65, 100, 204);
            uiLine3.Location = new Point(15, 6);
            uiLine3.MinimumSize = new Size(1, 1);
            uiLine3.Name = "uiLine3";
            uiLine3.Size = new Size(308, 29);
            uiLine3.TabIndex = 17;
            uiLine3.Text = "数据可视化";
            uiLine3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // progressCurrentW
            // 
            progressCurrentW.Location = new Point(228, 126);
            progressCurrentW.Maximum = 50;
            progressCurrentW.Name = "progressCurrentW";
            progressCurrentW.Size = new Size(90, 20);
            progressCurrentW.Style = ProgressBarStyle.Continuous;
            progressCurrentW.TabIndex = 7;
            // 
            // progressCurrentV
            // 
            progressCurrentV.Location = new Point(128, 126);
            progressCurrentV.Maximum = 50;
            progressCurrentV.Name = "progressCurrentV";
            progressCurrentV.Size = new Size(90, 20);
            progressCurrentV.Style = ProgressBarStyle.Continuous;
            progressCurrentV.TabIndex = 6;
            // 
            // progressCurrentU
            // 
            progressCurrentU.Location = new Point(28, 126);
            progressCurrentU.Maximum = 50;
            progressCurrentU.Name = "progressCurrentU";
            progressCurrentU.Size = new Size(90, 20);
            progressCurrentU.Style = ProgressBarStyle.Continuous;
            progressCurrentU.TabIndex = 5;
            // 
            // lblProgressCurrent
            // 
            lblProgressCurrent.Font = new Font("微软雅黑", 11F);
            lblProgressCurrent.Location = new Point(18, 101);
            lblProgressCurrent.Name = "lblProgressCurrent";
            lblProgressCurrent.Size = new Size(120, 20);
            lblProgressCurrent.TabIndex = 4;
            lblProgressCurrent.Text = "电流进度 (U-V-W):";
            // 
            // progressVoltageW
            // 
            progressVoltageW.Location = new Point(228, 71);
            progressVoltageW.Maximum = 300;
            progressVoltageW.Name = "progressVoltageW";
            progressVoltageW.Size = new Size(90, 20);
            progressVoltageW.Style = ProgressBarStyle.Continuous;
            progressVoltageW.TabIndex = 3;
            // 
            // progressVoltageV
            // 
            progressVoltageV.Location = new Point(128, 71);
            progressVoltageV.Maximum = 300;
            progressVoltageV.Name = "progressVoltageV";
            progressVoltageV.Size = new Size(90, 20);
            progressVoltageV.Style = ProgressBarStyle.Continuous;
            progressVoltageV.TabIndex = 2;
            // 
            // progressVoltageU
            // 
            progressVoltageU.Location = new Point(28, 71);
            progressVoltageU.Maximum = 300;
            progressVoltageU.Name = "progressVoltageU";
            progressVoltageU.Size = new Size(90, 20);
            progressVoltageU.Style = ProgressBarStyle.Continuous;
            progressVoltageU.TabIndex = 1;
            progressVoltageU.Value = 100;
            // 
            // lblProgressVoltage
            // 
            lblProgressVoltage.Font = new Font("微软雅黑", 11F);
            lblProgressVoltage.Location = new Point(18, 46);
            lblProgressVoltage.Name = "lblProgressVoltage";
            lblProgressVoltage.Size = new Size(120, 20);
            lblProgressVoltage.TabIndex = 0;
            lblProgressVoltage.Text = "电压进度 (U-V-W):";
            // 
            // grpControl
            // 
            grpControl.BackColor = Color.Transparent;
            grpControl.Controls.Add(uiLine1);
            grpControl.Controls.Add(btnEmergencyStop);
            grpControl.Controls.Add(btnQuickStart);
            grpControl.Controls.Add(btnReset);
            grpControl.Controls.Add(btnSetFrequency);
            grpControl.Controls.Add(numFrequency);
            grpControl.Controls.Add(lblFrequencySet);
            grpControl.Controls.Add(btnSetVoltage);
            grpControl.Controls.Add(numVoltage);
            grpControl.Controls.Add(lblVoltageSet);
            grpControl.Controls.Add(btnSetOutputRange);
            grpControl.Controls.Add(cmbOutputRange);
            grpControl.Controls.Add(lblOutputRange);
            grpControl.Controls.Add(btnSetControlMode);
            grpControl.Controls.Add(cmbControlMode);
            grpControl.Controls.Add(lblControlMode);
            grpControl.FillColor = Color.White;
            grpControl.FillColor2 = Color.White;
            grpControl.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            grpControl.Location = new Point(12, 334);
            grpControl.Margin = new Padding(4, 5, 4, 5);
            grpControl.MinimumSize = new Size(1, 1);
            grpControl.Name = "grpControl";
            grpControl.Padding = new Padding(0, 32, 0, 0);
            grpControl.RectColor = Color.FromArgb(65, 100, 204);
            grpControl.RectDisableColor = Color.FromArgb(65, 100, 204);
            grpControl.Size = new Size(966, 166);
            grpControl.TabIndex = 3;
            grpControl.TabStop = false;
            grpControl.Text = null;
            grpControl.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.LineColor = Color.FromArgb(65, 100, 204);
            uiLine1.Location = new Point(21, 11);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(929, 29);
            uiLine1.TabIndex = 15;
            uiLine1.Text = "参数设置";
            uiLine1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnEmergencyStop
            // 
            btnEmergencyStop.BackColor = Color.Red;
            btnEmergencyStop.Font = new Font("微软雅黑", 11F);
            btnEmergencyStop.ForeColor = Color.White;
            btnEmergencyStop.Location = new Point(860, 53);
            btnEmergencyStop.Name = "btnEmergencyStop";
            btnEmergencyStop.Size = new Size(80, 50);
            btnEmergencyStop.TabIndex = 14;
            btnEmergencyStop.Text = "紧急停止";
            btnEmergencyStop.UseVisualStyleBackColor = false;
            btnEmergencyStop.Click += BtnEmergencyStop_Click;
            // 
            // btnQuickStart
            // 
            btnQuickStart.BackColor = Color.LightGreen;
            btnQuickStart.Font = new Font("微软雅黑", 11F);
            btnQuickStart.Location = new Point(734, 53);
            btnQuickStart.Name = "btnQuickStart";
            btnQuickStart.Size = new Size(120, 50);
            btnQuickStart.TabIndex = 13;
            btnQuickStart.Text = "快速启动\r\n(电脑控制+低档)";
            btnQuickStart.UseVisualStyleBackColor = false;
            btnQuickStart.Click += BtnQuickStart_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Orange;
            btnReset.Font = new Font("微软雅黑", 11F);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(627, 73);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(101, 30);
            btnReset.TabIndex = 12;
            btnReset.Text = "电源复位";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            // 
            // btnSetFrequency
            // 
            btnSetFrequency.BackColor = Color.LightGreen;
            btnSetFrequency.Font = new Font("微软雅黑", 11F);
            btnSetFrequency.Location = new Point(548, 99);
            btnSetFrequency.Name = "btnSetFrequency";
            btnSetFrequency.Size = new Size(60, 27);
            btnSetFrequency.TabIndex = 11;
            btnSetFrequency.Text = "设置";
            btnSetFrequency.UseVisualStyleBackColor = false;
            btnSetFrequency.Click += BtnSetFrequency_Click;
            // 
            // numFrequency
            // 
            numFrequency.DecimalPlaces = 1;
            numFrequency.Font = new Font("微软雅黑", 11F);
            numFrequency.Location = new Point(398, 97);
            numFrequency.Maximum = new decimal(new int[] { 70, 0, 0, 0 });
            numFrequency.Minimum = new decimal(new int[] { 40, 0, 0, 0 });
            numFrequency.Name = "numFrequency";
            numFrequency.Size = new Size(129, 27);
            numFrequency.TabIndex = 10;
            numFrequency.TextAlign = HorizontalAlignment.Center;
            numFrequency.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblFrequencySet
            // 
            lblFrequencySet.Font = new Font("微软雅黑", 11F);
            lblFrequencySet.ForeColor = Color.FromArgb(48, 48, 48);
            lblFrequencySet.Location = new Point(324, 99);
            lblFrequencySet.Name = "lblFrequencySet";
            lblFrequencySet.Size = new Size(80, 23);
            lblFrequencySet.TabIndex = 9;
            lblFrequencySet.Text = "设置频率:";
            lblFrequencySet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetVoltage
            // 
            btnSetVoltage.Font = new Font("微软雅黑", 11F);
            btnSetVoltage.Location = new Point(238, 99);
            btnSetVoltage.MinimumSize = new Size(1, 1);
            btnSetVoltage.Name = "btnSetVoltage";
            btnSetVoltage.Size = new Size(60, 27);
            btnSetVoltage.TabIndex = 8;
            btnSetVoltage.Text = "设置";
            btnSetVoltage.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSetVoltage.Click += BtnSetVoltage_Click;
            // 
            // numVoltage
            // 
            numVoltage.DecimalPlaces = 1;
            numVoltage.Font = new Font("微软雅黑", 11F);
            numVoltage.Location = new Point(111, 101);
            numVoltage.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numVoltage.Name = "numVoltage";
            numVoltage.Size = new Size(120, 27);
            numVoltage.TabIndex = 7;
            numVoltage.TextAlign = HorizontalAlignment.Center;
            numVoltage.Value = new decimal(new int[] { 120, 0, 0, 0 });
            // 
            // lblVoltageSet
            // 
            lblVoltageSet.Font = new Font("微软雅黑", 11F);
            lblVoltageSet.ForeColor = Color.FromArgb(48, 48, 48);
            lblVoltageSet.Location = new Point(30, 103);
            lblVoltageSet.Name = "lblVoltageSet";
            lblVoltageSet.Size = new Size(85, 23);
            lblVoltageSet.TabIndex = 6;
            lblVoltageSet.Text = "设置电压:";
            lblVoltageSet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetOutputRange
            // 
            btnSetOutputRange.Font = new Font("微软雅黑", 11F);
            btnSetOutputRange.Location = new Point(548, 49);
            btnSetOutputRange.MinimumSize = new Size(1, 1);
            btnSetOutputRange.Name = "btnSetOutputRange";
            btnSetOutputRange.Size = new Size(60, 27);
            btnSetOutputRange.TabIndex = 5;
            btnSetOutputRange.Text = "设置";
            btnSetOutputRange.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSetOutputRange.Click += BtnSetOutputRange_Click;
            // 
            // cmbOutputRange
            // 
            cmbOutputRange.DataSource = null;
            cmbOutputRange.DropDownStyle = UIDropDownStyle.DropDownList;
            cmbOutputRange.FillColor = Color.White;
            cmbOutputRange.Font = new Font("微软雅黑", 11F);
            cmbOutputRange.FormattingEnabled = true;
            cmbOutputRange.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cmbOutputRange.Items.AddRange(new object[] { "高档0-300V", "低档0-150V" });
            cmbOutputRange.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cmbOutputRange.Location = new Point(398, 51);
            cmbOutputRange.Margin = new Padding(4, 5, 4, 5);
            cmbOutputRange.MinimumSize = new Size(63, 0);
            cmbOutputRange.Name = "cmbOutputRange";
            cmbOutputRange.Padding = new Padding(0, 0, 30, 2);
            cmbOutputRange.RectColor = Color.FromArgb(65, 100, 204);
            cmbOutputRange.RectDisableColor = Color.FromArgb(65, 100, 204);
            cmbOutputRange.Size = new Size(129, 25);
            cmbOutputRange.SymbolSize = 24;
            cmbOutputRange.TabIndex = 4;
            cmbOutputRange.TextAlignment = ContentAlignment.MiddleLeft;
            cmbOutputRange.Watermark = "";
            // 
            // lblOutputRange
            // 
            lblOutputRange.Font = new Font("微软雅黑", 11F);
            lblOutputRange.ForeColor = Color.FromArgb(48, 48, 48);
            lblOutputRange.Location = new Point(324, 53);
            lblOutputRange.Name = "lblOutputRange";
            lblOutputRange.Size = new Size(80, 23);
            lblOutputRange.TabIndex = 3;
            lblOutputRange.Text = "输出档位:";
            lblOutputRange.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetControlMode
            // 
            btnSetControlMode.Font = new Font("微软雅黑", 12F);
            btnSetControlMode.Location = new Point(238, 51);
            btnSetControlMode.MinimumSize = new Size(1, 1);
            btnSetControlMode.Name = "btnSetControlMode";
            btnSetControlMode.Size = new Size(60, 27);
            btnSetControlMode.TabIndex = 2;
            btnSetControlMode.Text = "设置";
            btnSetControlMode.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSetControlMode.Click += BtnSetControlMode_Click;
            // 
            // cmbControlMode
            // 
            cmbControlMode.DataSource = null;
            cmbControlMode.DropDownStyle = UIDropDownStyle.DropDownList;
            cmbControlMode.FillColor = Color.White;
            cmbControlMode.Font = new Font("微软雅黑", 11F);
            cmbControlMode.FormattingEnabled = true;
            cmbControlMode.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cmbControlMode.Items.AddRange(new object[] { "本机控制", "电脑控制" });
            cmbControlMode.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cmbControlMode.Location = new Point(111, 51);
            cmbControlMode.Margin = new Padding(4, 5, 4, 5);
            cmbControlMode.MinimumSize = new Size(63, 0);
            cmbControlMode.Name = "cmbControlMode";
            cmbControlMode.Padding = new Padding(0, 0, 30, 2);
            cmbControlMode.RectColor = Color.FromArgb(65, 100, 204);
            cmbControlMode.RectDisableColor = Color.FromArgb(65, 100, 204);
            cmbControlMode.Size = new Size(120, 28);
            cmbControlMode.SymbolSize = 24;
            cmbControlMode.TabIndex = 1;
            cmbControlMode.TextAlignment = ContentAlignment.MiddleLeft;
            cmbControlMode.Watermark = "";
            // 
            // lblControlMode
            // 
            lblControlMode.Font = new Font("微软雅黑", 11F);
            lblControlMode.ForeColor = Color.FromArgb(48, 48, 48);
            lblControlMode.Location = new Point(30, 53);
            lblControlMode.Name = "lblControlMode";
            lblControlMode.Size = new Size(85, 23);
            lblControlMode.TabIndex = 0;
            lblControlMode.Text = "控制模式:";
            lblControlMode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmPowerSupplyForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(996, 515);
            Controls.Add(grpControl);
            Controls.Add(grpProgress);
            Controls.Add(grpDataDisplay);
            Controls.Add(grpConnection);
            Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmPowerSupplyForm";
            ShowIcon = false;
            Text = "调频电源监控系统";
            TitleFont = new Font("微软雅黑", 13F);
            ZoomScaleRect = new Rectangle(15, 15, 996, 531);
            grpConnection.ResumeLayout(false);
            grpDataDisplay.ResumeLayout(false);
            grpProgress.ResumeLayout(false);
            grpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numFrequency).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVoltage).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private UILine uiLine1;
        private UILabel uiLabel1;
        private UILine uiLine2;
        private UILine uiLine3;
    }
}