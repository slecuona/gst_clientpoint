using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientPoint.Utils;
using static ClientPoint.Utils.ExUtils;

namespace ClientPoint.IO {
    
    // Printer: Custom TG2480H
    // Product key: 915CH011100300

    public class VoucherPrinter : SerialPrinter {
        protected override string PortName =>
            Config.VoucherPrinterPort;
        protected override int BaudRate =>
            Config.VoucherPrinterBaud;
        protected override int DataBits =>
            Config.VoucherPrinterDataBits;
        protected override Parity Parity =>
            Config.VoucherPrinterParity;
        protected override StopBits StopBits =>
            Config.VoucherPrinterStopBits;
        protected override Handshake Handshake =>
            Config.VoucherPrinterHandshake;


        public Action<bool, string> OnFinish;

        private string Ticket;

        public VoucherPrinter() { }

        public void PrintAsync(string tkt) {
            DieIf(string.IsNullOrEmpty(tkt), $"Ticket null or empty.");
            // Mando a imprimir tal cual viene de la API
            Ticket = tkt;
            var t = new Thread(Print);
            t.Start();
        }

        private void Print() {
            var success = base.TryWrite(Ticket, out string errMsg);
            if (!success) {
                OnFinish?.Invoke(false, errMsg);
                return;
            }

            var status = GetStatus();
            if (status.Contains(VoucherPrinterState.PRINT_STOPPED)) {
                OnFinish?.Invoke(false, "La impresora no pudo imprimir el voucher.");
                return;
            }

            OnFinish?.Invoke(true, null);
        }

        
        // https://reliance-escpos-commands.readthedocs.io/en/latest/realtime_status.html

        private const string CMD_ST_PRINTER = "\x10\x04\x01";
        private const string CMD_ST_PRINTER_OFF = "\x10\x04\x02";
        private const string CMD_ST_ERROR = "\x10\x04\x03";
        private const string CMD_ST_PAPPER_ROLL = "\x10\x04\x04";
        // Estos comandos no funcionan con esta impresora.
        private const string CMD_ST_PRINTER2 = "\x10\x04\x17";
        private const string CMD_ST_FULL = "\x10\x04\x20";

        public List<VoucherPrinterState> GetStatus() {
            if (!PortExists()) {
                return new List<VoucherPrinterState>() 
                    {VoucherPrinterState.PORT_NOT_EXISTS};
            }

            var success = false;
            var tries = 0;
            while (tries < 5) {
                tries++;
                success = TryGetSerialStatus(out var res);
                if (success)
                    return res;
                Thread.Sleep(200);
            }
            return new List<VoucherPrinterState>() {VoucherPrinterState.NO_RESPONSE};
        }

        private bool TryGetSerialStatus(out List<VoucherPrinterState> res) {
            res = new List<VoucherPrinterState>();
            if (TrySendCmd(CMD_ST_PRINTER, out string st_p)) {
                var b = (byte)st_p[0];
                var online = !IsBitSet(b, 3);
                Debug.WriteLine(online ? "ONLINE" : "OFFLINE");
                if(!online)
                    res.Add(VoucherPrinterState.OFFLINE);
            }
            else {
                Debug.WriteLine("=== ERROR ST");
                return false;
            }

            if (TrySendCmd(CMD_ST_PRINTER_OFF, out string st_off)) {
                var b = (byte)st_off[0];
                var cover_open = IsBitSet(b, 2);
                Debug.WriteLine(cover_open ? 
                    "COVER OPEN" : "COVER CLOSED");
                if(cover_open)
                    res.Add(VoucherPrinterState.COVER_OPEN);
                var feed_button = IsBitSet(b, 3);
                Debug.WriteLine(feed_button ? 
                    "FEED BUTTON" : "NOT FEED BUTTON");
                var print_stopped = IsBitSet(b, 5);
                Debug.WriteLine(print_stopped ? 
                    "PRINT STOPPED" : "NO PAPPER END STOP");
                if(print_stopped)
                    res.Add(VoucherPrinterState.PRINT_STOPPED);
                var with_errors = IsBitSet(b, 6);
                Debug.WriteLine(with_errors ? 
                    "ERRORS OCCURS" : "NO ERROR");
                if(with_errors)
                    res.Add(VoucherPrinterState.ERR_OCCUR);
            } else {
                Debug.WriteLine("=== ERROR ST OFF");
                return false;
            }

            if (TrySendCmd(CMD_ST_ERROR, out string st_err)) {
                var b = (byte)st_err[0];
                var autocutter_err = IsBitSet(b, 3);
                Debug.WriteLine(autocutter_err ? 
                    "ERROR AUTOCUTTER" : "-");
                if(autocutter_err)
                    res.Add(VoucherPrinterState.ERR_AUTO_CUTTER);
                var unrecoverable_err = IsBitSet(b, 5);
                Debug.WriteLine(unrecoverable_err ? 
                    "ERROR UNRECOVERABLE" : "-");
                if(unrecoverable_err)
                    res.Add(VoucherPrinterState.ERR_UNRECOVERABLE);
                var auto_recoverable_err = IsBitSet(b, 6);
                Debug.WriteLine(auto_recoverable_err ? 
                    "ERROR AUTO-RECOVERABLE" : "-");
                if(auto_recoverable_err)
                    res.Add(VoucherPrinterState.ERR_AUTO_RECOVERABLE);
            } else {
                Debug.WriteLine("=== ERROR ST ERR");
                return false;
            }

            if (TrySendCmd(CMD_ST_PAPPER_ROLL, out string st_pr)) {
                var b = (byte)st_pr[0];
                var almost_empty = IsBitSet(b, 3);
                Debug.WriteLine(almost_empty ? 
                    "ALMOST EMPTY" : "-");
                if(almost_empty)
                    res.Add(VoucherPrinterState.ALMOST_EMPTY);
                var empty = IsBitSet(b, 6);
                Debug.WriteLine(empty ? 
                    "EMPTY" : "-");
                if(empty)
                    res.Add(VoucherPrinterState.EMPTY);
            } else {
                Debug.WriteLine("=== ERROR ST PR");
                return false;
            }

            if (res.Count == 0 || 
                (res.Count == 1 && res.Contains(VoucherPrinterState.ALMOST_EMPTY))) {
                res.Add(VoucherPrinterState.OK);
            }

            return true;
        }
    }

    public enum VoucherPrinterState {
        OK = 0,
        PORT_NOT_EXISTS = 1,
        NO_RESPONSE = 2,
        OFFLINE = 3,
        COVER_OPEN = 4,
        PRINT_STOPPED = 5,
        ERR_OCCUR = 6,
        ERR_AUTO_CUTTER = 7,
        ERR_UNRECOVERABLE = 8,
        ERR_AUTO_RECOVERABLE = 9,
        EMPTY = 10,
        ALMOST_EMPTY = 11
    }
}
