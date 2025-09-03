namespace MainUI
{
    partial class frmPowerSupplyForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region 控件声明

        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label lblConnectionStatus;

        private System.Windows.Forms.GroupBox grpDataDisplay;
        private System.Windows.Forms.Label lblVoltageTitle;
        private System.Windows.Forms.Label lblVoltageU;
        private System.Windows.Forms.Label lblVoltageV;
        private System.Windows.Forms.Label lblVoltageW;
        private System.Windows.Forms.Label lblCurrentTitle;
        private System.Windows.Forms.Label lblCurrentU;
        private System.Windows.Forms.Label lblCurrentV;
        private System.Windows.Forms.Label lblCurrentW;
        private System.Windows.Forms.Label lblPowerTitle;
        private System.Windows.Forms.Label lblPowerU;
        private System.Windows.Forms.Label lblPowerV;
        private System.Windows.Forms.Label lblPowerW;
        private System.Windows.Forms.Label lblTotalPower;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Label lblFaultStatus;

        private System.Windows.Forms.GroupBox grpProgress;
        private System.Windows.Forms.Label lblProgressVoltage;
        private System.Windows.Forms.ProgressBar progressVoltageU;
        private System.Windows.Forms.ProgressBar progressVoltageV;
        private System.Windows.Forms.ProgressBar progressVoltageW;
        private System.Windows.Forms.Label lblProgressCurrent;
        private System.Windows.Forms.ProgressBar progressCurrentU;
        private System.Windows.Forms.ProgressBar progressCurrentV;
        private System.Windows.Forms.ProgressBar progressCurrentW;

        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Label lblControlMode;
        private System.Windows.Forms.ComboBox cmbControlMode;
        private System.Windows.Forms.Button btnSetControlMode;
        private System.Windows.Forms.Label lblOutputRange;
        private System.Windows.Forms.ComboBox cmbOutputRange;
        private System.Windows.Forms.Button btnSetOutputRange;
        private System.Windows.Forms.Label lblVoltageSet;
        private System.Windows.Forms.NumericUpDown numVoltage;
        private System.Windows.Forms.Button btnSetVoltage;
        private System.Windows.Forms.Label lblFrequencySet;
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
            grpConnection = new GroupBox();
            lblConnectionStatus = new Label();
            btnDisconnect = new Button();
            btnConnect = new Button();
            cmbComPort = new ComboBox();
            lblPort = new Label();
            grpDataDisplay = new GroupBox();
            lblFaultStatus = new Label();
            lblFrequency = new Label();
            lblTotalPower = new Label();
            lblPowerW = new Label();
            lblPowerV = new Label();
            lblPowerU = new Label();
            lblPowerTitle = new Label();
            lblCurrentW = new Label();
            lblCurrentV = new Label();
            lblCurrentU = new Label();
            lblCurrentTitle = new Label();
            lblVoltageW = new Label();
            lblVoltageV = new Label();
            lblVoltageU = new Label();
            lblVoltageTitle = new Label();
            grpProgress = new GroupBox();
            progressCurrentW = new ProgressBar();
            progressCurrentV = new ProgressBar();
            progressCurrentU = new ProgressBar();
            lblProgressCurrent = new Label();
            progressVoltageW = new ProgressBar();
            progressVoltageV = new ProgressBar();
            progressVoltageU = new ProgressBar();
            lblProgressVoltage = new Label();
            grpControl = new GroupBox();
            btnEmergencyStop = new Button();
            btnQuickStart = new Button();
            btnReset = new Button();
            btnSetFrequency = new Button();
            numFrequency = new NumericUpDown();
            lblFrequencySet = new Label();
            btnSetVoltage = new Button();
            numVoltage = new NumericUpDown();
            lblVoltageSet = new Label();
            btnSetOutputRange = new Button();
            cmbOutputRange = new ComboBox();
            lblOutputRange = new Label();
            btnSetControlMode = new Button();
            cmbControlMode = new ComboBox();
            lblControlMode = new Label();
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
            grpConnection.Controls.Add(lblConnectionStatus);
            grpConnection.Controls.Add(btnDisconnect);
            grpConnection.Controls.Add(btnConnect);
            grpConnection.Controls.Add(cmbComPort);
            grpConnection.Controls.Add(lblPort);
            grpConnection.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            grpConnection.Location = new Point(12, 12);
            grpConnection.Name = "grpConnection";
            grpConnection.Size = new Size(860, 60);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = "连接设置";
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblConnectionStatus.ForeColor = Color.Red;
            lblConnectionStatus.Location = new Point(320, 25);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(200, 23);
            lblConnectionStatus.TabIndex = 4;
            lblConnectionStatus.Text = "未连接";
            lblConnectionStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Enabled = false;
            btnDisconnect.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDisconnect.Location = new Point(235, 21);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(70, 27);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "断开";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += BtnDisconnect_Click;
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConnect.Location = new Point(155, 21);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(70, 27);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "连接";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += BtnConnect_Click;
            // 
            // cmbComPort
            // 
            cmbComPort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbComPort.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmbComPort.FormattingEnabled = true;
            cmbComPort.Location = new Point(65, 22);
            cmbComPort.Name = "cmbComPort";
            cmbComPort.Size = new Size(80, 25);
            cmbComPort.TabIndex = 1;
            // 
            // lblPort
            // 
            lblPort.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblPort.Location = new Point(20, 25);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(40, 23);
            lblPort.TabIndex = 0;
            lblPort.Text = "串口:";
            lblPort.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpDataDisplay
            // 
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
            grpDataDisplay.Location = new Point(12, 78);
            grpDataDisplay.Name = "grpDataDisplay";
            grpDataDisplay.Size = new Size(500, 150);
            grpDataDisplay.TabIndex = 1;
            grpDataDisplay.TabStop = false;
            grpDataDisplay.Text = "实时数据";
            // 
            // lblFaultStatus
            // 
            lblFaultStatus.BackColor = Color.LightGreen;
            lblFaultStatus.BorderStyle = BorderStyle.Fixed3D;
            lblFaultStatus.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblFaultStatus.Location = new Point(140, 115);
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
            lblFrequency.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblFrequency.Location = new Point(10, 115);
            lblFrequency.Name = "lblFrequency";
            lblFrequency.Size = new Size(120, 23);
            lblFrequency.TabIndex = 13;
            lblFrequency.Text = "频率: 0.0HZ";
            lblFrequency.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalPower
            // 
            lblTotalPower.BackColor = Color.Orange;
            lblTotalPower.BorderStyle = BorderStyle.Fixed3D;
            lblTotalPower.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblTotalPower.Location = new Point(385, 85);
            lblTotalPower.Name = "lblTotalPower";
            lblTotalPower.Size = new Size(100, 23);
            lblTotalPower.TabIndex = 12;
            lblTotalPower.Text = "总功率: 0W";
            lblTotalPower.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPowerW
            // 
            lblPowerW.BackColor = Color.LightYellow;
            lblPowerW.BorderStyle = BorderStyle.Fixed3D;
            lblPowerW.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblPowerW.Location = new Point(290, 85);
            lblPowerW.Name = "lblPowerW";
            lblPowerW.Size = new Size(85, 23);
            lblPowerW.TabIndex = 11;
            lblPowerW.Text = "W: 0W";
            lblPowerW.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPowerV
            // 
            lblPowerV.BackColor = Color.LightYellow;
            lblPowerV.BorderStyle = BorderStyle.Fixed3D;
            lblPowerV.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblPowerV.Location = new Point(195, 85);
            lblPowerV.Name = "lblPowerV";
            lblPowerV.Size = new Size(85, 23);
            lblPowerV.TabIndex = 10;
            lblPowerV.Text = "V: 0W";
            lblPowerV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPowerU
            // 
            lblPowerU.BackColor = Color.LightYellow;
            lblPowerU.BorderStyle = BorderStyle.Fixed3D;
            lblPowerU.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblPowerU.Location = new Point(100, 85);
            lblPowerU.Name = "lblPowerU";
            lblPowerU.Size = new Size(85, 23);
            lblPowerU.TabIndex = 9;
            lblPowerU.Text = "U: 0W";
            lblPowerU.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPowerTitle
            // 
            lblPowerTitle.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblPowerTitle.Location = new Point(10, 85);
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
            lblCurrentW.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblCurrentW.Location = new Point(290, 55);
            lblCurrentW.Name = "lblCurrentW";
            lblCurrentW.Size = new Size(85, 23);
            lblCurrentW.TabIndex = 7;
            lblCurrentW.Text = "W: 0.0A";
            lblCurrentW.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentV
            // 
            lblCurrentV.BackColor = Color.LightBlue;
            lblCurrentV.BorderStyle = BorderStyle.Fixed3D;
            lblCurrentV.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblCurrentV.Location = new Point(195, 55);
            lblCurrentV.Name = "lblCurrentV";
            lblCurrentV.Size = new Size(85, 23);
            lblCurrentV.TabIndex = 6;
            lblCurrentV.Text = "V: 0.0A";
            lblCurrentV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentU
            // 
            lblCurrentU.BackColor = Color.LightBlue;
            lblCurrentU.BorderStyle = BorderStyle.Fixed3D;
            lblCurrentU.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblCurrentU.Location = new Point(100, 55);
            lblCurrentU.Name = "lblCurrentU";
            lblCurrentU.Size = new Size(85, 23);
            lblCurrentU.TabIndex = 5;
            lblCurrentU.Text = "U: 0.0A";
            lblCurrentU.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentTitle
            // 
            lblCurrentTitle.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblCurrentTitle.Location = new Point(10, 55);
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
            lblVoltageW.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblVoltageW.Location = new Point(290, 25);
            lblVoltageW.Name = "lblVoltageW";
            lblVoltageW.Size = new Size(85, 23);
            lblVoltageW.TabIndex = 3;
            lblVoltageW.Text = "W: 0.0V";
            lblVoltageW.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVoltageV
            // 
            lblVoltageV.BackColor = Color.LightGray;
            lblVoltageV.BorderStyle = BorderStyle.Fixed3D;
            lblVoltageV.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblVoltageV.Location = new Point(195, 25);
            lblVoltageV.Name = "lblVoltageV";
            lblVoltageV.Size = new Size(85, 23);
            lblVoltageV.TabIndex = 2;
            lblVoltageV.Text = "V: 0.0V";
            lblVoltageV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVoltageU
            // 
            lblVoltageU.BackColor = Color.LightGray;
            lblVoltageU.BorderStyle = BorderStyle.Fixed3D;
            lblVoltageU.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblVoltageU.Location = new Point(100, 25);
            lblVoltageU.Name = "lblVoltageU";
            lblVoltageU.Size = new Size(85, 23);
            lblVoltageU.TabIndex = 1;
            lblVoltageU.Text = "U: 0.0V";
            lblVoltageU.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVoltageTitle
            // 
            lblVoltageTitle.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblVoltageTitle.Location = new Point(10, 25);
            lblVoltageTitle.Name = "lblVoltageTitle";
            lblVoltageTitle.Size = new Size(80, 23);
            lblVoltageTitle.TabIndex = 0;
            lblVoltageTitle.Text = "三相电压(V):";
            lblVoltageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpProgress
            // 
            grpProgress.Controls.Add(progressCurrentW);
            grpProgress.Controls.Add(progressCurrentV);
            grpProgress.Controls.Add(progressCurrentU);
            grpProgress.Controls.Add(lblProgressCurrent);
            grpProgress.Controls.Add(progressVoltageW);
            grpProgress.Controls.Add(progressVoltageV);
            grpProgress.Controls.Add(progressVoltageU);
            grpProgress.Controls.Add(lblProgressVoltage);
            grpProgress.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            grpProgress.Location = new Point(522, 78);
            grpProgress.Name = "grpProgress";
            grpProgress.Size = new Size(350, 150);
            grpProgress.TabIndex = 2;
            grpProgress.TabStop = false;
            grpProgress.Text = "数据可视化";
            // 
            // progressCurrentW
            // 
            progressCurrentW.Location = new Point(225, 105);
            progressCurrentW.Maximum = 50;
            progressCurrentW.Name = "progressCurrentW";
            progressCurrentW.Size = new Size(90, 20);
            progressCurrentW.Style = ProgressBarStyle.Continuous;
            progressCurrentW.TabIndex = 7;
            // 
            // progressCurrentV
            // 
            progressCurrentV.Location = new Point(125, 105);
            progressCurrentV.Maximum = 50;
            progressCurrentV.Name = "progressCurrentV";
            progressCurrentV.Size = new Size(90, 20);
            progressCurrentV.Style = ProgressBarStyle.Continuous;
            progressCurrentV.TabIndex = 6;
            // 
            // progressCurrentU
            // 
            progressCurrentU.Location = new Point(25, 105);
            progressCurrentU.Maximum = 50;
            progressCurrentU.Name = "progressCurrentU";
            progressCurrentU.Size = new Size(90, 20);
            progressCurrentU.Style = ProgressBarStyle.Continuous;
            progressCurrentU.TabIndex = 5;
            // 
            // lblProgressCurrent
            // 
            lblProgressCurrent.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblProgressCurrent.Location = new Point(15, 80);
            lblProgressCurrent.Name = "lblProgressCurrent";
            lblProgressCurrent.Size = new Size(120, 20);
            lblProgressCurrent.TabIndex = 4;
            lblProgressCurrent.Text = "电流进度 (U-V-W):";
            // 
            // progressVoltageW
            // 
            progressVoltageW.Location = new Point(225, 50);
            progressVoltageW.Maximum = 300;
            progressVoltageW.Name = "progressVoltageW";
            progressVoltageW.Size = new Size(90, 20);
            progressVoltageW.Style = ProgressBarStyle.Continuous;
            progressVoltageW.TabIndex = 3;
            // 
            // progressVoltageV
            // 
            progressVoltageV.Location = new Point(125, 50);
            progressVoltageV.Maximum = 300;
            progressVoltageV.Name = "progressVoltageV";
            progressVoltageV.Size = new Size(90, 20);
            progressVoltageV.Style = ProgressBarStyle.Continuous;
            progressVoltageV.TabIndex = 2;
            // 
            // progressVoltageU
            // 
            progressVoltageU.Location = new Point(25, 50);
            progressVoltageU.Maximum = 300;
            progressVoltageU.Name = "progressVoltageU";
            progressVoltageU.Size = new Size(90, 20);
            progressVoltageU.Style = ProgressBarStyle.Continuous;
            progressVoltageU.TabIndex = 1;
            // 
            // lblProgressVoltage
            // 
            lblProgressVoltage.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblProgressVoltage.Location = new Point(15, 25);
            lblProgressVoltage.Name = "lblProgressVoltage";
            lblProgressVoltage.Size = new Size(120, 20);
            lblProgressVoltage.TabIndex = 0;
            lblProgressVoltage.Text = "电压进度 (U-V-W):";
            // 
            // grpControl
            // 
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
            grpControl.Location = new Point(12, 240);
            grpControl.Name = "grpControl";
            grpControl.Size = new Size(860, 180);
            grpControl.TabIndex = 3;
            grpControl.TabStop = false;
            grpControl.Text = "参数设置";
            // 
            // btnEmergencyStop
            // 
            btnEmergencyStop.BackColor = Color.Red;
            btnEmergencyStop.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnEmergencyStop.ForeColor = Color.White;
            btnEmergencyStop.Location = new Point(765, 36);
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
            btnQuickStart.Font = new Font("微软雅黑", 8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuickStart.Location = new Point(625, 36);
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
            btnReset.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(525, 56);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 30);
            btnReset.TabIndex = 12;
            btnReset.Text = "电源复位";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += BtnReset_Click;
            // 
            // btnSetFrequency
            // 
            btnSetFrequency.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSetFrequency.Location = new Point(416, 77);
            btnSetFrequency.Name = "btnSetFrequency";
            btnSetFrequency.Size = new Size(60, 27);
            btnSetFrequency.TabIndex = 11;
            btnSetFrequency.Text = "设置";
            btnSetFrequency.UseVisualStyleBackColor = true;
            btnSetFrequency.Click += BtnSetFrequency_Click;
            // 
            // numFrequency
            // 
            numFrequency.DecimalPlaces = 1;
            numFrequency.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            numFrequency.Location = new Point(321, 78);
            numFrequency.Maximum = new decimal(new int[] { 70, 0, 0, 0 });
            numFrequency.Minimum = new decimal(new int[] { 40, 0, 0, 0 });
            numFrequency.Name = "numFrequency";
            numFrequency.Size = new Size(90, 23);
            numFrequency.TabIndex = 10;
            numFrequency.TextAlign = HorizontalAlignment.Center;
            numFrequency.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblFrequencySet
            // 
            lblFrequencySet.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblFrequencySet.Location = new Point(258, 80);
            lblFrequencySet.Name = "lblFrequencySet";
            lblFrequencySet.Size = new Size(70, 23);
            lblFrequencySet.TabIndex = 9;
            lblFrequencySet.Text = "设置频率:";
            lblFrequencySet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetVoltage
            // 
            btnSetVoltage.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSetVoltage.Location = new Point(177, 77);
            btnSetVoltage.Name = "btnSetVoltage";
            btnSetVoltage.Size = new Size(60, 27);
            btnSetVoltage.TabIndex = 8;
            btnSetVoltage.Text = "设置";
            btnSetVoltage.UseVisualStyleBackColor = true;
            btnSetVoltage.Click += BtnSetVoltage_Click;
            // 
            // numVoltage
            // 
            numVoltage.DecimalPlaces = 1;
            numVoltage.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            numVoltage.Location = new Point(82, 78);
            numVoltage.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numVoltage.Name = "numVoltage";
            numVoltage.Size = new Size(90, 23);
            numVoltage.TabIndex = 7;
            numVoltage.TextAlign = HorizontalAlignment.Center;
            numVoltage.Value = new decimal(new int[] { 120, 0, 0, 0 });
            // 
            // lblVoltageSet
            // 
            lblVoltageSet.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblVoltageSet.Location = new Point(18, 80);
            lblVoltageSet.Name = "lblVoltageSet";
            lblVoltageSet.Size = new Size(70, 23);
            lblVoltageSet.TabIndex = 6;
            lblVoltageSet.Text = "设置电压:";
            lblVoltageSet.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetOutputRange
            // 
            btnSetOutputRange.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSetOutputRange.Location = new Point(416, 27);
            btnSetOutputRange.Name = "btnSetOutputRange";
            btnSetOutputRange.Size = new Size(60, 27);
            btnSetOutputRange.TabIndex = 5;
            btnSetOutputRange.Text = "设置";
            btnSetOutputRange.UseVisualStyleBackColor = true;
            btnSetOutputRange.Click += BtnSetOutputRange_Click;
            // 
            // cmbOutputRange
            // 
            cmbOutputRange.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOutputRange.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmbOutputRange.FormattingEnabled = true;
            cmbOutputRange.Items.AddRange(new object[] { "高档0-300V", "低档0-150V" });
            cmbOutputRange.Location = new Point(321, 28);
            cmbOutputRange.Name = "cmbOutputRange";
            cmbOutputRange.Size = new Size(90, 25);
            cmbOutputRange.TabIndex = 4;
            // 
            // lblOutputRange
            // 
            lblOutputRange.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblOutputRange.Location = new Point(258, 30);
            lblOutputRange.Name = "lblOutputRange";
            lblOutputRange.Size = new Size(70, 23);
            lblOutputRange.TabIndex = 3;
            lblOutputRange.Text = "输出档位:";
            lblOutputRange.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSetControlMode
            // 
            btnSetControlMode.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSetControlMode.Location = new Point(177, 27);
            btnSetControlMode.Name = "btnSetControlMode";
            btnSetControlMode.Size = new Size(60, 27);
            btnSetControlMode.TabIndex = 2;
            btnSetControlMode.Text = "设置";
            btnSetControlMode.UseVisualStyleBackColor = true;
            btnSetControlMode.Click += BtnSetControlMode_Click;
            // 
            // cmbControlMode
            // 
            cmbControlMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbControlMode.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            cmbControlMode.FormattingEnabled = true;
            cmbControlMode.Items.AddRange(new object[] { "本机控制", "电脑控制" });
            cmbControlMode.Location = new Point(82, 28);
            cmbControlMode.Name = "cmbControlMode";
            cmbControlMode.Size = new Size(90, 25);
            cmbControlMode.TabIndex = 1;
            // 
            // lblControlMode
            // 
            lblControlMode.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblControlMode.Location = new Point(18, 30);
            lblControlMode.Name = "lblControlMode";
            lblControlMode.Size = new Size(70, 23);
            lblControlMode.TabIndex = 0;
            lblControlMode.Text = "控制模式:";
            lblControlMode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmPowerSupplyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 431);
            Controls.Add(grpControl);
            Controls.Add(grpProgress);
            Controls.Add(grpDataDisplay);
            Controls.Add(grpConnection);
            Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmPowerSupplyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "调频电源监控系统";
            grpConnection.ResumeLayout(false);
            grpDataDisplay.ResumeLayout(false);
            grpProgress.ResumeLayout(false);
            grpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numFrequency).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVoltage).EndInit();
            ResumeLayout(false);

        }

        #endregion
    }
}