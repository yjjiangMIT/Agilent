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
        /** Set some time constants */
        private static int DELAY_BETWEEN_ROUNDS = 0;
        private static int DELAY_BETWEEN_COMMANDS = 20;

        private static bool IS_WORK_MODE = false; // Set false if want to debug without serial connection.
        
        private enum DataType { MEASUREMENT, RESOLUTION }; // Distinguish various types of read-in data.

        private Sequence sequence; // Stores a sequence of SCPI commands and delay times.
        private ComPort comPort; // RS232 serial port.
        private ConnectForm connectForm; // Pop-up form that shows serial connection options.
        private DataType expectedDataType; // Expected type of data.
        private bool ifAbort; // If abort sequence after current iteration.
        private bool ifAbortImmediately; // If abort sequence immediately and jump out of current iteration.
        private bool ifDataReceived; // If expected data has been received.
        private int outputCounter; // Count number of outputs in a single measurement. 

        public Form1()
        {
            InitializeComponent();
            this.connectForm = new ConnectForm(this);
            this.connectForm.Dispose();
            this.comPort = new ComPort();
            this.sequence = new Sequence();

            this.checkBoxStop.Checked = false;
            this.ifAbort = false;

            /* Disable buttons that writes to serial port. */
            if (IS_WORK_MODE)
            {
                this.buttonRunSequence.Enabled = false;
                this.buttonRunSequenceOnce.Enabled = false;
                this.buttonStopSequence.Enabled = false;
            }
        }



        /** *********************************************** */
        /** *** All about setting up serial connection. *** */
        /** *********************************************** */

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            /** Connect/disconnect to DMM via RS232. */

            if (this.comPort.IsOpen)
            {
                this.comPort.Close();
                /* Disable buttons that writes to serial port. */
                if (IS_WORK_MODE)
                {
                    this.buttonRunSequence.Enabled = false;
                    this.buttonRunSequenceOnce.Enabled = false;
                    this.buttonStopSequence.Enabled = false;
                }
            }
            else
            {
                if (this.connectForm.IsDisposed)
                {
                    this.connectForm = new ConnectForm(this);
                    this.connectForm.Show();
                }
            }
            this.UpdateConnectionDisplay();
        }

        public void OpenPort(string portName, int baudRate, string parity, int dataBits, int stopBits)
        {
            /** Open serial port that talks to the DMM. */

            this.comPort = new ComPort(portName, baudRate, parity, dataBits, stopBits);
            this.comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            try
            {
                this.comPort.Open();
            }
            catch
            {
                // Do nothing.
            }
        }

        public void UpdateConnectionDisplay()
        {
            /** Update GUI display to reflect current connection status. */

            if (this.comPort.IsOpen)
            {
                buttonConnect.Text = "Disconnect";
                labelConnectStatus.Text = "Status: Connected";
                this.buttonRunSequence.Enabled = true;
                this.buttonRunSequenceOnce.Enabled = true;
                this.buttonStopSequence.Enabled = true;
            }
            else
            {
                buttonConnect.Text = "Connect";
                labelConnectStatus.Text = "Status: Unconnected";
                if (IS_WORK_MODE)
                {
                    this.buttonRunSequence.Enabled = false;
                    this.buttonRunSequenceOnce.Enabled = false;
                    this.buttonStopSequence.Enabled = false;
                }
            }
        }



        /** ************************************* */
        /** *** All about running a sequence. *** */
        /** ************************************* */

        /** Button operations on a sequence. */
        private void buttonImportSequence_Click(object sender, EventArgs e)
        {
            /** Load a sequence from .txt file. */

            Stream stream = null;
            StreamReader reader = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"sequences";
            openFileDialog.Filter = "txt files(*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        using (reader = new StreamReader(stream))
                        {
                            /* Load the sequence and show it on the form. */
                            this.sequence.LoadSequence(reader, openFileDialog.FileName);
                            this.sequence.DisplaySetup(this.richTextBoxSetup, this.richTextBoxSetupDelay);
                            this.sequence.DisplayLoop(this.richTextBoxLoop, this.richTextBoxLoopDelay);
                            this.sequence.DisplayDescription(this.richTextBoxDescription);
                        }
                    }
                }
                catch
                {
                    // Do nothing.
                }
            }
        }

        private void buttonClearSequence_Click(object sender, EventArgs e)
        {
            /** Clear sequence on display. */

            this.richTextBoxSetup.Clear();
            this.richTextBoxSetupDelay.Clear();
            this.richTextBoxLoop.Clear();
            this.richTextBoxLoopDelay.Clear();
            this.richTextBoxDescription.Clear();
        }

        private void buttonRunSequence_Click(object sender, EventArgs e)
        {
            /** Run sequence over and over again. */

            Thread threadRunSeq = new Thread(new ThreadStart(this.RunSequence));
            threadRunSeq.Start();
        }

        private void buttonRunSequenceOnce_Click(object sender, EventArgs e)
        {
            /** Run sequence only once. */

            this.checkBoxStop.Checked = true;
            Thread threadRunSeq = new Thread(new ThreadStart(this.RunSequence));
            threadRunSeq.Start();
        }

        private void buttonSaveSequence_Click(object sender, EventArgs e)
        {
            /** Save the displayed sequence to file. */

            Stream stream = null;
            StreamWriter writer = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"sequences";
            saveFileDialog.Filter = "txt files(*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = this.sequence.FileName;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = saveFileDialog.OpenFile()) != null)
                    {
                        using (writer = new StreamWriter(stream))
                        {
                            this.sequence.Update(this.richTextBoxSetup, this.richTextBoxSetupDelay,
                                this.richTextBoxLoop, this.richTextBoxLoopDelay, this.richTextBoxDescription);
                            this.sequence.SaveSequence(writer);
                        }
                    }
                }
                catch
                {
                    // Do nothing.
                }
            }
        }

        /** Change status to run/idle. */
        private delegate void ChangeStatusCallback();

        private void ChangeStatusToRun()
        {
            this.sequence.Update(this.richTextBoxSetup, this.richTextBoxSetupDelay,
                this.richTextBoxLoop, this.richTextBoxLoopDelay, this.richTextBoxDescription);

            this.ifAbortImmediately = false;
            this.ifDataReceived = false;
            this.ifAbort = this.checkBoxStop.Checked;

            this.labelRunStatus.Text = "Status: Running";
            this.buttonRunSequence.Enabled = false;
            this.buttonRunSequenceOnce.Enabled = false;
            this.buttonConnect.Enabled = false;
        }

        private void ChangeStatusToIdle()
        {
            this.checkBoxStop.Checked = false;
            this.labelRunStatus.Text = "Status: Idle";
            this.buttonRunSequence.Enabled = true;
            this.buttonRunSequenceOnce.Enabled = true;
            this.buttonConnect.Enabled = true;
        }

        /** Initialize and run a sequence on DMM. */
        private void InitializeDMM()
        {
            /** Send commands to initialize DMM. */

            if (IS_WORK_MODE)
            {
                this.comPort.WriteLine("\x03"); // Stop unfinished job.
                Thread.Sleep(DELAY_BETWEEN_COMMANDS);
                this.comPort.WriteLine("*CLS"); // Clear previous setup.
                Thread.Sleep(DELAY_BETWEEN_COMMANDS);
                this.comPort.WriteLine("SYST:REM"); // Put DMM in remote state.
                Thread.Sleep(DELAY_BETWEEN_COMMANDS);
            }
            else
            {
                Console.WriteLine("\x03");
                Console.WriteLine("*CLS");
                Console.WriteLine("SYST:REM");
            }
        }

        private void RunSequence()
        {
            /** Run setup once and run loop until an abort instruction. */

            Command currentCommand;

            try // Just in case serial connection breaks down unexpectedly.
            {
                if (this.InvokeRequired)
                {
                    /* Change display status to run. */
                    this.Invoke(new ChangeStatusCallback(this.ChangeStatusToRun));

                    this.InitializeDMM();

                    /* Run setup commands. */
                    for (int i = 0; i < this.sequence.SetupLength; i++)
                    {
                        /* Hightlight current command. */
                        this.Invoke(new ColorDisplayCommandCallback
                            (this.ColorDisplayCurrentSetup), new object[] { i });

                        currentCommand = this.sequence.GetSetupCommand(i);
                        if (IS_WORK_MODE)
                        {
                            this.comPort.WriteLine(currentCommand.Scpi); // Send command to DMM.
                        }
                        else
                        {
                            Console.WriteLine(currentCommand.Scpi);
                        }

                        if (this.ifAbortImmediately)
                        {
                            break;
                        }
                        Thread.Sleep(currentCommand.Delay);
                    }

                    /* Remove hightlight. */
                    this.Invoke(new ColorDisplayCommandCallback
                        (this.ColorDisplayCurrentSetup), new object[] { -1 });

                    /* Run loop commands. */
                    /* Outer iteration: run loop commands over and over again. */
                    do
                    {
                        if (this.ifAbortImmediately)
                        {
                            break;
                        }

                        /* Inner iteration: run each command in loop. */
                        for (int i = 0; i < this.sequence.LoopLength; i++)
                        {
                            /* Highlight current command. */
                            this.Invoke(new ColorDisplayCommandCallback
                                (this.ColorDisplayCurrentLoop), new object[] { i });

                            currentCommand = this.sequence.GetLoopCommand(i);
                            if (IS_WORK_MODE)
                            {
                                this.comPort.WriteLine(currentCommand.Scpi); // Send command to DMM.
                            }
                            else
                            {
                                Console.WriteLine(currentCommand.Scpi);
                            }

                            /* When a measurement request is sent. */
                            if (currentCommand.Scpi.EndsWith("?"))
                            {
                                if (currentCommand.Scpi.EndsWith("RES?")) // Ask for a resolution.
                                {
                                    this.expectedDataType = DataType.RESOLUTION;
                                }
                                else // Ask for a measurement.
                                {
                                    this.expectedDataType = DataType.MEASUREMENT;
                                }
                                while (!this.ifDataReceived && IS_WORK_MODE) ;
                                    // Do not continue unless some data are received.
                                this.ifDataReceived = false;
                            }

                            if (this.ifAbortImmediately)
                            {
                                break;
                            }
                            Thread.Sleep(currentCommand.Delay);
                        }

                        /* Remove hightlight. */
                        this.Invoke(new ColorDisplayCommandCallback
                            (this.ColorDisplayCurrentLoop), new object[] { -1 });

                        /* Delay before the next round. */
                        Thread.Sleep(DELAY_BETWEEN_ROUNDS);
                    }
                    while (!this.ifAbort);

                    /* Change display status to idle. */
                    this.Invoke(new ChangeStatusCallback(this.ChangeStatusToIdle));
                }
            }
            catch
            {
                // Do nothing.
            }
        }

        /** Stop running sequence. */
        private void buttonStopSequence_Click(object sender, EventArgs e)
        {
            /* Abort sequence immediately when button is clicked. */

            try
            {
                if (IS_WORK_MODE)
                {
                    this.comPort.WriteLine("\x03");
                }
                else
                {
                    Console.WriteLine("\x03");
                }
                this.ifAbort = true;
                this.ifAbortImmediately = true;
                this.ifDataReceived = true;
            }
            catch
            {
                // Do nothing.
            }
        }

        private void checkBoxStop_CheckedChanged(object sender, EventArgs e)
        {
            /* Do not run another round if checked. */

            this.ifAbort = this.checkBoxStop.Checked;
        }



        /** ****************************************** */
        /** *** All about parsing serial messages. *** */
        /** ****************************************** */

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            /* Parse data when they arrive at input buffer. */

            if (this.expectedDataType == DataType.MEASUREMENT)
            {
                this.ParseMeasurement();
            }
            else
            {
                this.ParseResolution();
            }
        }

        private delegate void ParseCallback();

        private void ParseMeasurement()
        {
            /** Parse a measurement result. */

            string[] measurement;

            if (this.InvokeRequired)
            {
                this.Invoke(new ParseCallback(this.ParseMeasurement));
            }
            else
            {
                try
                {
                    measurement = this.comPort.ReadLine().Split(',');
                    this.outputCounter = 0;
                    foreach (string oneLine in measurement)
                    {
                        if (oneLine.Length > 0)
                        {
                            this.richTextBoxMeasurement.AppendText(oneLine.TrimEnd((char)13) + Environment.NewLine);
                            this.richTextBoxMeasurement.SelectionStart = this.richTextBoxMeasurement.Text.Length;
                            this.richTextBoxMeasurement.ScrollToCaret();
                            this.outputCounter++;
                        }
                    }
                }
                catch
                {
                    // Do nothing.
                }

                this.comPort.WriteLine("\x03"); // Stop unfinished job.
            }
        }

        private void ParseResolution()
        {
            /** Parse a resulution result. */

            string resolution;
            int emptyNumber;

            if (this.InvokeRequired)
            {
                this.Invoke(new ParseCallback(this.ParseResolution));
            }
            else
            {
                /* Empty-string-padding until aligned with previous measurement in richTextBoxMeasurement. */
                emptyNumber = this.richTextBoxMeasurement.Lines.Length
                    - this.richTextBoxResolution.Lines.Length - this.outputCounter;
                for (int i = 0; i < emptyNumber; i++)
                {
                    this.richTextBoxResolution.AppendText(Environment.NewLine);
                }

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
                    resolution = "N/A" + Environment.NewLine;
                }
                for (int i = 0; i < this.outputCounter; i++)
                {
                    this.richTextBoxResolution.AppendText(resolution);
                    this.richTextBoxResolution.SelectionStart = this.richTextBoxResolution.Text.Length;
                    this.richTextBoxResolution.ScrollToCaret();
                }
                this.ifDataReceived = true;
            }
        }
        


        /** ************************** */
        /** *** All about display. *** */
        /** ************************** */

        private delegate void ColorDisplayCommandCallback(int index);

        private void ColorDisplayCurrentSetup(int index)
        {
            this.sequence.DisplaySetup(this.richTextBoxSetup, this.richTextBoxSetupDelay, index);
        }

        private void ColorDisplayCurrentLoop(int index)
        {
            this.sequence.DisplayLoop(this.richTextBoxLoop, this.richTextBoxLoopDelay, index);
        }


        
        /** *************************** */
        /** *** All about readouts. *** */
        /** *************************** */

        private void buttonClearReadout_Click(object sender, EventArgs e)
        {
            /* Clear displayed readout. */

            this.richTextBoxMeasurement.Clear();
            this.richTextBoxResolution.Clear();
            this.splitContainerReadout.Update();
        }

        private void buttonSaveReadout_Click(object sender, EventArgs e)
        {
            /** Save displayed readouts to a .csv file. */

            Stream stream = null;
            StreamWriter writer = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"readouts";
            saveFileDialog.Filter = "csv files(*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = this.sequence.FileName;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = saveFileDialog.OpenFile()) != null)
                    {
                        using (writer = new StreamWriter(stream))
                        {
                            WriteReadoutToFile(writer);
                        }
                    }
                }
                catch
                {
                    // Do nothing.
                }
            }
        }

        private void WriteReadoutToFile(StreamWriter writer)
        {
            /** Write readout to file. */

            string[] measurement = this.richTextBoxMeasurement.Text.Split('\n');
            string[] resolution = this.richTextBoxResolution.Text.Split('\n');
            int length = Math.Min(measurement.Length, resolution.Length);

            writer.WriteLine("Sequence file name," + this.sequence.FileName);
            writer.WriteLine("Sequence file path," + this.sequence.FilePath);
            writer.WriteLine("Description," + this.sequence.ToString());
            writer.Write(Environment.NewLine);
            writer.WriteLine("Readout,Resolution");
            for (int i = 0; i < length; i++)
            {
                writer.Write(measurement[i]);
                writer.Write(",");
                writer.WriteLine(resolution[i]);
            }
            writer.Close();
        }

        private void buttonPlotReadout_Click(object sender, EventArgs e)
        {
            /** Plot measurements. */

            int counter = 1;
            string[] measurement;

            this.chartReadoutPlot.Series.Clear();
            this.chartReadoutPlot.Series.Add("Measurement");
            this.chartReadoutPlot.Series["Measurement"].ChartType = SeriesChartType.Line;
            if (richTextBoxMeasurement.SelectedText.Length > 0)
            {
                measurement = richTextBoxMeasurement.SelectedText.Split('\n');
            }
            else
            {
                measurement = richTextBoxMeasurement.Text.Split('\n');
            }
            foreach (string oneLine in measurement)
            {
                try
                { 
                    this.chartReadoutPlot.Series["Measurement"].Points.AddXY(counter, double.Parse(oneLine));
                    counter++;
                }
                catch
                {
                    //Do nothing.
                }
            }
            this.chartReadoutPlot.Update();
        }
    }
}