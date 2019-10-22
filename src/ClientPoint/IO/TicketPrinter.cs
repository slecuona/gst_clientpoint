using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.IO {
    public class TicketPrinter {
        private SerialPort _serial;

        public TicketPrinter() {
            _serial = GetSerialPort();
        }

        private static SerialPort GetSerialPort() {
            var serial = new SerialPort {
                PortName = "Com3",
                BaudRate = 38400,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                Handshake = Handshake.XOnXOff
            };
            return serial;
        }

        public bool Print(string t, out string errMsg) {
            try {
                errMsg = null;
                _serial.Open();
                _serial.Write(t);
                _serial.Close();
                return true;
            } catch (Exception e) {
                Logger.Exception(e);
                errMsg = e.Message;
                return false;
            }
        }

        private Action<string> _statusHandle;
        public void GetStatus(Action<string> a) {
            try {
                _statusHandle = a;
                _serial.Open();
                //_serial.DataReceived += SerialOnDataReceived;
                _serial.Write("^S|^");
                var tries = 10;
                while (tries < 10) {
                    Thread.Sleep(200);
                }

                
                _statusHandle.Invoke(_serial.ReadExisting());
                _serial.Close();
            } catch (Exception e) {
                Logger.Exception(e);
                a.Invoke(e.Message);
            }
        }

        private void SerialOnDataReceived(object sender, SerialDataReceivedEventArgs e) {
            var res = _serial.ReadExisting();
            if (!string.IsNullOrEmpty(res)) {
                _statusHandle.Invoke(res);
                _serial.Close();
            }
        }
    }
}
