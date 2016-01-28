using System;
using System.Windows.Forms;

namespace Agilent
{
    public partial class ConnectForm : Form
    {
        public ConnectForm(MainForm mainForm)
        {
            InitializeComponent();
            this.fatherForm = mainForm;
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            //Do not remove this empty method.
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string portName = tbxPortName.Text;
            int baudRate = int.Parse(tbxBaudRate.Text);
            int dataBits = int.Parse(tbxDataBits.Text);
            int stopBits = int.Parse(tbxStopBits.Text);
            string parity = lbxParity.Text;

            this.fatherForm.OpenPort(portName, baudRate, parity, dataBits, stopBits);
            this.fatherForm.UpdateConnectionDisplay();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
