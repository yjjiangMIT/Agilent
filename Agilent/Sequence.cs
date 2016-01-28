using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Agilent
{
    class Command
    {
        /** Command class: stores a string of SCPI command and the delay time after this command. */

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
        
        public Sequence()
        {
            this.setup = new List<Command>();
            this.loop = new List<Command>();
            this.description = "";
        }

        public int SetupLength
        {
            get
            {
                return this.setup.Count;
            }
        }

        public int LoopLength
        {
            get
            {
                return this.loop.Count;
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

        public void LoadSequence(StreamReader reader, string fileName)
        {
            /** Load a sequence from a file. */

            string line;
            string[] splitLine;

            /* Load discription. */
           
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Description:"))
                {
                    break;
                }
            }
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length > 0)
                {
                    this.description = line;
                    Console.WriteLine(this.description);
                    break;
                }
            }

            /* Load setup. */
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Setup:"))
                {
                    Console.WriteLine(line);
                    break;
                }
            }
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length > 0)
                {
                    if (line.StartsWith("Loop:"))
                    {
                        break;
                    }
                    else
                    {
                        if (line.Length > 0)
                        {
                            Console.WriteLine(line + "ddd");
                            splitLine = line.Split('#');
                            this.setup.Add(new Command(splitLine[0].TrimEnd(' '), int.Parse(splitLine[1])));
                        }
                    }
                }
            }
          
            /* Load loop. */
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length > 0)
                {
                    Console.WriteLine(line + "ddd");
                    splitLine = line.Split('#');
                    this.loop.Add(new Command(splitLine[0].TrimEnd(' '), int.Parse(splitLine[1])));
                }
            }

            /* Load file information. */
            this.filePath = fileName;
            splitLine = fileName.Split('\\');
            this.fileName = splitLine[splitLine.Length - 1].Split('.')[0];

            /* Close StreamReader. */
            reader.Close();
        }

        public void SaveSequence(StreamWriter writer)
        {
            /** Write this sequence to a file. */

            /* Write description. */
            writer.WriteLine("Description:");
            writer.WriteLine(this.ToString());
            writer.Write(Environment.NewLine);

            /* Write setup. */
            writer.WriteLine("Setup:");
            for (int i = 0; i < this.setup.Count; i++)
            {
                writer.Write(this.GetSetupCommand(i).Scpi);
                writer.Write(" #");
                writer.WriteLine(this.GetSetupCommand(i).Delay);
            }
            writer.Write(Environment.NewLine);

            /* Write loop. */
            writer.WriteLine("Loop:");
            for (int i = 0; i < this.loop.Count; i++)
            {
                writer.Write(this.GetLoopCommand(i).Scpi);
                writer.Write(" #");
                writer.WriteLine(this.GetLoopCommand(i).Delay);
            }
        }

        public void DisplaySetup(RichTextBox richTextBoxSetup, RichTextBox richTextBoxSetupDelay, int currentIndex = -1)
        {
            /** Display setup sequence on the GUI. Highlight the indexed command. */

            richTextBoxSetup.Clear();
            richTextBoxSetupDelay.Clear();

            /* Command #index is highlighted. */
            if (this.setup.Count > 0)
            {
                for (int i = 0; i < this.setup.Count; i++)
                {
                    if (i == currentIndex)
                    {
                        richTextBoxSetup.SelectionBackColor = Color.Yellow;
                        richTextBoxSetupDelay.SelectionBackColor = Color.Yellow;
                        richTextBoxSetup.SelectionStart = richTextBoxSetup.Text.Length;
                        richTextBoxSetup.ScrollToCaret();
                        richTextBoxSetupDelay.SelectionStart = richTextBoxSetupDelay.Text.Length;
                        richTextBoxSetupDelay.ScrollToCaret();
                    }
                    else
                    {
                        richTextBoxSetup.SelectionBackColor = Color.White;
                        richTextBoxSetupDelay.SelectionBackColor = Color.White;
                    }
                    richTextBoxSetup.AppendText(this.setup[i].Scpi + "\r\n");
                    richTextBoxSetupDelay.AppendText(this.setup[i].Delay + "\r\n");                 
                }
            }
        }

        public void DisplayLoop(RichTextBox richTextBoxLoop, RichTextBox richTextBoxLoopDelay, int currentIndex = -1)
        {
            /** Display loop sequence on the GUI. Highlight the indexed command. */

            richTextBoxLoop.Clear();
            richTextBoxLoopDelay.Clear();

            /* Command #index is highlighted. */
            if (this.loop.Count > 0)
            {
                for (int i = 0; i < this.loop.Count; i++)
                {
                    if (i == currentIndex)
                    {
                        richTextBoxLoop.SelectionBackColor = Color.Yellow;
                        richTextBoxLoopDelay.SelectionBackColor = Color.Yellow;
                        richTextBoxLoop.SelectionStart = richTextBoxLoop.Text.Length;
                        richTextBoxLoop.ScrollToCaret();
                        richTextBoxLoopDelay.SelectionStart = richTextBoxLoopDelay.Text.Length;
                        richTextBoxLoopDelay.ScrollToCaret();
                    }
                    else
                    {
                        richTextBoxLoop.SelectionBackColor = Color.White;
                        richTextBoxLoopDelay.SelectionBackColor = Color.White;
                    }
                    richTextBoxLoop.AppendText(this.loop[i].Scpi + "\r\n");
                    richTextBoxLoopDelay.AppendText(this.loop[i].Delay + "\r\n");
                    
                }
            }
        }

        public void DisplayDescription(RichTextBox richTextBoxDescription)
        {
            /** Display description on the GUI. */

            richTextBoxDescription.Text = this.description;
            richTextBoxDescription.SelectionStart = richTextBoxDescription.Text.Length;
            richTextBoxDescription.ScrollToCaret();
        }

        public void Update(RichTextBox richTextBoxSetup, RichTextBox richTextBoxSetupDelay,
            RichTextBox richTextBoxLoop, RichTextBox richTextBoxLoopDelay, RichTextBox richTextBoxDescription)
        {
            /** Update sequence by loading from textboxes. */

            int length;
            string scpi;
            int delay;

            this.setup.Clear();
            this.loop.Clear();
            
            /* Update setup. */
            length = richTextBoxSetup.Lines.Length;
            for (int i = 0; i < length; i++)
            {

                scpi = richTextBoxSetup.Lines[i];
                if (scpi.Length > 0)
                {
                    try
                    {
                        delay = int.Parse(richTextBoxSetupDelay.Lines[i]);
                    }
                    catch
                    {
                        delay = 0;
                    }
                    this.setup.Add(new Command(scpi, delay));
                }
            }

            /* Update loop. */
            length = richTextBoxLoop.Lines.Length;
            for (int i = 0; i < length; i++)
            {

                scpi = richTextBoxLoop.Lines[i];
                if (scpi.Length > 0)
                {
                    try
                    {
                        delay = int.Parse(richTextBoxLoopDelay.Lines[i]);
                    }
                    catch
                    {
                        delay = 0;
                    }
                    this.loop.Add(new Command(scpi, delay));
                }
            }

            /* Update description. */
            this.description = richTextBoxDescription.Text;
        }

        public override string ToString()
        {
            /** Get the description of the sequence. */

            return this.description;
        }

        public Command GetSetupCommand(int index)
        {
            /* Get a setup command with given index. */

            if (index < this.setup.Count)
            {
                return this.setup[index];
            }
            else
            {
                return null;
            }
        }

        public Command GetLoopCommand(int index)
        {
            /* Get a loop command with given index. */

            if (index < this.loop.Count)
            {
                return this.loop[index];
            }
            else
            {
                return null;
            }
        }
    }
}