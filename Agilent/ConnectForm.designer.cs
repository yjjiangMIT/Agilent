namespace Agilent
{
    partial class ConnectForm
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
            this.tbxPortName = new System.Windows.Forms.TextBox();
            this.tbxBaudRate = new System.Windows.Forms.TextBox();
            this.tbxDataBits = new System.Windows.Forms.TextBox();
            this.tbxStopBits = new System.Windows.Forms.TextBox();
            this.lblPortName = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.lbxParity = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxPortName
            // 
            this.tbxPortName.Location = new System.Drawing.Point(168, 28);
            this.tbxPortName.Name = "tbxPortName";
            this.tbxPortName.Size = new System.Drawing.Size(73, 20);
            this.tbxPortName.TabIndex = 0;
            this.tbxPortName.Text = "COM1";
            // 
            // tbxBaudRate
            // 
            this.tbxBaudRate.Location = new System.Drawing.Point(168, 67);
            this.tbxBaudRate.Name = "tbxBaudRate";
            this.tbxBaudRate.Size = new System.Drawing.Size(73, 20);
            this.tbxBaudRate.TabIndex = 1;
            this.tbxBaudRate.Text = "9600";
            // 
            // tbxDataBits
            // 
            this.tbxDataBits.Location = new System.Drawing.Point(168, 106);
            this.tbxDataBits.Name = "tbxDataBits";
            this.tbxDataBits.Size = new System.Drawing.Size(73, 20);
            this.tbxDataBits.TabIndex = 2;
            this.tbxDataBits.Text = "7";
            // 
            // tbxStopBits
            // 
            this.tbxStopBits.Location = new System.Drawing.Point(168, 145);
            this.tbxStopBits.Name = "tbxStopBits";
            this.tbxStopBits.Size = new System.Drawing.Size(73, 20);
            this.tbxStopBits.TabIndex = 3;
            this.tbxStopBits.Text = "2";
            // 
            // lblPortName
            // 
            this.lblPortName.AutoSize = true;
            this.lblPortName.Location = new System.Drawing.Point(55, 32);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(57, 13);
            this.lblPortName.TabIndex = 4;
            this.lblPortName.Text = "Port Name";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(55, 71);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(58, 13);
            this.lblBaudRate.TabIndex = 5;
            this.lblBaudRate.Text = "Baud Rate";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(55, 110);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(50, 13);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits";
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(55, 149);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(49, 13);
            this.lblStopBits.TabIndex = 7;
            this.lblStopBits.Text = "Stop Bits";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(55, 199);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(33, 13);
            this.lblParity.TabIndex = 8;
            this.lblParity.Text = "Parity";
            // 
            // lbxParity
            // 
            this.lbxParity.AllowDrop = true;
            this.lbxParity.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbxParity.FormattingEnabled = true;
            this.lbxParity.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None"});
            this.lbxParity.Location = new System.Drawing.Point(168, 184);
            this.lbxParity.Name = "lbxParity";
            this.lbxParity.Size = new System.Drawing.Size(73, 43);
            this.lbxParity.TabIndex = 9;
            this.lbxParity.SelectedIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(45, 255);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 46);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(165, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 46);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 337);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbxParity);
            this.Controls.Add(this.lblParity);
            this.Controls.Add(this.lblStopBits);
            this.Controls.Add(this.lblDataBits);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.lblPortName);
            this.Controls.Add(this.tbxStopBits);
            this.Controls.Add(this.tbxDataBits);
            this.Controls.Add(this.tbxBaudRate);
            this.Controls.Add(this.tbxPortName);
            this.Name = "ConnectForm";
            this.Text = "Connection Setup";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPortName;
        private System.Windows.Forms.TextBox tbxBaudRate;
        private System.Windows.Forms.TextBox tbxDataBits;
        private System.Windows.Forms.TextBox tbxStopBits;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ListBox lbxParity;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        private MainForm fatherForm;
    }
}