namespace TSP
{
    partial class frmInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInterface));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.picPlot = new System.Windows.Forms.PictureBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveImageOfMap = new System.Windows.Forms.Button();
            this.butMake = new System.Windows.Forms.Button();
            this.btnShowWeight = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblRegeneration = new System.Windows.Forms.Label();
            this.numReg = new System.Windows.Forms.NumericUpDown();
            this.lblPopulation = new System.Windows.Forms.Label();
            this.numPopulation = new System.Windows.Forms.NumericUpDown();
            this.lblVal = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.plotter = new GraphLib.PlotterDisplayEx();
            this.btnSolve = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtMaxTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkImperialist = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numImperialists = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numEpoch = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numPopICA = new System.Windows.Forms.NumericUpDown();
            this.btnStopICA = new System.Windows.Forms.Button();
            this.btnSaveImageICA = new System.Windows.Forms.Button();
            this.lblValICA = new System.Windows.Forms.Label();
            this.btnSolveICA = new System.Windows.Forms.Button();
            this.plotterICA = new GraphLib.PlotterDisplayEx();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.nudR = new System.Windows.Forms.NumericUpDown();
            this.lblR = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblDX = new System.Windows.Forms.Label();
            this.nudDy = new System.Windows.Forms.NumericUpDown();
            this.nudDX = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.txtLanda = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numEDU = new System.Windows.Forms.NumericUpDown();
            this.lblSOM = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numNN = new System.Windows.Forms.NumericUpDown();
            this.cmdLearn = new System.Windows.Forms.Button();
            this.picSOM = new System.Windows.Forms.PictureBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbSetting = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.nudStopIteration = new System.Windows.Forms.NumericUpDown();
            this.chkItTerm = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.chkBubble = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.nudBubbleIndv = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.nudBubMaxIt = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.nudBubGroup = new System.Windows.Forms.NumericUpDown();
            this.lblReportBub = new System.Windows.Forms.Label();
            this.btnBubble = new System.Windows.Forms.Button();
            this.picBubble = new System.Windows.Forms.PictureBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.btnStopMem = new System.Windows.Forms.Button();
            this.lblMEMSOM = new System.Windows.Forms.Label();
            this.btnSaveMemSOM = new System.Windows.Forms.Button();
            this.chkMEMShow = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numMEMEDU = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numMEMpop = new System.Windows.Forms.NumericUpDown();
            this.btnSolvememetic = new System.Windows.Forms.Button();
            this.picMEMSOM = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblTourlength = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSaveMap = new System.Windows.Forms.Button();
            this.picLast = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdlg = new System.Windows.Forms.OpenFileDialog();
            this.cmdSave = new System.Windows.Forms.SaveFileDialog();
            this.openBMP = new System.Windows.Forms.OpenFileDialog();
            this.saveTSP = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlot)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulation)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImperialists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpoch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopICA)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLanda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEDU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSOM)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopIteration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBubbleIndv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBubMaxIt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBubGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBubble)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMEMEDU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMEMpop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMEMSOM)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLast)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(10, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(733, 418);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picPlot);
            this.tabPage1.Controls.Add(this.txtFileName);
            this.tabPage1.Controls.Add(this.cmdOpen);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(725, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input File";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // picPlot
            // 
            this.picPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPlot.Location = new System.Drawing.Point(286, 49);
            this.picPlot.Name = "picPlot";
            this.picPlot.Size = new System.Drawing.Size(431, 327);
            this.picPlot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlot.TabIndex = 3;
            this.picPlot.TabStop = false;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(286, 15);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(350, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // cmdOpen
            // 
            this.cmdOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOpen.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOpen.Location = new System.Drawing.Point(648, 15);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(70, 20);
            this.cmdOpen.TabIndex = 1;
            this.cmdOpen.Text = "Choose File";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnSaveImageOfMap);
            this.groupBox1.Controls.Add(this.butMake);
            this.groupBox1.Controls.Add(this.btnShowWeight);
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 371);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File information";
            // 
            // btnSaveImageOfMap
            // 
            this.btnSaveImageOfMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveImageOfMap.Location = new System.Drawing.Point(5, 342);
            this.btnSaveImageOfMap.Name = "btnSaveImageOfMap";
            this.btnSaveImageOfMap.Size = new System.Drawing.Size(80, 23);
            this.btnSaveImageOfMap.TabIndex = 3;
            this.btnSaveImageOfMap.Text = "Save Image";
            this.btnSaveImageOfMap.UseVisualStyleBackColor = true;
            this.btnSaveImageOfMap.Click += new System.EventHandler(this.btnSaveImageOfMap_Click);
            // 
            // butMake
            // 
            this.butMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMake.Location = new System.Drawing.Point(91, 342);
            this.butMake.Name = "butMake";
            this.butMake.Size = new System.Drawing.Size(75, 23);
            this.butMake.TabIndex = 2;
            this.butMake.Text = "Make Map";
            this.butMake.UseVisualStyleBackColor = true;
            this.butMake.Click += new System.EventHandler(this.butMake_Click);
            // 
            // btnShowWeight
            // 
            this.btnShowWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowWeight.Location = new System.Drawing.Point(171, 342);
            this.btnShowWeight.Name = "btnShowWeight";
            this.btnShowWeight.Size = new System.Drawing.Size(97, 23);
            this.btnShowWeight.TabIndex = 1;
            this.btnShowWeight.Text = "Show Distances";
            this.btnShowWeight.UseVisualStyleBackColor = true;
            this.btnShowWeight.Click += new System.EventHandler(this.btnShowWeight_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(20, 27);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblRegeneration);
            this.tabPage2.Controls.Add(this.numReg);
            this.tabPage2.Controls.Add(this.lblPopulation);
            this.tabPage2.Controls.Add(this.numPopulation);
            this.tabPage2.Controls.Add(this.lblVal);
            this.tabPage2.Controls.Add(this.btnStop);
            this.tabPage2.Controls.Add(this.btnSaveImage);
            this.tabPage2.Controls.Add(this.plotter);
            this.tabPage2.Controls.Add(this.btnSolve);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(725, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Solver (GA)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblRegeneration
            // 
            this.lblRegeneration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegeneration.AutoSize = true;
            this.lblRegeneration.Location = new System.Drawing.Point(644, 145);
            this.lblRegeneration.Name = "lblRegeneration";
            this.lblRegeneration.Size = new System.Drawing.Size(56, 26);
            this.lblRegeneration.TabIndex = 8;
            this.lblRegeneration.Text = "Number of\r\niterations:";
            // 
            // numReg
            // 
            this.numReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numReg.Location = new System.Drawing.Point(645, 174);
            this.numReg.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numReg.Name = "numReg";
            this.numReg.Size = new System.Drawing.Size(74, 20);
            this.numReg.TabIndex = 7;
            this.numReg.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // lblPopulation
            // 
            this.lblPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPopulation.AutoSize = true;
            this.lblPopulation.Location = new System.Drawing.Point(644, 106);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(60, 13);
            this.lblPopulation.TabIndex = 6;
            this.lblPopulation.Text = "Population:";
            // 
            // numPopulation
            // 
            this.numPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numPopulation.Location = new System.Drawing.Point(645, 122);
            this.numPopulation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPopulation.Name = "numPopulation";
            this.numPopulation.Size = new System.Drawing.Size(74, 20);
            this.numPopulation.TabIndex = 5;
            this.numPopulation.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // lblVal
            // 
            this.lblVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVal.AutoSize = true;
            this.lblVal.Location = new System.Drawing.Point(6, 351);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(0, 13);
            this.lblVal.TabIndex = 4;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(644, 64);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveImage.Location = new System.Drawing.Point(644, 35);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveImage.TabIndex = 2;
            this.btnSaveImage.Text = "Save Picture";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // plotter
            // 
            this.plotter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotter.AutoSize = true;
            this.plotter.BackColor = System.Drawing.Color.Transparent;
            this.plotter.BackgroundColorBot = System.Drawing.Color.DimGray;
            this.plotter.BackgroundColorTop = System.Drawing.Color.Gainsboro;
            this.plotter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plotter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plotter.DashedGridColor = System.Drawing.Color.DarkGray;
            this.plotter.DoubleBuffering = true;
            this.plotter.Location = new System.Drawing.Point(6, 6);
            this.plotter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.plotter.Name = "plotter";
            this.plotter.PlaySpeed = 0.5F;
            this.plotter.Size = new System.Drawing.Size(632, 342);
            this.plotter.SolidGridColor = System.Drawing.Color.DarkGray;
            this.plotter.TabIndex = 1;
            // 
            // btnSolve
            // 
            this.btnSolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolve.Location = new System.Drawing.Point(644, 6);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 0;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtMaxTime);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.chkImperialist);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.numImperialists);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.numEpoch);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.numPopICA);
            this.tabPage5.Controls.Add(this.btnStopICA);
            this.tabPage5.Controls.Add(this.btnSaveImageICA);
            this.tabPage5.Controls.Add(this.lblValICA);
            this.tabPage5.Controls.Add(this.btnSolveICA);
            this.tabPage5.Controls.Add(this.plotterICA);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(725, 392);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Solver (ICA)";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxTime.Location = new System.Drawing.Point(642, 279);
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.Size = new System.Drawing.Size(74, 20);
            this.txtMaxTime.TabIndex = 19;
            this.txtMaxTime.Text = "59.50963";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(641, 250);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 26);
            this.label12.TabIndex = 18;
            this.label12.Text = "Maximum \r\nrunning time (s):";
            // 
            // chkImperialist
            // 
            this.chkImperialist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkImperialist.AutoSize = true;
            this.chkImperialist.Location = new System.Drawing.Point(3, 363);
            this.chkImperialist.Name = "chkImperialist";
            this.chkImperialist.Size = new System.Drawing.Size(136, 17);
            this.chkImperialist.TabIndex = 17;
            this.chkImperialist.Text = "Enhance ICA operators";
            this.chkImperialist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkImperialist.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(641, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "Number of\r\nimperialists:";
            // 
            // numImperialists
            // 
            this.numImperialists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numImperialists.Location = new System.Drawing.Point(642, 223);
            this.numImperialists.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numImperialists.Name = "numImperialists";
            this.numImperialists.Size = new System.Drawing.Size(74, 20);
            this.numImperialists.TabIndex = 15;
            this.numImperialists.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Number of\r\niterations:";
            // 
            // numEpoch
            // 
            this.numEpoch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numEpoch.Location = new System.Drawing.Point(642, 171);
            this.numEpoch.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numEpoch.Name = "numEpoch";
            this.numEpoch.Size = new System.Drawing.Size(74, 20);
            this.numEpoch.TabIndex = 13;
            this.numEpoch.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(641, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Population:";
            // 
            // numPopICA
            // 
            this.numPopICA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numPopICA.Location = new System.Drawing.Point(642, 119);
            this.numPopICA.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPopICA.Name = "numPopICA";
            this.numPopICA.Size = new System.Drawing.Size(74, 20);
            this.numPopICA.TabIndex = 11;
            this.numPopICA.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // btnStopICA
            // 
            this.btnStopICA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopICA.Location = new System.Drawing.Point(641, 61);
            this.btnStopICA.Name = "btnStopICA";
            this.btnStopICA.Size = new System.Drawing.Size(75, 23);
            this.btnStopICA.TabIndex = 10;
            this.btnStopICA.Text = "Stop";
            this.btnStopICA.UseVisualStyleBackColor = true;
            this.btnStopICA.Click += new System.EventHandler(this.btnStopICA_Click);
            // 
            // btnSaveImageICA
            // 
            this.btnSaveImageICA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveImageICA.Location = new System.Drawing.Point(641, 32);
            this.btnSaveImageICA.Name = "btnSaveImageICA";
            this.btnSaveImageICA.Size = new System.Drawing.Size(75, 23);
            this.btnSaveImageICA.TabIndex = 9;
            this.btnSaveImageICA.Text = "Save Picture";
            this.btnSaveImageICA.UseVisualStyleBackColor = true;
            this.btnSaveImageICA.Click += new System.EventHandler(this.btnSaveImageICA_Click);
            // 
            // lblValICA
            // 
            this.lblValICA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValICA.AutoSize = true;
            this.lblValICA.Location = new System.Drawing.Point(3, 348);
            this.lblValICA.Name = "lblValICA";
            this.lblValICA.Size = new System.Drawing.Size(0, 13);
            this.lblValICA.TabIndex = 5;
            // 
            // btnSolveICA
            // 
            this.btnSolveICA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolveICA.Location = new System.Drawing.Point(641, 3);
            this.btnSolveICA.Name = "btnSolveICA";
            this.btnSolveICA.Size = new System.Drawing.Size(75, 23);
            this.btnSolveICA.TabIndex = 3;
            this.btnSolveICA.Text = "Solve";
            this.btnSolveICA.UseVisualStyleBackColor = true;
            this.btnSolveICA.Click += new System.EventHandler(this.btnSolveICA_Click);
            // 
            // plotterICA
            // 
            this.plotterICA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotterICA.AutoSize = true;
            this.plotterICA.BackColor = System.Drawing.Color.Transparent;
            this.plotterICA.BackgroundColorBot = System.Drawing.Color.DimGray;
            this.plotterICA.BackgroundColorTop = System.Drawing.Color.Gainsboro;
            this.plotterICA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plotterICA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plotterICA.DashedGridColor = System.Drawing.Color.DarkGray;
            this.plotterICA.DoubleBuffering = true;
            this.plotterICA.Location = new System.Drawing.Point(3, 3);
            this.plotterICA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.plotterICA.Name = "plotterICA";
            this.plotterICA.PlaySpeed = 0.5F;
            this.plotterICA.Size = new System.Drawing.Size(632, 342);
            this.plotterICA.SolidGridColor = System.Drawing.Color.DarkGray;
            this.plotterICA.TabIndex = 2;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.nudR);
            this.tabPage6.Controls.Add(this.lblR);
            this.tabPage6.Controls.Add(this.label19);
            this.tabPage6.Controls.Add(this.lblDX);
            this.tabPage6.Controls.Add(this.nudDy);
            this.tabPage6.Controls.Add(this.nudDX);
            this.tabPage6.Controls.Add(this.button1);
            this.tabPage6.Controls.Add(this.chkShow);
            this.tabPage6.Controls.Add(this.txtLanda);
            this.tabPage6.Controls.Add(this.label8);
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.Controls.Add(this.numEDU);
            this.tabPage6.Controls.Add(this.lblSOM);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Controls.Add(this.numNN);
            this.tabPage6.Controls.Add(this.cmdLearn);
            this.tabPage6.Controls.Add(this.picSOM);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(725, 392);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "KNIES";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // nudR
            // 
            this.nudR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudR.Location = new System.Drawing.Point(677, 289);
            this.nudR.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudR.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudR.Name = "nudR";
            this.nudR.Size = new System.Drawing.Size(39, 20);
            this.nudR.TabIndex = 21;
            this.nudR.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblR
            // 
            this.lblR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(643, 290);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(35, 13);
            this.lblR.TabIndex = 22;
            this.lblR.Text = "Ratio:";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(643, 264);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Dy:";
            // 
            // lblDX
            // 
            this.lblDX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDX.AutoSize = true;
            this.lblDX.Location = new System.Drawing.Point(643, 238);
            this.lblDX.Name = "lblDX";
            this.lblDX.Size = new System.Drawing.Size(23, 13);
            this.lblDX.TabIndex = 19;
            this.lblDX.Text = "Dx:";
            // 
            // nudDy
            // 
            this.nudDy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDy.Location = new System.Drawing.Point(677, 263);
            this.nudDy.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDy.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudDy.Name = "nudDy";
            this.nudDy.Size = new System.Drawing.Size(39, 20);
            this.nudDy.TabIndex = 18;
            // 
            // nudDX
            // 
            this.nudDX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDX.Location = new System.Drawing.Point(677, 237);
            this.nudDX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudDX.Name = "nudDX";
            this.nudDX.Size = new System.Drawing.Size(40, 20);
            this.nudDX.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(645, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Save Picture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkShow
            // 
            this.chkShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShow.AutoSize = true;
            this.chkShow.Location = new System.Drawing.Point(645, 214);
            this.chkShow.Name = "chkShow";
            this.chkShow.Size = new System.Drawing.Size(53, 17);
            this.chkShow.TabIndex = 15;
            this.chkShow.Text = "Show";
            this.chkShow.UseVisualStyleBackColor = true;
            // 
            // txtLanda
            // 
            this.txtLanda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLanda.Location = new System.Drawing.Point(665, 191);
            this.txtLanda.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.txtLanda.Name = "txtLanda";
            this.txtLanda.Size = new System.Drawing.Size(51, 20);
            this.txtLanda.TabIndex = 14;
            this.txtLanda.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label8.Location = new System.Drawing.Point(643, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "l";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(643, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 39);
            this.label7.TabIndex = 12;
            this.label7.Text = "Number of\r\nlearning\r\niterations:";
            // 
            // numEDU
            // 
            this.numEDU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numEDU.Location = new System.Drawing.Point(646, 164);
            this.numEDU.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numEDU.Name = "numEDU";
            this.numEDU.Size = new System.Drawing.Size(69, 20);
            this.numEDU.TabIndex = 11;
            this.numEDU.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // lblSOM
            // 
            this.lblSOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSOM.AutoSize = true;
            this.lblSOM.Location = new System.Drawing.Point(3, 365);
            this.lblSOM.Name = "lblSOM";
            this.lblSOM.Size = new System.Drawing.Size(0, 13);
            this.lblSOM.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(643, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "Number of\r\nneurons:";
            // 
            // numNN
            // 
            this.numNN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numNN.Location = new System.Drawing.Point(646, 99);
            this.numNN.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numNN.Name = "numNN";
            this.numNN.Size = new System.Drawing.Size(69, 20);
            this.numNN.TabIndex = 8;
            this.numNN.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cmdLearn
            // 
            this.cmdLearn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLearn.Location = new System.Drawing.Point(644, 6);
            this.cmdLearn.Name = "cmdLearn";
            this.cmdLearn.Size = new System.Drawing.Size(75, 23);
            this.cmdLearn.TabIndex = 7;
            this.cmdLearn.Text = "Learn";
            this.cmdLearn.UseVisualStyleBackColor = true;
            this.cmdLearn.Click += new System.EventHandler(this.cmdLearn_Click);
            // 
            // picSOM
            // 
            this.picSOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picSOM.Location = new System.Drawing.Point(6, 6);
            this.picSOM.Name = "picSOM";
            this.picSOM.Size = new System.Drawing.Size(632, 356);
            this.picSOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSOM.TabIndex = 6;
            this.picSOM.TabStop = false;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.label24);
            this.tabPage10.Controls.Add(this.cmbSetting);
            this.tabPage10.Controls.Add(this.label23);
            this.tabPage10.Controls.Add(this.nudStopIteration);
            this.tabPage10.Controls.Add(this.chkItTerm);
            this.tabPage10.Controls.Add(this.button5);
            this.tabPage10.Controls.Add(this.chkBubble);
            this.tabPage10.Controls.Add(this.label22);
            this.tabPage10.Controls.Add(this.nudBubbleIndv);
            this.tabPage10.Controls.Add(this.label21);
            this.tabPage10.Controls.Add(this.nudBubMaxIt);
            this.tabPage10.Controls.Add(this.label20);
            this.tabPage10.Controls.Add(this.nudBubGroup);
            this.tabPage10.Controls.Add(this.lblReportBub);
            this.tabPage10.Controls.Add(this.btnBubble);
            this.tabPage10.Controls.Add(this.picBubble);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(725, 392);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "PMSOM";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(640, 305);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 32;
            this.label24.Text = "Setting:";
            // 
            // cmbSetting
            // 
            this.cmbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSetting.FormattingEnabled = true;
            this.cmbSetting.Items.AddRange(new object[] {
            "None",
            "(1,1) = (-0.1, 0.1)",
            "(1,2) = (-0.1, 0.01)",
            "(1,3) = (-0.1, 0.001)",
            "(2,1) = (-0.5, 0.1)",
            "(2,2) = (-0.5, 0.01)",
            "(2,3) = (-0.5, 0.001)",
            "(3,1) = (-0.9, 0.1)",
            "(3,2) = (-0.9, 0.01)",
            "(3,3) = (-0.9, 0.001)"});
            this.cmbSetting.Location = new System.Drawing.Point(641, 320);
            this.cmbSetting.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSetting.Name = "cmbSetting";
            this.cmbSetting.Size = new System.Drawing.Size(75, 20);
            this.cmbSetting.TabIndex = 31;
            this.cmbSetting.Text = "None";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(640, 214);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 26);
            this.label23.TabIndex = 30;
            this.label23.Text = "Maximum\r\niteration:";
            // 
            // nudStopIteration
            // 
            this.nudStopIteration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudStopIteration.Location = new System.Drawing.Point(643, 243);
            this.nudStopIteration.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudStopIteration.Name = "nudStopIteration";
            this.nudStopIteration.Size = new System.Drawing.Size(74, 20);
            this.nudStopIteration.TabIndex = 29;
            this.nudStopIteration.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // chkItTerm
            // 
            this.chkItTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkItTerm.AutoSize = true;
            this.chkItTerm.Location = new System.Drawing.Point(643, 285);
            this.chkItTerm.Name = "chkItTerm";
            this.chkItTerm.Size = new System.Drawing.Size(87, 17);
            this.chkItTerm.TabIndex = 28;
            this.chkItTerm.Text = "Use max iter.";
            this.chkItTerm.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(641, 35);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 27;
            this.button5.Text = "Save Picture";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // chkBubble
            // 
            this.chkBubble.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBubble.AutoSize = true;
            this.chkBubble.Checked = true;
            this.chkBubble.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBubble.Location = new System.Drawing.Point(643, 267);
            this.chkBubble.Name = "chkBubble";
            this.chkBubble.Size = new System.Drawing.Size(53, 17);
            this.chkBubble.TabIndex = 26;
            this.chkBubble.Text = "Show";
            this.chkBubble.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(640, 177);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 13);
            this.label22.TabIndex = 22;
            this.label22.Text = "Population size:";
            // 
            // nudBubbleIndv
            // 
            this.nudBubbleIndv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBubbleIndv.Location = new System.Drawing.Point(643, 194);
            this.nudBubbleIndv.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudBubbleIndv.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBubbleIndv.Name = "nudBubbleIndv";
            this.nudBubbleIndv.Size = new System.Drawing.Size(74, 20);
            this.nudBubbleIndv.TabIndex = 21;
            this.nudBubbleIndv.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(640, 110);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 39);
            this.label21.TabIndex = 15;
            this.label21.Text = "Number of\r\nlearning \r\niterations:";
            // 
            // nudBubMaxIt
            // 
            this.nudBubMaxIt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBubMaxIt.Location = new System.Drawing.Point(642, 153);
            this.nudBubMaxIt.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudBubMaxIt.Name = "nudBubMaxIt";
            this.nudBubMaxIt.Size = new System.Drawing.Size(74, 20);
            this.nudBubMaxIt.TabIndex = 14;
            this.nudBubMaxIt.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(640, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 26);
            this.label20.TabIndex = 13;
            this.label20.Text = "Number of\r\nclusters:";
            // 
            // nudBubGroup
            // 
            this.nudBubGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBubGroup.Location = new System.Drawing.Point(641, 90);
            this.nudBubGroup.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBubGroup.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBubGroup.Name = "nudBubGroup";
            this.nudBubGroup.Size = new System.Drawing.Size(74, 20);
            this.nudBubGroup.TabIndex = 12;
            this.nudBubGroup.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblReportBub
            // 
            this.lblReportBub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReportBub.AutoSize = true;
            this.lblReportBub.Location = new System.Drawing.Point(3, 365);
            this.lblReportBub.Name = "lblReportBub";
            this.lblReportBub.Size = new System.Drawing.Size(42, 13);
            this.lblReportBub.TabIndex = 11;
            this.lblReportBub.Text = "Report:";
            // 
            // btnBubble
            // 
            this.btnBubble.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBubble.Location = new System.Drawing.Point(641, 6);
            this.btnBubble.Name = "btnBubble";
            this.btnBubble.Size = new System.Drawing.Size(75, 23);
            this.btnBubble.TabIndex = 9;
            this.btnBubble.Text = "Solve";
            this.btnBubble.UseVisualStyleBackColor = true;
            this.btnBubble.Click += new System.EventHandler(this.btnBubble_Click);
            // 
            // picBubble
            // 
            this.picBubble.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBubble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBubble.Location = new System.Drawing.Point(3, 6);
            this.picBubble.Name = "picBubble";
            this.picBubble.Size = new System.Drawing.Size(632, 356);
            this.picBubble.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBubble.TabIndex = 8;
            this.picBubble.TabStop = false;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.btnStopMem);
            this.tabPage8.Controls.Add(this.lblMEMSOM);
            this.tabPage8.Controls.Add(this.btnSaveMemSOM);
            this.tabPage8.Controls.Add(this.chkMEMShow);
            this.tabPage8.Controls.Add(this.label13);
            this.tabPage8.Controls.Add(this.numMEMEDU);
            this.tabPage8.Controls.Add(this.label14);
            this.tabPage8.Controls.Add(this.numMEMpop);
            this.tabPage8.Controls.Add(this.btnSolvememetic);
            this.tabPage8.Controls.Add(this.picMEMSOM);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(725, 392);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Memetic SOM";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // btnStopMem
            // 
            this.btnStopMem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopMem.Location = new System.Drawing.Point(644, 35);
            this.btnStopMem.Name = "btnStopMem";
            this.btnStopMem.Size = new System.Drawing.Size(75, 24);
            this.btnStopMem.TabIndex = 28;
            this.btnStopMem.Text = "Stop";
            this.btnStopMem.UseVisualStyleBackColor = true;
            this.btnStopMem.Click += new System.EventHandler(this.btnStopMem_Click);
            // 
            // lblMEMSOM
            // 
            this.lblMEMSOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMEMSOM.AutoSize = true;
            this.lblMEMSOM.Location = new System.Drawing.Point(3, 354);
            this.lblMEMSOM.Name = "lblMEMSOM";
            this.lblMEMSOM.Size = new System.Drawing.Size(0, 13);
            this.lblMEMSOM.TabIndex = 27;
            // 
            // btnSaveMemSOM
            // 
            this.btnSaveMemSOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMemSOM.Location = new System.Drawing.Point(644, 66);
            this.btnSaveMemSOM.Name = "btnSaveMemSOM";
            this.btnSaveMemSOM.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMemSOM.TabIndex = 26;
            this.btnSaveMemSOM.Text = "Save Picture";
            this.btnSaveMemSOM.UseVisualStyleBackColor = true;
            this.btnSaveMemSOM.Click += new System.EventHandler(this.btnSaveMemSOM_Click);
            // 
            // chkMEMShow
            // 
            this.chkMEMShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMEMShow.AutoSize = true;
            this.chkMEMShow.Location = new System.Drawing.Point(646, 196);
            this.chkMEMShow.Name = "chkMEMShow";
            this.chkMEMShow.Size = new System.Drawing.Size(53, 17);
            this.chkMEMShow.TabIndex = 25;
            this.chkMEMShow.Text = "Show";
            this.chkMEMShow.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(643, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 39);
            this.label13.TabIndex = 22;
            this.label13.Text = "Number of\r\nlearning\r\niterations:";
            // 
            // numMEMEDU
            // 
            this.numMEMEDU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMEMEDU.Location = new System.Drawing.Point(645, 170);
            this.numMEMEDU.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMEMEDU.Name = "numMEMEDU";
            this.numMEMEDU.Size = new System.Drawing.Size(74, 20);
            this.numMEMEDU.TabIndex = 21;
            this.numMEMEDU.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(643, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Population size:";
            // 
            // numMEMpop
            // 
            this.numMEMpop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMEMpop.Location = new System.Drawing.Point(645, 108);
            this.numMEMpop.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numMEMpop.Name = "numMEMpop";
            this.numMEMpop.Size = new System.Drawing.Size(74, 20);
            this.numMEMpop.TabIndex = 19;
            this.numMEMpop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnSolvememetic
            // 
            this.btnSolvememetic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolvememetic.Location = new System.Drawing.Point(644, 6);
            this.btnSolvememetic.Name = "btnSolvememetic";
            this.btnSolvememetic.Size = new System.Drawing.Size(75, 23);
            this.btnSolvememetic.TabIndex = 18;
            this.btnSolvememetic.Text = "Learn";
            this.btnSolvememetic.UseVisualStyleBackColor = true;
            this.btnSolvememetic.Click += new System.EventHandler(this.btnSolvememetic_Click);
            // 
            // picMEMSOM
            // 
            this.picMEMSOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMEMSOM.Location = new System.Drawing.Point(6, 6);
            this.picMEMSOM.Name = "picMEMSOM";
            this.picMEMSOM.Size = new System.Drawing.Size(632, 345);
            this.picMEMSOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMEMSOM.TabIndex = 17;
            this.picMEMSOM.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblTourlength);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.btnSaveMap);
            this.tabPage3.Controls.Add(this.picLast);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(725, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reporter";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblTourlength
            // 
            this.lblTourlength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTourlength.AutoSize = true;
            this.lblTourlength.Location = new System.Drawing.Point(644, 335);
            this.lblTourlength.Name = "lblTourlength";
            this.lblTourlength.Size = new System.Drawing.Size(35, 13);
            this.lblTourlength.TabIndex = 8;
            this.lblTourlength.Text = "Tour :";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(644, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Clean";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(644, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Draw Optimal ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMap.Location = new System.Drawing.Point(644, 6);
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMap.TabIndex = 5;
            this.btnSaveMap.Text = "Save Picture";
            this.btnSaveMap.UseVisualStyleBackColor = true;
            this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
            // 
            // picLast
            // 
            this.picLast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picLast.Location = new System.Drawing.Point(6, 6);
            this.picLast.Name = "picLast";
            this.picLast.Size = new System.Drawing.Size(632, 371);
            this.picLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLast.TabIndex = 4;
            this.picLast.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Controls.Add(this.linkLabel2);
            this.tabPage4.Controls.Add(this.linkLabel1);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(725, 392);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::TSP.Properties.Resources.Untitled_1;
            this.pictureBox1.Location = new System.Drawing.Point(18, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 278);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(15, 325);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(180, 13);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "E-mail : danialesm@sabanciuniv.edu";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(15, 303);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(223, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "website : myweb.sabanciuniv.edu/danialesm/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 37);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(293, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Programmer: Danial Esmaeili Aliabadi, Edris Esmaeili Aliabadi ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 13);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TSP Solver version 1.11 ";
            // 
            // cmdlg
            // 
            this.cmdlg.Filter = "TSP file|*.tsp";
            this.cmdlg.Title = "Open TSP file";
            // 
            // cmdSave
            // 
            this.cmdSave.Filter = "PNG File|*.PNG";
            // 
            // openBMP
            // 
            this.openBMP.Filter = "Bitmap File|*.BMP";
            // 
            // saveTSP
            // 
            this.saveTSP.Filter = "TSP file|*.tsp";
            // 
            // frmInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 430);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSP Solver (Genetic Algorithm, Imperialist Colony Algorithm, Neural Network)";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlot)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulation)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImperialists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpoch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopICA)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLanda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEDU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSOM)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStopIteration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBubbleIndv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBubMaxIt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBubGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBubble)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMEMEDU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMEMpop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMEMSOM)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLast)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox picPlot;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.OpenFileDialog cmdlg;
        private System.Windows.Forms.Button btnSolve;
        private GraphLib.PlotterDisplayEx plotter;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.SaveFileDialog cmdSave;
        private System.Windows.Forms.PictureBox picLast;
        private System.Windows.Forms.Button btnShowWeight;
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblVal;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRegeneration;
        private System.Windows.Forms.NumericUpDown numReg;
        private System.Windows.Forms.Label lblPopulation;
        private System.Windows.Forms.NumericUpDown numPopulation;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnSolveICA;
        private GraphLib.PlotterDisplayEx plotterICA;
        private System.Windows.Forms.Label lblValICA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numEpoch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPopICA;
        private System.Windows.Forms.Button btnStopICA;
        private System.Windows.Forms.Button btnSaveImageICA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numImperialists;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button cmdLearn;
        private System.Windows.Forms.PictureBox picSOM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numNN;
        private System.Windows.Forms.Label lblSOM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numEDU;
        private System.Windows.Forms.NumericUpDown txtLanda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Button butMake;
        private System.Windows.Forms.OpenFileDialog openBMP;
        private System.Windows.Forms.SaveFileDialog saveTSP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button btnSaveMemSOM;
        private System.Windows.Forms.CheckBox chkMEMShow;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numMEMEDU;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numMEMpop;
        private System.Windows.Forms.Button btnSolvememetic;
        private System.Windows.Forms.PictureBox picMEMSOM;
        private System.Windows.Forms.Label lblMEMSOM;
        private System.Windows.Forms.CheckBox chkImperialist;
        private System.Windows.Forms.TextBox txtMaxTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblTourlength;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.NumericUpDown nudR;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblDX;
        private System.Windows.Forms.NumericUpDown nudDy;
        private System.Windows.Forms.NumericUpDown nudDX;
        private System.Windows.Forms.Button btnStopMem;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.Button btnBubble;
        private System.Windows.Forms.PictureBox picBubble;
        private System.Windows.Forms.Label lblReportBub;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown nudBubGroup;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown nudBubMaxIt;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nudBubbleIndv;
        private System.Windows.Forms.CheckBox chkBubble;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox chkItTerm;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown nudStopIteration;
        private System.Windows.Forms.ComboBox cmbSetting;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnSaveImageOfMap;
    }
}

