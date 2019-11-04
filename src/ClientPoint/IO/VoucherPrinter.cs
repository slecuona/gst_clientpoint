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

        public VoucherPrinter() { }


        // Mando a imprimir tal cual viene de la API
        public bool TryPrint(string t, out string errMsg) {
            return base.TryWrite(t, out errMsg);
        }
        
        // https://reliance-escpos-commands.readthedocs.io/en/latest/realtime_status.html

        private const string CMD_ST_PRINTER = "\x10\x04\x01";
        private const string CMD_ST_PRINTER_OFF = "\x10\x04\x02";
        private const string CMD_ST_ERROR = "\x10\x04\x03";
        private const string CMD_ST_PAPPER_ROLL = "\x10\x04\x04";
        private const string CMD_ST_PRINTER2 = "\x10\x04\x17";
        private const string CMD_ST_FULL = "\x10\x04\x20";
        
        public bool TryGetSerialStatus(out string status) {
            status = "ok";
            TrySendCmd(CMD_ST_PRINTER, out string st_p);
            TrySendCmd(CMD_ST_PRINTER_OFF, out string st_off);
            TrySendCmd(CMD_ST_ERROR, out string st_err);
            TrySendCmd(CMD_ST_PAPPER_ROLL, out string st_pr);
            TrySendCmd(CMD_ST_PRINTER2, out string st_p2);
            TrySendCmd(CMD_ST_FULL, out string st_full);
            return true;
        }
        
    }
}
