using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing;

namespace Agilent
{
    class Command
    {
        public Command(string scpi, int delay)
        {
            this.scpi = scpi;
            this.delay = delay;
        }

        private string scpi;
        private int delay;

        public string Scpi
        {
            get
            {
                return this.scpi;
            }
        }

        public int Delay
        {
            get
            {
                return this.delay;
            }
        }
    }
        
    class Sequence
    {
        private List<Command> setup; // SCPI commands that will be executed only once.
        private List<Command> loop; // SCPI commands that will be executed over and over again.
        private string description; // Description of this sequence.
        private string filePath; // Path of the file that stores this sequence.
        private string fileName; // Name of the file that stores this sequence.
        public enum CommandType {SETUP, LOOP};

        public Sequence()
        {
            this.setup = new List<Command>();
            this.loop = new List<Command>();
            this.description = "";
        }

        // Get the number of commands in setup.
        public int SetupLength
        {
            get
            {
                return this.setup.Count;
            }
        }

        // Get the number of commands in loop.
        public int LoopLength
        {
            get
            {
                return this.loop.Count;
            }
        }

        // Get the name of the file that stores this sequence.
        public string FileName
        {
            get
            {
                return this.fileName;
            }
        }

        // Get the path of the file that stores this sequence.
        public string FilePath
        {
            get
            {
                return this.filePath;
            }
        }

        // Load a sequence from a file
        public void LoadSequence(StreamReader reader, string fileName)
        {
            string line;
            string[] splitLine;

            // Load discription.
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Description:"))
                {
                    break;
                }
            }
            if ((line = reader.ReadLine()) != null)
            {
                this.description = line;
            }

            // Load setup.
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Setup:"))
                {
                    break;
                }
            }
            while ((line = reader.ReadLine()) != "")
            {
                splitLine = line.Split('#');
                this.setup.Add(new Command(splitLine[0].TrimEnd(' '), int.Parse(splitLine[1])));
            }

            // Load loop.
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Loop:"))
                {
                    break;
                }
            }
            while ((line = reader.ReadLine()) != "")
            {
                splitLine = line.Split('#');
                this.loop.Add(new Command(splitLine[0].TrimEnd(' '), int.Parse(splitLine[1])));
            }
            
            // Load file information.
            this.filePath = fileName;
            splitLine = fileName.Split('\\');
            this.fileName = splitLine[splitLine.Length - 1].Split('.')[0];

            // Close StreamReader.
            reader.Close();
        }

        // Display a sequence to Form
        public void DisplaySequence(RichTextBox richTextBoxSequence, RichTextBox richTextBoxDelay, RichTextBox richTextBoxDescription, CommandType type, int currentIndex = -1)
        {
            int length;

            if (type == CommandType.SETUP)
            {
                length = this.setup.Count;
            }
            else
            {
                length = this.loop.Count;
            }
            
            richTextBoxSequence.Clear();
            richTextBoxDelay.Clear();
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    if (i == currentIndex)
                    {
                        richTextBoxSequence.SelectionBackColor = Color.Yellow;
                        richTextBoxDelay.SelectionBackColor = Color.Yellow;
                    }
                    else
                    {
                        richTextBoxSequence.SelectionBackColor = Color.White;
                        richTextBoxSequence.SelectionBackColor = Color.White;
                    }
                    richTextBoxSequence.AppendText(this.setup[i].Scpi + "\r\n");
                    richTextBoxDelay.AppendText(this.setup[i].Delay + "\r\n");
                }
            }
            richTextBoxDescription.Text = this.description;
        }

        // Load a sequence from Form
        public void UpdateSequence(RichTextBox richTextBoxSetup, RichTextBox richTextBoxDelay, RichTextBox richTextBoxDescription)
        {
            this.setup.Clear();
            for (int i = richTextBoxSetup.Lines.Length - 1; i >= 0; i--)
            {
                if (richTextBoxSetup.Lines[i].Length > 0)
                {
                    this.setupLength = i + 1;
                    break;
                }
            }
            this.description = richTextBoxDescription.Text;
            for (int i = 0; i < this.setupLength; i++)
            {
                this.setup.Add(new Command(richTextBoxSetup.Lines[i], int.Parse(richTextBoxDelay.Lines[i])));
            }
        }

        // Get the description of a sequence
        public override string ToString()
        {
            return this.description;
        }

        // Get a command with given index
        public Command getCommand(int index)
        {
            if (index < this.setupLength)
            {
                return this.setup[index];
            }
            else
            {
                return null;
            }
        }
    }
}
