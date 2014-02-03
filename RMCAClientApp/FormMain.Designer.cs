namespace WindowsFormsGraphickOpenGL
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowGrap = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSaveGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.addEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterDataSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReCalcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSaveReportAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSA = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuST = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSD = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSFExperimentTime = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSFKadrsNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSFInputTimeInSec = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCalc = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReCalc = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFindEvent = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowGraph = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelWidthDiff = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxParam = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonIncParam = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecParam = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripOutStep = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxOutStep = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonIncOutStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecOutStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelInStep = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxInStep = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonIncInStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDecInStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelGauss = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxWidthGauss = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxSmooth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxSelectTypeSeach = new System.Windows.Forms.ToolStripComboBox();
            this.saveFileReportDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerTreeFilePath = new System.Windows.Forms.SplitContainer();
            this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGraphFile = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGraphMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxGraphData = new System.Windows.Forms.PictureBox();
            this.OpenGlControlGraph = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.tableLayoutPanelScroll = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripGraphTools = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonGraphZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGraphZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGraphFullView = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGraphSave = new System.Windows.Forms.ToolStripButton();
            this.hScrollBarGraph = new System.Windows.Forms.HScrollBar();
            this.tabPageTimeSpeed = new System.Windows.Forms.TabPage();
            this.zedGraphControlTimeSpeed = new ZedGraph.ZedGraphControl();
            this.tabPageTimeAcceleration = new System.Windows.Forms.TabPage();
            this.zedGraphControlTimeAcceleration = new ZedGraph.ZedGraphControl();
            this.tabPageSpeedAcceleration = new System.Windows.Forms.TabPage();
            this.zedGraphControlSpeedAcceleration = new ZedGraph.ZedGraphControl();
            this.tabPageReport = new System.Windows.Forms.TabPage();
            this.richTextBoxReport = new System.Windows.Forms.RichTextBox();
            this.tabPageTimeSpeedAcc = new System.Windows.Forms.TabPage();
            this.zedGraphControlTimeSpeedAcc = new ZedGraph.ZedGraphControl();
            this.tabPageFilter = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelFilterTop = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.zedGraphControlFiltered = new ZedGraph.ZedGraphControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.zedGraphControlSource = new ZedGraph.ZedGraphControl();
            this.tabPageDegreeSpeed = new System.Windows.Forms.TabPage();
            this.zedGraphControlDegreeSpeed = new ZedGraph.ZedGraphControl();
            this.tabPageDegreeAcc = new System.Windows.Forms.TabPage();
            this.zedGraphControlDegreeAcc = new ZedGraph.ZedGraphControl();
            this.saveFileDialogGraph = new System.Windows.Forms.SaveFileDialog();
            this.explorerTreeMain = new WindowsExplorer.ExplorerTree();
            this.menuStrip1.SuspendLayout();
            this.toolStripMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeFilePath)).BeginInit();
            this.splitContainerTreeFilePath.Panel1.SuspendLayout();
            this.splitContainerTreeFilePath.Panel2.SuspendLayout();
            this.splitContainerTreeFilePath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageGraphFile.SuspendLayout();
            this.tableLayoutPanelGraphMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphData)).BeginInit();
            this.tableLayoutPanelScroll.SuspendLayout();
            this.toolStripGraphTools.SuspendLayout();
            this.tabPageTimeSpeed.SuspendLayout();
            this.tabPageTimeAcceleration.SuspendLayout();
            this.tabPageSpeedAcceleration.SuspendLayout();
            this.tabPageReport.SuspendLayout();
            this.tabPageTimeSpeedAcc.SuspendLayout();
            this.tabPageFilter.SuspendLayout();
            this.tableLayoutPanelFilterTop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageDegreeSpeed.SuspendLayout();
            this.tabPageDegreeAcc.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1276, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowGrap,
            this.ToolStripMenuItemSaveGraph,
            this.ToolStripMenuItemCalc,
            this.addEventsToolStripMenuItem,
            this.FilterDataSourceToolStripMenuItem,
            this.ReCalcToolStripMenuItem,
            this.findEventsToolStripMenuItem,
            this.ToolStripMenuItemSaveReportAs,
            this.ToolStripMenuItemExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.файлToolStripMenuItem.Text = "Операции";
            // 
            // menuShowGrap
            // 
            this.menuShowGrap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuShowGrap.Name = "menuShowGrap";
            this.menuShowGrap.Size = new System.Drawing.Size(274, 22);
            this.menuShowGrap.Text = "Построить график исходных данных";
            this.menuShowGrap.Click += new System.EventHandler(this.menuShowGrap_Click);
            // 
            // ToolStripMenuItemSaveGraph
            // 
            this.ToolStripMenuItemSaveGraph.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolStripMenuItemSaveGraph.Name = "ToolStripMenuItemSaveGraph";
            this.ToolStripMenuItemSaveGraph.Size = new System.Drawing.Size(274, 22);
            this.ToolStripMenuItemSaveGraph.Text = "Сохранить график исходных данных";
            this.ToolStripMenuItemSaveGraph.Click += new System.EventHandler(this.ToolStripMenuItemSaveGraph_Click);
            // 
            // ToolStripMenuItemCalc
            // 
            this.ToolStripMenuItemCalc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolStripMenuItemCalc.Name = "ToolStripMenuItemCalc";
            this.ToolStripMenuItemCalc.Size = new System.Drawing.Size(274, 22);
            this.ToolStripMenuItemCalc.Text = "Вычислить";
            this.ToolStripMenuItemCalc.Click += new System.EventHandler(this.calcToolStripMenuItem_Click);
            // 
            // addEventsToolStripMenuItem
            // 
            this.addEventsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addEventsToolStripMenuItem.Name = "addEventsToolStripMenuItem";
            this.addEventsToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.addEventsToolStripMenuItem.Text = "Добавить События";
            this.addEventsToolStripMenuItem.Click += new System.EventHandler(this.addEventsToolStripMenuItem_Click);
            // 
            // FilterDataSourceToolStripMenuItem
            // 
            this.FilterDataSourceToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FilterDataSourceToolStripMenuItem.Name = "FilterDataSourceToolStripMenuItem";
            this.FilterDataSourceToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.FilterDataSourceToolStripMenuItem.Text = "Фильтрация исходных данных";
            this.FilterDataSourceToolStripMenuItem.Click += new System.EventHandler(this.FilterDataSourceToolStripMenuItem_Click);
            // 
            // ReCalcToolStripMenuItem
            // 
            this.ReCalcToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ReCalcToolStripMenuItem.Name = "ReCalcToolStripMenuItem";
            this.ReCalcToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.ReCalcToolStripMenuItem.Text = "Пересчитать";
            this.ReCalcToolStripMenuItem.Click += new System.EventHandler(this.ReCalcToolStripMenuItem_Click);
            // 
            // findEventsToolStripMenuItem
            // 
            this.findEventsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.findEventsToolStripMenuItem.Name = "findEventsToolStripMenuItem";
            this.findEventsToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
            this.findEventsToolStripMenuItem.Text = "Найти события";
            this.findEventsToolStripMenuItem.Click += new System.EventHandler(this.findEventsToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemSaveReportAs
            // 
            this.ToolStripMenuItemSaveReportAs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolStripMenuItemSaveReportAs.Name = "ToolStripMenuItemSaveReportAs";
            this.ToolStripMenuItemSaveReportAs.Size = new System.Drawing.Size(274, 22);
            this.ToolStripMenuItemSaveReportAs.Text = "Сохранить отчёт";
            this.ToolStripMenuItemSaveReportAs.Click += new System.EventHandler(this.ToolStripMenuItemSaveReportAs_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(274, 22);
            this.ToolStripMenuItemExit.Text = "Выход";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSA,
            this.mnuST,
            this.toolStripMenuItem1,
            this.mnuSD,
            this.mnuSN,
            this.mnuSF,
            this.toolStripMenuItem2,
            this.mnuSFExperimentTime,
            this.mnuSFKadrsNumber,
            this.mnuSFInputTimeInSec,
            this.toolStripMenuItem3});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // mnuSA
            // 
            this.mnuSA.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnuSA.Checked = true;
            this.mnuSA.CheckOnClick = true;
            this.mnuSA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSA.Name = "mnuSA";
            this.mnuSA.Size = new System.Drawing.Size(196, 22);
            this.mnuSA.Text = "Адресная строка";
            this.mnuSA.Click += new System.EventHandler(this.mnuSA_Click);
            // 
            // mnuST
            // 
            this.mnuST.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnuST.Checked = true;
            this.mnuST.CheckOnClick = true;
            this.mnuST.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuST.Name = "mnuST";
            this.mnuST.Size = new System.Drawing.Size(196, 22);
            this.mnuST.Text = "Панель инструментов";
            this.mnuST.Click += new System.EventHandler(this.mnuST_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuSD
            // 
            this.mnuSD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnuSD.Checked = true;
            this.mnuSD.CheckOnClick = true;
            this.mnuSD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSD.Name = "mnuSD";
            this.mnuSD.Size = new System.Drawing.Size(196, 22);
            this.mnuSD.Text = "Мои документы";
            this.mnuSD.Click += new System.EventHandler(this.mnuSD_Click);
            // 
            // mnuSN
            // 
            this.mnuSN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnuSN.Checked = true;
            this.mnuSN.CheckOnClick = true;
            this.mnuSN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSN.Name = "mnuSN";
            this.mnuSN.Size = new System.Drawing.Size(196, 22);
            this.mnuSN.Text = "Сетевое окружение";
            this.mnuSN.Click += new System.EventHandler(this.mnuSN_Click);
            // 
            // mnuSF
            // 
            this.mnuSF.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnuSF.Checked = true;
            this.mnuSF.CheckOnClick = true;
            this.mnuSF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSF.Name = "mnuSF";
            this.mnuSF.Size = new System.Drawing.Size(196, 22);
            this.mnuSF.Text = "Избранное";
            this.mnuSF.Click += new System.EventHandler(this.mnuSF_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuSFExperimentTime
            // 
            this.mnuSFExperimentTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnuSFExperimentTime.Checked = true;
            this.mnuSFExperimentTime.CheckOnClick = true;
            this.mnuSFExperimentTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSFExperimentTime.Name = "mnuSFExperimentTime";
            this.mnuSFExperimentTime.Size = new System.Drawing.Size(196, 22);
            this.mnuSFExperimentTime.Text = "Время эксперимента";
            this.mnuSFExperimentTime.Click += new System.EventHandler(this.mnuSFExperimentTime_Click);
            // 
            // mnuSFKadrsNumber
            // 
            this.mnuSFKadrsNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnuSFKadrsNumber.Checked = true;
            this.mnuSFKadrsNumber.CheckOnClick = true;
            this.mnuSFKadrsNumber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSFKadrsNumber.Name = "mnuSFKadrsNumber";
            this.mnuSFKadrsNumber.Size = new System.Drawing.Size(196, 22);
            this.mnuSFKadrsNumber.Text = "Число кадров";
            this.mnuSFKadrsNumber.Click += new System.EventHandler(this.mnuSFKadrsNumber_Click);
            // 
            // mnuSFInputTimeInSec
            // 
            this.mnuSFInputTimeInSec.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnuSFInputTimeInSec.Checked = true;
            this.mnuSFInputTimeInSec.CheckOnClick = true;
            this.mnuSFInputTimeInSec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuSFInputTimeInSec.Name = "mnuSFInputTimeInSec";
            this.mnuSFInputTimeInSec.Size = new System.Drawing.Size(196, 22);
            this.mnuSFInputTimeInSec.Text = "Длительность записи";
            this.mnuSFInputTimeInSec.Click += new System.EventHandler(this.mnuSFInputTimeInSec_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 6);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemHelp,
            this.ToolStripMenuItemAbout});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(149, 22);
            this.ToolStripMenuItemHelp.Text = "Справка";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(149, 22);
            this.ToolStripMenuItemAbout.Text = "О программе";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // toolStripMainMenu
            // 
            this.toolStripMainMenu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripMainMenu.ImageScalingSize = new System.Drawing.Size(15, 15);
            this.toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCalc,
            this.toolStripButtonReCalc,
            this.toolStripButtonFindEvent,
            this.toolStripButtonShowGraph,
            this.toolStripButtonSaveReport,
            this.toolStripSeparator1,
            this.toolStripLabelWidthDiff,
            this.toolStripTextBoxParam,
            this.toolStripButtonIncParam,
            this.toolStripButtonDecParam,
            this.toolStripSeparator2,
            this.toolStripOutStep,
            this.toolStripTextBoxOutStep,
            this.toolStripButtonIncOutStep,
            this.toolStripButtonDecOutStep,
            this.toolStripSeparator3,
            this.toolStripLabelInStep,
            this.toolStripTextBoxInStep,
            this.toolStripButtonIncInStep,
            this.toolStripButtonDecInStep,
            this.toolStripLabelGauss,
            this.toolStripTextBoxWidthGauss,
            this.toolStripSeparator4,
            this.toolStripComboBoxSmooth,
            this.toolStripSeparator5,
            this.toolStripComboBoxSelectTypeSeach});
            this.toolStripMainMenu.Location = new System.Drawing.Point(0, 24);
            this.toolStripMainMenu.Name = "toolStripMainMenu";
            this.toolStripMainMenu.Size = new System.Drawing.Size(1276, 27);
            this.toolStripMainMenu.TabIndex = 14;
            this.toolStripMainMenu.Text = "toolStrip1";
            // 
            // toolStripButtonCalc
            // 
            this.toolStripButtonCalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCalc.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCalc.Image")));
            this.toolStripButtonCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCalc.Name = "toolStripButtonCalc";
            this.toolStripButtonCalc.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonCalc.Text = "Вычислить";
            this.toolStripButtonCalc.Click += new System.EventHandler(this.toolStripButtonCalc_Click);
            // 
            // toolStripButtonReCalc
            // 
            this.toolStripButtonReCalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReCalc.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReCalc.Image")));
            this.toolStripButtonReCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReCalc.Name = "toolStripButtonReCalc";
            this.toolStripButtonReCalc.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonReCalc.Text = "toolStripButton1";
            this.toolStripButtonReCalc.ToolTipText = "Пересчитать";
            this.toolStripButtonReCalc.Click += new System.EventHandler(this.toolStripButtonReCalc_Click);
            // 
            // toolStripButtonFindEvent
            // 
            this.toolStripButtonFindEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFindEvent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFindEvent.Image")));
            this.toolStripButtonFindEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFindEvent.Name = "toolStripButtonFindEvent";
            this.toolStripButtonFindEvent.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonFindEvent.Text = "Найти события";
            this.toolStripButtonFindEvent.Click += new System.EventHandler(this.toolStripButtonFindEvent_Click);
            // 
            // toolStripButtonShowGraph
            // 
            this.toolStripButtonShowGraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowGraph.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowGraph.Image")));
            this.toolStripButtonShowGraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowGraph.Name = "toolStripButtonShowGraph";
            this.toolStripButtonShowGraph.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonShowGraph.Text = "Построить график исходных данных";
            this.toolStripButtonShowGraph.Click += new System.EventHandler(this.toolStripButtonShowGraph_Click);
            // 
            // toolStripButtonSaveReport
            // 
            this.toolStripButtonSaveReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveReport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveReport.Image")));
            this.toolStripButtonSaveReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveReport.Name = "toolStripButtonSaveReport";
            this.toolStripButtonSaveReport.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonSaveReport.Text = "Сохранить отчёт";
            this.toolStripButtonSaveReport.Click += new System.EventHandler(this.toolStripButtonSaveReport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolStripLabelWidthDiff
            // 
            this.toolStripLabelWidthDiff.Name = "toolStripLabelWidthDiff";
            this.toolStripLabelWidthDiff.Size = new System.Drawing.Size(62, 24);
            this.toolStripLabelWidthDiff.Text = "Параметр";
            this.toolStripLabelWidthDiff.Visible = false;
            // 
            // toolStripTextBoxParam
            // 
            this.toolStripTextBoxParam.MaxLength = 2;
            this.toolStripTextBoxParam.Name = "toolStripTextBoxParam";
            this.toolStripTextBoxParam.Size = new System.Drawing.Size(30, 27);
            this.toolStripTextBoxParam.Visible = false;
            this.toolStripTextBoxParam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxParam_KeyPress);
            this.toolStripTextBoxParam.TextChanged += new System.EventHandler(this.toolStripTextBoxParam_TextChanged);
            // 
            // toolStripButtonIncParam
            // 
            this.toolStripButtonIncParam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIncParam.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonIncParam.Image")));
            this.toolStripButtonIncParam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIncParam.Name = "toolStripButtonIncParam";
            this.toolStripButtonIncParam.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonIncParam.Visible = false;
            this.toolStripButtonIncParam.Click += new System.EventHandler(this.toolStripButtonIncParam_Click);
            // 
            // toolStripButtonDecParam
            // 
            this.toolStripButtonDecParam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDecParam.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDecParam.Image")));
            this.toolStripButtonDecParam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecParam.Name = "toolStripButtonDecParam";
            this.toolStripButtonDecParam.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonDecParam.Visible = false;
            this.toolStripButtonDecParam.Click += new System.EventHandler(this.toolStripButtonDecParam_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripOutStep
            // 
            this.toolStripOutStep.Name = "toolStripOutStep";
            this.toolStripOutStep.Size = new System.Drawing.Size(144, 24);
            this.toolStripOutStep.Text = "Коэфициент накопления";
            // 
            // toolStripTextBoxOutStep
            // 
            this.toolStripTextBoxOutStep.Name = "toolStripTextBoxOutStep";
            this.toolStripTextBoxOutStep.Size = new System.Drawing.Size(30, 27);
            this.toolStripTextBoxOutStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxOutStep_KeyPress);
            this.toolStripTextBoxOutStep.TextChanged += new System.EventHandler(this.toolStripTextBoxOutStep_TextChanged);
            // 
            // toolStripButtonIncOutStep
            // 
            this.toolStripButtonIncOutStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIncOutStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonIncOutStep.Image")));
            this.toolStripButtonIncOutStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIncOutStep.Name = "toolStripButtonIncOutStep";
            this.toolStripButtonIncOutStep.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonIncOutStep.Text = "toolStripButton1";
            this.toolStripButtonIncOutStep.Click += new System.EventHandler(this.toolStripButtonIncOutStep_Click);
            // 
            // toolStripButtonDecOutStep
            // 
            this.toolStripButtonDecOutStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDecOutStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDecOutStep.Image")));
            this.toolStripButtonDecOutStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecOutStep.Name = "toolStripButtonDecOutStep";
            this.toolStripButtonDecOutStep.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonDecOutStep.Text = "toolStripButton2";
            this.toolStripButtonDecOutStep.Click += new System.EventHandler(this.toolStripButtonDecOutStep_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabelInStep
            // 
            this.toolStripLabelInStep.Name = "toolStripLabelInStep";
            this.toolStripLabelInStep.Size = new System.Drawing.Size(136, 24);
            this.toolStripLabelInStep.Text = "Коэфициент смещения";
            // 
            // toolStripTextBoxInStep
            // 
            this.toolStripTextBoxInStep.Name = "toolStripTextBoxInStep";
            this.toolStripTextBoxInStep.Size = new System.Drawing.Size(30, 27);
            this.toolStripTextBoxInStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxInStep_KeyPress);
            this.toolStripTextBoxInStep.TextChanged += new System.EventHandler(this.toolStripTextBoxInStep_TextChanged);
            // 
            // toolStripButtonIncInStep
            // 
            this.toolStripButtonIncInStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonIncInStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonIncInStep.Image")));
            this.toolStripButtonIncInStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIncInStep.Name = "toolStripButtonIncInStep";
            this.toolStripButtonIncInStep.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonIncInStep.Text = "toolStripButtonIncInStep";
            this.toolStripButtonIncInStep.Click += new System.EventHandler(this.toolStripButtonIncInStep_Click);
            // 
            // toolStripButtonDecInStep
            // 
            this.toolStripButtonDecInStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDecInStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDecInStep.Image")));
            this.toolStripButtonDecInStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDecInStep.Name = "toolStripButtonDecInStep";
            this.toolStripButtonDecInStep.Size = new System.Drawing.Size(23, 24);
            this.toolStripButtonDecInStep.Text = "toolStripButton2";
            this.toolStripButtonDecInStep.Click += new System.EventHandler(this.toolStripButtonDecInStep_Click);
            // 
            // toolStripLabelGauss
            // 
            this.toolStripLabelGauss.Name = "toolStripLabelGauss";
            this.toolStripLabelGauss.Size = new System.Drawing.Size(232, 24);
            this.toolStripLabelGauss.Text = "Ширина окна сглаживания(число точек)";
            // 
            // toolStripTextBoxWidthGauss
            // 
            this.toolStripTextBoxWidthGauss.Name = "toolStripTextBoxWidthGauss";
            this.toolStripTextBoxWidthGauss.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBoxWidthGauss.Text = "57";
            this.toolStripTextBoxWidthGauss.Leave += new System.EventHandler(this.toolStripTextBoxWidthGauss_Leave);
            this.toolStripTextBoxWidthGauss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxWidthGauss_KeyPress);
            this.toolStripTextBoxWidthGauss.TextChanged += new System.EventHandler(this.toolStripTextBoxWidthGauss_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripComboBoxSmooth
            // 
            this.toolStripComboBoxSmooth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxSmooth.Items.AddRange(new object[] {
            "Двухпараметрическое сглаживание",
            "Сглаживание Гаусса"});
            this.toolStripComboBoxSmooth.Name = "toolStripComboBoxSmooth";
            this.toolStripComboBoxSmooth.Size = new System.Drawing.Size(250, 23);
            this.toolStripComboBoxSmooth.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxSmooth_SelectedIndexChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripComboBoxSelectTypeSeach
            // 
            this.toolStripComboBoxSelectTypeSeach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxSelectTypeSeach.Items.AddRange(new object[] {
            "Поиск событий по мин. и мак.",
            "Поиск событий по оптическому и пъезо датчику"});
            this.toolStripComboBoxSelectTypeSeach.Name = "toolStripComboBoxSelectTypeSeach";
            this.toolStripComboBoxSelectTypeSeach.Size = new System.Drawing.Size(300, 23);
            this.toolStripComboBoxSelectTypeSeach.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxSelectTypeSeach_SelectedIndexChanged);
            // 
            // saveFileReportDialog
            // 
            this.saveFileReportDialog.DefaultExt = "rtf";
            this.saveFileReportDialog.FileName = "отчёт";
            this.saveFileReportDialog.Filter = "rtf files|*.rtf";
            this.saveFileReportDialog.RestoreDirectory = true;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 51);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerTreeFilePath);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlMain);
            this.splitContainerMain.Size = new System.Drawing.Size(1276, 712);
            this.splitContainerMain.SplitterDistance = 252;
            this.splitContainerMain.TabIndex = 17;
            this.splitContainerMain.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainerMain_SplitterMoving);
            this.splitContainerMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerMain_SplitterMoved);
            // 
            // splitContainerTreeFilePath
            // 
            this.splitContainerTreeFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTreeFilePath.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTreeFilePath.Name = "splitContainerTreeFilePath";
            this.splitContainerTreeFilePath.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTreeFilePath.Panel1
            // 
            this.splitContainerTreeFilePath.Panel1.Controls.Add(this.explorerTreeMain);
            // 
            // splitContainerTreeFilePath.Panel2
            // 
            this.splitContainerTreeFilePath.Panel2.Controls.Add(this.dataGridViewFiles);
            this.splitContainerTreeFilePath.Size = new System.Drawing.Size(252, 712);
            this.splitContainerTreeFilePath.SplitterDistance = 422;
            this.splitContainerTreeFilePath.TabIndex = 0;
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.AllowUserToDeleteRows = false;
            this.dataGridViewFiles.AllowUserToOrderColumns = true;
            this.dataGridViewFiles.AllowUserToResizeRows = false;
            this.dataGridViewFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewFiles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFiles.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.ReadOnly = true;
            this.dataGridViewFiles.RowHeadersVisible = false;
            this.dataGridViewFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFiles.Size = new System.Drawing.Size(252, 286);
            this.dataGridViewFiles.TabIndex = 11;
            this.dataGridViewFiles.SelectionChanged += new System.EventHandler(this.dataGridViewFiles_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 73;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 73;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 73;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 73;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageGraphFile);
            this.tabControlMain.Controls.Add(this.tabPageTimeSpeed);
            this.tabControlMain.Controls.Add(this.tabPageTimeAcceleration);
            this.tabControlMain.Controls.Add(this.tabPageSpeedAcceleration);
            this.tabControlMain.Controls.Add(this.tabPageReport);
            this.tabControlMain.Controls.Add(this.tabPageTimeSpeedAcc);
            this.tabControlMain.Controls.Add(this.tabPageFilter);
            this.tabControlMain.Controls.Add(this.tabPageDegreeSpeed);
            this.tabControlMain.Controls.Add(this.tabPageDegreeAcc);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1020, 712);
            this.tabControlMain.TabIndex = 17;
            // 
            // tabPageGraphFile
            // 
            this.tabPageGraphFile.Controls.Add(this.tableLayoutPanelGraphMain);
            this.tabPageGraphFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageGraphFile.Name = "tabPageGraphFile";
            this.tabPageGraphFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraphFile.Size = new System.Drawing.Size(1012, 686);
            this.tabPageGraphFile.TabIndex = 0;
            this.tabPageGraphFile.Text = "График исходных данных";
            this.tabPageGraphFile.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelGraphMain
            // 
            this.tableLayoutPanelGraphMain.ColumnCount = 1;
            this.tableLayoutPanelGraphMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGraphMain.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelGraphMain.Controls.Add(this.tableLayoutPanelScroll, 0, 1);
            this.tableLayoutPanelGraphMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGraphMain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelGraphMain.Name = "tableLayoutPanelGraphMain";
            this.tableLayoutPanelGraphMain.RowCount = 2;
            this.tableLayoutPanelGraphMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGraphMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelGraphMain.Size = new System.Drawing.Size(1006, 680);
            this.tableLayoutPanelGraphMain.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxGraphData);
            this.panel1.Controls.Add(this.OpenGlControlGraph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 634);
            this.panel1.TabIndex = 12;
            // 
            // pictureBoxGraphData
            // 
            this.pictureBoxGraphData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGraphData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxGraphData.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGraphData.Name = "pictureBoxGraphData";
            this.pictureBoxGraphData.Size = new System.Drawing.Size(1000, 634);
            this.pictureBoxGraphData.TabIndex = 4;
            this.pictureBoxGraphData.TabStop = false;
            // 
            // OpenGlControlGraph
            // 
            this.OpenGlControlGraph.AccumBits = ((byte)(0));
            this.OpenGlControlGraph.AutoCheckErrors = false;
            this.OpenGlControlGraph.AutoFinish = false;
            this.OpenGlControlGraph.AutoMakeCurrent = true;
            this.OpenGlControlGraph.AutoSwapBuffers = true;
            this.OpenGlControlGraph.BackColor = System.Drawing.Color.White;
            this.OpenGlControlGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OpenGlControlGraph.ColorBits = ((byte)(32));
            this.OpenGlControlGraph.DepthBits = ((byte)(16));
            this.OpenGlControlGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenGlControlGraph.Location = new System.Drawing.Point(0, 0);
            this.OpenGlControlGraph.Name = "OpenGlControlGraph";
            this.OpenGlControlGraph.Size = new System.Drawing.Size(1000, 634);
            this.OpenGlControlGraph.StencilBits = ((byte)(0));
            this.OpenGlControlGraph.TabIndex = 3;
            this.OpenGlControlGraph.SizeChanged += new System.EventHandler(this.OpenGlControlGraph_SizeChanged);
            this.OpenGlControlGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenGlControlGraph_Paint);
            this.OpenGlControlGraph.Resize += new System.EventHandler(this.OpenGlControlGraph_Resize);
            // 
            // tableLayoutPanelScroll
            // 
            this.tableLayoutPanelScroll.ColumnCount = 2;
            this.tableLayoutPanelScroll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelScroll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanelScroll.Controls.Add(this.toolStripGraphTools, 1, 0);
            this.tableLayoutPanelScroll.Controls.Add(this.hScrollBarGraph, 0, 0);
            this.tableLayoutPanelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelScroll.Location = new System.Drawing.Point(3, 643);
            this.tableLayoutPanelScroll.Name = "tableLayoutPanelScroll";
            this.tableLayoutPanelScroll.RowCount = 1;
            this.tableLayoutPanelScroll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelScroll.Size = new System.Drawing.Size(1000, 34);
            this.tableLayoutPanelScroll.TabIndex = 4;
            // 
            // toolStripGraphTools
            // 
            this.toolStripGraphTools.AutoSize = false;
            this.toolStripGraphTools.CanOverflow = false;
            this.toolStripGraphTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripGraphTools.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStripGraphTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonGraphZoomIn,
            this.toolStripButtonGraphZoomOut,
            this.toolStripButtonGraphFullView,
            this.toolStripButtonGraphSave});
            this.toolStripGraphTools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripGraphTools.Location = new System.Drawing.Point(870, 0);
            this.toolStripGraphTools.Name = "toolStripGraphTools";
            this.toolStripGraphTools.Size = new System.Drawing.Size(130, 34);
            this.toolStripGraphTools.TabIndex = 17;
            this.toolStripGraphTools.Text = "toolStripGraph";
            // 
            // toolStripButtonGraphZoomIn
            // 
            this.toolStripButtonGraphZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGraphZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGraphZoomIn.Image")));
            this.toolStripButtonGraphZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGraphZoomIn.Name = "toolStripButtonGraphZoomIn";
            this.toolStripButtonGraphZoomIn.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonGraphZoomIn.Text = "Приблизить";
            this.toolStripButtonGraphZoomIn.Click += new System.EventHandler(this.toolStripButtonGraphZoomIn_Click);
            // 
            // toolStripButtonGraphZoomOut
            // 
            this.toolStripButtonGraphZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGraphZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGraphZoomOut.Image")));
            this.toolStripButtonGraphZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGraphZoomOut.Name = "toolStripButtonGraphZoomOut";
            this.toolStripButtonGraphZoomOut.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonGraphZoomOut.Text = "Отдалить";
            this.toolStripButtonGraphZoomOut.Click += new System.EventHandler(this.toolStripButtonGraphZoomOut_Click);
            // 
            // toolStripButtonGraphFullView
            // 
            this.toolStripButtonGraphFullView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGraphFullView.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGraphFullView.Image")));
            this.toolStripButtonGraphFullView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGraphFullView.Name = "toolStripButtonGraphFullView";
            this.toolStripButtonGraphFullView.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonGraphFullView.Text = "Показать весь график";
            this.toolStripButtonGraphFullView.Click += new System.EventHandler(this.toolStripButtonGraphFullView_Click);
            // 
            // toolStripButtonGraphSave
            // 
            this.toolStripButtonGraphSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonGraphSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGraphSave.Image")));
            this.toolStripButtonGraphSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGraphSave.Name = "toolStripButtonGraphSave";
            this.toolStripButtonGraphSave.Size = new System.Drawing.Size(32, 32);
            this.toolStripButtonGraphSave.Text = "Сохранить график";
            this.toolStripButtonGraphSave.Click += new System.EventHandler(this.toolStripButtonGraphSave_Click);
            // 
            // hScrollBarGraph
            // 
            this.hScrollBarGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBarGraph.LargeChange = 1;
            this.hScrollBarGraph.Location = new System.Drawing.Point(0, 0);
            this.hScrollBarGraph.Maximum = 0;
            this.hScrollBarGraph.Name = "hScrollBarGraph";
            this.hScrollBarGraph.Size = new System.Drawing.Size(870, 34);
            this.hScrollBarGraph.TabIndex = 5;
            this.hScrollBarGraph.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // tabPageTimeSpeed
            // 
            this.tabPageTimeSpeed.Controls.Add(this.zedGraphControlTimeSpeed);
            this.tabPageTimeSpeed.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimeSpeed.Name = "tabPageTimeSpeed";
            this.tabPageTimeSpeed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTimeSpeed.Size = new System.Drawing.Size(1012, 686);
            this.tabPageTimeSpeed.TabIndex = 4;
            this.tabPageTimeSpeed.Text = "Время - частота вращения";
            this.tabPageTimeSpeed.UseVisualStyleBackColor = true;
            // 
            // zedGraphControlTimeSpeed
            // 
            this.zedGraphControlTimeSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlTimeSpeed.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControlTimeSpeed.Name = "zedGraphControlTimeSpeed";
            this.zedGraphControlTimeSpeed.ScrollGrace = 0D;
            this.zedGraphControlTimeSpeed.ScrollMaxX = 0D;
            this.zedGraphControlTimeSpeed.ScrollMaxY = 0D;
            this.zedGraphControlTimeSpeed.ScrollMaxY2 = 0D;
            this.zedGraphControlTimeSpeed.ScrollMinX = 0D;
            this.zedGraphControlTimeSpeed.ScrollMinY = 0D;
            this.zedGraphControlTimeSpeed.ScrollMinY2 = 0D;
            this.zedGraphControlTimeSpeed.Size = new System.Drawing.Size(1006, 680);
            this.zedGraphControlTimeSpeed.TabIndex = 1;
            // 
            // tabPageTimeAcceleration
            // 
            this.tabPageTimeAcceleration.Controls.Add(this.zedGraphControlTimeAcceleration);
            this.tabPageTimeAcceleration.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimeAcceleration.Name = "tabPageTimeAcceleration";
            this.tabPageTimeAcceleration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTimeAcceleration.Size = new System.Drawing.Size(1012, 686);
            this.tabPageTimeAcceleration.TabIndex = 1;
            this.tabPageTimeAcceleration.Text = "Время - ускорение";
            this.tabPageTimeAcceleration.UseVisualStyleBackColor = true;
            // 
            // zedGraphControlTimeAcceleration
            // 
            this.zedGraphControlTimeAcceleration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlTimeAcceleration.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControlTimeAcceleration.Name = "zedGraphControlTimeAcceleration";
            this.zedGraphControlTimeAcceleration.ScrollGrace = 0D;
            this.zedGraphControlTimeAcceleration.ScrollMaxX = 0D;
            this.zedGraphControlTimeAcceleration.ScrollMaxY = 0D;
            this.zedGraphControlTimeAcceleration.ScrollMaxY2 = 0D;
            this.zedGraphControlTimeAcceleration.ScrollMinX = 0D;
            this.zedGraphControlTimeAcceleration.ScrollMinY = 0D;
            this.zedGraphControlTimeAcceleration.ScrollMinY2 = 0D;
            this.zedGraphControlTimeAcceleration.Size = new System.Drawing.Size(1006, 680);
            this.zedGraphControlTimeAcceleration.TabIndex = 0;
            // 
            // tabPageSpeedAcceleration
            // 
            this.tabPageSpeedAcceleration.Controls.Add(this.zedGraphControlSpeedAcceleration);
            this.tabPageSpeedAcceleration.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpeedAcceleration.Name = "tabPageSpeedAcceleration";
            this.tabPageSpeedAcceleration.Size = new System.Drawing.Size(1012, 686);
            this.tabPageSpeedAcceleration.TabIndex = 2;
            this.tabPageSpeedAcceleration.Text = "Частота врещения - ускорение";
            this.tabPageSpeedAcceleration.UseVisualStyleBackColor = true;
            // 
            // zedGraphControlSpeedAcceleration
            // 
            this.zedGraphControlSpeedAcceleration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlSpeedAcceleration.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlSpeedAcceleration.Name = "zedGraphControlSpeedAcceleration";
            this.zedGraphControlSpeedAcceleration.ScrollGrace = 0D;
            this.zedGraphControlSpeedAcceleration.ScrollMaxX = 0D;
            this.zedGraphControlSpeedAcceleration.ScrollMaxY = 0D;
            this.zedGraphControlSpeedAcceleration.ScrollMaxY2 = 0D;
            this.zedGraphControlSpeedAcceleration.ScrollMinX = 0D;
            this.zedGraphControlSpeedAcceleration.ScrollMinY = 0D;
            this.zedGraphControlSpeedAcceleration.ScrollMinY2 = 0D;
            this.zedGraphControlSpeedAcceleration.Size = new System.Drawing.Size(1012, 686);
            this.zedGraphControlSpeedAcceleration.TabIndex = 1;
            // 
            // tabPageReport
            // 
            this.tabPageReport.Controls.Add(this.richTextBoxReport);
            this.tabPageReport.Location = new System.Drawing.Point(4, 22);
            this.tabPageReport.Name = "tabPageReport";
            this.tabPageReport.Size = new System.Drawing.Size(1012, 686);
            this.tabPageReport.TabIndex = 3;
            this.tabPageReport.Text = "Отчёт";
            this.tabPageReport.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReport
            // 
            this.richTextBoxReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxReport.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxReport.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReport.Name = "richTextBoxReport";
            this.richTextBoxReport.Size = new System.Drawing.Size(1012, 686);
            this.richTextBoxReport.TabIndex = 0;
            this.richTextBoxReport.Text = "";
            this.richTextBoxReport.WordWrap = false;
            // 
            // tabPageTimeSpeedAcc
            // 
            this.tabPageTimeSpeedAcc.Controls.Add(this.zedGraphControlTimeSpeedAcc);
            this.tabPageTimeSpeedAcc.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimeSpeedAcc.Name = "tabPageTimeSpeedAcc";
            this.tabPageTimeSpeedAcc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTimeSpeedAcc.Size = new System.Drawing.Size(1012, 686);
            this.tabPageTimeSpeedAcc.TabIndex = 5;
            this.tabPageTimeSpeedAcc.Text = "Время - скорость + ускорение";
            this.tabPageTimeSpeedAcc.UseVisualStyleBackColor = true;
            // 
            // zedGraphControlTimeSpeedAcc
            // 
            this.zedGraphControlTimeSpeedAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlTimeSpeedAcc.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControlTimeSpeedAcc.Name = "zedGraphControlTimeSpeedAcc";
            this.zedGraphControlTimeSpeedAcc.ScrollGrace = 0D;
            this.zedGraphControlTimeSpeedAcc.ScrollMaxX = 0D;
            this.zedGraphControlTimeSpeedAcc.ScrollMaxY = 0D;
            this.zedGraphControlTimeSpeedAcc.ScrollMaxY2 = 0D;
            this.zedGraphControlTimeSpeedAcc.ScrollMinX = 0D;
            this.zedGraphControlTimeSpeedAcc.ScrollMinY = 0D;
            this.zedGraphControlTimeSpeedAcc.ScrollMinY2 = 0D;
            this.zedGraphControlTimeSpeedAcc.Size = new System.Drawing.Size(1006, 680);
            this.zedGraphControlTimeSpeedAcc.TabIndex = 2;
            // 
            // tabPageFilter
            // 
            this.tabPageFilter.Controls.Add(this.tableLayoutPanelFilterTop);
            this.tabPageFilter.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilter.Name = "tabPageFilter";
            this.tabPageFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilter.Size = new System.Drawing.Size(1012, 686);
            this.tabPageFilter.TabIndex = 6;
            this.tabPageFilter.Text = "Фильтрация данных";
            this.tabPageFilter.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelFilterTop
            // 
            this.tableLayoutPanelFilterTop.ColumnCount = 1;
            this.tableLayoutPanelFilterTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFilterTop.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanelFilterTop.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanelFilterTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFilterTop.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelFilterTop.Name = "tableLayoutPanelFilterTop";
            this.tableLayoutPanelFilterTop.RowCount = 2;
            this.tableLayoutPanelFilterTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFilterTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFilterTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelFilterTop.Size = new System.Drawing.Size(1006, 680);
            this.tableLayoutPanelFilterTop.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.zedGraphControlFiltered);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 343);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 334);
            this.panel3.TabIndex = 2;
            // 
            // zedGraphControlFiltered
            // 
            this.zedGraphControlFiltered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlFiltered.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlFiltered.Name = "zedGraphControlFiltered";
            this.zedGraphControlFiltered.ScrollGrace = 0D;
            this.zedGraphControlFiltered.ScrollMaxX = 0D;
            this.zedGraphControlFiltered.ScrollMaxY = 0D;
            this.zedGraphControlFiltered.ScrollMaxY2 = 0D;
            this.zedGraphControlFiltered.ScrollMinX = 0D;
            this.zedGraphControlFiltered.ScrollMinY = 0D;
            this.zedGraphControlFiltered.ScrollMinY2 = 0D;
            this.zedGraphControlFiltered.Size = new System.Drawing.Size(1000, 334);
            this.zedGraphControlFiltered.TabIndex = 0;
            this.zedGraphControlFiltered.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.zedGraphControlFiltered_ZoomEvent);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.zedGraphControlSource);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 334);
            this.panel2.TabIndex = 2;
            // 
            // zedGraphControlSource
            // 
            this.zedGraphControlSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlSource.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlSource.Name = "zedGraphControlSource";
            this.zedGraphControlSource.ScrollGrace = 0D;
            this.zedGraphControlSource.ScrollMaxX = 0D;
            this.zedGraphControlSource.ScrollMaxY = 0D;
            this.zedGraphControlSource.ScrollMaxY2 = 0D;
            this.zedGraphControlSource.ScrollMinX = 0D;
            this.zedGraphControlSource.ScrollMinY = 0D;
            this.zedGraphControlSource.ScrollMinY2 = 0D;
            this.zedGraphControlSource.Size = new System.Drawing.Size(1000, 334);
            this.zedGraphControlSource.TabIndex = 0;
            this.zedGraphControlSource.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.zedGraphControlSource_ZoomEvent);
            // 
            // tabPageDegreeSpeed
            // 
            this.tabPageDegreeSpeed.Controls.Add(this.zedGraphControlDegreeSpeed);
            this.tabPageDegreeSpeed.Location = new System.Drawing.Point(4, 22);
            this.tabPageDegreeSpeed.Name = "tabPageDegreeSpeed";
            this.tabPageDegreeSpeed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDegreeSpeed.Size = new System.Drawing.Size(1012, 686);
            this.tabPageDegreeSpeed.TabIndex = 7;
            this.tabPageDegreeSpeed.Text = "Угол поворота - частота вращения";
            this.tabPageDegreeSpeed.UseVisualStyleBackColor = true;
            // 
            // zedGraphControlDegreeSpeed
            // 
            this.zedGraphControlDegreeSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlDegreeSpeed.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControlDegreeSpeed.Name = "zedGraphControlDegreeSpeed";
            this.zedGraphControlDegreeSpeed.ScrollGrace = 0D;
            this.zedGraphControlDegreeSpeed.ScrollMaxX = 0D;
            this.zedGraphControlDegreeSpeed.ScrollMaxY = 0D;
            this.zedGraphControlDegreeSpeed.ScrollMaxY2 = 0D;
            this.zedGraphControlDegreeSpeed.ScrollMinX = 0D;
            this.zedGraphControlDegreeSpeed.ScrollMinY = 0D;
            this.zedGraphControlDegreeSpeed.ScrollMinY2 = 0D;
            this.zedGraphControlDegreeSpeed.Size = new System.Drawing.Size(1006, 680);
            this.zedGraphControlDegreeSpeed.TabIndex = 0;
            // 
            // tabPageDegreeAcc
            // 
            this.tabPageDegreeAcc.Controls.Add(this.zedGraphControlDegreeAcc);
            this.tabPageDegreeAcc.Location = new System.Drawing.Point(4, 22);
            this.tabPageDegreeAcc.Name = "tabPageDegreeAcc";
            this.tabPageDegreeAcc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDegreeAcc.Size = new System.Drawing.Size(1012, 686);
            this.tabPageDegreeAcc.TabIndex = 8;
            this.tabPageDegreeAcc.Text = "Угол поворота - ускорение";
            this.tabPageDegreeAcc.UseVisualStyleBackColor = true;
            // 
            // zedGraphControlDegreeAcc
            // 
            this.zedGraphControlDegreeAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlDegreeAcc.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControlDegreeAcc.Name = "zedGraphControlDegreeAcc";
            this.zedGraphControlDegreeAcc.ScrollGrace = 0D;
            this.zedGraphControlDegreeAcc.ScrollMaxX = 0D;
            this.zedGraphControlDegreeAcc.ScrollMaxY = 0D;
            this.zedGraphControlDegreeAcc.ScrollMaxY2 = 0D;
            this.zedGraphControlDegreeAcc.ScrollMinX = 0D;
            this.zedGraphControlDegreeAcc.ScrollMinY = 0D;
            this.zedGraphControlDegreeAcc.ScrollMinY2 = 0D;
            this.zedGraphControlDegreeAcc.Size = new System.Drawing.Size(1006, 680);
            this.zedGraphControlDegreeAcc.TabIndex = 0;
            // 
            // saveFileDialogGraph
            // 
            this.saveFileDialogGraph.DefaultExt = "bmp";
            this.saveFileDialogGraph.FileName = "bmp";
            this.saveFileDialogGraph.Filter = "bmp files|*.bmp";
            this.saveFileDialogGraph.RestoreDirectory = true;
            // 
            // explorerTreeMain
            // 
            this.explorerTreeMain.BackColor = System.Drawing.Color.White;
            this.explorerTreeMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.explorerTreeMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.explorerTreeMain.Location = new System.Drawing.Point(0, 0);
            this.explorerTreeMain.Name = "explorerTreeMain";
            this.explorerTreeMain.SelectedPath = "C:\\Program Files\\Microsoft Visual Studio 10.0\\Common7\\IDE";
            this.explorerTreeMain.ShowAddressbar = true;
            this.explorerTreeMain.ShowMyDocuments = true;
            this.explorerTreeMain.ShowMyFavorites = true;
            this.explorerTreeMain.ShowMyNetwork = true;
            this.explorerTreeMain.ShowToolbar = true;
            this.explorerTreeMain.Size = new System.Drawing.Size(252, 422);
            this.explorerTreeMain.TabIndex = 0;
            this.explorerTreeMain.PathChanged += new WindowsExplorer.ExplorerTree.PathChangedEventHandler(this.explorerTreeMain_PathChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1276, 763);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripMainMenu);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Анализатор вращетельного движения";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripMainMenu.ResumeLayout(false);
            this.toolStripMainMenu.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerTreeFilePath.Panel1.ResumeLayout(false);
            this.splitContainerTreeFilePath.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeFilePath)).EndInit();
            this.splitContainerTreeFilePath.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGraphFile.ResumeLayout(false);
            this.tableLayoutPanelGraphMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphData)).EndInit();
            this.tableLayoutPanelScroll.ResumeLayout(false);
            this.toolStripGraphTools.ResumeLayout(false);
            this.toolStripGraphTools.PerformLayout();
            this.tabPageTimeSpeed.ResumeLayout(false);
            this.tabPageTimeAcceleration.ResumeLayout(false);
            this.tabPageSpeedAcceleration.ResumeLayout(false);
            this.tabPageReport.ResumeLayout(false);
            this.tabPageTimeSpeedAcc.ResumeLayout(false);
            this.tabPageFilter.ResumeLayout(false);
            this.tableLayoutPanelFilterTop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPageDegreeSpeed.ResumeLayout(false);
            this.tabPageDegreeAcc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSA;
        private System.Windows.Forms.ToolStripMenuItem mnuST;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSD;
        private System.Windows.Forms.ToolStripMenuItem mnuSN;
        private System.Windows.Forms.ToolStripMenuItem mnuSF;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuSFExperimentTime;
        private System.Windows.Forms.ToolStripMenuItem mnuSFKadrsNumber;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuSFInputTimeInSec;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCalc;
        private System.Windows.Forms.ToolStripMenuItem menuShowGrap;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSaveGraph;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStrip toolStripMainMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowGraph;
        private System.Windows.Forms.ToolStripButton toolStripButtonCalc;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveReport;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSaveReportAs;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.SaveFileDialog saveFileReportDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelWidthDiff;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxParam;
        private System.Windows.Forms.ToolStripButton toolStripButtonIncParam;
        private System.Windows.Forms.ToolStripButton toolStripButtonDecParam;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerTreeFilePath;
        //private WindowsExplorer.ExplorerTree explorerTreeMain;
        private System.Windows.Forms.DataGridView dataGridViewFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageGraphFile;
        private System.Windows.Forms.TabPage tabPageTimeSpeed;
        private ZedGraph.ZedGraphControl zedGraphControlTimeSpeed;
        private System.Windows.Forms.TabPage tabPageTimeAcceleration;
        private ZedGraph.ZedGraphControl zedGraphControlTimeAcceleration;
        private System.Windows.Forms.TabPage tabPageSpeedAcceleration;
        private ZedGraph.ZedGraphControl zedGraphControlSpeedAcceleration;
        private System.Windows.Forms.TabPage tabPageReport;
        private System.Windows.Forms.RichTextBox richTextBoxReport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGraphMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScroll;
        private System.Windows.Forms.ToolStrip toolStripGraphTools;
        private System.Windows.Forms.ToolStripButton toolStripButtonGraphZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonGraphZoomOut;
        private System.Windows.Forms.ToolStripButton toolStripButtonGraphFullView;
        private System.Windows.Forms.ToolStripButton toolStripButtonGraphSave;
        private System.Windows.Forms.HScrollBar hScrollBarGraph;
        private Tao.Platform.Windows.SimpleOpenGlControl OpenGlControlGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxGraphData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripOutStep;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxOutStep;
        private System.Windows.Forms.ToolStripButton toolStripButtonIncOutStep;
        private System.Windows.Forms.ToolStripButton toolStripButtonDecOutStep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabelInStep;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxInStep;
        private System.Windows.Forms.ToolStripButton toolStripButtonIncInStep;
        private System.Windows.Forms.ToolStripButton toolStripButtonDecInStep;
        private System.Windows.Forms.SaveFileDialog saveFileDialogGraph;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSmooth;
        private System.Windows.Forms.ToolStripLabel toolStripLabelGauss;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxWidthGauss;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonReCalc;
        private System.Windows.Forms.ToolStripButton toolStripButtonFindEvent;
        private System.Windows.Forms.ToolStripMenuItem ReCalcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findEventsToolStripMenuItem;
        private WindowsExplorer.ExplorerTree explorerTreeMain;
        private System.Windows.Forms.TabPage tabPageTimeSpeedAcc;
        private ZedGraph.ZedGraphControl zedGraphControlTimeSpeedAcc;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSelectTypeSeach;
        private System.Windows.Forms.ToolStripMenuItem addEventsToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFilterTop;
        private System.Windows.Forms.ToolStripMenuItem FilterDataSourceToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private ZedGraph.ZedGraphControl zedGraphControlFiltered;
        private ZedGraph.ZedGraphControl zedGraphControlSource;
        private System.Windows.Forms.TabPage tabPageDegreeSpeed;
        private ZedGraph.ZedGraphControl zedGraphControlDegreeSpeed;
        private System.Windows.Forms.TabPage tabPageDegreeAcc;
        private ZedGraph.ZedGraphControl zedGraphControlDegreeAcc;
    }
}

