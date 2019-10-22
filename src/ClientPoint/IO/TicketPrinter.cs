using System;
using System.IO.Ports;
using System.Threading;
using ClientPoint.Utils;

namespace ClientPoint.IO {

    // Utiliza protocolo TCL
    // https://stackoverflow.com/questions/5903331/tcl-thermal-control-language-printer-protocol-references

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
        
        public bool GetStatus(out string status) {
            status = null;
            try {
                _serial.Open();
                _serial.Write("^S|^");
                var tries = 0;
                while (tries < 5) {
                    tries++;
                    Thread.Sleep(200);
                    status = _serial.ReadExisting();
                    if (!string.IsNullOrEmpty(status))
                        break;
                }
                _serial.Close();
                return !string.IsNullOrEmpty(status);
            } catch (Exception e) {
                Logger.Exception(e);
                return false;
            }
        }
    }
}
