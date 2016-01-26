namespace Agilent
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonImportSequence = new System.Windows.Forms.Button();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.labelTitleDescription = new System.Windows.Forms.Label();
            this.buttonRunSequence = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelConnectStatus = new System.Windows.Forms.Label();
            this.splitContainerSequence = new System.Windows.Forms.SplitContainer();
            this.richTextBoxCommand = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDelay = new System.Windows.Forms.RichTextBox();
            this.labelTitleCommand = new System.Windows.Forms.Label();
            this.labelTitleDelay = new System.Windows.Forms.Label();
            this.checkBoxStop = new System.Windows.Forms.CheckBox();
            this.buttonRunSequenceOnce = new System.Windows.Forms.Button();
            this.buttonClearSequence = new System.Windows.Forms.Button();
            this.buttonSaveSequence = new System.Windows.Forms.Button();
            this.panelSequenceFull = new System.Windows.Forms.Panel();
            this.panelSequence = new System.Windows.Forms.Panel();
            this.panelConnect = new System.Windows.Forms.Panel();
            this.panelImportSequence = new System.Windows.Forms.Panel();
            this.panelRunSequence = new System.Windows.Forms.Panel();
            this.buttonStopSequence = new System.Windows.Forms.Button();
            this.labelRunStatus = new System.Windows.Forms.Label();
            this.panelReadout = new System.Windows.Forms.Panel();
            this.buttonPlotReadout = new System.Windows.Forms.Button();
            this.labelTitleResolution = new System.Windows.Forms.Label();
            this.labelTitleReadout = new System.Windows.Forms.Label();
            this.splitContainerReadout = new System.Windows.Forms.SplitContainer();
            this.richTextBoxReadout = new System.Windows.Forms.RichTextBox();
            this.richTextBoxResolution = new System.Windows.Forms.RichTextBox();
            this.buttonClearReadout = new System.Windows.Forms.Button();
            this.buttonSaveReadout = new System.Windows.Forms.Button();
            this.panelReadoutPlot = new System.Windows.Forms.Panel();
            this.chartReadoutPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSequence)).BeginInit();
            this.splitContainerSequence.Panel1.SuspendLayout();
            this.splitContainerSequence.Panel2.SuspendLayout();
            this.splitContainerSequence.SuspendLayout();
            this.panelSequenceFull.SuspendLayout();
            this.panelSequence.SuspendLayout();
            this.panelConnect.SuspendLayout();
            this.panelImportSequence.SuspendLayout();
            this.panelRunSequence.SuspendLayout();
            this.panelReadout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReadout)).BeginInit();
            this.splitContainerReadout.Panel1.SuspendLayout();
            this.splitContainerReadout.Panel2.SuspendLayout();
            this.splitContainerReadout.SuspendLayout();
            this.panelReadoutPlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReadoutPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImportSequence
            // 
            this.buttonImportSequence.Location = new System.Drawing.Point(22, 18);
            this.buttonImportSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonImportSequence.Name = "buttonImportSequence";
            this.buttonImportSequence.Size = new System.Drawing.Size(262, 62);
            this.buttonImportSequence.TabIndex = 0;
            this.buttonImportSequence.Text = "Import Sequence";
            this.buttonImportSequence.UseVisualStyleBackColor = true;
            this.buttonImportSequence.Click += new System.EventHandler(this.buttonImportSequence_Click);
            // 
            // panelDescription
            // 
            this.panelDescription.Controls.Add(this.richTextBoxDescription);
            this.panelDescription.Location = new System.Drawing.Point(387, 38);
            this.panelDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(262, 608);
            this.panelDescription.TabIndex = 2;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDescription.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(262, 608);
            this.richTextBoxDescription.TabIndex = 0;
            this.richTextBoxDescription.Text = "";
            // 
            // labelTitleDescription
            // 
            this.labelTitleDescription.AutoSize = true;
            this.labelTitleDescription.Location = new System.Drawing.Point(480, 14);
            this.labelTitleDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitleDescription.Name = "labelTitleDescription";
            this.labelTitleDescription.Size = new System.Drawing.Size(89, 20);
            this.labelTitleDescription.TabIndex = 3;
            this.labelTitleDescription.Text = "Description";
            // 
            // buttonRunSequence
            // 
            this.buttonRunSequence.Location = new System.Drawing.Point(22, 109);
            this.buttonRunSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRunSequence.Name = "buttonRunSequence";
            this.buttonRunSequence.Size = new System.Drawing.Size(262, 62);
            this.buttonRunSequence.TabIndex = 4;
            this.buttonRunSequence.Text = "Run Sequence";
            this.buttonRunSequence.UseVisualStyleBackColor = true;
            this.buttonRunSequence.Click += new System.EventHandler(this.buttonRunSequence_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(22, 38);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(262, 62);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelConnectStatus
            // 
            this.labelConnectStatus.AutoSize = true;
            this.labelConnectStatus.Location = new System.Drawing.Point(80, 14);
            this.labelConnectStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConnectStatus.Name = "labelConnectStatus";
            this.labelConnectStatus.Size = new System.Drawing.Size(160, 20);
            this.labelConnectStatus.TabIndex = 6;
            this.labelConnectStatus.Text = "Status: Unconnected";
            // 
            // splitContainerSequence
            // 
            this.splitContainerSequence.Location = new System.Drawing.Point(28, 38);
            this.splitContainerSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerSequence.Name = "splitContainerSequence";
            // 
            // splitContainerSequence.Panel1
            // 
            this.splitContainerSequence.Panel1.Controls.Add(this.richTextBoxCommand);
            // 
            // splitContainerSequence.Panel2
            // 
            this.splitContainerSequence.Panel2.Controls.Add(this.richTextBoxDelay);
            this.splitContainerSequence.Size = new System.Drawing.Size(315, 608);
            this.splitContainerSequence.SplitterDistance = 225;
            this.splitContainerSequence.SplitterWidth = 6;
            this.splitContainerSequence.TabIndex = 9;
            // 
            // richTextBoxCommand
            // 
            this.richTextBoxCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxCommand.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBoxCommand.Name = "richTextBoxCommand";
            this.richTextBoxCommand.Size = new System.Drawing.Size(225, 608);
            this.richTextBoxCommand.TabIndex = 0;
            this.richTextBoxCommand.Text = "";
            // 
            // richTextBoxDelay
            // 
            this.richTextBoxDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDelay.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxDelay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBoxDelay.Name = "richTextBoxDelay";
            this.richTextBoxDelay.Size = new System.Drawing.Size(84, 608);
            this.richTextBoxDelay.TabIndex = 0;
            this.richTextBoxDelay.Text = "";
            // 
            // labelTitleCommand
            // 
            this.labelTitleCommand.AutoSize = true;
            this.labelTitleCommand.Location = new System.Drawing.Point(106, 14);
            this.labelTitleCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitleCommand.Name = "labelTitleCommand";
            this.labelTitleCommand.Size = new System.Drawing.Size(82, 20);
            this.labelTitleCommand.TabIndex = 10;
            this.labelTitleCommand.Text = "Command";
            // 
            // labelTitleDelay
            // 
            this.labelTitleDelay.AutoSize = true;
            this.labelTitleDelay.Location = new System.Drawing.Point(260, 14);
            this.labelTitleDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitleDelay.Name = "labelTitleDelay";
            this.labelTitleDelay.Size = new System.Drawing.Size(84, 20);
            this.labelTitleDelay.TabIndex = 11;
            this.labelTitleDelay.Text = "Delay (ms)";
            // 
            // checkBoxStop
            // 
            this.checkBoxStop.AutoSize = true;
            this.checkBoxStop.Location = new System.Drawing.Point(60, 251);
            this.checkBoxStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxStop.Name = "checkBoxStop";
            this.checkBoxStop.Size = new System.Drawing.Size(185, 24);
            this.checkBoxStop.TabIndex = 16;
            this.checkBoxStop.Text = "Abort after this round";
            this.checkBoxStop.UseVisualStyleBackColor = true;
            this.checkBoxStop.CheckedChanged += new System.EventHandler(this.checkBoxStop_CheckedChanged);
            // 
            // buttonRunSequenceOnce
            // 
            this.buttonRunSequenceOnce.Location = new System.Drawing.Point(22, 38);
            this.buttonRunSequenceOnce.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRunSequenceOnce.Name = "buttonRunSequenceOnce";
            this.buttonRunSequenceOnce.Size = new System.Drawing.Size(262, 62);
            this.buttonRunSequenceOnce.TabIndex = 17;
            this.buttonRunSequenceOnce.Text = "Run Sequence Once";
            this.buttonRunSequenceOnce.UseVisualStyleBackColor = true;
            this.buttonRunSequenceOnce.Click += new System.EventHandler(this.buttonRunSeqOnce_Click);
            // 
            // buttonClearSequence
            // 
            this.buttonClearSequence.Location = new System.Drawing.Point(22, 160);
            this.buttonClearSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClearSequence.Name = "buttonClearSequence";
            this.buttonClearSequence.Size = new System.Drawing.Size(262, 62);
            this.buttonClearSequence.TabIndex = 20;
            this.buttonClearSequence.Text = "Clear sequence";
            this.buttonClearSequence.UseVisualStyleBackColor = true;
            this.buttonClearSequence.Click += new System.EventHandler(this.buttonClearSequence_Click);
            // 
            // buttonSaveSequence
            // 
            this.buttonSaveSequence.Location = new System.Drawing.Point(22, 89);
            this.buttonSaveSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSaveSequence.Name = "buttonSaveSequence";
            this.buttonSaveSequence.Size = new System.Drawing.Size(262, 62);
            this.buttonSaveSequence.TabIndex = 21;
            this.buttonSaveSequence.Text = "Save sequence";
            this.buttonSaveSequence.UseVisualStyleBackColor = true;
            this.buttonSaveSequence.Click += new System.EventHandler(this.buttonSaveSequence_Click);
            // 
            // panelSequenceFull
            // 
            this.panelSequenceFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSequenceFull.Controls.Add(this.panelSequence);
            this.panelSequenceFull.Controls.Add(this.panelConnect);
            this.panelSequenceFull.Controls.Add(this.panelImportSequence);
            this.panelSequenceFull.Controls.Add(this.panelRunSequence);
            this.panelSequenceFull.Location = new System.Drawing.Point(30, 31);
            this.panelSequenceFull.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSequenceFull.Name = "panelSequenceFull";
            this.panelSequenceFull.Size = new System.Drawing.Size(1078, 722);
            this.panelSequenceFull.TabIndex = 22;
            // 
            // panelSequence
            // 
            this.panelSequence.Controls.Add(this.labelTitleDelay);
            this.panelSequence.Controls.Add(this.labelTitleCommand);
            this.panelSequence.Controls.Add(this.splitContainerSequence);
            this.panelSequence.Controls.Add(this.labelTitleDescription);
            this.panelSequence.Controls.Add(this.panelDescription);
            this.panelSequence.Location = new System.Drawing.Point(369, 31);
            this.panelSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSequence.Name = "panelSequence";
            this.panelSequence.Size = new System.Drawing.Size(676, 662);
            this.panelSequence.TabIndex = 26;
            // 
            // panelConnect
            // 
            this.panelConnect.Controls.Add(this.labelConnectStatus);
            this.panelConnect.Controls.Add(this.buttonConnect);
            this.panelConnect.Location = new System.Drawing.Point(30, 31);
            this.panelConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelConnect.Name = "panelConnect";
            this.panelConnect.Size = new System.Drawing.Size(308, 115);
            this.panelConnect.TabIndex = 25;
            // 
            // panelImportSequence
            // 
            this.panelImportSequence.Controls.Add(this.buttonSaveSequence);
            this.panelImportSequence.Controls.Add(this.buttonClearSequence);
            this.panelImportSequence.Controls.Add(this.buttonImportSequence);
            this.panelImportSequence.Location = new System.Drawing.Point(30, 154);
            this.panelImportSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelImportSequence.Name = "panelImportSequence";
            this.panelImportSequence.Size = new System.Drawing.Size(308, 237);
            this.panelImportSequence.TabIndex = 24;
            // 
            // panelRunSequence
            // 
            this.panelRunSequence.Controls.Add(this.buttonStopSequence);
            this.panelRunSequence.Controls.Add(this.labelRunStatus);
            this.panelRunSequence.Controls.Add(this.checkBoxStop);
            this.panelRunSequence.Controls.Add(this.buttonRunSequenceOnce);
            this.panelRunSequence.Controls.Add(this.buttonRunSequence);
            this.panelRunSequence.Location = new System.Drawing.Point(30, 400);
            this.panelRunSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRunSequence.Name = "panelRunSequence";
            this.panelRunSequence.Size = new System.Drawing.Size(308, 292);
            this.panelRunSequence.TabIndex = 23;
            // 
            // buttonStopSequence
            // 
            this.buttonStopSequence.Location = new System.Drawing.Point(22, 180);
            this.buttonStopSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStopSequence.Name = "buttonStopSequence";
            this.buttonStopSequence.Size = new System.Drawing.Size(262, 62);
            this.buttonStopSequence.TabIndex = 25;
            this.buttonStopSequence.Text = "Abort Sequence Immediately";
            this.buttonStopSequence.UseVisualStyleBackColor = true;
            this.buttonStopSequence.Click += new System.EventHandler(this.buttonStopSequence_Click);
            // 
            // labelRunStatus
            // 
            this.labelRunStatus.AutoSize = true;
            this.labelRunStatus.Location = new System.Drawing.Point(106, 14);
            this.labelRunStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRunStatus.Name = "labelRunStatus";
            this.labelRunStatus.Size = new System.Drawing.Size(90, 20);
            this.labelRunStatus.TabIndex = 22;
            this.labelRunStatus.Text = "Status: Idle";
            // 
            // panelReadout
            // 
            this.panelReadout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReadout.Controls.Add(this.buttonPlotReadout);
            this.panelReadout.Controls.Add(this.labelTitleResolution);
            this.panelReadout.Controls.Add(this.labelTitleReadout);
            this.panelReadout.Controls.Add(this.splitContainerReadout);
            this.panelReadout.Controls.Add(this.buttonClearReadout);
            this.panelReadout.Controls.Add(this.buttonSaveReadout);
            this.panelReadout.Location = new System.Drawing.Point(1155, 31);
            this.panelReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelReadout.Name = "panelReadout";
            this.panelReadout.Size = new System.Drawing.Size(659, 722);
            this.panelReadout.TabIndex = 23;
            // 
            // buttonPlotReadout
            // 
            this.buttonPlotReadout.Location = new System.Drawing.Point(236, 615);
            this.buttonPlotReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPlotReadout.Name = "buttonPlotReadout";
            this.buttonPlotReadout.Size = new System.Drawing.Size(188, 62);
            this.buttonPlotReadout.TabIndex = 29;
            this.buttonPlotReadout.Text = "Plot readout";
            this.buttonPlotReadout.UseVisualStyleBackColor = true;
            this.buttonPlotReadout.Click += new System.EventHandler(this.buttonPlotReadout_Click);
            // 
            // labelTitleResolution
            // 
            this.labelTitleResolution.AutoSize = true;
            this.labelTitleResolution.Location = new System.Drawing.Point(444, 45);
            this.labelTitleResolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitleResolution.Name = "labelTitleResolution";
            this.labelTitleResolution.Size = new System.Drawing.Size(85, 20);
            this.labelTitleResolution.TabIndex = 28;
            this.labelTitleResolution.Text = "Resolution";
            // 
            // labelTitleReadout
            // 
            this.labelTitleReadout.AutoSize = true;
            this.labelTitleReadout.Location = new System.Drawing.Point(144, 45);
            this.labelTitleReadout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitleReadout.Name = "labelTitleReadout";
            this.labelTitleReadout.Size = new System.Drawing.Size(71, 20);
            this.labelTitleReadout.TabIndex = 27;
            this.labelTitleReadout.Text = "Readout";
            // 
            // splitContainerReadout
            // 
            this.splitContainerReadout.Location = new System.Drawing.Point(30, 69);
            this.splitContainerReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerReadout.Name = "splitContainerReadout";
            // 
            // splitContainerReadout.Panel1
            // 
            this.splitContainerReadout.Panel1.Controls.Add(this.richTextBoxReadout);
            // 
            // splitContainerReadout.Panel2
            // 
            this.splitContainerReadout.Panel2.Controls.Add(this.richTextBoxResolution);
            this.splitContainerReadout.Size = new System.Drawing.Size(600, 518);
            this.splitContainerReadout.SplitterDistance = 300;
            this.splitContainerReadout.SplitterWidth = 6;
            this.splitContainerReadout.TabIndex = 26;
            // 
            // richTextBoxReadout
            // 
            this.richTextBoxReadout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxReadout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxReadout.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBoxReadout.Name = "richTextBoxReadout";
            this.richTextBoxReadout.Size = new System.Drawing.Size(300, 518);
            this.richTextBoxReadout.TabIndex = 0;
            this.richTextBoxReadout.Text = "";
            // 
            // richTextBoxResolution
            // 
            this.richTextBoxResolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxResolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxResolution.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxResolution.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBoxResolution.Name = "richTextBoxResolution";
            this.richTextBoxResolution.Size = new System.Drawing.Size(294, 518);
            this.richTextBoxResolution.TabIndex = 0;
            this.richTextBoxResolution.Text = "";
            // 
            // buttonClearReadout
            // 
            this.buttonClearReadout.Location = new System.Drawing.Point(441, 615);
            this.buttonClearReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClearReadout.Name = "buttonClearReadout";
            this.buttonClearReadout.Size = new System.Drawing.Size(188, 62);
            this.buttonClearReadout.TabIndex = 25;
            this.buttonClearReadout.Text = "Clear readout";
            this.buttonClearReadout.UseVisualStyleBackColor = true;
            this.buttonClearReadout.Click += new System.EventHandler(this.buttonClearReadout_Click);
            // 
            // buttonSaveReadout
            // 
            this.buttonSaveReadout.Location = new System.Drawing.Point(30, 615);
            this.buttonSaveReadout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSaveReadout.Name = "buttonSaveReadout";
            this.buttonSaveReadout.Size = new System.Drawing.Size(188, 62);
            this.buttonSaveReadout.TabIndex = 24;
            this.buttonSaveReadout.Text = "Save readout";
            this.buttonSaveReadout.UseVisualStyleBackColor = true;
            this.buttonSaveReadout.Click += new System.EventHandler(this.buttonSaveReadout_Click);
            // 
            // panelReadoutPlot
            // 
            this.panelReadoutPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReadoutPlot.Controls.Add(this.chartReadoutPlot);
            this.panelReadoutPlot.Location = new System.Drawing.Point(30, 800);
            this.panelReadoutPlot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelReadoutPlot.Name = "panelReadoutPlot";
            this.panelReadoutPlot.Size = new System.Drawing.Size(1784, 648);
            this.panelReadoutPlot.TabIndex = 24;
            // 
            // chartReadoutPlot
            // 
            chartArea6.Name = "ChartArea1";
            this.chartReadoutPlot.ChartAreas.Add(chartArea6);
            this.chartReadoutPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chartReadoutPlot.Legends.Add(legend6);
            this.chartReadoutPlot.Location = new System.Drawing.Point(0, 0);
            this.chartReadoutPlot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartReadoutPlot.Name = "chartReadoutPlot";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Readout";
            this.chartReadoutPlot.Series.Add(series6);
            this.chartReadoutPlot.Size = new System.Drawing.Size(1782, 646);
            this.chartReadoutPlot.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1851, 1038);
            this.Controls.Add(this.panelReadoutPlot);
            this.Controls.Add(this.panelReadout);
            this.Controls.Add(this.panelSequenceFull);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Agilent";
            this.panelDescription.ResumeLayout(false);
            this.splitContainerSequence.Panel1.ResumeLayout(false);
            this.splitContainerSequence.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSequence)).EndInit();
            this.splitContainerSequence.ResumeLayout(false);
            this.panelSequenceFull.ResumeLayout(false);
            this.panelSequence.ResumeLayout(false);
            this.panelSequence.PerformLayout();
            this.panelConnect.ResumeLayout(false);
            this.panelConnect.PerformLayout();
            this.panelImportSequence.ResumeLayout(false);
            this.panelRunSequence.ResumeLayout(false);
            this.panelRunSequence.PerformLayout();
            this.panelReadout.ResumeLayout(false);
            this.panelReadout.PerformLayout();
            this.splitContainerReadout.Panel1.ResumeLayout(false);
            this.splitContainerReadout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReadout)).EndInit();
            this.splitContainerReadout.ResumeLayout(false);
            this.panelReadoutPlot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartReadoutPlot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonImportSequence;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Label labelTitleDescription;
        private System.Windows.Forms.Button buttonRunSequence;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelConnectStatus;
        private System.Windows.Forms.SplitContainer splitContainerSequence;
        private System.Windows.Forms.RichTextBox richTextBoxCommand;
        private System.Windows.Forms.RichTextBox richTextBoxDelay;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label labelTitleCommand;
        private System.Windows.Forms.Label labelTitleDelay;
        private System.Windows.Forms.CheckBox checkBoxStop;
        private System.Windows.Forms.Button buttonRunSequenceOnce;
        private System.Windows.Forms.Button buttonClearSequence;
        private System.Windows.Forms.Button buttonSaveSequence;
        private System.Windows.Forms.Panel panelSequenceFull;
        private System.Windows.Forms.Label labelRunStatus;
        private System.Windows.Forms.Panel panelConnect;
        private System.Windows.Forms.Panel panelImportSequence;
        private System.Windows.Forms.Panel panelRunSequence;
        private System.Windows.Forms.Panel panelSequence;
        private System.Windows.Forms.Panel panelReadout;
        private System.Windows.Forms.Button buttonClearReadout;
        private System.Windows.Forms.Button buttonSaveReadout;
        private System.Windows.Forms.SplitContainer splitContainerReadout;
        private System.Windows.Forms.Label labelTitleResolution;
        private System.Windows.Forms.Label labelTitleReadout;
        private System.Windows.Forms.RichTextBox richTextBoxReadout;
        private System.Windows.Forms.RichTextBox richTextBoxResolution;
        private System.Windows.Forms.Panel panelReadoutPlot;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReadoutPlot;
        private System.Windows.Forms.Button buttonPlotReadout;
        private System.Windows.Forms.Button buttonStopSequence;
    }
}