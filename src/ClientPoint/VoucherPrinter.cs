using System;
using System.Drawing.Printing;
using System.Printing;
using ClientPoint.IO;
using ClientPoint.Utils;

namespace ClientPoint {
    public static class VoucherPrinter {
        private static string PrinterName => 
            Config.VoucherPrinterName;

        public static VoucherPrinterState GetState() {
            if (!ValidPrinter())
                return VoucherPrinterState.NOTVALID;
            return CheckQueueStatus();
        }

        private static bool ValidPrinter() {
            var printer = new PrinterSettings {
                PrinterName = PrinterName
            };
            return printer.IsValid;
        }

        private static VoucherPrinterState CheckQueueStatus() {
            var server = new LocalPrintServer();
            var queue = server.GetPrintQueue(PrinterName, new string[0] { });
            if (queue.IsOutOfPaper)
                return VoucherPrinterState.EMPTY;
            if (queue.IsOffline)
                return VoucherPrinterState.OFFLINE;
            if (queue.IsBusy)
                return VoucherPrinterState.BUSY;
            if (queue.IsInError)
                return VoucherPrinterState.ERROR;
            return VoucherPrinterState.OK;
        }

        public static bool TryPrintRaw(string s, out string err) {
            err = "";
            try {
                var state = GetState();
                if (state != VoucherPrinterState.OK) {
                    err = $"{PrinterName} => {state}.";
                    return false;
                }
                // Hay que imprimir "en crudo" para que salga correctamente
                // el codigo de barras
                // https://techtaalks.wordpress.com/2018/01/11/raw-printing-from-c/
                var success = RawPrinterHelper.SendStringToPrinter(PrinterName, s);
                if (!success)
                    err = "RawPrinter fail.";
                return success;
            }
            catch (Exception e) {
                err = e.Message;
                Logger.Exception(e);
                return false;
            }
        }
    }

    public enum VoucherPrinterState {
        OK = 0,
        NOTVALID = 1,
        ERROR = 2,
        EMPTY = 3,
        OFFLINE = 4,
        BUSY = 5,
    }
}
