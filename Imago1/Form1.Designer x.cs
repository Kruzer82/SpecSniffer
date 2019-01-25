namespace Imago1
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Tab = new MetroFramework.Controls.MetroTabControl();
            this.tabDiagnostic = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbarAudio = new MetroFramework.Controls.MetroProgressBar();
            this.panel5 = new System.Windows.Forms.Panel();
            this.micChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMain_LCD = new MetroFramework.Controls.MetroButton();
            this.btnMain_Audio = new MetroFramework.Controls.MetroButton();
            this.btnMain_Cam = new MetroFramework.Controls.MetroButton();
            this.btnMain_Mic = new MetroFramework.Controls.MetroButton();
            this.btnMain_ShowKey = new MetroFramework.Controls.MetroButton();
            this.btnMain_HDTune = new MetroFramework.Controls.MetroButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.tabDrivers = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDrivers_Install = new MetroFramework.Controls.MetroButton();
            this.btnDrivers_BIOS = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.TBDrivers_Folder = new MetroFramework.Controls.MetroTextBox();
            this.TBDrivers_Path = new MetroFramework.Controls.MetroTextBox();
            this.tabSO = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.TBSO_SO = new MetroFramework.Controls.MetroTextBox();
            this.TBSO_RP = new MetroFramework.Controls.MetroTextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.CheckB_SO = new MetroFramework.Controls.MetroCheckBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.BTNSO_AltSave = new MetroFramework.Controls.MetroButton();
            this.BTNSO_Save = new MetroFramework.Controls.MetroButton();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.CheckB_comments = new MetroFramework.Controls.MetroCheckBox();
            this.CheckB_Parts = new MetroFramework.Controls.MetroCheckBox();
            this.CheckB_Licence = new MetroFramework.Controls.MetroCheckBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.CBSO_Licence = new MetroFramework.Controls.MetroComboBox();
            this.TBSO_Comments = new MetroFramework.Controls.MetroTextBox();
            this.TBSO_Parts = new MetroFramework.Controls.MetroTextBox();
            this.TBMain_display = new MetroFramework.Controls.MetroTextBox();
            this.TBMain_diskDrives = new MetroFramework.Controls.MetroTextBox();
            this.TBMain_model = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.TBMain_sn = new MetroFramework.Controls.MetroTextBox();
            this.TBMain_ram = new MetroFramework.Controls.MetroTextBox();
            this.TBMain_optical = new MetroFramework.Controls.MetroTextBox();
            this.TBMain_gpu = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.TBMain_OSinfo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.TBMain_Lang = new MetroFramework.Controls.MetroTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.TBMain_cpu = new MetroFramework.Controls.MetroTextBox();
            this.TBMain_summarySpec = new MetroFramework.Controls.MetroTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripText1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusInternet = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripText2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusNetworkFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripText3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusUSB = new System.Windows.Forms.ToolStripStatusLabel();
            this.TBMain_cmd = new System.Windows.Forms.TextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.timerAudio = new System.Windows.Forms.Timer(this.components);
            this.timerMic = new System.Windows.Forms.Timer(this.components);
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.Tab.SuspendLayout();
            this.tabDiagnostic.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.micChart)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.tabDrivers.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabSO.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab
            // 
            this.Tab.Controls.Add(this.tabDiagnostic);
            this.Tab.Controls.Add(this.tabDrivers);
            this.Tab.Controls.Add(this.tabSO);
            this.Tab.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.Tab.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.Tab.HotTrack = true;
            this.Tab.Location = new System.Drawing.Point(-4, 39);
            this.Tab.Margin = new System.Windows.Forms.Padding(0);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(957, 665);
            this.Tab.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Tab.TabIndex = 2;
            this.Tab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Tab.UseSelectable = true;
            this.Tab.UseStyleColors = true;
            this.Tab.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // tabDiagnostic
            // 
            this.tabDiagnostic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabDiagnostic.Controls.Add(this.panel4);
            this.tabDiagnostic.Controls.Add(this.panel5);
            this.tabDiagnostic.Controls.Add(this.tableLayoutPanel3);
            this.tabDiagnostic.Controls.Add(this.panel2);
            this.tabDiagnostic.Location = new System.Drawing.Point(4, 44);
            this.tabDiagnostic.Name = "tabDiagnostic";
            this.tabDiagnostic.Padding = new System.Windows.Forms.Padding(5);
            this.tabDiagnostic.Size = new System.Drawing.Size(949, 617);
            this.tabDiagnostic.TabIndex = 0;
            this.tabDiagnostic.Text = "Diagnostic\'s [Fx]  ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel4.Controls.Add(this.pbarAudio);
            this.panel4.Location = new System.Drawing.Point(458, 451);
            this.panel4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(480, 71);
            this.panel4.TabIndex = 4;
            // 
            // pbarAudio
            // 
            this.pbarAudio.Location = new System.Drawing.Point(3, 16);
            this.pbarAudio.Name = "pbarAudio";
            this.pbarAudio.Size = new System.Drawing.Size(474, 38);
            this.pbarAudio.Style = MetroFramework.MetroColorStyle.Silver;
            this.pbarAudio.TabIndex = 0;
            this.pbarAudio.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel5.Controls.Add(this.micChart);
            this.panel5.Location = new System.Drawing.Point(458, 371);
            this.panel5.Margin = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(480, 70);
            this.panel5.TabIndex = 3;
            // 
            // micChart
            // 
            this.micChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisX2.IsLabelAutoFit = false;
            chartArea2.AxisX2.LabelStyle.Enabled = false;
            chartArea2.AxisX2.MajorGrid.Enabled = false;
            chartArea2.AxisX2.MajorTickMark.Enabled = false;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            chartArea2.Name = "ChartArea1";
            this.micChart.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Enabled = false;
            legend2.IsDockedInsideChartArea = false;
            legend2.Name = "Legend1";
            this.micChart.Legends.Add(legend2);
            this.micChart.Location = new System.Drawing.Point(0, 8);
            this.micChart.Margin = new System.Windows.Forms.Padding(0);
            this.micChart.Name = "micChart";
            series2.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Color = System.Drawing.Color.Goldenrod;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.micChart.Series.Add(series2);
            this.micChart.Size = new System.Drawing.Size(480, 62);
            this.micChart.TabIndex = 0;
            this.micChart.Text = "chart1";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.btnMain_LCD, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnMain_Audio, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnMain_Cam, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnMain_Mic, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnMain_ShowKey, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.btnMain_HDTune, 0, 5);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(820, 11);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 10, 10, 10);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(118, 360);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnMain_LCD
            // 
            this.btnMain_LCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnMain_LCD.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnMain_LCD.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnMain_LCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMain_LCD.Location = new System.Drawing.Point(0, 0);
            this.btnMain_LCD.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnMain_LCD.Name = "btnMain_LCD";
            this.btnMain_LCD.Size = new System.Drawing.Size(118, 40);
            this.btnMain_LCD.Style = MetroFramework.MetroColorStyle.Black;
            this.btnMain_LCD.TabIndex = 3;
            this.btnMain_LCD.Text = "LCD Test [F1]";
            this.btnMain_LCD.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnMain_LCD.UseCustomBackColor = true;
            this.btnMain_LCD.UseSelectable = true;
            this.btnMain_LCD.Click += new System.EventHandler(this.btnLCD_Click);
            // 
            // btnMain_Audio
            // 
            this.btnMain_Audio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnMain_Audio.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnMain_Audio.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnMain_Audio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMain_Audio.Location = new System.Drawing.Point(0, 150);
            this.btnMain_Audio.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnMain_Audio.Name = "btnMain_Audio";
            this.btnMain_Audio.Size = new System.Drawing.Size(118, 40);
            this.btnMain_Audio.Style = MetroFramework.MetroColorStyle.Black;
            this.btnMain_Audio.TabIndex = 6;
            this.btnMain_Audio.Text = "Audio [F4]";
            this.btnMain_Audio.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnMain_Audio.UseCustomBackColor = true;
            this.btnMain_Audio.UseSelectable = true;
            this.btnMain_Audio.Click += new System.EventHandler(this.btnAudio_Click);
            // 
            // btnMain_Cam
            // 
            this.btnMain_Cam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnMain_Cam.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnMain_Cam.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnMain_Cam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMain_Cam.Location = new System.Drawing.Point(0, 50);
            this.btnMain_Cam.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnMain_Cam.Name = "btnMain_Cam";
            this.btnMain_Cam.Size = new System.Drawing.Size(118, 40);
            this.btnMain_Cam.Style = MetroFramework.MetroColorStyle.Black;
            this.btnMain_Cam.TabIndex = 4;
            this.btnMain_Cam.Text = "Camera [F2]";
            this.btnMain_Cam.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnMain_Cam.UseCustomBackColor = true;
            this.btnMain_Cam.UseSelectable = true;
            this.btnMain_Cam.Click += new System.EventHandler(this.btnCam_Click);
            // 
            // btnMain_Mic
            // 
            this.btnMain_Mic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnMain_Mic.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnMain_Mic.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnMain_Mic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMain_Mic.Location = new System.Drawing.Point(0, 100);
            this.btnMain_Mic.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnMain_Mic.Name = "btnMain_Mic";
            this.btnMain_Mic.Size = new System.Drawing.Size(118, 40);
            this.btnMain_Mic.Style = MetroFramework.MetroColorStyle.Black;
            this.btnMain_Mic.TabIndex = 5;
            this.btnMain_Mic.Text = "Microphone [F3]";
            this.btnMain_Mic.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnMain_Mic.UseCustomBackColor = true;
            this.btnMain_Mic.UseSelectable = true;
            this.btnMain_Mic.Click += new System.EventHandler(this.btnMic_Click);
            // 
            // btnMain_ShowKey
            // 
            this.btnMain_ShowKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnMain_ShowKey.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnMain_ShowKey.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnMain_ShowKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMain_ShowKey.Location = new System.Drawing.Point(0, 310);
            this.btnMain_ShowKey.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnMain_ShowKey.Name = "btnMain_ShowKey";
            this.btnMain_ShowKey.Size = new System.Drawing.Size(118, 40);
            this.btnMain_ShowKey.Style = MetroFramework.MetroColorStyle.Black;
            this.btnMain_ShowKey.TabIndex = 8;
            this.btnMain_ShowKey.Text = "ShowKey";
            this.btnMain_ShowKey.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnMain_ShowKey.UseCustomBackColor = true;
            this.btnMain_ShowKey.UseSelectable = true;
            this.btnMain_ShowKey.Click += new System.EventHandler(this.btnShowKey_Click);
            // 
            // btnMain_HDTune
            // 
            this.btnMain_HDTune.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnMain_HDTune.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnMain_HDTune.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnMain_HDTune.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMain_HDTune.Location = new System.Drawing.Point(0, 260);
            this.btnMain_HDTune.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnMain_HDTune.Name = "btnMain_HDTune";
            this.btnMain_HDTune.Size = new System.Drawing.Size(118, 40);
            this.btnMain_HDTune.Style = MetroFramework.MetroColorStyle.Black;
            this.btnMain_HDTune.TabIndex = 7;
            this.btnMain_HDTune.Text = "HDTune [F5]";
            this.btnMain_HDTune.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnMain_HDTune.UseCustomBackColor = true;
            this.btnMain_HDTune.UseSelectable = true;
            this.btnMain_HDTune.Click += new System.EventHandler(this.btnHDTune_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Controls.Add(this.imageBox1);
            this.panel2.Location = new System.Drawing.Point(458, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 350);
            this.panel2.TabIndex = 0;
            // 
            // imageBox1
            // 
            this.imageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox1.Location = new System.Drawing.Point(0, 0);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(350, 350);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // tabDrivers
            // 
            this.tabDrivers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabDrivers.Controls.Add(this.panel8);
            this.tabDrivers.Controls.Add(this.tableLayoutPanel6);
            this.tabDrivers.Controls.Add(this.tableLayoutPanel5);
            this.tabDrivers.Location = new System.Drawing.Point(4, 44);
            this.tabDrivers.Name = "tabDrivers";
            this.tabDrivers.Size = new System.Drawing.Size(949, 617);
            this.tabDrivers.TabIndex = 1;
            this.tabDrivers.Text = "Driver\'s [F6]  ";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.metroLabel20);
            this.panel8.Location = new System.Drawing.Point(458, 6);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(480, 40);
            this.panel8.TabIndex = 100;
            // 
            // metroLabel20
            // 
            this.metroLabel20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel20.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel20.Location = new System.Drawing.Point(-3, 3);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(157, 25);
            this.metroLabel20.TabIndex = 13;
            this.metroLabel20.Text = "Driver\'s Installation:";
            this.metroLabel20.UseCustomBackColor = true;
            this.metroLabel20.UseCustomForeColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 453F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel6.Controls.Add(this.btnDrivers_Install, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnDrivers_BIOS, 3, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(650, 130);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(288, 50);
            this.tableLayoutPanel6.TabIndex = 99;
            // 
            // btnDrivers_Install
            // 
            this.btnDrivers_Install.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnDrivers_Install.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDrivers_Install.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDrivers_Install.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDrivers_Install.Location = new System.Drawing.Point(14, 5);
            this.btnDrivers_Install.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnDrivers_Install.Name = "btnDrivers_Install";
            this.btnDrivers_Install.Size = new System.Drawing.Size(132, 40);
            this.btnDrivers_Install.Style = MetroFramework.MetroColorStyle.Black;
            this.btnDrivers_Install.TabIndex = 2;
            this.btnDrivers_Install.Text = "Install Driver\'s [Del]";
            this.btnDrivers_Install.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDrivers_Install.UseCustomBackColor = true;
            this.btnDrivers_Install.UseSelectable = true;
            this.btnDrivers_Install.Click += new System.EventHandler(this.btnDrivers_Install_Click);
            // 
            // btnDrivers_BIOS
            // 
            this.btnDrivers_BIOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnDrivers_BIOS.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDrivers_BIOS.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnDrivers_BIOS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDrivers_BIOS.Location = new System.Drawing.Point(156, 5);
            this.btnDrivers_BIOS.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnDrivers_BIOS.Name = "btnDrivers_BIOS";
            this.btnDrivers_BIOS.Size = new System.Drawing.Size(132, 40);
            this.btnDrivers_BIOS.Style = MetroFramework.MetroColorStyle.Black;
            this.btnDrivers_BIOS.TabIndex = 4;
            this.btnDrivers_BIOS.Text = "BIOS Flash [End]";
            this.btnDrivers_BIOS.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDrivers_BIOS.UseCustomBackColor = true;
            this.btnDrivers_BIOS.UseSelectable = true;
            this.btnDrivers_BIOS.Click += new System.EventHandler(this.btnDrivers_BIOS_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 383F));
            this.tableLayoutPanel5.Controls.Add(this.metroLabel11, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.metroLabel10, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.TBDrivers_Folder, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.TBDrivers_Path, 1, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(458, 47);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(480, 80);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // metroLabel11
            // 
            this.metroLabel11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel11.Location = new System.Drawing.Point(3, 50);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(91, 19);
            this.metroLabel11.TabIndex = 10;
            this.metroLabel11.Text = "Path To Open:";
            this.metroLabel11.UseCustomBackColor = true;
            this.metroLabel11.UseCustomForeColor = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel10.Location = new System.Drawing.Point(4, 10);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(90, 19);
            this.metroLabel10.TabIndex = 1;
            this.metroLabel10.Text = "Folder Name:";
            this.metroLabel10.UseCustomBackColor = true;
            this.metroLabel10.UseCustomForeColor = true;
            // 
            // TBDrivers_Folder
            // 
            this.TBDrivers_Folder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TBDrivers_Folder.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            // 
            // 
            // 
            this.TBDrivers_Folder.CustomButton.Image = null;
            this.TBDrivers_Folder.CustomButton.Location = new System.Drawing.Point(355, 2);
            this.TBDrivers_Folder.CustomButton.Name = "";
            this.TBDrivers_Folder.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBDrivers_Folder.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBDrivers_Folder.CustomButton.TabIndex = 1;
            this.TBDrivers_Folder.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBDrivers_Folder.CustomButton.UseSelectable = true;
            this.TBDrivers_Folder.CustomButton.Visible = false;
            this.TBDrivers_Folder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBDrivers_Folder.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBDrivers_Folder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBDrivers_Folder.Lines = new string[0];
            this.TBDrivers_Folder.Location = new System.Drawing.Point(97, 5);
            this.TBDrivers_Folder.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TBDrivers_Folder.MaxLength = 32767;
            this.TBDrivers_Folder.Name = "TBDrivers_Folder";
            this.TBDrivers_Folder.PasswordChar = '\0';
            this.TBDrivers_Folder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBDrivers_Folder.SelectedText = "";
            this.TBDrivers_Folder.SelectionLength = 0;
            this.TBDrivers_Folder.SelectionStart = 0;
            this.TBDrivers_Folder.ShortcutsEnabled = true;
            this.TBDrivers_Folder.Size = new System.Drawing.Size(383, 30);
            this.TBDrivers_Folder.Style = MetroFramework.MetroColorStyle.Silver;
            this.TBDrivers_Folder.TabIndex = 0;
            this.TBDrivers_Folder.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBDrivers_Folder.UseCustomBackColor = true;
            this.TBDrivers_Folder.UseSelectable = true;
            this.TBDrivers_Folder.UseStyleColors = true;
            this.TBDrivers_Folder.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBDrivers_Folder.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TBDrivers_Folder.TextChanged += new System.EventHandler(this.TBDrivers_Folder_TextChanged);
            // 
            // TBDrivers_Path
            // 
            this.TBDrivers_Path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TBDrivers_Path.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            // 
            // 
            // 
            this.TBDrivers_Path.CustomButton.Image = null;
            this.TBDrivers_Path.CustomButton.Location = new System.Drawing.Point(355, 2);
            this.TBDrivers_Path.CustomButton.Name = "";
            this.TBDrivers_Path.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBDrivers_Path.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBDrivers_Path.CustomButton.TabIndex = 1;
            this.TBDrivers_Path.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBDrivers_Path.CustomButton.UseSelectable = true;
            this.TBDrivers_Path.CustomButton.Visible = false;
            this.TBDrivers_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBDrivers_Path.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBDrivers_Path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBDrivers_Path.Lines = new string[0];
            this.TBDrivers_Path.Location = new System.Drawing.Point(97, 45);
            this.TBDrivers_Path.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TBDrivers_Path.MaxLength = 32767;
            this.TBDrivers_Path.Name = "TBDrivers_Path";
            this.TBDrivers_Path.PasswordChar = '\0';
            this.TBDrivers_Path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBDrivers_Path.SelectedText = "";
            this.TBDrivers_Path.SelectionLength = 0;
            this.TBDrivers_Path.SelectionStart = 0;
            this.TBDrivers_Path.ShortcutsEnabled = true;
            this.TBDrivers_Path.Size = new System.Drawing.Size(383, 30);
            this.TBDrivers_Path.Style = MetroFramework.MetroColorStyle.Black;
            this.TBDrivers_Path.TabIndex = 1;
            this.TBDrivers_Path.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBDrivers_Path.UseCustomBackColor = true;
            this.TBDrivers_Path.UseSelectable = true;
            this.TBDrivers_Path.UseStyleColors = true;
            this.TBDrivers_Path.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBDrivers_Path.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tabSO
            // 
            this.tabSO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabSO.Controls.Add(this.tableLayoutPanel7);
            this.tabSO.Controls.Add(this.panel7);
            this.tabSO.Controls.Add(this.CheckB_SO);
            this.tabSO.Controls.Add(this.tableLayoutPanel9);
            this.tabSO.Controls.Add(this.CheckB_comments);
            this.tabSO.Controls.Add(this.CheckB_Parts);
            this.tabSO.Controls.Add(this.CheckB_Licence);
            this.tabSO.Controls.Add(this.tableLayoutPanel8);
            this.tabSO.Location = new System.Drawing.Point(4, 44);
            this.tabSO.Name = "tabSO";
            this.tabSO.Size = new System.Drawing.Size(949, 617);
            this.tabSO.TabIndex = 2;
            this.tabSO.Text = "Save Spec. [F7]  ";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 7;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.metroLabel12, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.metroLabel13, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.TBSO_SO, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.TBSO_RP, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(698, 8);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(220, 40);
            this.tableLayoutPanel7.TabIndex = 0;
            this.tableLayoutPanel7.TabStop = true;
            // 
            // metroLabel12
            // 
            this.metroLabel12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel12.Location = new System.Drawing.Point(126, 10);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(30, 19);
            this.metroLabel12.TabIndex = 1;
            this.metroLabel12.Text = "SO:";
            this.metroLabel12.UseCustomBackColor = true;
            this.metroLabel12.UseCustomForeColor = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel13.Location = new System.Drawing.Point(9, 10);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(28, 19);
            this.metroLabel13.TabIndex = 10;
            this.metroLabel13.Text = "RP:";
            this.metroLabel13.UseCustomBackColor = true;
            this.metroLabel13.UseCustomForeColor = true;
            // 
            // TBSO_SO
            // 
            this.TBSO_SO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TBSO_SO.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            // 
            // 
            // 
            this.TBSO_SO.CustomButton.Image = null;
            this.TBSO_SO.CustomButton.Location = new System.Drawing.Point(33, 2);
            this.TBSO_SO.CustomButton.Name = "";
            this.TBSO_SO.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBSO_SO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBSO_SO.CustomButton.TabIndex = 1;
            this.TBSO_SO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBSO_SO.CustomButton.UseSelectable = true;
            this.TBSO_SO.CustomButton.Visible = false;
            this.TBSO_SO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBSO_SO.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBSO_SO.ForeColor = System.Drawing.Color.DimGray;
            this.TBSO_SO.Lines = new string[0];
            this.TBSO_SO.Location = new System.Drawing.Point(159, 5);
            this.TBSO_SO.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TBSO_SO.MaxLength = 5;
            this.TBSO_SO.Name = "TBSO_SO";
            this.TBSO_SO.PasswordChar = '\0';
            this.TBSO_SO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBSO_SO.SelectedText = "";
            this.TBSO_SO.SelectionLength = 0;
            this.TBSO_SO.SelectionStart = 0;
            this.TBSO_SO.ShortcutsEnabled = true;
            this.TBSO_SO.Size = new System.Drawing.Size(61, 30);
            this.TBSO_SO.Style = MetroFramework.MetroColorStyle.Black;
            this.TBSO_SO.TabIndex = 1;
            this.TBSO_SO.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBSO_SO.UseCustomBackColor = true;
            this.TBSO_SO.UseCustomForeColor = true;
            this.TBSO_SO.UseSelectable = true;
            this.TBSO_SO.UseStyleColors = true;
            this.TBSO_SO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBSO_SO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TBSO_SO.Enter += new System.EventHandler(this.TBSO_SO_Enter);
            // 
            // TBSO_RP
            // 
            this.TBSO_RP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TBSO_RP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            // 
            // 
            // 
            this.TBSO_RP.CustomButton.Image = null;
            this.TBSO_RP.CustomButton.Location = new System.Drawing.Point(32, 2);
            this.TBSO_RP.CustomButton.Name = "";
            this.TBSO_RP.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBSO_RP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBSO_RP.CustomButton.TabIndex = 1;
            this.TBSO_RP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBSO_RP.CustomButton.UseSelectable = true;
            this.TBSO_RP.CustomButton.Visible = false;
            this.TBSO_RP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBSO_RP.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBSO_RP.ForeColor = System.Drawing.Color.DimGray;
            this.TBSO_RP.Lines = new string[0];
            this.TBSO_RP.Location = new System.Drawing.Point(40, 5);
            this.TBSO_RP.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TBSO_RP.MaxLength = 4;
            this.TBSO_RP.Name = "TBSO_RP";
            this.TBSO_RP.PasswordChar = '\0';
            this.TBSO_RP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBSO_RP.SelectedText = "";
            this.TBSO_RP.SelectionLength = 0;
            this.TBSO_RP.SelectionStart = 0;
            this.TBSO_RP.ShortcutsEnabled = true;
            this.TBSO_RP.Size = new System.Drawing.Size(60, 30);
            this.TBSO_RP.Style = MetroFramework.MetroColorStyle.Black;
            this.TBSO_RP.TabIndex = 0;
            this.TBSO_RP.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBSO_RP.UseCustomBackColor = true;
            this.TBSO_RP.UseCustomForeColor = true;
            this.TBSO_RP.UseSelectable = true;
            this.TBSO_RP.UseStyleColors = true;
            this.TBSO_RP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBSO_RP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TBSO_RP.Enter += new System.EventHandler(this.TBSO_RP_Enter);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.metroLabel19);
            this.panel7.Location = new System.Drawing.Point(456, 7);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(462, 40);
            this.panel7.TabIndex = 12;
            // 
            // metroLabel19
            // 
            this.metroLabel19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel19.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel19.Location = new System.Drawing.Point(-3, 3);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(147, 25);
            this.metroLabel19.TabIndex = 13;
            this.metroLabel19.Text = "Save Specification";
            this.metroLabel19.UseCustomBackColor = true;
            this.metroLabel19.UseCustomForeColor = true;
            // 
            // CheckB_SO
            // 
            this.CheckB_SO.AutoSize = true;
            this.CheckB_SO.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.CheckB_SO.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.CheckB_SO.Location = new System.Drawing.Point(921, 8);
            this.CheckB_SO.Name = "CheckB_SO";
            this.CheckB_SO.Size = new System.Drawing.Size(33, 25);
            this.CheckB_SO.Style = MetroFramework.MetroColorStyle.Yellow;
            this.CheckB_SO.TabIndex = 7;
            this.CheckB_SO.Text = " ";
            this.CheckB_SO.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CheckB_SO.UseCustomBackColor = true;
            this.CheckB_SO.UseSelectable = true;
            this.CheckB_SO.UseStyleColors = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.21212F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.78788F));
            this.tableLayoutPanel9.Controls.Add(this.BTNSO_AltSave, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.BTNSO_Save, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.metroLabel15, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.metroLabel14, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(456, 333);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 4;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(462, 100);
            this.tableLayoutPanel9.TabIndex = 10;
            // 
            // BTNSO_AltSave
            // 
            this.BTNSO_AltSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BTNSO_AltSave.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BTNSO_AltSave.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.BTNSO_AltSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BTNSO_AltSave.Location = new System.Drawing.Point(328, 50);
            this.BTNSO_AltSave.Margin = new System.Windows.Forms.Padding(0);
            this.BTNSO_AltSave.Name = "BTNSO_AltSave";
            this.BTNSO_AltSave.Size = new System.Drawing.Size(132, 40);
            this.BTNSO_AltSave.Style = MetroFramework.MetroColorStyle.Black;
            this.BTNSO_AltSave.TabIndex = 6;
            this.BTNSO_AltSave.Text = "USB [End]";
            this.BTNSO_AltSave.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.BTNSO_AltSave.UseSelectable = true;
            this.BTNSO_AltSave.Click += new System.EventHandler(this.BTNSO_AltSave_Click);
            // 
            // BTNSO_Save
            // 
            this.BTNSO_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BTNSO_Save.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.BTNSO_Save.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.BTNSO_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BTNSO_Save.Location = new System.Drawing.Point(328, 0);
            this.BTNSO_Save.Margin = new System.Windows.Forms.Padding(0);
            this.BTNSO_Save.Name = "BTNSO_Save";
            this.BTNSO_Save.Size = new System.Drawing.Size(132, 40);
            this.BTNSO_Save.Style = MetroFramework.MetroColorStyle.Black;
            this.BTNSO_Save.TabIndex = 5;
            this.BTNSO_Save.Text = "Server [Del]";
            this.BTNSO_Save.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.BTNSO_Save.UseSelectable = true;
            this.BTNSO_Save.Click += new System.EventHandler(this.BTNSO_Save_Click);
            // 
            // metroLabel15
            // 
            this.metroLabel15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel15.Location = new System.Drawing.Point(216, 60);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(109, 19);
            this.metroLabel15.TabIndex = 12;
            this.metroLabel15.Text = "Save log on USB:";
            this.metroLabel15.UseCustomBackColor = true;
            this.metroLabel15.UseCustomForeColor = true;
            // 
            // metroLabel14
            // 
            this.metroLabel14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel14.Location = new System.Drawing.Point(203, 10);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(122, 19);
            this.metroLabel14.TabIndex = 2;
            this.metroLabel14.Text = "Save log on server:";
            this.metroLabel14.UseCustomBackColor = true;
            this.metroLabel14.UseCustomForeColor = true;
            // 
            // CheckB_comments
            // 
            this.CheckB_comments.AutoSize = true;
            this.CheckB_comments.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.CheckB_comments.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.CheckB_comments.Location = new System.Drawing.Point(922, 246);
            this.CheckB_comments.Name = "CheckB_comments";
            this.CheckB_comments.Size = new System.Drawing.Size(33, 25);
            this.CheckB_comments.Style = MetroFramework.MetroColorStyle.Yellow;
            this.CheckB_comments.TabIndex = 10;
            this.CheckB_comments.Text = " ";
            this.CheckB_comments.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CheckB_comments.UseCustomBackColor = true;
            this.CheckB_comments.UseSelectable = true;
            this.CheckB_comments.UseStyleColors = true;
            // 
            // CheckB_Parts
            // 
            this.CheckB_Parts.AutoSize = true;
            this.CheckB_Parts.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.CheckB_Parts.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.CheckB_Parts.Location = new System.Drawing.Point(922, 126);
            this.CheckB_Parts.Name = "CheckB_Parts";
            this.CheckB_Parts.Size = new System.Drawing.Size(33, 25);
            this.CheckB_Parts.Style = MetroFramework.MetroColorStyle.Yellow;
            this.CheckB_Parts.TabIndex = 9;
            this.CheckB_Parts.Text = " ";
            this.CheckB_Parts.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CheckB_Parts.UseCustomBackColor = true;
            this.CheckB_Parts.UseSelectable = true;
            this.CheckB_Parts.UseStyleColors = true;
            // 
            // CheckB_Licence
            // 
            this.CheckB_Licence.AutoSize = true;
            this.CheckB_Licence.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.CheckB_Licence.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.CheckB_Licence.Location = new System.Drawing.Point(922, 46);
            this.CheckB_Licence.Name = "CheckB_Licence";
            this.CheckB_Licence.Size = new System.Drawing.Size(33, 25);
            this.CheckB_Licence.Style = MetroFramework.MetroColorStyle.Yellow;
            this.CheckB_Licence.TabIndex = 8;
            this.CheckB_Licence.Text = " ";
            this.CheckB_Licence.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CheckB_Licence.UseCustomBackColor = true;
            this.CheckB_Licence.UseSelectable = true;
            this.CheckB_Licence.UseStyleColors = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 552F));
            this.tableLayoutPanel8.Controls.Add(this.metroLabel18, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.metroLabel17, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.CBSO_Licence, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.TBSO_Comments, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.TBSO_Parts, 0, 2);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(458, 47);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 5;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(460, 285);
            this.tableLayoutPanel8.TabIndex = 1;
            this.tableLayoutPanel8.TabStop = true;
            // 
            // metroLabel18
            // 
            this.metroLabel18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel18.Location = new System.Drawing.Point(3, 50);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(296, 19);
            this.metroLabel18.TabIndex = 13;
            this.metroLabel18.Text = "Parts to add in IQReseller. Separate with new line:";
            this.metroLabel18.UseCustomBackColor = true;
            this.metroLabel18.UseCustomForeColor = true;
            // 
            // metroLabel17
            // 
            this.metroLabel17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel17.Location = new System.Drawing.Point(3, 170);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(78, 19);
            this.metroLabel17.TabIndex = 12;
            this.metroLabel17.Text = "Comment\'s:";
            this.metroLabel17.UseCustomBackColor = true;
            this.metroLabel17.UseCustomForeColor = true;
            // 
            // CBSO_Licence
            // 
            this.CBSO_Licence.AllowDrop = true;
            this.CBSO_Licence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.CBSO_Licence.DisplayFocus = true;
            this.CBSO_Licence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBSO_Licence.ForeColor = System.Drawing.Color.Gainsboro;
            this.CBSO_Licence.ItemHeight = 23;
            this.CBSO_Licence.Items.AddRange(new object[] {
            "Win 10 Pro CMAR",
            "Win 10 Home CMAR",
            "Win 10 RRPC",
            "Win 7 Pro COA",
            "Win 7 Home Premium COA",
            "Win 8 OEM",
            "Win 10 OEM",
            "NO COA"});
            this.CBSO_Licence.Location = new System.Drawing.Point(0, 5);
            this.CBSO_Licence.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.CBSO_Licence.Name = "CBSO_Licence";
            this.CBSO_Licence.PromptText = "Valid licence shipped with product.";
            this.CBSO_Licence.Size = new System.Drawing.Size(460, 29);
            this.CBSO_Licence.Style = MetroFramework.MetroColorStyle.Black;
            this.CBSO_Licence.TabIndex = 2;
            this.CBSO_Licence.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CBSO_Licence.UseCustomBackColor = true;
            this.CBSO_Licence.UseCustomForeColor = true;
            this.CBSO_Licence.UseSelectable = true;
            this.CBSO_Licence.UseStyleColors = true;
            // 
            // TBSO_Comments
            // 
            this.TBSO_Comments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TBSO_Comments.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            // 
            // 
            // 
            this.TBSO_Comments.CustomButton.Image = null;
            this.TBSO_Comments.CustomButton.Location = new System.Drawing.Point(390, 1);
            this.TBSO_Comments.CustomButton.Name = "";
            this.TBSO_Comments.CustomButton.Size = new System.Drawing.Size(69, 69);
            this.TBSO_Comments.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBSO_Comments.CustomButton.TabIndex = 1;
            this.TBSO_Comments.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBSO_Comments.CustomButton.UseSelectable = true;
            this.TBSO_Comments.CustomButton.Visible = false;
            this.TBSO_Comments.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBSO_Comments.ForeColor = System.Drawing.Color.DimGray;
            this.TBSO_Comments.Lines = new string[0];
            this.TBSO_Comments.Location = new System.Drawing.Point(0, 205);
            this.TBSO_Comments.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TBSO_Comments.MaxLength = 32767;
            this.TBSO_Comments.Multiline = true;
            this.TBSO_Comments.Name = "TBSO_Comments";
            this.TBSO_Comments.PasswordChar = '\0';
            this.TBSO_Comments.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBSO_Comments.SelectedText = "";
            this.TBSO_Comments.SelectionLength = 0;
            this.TBSO_Comments.SelectionStart = 0;
            this.TBSO_Comments.ShortcutsEnabled = true;
            this.TBSO_Comments.Size = new System.Drawing.Size(460, 71);
            this.TBSO_Comments.Style = MetroFramework.MetroColorStyle.Black;
            this.TBSO_Comments.TabIndex = 4;
            this.TBSO_Comments.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBSO_Comments.UseCustomBackColor = true;
            this.TBSO_Comments.UseCustomForeColor = true;
            this.TBSO_Comments.UseSelectable = true;
            this.TBSO_Comments.UseStyleColors = true;
            this.TBSO_Comments.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBSO_Comments.WaterMarkFont = new System.Drawing.Font("Segoe UI Light", 12F);
            this.TBSO_Comments.Enter += new System.EventHandler(this.TBSO_Comments_Enter);
            // 
            // TBSO_Parts
            // 
            this.TBSO_Parts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TBSO_Parts.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            // 
            // 
            // 
            this.TBSO_Parts.CustomButton.Image = null;
            this.TBSO_Parts.CustomButton.Location = new System.Drawing.Point(392, 1);
            this.TBSO_Parts.CustomButton.Name = "";
            this.TBSO_Parts.CustomButton.Size = new System.Drawing.Size(67, 67);
            this.TBSO_Parts.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBSO_Parts.CustomButton.TabIndex = 1;
            this.TBSO_Parts.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBSO_Parts.CustomButton.UseSelectable = true;
            this.TBSO_Parts.CustomButton.Visible = false;
            this.TBSO_Parts.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBSO_Parts.ForeColor = System.Drawing.Color.DimGray;
            this.TBSO_Parts.Lines = new string[0];
            this.TBSO_Parts.Location = new System.Drawing.Point(0, 85);
            this.TBSO_Parts.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TBSO_Parts.MaxLength = 32767;
            this.TBSO_Parts.Multiline = true;
            this.TBSO_Parts.Name = "TBSO_Parts";
            this.TBSO_Parts.PasswordChar = '\0';
            this.TBSO_Parts.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBSO_Parts.SelectedText = "";
            this.TBSO_Parts.SelectionLength = 0;
            this.TBSO_Parts.SelectionStart = 0;
            this.TBSO_Parts.ShortcutsEnabled = true;
            this.TBSO_Parts.Size = new System.Drawing.Size(460, 69);
            this.TBSO_Parts.Style = MetroFramework.MetroColorStyle.Black;
            this.TBSO_Parts.TabIndex = 3;
            this.TBSO_Parts.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBSO_Parts.UseCustomBackColor = true;
            this.TBSO_Parts.UseCustomForeColor = true;
            this.TBSO_Parts.UseSelectable = true;
            this.TBSO_Parts.UseStyleColors = true;
            this.TBSO_Parts.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBSO_Parts.WaterMarkFont = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TBSO_Parts.Enter += new System.EventHandler(this.TBSO_Parts_Enter);
            // 
            // TBMain_display
            // 
            this.TBMain_display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_display.CustomButton.Image = null;
            this.TBMain_display.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.TBMain_display.CustomButton.Name = "";
            this.TBMain_display.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBMain_display.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_display.CustomButton.TabIndex = 1;
            this.TBMain_display.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_display.CustomButton.UseSelectable = true;
            this.TBMain_display.CustomButton.Visible = false;
            this.TBMain_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_display.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_display.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_display.Lines = new string[0];
            this.TBMain_display.Location = new System.Drawing.Point(64, 325);
            this.TBMain_display.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_display.MaxLength = 32767;
            this.TBMain_display.Name = "TBMain_display";
            this.TBMain_display.PasswordChar = '\0';
            this.TBMain_display.ReadOnly = true;
            this.TBMain_display.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_display.SelectedText = "";
            this.TBMain_display.SelectionLength = 0;
            this.TBMain_display.SelectionStart = 0;
            this.TBMain_display.ShortcutsEnabled = true;
            this.TBMain_display.Size = new System.Drawing.Size(366, 30);
            this.TBMain_display.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_display.TabIndex = 15;
            this.TBMain_display.TabStop = false;
            this.TBMain_display.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_display.UseCustomBackColor = true;
            this.TBMain_display.UseSelectable = true;
            this.TBMain_display.UseStyleColors = true;
            this.TBMain_display.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_display.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TBMain_diskDrives
            // 
            this.TBMain_diskDrives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_diskDrives.CustomButton.Image = null;
            this.TBMain_diskDrives.CustomButton.Location = new System.Drawing.Point(318, 2);
            this.TBMain_diskDrives.CustomButton.Name = "";
            this.TBMain_diskDrives.CustomButton.Size = new System.Drawing.Size(45, 45);
            this.TBMain_diskDrives.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_diskDrives.CustomButton.TabIndex = 1;
            this.TBMain_diskDrives.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_diskDrives.CustomButton.UseSelectable = true;
            this.TBMain_diskDrives.CustomButton.Visible = false;
            this.TBMain_diskDrives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_diskDrives.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_diskDrives.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_diskDrives.Lines = new string[0];
            this.TBMain_diskDrives.Location = new System.Drawing.Point(64, 205);
            this.TBMain_diskDrives.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_diskDrives.MaxLength = 32767;
            this.TBMain_diskDrives.Multiline = true;
            this.TBMain_diskDrives.Name = "TBMain_diskDrives";
            this.TBMain_diskDrives.PasswordChar = '\0';
            this.TBMain_diskDrives.ReadOnly = true;
            this.TBMain_diskDrives.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_diskDrives.SelectedText = "";
            this.TBMain_diskDrives.SelectionLength = 0;
            this.TBMain_diskDrives.SelectionStart = 0;
            this.TBMain_diskDrives.ShortcutsEnabled = true;
            this.TBMain_diskDrives.Size = new System.Drawing.Size(366, 50);
            this.TBMain_diskDrives.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_diskDrives.TabIndex = 12;
            this.TBMain_diskDrives.TabStop = false;
            this.TBMain_diskDrives.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_diskDrives.UseCustomBackColor = true;
            this.TBMain_diskDrives.UseSelectable = true;
            this.TBMain_diskDrives.UseStyleColors = true;
            this.TBMain_diskDrives.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_diskDrives.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TBMain_model
            // 
            this.TBMain_model.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_model.CustomButton.Image = null;
            this.TBMain_model.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.TBMain_model.CustomButton.Name = "";
            this.TBMain_model.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBMain_model.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_model.CustomButton.TabIndex = 1;
            this.TBMain_model.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_model.CustomButton.UseSelectable = true;
            this.TBMain_model.CustomButton.Visible = false;
            this.TBMain_model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_model.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_model.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_model.Lines = new string[0];
            this.TBMain_model.Location = new System.Drawing.Point(64, 5);
            this.TBMain_model.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_model.MaxLength = 32767;
            this.TBMain_model.Name = "TBMain_model";
            this.TBMain_model.PasswordChar = '\0';
            this.TBMain_model.ReadOnly = true;
            this.TBMain_model.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_model.SelectedText = "";
            this.TBMain_model.SelectionLength = 0;
            this.TBMain_model.SelectionStart = 0;
            this.TBMain_model.ShortcutsEnabled = true;
            this.TBMain_model.Size = new System.Drawing.Size(366, 30);
            this.TBMain_model.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_model.TabIndex = 8;
            this.TBMain_model.TabStop = false;
            this.TBMain_model.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_model.UseCustomBackColor = true;
            this.TBMain_model.UseSelectable = true;
            this.TBMain_model.UseStyleColors = true;
            this.TBMain_model.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_model.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel6.Location = new System.Drawing.Point(16, 280);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(45, 19);
            this.metroLabel6.TabIndex = 5;
            this.metroLabel6.Text = "GPU\'s:";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel6.UseCustomBackColor = true;
            this.metroLabel6.UseCustomForeColor = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel5.Location = new System.Drawing.Point(13, 211);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(48, 38);
            this.metroLabel5.TabIndex = 4;
            this.metroLabel5.Text = "Disk\r\nDrive\'s:";
            this.metroLabel5.UseCustomBackColor = true;
            this.metroLabel5.UseCustomForeColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel4.Location = new System.Drawing.Point(7, 170);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(54, 19);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "Optical:";
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel3.Location = new System.Drawing.Point(20, 130);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(41, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "RAM:";
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel2.Location = new System.Drawing.Point(17, 50);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(44, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Serial:";
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel1.Location = new System.Drawing.Point(11, 10);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(50, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Model:";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            // 
            // TBMain_sn
            // 
            this.TBMain_sn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_sn.CustomButton.Image = null;
            this.TBMain_sn.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.TBMain_sn.CustomButton.Name = "";
            this.TBMain_sn.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBMain_sn.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_sn.CustomButton.TabIndex = 1;
            this.TBMain_sn.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_sn.CustomButton.UseSelectable = true;
            this.TBMain_sn.CustomButton.Visible = false;
            this.TBMain_sn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_sn.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_sn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_sn.Lines = new string[0];
            this.TBMain_sn.Location = new System.Drawing.Point(64, 45);
            this.TBMain_sn.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_sn.MaxLength = 32767;
            this.TBMain_sn.Name = "TBMain_sn";
            this.TBMain_sn.PasswordChar = '\0';
            this.TBMain_sn.ReadOnly = true;
            this.TBMain_sn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_sn.SelectedText = "";
            this.TBMain_sn.SelectionLength = 0;
            this.TBMain_sn.SelectionStart = 0;
            this.TBMain_sn.ShortcutsEnabled = true;
            this.TBMain_sn.Size = new System.Drawing.Size(366, 30);
            this.TBMain_sn.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_sn.TabIndex = 9;
            this.TBMain_sn.TabStop = false;
            this.TBMain_sn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_sn.UseCustomBackColor = true;
            this.TBMain_sn.UseSelectable = true;
            this.TBMain_sn.UseStyleColors = true;
            this.TBMain_sn.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_sn.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TBMain_ram
            // 
            this.TBMain_ram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_ram.CustomButton.Image = null;
            this.TBMain_ram.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.TBMain_ram.CustomButton.Name = "";
            this.TBMain_ram.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBMain_ram.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_ram.CustomButton.TabIndex = 1;
            this.TBMain_ram.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_ram.CustomButton.UseSelectable = true;
            this.TBMain_ram.CustomButton.Visible = false;
            this.TBMain_ram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_ram.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_ram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_ram.Lines = new string[0];
            this.TBMain_ram.Location = new System.Drawing.Point(64, 125);
            this.TBMain_ram.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_ram.MaxLength = 32767;
            this.TBMain_ram.Name = "TBMain_ram";
            this.TBMain_ram.PasswordChar = '\0';
            this.TBMain_ram.ReadOnly = true;
            this.TBMain_ram.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_ram.SelectedText = "";
            this.TBMain_ram.SelectionLength = 0;
            this.TBMain_ram.SelectionStart = 0;
            this.TBMain_ram.ShortcutsEnabled = true;
            this.TBMain_ram.Size = new System.Drawing.Size(366, 30);
            this.TBMain_ram.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_ram.TabIndex = 10;
            this.TBMain_ram.TabStop = false;
            this.TBMain_ram.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_ram.UseCustomBackColor = true;
            this.TBMain_ram.UseSelectable = true;
            this.TBMain_ram.UseStyleColors = true;
            this.TBMain_ram.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_ram.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TBMain_optical
            // 
            this.TBMain_optical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_optical.CustomButton.Image = null;
            this.TBMain_optical.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.TBMain_optical.CustomButton.Name = "";
            this.TBMain_optical.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBMain_optical.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_optical.CustomButton.TabIndex = 1;
            this.TBMain_optical.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_optical.CustomButton.UseSelectable = true;
            this.TBMain_optical.CustomButton.Visible = false;
            this.TBMain_optical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_optical.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_optical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_optical.Lines = new string[0];
            this.TBMain_optical.Location = new System.Drawing.Point(64, 165);
            this.TBMain_optical.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_optical.MaxLength = 32767;
            this.TBMain_optical.Name = "TBMain_optical";
            this.TBMain_optical.PasswordChar = '\0';
            this.TBMain_optical.ReadOnly = true;
            this.TBMain_optical.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_optical.SelectedText = "";
            this.TBMain_optical.SelectionLength = 0;
            this.TBMain_optical.SelectionStart = 0;
            this.TBMain_optical.ShortcutsEnabled = true;
            this.TBMain_optical.Size = new System.Drawing.Size(366, 30);
            this.TBMain_optical.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_optical.TabIndex = 11;
            this.TBMain_optical.TabStop = false;
            this.TBMain_optical.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_optical.UseCustomBackColor = true;
            this.TBMain_optical.UseSelectable = true;
            this.TBMain_optical.UseStyleColors = true;
            this.TBMain_optical.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_optical.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TBMain_gpu
            // 
            this.TBMain_gpu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_gpu.CustomButton.Image = null;
            this.TBMain_gpu.CustomButton.Location = new System.Drawing.Point(318, 2);
            this.TBMain_gpu.CustomButton.Name = "";
            this.TBMain_gpu.CustomButton.Size = new System.Drawing.Size(45, 45);
            this.TBMain_gpu.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_gpu.CustomButton.TabIndex = 1;
            this.TBMain_gpu.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_gpu.CustomButton.UseSelectable = true;
            this.TBMain_gpu.CustomButton.Visible = false;
            this.TBMain_gpu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_gpu.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_gpu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_gpu.Lines = new string[0];
            this.TBMain_gpu.Location = new System.Drawing.Point(64, 265);
            this.TBMain_gpu.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_gpu.MaxLength = 32767;
            this.TBMain_gpu.Multiline = true;
            this.TBMain_gpu.Name = "TBMain_gpu";
            this.TBMain_gpu.PasswordChar = '\0';
            this.TBMain_gpu.ReadOnly = true;
            this.TBMain_gpu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_gpu.SelectedText = "";
            this.TBMain_gpu.SelectionLength = 0;
            this.TBMain_gpu.SelectionStart = 0;
            this.TBMain_gpu.ShortcutsEnabled = true;
            this.TBMain_gpu.Size = new System.Drawing.Size(366, 50);
            this.TBMain_gpu.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_gpu.TabIndex = 13;
            this.TBMain_gpu.TabStop = false;
            this.TBMain_gpu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_gpu.UseCustomBackColor = true;
            this.TBMain_gpu.UseSelectable = true;
            this.TBMain_gpu.UseStyleColors = true;
            this.TBMain_gpu.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_gpu.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel7.Location = new System.Drawing.Point(8, 330);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(53, 19);
            this.metroLabel7.TabIndex = 14;
            this.metroLabel7.Text = "Display:";
            this.metroLabel7.UseCustomBackColor = true;
            this.metroLabel7.UseCustomForeColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel8.Location = new System.Drawing.Point(5, 370);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(56, 19);
            this.metroLabel8.TabIndex = 16;
            this.metroLabel8.Text = "OS info:";
            this.metroLabel8.UseCustomBackColor = true;
            this.metroLabel8.UseCustomForeColor = true;
            // 
            // TBMain_OSinfo
            // 
            this.TBMain_OSinfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_OSinfo.CustomButton.Image = null;
            this.TBMain_OSinfo.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.TBMain_OSinfo.CustomButton.Name = "";
            this.TBMain_OSinfo.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBMain_OSinfo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_OSinfo.CustomButton.TabIndex = 1;
            this.TBMain_OSinfo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_OSinfo.CustomButton.UseSelectable = true;
            this.TBMain_OSinfo.CustomButton.Visible = false;
            this.TBMain_OSinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_OSinfo.Enabled = false;
            this.TBMain_OSinfo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_OSinfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_OSinfo.Lines = new string[0];
            this.TBMain_OSinfo.Location = new System.Drawing.Point(64, 365);
            this.TBMain_OSinfo.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_OSinfo.MaxLength = 32767;
            this.TBMain_OSinfo.Name = "TBMain_OSinfo";
            this.TBMain_OSinfo.PasswordChar = '\0';
            this.TBMain_OSinfo.ReadOnly = true;
            this.TBMain_OSinfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_OSinfo.SelectedText = "";
            this.TBMain_OSinfo.SelectionLength = 0;
            this.TBMain_OSinfo.SelectionStart = 0;
            this.TBMain_OSinfo.ShortcutsEnabled = true;
            this.TBMain_OSinfo.Size = new System.Drawing.Size(366, 30);
            this.TBMain_OSinfo.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_OSinfo.TabIndex = 17;
            this.TBMain_OSinfo.TabStop = false;
            this.TBMain_OSinfo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_OSinfo.UseCustomBackColor = true;
            this.TBMain_OSinfo.UseSelectable = true;
            this.TBMain_OSinfo.UseStyleColors = true;
            this.TBMain_OSinfo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_OSinfo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel9.Location = new System.Drawing.Point(18, 410);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(43, 19);
            this.metroLabel9.TabIndex = 18;
            this.metroLabel9.Text = "Lang.:";
            this.metroLabel9.UseCustomBackColor = true;
            this.metroLabel9.UseCustomForeColor = true;
            // 
            // TBMain_Lang
            // 
            this.TBMain_Lang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_Lang.CustomButton.Image = null;
            this.TBMain_Lang.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.TBMain_Lang.CustomButton.Name = "";
            this.TBMain_Lang.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBMain_Lang.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_Lang.CustomButton.TabIndex = 1;
            this.TBMain_Lang.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_Lang.CustomButton.UseSelectable = true;
            this.TBMain_Lang.CustomButton.Visible = false;
            this.TBMain_Lang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_Lang.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_Lang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_Lang.Lines = new string[0];
            this.TBMain_Lang.Location = new System.Drawing.Point(64, 405);
            this.TBMain_Lang.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_Lang.MaxLength = 32767;
            this.TBMain_Lang.Name = "TBMain_Lang";
            this.TBMain_Lang.PasswordChar = '\0';
            this.TBMain_Lang.ReadOnly = true;
            this.TBMain_Lang.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_Lang.SelectedText = "";
            this.TBMain_Lang.SelectionLength = 0;
            this.TBMain_Lang.SelectionStart = 0;
            this.TBMain_Lang.ShortcutsEnabled = true;
            this.TBMain_Lang.Size = new System.Drawing.Size(366, 30);
            this.TBMain_Lang.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_Lang.TabIndex = 19;
            this.TBMain_Lang.TabStop = false;
            this.TBMain_Lang.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_Lang.UseCustomBackColor = true;
            this.TBMain_Lang.UseSelectable = true;
            this.TBMain_Lang.UseStyleColors = true;
            this.TBMain_Lang.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_Lang.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TBMain_sn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TBMain_model, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel9, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.TBMain_Lang, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel8, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.TBMain_OSinfo, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.TBMain_display, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.TBMain_gpu, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.TBMain_diskDrives, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.TBMain_optical, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TBMain_ram, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.metroLabel16, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TBMain_cpu, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 6);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(440, 440);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // metroLabel16
            // 
            this.metroLabel16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel16.Location = new System.Drawing.Point(23, 90);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(38, 19);
            this.metroLabel16.TabIndex = 20;
            this.metroLabel16.Text = "CPU:";
            this.metroLabel16.UseCustomBackColor = true;
            this.metroLabel16.UseCustomForeColor = true;
            // 
            // TBMain_cpu
            // 
            this.TBMain_cpu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_cpu.CustomButton.Image = null;
            this.TBMain_cpu.CustomButton.Location = new System.Drawing.Point(338, 2);
            this.TBMain_cpu.CustomButton.Name = "";
            this.TBMain_cpu.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBMain_cpu.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_cpu.CustomButton.TabIndex = 1;
            this.TBMain_cpu.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_cpu.CustomButton.UseSelectable = true;
            this.TBMain_cpu.CustomButton.Visible = false;
            this.TBMain_cpu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMain_cpu.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TBMain_cpu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TBMain_cpu.Lines = new string[0];
            this.TBMain_cpu.Location = new System.Drawing.Point(64, 85);
            this.TBMain_cpu.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.TBMain_cpu.MaxLength = 32767;
            this.TBMain_cpu.Name = "TBMain_cpu";
            this.TBMain_cpu.PasswordChar = '\0';
            this.TBMain_cpu.ReadOnly = true;
            this.TBMain_cpu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_cpu.SelectedText = "";
            this.TBMain_cpu.SelectionLength = 0;
            this.TBMain_cpu.SelectionStart = 0;
            this.TBMain_cpu.ShortcutsEnabled = true;
            this.TBMain_cpu.Size = new System.Drawing.Size(366, 30);
            this.TBMain_cpu.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_cpu.TabIndex = 21;
            this.TBMain_cpu.TabStop = false;
            this.TBMain_cpu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_cpu.UseCustomBackColor = true;
            this.TBMain_cpu.UseSelectable = true;
            this.TBMain_cpu.UseStyleColors = true;
            this.TBMain_cpu.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_cpu.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TBMain_summarySpec
            // 
            this.TBMain_summarySpec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.TBMain_summarySpec.CustomButton.Image = null;
            this.TBMain_summarySpec.CustomButton.Location = new System.Drawing.Point(718, 2);
            this.TBMain_summarySpec.CustomButton.Name = "";
            this.TBMain_summarySpec.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TBMain_summarySpec.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TBMain_summarySpec.CustomButton.TabIndex = 1;
            this.TBMain_summarySpec.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TBMain_summarySpec.CustomButton.UseSelectable = true;
            this.TBMain_summarySpec.CustomButton.Visible = false;
            this.TBMain_summarySpec.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.TBMain_summarySpec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_summarySpec.Lines = new string[0];
            this.TBMain_summarySpec.Location = new System.Drawing.Point(89, 7);
            this.TBMain_summarySpec.Margin = new System.Windows.Forms.Padding(10);
            this.TBMain_summarySpec.MaxLength = 32767;
            this.TBMain_summarySpec.Name = "TBMain_summarySpec";
            this.TBMain_summarySpec.PasswordChar = '\0';
            this.TBMain_summarySpec.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TBMain_summarySpec.SelectedText = "";
            this.TBMain_summarySpec.SelectionLength = 0;
            this.TBMain_summarySpec.SelectionStart = 0;
            this.TBMain_summarySpec.ShortcutsEnabled = true;
            this.TBMain_summarySpec.Size = new System.Drawing.Size(746, 30);
            this.TBMain_summarySpec.Style = MetroFramework.MetroColorStyle.Black;
            this.TBMain_summarySpec.TabIndex = 12;
            this.TBMain_summarySpec.TabStop = false;
            this.TBMain_summarySpec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TBMain_summarySpec.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TBMain_summarySpec.UseCustomBackColor = true;
            this.TBMain_summarySpec.UseCustomForeColor = true;
            this.TBMain_summarySpec.UseSelectable = true;
            this.TBMain_summarySpec.UseStyleColors = true;
            this.TBMain_summarySpec.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_summarySpec.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(848, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(90, 29);
            this.panel3.TabIndex = 13;
            this.panel3.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.TBMain_cmd);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(8, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 609);
            this.panel1.TabIndex = 14;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.StatusStrip);
            this.panel6.Location = new System.Drawing.Point(1, 579);
            this.panel6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(429, 30);
            this.panel6.TabIndex = 11;
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.StatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusStrip.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripText1,
            this.StatusInternet,
            this.ToolStripText2,
            this.StatusNetworkFolder,
            this.ToolStripText3,
            this.StatusUSB});
            this.StatusStrip.Location = new System.Drawing.Point(0, 0);
            this.StatusStrip.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(429, 30);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ToolStripText1
            // 
            this.ToolStripText1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ToolStripText1.Name = "ToolStripText1";
            this.ToolStripText1.Size = new System.Drawing.Size(63, 25);
            this.ToolStripText1.Text = "Internet:";
            // 
            // StatusInternet
            // 
            this.StatusInternet.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusInternet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.StatusInternet.Name = "StatusInternet";
            this.StatusInternet.Size = new System.Drawing.Size(28, 25);
            this.StatusInternet.Text = "off";
            // 
            // ToolStripText2
            // 
            this.ToolStripText2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ToolStripText2.Name = "ToolStripText2";
            this.ToolStripText2.Size = new System.Drawing.Size(114, 25);
            this.ToolStripText2.Text = "Network Folder:";
            // 
            // StatusNetworkFolder
            // 
            this.StatusNetworkFolder.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusNetworkFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.StatusNetworkFolder.Name = "StatusNetworkFolder";
            this.StatusNetworkFolder.Size = new System.Drawing.Size(28, 25);
            this.StatusNetworkFolder.Text = "off";
            // 
            // ToolStripText3
            // 
            this.ToolStripText3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ToolStripText3.Name = "ToolStripText3";
            this.ToolStripText3.Size = new System.Drawing.Size(39, 25);
            this.ToolStripText3.Text = "USB:";
            // 
            // StatusUSB
            // 
            this.StatusUSB.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusUSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.StatusUSB.Name = "StatusUSB";
            this.StatusUSB.Size = new System.Drawing.Size(28, 25);
            this.StatusUSB.Text = "off";
            // 
            // TBMain_cmd
            // 
            this.TBMain_cmd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TBMain_cmd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBMain_cmd.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TBMain_cmd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TBMain_cmd.Location = new System.Drawing.Point(1, 451);
            this.TBMain_cmd.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.TBMain_cmd.Multiline = true;
            this.TBMain_cmd.Name = "TBMain_cmd";
            this.TBMain_cmd.Size = new System.Drawing.Size(429, 118);
            this.TBMain_cmd.TabIndex = 1;
            this.TBMain_cmd.TabStop = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Location = new System.Drawing.Point(89, 7);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.metroProgressBar1.Size = new System.Drawing.Size(746, 29);
            this.metroProgressBar1.Style = MetroFramework.MetroColorStyle.Yellow;
            this.metroProgressBar1.TabIndex = 15;
            this.metroProgressBar1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // timerAudio
            // 
            this.timerAudio.Tick += new System.EventHandler(this.timerAudio_Tick_1);
            // 
            // timerMic
            // 
            this.timerMic.Tick += new System.EventHandler(this.timerMic_Tick);
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 500;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick_1);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.metroButton1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.metroButton2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.metroButton3, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(458, 42);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(350, 35);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(0, 0);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(0);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(110, 35);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton1.TabIndex = 4;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "Device Mgr. [F8]";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(120, 0);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(0);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(110, 35);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton2.TabIndex = 5;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "Disk Mgr. [F9]";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseCustomForeColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.UseStyleColors = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.metroButton3.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton3.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.metroButton3.Highlight = true;
            this.metroButton3.Location = new System.Drawing.Point(240, 0);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(0);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(110, 35);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton3.TabIndex = 6;
            this.metroButton3.TabStop = false;
            this.metroButton3.Text = "Ctrl Panel [F10]";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.UseCustomBackColor = true;
            this.metroButton3.UseCustomForeColor = true;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.UseStyleColors = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.metroButton4.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton4.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.metroButton4.Highlight = true;
            this.metroButton4.Location = new System.Drawing.Point(818, 42);
            this.metroButton4.Margin = new System.Windows.Forms.Padding(0);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(120, 35);
            this.metroButton4.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton4.TabIndex = 18;
            this.metroButton4.TabStop = false;
            this.metroButton4.Text = "NetDrive [ctr+M]";
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton4.UseCustomBackColor = true;
            this.metroButton4.UseCustomForeColor = true;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.UseStyleColors = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackImage = global::Imago1.Properties.Resources.spec_sniffer_logo2;
            this.BackMaxSize = 80;
            this.ClientSize = new System.Drawing.Size(949, 700);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Tab);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.TBMain_summarySpec);
            this.DisplayHeader = false;
            this.ForeColor = System.Drawing.Color.Thistle;
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "           SpecSniffer";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.Tab.ResumeLayout(false);
            this.tabDiagnostic.ResumeLayout(false);
            this.tabDiagnostic.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.micChart)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.tabDrivers.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabSO.ResumeLayout(false);
            this.tabSO.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTabControl Tab;
        private System.Windows.Forms.TabPage tabDiagnostic;
        private MetroFramework.Controls.MetroTextBox TBMain_display;
        private MetroFramework.Controls.MetroTextBox TBMain_diskDrives;
        private MetroFramework.Controls.MetroTextBox TBMain_model;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox TBMain_sn;
        private MetroFramework.Controls.MetroTextBox TBMain_ram;
        private MetroFramework.Controls.MetroTextBox TBMain_optical;
        private MetroFramework.Controls.MetroTextBox TBMain_gpu;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox TBMain_OSinfo;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox TBMain_Lang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabSO;
        private MetroFramework.Controls.MetroTextBox TBMain_summarySpec;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroButton btnMain_LCD;
        private MetroFramework.Controls.MetroButton btnMain_Cam;
        private MetroFramework.Controls.MetroButton btnMain_Mic;
        private MetroFramework.Controls.MetroButton btnMain_Audio;
        private MetroFramework.Controls.MetroButton btnMain_HDTune;
        private MetroFramework.Controls.MetroButton btnMain_ShowKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabDrivers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox TBDrivers_Folder;
        private MetroFramework.Controls.MetroTextBox TBDrivers_Path;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private MetroFramework.Controls.MetroButton btnDrivers_Install;
        private MetroFramework.Controls.MetroButton btnDrivers_BIOS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox TBSO_SO;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox TBSO_RP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private MetroFramework.Controls.MetroComboBox CBSO_Licence;
        private MetroFramework.Controls.MetroTextBox TBSO_Parts;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private Emgu.CV.UI.ImageBox imageBox1;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroTextBox TBMain_cpu;
        private System.Windows.Forms.TextBox TBMain_cmd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private System.Windows.Forms.Timer timerAudio;
        private MetroFramework.Controls.MetroProgressBar pbarAudio;
        private System.Windows.Forms.DataVisualization.Charting.Chart micChart;
        private System.Windows.Forms.Timer timerMic;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripText1;
        private System.Windows.Forms.ToolStripStatusLabel StatusInternet;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripText2;
        private System.Windows.Forms.ToolStripStatusLabel StatusNetworkFolder;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripText3;
        private System.Windows.Forms.ToolStripStatusLabel StatusUSB;
        private MetroFramework.Controls.MetroCheckBox CheckB_Licence;
        private MetroFramework.Controls.MetroCheckBox CheckB_comments;
        private MetroFramework.Controls.MetroCheckBox CheckB_Parts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton BTNSO_AltSave;
        private MetroFramework.Controls.MetroButton BTNSO_Save;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private MetroFramework.Controls.MetroCheckBox CheckB_SO;
        private MetroFramework.Controls.MetroTextBox TBSO_Comments;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private System.Windows.Forms.Panel panel7;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private System.Windows.Forms.Panel panel8;
        private MetroFramework.Controls.MetroLabel metroLabel20;
    }
}

