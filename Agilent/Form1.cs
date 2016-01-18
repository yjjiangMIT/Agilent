using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Agilent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.childForm = new Form2(this);
            this.comPort = new ComPort();
            this.childForm.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Do not remove this empty method.
        }

        private void btnImportSeq_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            StreamReader reader = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Command currentCommand;
            string commandText = "";
            string delayText = "";

            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"sequences";
            openFileDialog1.Filter = "txt files(*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog1.OpenFile()) != null)
                    {
                        using (reader = new StreamReader(stream))
                        {
                            sequence = new Sequence(reader);
                            currentCommand = sequence.NextCommand();
                            while (currentCommand != null)
                            {
                                commandText += currentCommand.Line + "\r\n";
                                delayText += currentCommand.Delay.ToString() + "\r\n"; 
                                currentCommand = sequence.NextCommand();
                            }
                            tbxDescription.Text = sequence.ToString();
                            tbxDelay.Text = delayText;
                            tbxCommand.Text = commandText;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnRunSeq_Click(object sender, EventArgs e)
        {
            Command nextCommand;
            string[] readOut;
            StreamWriter dataFile;
            string fileName;
            bool tempBool = true;

            fileName = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".txt";
            dataFile = new StreamWriter(fileName);

            //while (!this.cbxIfStop.Checked)
            while (tempBool)
            {
                this.sequence.ResetCounter();
                nextCommand = this.sequence.NextCommand();
                while (nextCommand != null)
                {
                    Console.WriteLine(nextCommand.Line);
                    this.comPort.WriteLine(nextCommand.Line);
                    Thread.Sleep(nextCommand.Delay);
                    if (nextCommand.Line.EndsWith("?"))
                    {
                        try
                        {
                            readOut = this.comPort.ReadLine().Split(',');
                            foreach (string temp in readOut)
                            {
                                dataFile.WriteLine(temp);
                                tbxRead.AppendText(temp + "\r\n");
                            }
                        }
                        catch
                        {
                            //Do nothing;
                        }
                    }
                    nextCommand = this.sequence.NextCommand();
                }
                tempBool = false;
            }
            dataFile.Close();
            this.sequence.ResetCounter();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.comPort.IsOpen)
            {
                this.comPort.Close();
            }
            else
            {
                if (this.childForm.IsDisposed)
                {
                    this.childForm = new Form2(this);
                    this.childForm.Show();
                }
            }
            this.UpdateConnStatus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Do not remove this empty method.
        }

        public void OpenPort(string portName, int baudRate, string parity, int dataBits, int stopBits)
        {
            this.comPort = new ComPort(portName, baudRate, parity, dataBits, stopBits);
            try
            {
                this.comPort.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateConnStatus()
        {
            if (this.comPort.IsOpen)
            {
                btnConnect.Text = "Disconnect";
                lblConnStatus.Text = "Status: Connected";
            }
            else
            {
                btnConnect.Text = "Connect";
                lblConnStatus.Text = "Status: Unconnected";
            }
        }

        private void btnClearRead_Click(object sender, EventArgs e)
        {
            this.tbxRead.Text = "";
        }
    }
}