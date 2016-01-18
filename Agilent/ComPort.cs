using System;
using System.Collections;
using System.IO;
using System.IO.Ports;

namespace Agilent
{
    class ComPort : SerialPort
    {
        public ComPort(string portName, int baudRate, string parity, int dataBits, int stopBits)
            : base()
        {
            this.PortName = portName;
            this.BaudRate = baudRate;
            this.DataBits = dataBits;
            this.DtrEnable = true;
            this.ReadTimeout = 1000000;
            switch (stopBits)
            {
                case 0: this.StopBits = StopBits.None; break;
                case 1: this.StopBits = StopBits.One; break;
                case 2: this.StopBits = StopBits.Two; break;
            }
            switch (parity)
            {
                case "None": this.Parity = Parity.None; break;
                case "Odd": this.Parity = Parity.Odd; break;
                case "Even": this.Parity = Parity.Even; break;
            }
        }

        public ComPort()
            : base()
        {

        }
    }
}