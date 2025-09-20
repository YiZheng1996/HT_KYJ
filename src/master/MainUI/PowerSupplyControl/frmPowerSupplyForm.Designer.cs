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
        private Sunny.UI.UIButton btnSetFrequency;
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
            lblFaultStatus = new UILabel();
            grpDataDisplay = new UIPanel();
            lbTotalFactor = new UILabel();
            lblFactorW = new UILabel();
            lblFactorV = new UILabel();
            lblFactorU = new UILabel();
            uiLabel8 = new UILabel();
            lbTotalVoltage = new UILabel();
            lbTotalCurrent = new UILabel();
            uiLine2 = new UILine();
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
            grpControl = new UIPanel();
            btnClose = new Button();
            uiLine1 = new UILine();
            btnEmergencyStop = new Button();
            btnQuickStart = new Button();
            btnReset = new Button();
            btnSetFrequency = new UIButton();
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
            grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFrequency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVoltage).BeginInit();
            SuspendLayout();
            // 
            // grpConnection
            // 
            grpConnection.Controls.Add(lblFaultStatus);
            grpConnection.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            grpConnection.Location = new Point(14, 47);
            grpConnection.Margin = new Padding(4, 5, 4, 5);
            grpConnection.MinimumSize = new Size(1, 1);
            grpConnection.Name = "grpConnection";
            grpConnection.Padding = new Padding(0, 32, 0, 0);
            grpConnection.RectColor = Color.FromArgb(65, 100, 204);
            grpConnection.Size = new Size(779, 60);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = null;
            grpConnection.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // lblFaultStatus
            // 
            lblFaultStatus.BackColor = Color.FromArgb(255, 128, 128);
            lblFaultStatus.BorderStyle = BorderStyle.Fixed3D;
            lblFaultStatus.Font = new Font("微软雅黑", 11F);
            lblFaultStatus.ForeColor = Color.Black;
            lblFaultStatus.Location = new Point(27, 19);
            lblFaultStatus.Name = "lblFaultStatus";
            lblFaultStatus.Size = new Size(306, 23);
            lblFaultStatus.TabIndex = 14;
            lblFaultStatus.Text = "状态: 正常";
            lblFaultStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpDataDisplay
            // 
            grpDataDisplay.Controls.Add(lbTotalFactor);
            grpDataDisplay.Controls.Add(lblFactorW);
            grpDataDisplay.Controls.Add(lblFactorV);
            grpDataDisplay.Controls.Add(lblFactorU);
            grpDataDisplay.Controls.Add(uiLabel8);
            grpDataDisplay.Controls.Add(lbTotalVoltage);
            grpDataDisplay.Controls.Add(lbTotalCurrent);
            grpDataDisplay.Controls.Add(uiLine2);
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
            grpDataDisplay.Location = new Point(14, 117);
            grpDataDisplay.Margin = new Padding(4, 5, 4, 5);
            grpDataDisplay.MinimumSize = new Size(1, 1);
            grpDataDisplay.Name = "grpDataDisplay";
            grpDataDisplay.Padding = new Padding(0, 32, 0, 0);
            grpDataDisplay.RectColor = Color.FromArgb(65, 100, 204);
            grpDataDisplay.Size = new Size(779, 199);
            grpDataDisplay.TabIndex = 1;
            grpDataDisplay.TabStop = false;
            grpDataDisplay.Text = null;
            grpDataDisplay.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // lbTotalFactor
            // 
            lbTotalFactor.BackColor = Color.Orange;
            lbTotalFactor.BorderStyle = BorderStyle.Fixed3D;
            lbTotalFactor.Font = new Font("微软雅黑", 11F);
            lbTotalFactor.ForeColor = Color.FromArgb(48, 48, 48);
            lbTotalFactor.Location = new Point(433, 159);
            lbTotalFactor.Name = "lbTotalFactor";
            lbTotalFactor.Size = new Size(148, 23);
            lbTotalFactor.TabIndex = 23;
            lbTotalFactor.Text = "总因素: 0";
            lbTotalFactor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFactorW
            // 
            lblFactorW.BackColor = Color.DarkTurquoise;
            lblFactorW.BorderStyle = BorderStyle.Fixed3D;
            lblFactorW.Font = new Font("微软雅黑", 11F);
            lblFactorW.ForeColor = Color.FromArgb(48, 48, 48);
            lblFactorW.Location = new Point(324, 159);
            lblFactorW.Name = "lblFactorW";
            lblFactorW.Size = new Size(99, 23);
            lblFactorW.TabIndex = 22;
            lblFactorW.Text = "W: 0";
            lblFactorW.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFactorV
            // 
            lblFactorV.BackColor = Color.DarkTurquoise;
            lblFactorV.BorderStyle = BorderStyle.Fixed3D;
            lblFactorV.Font = new Font("微软雅黑", 11F);
            lblFactorV.ForeColor = Color.FromArgb(48, 48, 48);
            lblFactorV.Location = new Point(215, 159);
            lblFactorV.Name = "lblFactorV";
            lblFactorV.Size = new Size(99, 23);
            lblFactorV.TabIndex = 21;
            lblFactorV.Text = "V: 0";
            lblFactorV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFactorU
            // 
            lblFactorU.BackColor = Color.DarkTurquoise;
            lblFactorU.BorderStyle = BorderStyle.Fixed3D;
            lblFactorU.Font = new Font("微软雅黑", 11F);
            lblFactorU.ForeColor = Color.FromArgb(48, 48, 48);
            lblFactorU.Location = new Point(106, 159);
            lblFactorU.Name = "lblFactorU";
            lblFactorU.Size = new Size(99, 23);
            lblFactorU.TabIndex = 20;
            lblFactorU.Text = "U: 0";
            lblFactorU.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel8
            // 
            uiLabel8.Font = new Font("微软雅黑", 11F);
            uiLabel8.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel8.Location = new Point(16, 159);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(80, 23);
            uiLabel8.TabIndex = 19;
            uiLabel8.Text = "功率因数(W):";
            uiLabel8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbTotalVoltage
            // 
            lbTotalVoltage.BackColor = Color.Orange;
            lbTotalVoltage.BorderStyle = BorderStyle.Fixed3D;
            lbTotalVoltage.Font = new Font("微软雅黑", 11F);
            lbTotalVoltage.ForeColor = Color.FromArgb(48, 48, 48);
            lbTotalVoltage.Location = new Point(433, 46);
            lbTotalVoltage.Name = "lbTotalVoltage";
            lbTotalVoltage.Size = new Size(148, 23);
            lbTotalVoltage.TabIndex = 18;
            lbTotalVoltage.Text = "平均电压: 0V";
            lbTotalVoltage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbTotalCurrent
            // 
            lbTotalCurrent.BackColor = Color.Orange;
            lbTotalCurrent.BorderStyle = BorderStyle.Fixed3D;
            lbTotalCurrent.Font = new Font("微软雅黑", 11F);
            lbTotalCurrent.ForeColor = Color.FromArgb(48, 48, 48);
            lbTotalCurrent.Location = new Point(433, 84);
            lbTotalCurrent.Name = "lbTotalCurrent";
            lbTotalCurrent.Size = new Size(148, 23);
            lbTotalCurrent.TabIndex = 17;
            lbTotalCurrent.Text = "平均电流: 0A";
            lbTotalCurrent.TextAlign = ContentAlignment.MiddleLeft;
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
            uiLine2.Size = new Size(763, 29);
            uiLine2.TabIndex = 16;
            uiLine2.Text = "实时数据";
            uiLine2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFrequency
            // 
            lblFrequency.BackColor = Color.LightGreen;
            lblFrequency.BorderStyle = BorderStyle.Fixed3D;
            lblFrequency.Font = new Font("微软雅黑", 11F);
            lblFrequency.ForeColor = Color.FromArgb(48, 48, 48);
            lblFrequency.Location = new Point(619, 84);
            lblFrequency.Name = "lblFrequency";
            lblFrequency.Size = new Size(120, 57);
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
            lblTotalPower.Location = new Point(433, 120);
            lblTotalPower.Name = "lblTotalPower";
            lblTotalPower.Size = new Size(148, 23);
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
            lblPowerW.Location = new Point(324, 120);
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
            lblPowerV.Location = new Point(215, 120);
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
            lblPowerU.Location = new Point(106, 120);
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
            lblPowerTitle.Location = new Point(16, 120);
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
            lblCurrentW.Location = new Point(324, 84);
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
            lblCurrentV.Location = new Point(215, 84);
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
            lblCurrentU.Location = new Point(106, 84);
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
            lblCurrentTitle.Location = new Point(16, 84);
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
            // grpControl
            // 
            grpControl.BackColor = Color.Transparent;
            grpControl.Controls.Add(btnClose);
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
            grpControl.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            grpControl.Location = new Point(14, 334);
            grpControl.Margin = new Padding(4, 5, 4, 5);
            grpControl.MinimumSize = new Size(1, 1);
            grpControl.Name = "grpControl";
            grpControl.Padding = new Padding(0, 32, 0, 0);
            grpControl.RectColor = Color.FromArgb(65, 100, 204);
            grpControl.RectDisableColor = Color.FromArgb(65, 100, 204);
            grpControl.Size = new Size(779, 228);
            grpControl.TabIndex = 3;
            grpControl.TabStop = false;
            grpControl.Text = null;
            grpControl.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.WhiteSmoke;
            btnClose.Font = new Font("微软雅黑", 11F);
            btnClose.ForeColor = Color.Black;
            btnClose.Location = new Point(578, 165);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 50);
            btnClose.TabIndex = 16;
            btnClose.Text = "退 出";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
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
            uiLine1.Size = new Size(755, 29);
            uiLine1.TabIndex = 15;
            uiLine1.Text = "参数设置";
            uiLine1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnEmergencyStop
            // 
            btnEmergencyStop.BackColor = Color.WhiteSmoke;
            btnEmergencyStop.Font = new Font("微软雅黑", 11F);
            btnEmergencyStop.ForeColor = Color.Black;
            btnEmergencyStop.Location = new Point(408, 165);
            btnEmergencyStop.Name = "btnEmergencyStop";
            btnEmergencyStop.Size = new Size(120, 50);
            btnEmergencyStop.TabIndex = 14;
            btnEmergencyStop.Text = "电源停止";
            btnEmergencyStop.UseVisualStyleBackColor = false;
            btnEmergencyStop.Click += BtnEmergencyStop_Click;
            // 
            // btnQuickStart
            // 
            btnQuickStart.BackColor = Color.WhiteSmoke;
            btnQuickStart.Font = new Font("微软雅黑", 11F);
            btnQuickStart.ForeColor = Color.Black;
            btnQuickStart.Location = new Point(238, 165);
            btnQuickStart.Name = "btnQuickStart";
            btnQuickStart.Size = new Size(120, 50);
            btnQuickStart.TabIndex = 13;
            btnQuickStart.Text = "电源启动";
            btnQuickStart.UseVisualStyleBackColor = false;
            btnQuickStart.Click += BtnQuickStart_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.WhiteSmoke;
            btnReset.Font = new Font("微软雅黑", 11F);
            btnReset.ForeColor = Color.Black;
            btnReset.Location = new Point(68, 165);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(120, 50);
            btnReset.TabIndex = 12;
            btnReset.Text = "电源复位";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            // 
            // btnSetFrequency
            // 
            btnSetFrequency.BackColor = Color.LightGreen;
            btnSetFrequency.Font = new Font("微软雅黑", 11F);
            btnSetFrequency.Location = new Point(601, 99);
            btnSetFrequency.MinimumSize = new Size(1, 1);
            btnSetFrequency.Name = "btnSetFrequency";
            btnSetFrequency.Size = new Size(60, 27);
            btnSetFrequency.TabIndex = 11;
            btnSetFrequency.Text = "设置";
            btnSetFrequency.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSetFrequency.Click += BtnSetFrequency_Click;
            // 
            // numFrequency
            // 
            numFrequency.DecimalPlaces = 1;
            numFrequency.Font = new Font("微软雅黑", 11F);
            numFrequency.Location = new Point(451, 97);
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
            lblFrequencySet.Location = new Point(377, 99);
            lblFrequencySet.Name = "lblFrequencySet";
            lblFrequencySet.Size = new Size(80, 23);
            lblFrequencySet.TabIndex = 9;
            lblFrequencySet.Text = "设置频率:";
            lblFrequencySet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetVoltage
            // 
            btnSetVoltage.Font = new Font("微软雅黑", 11F);
            btnSetVoltage.Location = new Point(252, 99);
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
            numVoltage.Location = new Point(110, 101);
            numVoltage.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numVoltage.Name = "numVoltage";
            numVoltage.Size = new Size(129, 27);
            numVoltage.TabIndex = 7;
            numVoltage.TextAlign = HorizontalAlignment.Center;
            numVoltage.Value = new decimal(new int[] { 120, 0, 0, 0 });
            // 
            // lblVoltageSet
            // 
            lblVoltageSet.Font = new Font("微软雅黑", 11F);
            lblVoltageSet.ForeColor = Color.FromArgb(48, 48, 48);
            lblVoltageSet.Location = new Point(29, 103);
            lblVoltageSet.Name = "lblVoltageSet";
            lblVoltageSet.Size = new Size(85, 23);
            lblVoltageSet.TabIndex = 6;
            lblVoltageSet.Text = "设置电压:";
            lblVoltageSet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetOutputRange
            // 
            btnSetOutputRange.Font = new Font("微软雅黑", 11F);
            btnSetOutputRange.Location = new Point(601, 49);
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
            cmbOutputRange.Location = new Point(451, 51);
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
            lblOutputRange.Location = new Point(377, 53);
            lblOutputRange.Name = "lblOutputRange";
            lblOutputRange.Size = new Size(80, 23);
            lblOutputRange.TabIndex = 3;
            lblOutputRange.Text = "输出档位:";
            lblOutputRange.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetControlMode
            // 
            btnSetControlMode.Font = new Font("微软雅黑", 12F);
            btnSetControlMode.Location = new Point(252, 51);
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
            cmbControlMode.Location = new Point(110, 51);
            cmbControlMode.Margin = new Padding(4, 5, 4, 5);
            cmbControlMode.MinimumSize = new Size(63, 0);
            cmbControlMode.Name = "cmbControlMode";
            cmbControlMode.Padding = new Padding(0, 0, 30, 2);
            cmbControlMode.RectColor = Color.FromArgb(65, 100, 204);
            cmbControlMode.RectDisableColor = Color.FromArgb(65, 100, 204);
            cmbControlMode.Size = new Size(129, 25);
            cmbControlMode.SymbolSize = 24;
            cmbControlMode.TabIndex = 1;
            cmbControlMode.TextAlignment = ContentAlignment.MiddleLeft;
            cmbControlMode.Watermark = "";
            // 
            // lblControlMode
            // 
            lblControlMode.Font = new Font("微软雅黑", 11F);
            lblControlMode.ForeColor = Color.FromArgb(48, 48, 48);
            lblControlMode.Location = new Point(29, 53);
            lblControlMode.Name = "lblControlMode";
            lblControlMode.Size = new Size(85, 23);
            lblControlMode.TabIndex = 0;
            lblControlMode.Text = "控制模式:";
            lblControlMode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmPowerSupplyForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(806, 587);
            ControlBox = false;
            Controls.Add(grpControl);
            Controls.Add(grpDataDisplay);
            Controls.Add(grpConnection);
            Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPowerSupplyForm";
            RectColor = Color.FromArgb(65, 100, 204);
            ShowIcon = false;
            Text = "调频电源监控系统";
            TitleColor = Color.FromArgb(65, 100, 204);
            TitleFont = new Font("微软雅黑", 13F);
            ZoomScaleRect = new Rectangle(15, 15, 996, 531);
            grpConnection.ResumeLayout(false);
            grpDataDisplay.ResumeLayout(false);
            grpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numFrequency).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVoltage).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private UILine uiLine1;
        private UILine uiLine2;
        private UILabel lbTotalVoltage;
        private UILabel lbTotalCurrent;
        private UILabel lbTotalFactor;
        private UILabel lblFactorW;
        private UILabel lblFactorV;
        private UILabel lblFactorU;
        private UILabel uiLabel8;
        private Button btnClose;
    }
}