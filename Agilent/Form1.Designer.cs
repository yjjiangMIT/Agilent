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
            this.btnImportSeq = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblTitleDesc = new System.Windows.Forms.Label();
            this.btnRunSeq = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblConnStatus = new System.Windows.Forms.Label();
            this.lblTitleSeq = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbxCommand = new System.Windows.Forms.TextBox();
            this.tbxDelay = new System.Windows.Forms.TextBox();
            this.lblTitleCom = new System.Windows.Forms.Label();
            this.lblTitleDelay = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbxRead = new System.Windows.Forms.TextBox();
            this.lblTitleRead = new System.Windows.Forms.Label();
            this.btnClearRead = new System.Windows.Forms.Button();
            this.cbxIfStop = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportSeq
            // 
            this.btnImportSeq.Location = new System.Drawing.Point(40, 231);
            this.btnImportSeq.Name = "btnImportSeq";
            this.btnImportSeq.Size = new System.Drawing.Size(175, 40);
            this.btnImportSeq.TabIndex = 0;
            this.btnImportSeq.Text = "Import Sequence";
            this.btnImportSeq.UseVisualStyleBackColor = true;
            this.btnImportSeq.Click += new System.EventHandler(this.btnImportSeq_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxDescription);
            this.panel1.Location = new System.Drawing.Point(668, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 279);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tbxDescription
            // 
            this.tbxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxDescription.Location = new System.Drawing.Point(0, 0);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(170, 279);
            this.tbxDescription.TabIndex = 0;
            // 
            // lblTitleDesc
            // 
            this.lblTitleDesc.AutoSize = true;
            this.lblTitleDesc.Location = new System.Drawing.Point(724, 40);
            this.lblTitleDesc.Name = "lblTitleDesc";
            this.lblTitleDesc.Size = new System.Drawing.Size(60, 13);
            this.lblTitleDesc.TabIndex = 3;
            this.lblTitleDesc.Text = "Description";
            // 
            // btnRunSeq
            // 
            this.btnRunSeq.Location = new System.Drawing.Point(40, 303);
            this.btnRunSeq.Name = "btnRunSeq";
            this.btnRunSeq.Size = new System.Drawing.Size(175, 40);
            this.btnRunSeq.TabIndex = 4;
            this.btnRunSeq.Text = "Run Sequence";
            this.btnRunSeq.UseVisualStyleBackColor = true;
            this.btnRunSeq.Click += new System.EventHandler(this.btnRunSeq_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(40, 64);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(175, 40);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblConnStatus
            // 
            this.lblConnStatus.AutoSize = true;
            this.lblConnStatus.Location = new System.Drawing.Point(73, 40);
            this.lblConnStatus.Name = "lblConnStatus";
            this.lblConnStatus.Size = new System.Drawing.Size(108, 13);
            this.lblConnStatus.TabIndex = 6;
            this.lblConnStatus.Text = "Status: Unconnected";
            // 
            // lblTitleSeq
            // 
            this.lblTitleSeq.AutoSize = true;
            this.lblTitleSeq.Location = new System.Drawing.Point(438, 40);
            this.lblTitleSeq.Name = "lblTitleSeq";
            this.lblTitleSeq.Size = new System.Drawing.Size(56, 13);
            this.lblTitleSeq.TabIndex = 8;
            this.lblTitleSeq.Text = "Sequence";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(359, 85);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbxCommand);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbxDelay);
            this.splitContainer1.Size = new System.Drawing.Size(211, 277);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 9;
            // 
            // tbxCommand
            // 
            this.tbxCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxCommand.Location = new System.Drawing.Point(0, 0);
            this.tbxCommand.Multiline = true;
            this.tbxCommand.Name = "tbxCommand";
            this.tbxCommand.Size = new System.Drawing.Size(150, 277);
            this.tbxCommand.TabIndex = 0;
            // 
            // tbxDelay
            // 
            this.tbxDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxDelay.Location = new System.Drawing.Point(0, 0);
            this.tbxDelay.Multiline = true;
            this.tbxDelay.Name = "tbxDelay";
            this.tbxDelay.Size = new System.Drawing.Size(57, 277);
            this.tbxDelay.TabIndex = 0;
            // 
            // lblTitleCom
            // 
            this.lblTitleCom.AutoSize = true;
            this.lblTitleCom.Location = new System.Drawing.Point(414, 64);
            this.lblTitleCom.Name = "lblTitleCom";
            this.lblTitleCom.Size = new System.Drawing.Size(59, 13);
            this.lblTitleCom.TabIndex = 10;
            this.lblTitleCom.Text = "Commands";
            // 
            // lblTitleDelay
            // 
            this.lblTitleDelay.AutoSize = true;
            this.lblTitleDelay.Location = new System.Drawing.Point(510, 64);
            this.lblTitleDelay.Name = "lblTitleDelay";
            this.lblTitleDelay.Size = new System.Drawing.Size(61, 13);
            this.lblTitleDelay.TabIndex = 11;
            this.lblTitleDelay.Text = "Delays (ms)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbxRead);
            this.panel2.Location = new System.Drawing.Point(928, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 277);
            this.panel2.TabIndex = 12;
            // 
            // tbxRead
            // 
            this.tbxRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxRead.Location = new System.Drawing.Point(0, 0);
            this.tbxRead.Multiline = true;
            this.tbxRead.Name = "tbxRead";
            this.tbxRead.Size = new System.Drawing.Size(170, 277);
            this.tbxRead.TabIndex = 0;
            // 
            // lblTitleRead
            // 
            this.lblTitleRead.AutoSize = true;
            this.lblTitleRead.Location = new System.Drawing.Point(988, 40);
            this.lblTitleRead.Name = "lblTitleRead";
            this.lblTitleRead.Size = new System.Drawing.Size(48, 13);
            this.lblTitleRead.TabIndex = 13;
            this.lblTitleRead.Text = "Readout";
            // 
            // btnClearRead
            // 
            this.btnClearRead.Location = new System.Drawing.Point(979, 384);
            this.btnClearRead.Name = "btnClearRead";
            this.btnClearRead.Size = new System.Drawing.Size(81, 46);
            this.btnClearRead.TabIndex = 14;
            this.btnClearRead.Text = "Clear";
            this.btnClearRead.UseVisualStyleBackColor = true;
            this.btnClearRead.Click += new System.EventHandler(this.btnClearRead_Click);
            // 
            // cbxIfStop
            // 
            this.cbxIfStop.AutoSize = true;
            this.cbxIfStop.Location = new System.Drawing.Point(221, 316);
            this.cbxIfStop.Name = "cbxIfStop";
            this.cbxIfStop.Size = new System.Drawing.Size(109, 17);
            this.cbxIfStop.TabIndex = 16;
            this.cbxIfStop.Text = "Stop after this run";
            this.cbxIfStop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1167, 462);
            this.Controls.Add(this.cbxIfStop);
            this.Controls.Add(this.btnClearRead);
            this.Controls.Add(this.lblTitleRead);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTitleDelay);
            this.Controls.Add(this.lblTitleCom);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblTitleSeq);
            this.Controls.Add(this.lblConnStatus);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRunSeq);
            this.Controls.Add(this.lblTitleDesc);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnImportSeq);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Agilent";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportSeq;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitleDesc;
        private System.Windows.Forms.Button btnRunSeq;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblConnStatus;

        private Sequence sequence;
        private ComPort comPort;
        private Form2 childForm;
        private System.Windows.Forms.Label lblTitleSeq;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbxCommand;
        private System.Windows.Forms.TextBox tbxDelay;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label lblTitleCom;
        private System.Windows.Forms.Label lblTitleDelay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbxRead;
        private System.Windows.Forms.Label lblTitleRead;
        private System.Windows.Forms.Button btnClearRead;
        private System.Windows.Forms.CheckBox cbxIfStop;
    }
}