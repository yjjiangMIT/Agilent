using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;

namespace Agilent
{
    class Command
    {
        public Command(string line, int delay)
        {
            this.line = line;
            this.delay = delay;
        }

        private string line;
        private int delay;

        public string Line
        {
            get
            {
                return this.line;
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
        private int counter;
        private int total;

        public Sequence(StreamReader reader)
        {
            this.commands = new List<Command>();
            this.description = "";
            this.LoadSequence(reader);
        }

        public void LoadSequence(StreamReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Sequence:"))
                {
                    break;
                }
            }
            while ((line = reader.ReadLine()) != "")
            {
                string[] splitLine = line.Split('#');
                this.commands.Add(new Command(splitLine[0].TrimEnd(' '), int.Parse(splitLine[1])));
            }
            this.total = this.commands.Count;
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
            this.counter = 0;
        }

        public override string ToString()
        {
            return this.description;
        }

        public Command NextCommand()
        {
            if (this.counter < this.total)
            {
                Command nextCommand = this.commands[this.counter];
                this.counter += 1;
                return nextCommand;
            }
            else
            {
                return null;
            }
        }

        public void ResetCounter()
        {
            this.counter = 0;
        }
    }
}
