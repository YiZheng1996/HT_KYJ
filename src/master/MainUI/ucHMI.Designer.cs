using AntdUI;
using MainUI.Procedure.Controls;
using Label = System.Windows.Forms.Label;

namespace MainUI
{
    partial class UcHMI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    // 停止并释放电源数据刷新定时器
                    if (_powerTimer != null)
                    {
                        _powerTimer.Stop();
                        _powerTimer.Dispose();
                        _powerTimer = null;
                    }

                    // 关闭并释放电源串口连接
                    if (_powerSupply != null)
                    {
                        _powerSupply.Close();
                        _powerSupply.Dispose();
                        _powerSupply = null;
                    }

                    NlogHelper.Default.Info("电源监控资源释放完成");
                }
                catch (Exception ex)
                {
                    NlogHelper.Default.Error($"释放电源监控资源时发生错误: {ex.Message}");
                }
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Tabs.StyleLine styleLine1 = new Tabs.StyleLine();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcHMI));
            uiTitlePanel3 = new UITitlePanel();
            TableItemPoint = new Table();
            btnProductSelection = new UIButton();
            uiTextBox1 = new UITextBox();
            uiTextBox2 = new UITextBox();
            uiTextBox3 = new UITextBox();
            uiTextBox4 = new UITextBox();
            uiTextBox8 = new UITextBox();
            uiTextBox10 = new UITextBox();
            uiTextBox12 = new UITextBox();
            uiTextBox13 = new UITextBox();
            uiTextBox14 = new UITextBox();
            uiTextBox15 = new UITextBox();
            uiTextBox11 = new UITextBox();
            uiTextBox19 = new UITextBox();
            btnStartTest = new UIButton();
            uiTitlePanel8 = new UITitlePanel();
            LabTestTime = new UIPanel();
            btnStopTest = new UIButton();
            tabs1 = new Tabs();
            tabPage3 = new AntdUI.TabPage();
            grpRainy = new UIPanel();
            uiPanel11 = new UIPanel();
            label10 = new AntdUI.Label();
            uiLabel1 = new UILabel();
            uiLabel4 = new UILabel();
            uiPanel6 = new UIPanel();
            minus = new PictureBox();
            LabelNumber = new UIDigitalLabel();
            plus = new PictureBox();
            btnPageDown = new UISymbolButton();
            btnPageUp = new UISymbolButton();
            btnPrintReport = new UISymbolButton();
            btnSaveReport = new UISymbolButton();
            ucGrid1 = new Report.UcGrid();
            uiPanel5 = new UIPanel();
            label5 = new AntdUI.Label();
            uiLabel12 = new UILabel();
            LabTemperature02 = new UILabel();
            uiPanel7 = new UIPanel();
            label6 = new AntdUI.Label();
            uiLabel14 = new UILabel();
            LabTemperature01 = new UILabel();
            uiPanel8 = new UIPanel();
            label7 = new AntdUI.Label();
            uiLabel16 = new UILabel();
            LabPressure03 = new UILabel();
            uiPanel9 = new UIPanel();
            label8 = new AntdUI.Label();
            uiLabel19 = new UILabel();
            LabPressure02 = new UILabel();
            uiPanel10 = new UIPanel();
            label9 = new AntdUI.Label();
            uiLabel21 = new UILabel();
            LabPressure01 = new UILabel();
            uiPanel2 = new UIPanel();
            label2 = new AntdUI.Label();
            uiPanel101 = new UILabel();
            LabHJYL = new UILabel();
            uiPanel1 = new UIPanel();
            label1 = new AntdUI.Label();
            uiPanel100 = new UILabel();
            LabSD = new UILabel();
            uiPanel18 = new UIPanel();
            label43 = new AntdUI.Label();
            uiLabel17 = new UILabel();
            LabWD = new UILabel();
            tabPage1 = new AntdUI.TabPage();
            panelChart = new UIPanel();
            uiTitlePanel4 = new UITitlePanel();
            uiLabel7 = new UILabel();
            uiLabel3 = new UILabel();
            uiLabel2 = new UILabel();
            panelHand = new UIPanel();
            RadioHand = new UIRadioButton();
            RadioAuto = new UIRadioButton();
            btnReportForms = new AntdUI.Button();
            btnWorkmanshipForms = new AntdUI.Button();
            txtDrawingNo = new UITextBox();
            txtModel = new UITextBox();
            txtNumber = new UITextBox();
            alert = new Alert();
            uiTitlePanel3.SuspendLayout();
            uiTitlePanel8.SuspendLayout();
            tabs1.SuspendLayout();
            tabPage3.SuspendLayout();
            grpRainy.SuspendLayout();
            uiPanel11.SuspendLayout();
            uiPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)minus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plus).BeginInit();
            uiPanel5.SuspendLayout();
            uiPanel7.SuspendLayout();
            uiPanel8.SuspendLayout();
            uiPanel9.SuspendLayout();
            uiPanel10.SuspendLayout();
            uiPanel2.SuspendLayout();
            uiPanel1.SuspendLayout();
            uiPanel18.SuspendLayout();
            tabPage1.SuspendLayout();
            panelChart.SuspendLayout();
            uiTitlePanel4.SuspendLayout();
            panelHand.SuspendLayout();
            SuspendLayout();
            // 
            // uiTitlePanel3
            // 
            uiTitlePanel3.BackColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel3.Controls.Add(TableItemPoint);
            uiTitlePanel3.FillColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel3.FillColor2 = Color.FromArgb(236, 236, 236);
            uiTitlePanel3.FillDisableColor = Color.FromArgb(49, 54, 64);
            uiTitlePanel3.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            uiTitlePanel3.Location = new Point(659, 171);
            uiTitlePanel3.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel3.MinimumSize = new Size(1, 1);
            uiTitlePanel3.Name = "uiTitlePanel3";
            uiTitlePanel3.Padding = new Padding(1, 29, 1, 1);
            uiTitlePanel3.Radius = 0;
            uiTitlePanel3.RectColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel3.RectDisableColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel3.ShowText = false;
            uiTitlePanel3.Size = new Size(177, 252);
            uiTitlePanel3.TabIndex = 398;
            uiTitlePanel3.Text = "试验项点";
            uiTitlePanel3.TextAlignment = ContentAlignment.MiddleCenter;
            uiTitlePanel3.TitleColor = Color.FromArgb(65, 100, 204);
            uiTitlePanel3.TitleHeight = 29;
            uiTitlePanel3.Visible = false;
            // 
            // TableItemPoint
            // 
            TableItemPoint.BackColor = Color.White;
            TableItemPoint.CheckSize = 18;
            TableItemPoint.Dock = DockStyle.Bottom;
            TableItemPoint.Font = new Font("微软雅黑", 12F);
            TableItemPoint.ForeColor = Color.Black;
            TableItemPoint.Gap = 12;
            TableItemPoint.Location = new Point(1, 26);
            TableItemPoint.Name = "TableItemPoint";
            TableItemPoint.RowSelectedBg = Color.Transparent;
            TableItemPoint.Size = new Size(175, 225);
            TableItemPoint.TabIndex = 53;
            TableItemPoint.CheckedChanged += TableItemPoint_CheckedChanged;
            TableItemPoint.SetRowStyle += TableItemPoint_SetRowStyle;
            // 
            // btnProductSelection
            // 
            btnProductSelection.BackColor = Color.Transparent;
            btnProductSelection.Cursor = Cursors.Hand;
            btnProductSelection.FillDisableColor = Color.FromArgb(80, 160, 255);
            btnProductSelection.Font = new Font("思源黑体 CN Bold", 12F, FontStyle.Bold);
            btnProductSelection.ForeDisableColor = Color.White;
            btnProductSelection.Location = new Point(213, 0);
            btnProductSelection.MinimumSize = new Size(1, 1);
            btnProductSelection.Name = "btnProductSelection";
            btnProductSelection.Radius = 10;
            btnProductSelection.RectDisableColor = Color.FromArgb(80, 160, 255);
            btnProductSelection.ShowFocusLine = true;
            btnProductSelection.Size = new Size(158, 35);
            btnProductSelection.TabIndex = 60;
            btnProductSelection.Text = "车型选择";
            btnProductSelection.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnProductSelection.TipsText = "1";
            btnProductSelection.Click += btnProductSelection_Click;
            // 
            // uiTextBox1
            // 
            uiTextBox1.Cursor = Cursors.IBeam;
            uiTextBox1.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox1.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox1.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox1.Location = new Point(890, 30);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.ReadOnly = true;
            uiTextBox1.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox1.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(95, 30);
            uiTextBox1.TabIndex = 942;
            uiTextBox1.Tag = "1";
            uiTextBox1.Text = "0";
            uiTextBox1.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox1.Watermark = "";
            // 
            // uiTextBox2
            // 
            uiTextBox2.Cursor = Cursors.IBeam;
            uiTextBox2.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox2.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox2.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox2.Location = new Point(555, 92);
            uiTextBox2.Margin = new Padding(4, 5, 4, 5);
            uiTextBox2.MinimumSize = new Size(1, 16);
            uiTextBox2.Name = "uiTextBox2";
            uiTextBox2.Padding = new Padding(5);
            uiTextBox2.ReadOnly = true;
            uiTextBox2.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox2.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox2.ShowText = false;
            uiTextBox2.Size = new Size(95, 30);
            uiTextBox2.TabIndex = 942;
            uiTextBox2.Tag = "2";
            uiTextBox2.Text = "0";
            uiTextBox2.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox2.Watermark = "";
            // 
            // uiTextBox3
            // 
            uiTextBox3.Cursor = Cursors.IBeam;
            uiTextBox3.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox3.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox3.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox3.Location = new Point(890, 136);
            uiTextBox3.Margin = new Padding(4, 5, 4, 5);
            uiTextBox3.MinimumSize = new Size(1, 16);
            uiTextBox3.Name = "uiTextBox3";
            uiTextBox3.Padding = new Padding(5);
            uiTextBox3.ReadOnly = true;
            uiTextBox3.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox3.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox3.ShowText = false;
            uiTextBox3.Size = new Size(95, 30);
            uiTextBox3.TabIndex = 944;
            uiTextBox3.Tag = "3";
            uiTextBox3.Text = "0";
            uiTextBox3.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox3.Watermark = "";
            // 
            // uiTextBox4
            // 
            uiTextBox4.Cursor = Cursors.IBeam;
            uiTextBox4.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox4.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox4.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox4.Location = new Point(890, 284);
            uiTextBox4.Margin = new Padding(4, 5, 4, 5);
            uiTextBox4.MinimumSize = new Size(1, 16);
            uiTextBox4.Name = "uiTextBox4";
            uiTextBox4.Padding = new Padding(5);
            uiTextBox4.ReadOnly = true;
            uiTextBox4.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox4.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox4.ShowText = false;
            uiTextBox4.Size = new Size(95, 30);
            uiTextBox4.TabIndex = 944;
            uiTextBox4.Tag = "4";
            uiTextBox4.Text = "0";
            uiTextBox4.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox4.Watermark = "";
            // 
            // uiTextBox8
            // 
            uiTextBox8.Cursor = Cursors.IBeam;
            uiTextBox8.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox8.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox8.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox8.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox8.Location = new Point(890, 345);
            uiTextBox8.Margin = new Padding(4, 5, 4, 5);
            uiTextBox8.MinimumSize = new Size(1, 16);
            uiTextBox8.Name = "uiTextBox8";
            uiTextBox8.Padding = new Padding(5);
            uiTextBox8.ReadOnly = true;
            uiTextBox8.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox8.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox8.ShowText = false;
            uiTextBox8.Size = new Size(95, 30);
            uiTextBox8.TabIndex = 946;
            uiTextBox8.Tag = "6";
            uiTextBox8.Text = "0";
            uiTextBox8.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox8.Watermark = "";
            // 
            // uiTextBox10
            // 
            uiTextBox10.Cursor = Cursors.IBeam;
            uiTextBox10.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox10.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox10.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox10.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox10.Location = new Point(505, 337);
            uiTextBox10.Margin = new Padding(4, 5, 4, 5);
            uiTextBox10.MinimumSize = new Size(1, 16);
            uiTextBox10.Name = "uiTextBox10";
            uiTextBox10.Padding = new Padding(5);
            uiTextBox10.ReadOnly = true;
            uiTextBox10.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox10.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox10.ShowText = false;
            uiTextBox10.Size = new Size(95, 30);
            uiTextBox10.TabIndex = 948;
            uiTextBox10.Tag = "5";
            uiTextBox10.Text = "0";
            uiTextBox10.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox10.Watermark = "";
            // 
            // uiTextBox12
            // 
            uiTextBox12.Cursor = Cursors.IBeam;
            uiTextBox12.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox12.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox12.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox12.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox12.Location = new Point(890, 424);
            uiTextBox12.Margin = new Padding(4, 5, 4, 5);
            uiTextBox12.MinimumSize = new Size(1, 16);
            uiTextBox12.Name = "uiTextBox12";
            uiTextBox12.Padding = new Padding(5);
            uiTextBox12.ReadOnly = true;
            uiTextBox12.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox12.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox12.ShowText = false;
            uiTextBox12.Size = new Size(95, 30);
            uiTextBox12.TabIndex = 948;
            uiTextBox12.Tag = "8";
            uiTextBox12.Text = "0";
            uiTextBox12.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox12.Watermark = "";
            // 
            // uiTextBox13
            // 
            uiTextBox13.Cursor = Cursors.IBeam;
            uiTextBox13.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox13.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox13.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox13.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox13.Location = new Point(890, 487);
            uiTextBox13.Margin = new Padding(4, 5, 4, 5);
            uiTextBox13.MinimumSize = new Size(1, 16);
            uiTextBox13.Name = "uiTextBox13";
            uiTextBox13.Padding = new Padding(5);
            uiTextBox13.ReadOnly = true;
            uiTextBox13.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox13.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox13.ShowText = false;
            uiTextBox13.Size = new Size(95, 30);
            uiTextBox13.TabIndex = 948;
            uiTextBox13.Tag = "10";
            uiTextBox13.Text = "0";
            uiTextBox13.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox13.Watermark = "";
            // 
            // uiTextBox14
            // 
            uiTextBox14.Cursor = Cursors.IBeam;
            uiTextBox14.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox14.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox14.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox14.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox14.Location = new Point(890, 560);
            uiTextBox14.Margin = new Padding(4, 5, 4, 5);
            uiTextBox14.MinimumSize = new Size(1, 16);
            uiTextBox14.Name = "uiTextBox14";
            uiTextBox14.Padding = new Padding(5);
            uiTextBox14.ReadOnly = true;
            uiTextBox14.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox14.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox14.ShowText = false;
            uiTextBox14.Size = new Size(95, 30);
            uiTextBox14.TabIndex = 950;
            uiTextBox14.Tag = "12";
            uiTextBox14.Text = "0";
            uiTextBox14.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox14.Watermark = "";
            // 
            // uiTextBox15
            // 
            uiTextBox15.Cursor = Cursors.IBeam;
            uiTextBox15.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox15.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox15.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox15.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox15.Location = new Point(505, 491);
            uiTextBox15.Margin = new Padding(4, 5, 4, 5);
            uiTextBox15.MinimumSize = new Size(1, 16);
            uiTextBox15.Name = "uiTextBox15";
            uiTextBox15.Padding = new Padding(5);
            uiTextBox15.ReadOnly = true;
            uiTextBox15.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox15.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox15.ShowText = false;
            uiTextBox15.Size = new Size(95, 30);
            uiTextBox15.TabIndex = 950;
            uiTextBox15.Tag = "9";
            uiTextBox15.Text = "0";
            uiTextBox15.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox15.Watermark = "";
            // 
            // uiTextBox11
            // 
            uiTextBox11.Cursor = Cursors.IBeam;
            uiTextBox11.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox11.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox11.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox11.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox11.Location = new Point(505, 424);
            uiTextBox11.Margin = new Padding(4, 5, 4, 5);
            uiTextBox11.MinimumSize = new Size(1, 16);
            uiTextBox11.Name = "uiTextBox11";
            uiTextBox11.Padding = new Padding(5);
            uiTextBox11.ReadOnly = true;
            uiTextBox11.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox11.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox11.ShowText = false;
            uiTextBox11.Size = new Size(95, 30);
            uiTextBox11.TabIndex = 950;
            uiTextBox11.Tag = "7";
            uiTextBox11.Text = "0";
            uiTextBox11.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox11.Watermark = "";
            // 
            // uiTextBox19
            // 
            uiTextBox19.Cursor = Cursors.IBeam;
            uiTextBox19.FillColor = Color.FromArgb(243, 249, 255);
            uiTextBox19.FillDisableColor = Color.FromArgb(243, 249, 255);
            uiTextBox19.FillReadOnlyColor = Color.FromArgb(243, 249, 255);
            uiTextBox19.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiTextBox19.Location = new Point(505, 560);
            uiTextBox19.Margin = new Padding(4, 5, 4, 5);
            uiTextBox19.MinimumSize = new Size(1, 16);
            uiTextBox19.Name = "uiTextBox19";
            uiTextBox19.Padding = new Padding(5);
            uiTextBox19.ReadOnly = true;
            uiTextBox19.RectDisableColor = Color.FromArgb(80, 160, 255);
            uiTextBox19.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
            uiTextBox19.ShowText = false;
            uiTextBox19.Size = new Size(95, 30);
            uiTextBox19.TabIndex = 952;
            uiTextBox19.Tag = "11";
            uiTextBox19.Text = "0";
            uiTextBox19.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox19.Watermark = "";
            // 
            // btnStartTest
            // 
            btnStartTest.Cursor = Cursors.Hand;
            btnStartTest.FillColor = Color.FromArgb(90, 124, 236);
            btnStartTest.FillColor2 = Color.FromArgb(90, 124, 236);
            btnStartTest.FillDisableColor = Color.FromArgb(153, 153, 161);
            btnStartTest.FillHoverColor = Color.FromArgb(90, 124, 236);
            btnStartTest.FillPressColor = Color.FromArgb(90, 124, 236);
            btnStartTest.FillSelectedColor = Color.FromArgb(90, 124, 236);
            btnStartTest.Font = new Font("思源黑体 CN Bold", 16F, FontStyle.Bold);
            btnStartTest.ForeColor = Color.FromArgb(235, 227, 221);
            btnStartTest.ForeDisableColor = Color.FromArgb(235, 227, 221);
            btnStartTest.LightColor = Color.FromArgb(245, 251, 241);
            btnStartTest.Location = new Point(520, 611);
            btnStartTest.MinimumSize = new Size(1, 1);
            btnStartTest.Name = "btnStartTest";
            btnStartTest.Radius = 7;
            btnStartTest.RectColor = Color.FromArgb(90, 124, 236);
            btnStartTest.RectDisableColor = Color.FromArgb(153, 153, 161);
            btnStartTest.RectHoverColor = Color.FromArgb(90, 124, 236);
            btnStartTest.RectPressColor = Color.FromArgb(90, 124, 236);
            btnStartTest.RectSelectedColor = Color.FromArgb(90, 124, 236);
            btnStartTest.Size = new Size(145, 70);
            btnStartTest.Style = UIStyle.Custom;
            btnStartTest.StyleCustomMode = true;
            btnStartTest.TabIndex = 398;
            btnStartTest.Text = "开始试验";
            btnStartTest.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnStartTest.Visible = false;
            btnStartTest.Click += btnStartTest_Click;
            // 
            // uiTitlePanel8
            // 
            uiTitlePanel8.BackColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel8.Controls.Add(LabTestTime);
            uiTitlePanel8.FillColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel8.FillColor2 = Color.FromArgb(236, 236, 236);
            uiTitlePanel8.FillDisableColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel8.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            uiTitlePanel8.Location = new Point(512, 496);
            uiTitlePanel8.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel8.MinimumSize = new Size(1, 1);
            uiTitlePanel8.Name = "uiTitlePanel8";
            uiTitlePanel8.Padding = new Padding(1, 29, 1, 1);
            uiTitlePanel8.Radius = 0;
            uiTitlePanel8.RectColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel8.RectDisableColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel8.ShowText = false;
            uiTitlePanel8.Size = new Size(322, 103);
            uiTitlePanel8.TabIndex = 400;
            uiTitlePanel8.Text = "试验时间";
            uiTitlePanel8.TextAlignment = ContentAlignment.MiddleCenter;
            uiTitlePanel8.TitleColor = Color.FromArgb(65, 100, 204);
            uiTitlePanel8.TitleHeight = 29;
            uiTitlePanel8.Visible = false;
            // 
            // LabTestTime
            // 
            LabTestTime.BackColor = Color.Transparent;
            LabTestTime.FillColor = Color.FromArgb(43, 46, 57);
            LabTestTime.FillColor2 = Color.FromArgb(43, 46, 57);
            LabTestTime.Font = new Font("微软雅黑", 40F);
            LabTestTime.ForeColor = Color.White;
            LabTestTime.Location = new Point(16, 35);
            LabTestTime.Margin = new Padding(4, 5, 4, 5);
            LabTestTime.MinimumSize = new Size(1, 1);
            LabTestTime.Name = "LabTestTime";
            LabTestTime.Radius = 15;
            LabTestTime.RectColor = Color.FromArgb(43, 46, 57);
            LabTestTime.RectDisableColor = Color.FromArgb(43, 46, 57);
            LabTestTime.Size = new Size(290, 63);
            LabTestTime.TabIndex = 498;
            LabTestTime.Text = "00:00:00";
            LabTestTime.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnStopTest
            // 
            btnStopTest.Cursor = Cursors.Hand;
            btnStopTest.FillColor = Color.FromArgb(230, 83, 100);
            btnStopTest.FillColor2 = Color.FromArgb(230, 83, 100);
            btnStopTest.FillDisableColor = Color.FromArgb(153, 153, 161);
            btnStopTest.FillHoverColor = Color.FromArgb(235, 115, 115);
            btnStopTest.FillPressColor = Color.FromArgb(184, 64, 64);
            btnStopTest.FillSelectedColor = Color.FromArgb(184, 64, 64);
            btnStopTest.Font = new Font("思源黑体 CN Bold", 16F, FontStyle.Bold);
            btnStopTest.ForeColor = Color.FromArgb(235, 227, 221);
            btnStopTest.ForeDisableColor = Color.FromArgb(235, 227, 221);
            btnStopTest.LightColor = Color.FromArgb(253, 243, 243);
            btnStopTest.Location = new Point(682, 611);
            btnStopTest.MinimumSize = new Size(1, 1);
            btnStopTest.Name = "btnStopTest";
            btnStopTest.Radius = 7;
            btnStopTest.RectColor = Color.FromArgb(230, 83, 100);
            btnStopTest.RectDisableColor = Color.FromArgb(153, 153, 161);
            btnStopTest.RectHoverColor = Color.FromArgb(235, 115, 115);
            btnStopTest.RectPressColor = Color.FromArgb(184, 64, 64);
            btnStopTest.RectSelectedColor = Color.FromArgb(184, 64, 64);
            btnStopTest.Size = new Size(145, 70);
            btnStopTest.Style = UIStyle.Custom;
            btnStopTest.StyleCustomMode = true;
            btnStopTest.TabIndex = 399;
            btnStopTest.Text = "结束试验";
            btnStopTest.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnStopTest.Visible = false;
            btnStopTest.Click += btnStopTest_Click;
            // 
            // tabs1
            // 
            tabs1.BackColor = Color.FromArgb(236, 236, 237);
            tabs1.Controls.Add(tabPage3);
            tabs1.Controls.Add(tabPage1);
            tabs1.Location = new Point(0, 33);
            tabs1.Name = "tabs1";
            tabs1.Pages.Add(tabPage3);
            tabs1.Pages.Add(tabPage1);
            tabs1.ScrollForeHover = SystemColors.ActiveBorder;
            tabs1.Size = new Size(1753, 910);
            tabs1.Style = styleLine1;
            tabs1.TabIndex = 405;
            tabs1.TabMenuVisible = false;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(42, 47, 55);
            tabPage3.Controls.Add(grpRainy);
            tabPage3.Location = new Point(3, 3);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1747, 904);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "工艺界面";
            // 
            // grpRainy
            // 
            grpRainy.BackColor = Color.FromArgb(236, 236, 237);
            grpRainy.Controls.Add(uiPanel11);
            grpRainy.Controls.Add(uiPanel6);
            grpRainy.Controls.Add(ucGrid1);
            grpRainy.Controls.Add(uiPanel5);
            grpRainy.Controls.Add(uiPanel7);
            grpRainy.Controls.Add(uiPanel8);
            grpRainy.Controls.Add(uiPanel9);
            grpRainy.Controls.Add(uiPanel10);
            grpRainy.Controls.Add(uiPanel2);
            grpRainy.Controls.Add(uiPanel1);
            grpRainy.Controls.Add(uiPanel18);
            grpRainy.Dock = DockStyle.Fill;
            grpRainy.FillColor = Color.FromArgb(236, 236, 237);
            grpRainy.FillColor2 = Color.FromArgb(236, 236, 237);
            grpRainy.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            grpRainy.Location = new Point(0, 0);
            grpRainy.Margin = new Padding(4, 5, 4, 5);
            grpRainy.MinimumSize = new Size(1, 1);
            grpRainy.Name = "grpRainy";
            grpRainy.Radius = 0;
            grpRainy.RectColor = Color.FromArgb(236, 236, 237);
            grpRainy.RectDisableColor = Color.FromArgb(236, 236, 237);
            grpRainy.Size = new Size(1747, 904);
            grpRainy.TabIndex = 521;
            grpRainy.Text = null;
            grpRainy.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiPanel11
            // 
            uiPanel11.BackColor = Color.Transparent;
            uiPanel11.Controls.Add(label10);
            uiPanel11.Controls.Add(uiLabel1);
            uiPanel11.Controls.Add(uiLabel4);
            uiPanel11.FillColor = Color.White;
            uiPanel11.FillColor2 = Color.White;
            uiPanel11.FillDisableColor = Color.White;
            uiPanel11.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel11.ForeColor = Color.Black;
            uiPanel11.ForeDisableColor = Color.Black;
            uiPanel11.Location = new Point(4, 787);
            uiPanel11.Margin = new Padding(4, 5, 4, 5);
            uiPanel11.MinimumSize = new Size(1, 1);
            uiPanel11.Name = "uiPanel11";
            uiPanel11.Radius = 30;
            uiPanel11.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel11.Size = new Size(181, 105);
            uiPanel11.TabIndex = 523;
            uiPanel11.Text = null;
            uiPanel11.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(64, 64, 64);
            label10.ForeColor = Color.FromArgb(141, 145, 145);
            label10.Location = new Point(6, 71);
            label10.Name = "label10";
            label10.Size = new Size(170, 2);
            label10.TabIndex = 495;
            label10.Text = "";
            // 
            // uiLabel1
            // 
            uiLabel1.AutoSize = true;
            uiLabel1.BackColor = Color.Transparent;
            uiLabel1.Font = new Font("宋体", 13F);
            uiLabel1.ForeColor = Color.FromArgb(64, 64, 64);
            uiLabel1.Location = new Point(4, 79);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(152, 18);
            uiLabel1.TabIndex = 496;
            uiLabel1.Text = "空气温度检测(℃)";
            // 
            // uiLabel4
            // 
            uiLabel4.BackColor = Color.Transparent;
            uiLabel4.Font = new Font("宋体", 35F);
            uiLabel4.ForeColor = Color.FromArgb(64, 64, 64);
            uiLabel4.Location = new Point(2, 8);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(179, 62);
            uiLabel4.TabIndex = 0;
            uiLabel4.Tag = "1";
            uiLabel4.Text = "1000.0";
            uiLabel4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiPanel6
            // 
            uiPanel6.BackColor = Color.Transparent;
            uiPanel6.Controls.Add(minus);
            uiPanel6.Controls.Add(LabelNumber);
            uiPanel6.Controls.Add(plus);
            uiPanel6.Controls.Add(btnPageDown);
            uiPanel6.Controls.Add(btnPageUp);
            uiPanel6.Controls.Add(btnPrintReport);
            uiPanel6.Controls.Add(btnSaveReport);
            uiPanel6.FillColor = Color.White;
            uiPanel6.FillColor2 = Color.White;
            uiPanel6.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel6.ForeColor = Color.FromArgb(46, 46, 46);
            uiPanel6.Location = new Point(1547, 5);
            uiPanel6.Margin = new Padding(4, 5, 4, 5);
            uiPanel6.MinimumSize = new Size(1, 1);
            uiPanel6.Name = "uiPanel6";
            uiPanel6.Radius = 10;
            uiPanel6.RectColor = Color.White;
            uiPanel6.RectDisableColor = Color.White;
            uiPanel6.Size = new Size(209, 906);
            uiPanel6.TabIndex = 1;
            uiPanel6.Text = null;
            uiPanel6.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // minus
            // 
            minus.BackColor = Color.White;
            minus.Image = (Image)resources.GetObject("minus.Image");
            minus.Location = new Point(160, 188);
            minus.Name = "minus";
            minus.Size = new Size(32, 32);
            minus.TabIndex = 493;
            minus.TabStop = false;
            // 
            // LabelNumber
            // 
            LabelNumber.BackColor = Color.FromArgb(218, 220, 230);
            LabelNumber.DecimalPlaces = 0;
            LabelNumber.DigitalSize = 23;
            LabelNumber.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            LabelNumber.ForeColor = Color.FromArgb(46, 46, 46);
            LabelNumber.Location = new Point(55, 187);
            LabelNumber.MinimumSize = new Size(1, 1);
            LabelNumber.Name = "LabelNumber";
            LabelNumber.Size = new Size(98, 33);
            LabelNumber.TabIndex = 492;
            LabelNumber.TextAlign = HorizontalAlignment.Center;
            LabelNumber.Value = 5D;
            // 
            // plus
            // 
            plus.BackColor = Color.White;
            plus.Image = (Image)resources.GetObject("plus.Image");
            plus.Location = new Point(17, 188);
            plus.Name = "plus";
            plus.Size = new Size(32, 32);
            plus.TabIndex = 491;
            plus.TabStop = false;
            // 
            // btnPageDown
            // 
            btnPageDown.FillDisableColor = Color.FromArgb(80, 160, 255);
            btnPageDown.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            btnPageDown.ForeDisableColor = Color.White;
            btnPageDown.Location = new Point(17, 227);
            btnPageDown.MinimumSize = new Size(1, 1);
            btnPageDown.Name = "btnPageDown";
            btnPageDown.RectDisableColor = Color.FromArgb(80, 160, 255);
            btnPageDown.Size = new Size(175, 37);
            btnPageDown.Symbol = 0;
            btnPageDown.TabIndex = 490;
            btnPageDown.Text = "下翻";
            btnPageDown.TipsFont = new Font("宋体", 11F);
            btnPageDown.Click += btnPageDown_Click;
            // 
            // btnPageUp
            // 
            btnPageUp.FillDisableColor = Color.FromArgb(70, 75, 85);
            btnPageUp.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            btnPageUp.ForeDisableColor = Color.White;
            btnPageUp.Location = new Point(17, 143);
            btnPageUp.MinimumSize = new Size(1, 1);
            btnPageUp.Name = "btnPageUp";
            btnPageUp.RectDisableColor = Color.FromArgb(80, 160, 255);
            btnPageUp.Size = new Size(175, 37);
            btnPageUp.Symbol = 0;
            btnPageUp.TabIndex = 489;
            btnPageUp.Text = "上翻";
            btnPageUp.TipsFont = new Font("宋体", 11F);
            btnPageUp.Click += btnPageUp_Click;
            // 
            // btnPrintReport
            // 
            btnPrintReport.FillDisableColor = Color.FromArgb(80, 160, 255);
            btnPrintReport.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            btnPrintReport.ForeDisableColor = Color.White;
            btnPrintReport.Image = (Image)resources.GetObject("btnPrintReport.Image");
            btnPrintReport.Location = new Point(17, 671);
            btnPrintReport.MinimumSize = new Size(1, 1);
            btnPrintReport.Name = "btnPrintReport";
            btnPrintReport.RectDisableColor = Color.FromArgb(80, 160, 255);
            btnPrintReport.Size = new Size(175, 37);
            btnPrintReport.Symbol = 0;
            btnPrintReport.TabIndex = 488;
            btnPrintReport.Text = "打印报表";
            btnPrintReport.TipsFont = new Font("宋体", 11F);
            btnPrintReport.Click += btnPrintReport_Click;
            // 
            // btnSaveReport
            // 
            btnSaveReport.FillDisableColor = Color.FromArgb(80, 160, 255);
            btnSaveReport.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            btnSaveReport.ForeDisableColor = Color.White;
            btnSaveReport.Image = (Image)resources.GetObject("btnSaveReport.Image");
            btnSaveReport.Location = new Point(17, 617);
            btnSaveReport.MinimumSize = new Size(1, 1);
            btnSaveReport.Name = "btnSaveReport";
            btnSaveReport.RectDisableColor = Color.FromArgb(80, 160, 255);
            btnSaveReport.Size = new Size(175, 37);
            btnSaveReport.Symbol = 0;
            btnSaveReport.TabIndex = 487;
            btnSaveReport.Text = "保存报表";
            btnSaveReport.TipsFont = new Font("宋体", 11F);
            btnSaveReport.Click += btnSave_Click;
            // 
            // ucGrid1
            // 
            ucGrid1.Location = new Point(393, 5);
            ucGrid1.Name = "ucGrid1";
            ucGrid1.Readonly = true;
            ucGrid1.Size = new Size(1147, 896);
            ucGrid1.TabIndex = 0;
            // 
            // uiPanel5
            // 
            uiPanel5.BackColor = Color.Transparent;
            uiPanel5.Controls.Add(label5);
            uiPanel5.Controls.Add(uiLabel12);
            uiPanel5.Controls.Add(LabTemperature02);
            uiPanel5.FillColor = Color.White;
            uiPanel5.FillColor2 = Color.White;
            uiPanel5.FillDisableColor = Color.White;
            uiPanel5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel5.ForeColor = Color.Black;
            uiPanel5.ForeDisableColor = Color.Black;
            uiPanel5.Location = new Point(4, 657);
            uiPanel5.Margin = new Padding(4, 5, 4, 5);
            uiPanel5.MinimumSize = new Size(1, 1);
            uiPanel5.Name = "uiPanel5";
            uiPanel5.Radius = 30;
            uiPanel5.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel5.Size = new Size(181, 105);
            uiPanel5.TabIndex = 522;
            uiPanel5.Text = null;
            uiPanel5.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(64, 64, 64);
            label5.ForeColor = Color.FromArgb(141, 145, 145);
            label5.Location = new Point(6, 71);
            label5.Name = "label5";
            label5.Size = new Size(170, 2);
            label5.TabIndex = 495;
            label5.Text = "";
            // 
            // uiLabel12
            // 
            uiLabel12.AutoSize = true;
            uiLabel12.BackColor = Color.Transparent;
            uiLabel12.Font = new Font("宋体", 13F);
            uiLabel12.ForeColor = Color.FromArgb(64, 64, 64);
            uiLabel12.Location = new Point(4, 79);
            uiLabel12.Name = "uiLabel12";
            uiLabel12.Size = new Size(161, 18);
            uiLabel12.TabIndex = 496;
            uiLabel12.Text = "进口温度2检测(℃)";
            // 
            // LabTemperature02
            // 
            LabTemperature02.BackColor = Color.Transparent;
            LabTemperature02.Font = new Font("宋体", 35F);
            LabTemperature02.ForeColor = Color.FromArgb(64, 64, 64);
            LabTemperature02.Location = new Point(2, 8);
            LabTemperature02.Name = "LabTemperature02";
            LabTemperature02.Size = new Size(179, 62);
            LabTemperature02.TabIndex = 0;
            LabTemperature02.Tag = "1";
            LabTemperature02.Text = "1000.0";
            LabTemperature02.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiPanel7
            // 
            uiPanel7.BackColor = Color.Transparent;
            uiPanel7.Controls.Add(label6);
            uiPanel7.Controls.Add(uiLabel14);
            uiPanel7.Controls.Add(LabTemperature01);
            uiPanel7.FillColor = Color.White;
            uiPanel7.FillColor2 = Color.White;
            uiPanel7.FillDisableColor = Color.White;
            uiPanel7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel7.ForeColor = Color.Black;
            uiPanel7.ForeDisableColor = Color.Black;
            uiPanel7.Location = new Point(4, 527);
            uiPanel7.Margin = new Padding(4, 5, 4, 5);
            uiPanel7.MinimumSize = new Size(1, 1);
            uiPanel7.Name = "uiPanel7";
            uiPanel7.Radius = 30;
            uiPanel7.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel7.Size = new Size(181, 105);
            uiPanel7.TabIndex = 521;
            uiPanel7.Text = null;
            uiPanel7.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(64, 64, 64);
            label6.ForeColor = Color.FromArgb(141, 145, 145);
            label6.Location = new Point(6, 71);
            label6.Name = "label6";
            label6.Size = new Size(170, 2);
            label6.TabIndex = 495;
            label6.Text = "";
            // 
            // uiLabel14
            // 
            uiLabel14.AutoSize = true;
            uiLabel14.BackColor = Color.Transparent;
            uiLabel14.Font = new Font("宋体", 13F);
            uiLabel14.ForeColor = Color.FromArgb(64, 64, 64);
            uiLabel14.Location = new Point(6, 79);
            uiLabel14.Name = "uiLabel14";
            uiLabel14.Size = new Size(161, 18);
            uiLabel14.TabIndex = 496;
            uiLabel14.Text = "进口温度1检测(℃)";
            // 
            // LabTemperature01
            // 
            LabTemperature01.BackColor = Color.Transparent;
            LabTemperature01.Font = new Font("宋体", 35F);
            LabTemperature01.ForeColor = Color.FromArgb(64, 64, 64);
            LabTemperature01.Location = new Point(2, 8);
            LabTemperature01.Name = "LabTemperature01";
            LabTemperature01.Size = new Size(179, 62);
            LabTemperature01.TabIndex = 0;
            LabTemperature01.Tag = "1";
            LabTemperature01.Text = "1000.0";
            LabTemperature01.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiPanel8
            // 
            uiPanel8.BackColor = Color.Transparent;
            uiPanel8.Controls.Add(label7);
            uiPanel8.Controls.Add(uiLabel16);
            uiPanel8.Controls.Add(LabPressure03);
            uiPanel8.FillColor = Color.White;
            uiPanel8.FillColor2 = Color.White;
            uiPanel8.FillDisableColor = Color.White;
            uiPanel8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel8.ForeColor = Color.Black;
            uiPanel8.ForeDisableColor = Color.Black;
            uiPanel8.Location = new Point(4, 397);
            uiPanel8.Margin = new Padding(4, 5, 4, 5);
            uiPanel8.MinimumSize = new Size(1, 1);
            uiPanel8.Name = "uiPanel8";
            uiPanel8.Radius = 30;
            uiPanel8.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel8.Size = new Size(181, 105);
            uiPanel8.TabIndex = 520;
            uiPanel8.Text = null;
            uiPanel8.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(64, 64, 64);
            label7.ForeColor = Color.FromArgb(141, 145, 145);
            label7.Location = new Point(6, 71);
            label7.Name = "label7";
            label7.Size = new Size(170, 2);
            label7.TabIndex = 495;
            label7.Text = "";
            // 
            // uiLabel16
            // 
            uiLabel16.AutoSize = true;
            uiLabel16.BackColor = Color.Transparent;
            uiLabel16.Font = new Font("宋体", 13F);
            uiLabel16.ForeColor = Color.FromArgb(64, 64, 64);
            uiLabel16.Location = new Point(3, 79);
            uiLabel16.Name = "uiLabel16";
            uiLabel16.Size = new Size(161, 18);
            uiLabel16.TabIndex = 496;
            uiLabel16.Text = "计测储气压力(kPa)";
            // 
            // LabPressure03
            // 
            LabPressure03.BackColor = Color.Transparent;
            LabPressure03.Font = new Font("宋体", 35F);
            LabPressure03.ForeColor = Color.FromArgb(64, 64, 64);
            LabPressure03.Location = new Point(2, 8);
            LabPressure03.Name = "LabPressure03";
            LabPressure03.Size = new Size(179, 62);
            LabPressure03.TabIndex = 0;
            LabPressure03.Tag = "1";
            LabPressure03.Text = "1000.0";
            LabPressure03.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiPanel9
            // 
            uiPanel9.BackColor = Color.Transparent;
            uiPanel9.Controls.Add(label8);
            uiPanel9.Controls.Add(uiLabel19);
            uiPanel9.Controls.Add(LabPressure02);
            uiPanel9.FillColor = Color.White;
            uiPanel9.FillColor2 = Color.White;
            uiPanel9.FillDisableColor = Color.White;
            uiPanel9.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel9.ForeColor = Color.Black;
            uiPanel9.ForeDisableColor = Color.Black;
            uiPanel9.Location = new Point(4, 267);
            uiPanel9.Margin = new Padding(4, 5, 4, 5);
            uiPanel9.MinimumSize = new Size(1, 1);
            uiPanel9.Name = "uiPanel9";
            uiPanel9.Radius = 30;
            uiPanel9.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel9.Size = new Size(181, 105);
            uiPanel9.TabIndex = 519;
            uiPanel9.Text = null;
            uiPanel9.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(64, 64, 64);
            label8.ForeColor = Color.FromArgb(141, 145, 145);
            label8.Location = new Point(6, 71);
            label8.Name = "label8";
            label8.Size = new Size(170, 2);
            label8.TabIndex = 495;
            label8.Text = "";
            // 
            // uiLabel19
            // 
            uiLabel19.AutoSize = true;
            uiLabel19.BackColor = Color.Transparent;
            uiLabel19.Font = new Font("宋体", 13F);
            uiLabel19.ForeColor = Color.FromArgb(64, 64, 64);
            uiLabel19.Location = new Point(3, 79);
            uiLabel19.Name = "uiLabel19";
            uiLabel19.Size = new Size(161, 18);
            uiLabel19.TabIndex = 496;
            uiLabel19.Text = "负荷储气压力(kPa)";
            // 
            // LabPressure02
            // 
            LabPressure02.BackColor = Color.Transparent;
            LabPressure02.Font = new Font("宋体", 35F);
            LabPressure02.ForeColor = Color.FromArgb(64, 64, 64);
            LabPressure02.Location = new Point(2, 8);
            LabPressure02.Name = "LabPressure02";
            LabPressure02.Size = new Size(179, 62);
            LabPressure02.TabIndex = 0;
            LabPressure02.Tag = "1";
            LabPressure02.Text = "1000.0";
            LabPressure02.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiPanel10
            // 
            uiPanel10.BackColor = Color.Transparent;
            uiPanel10.Controls.Add(label9);
            uiPanel10.Controls.Add(uiLabel21);
            uiPanel10.Controls.Add(LabPressure01);
            uiPanel10.FillColor = Color.White;
            uiPanel10.FillColor2 = Color.White;
            uiPanel10.FillDisableColor = Color.White;
            uiPanel10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel10.ForeColor = Color.Black;
            uiPanel10.ForeDisableColor = Color.Black;
            uiPanel10.Location = new Point(4, 137);
            uiPanel10.Margin = new Padding(4, 5, 4, 5);
            uiPanel10.MinimumSize = new Size(1, 1);
            uiPanel10.Name = "uiPanel10";
            uiPanel10.Radius = 30;
            uiPanel10.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel10.Size = new Size(181, 105);
            uiPanel10.TabIndex = 518;
            uiPanel10.Text = null;
            uiPanel10.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(64, 64, 64);
            label9.ForeColor = Color.FromArgb(141, 145, 145);
            label9.Location = new Point(6, 71);
            label9.Name = "label9";
            label9.Size = new Size(170, 2);
            label9.TabIndex = 495;
            label9.Text = "";
            // 
            // uiLabel21
            // 
            uiLabel21.AutoSize = true;
            uiLabel21.BackColor = Color.Transparent;
            uiLabel21.Font = new Font("宋体", 13F);
            uiLabel21.ForeColor = Color.FromArgb(64, 64, 64);
            uiLabel21.Location = new Point(6, 79);
            uiLabel21.Name = "uiLabel21";
            uiLabel21.Size = new Size(161, 18);
            uiLabel21.TabIndex = 496;
            uiLabel21.Text = "泄露储气压力(kPa)";
            // 
            // LabPressure01
            // 
            LabPressure01.BackColor = Color.Transparent;
            LabPressure01.Font = new Font("宋体", 35F);
            LabPressure01.ForeColor = Color.FromArgb(64, 64, 64);
            LabPressure01.Location = new Point(2, 8);
            LabPressure01.Name = "LabPressure01";
            LabPressure01.Size = new Size(179, 62);
            LabPressure01.TabIndex = 0;
            LabPressure01.Tag = "1";
            LabPressure01.Text = "1000.0";
            LabPressure01.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiPanel2
            // 
            uiPanel2.BackColor = Color.Transparent;
            uiPanel2.Controls.Add(label2);
            uiPanel2.Controls.Add(uiPanel101);
            uiPanel2.Controls.Add(LabHJYL);
            uiPanel2.FillColor = Color.White;
            uiPanel2.FillColor2 = Color.White;
            uiPanel2.FillDisableColor = Color.White;
            uiPanel2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel2.ForeColor = Color.Black;
            uiPanel2.ForeDisableColor = Color.Black;
            uiPanel2.Location = new Point(192, 137);
            uiPanel2.Margin = new Padding(4, 5, 4, 5);
            uiPanel2.MinimumSize = new Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.Radius = 30;
            uiPanel2.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel2.Size = new Size(181, 105);
            uiPanel2.TabIndex = 515;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.ForeColor = Color.FromArgb(141, 145, 145);
            label2.Location = new Point(6, 71);
            label2.Name = "label2";
            label2.Size = new Size(170, 2);
            label2.TabIndex = 495;
            label2.Text = "";
            // 
            // uiPanel101
            // 
            uiPanel101.AutoSize = true;
            uiPanel101.BackColor = Color.Transparent;
            uiPanel101.Font = new Font("宋体", 13F);
            uiPanel101.ForeColor = Color.FromArgb(64, 64, 64);
            uiPanel101.Location = new Point(6, 79);
            uiPanel101.Name = "uiPanel101";
            uiPanel101.Size = new Size(116, 18);
            uiPanel101.TabIndex = 496;
            uiPanel101.Text = "环境压力(Pa)";
            // 
            // LabHJYL
            // 
            LabHJYL.BackColor = Color.Transparent;
            LabHJYL.Font = new Font("宋体", 35F);
            LabHJYL.ForeColor = Color.FromArgb(64, 64, 64);
            LabHJYL.Location = new Point(2, 8);
            LabHJYL.Name = "LabHJYL";
            LabHJYL.Size = new Size(179, 62);
            LabHJYL.TabIndex = 0;
            LabHJYL.Tag = "1";
            LabHJYL.Text = "1000.0";
            LabHJYL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiPanel1
            // 
            uiPanel1.BackColor = Color.Transparent;
            uiPanel1.Controls.Add(label1);
            uiPanel1.Controls.Add(uiPanel100);
            uiPanel1.Controls.Add(LabSD);
            uiPanel1.FillColor = Color.White;
            uiPanel1.FillColor2 = Color.White;
            uiPanel1.FillDisableColor = Color.White;
            uiPanel1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel1.ForeColor = Color.Black;
            uiPanel1.ForeDisableColor = Color.Black;
            uiPanel1.Location = new Point(192, 7);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Radius = 30;
            uiPanel1.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel1.Size = new Size(181, 105);
            uiPanel1.TabIndex = 514;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.ForeColor = Color.FromArgb(141, 145, 145);
            label1.Location = new Point(6, 71);
            label1.Name = "label1";
            label1.Size = new Size(170, 2);
            label1.TabIndex = 495;
            label1.Text = "";
            // 
            // uiPanel100
            // 
            uiPanel100.AutoSize = true;
            uiPanel100.BackColor = Color.Transparent;
            uiPanel100.Font = new Font("宋体", 13F);
            uiPanel100.ForeColor = Color.FromArgb(64, 64, 64);
            uiPanel100.Location = new Point(6, 79);
            uiPanel100.Name = "uiPanel100";
            uiPanel100.Size = new Size(116, 18);
            uiPanel100.TabIndex = 496;
            uiPanel100.Text = "环境温度(℃)";
            // 
            // LabSD
            // 
            LabSD.BackColor = Color.Transparent;
            LabSD.Font = new Font("宋体", 35F);
            LabSD.ForeColor = Color.FromArgb(64, 64, 64);
            LabSD.Location = new Point(2, 8);
            LabSD.Name = "LabSD";
            LabSD.Size = new Size(179, 62);
            LabSD.TabIndex = 0;
            LabSD.Tag = "1";
            LabSD.Text = "1000.0";
            LabSD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uiPanel18
            // 
            uiPanel18.BackColor = Color.Transparent;
            uiPanel18.Controls.Add(label43);
            uiPanel18.Controls.Add(uiLabel17);
            uiPanel18.Controls.Add(LabWD);
            uiPanel18.FillColor = Color.White;
            uiPanel18.FillColor2 = Color.White;
            uiPanel18.FillDisableColor = Color.White;
            uiPanel18.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiPanel18.ForeColor = Color.Black;
            uiPanel18.ForeDisableColor = Color.Black;
            uiPanel18.Location = new Point(4, 7);
            uiPanel18.Margin = new Padding(4, 5, 4, 5);
            uiPanel18.MinimumSize = new Size(1, 1);
            uiPanel18.Name = "uiPanel18";
            uiPanel18.Radius = 30;
            uiPanel18.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPanel18.Size = new Size(181, 105);
            uiPanel18.TabIndex = 513;
            uiPanel18.Text = null;
            uiPanel18.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            label43.BackColor = Color.FromArgb(64, 64, 64);
            label43.ForeColor = Color.FromArgb(141, 145, 145);
            label43.Location = new Point(6, 71);
            label43.Name = "label43";
            label43.Size = new Size(170, 2);
            label43.TabIndex = 495;
            label43.Text = "";
            // 
            // uiLabel17
            // 
            uiLabel17.AutoSize = true;
            uiLabel17.BackColor = Color.Transparent;
            uiLabel17.Font = new Font("宋体", 13F);
            uiLabel17.ForeColor = Color.FromArgb(64, 64, 64);
            uiLabel17.Location = new Point(6, 79);
            uiLabel17.Name = "uiLabel17";
            uiLabel17.Size = new Size(107, 18);
            uiLabel17.TabIndex = 496;
            uiLabel17.Text = "环境湿度(%)";
            // 
            // LabWD
            // 
            LabWD.BackColor = Color.Transparent;
            LabWD.Font = new Font("宋体", 35F);
            LabWD.ForeColor = Color.FromArgb(64, 64, 64);
            LabWD.Location = new Point(2, 8);
            LabWD.Name = "LabWD";
            LabWD.Size = new Size(179, 62);
            LabWD.TabIndex = 0;
            LabWD.Tag = "1";
            LabWD.Text = "1000.0";
            LabWD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panelChart);
            tabPage1.Location = new Point(-1747, -904);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1747, 904);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "tabPage1";
            // 
            // panelChart
            // 
            panelChart.BackColor = Color.FromArgb(236, 236, 236);
            panelChart.Controls.Add(uiTitlePanel4);
            panelChart.Controls.Add(panelHand);
            panelChart.Controls.Add(uiTitlePanel8);
            panelChart.Controls.Add(btnStopTest);
            panelChart.Controls.Add(btnStartTest);
            panelChart.Controls.Add(uiTitlePanel3);
            panelChart.Dock = DockStyle.Fill;
            panelChart.FillColor = Color.FromArgb(236, 236, 236);
            panelChart.FillColor2 = Color.FromArgb(236, 236, 236);
            panelChart.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            panelChart.Location = new Point(0, 0);
            panelChart.Margin = new Padding(4, 5, 4, 5);
            panelChart.MinimumSize = new Size(1, 1);
            panelChart.Name = "panelChart";
            panelChart.Padding = new Padding(1);
            panelChart.Radius = 0;
            panelChart.RectColor = Color.FromArgb(236, 236, 236);
            panelChart.RectDisableColor = Color.FromArgb(236, 236, 236);
            panelChart.Size = new Size(1747, 904);
            panelChart.TabIndex = 399;
            panelChart.Text = null;
            panelChart.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiTitlePanel4
            // 
            uiTitlePanel4.BackColor = Color.FromArgb(236, 236, 236);
            uiTitlePanel4.Controls.Add(uiLabel7);
            uiTitlePanel4.Controls.Add(uiLabel3);
            uiTitlePanel4.Controls.Add(uiLabel2);
            uiTitlePanel4.FillColor = Color.White;
            uiTitlePanel4.FillColor2 = Color.White;
            uiTitlePanel4.FillDisableColor = Color.White;
            uiTitlePanel4.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            uiTitlePanel4.Location = new Point(520, 171);
            uiTitlePanel4.Margin = new Padding(4, 5, 4, 5);
            uiTitlePanel4.MinimumSize = new Size(1, 1);
            uiTitlePanel4.Name = "uiTitlePanel4";
            uiTitlePanel4.Padding = new Padding(1, 29, 1, 1);
            uiTitlePanel4.Radius = 10;
            uiTitlePanel4.RectColor = Color.White;
            uiTitlePanel4.RectDisableColor = Color.White;
            uiTitlePanel4.ShowText = false;
            uiTitlePanel4.Size = new Size(131, 260);
            uiTitlePanel4.TabIndex = 497;
            uiTitlePanel4.Text = "信息录入";
            uiTitlePanel4.TextAlignment = ContentAlignment.MiddleCenter;
            uiTitlePanel4.TitleColor = Color.FromArgb(65, 100, 204);
            uiTitlePanel4.TitleHeight = 29;
            uiTitlePanel4.Visible = false;
            // 
            // uiLabel7
            // 
            uiLabel7.BackColor = Color.Transparent;
            uiLabel7.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            uiLabel7.ForeColor = Color.FromArgb(65, 100, 204);
            uiLabel7.Location = new Point(9, 188);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(91, 23);
            uiLabel7.TabIndex = 67;
            uiLabel7.Text = "车型车号:";
            uiLabel7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            uiLabel3.BackColor = Color.Transparent;
            uiLabel3.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            uiLabel3.ForeColor = Color.FromArgb(65, 100, 204);
            uiLabel3.Location = new Point(9, 141);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(91, 23);
            uiLabel3.TabIndex = 65;
            uiLabel3.Text = "车型图号:";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = Color.Transparent;
            uiLabel2.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            uiLabel2.ForeColor = Color.FromArgb(65, 100, 204);
            uiLabel2.Location = new Point(8, 92);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(91, 23);
            uiLabel2.TabIndex = 63;
            uiLabel2.Text = "车型型号:";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelHand
            // 
            panelHand.Controls.Add(RadioHand);
            panelHand.Controls.Add(RadioAuto);
            panelHand.FillColor = Color.White;
            panelHand.FillColor2 = Color.White;
            panelHand.FillDisableColor = Color.White;
            panelHand.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            panelHand.Location = new Point(513, 449);
            panelHand.Margin = new Padding(4, 5, 4, 5);
            panelHand.MinimumSize = new Size(1, 1);
            panelHand.Name = "panelHand";
            panelHand.RectColor = Color.White;
            panelHand.RectDisableColor = Color.White;
            panelHand.Size = new Size(321, 40);
            panelHand.TabIndex = 71;
            panelHand.Text = null;
            panelHand.TextAlignment = ContentAlignment.MiddleCenter;
            panelHand.Visible = false;
            // 
            // RadioHand
            // 
            RadioHand.BackColor = Color.Transparent;
            RadioHand.Font = new Font("微软雅黑", 14F);
            RadioHand.Location = new Point(23, 6);
            RadioHand.MinimumSize = new Size(1, 1);
            RadioHand.Name = "RadioHand";
            RadioHand.Size = new Size(116, 29);
            RadioHand.TabIndex = 67;
            RadioHand.Text = "手动控制";
            RadioHand.Click += RadioAuto_Click;
            // 
            // RadioAuto
            // 
            RadioAuto.BackColor = Color.Transparent;
            RadioAuto.Checked = true;
            RadioAuto.Font = new Font("微软雅黑", 14F);
            RadioAuto.Location = new Point(180, 6);
            RadioAuto.MinimumSize = new Size(1, 1);
            RadioAuto.Name = "RadioAuto";
            RadioAuto.Size = new Size(118, 29);
            RadioAuto.TabIndex = 498;
            RadioAuto.Text = "自动控制";
            RadioAuto.Click += RadioAuto_Click;
            // 
            // btnReportForms
            // 
            btnReportForms.BackActive = Color.FromArgb(196, 199, 204);
            btnReportForms.BackColor = Color.FromArgb(196, 199, 204);
            btnReportForms.BorderWidth = 1F;
            btnReportForms.Font = new Font("微软雅黑", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnReportForms.ForeColor = Color.White;
            btnReportForms.JoinMode = TJoinMode.Right;
            btnReportForms.Location = new Point(172, 0);
            btnReportForms.Name = "btnReportForms";
            btnReportForms.Size = new Size(158, 35);
            btnReportForms.TabIndex = 494;
            btnReportForms.Text = "报表界面";
            btnReportForms.Type = TTypeMini.Primary;
            btnReportForms.Visible = false;
            btnReportForms.WaveSize = 1;
            btnReportForms.Click += btnCurve_Click;
            // 
            // btnWorkmanshipForms
            // 
            btnWorkmanshipForms.BackActive = Color.FromArgb(49, 54, 64);
            btnWorkmanshipForms.BackColor = Color.White;
            btnWorkmanshipForms.BorderWidth = 1F;
            btnWorkmanshipForms.Font = new Font("微软雅黑", 14F, FontStyle.Bold);
            btnWorkmanshipForms.ForeColor = Color.Black;
            btnWorkmanshipForms.JoinMode = TJoinMode.Right;
            btnWorkmanshipForms.Location = new Point(4, 0);
            btnWorkmanshipForms.Name = "btnWorkmanshipForms";
            btnWorkmanshipForms.Size = new Size(158, 35);
            btnWorkmanshipForms.TabIndex = 493;
            btnWorkmanshipForms.Text = "工艺界面";
            btnWorkmanshipForms.Type = TTypeMini.Primary;
            btnWorkmanshipForms.WaveSize = 1;
            btnWorkmanshipForms.Click += btnTechnology_Click;
            // 
            // txtDrawingNo
            // 
            txtDrawingNo.BackColor = Color.Transparent;
            txtDrawingNo.FillColor = Color.FromArgb(218, 220, 230);
            txtDrawingNo.FillColor2 = Color.FromArgb(218, 220, 230);
            txtDrawingNo.FillDisableColor = Color.FromArgb(218, 220, 230);
            txtDrawingNo.FillReadOnlyColor = Color.FromArgb(218, 220, 230);
            txtDrawingNo.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            txtDrawingNo.Location = new Point(102, 137);
            txtDrawingNo.Margin = new Padding(4, 5, 4, 5);
            txtDrawingNo.MinimumSize = new Size(1, 16);
            txtDrawingNo.Name = "txtDrawingNo";
            txtDrawingNo.Padding = new Padding(5);
            txtDrawingNo.Radius = 15;
            txtDrawingNo.RectColor = Color.FromArgb(218, 220, 230);
            txtDrawingNo.RectDisableColor = Color.FromArgb(218, 220, 230);
            txtDrawingNo.RectReadOnlyColor = Color.FromArgb(218, 220, 230);
            txtDrawingNo.ShowText = false;
            txtDrawingNo.Size = new Size(198, 32);
            txtDrawingNo.TabIndex = 0;
            txtDrawingNo.TextAlignment = ContentAlignment.MiddleLeft;
            txtDrawingNo.Watermark = "请输入";
            // 
            // txtModel
            // 
            txtModel.BackColor = Color.Transparent;
            txtModel.FillColor = Color.FromArgb(218, 220, 230);
            txtModel.FillColor2 = Color.FromArgb(218, 220, 230);
            txtModel.FillDisableColor = Color.FromArgb(218, 220, 230);
            txtModel.FillReadOnlyColor = Color.FromArgb(218, 220, 230);
            txtModel.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            txtModel.Location = new Point(102, 90);
            txtModel.Margin = new Padding(4, 5, 4, 5);
            txtModel.MinimumSize = new Size(1, 16);
            txtModel.Name = "txtModel";
            txtModel.Padding = new Padding(5);
            txtModel.Radius = 15;
            txtModel.RectColor = Color.FromArgb(218, 220, 230);
            txtModel.RectDisableColor = Color.FromArgb(218, 220, 230);
            txtModel.RectReadOnlyColor = Color.FromArgb(218, 220, 230);
            txtModel.ShowText = false;
            txtModel.Size = new Size(198, 32);
            txtModel.TabIndex = 3;
            txtModel.TextAlignment = ContentAlignment.MiddleLeft;
            txtModel.Watermark = "请选择";
            // 
            // txtNumber
            // 
            txtNumber.BackColor = Color.Transparent;
            txtNumber.FillColor = Color.FromArgb(218, 220, 230);
            txtNumber.FillColor2 = Color.FromArgb(218, 220, 230);
            txtNumber.FillDisableColor = Color.FromArgb(218, 220, 230);
            txtNumber.FillReadOnlyColor = Color.FromArgb(218, 220, 230);
            txtNumber.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            txtNumber.Location = new Point(102, 184);
            txtNumber.Margin = new Padding(4, 5, 4, 5);
            txtNumber.MinimumSize = new Size(1, 16);
            txtNumber.Name = "txtNumber";
            txtNumber.Padding = new Padding(5);
            txtNumber.Radius = 15;
            txtNumber.RectColor = Color.FromArgb(218, 220, 230);
            txtNumber.RectDisableColor = Color.FromArgb(218, 220, 230);
            txtNumber.RectReadOnlyColor = Color.FromArgb(218, 220, 230);
            txtNumber.ShowText = false;
            txtNumber.Size = new Size(198, 32);
            txtNumber.TabIndex = 66;
            txtNumber.TextAlignment = ContentAlignment.MiddleLeft;
            txtNumber.Watermark = "请输入";
            // 
            // alert
            // 
            alert.BackColor = Color.Transparent;
            alert.Font = new Font("微软雅黑", 13F, FontStyle.Bold);
            alert.Icon = TType.Success;
            alert.Location = new Point(377, 2);
            alert.Name = "alert";
            alert.Size = new Size(1379, 33);
            alert.TabIndex = 514;
            alert.Text = "产品型号";
            alert.Visible = false;
            // 
            // UcHMI
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(236, 236, 236);
            Controls.Add(btnProductSelection);
            Controls.Add(alert);
            Controls.Add(tabs1);
            Controls.Add(btnReportForms);
            Controls.Add(btnWorkmanshipForms);
            Font = new Font("宋体", 11F);
            Margin = new Padding(4);
            Name = "UcHMI";
            Size = new Size(1759, 940);
            uiTitlePanel3.ResumeLayout(false);
            uiTitlePanel8.ResumeLayout(false);
            tabs1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            grpRainy.ResumeLayout(false);
            uiPanel11.ResumeLayout(false);
            uiPanel11.PerformLayout();
            uiPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)minus).EndInit();
            ((System.ComponentModel.ISupportInitialize)plus).EndInit();
            uiPanel5.ResumeLayout(false);
            uiPanel5.PerformLayout();
            uiPanel7.ResumeLayout(false);
            uiPanel7.PerformLayout();
            uiPanel8.ResumeLayout(false);
            uiPanel8.PerformLayout();
            uiPanel9.ResumeLayout(false);
            uiPanel9.PerformLayout();
            uiPanel10.ResumeLayout(false);
            uiPanel10.PerformLayout();
            uiPanel2.ResumeLayout(false);
            uiPanel2.PerformLayout();
            uiPanel1.ResumeLayout(false);
            uiPanel1.PerformLayout();
            uiPanel18.ResumeLayout(false);
            uiPanel18.PerformLayout();
            tabPage1.ResumeLayout(false);
            panelChart.ResumeLayout(false);
            uiTitlePanel4.ResumeLayout(false);
            panelHand.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private UITextBox uiTextBox1;
        private UITextBox uiTextBox2;
        private UITextBox uiTextBox3;
        private UITextBox uiTextBox4;
        private UITextBox uiTextBox8;
        private UITextBox uiTextBox10;
        private UITextBox uiTextBox12;
        private UITextBox uiTextBox13;
        private UITextBox uiTextBox14;
        private UITextBox uiTextBox15;
        private UITextBox uiTextBox11;
        private UITextBox uiTextBox19;
        private UIButton btnProductSelection;
        private UIButton btnStartTest;
        private UITitlePanel uiTitlePanel3;
        private UITitlePanel uiTitlePanel8;
        private UIButton btnStopTest;
        private AntdUI.Tabs tabs1;
        private AntdUI.TabPage tabPage3;
        private UIPanel panelChart;
        private AntdUI.TabPage tabPage1;
        private AntdUI.Button btnWorkmanshipForms;
        private AntdUI.Button btnReportForms;
        private UIPanel grpRainy;
        private UIPanel LabTestTime;
        private UIRadioButton RadioHand;
        private UIRadioButton RadioAuto;
        private UIPanel panelHand;
        private UIPanel uiPanel18;
        private AntdUI.Label label43;
        private UILabel uiLabel17;
        private UILabel LabWD;
        private AntdUI.Table TableItemPoint;
        private UITitlePanel uiTitlePanel4;
        private UILabel uiLabel7;
        private UILabel uiLabel3;
        private UILabel uiLabel2;
        private UITextBox txtDrawingNo;
        private UITextBox txtModel;
        private UITextBox txtNumber;
        private Alert alert;
        private UIPanel uiPanel2;
        private AntdUI.Label label2;
        private UILabel uiPanel101;
        private UILabel LabHJYL;
        private UIPanel uiPanel1;
        private AntdUI.Label label1;
        private UILabel uiPanel100;
        private UILabel LabSD;
        private UIPanel uiPanel5;
        private AntdUI.Label label5;
        private UILabel uiLabel12;
        private UILabel LabTemperature02;
        private UIPanel uiPanel7;
        private AntdUI.Label label6;
        private UILabel uiLabel14;
        private UILabel LabTemperature01;
        private UIPanel uiPanel8;
        private AntdUI.Label label7;
        private UILabel uiLabel16;
        private UILabel LabPressure03;
        private UIPanel uiPanel9;
        private AntdUI.Label label8;
        private UILabel uiLabel19;
        private UILabel LabPressure02;
        private UIPanel uiPanel10;
        private AntdUI.Label label9;
        private UILabel uiLabel21;
        private UILabel LabPressure01;
        private UIPanel uiPanel6;
        private PictureBox minus;
        private UIDigitalLabel LabelNumber;
        private PictureBox plus;
        private UISymbolButton btnPageDown;
        private UISymbolButton btnPageUp;
        private UISymbolButton btnPrintReport;
        private UISymbolButton btnSaveReport;
        private Report.UcGrid ucGrid1;
        private UIPanel uiPanel11;
        private AntdUI.Label label10;
        private UILabel uiLabel1;
        private UILabel uiLabel4;
    }
}
