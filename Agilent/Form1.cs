using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Agilent
{
    public partial class Form1 : Form
    {
        private int DELAY_BETWEEN_TWO_RUNS = 1000;
        private int READ_TIMEOUT = 1000000;

        private Sequence sequence;
        private ComPort comPort;
        private Form2 childForm;
        private bool ifAbort;

        public Form1()
        {
            InitializeComponent();
            this.childForm = new Form2(this);
            this.comPort = new ComPort();
            this.childForm.Dispose();
            this.ifAbort = false;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
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

        public void OpenPort(string portName, int baudRate, string parity, int dataBits, int stopBits)
        {
            this.comPort = new ComPort(portName, baudRate, parity, dataBits, stopBits);
            try
            {
                this.comPort.Open();
                this.comPort.ReadTimeout = READ_TIMEOUT;
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
                buttonConnect.Text = "Disconnect";
                labelConnectStatus.Text = "Status: Connected";
            }
            else
            {
                buttonConnect.Text = "Connect";
                labelConnectStatus.Text = "Status: Unconnected";
            }
        }

        private void buttonImportSequence_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            StreamReader reader = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

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
                            sequence = new Sequence();
                            sequence.LoadSequence(reader);
                            sequence.DisplaySequence(this.richTextBoxCommand, this.richTextBoxDelay, this.richTextBoxDescription);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void buttonRunSequence_Click(object sender, EventArgs e)
        {
            this.sequence.UpdateSequence(this.richTextBoxCommand, this.richTextBoxDelay, this.richTextBoxDescription);
            Thread threadRunSeq = new Thread(new ThreadStart(this.RunSequence));
            threadRunSeq.Start();
        }

        private void RunSequence()
        {
            Command currentCommand;
            string function;
            string resolution;
            int counter;

            if (this.InvokeRequired)
            {
                this.Invoke(new ChangeDisplayStatusCallback(this.ChangeDisplayStatusToRun));
                do
                {
                    for (int i = 0; i < this.sequence.Length; i++)
                    {
                        currentCommand = this.sequence.getCommand(i);
                        this.Invoke(new ColorDisplayCurrentCommandCallback(this.ColorDisplayCurrentCommand), new object[] { i });

                        this.comPort.WriteLine(currentCommand.Scpi);
                        Console.WriteLine(currentCommand.Scpi);
                        Console.WriteLine(currentCommand.Delay);
                        if (currentCommand.Scpi.EndsWith("?"))
                        {
                            counter = (int)this.Invoke(new ParseReadoutCallback(this.ParseReadout));
                            if (counter > 0) // If readouts are obtained, ask for their precision
                            {
                                this.comPort.WriteLine("FUNC?");
                                function = this.comPort.ReadLine().Split('"')[1];
                                this.comPort.WriteLine(function + ":RES?");
                                resolution = this.comPort.ReadLine();
                                this.Invoke(new ParseResolutionCallback(this.ParseResolution), new object[] { counter });
                            }
                        }
                        Thread.Sleep(currentCommand.Delay);
                    }
                    this.Invoke(new ColorDisplayCurrentCommandCallback(this.ColorDisplayCurrentCommand), new object[] { -1 });
                    Thread.Sleep(DELAY_BETWEEN_TWO_RUNS);
                }
                while (!this.ifAbort);
                this.Invoke(new ChangeDisplayStatusCallback(this.ChangeDisplayStatusToIdle));
            }
        }

        private delegate int ParseReadoutCallback();

        private int ParseReadout()
        {
            int counter = 0;
            string[] readout;
            try
            {
                readout = this.comPort.ReadLine().Split(',');
                foreach (string oneLine in readout)
                {
                    if (oneLine.Length > 0)
                    {
                        this.richTextBoxReadout.AppendText(oneLine + "\r\n");
                        counter++;
                    }
                }
            }
            catch
            {
                //Do nothing
            }
            if (counter > 0)
            {
                this.richTextBoxReadout.AppendText("\r\n");
            }
            return counter;
        }

        private delegate void ParseResolutionCallback(int counter);

        private void ParseResolution(int counter)
        {
            string resolution;
            try
            {
                resolution = this.comPort.ReadLine();
                if (resolution.Length == 0)
                {
                    resolution = "N/A";
                }
            }
            catch
            {
                resolution = "N/A";
            }
            for (int i = 0; i < counter; i++)
            {
                this.richTextBoxPrecision.AppendText(resolution + "\r\n");
            }
            if (counter > 0)
            {
                this.richTextBoxPrecision.AppendText("\r\n");
            }
        }

        private void buttonRunSeqOnce_Click(object sender, EventArgs e)
        {
            this.sequence.UpdateSequence(this.richTextBoxCommand, this.richTextBoxDelay, this.richTextBoxDescription);
            Thread threadRunSeq = new Thread(new ThreadStart(this.RunSequenceOnce));
            threadRunSeq.Start();
        }

        private void RunSequenceOnce()
        {
            Command currentCommand;
            String[] readOut;

            if (this.InvokeRequired)
            {
                this.Invoke(new ChangeDisplayStatusCallback(this.ChangeDisplayStatusToRun));
                this.ifAbort = true;
                for (int i = 0; i < this.sequence.Length; i++)
                {
                    currentCommand = this.sequence.getCommand(i);
                    this.Invoke(new ColorDisplayCurrentCommandCallback(this.ColorDisplayCurrentCommand), new object[] { i });

                    Console.WriteLine(currentCommand.Scpi);
                    Console.WriteLine(currentCommand.Delay);
                    if (currentCommand.Scpi.EndsWith("?"))
                    {
                        try
                        {
                            readOut = this.comPort.ReadLine().Split(',');
                            foreach (string readOutLine in readOut)
                            {
                                if (readOutLine.Length > 0)
                                {
                                    richTextBoxReadout.AppendText(readOutLine + "\r\n");
                                }
                            }
                            richTextBoxReadout.AppendText("\r\n");
                        }
                        catch
                        {
                            //Do nothing;
                        }
                    }
                    Thread.Sleep(currentCommand.Delay);
                }
                this.Invoke(new ColorDisplayCurrentCommandCallback(this.ColorDisplayCurrentCommand), new object[] { -1 });
                this.Invoke(new ChangeDisplayStatusCallback(this.ChangeDisplayStatusToIdle));
            }
        }

        private delegate void ColorDisplayCurrentCommandCallback(int index);

        private void ColorDisplayCurrentCommand(int index)
        {
            this.sequence.DisplaySequence(this.richTextBoxCommand, this.richTextBoxDelay, this.richTextBoxDescription, index);
        }

        private delegate void ChangeDisplayStatusCallback();

        private void ChangeDisplayStatusToRun()
        {
            this.ifAbort = this.checkBoxStop.Checked;
            this.labelRunStatus.Text = "Status: Running";
            this.buttonRunSequence.Enabled = false;
            this.buttonRunSequenceOnce.Enabled = false;
        }

        private void ChangeDisplayStatusToIdle()
        {
            this.checkBoxStop.Checked = false;
            this.labelRunStatus.Text = "Status: Idle";
            this.buttonRunSequence.Enabled = true;
            this.buttonRunSequenceOnce.Enabled = true;
        }

        private void checkBoxStop_CheckedChanged(object sender, EventArgs e)
        {
            this.ifAbort = this.checkBoxStop.Checked;
        }

        private void buttonClearReadout_Click(object sender, EventArgs e)
        {
            this.richTextBoxReadout.Clear();
            this.richTextBoxPrecision.Clear();
        }

        private void buttonClearSequence_Click(object sender, EventArgs e)
        {
            this.richTextBoxCommand.Clear();
            this.richTextBoxDelay.Clear();
            this.richTextBoxDescription.Clear();
        }
    }
}