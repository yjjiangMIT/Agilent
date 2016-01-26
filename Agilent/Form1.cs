using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace Agilent
{
    public partial class Form1 : Form
    {
        private int READ_TIMEOUT = 1000; // Set read timeout to be 1s.
        private int DELAY_BETWEEN_ROUNDS = 0;
        private enum DataType { READOUT, FUNCTION, RESOLUTION };

        private Sequence sequence;
        private ComPort comPort;
        private Form2 childForm;
        private bool ifAbort;
        private bool ifDataReceived;
        private bool ifAbortImmediately;
        private int readoutCounter;
        private DataType expectedDataType;

        public Form1()
        {
            InitializeComponent();
            this.childForm = new Form2(this);
            this.comPort = new ComPort();
            this.childForm.Dispose();
            this.ifAbort = false;
            this.expectedDataType = DataType.READOUT;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (this.expectedDataType == DataType.READOUT)
                {
                    this.ParseReadout();
                    this.comPort.WriteLine("FUNC?");
                    this.expectedDataType = DataType.FUNCTION;
                }
                else if (this.expectedDataType == DataType.FUNCTION)
                {
                    string function = this.comPort.ReadLine().Split('"')[1];
                    Console.WriteLine(function);
                    this.comPort.WriteLine(function + ":RES?");
                    this.expectedDataType = DataType.RESOLUTION;
                }
                else if (this.expectedDataType == DataType.RESOLUTION)
                {
                    Console.WriteLine(this.readoutCounter);
                    this.ParseResolution();
                    this.expectedDataType = DataType.READOUT;
                }
            }
            catch
            {
                this.ParseResolution();
                this.expectedDataType = DataType.READOUT;
            }

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
            this.comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
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
                            sequence.LoadSequence(reader, openFileDialog1.FileName);
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
            this.expectedDataType = DataType.READOUT;
            this.ifAbortImmediately = false;
            Thread threadRunSeq = new Thread(new ThreadStart(this.RunSequence));
            threadRunSeq.Start();
        }

        private void RunSequence()
        {
            Command currentCommand;

            if (this.InvokeRequired)
            {
                this.Invoke(new ChangeDisplayStatusCallback(this.ChangeDisplayStatusToRun));

                try
                {
                    this.comPort.WriteLine("\x03"); // Stop unfinished job.
                    this.comPort.WriteLine("*CLS"); // Clear previous setup.
                }
                catch
                {
                    // Do nothing.
                }
                do
                {
                    this.ifDataReceived = false;
                    for (int i = 0; i < this.sequence.Length; i++)
                    {
                        currentCommand = this.sequence.getCommand(i);
                        this.Invoke(new ColorDisplayCurrentCommandCallback(this.ColorDisplayCurrentCommand), new object[] { i });

                        this.comPort.WriteLine(currentCommand.Scpi);
                        if (currentCommand.Scpi.EndsWith("?"))
                        {
                            while (!this.ifDataReceived) ; // Do not continue unless some data are received.
                            this.ifDataReceived = false;
                        }
                        if (this.ifAbortImmediately)
                        {
                            break;
                        }
                        Thread.Sleep(currentCommand.Delay);
                    }
                    this.Invoke(new ColorDisplayCurrentCommandCallback(this.ColorDisplayCurrentCommand), new object[] { -1 });    
                }
                while (!this.ifAbort && !this.ifAbortImmediately);
                this.Invoke(new ChangeDisplayStatusCallback(this.ChangeDisplayStatusToIdle));
                Thread.Sleep(DELAY_BETWEEN_ROUNDS);
            }
        }

        private delegate void ParseCallback();

        private void ParseReadout()
        {
            string[] readout;

            if (this.InvokeRequired)
            {
                this.Invoke(new ParseCallback(this.ParseReadout));
            }
            else
            {
                try
                {
                    readout = this.comPort.ReadLine().Split(',');
                    this.readoutCounter = 0;
                    foreach (string oneLine in readout)
                    {
                        if (oneLine.Length > 0)
                        {
                            this.richTextBoxReadout.AppendText(oneLine.TrimEnd((char)13) + Environment.NewLine);
                            this.readoutCounter++;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Readout error: timeout!");
                }
                this.comPort.WriteLine("\x03"); // Stop unfinished job.
            }
        }

        private void ParseResolution()
        {
            string resolution;

            if (this.InvokeRequired)
            {
                this.Invoke(new ParseCallback(this.ParseResolution));
            }
            else
            {
                try
                {
                    resolution = this.comPort.ReadLine();
                    if (resolution.Length == 0)
                    {
                        resolution = "N/A" + Environment.NewLine;
                    }
                }
                catch
                {
                    Console.WriteLine("Resolution error: timeout!");
                    resolution = "N/A" + Environment.NewLine;
                }
                for (int i = 0; i < this.readoutCounter; i++)
                {
                    this.richTextBoxResolution.AppendText(resolution);
                }
                this.ifDataReceived = true;
            }
        }

        private void buttonRunSeqOnce_Click(object sender, EventArgs e)
        {
            this.sequence.UpdateSequence(this.richTextBoxCommand, this.richTextBoxDelay, this.richTextBoxDescription);
            this.expectedDataType = DataType.READOUT;
            this.ifAbortImmediately = false;
            this.checkBoxStop.Checked = true;
            Thread threadRunSeq = new Thread(new ThreadStart(this.RunSequence));
            threadRunSeq.Start();
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
            this.richTextBoxResolution.Clear();
        }

        private void buttonClearSequence_Click(object sender, EventArgs e)
        {
            this.richTextBoxCommand.Clear();
            this.richTextBoxDelay.Clear();
            this.richTextBoxDescription.Clear();
        }

        private void buttonSaveReadout_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            StreamWriter writer = null;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"readouts";
            saveFileDialog1.Filter = "csv files(*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = this.sequence.FileName;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = saveFileDialog1.OpenFile()) != null)
                    {
                        using (writer = new StreamWriter(stream))
                        {
                            WriteToFile(writer);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void WriteToFile(StreamWriter writer)
        {
            string[] readout = this.richTextBoxReadout.Text.Split('\n');
            string[] resolution = this.richTextBoxResolution.Text.Split('\n');
            int length = Math.Min(readout.Length, resolution.Length);

            writer.WriteLine("Sequence file name," + this.sequence.FileName);
            writer.WriteLine("Sequence file path," + this.sequence.FilePath);
            writer.WriteLine("Description," + this.sequence.ToString());
            writer.Write(Environment.NewLine);
            writer.WriteLine("Readout,Resolution");
            writer.Write(Environment.NewLine);
            for (int i = 0; i < length; i++)
            {
                writer.Write(readout[i]);
                writer.Write(",");
                writer.Write(resolution[i]);
                writer.Write(Environment.NewLine);
            }
            writer.Close();
        }

        private void buttonPlotReadout_Click(object sender, EventArgs e)
        {
            int counter = 1;
            string[] readout;

            this.chartReadoutPlot.Series.Clear();
            this.chartReadoutPlot.Series.Add("Readout");
            this.chartReadoutPlot.Series["Readout"].ChartType = SeriesChartType.Line;
            if (richTextBoxReadout.SelectedText.Length > 0)
            {
                readout = richTextBoxReadout.SelectedText.Split('\n');
            }
            else
            {
                readout = richTextBoxReadout.Text.Split('\n');
            }
            foreach (string oneLine in readout)
            {
                try
                { 
                    this.chartReadoutPlot.Series["Readout"].Points.AddXY(counter, double.Parse(oneLine));
                    counter++;
                }
                catch
                {
                    //Do nothing.
                }
            }
            this.chartReadoutPlot.Update();
        }

        private void buttonStopSequence_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Send stop message");
                this.comPort.WriteLine("\x03");
                this.ifAbort = true;
                this.ifDataReceived = true;
            }
            catch
            {
                // Do nothing.
            }
        }
    }
}