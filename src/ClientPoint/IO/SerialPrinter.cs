using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
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
                var writeTries = 0;
                while (writeTries < 5) {
                    writeTries++;
                    _serial = GetSerialPort();
                    _serial.Open();
                    _serial.Write(cmd);
                    PrintBytes("SerialWrite", cmd);
                    var readTries = 0;
                    while (readTries < 5) {
                        readTries++;
                        Thread.Sleep(100);
                        res = _serial.ReadExisting();
                        if (!string.IsNullOrEmpty(res))
                            break;
                    }
                    if (!string.IsNullOrEmpty(res))
                        break;
                    _serial.DiscardInBuffer();
                    _serial.DiscardOutBuffer();
                    _serial.Close();
                    _serial.Dispose();
                    Thread.Sleep(200);
                }
                PrintBytes("SerialRead", res);
                if(_serial.IsOpen)
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

        protected bool PortExists() =>
            SerialPort.GetPortNames().Any(x => x.ToLower() == PortName?.ToLower());

        [Conditional("DEBUG")]
        private static void PrintBytes(string m, string r) {
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
