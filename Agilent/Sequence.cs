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
        private List<Command> commands;
        private string description;
        private int length;
        private string filePath;
        private string fileName;

        public Sequence()
        {
            this.commands = new List<Command>();
            this.description = "";
            this.length = 0;
        }

        // Number of commands in the sequence
        public int Length
        {
            get
            {
                return this.length;
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
        }

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

            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Sequence:"))
                {
                    break;
                }
            }
            while ((line = reader.ReadLine()) != "")
            {
                splitLine = line.Split('#');
                this.commands.Add(new Command(splitLine[0].TrimEnd(' '), int.Parse(splitLine[1])));
            }
            this.length = this.commands.Count;
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

            this.filePath = fileName;
            splitLine = fileName.Split('\\');
            this.fileName = splitLine[splitLine.Length - 1].Split('.')[0];
            reader.Close();
        }

        // Display a sequence to Form
        public void DisplaySequence(RichTextBox tbxCommand, RichTextBox tbxDelay, RichTextBox tbxDescription, int currentIndex = -1)
        {
            tbxCommand.Clear();
            tbxDelay.Clear();
            if (length > 0)
            {
                for (int i = 0; i < this.length; i++)
                {
                    if (i == currentIndex)
                    {
                        tbxCommand.SelectionBackColor = Color.Yellow;
                        tbxDelay.SelectionBackColor = Color.Yellow;
                    }
                    else
                    {
                        tbxCommand.SelectionBackColor = Color.White;
                        tbxCommand.SelectionBackColor = Color.White;
                    }
                    tbxCommand.AppendText(this.commands[i].Scpi + "\r\n");
                    tbxDelay.AppendText(this.commands[i].Delay + "\r\n");
                }
            }
            tbxDescription.Text = this.description;
        }

        // Load a sequence from Form
        public void UpdateSequence(RichTextBox richTextBoxCommand, RichTextBox richTextBoxDelay, RichTextBox richTextBoxDescription)
        {
            this.commands.Clear();
            for (int i = richTextBoxCommand.Lines.Length - 1; i >= 0; i--)
            {
                if (richTextBoxCommand.Lines[i].Length > 0)
                {
                    this.length = i + 1;
                    break;
                }
            }
            this.description = richTextBoxDescription.Text;
            for (int i = 0; i < this.length; i++)
            {
                this.commands.Add(new Command(richTextBoxCommand.Lines[i], int.Parse(richTextBoxDelay.Lines[i])));
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
            if (index < this.length)
            {
                return this.commands[index];
            }
            else
            {
                return null;
            }
        }
    }
}
