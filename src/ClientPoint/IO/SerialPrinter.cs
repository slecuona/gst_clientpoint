using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using ClientPoint.Utils;
using static ClientPoint.Utils.ExUtils;

namespace ClientPoint.IO {
    public class SerialPrinter {
        private SerialPort _serial;

        protected virtual string PortName { get; set; }
        protected virtual int BaudRate { get; set; }
        protected virtual int DataBits { get; set; }
        protected virtual Parity Parity { get; set; }
        protected virtual StopBits StopBits { get; set; }
        protected virtual Handshake Handshake { get; set; }

        public SerialPrinter() {
        }

        private SerialPort GetSerialPort() {
            DieIf(PortName == null, "Serial PortName null.");
            DieIf(BaudRate == 0, "Serial BaudRate 0.");
            DieIf(DataBits == 0, "Serial DataBits 0.");
            var serial = new SerialPort {
                PortName = PortName,
                BaudRate = BaudRate,
                DataBits = DataBits,
                Parity = Parity,
                StopBits = StopBits,
                Handshake = Handshake
            };
            return serial;
        }

        protected bool TryWrite(string t, out string errMsg) {
            try {
                if (_serial == null) {
                    _serial = GetSerialPort();
                }

                errMsg = null;
                _serial.Open();
                _serial.Write(t);
                _serial.Close();
                return true;
            }
            catch (Exception e) {
                Logger.Exception(e);
                errMsg = e.Message;
                return false;
            }
            finally {
                _serial.Dispose();
                _serial = null;
            }
        }
        
        // Write & Read
        protected bool TrySendCmd(string cmd, out string res) {
            res = null;
            try {
                if (_serial == null) {
                    _serial = GetSerialPort();
                }
                _serial.Open();
                _serial.Write(cmd);
                PrintBytes("SerialWrite", cmd);
                var tries = 0;
                while (tries < 5) {
                    tries++;
                    Thread.Sleep(200);
                    res = _serial.ReadExisting();
                    if (!string.IsNullOrEmpty(res))
                        break;
                }
                PrintBytes("SerialRead", res);
                _serial.Close();
                return !string.IsNullOrEmpty(res);
            } catch (Exception e) {
                res = $"ERR. {e.Message}";
                Logger.Exception(e);
                return false;
            } finally {
                _serial?.Dispose();
                _serial = null;
            }
        }
        
        [Conditional("DEBUG")]
        private void PrintBytes(string m, string r) {
            if (r != null) {
                var i = 0;
                foreach (var b in r) {
                    Debug.WriteLine($"{m}[{i}] => {(byte)b}");
                    i++;
                }
            } else
                Debug.WriteLine($"{m} => null");
        }
    }
}
