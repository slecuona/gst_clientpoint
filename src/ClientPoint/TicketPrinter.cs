using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;
using ClientPoint.Utils;

namespace ClientPoint {
    public static class TicketPrinter {

        public static void Print(string s) {
            try {
                var serial = new SerialPort();
                serial.PortName = "Com3";
                serial.BaudRate = 38400;
                serial.DataBits = 8;
                serial.Parity = Parity.None;
                serial.StopBits = StopBits.One;
                serial.Handshake = Handshake.XOnXOff;
                serial.Open();
                serial.WriteLine(s);
                Thread.Sleep(2000);
                var res = serial.ReadLine();
                Logger.Write($"Serial res: {res}");
                serial.Close();
            }
            catch (Exception e) {
                Logger.Exception(e);
                MsgBox.Show(e.Message);
            }
        }
    }
}
