using System;
using System.Drawing.Printing;
using System.Management;
using System.Printing;
using System.Threading;
using ClientPoint.IO;
using ClientPoint.Utils;

namespace ClientPoint {

    // Printer: Custom TG2480H
    // Product key: 915CH011100300

    public static class VoucherPrinter {
        public static bool LastFailed = false;

        private static string PrinterName => 
            Config.VoucherPrinterName;

        public static VoucherPrinterState GetState() {
            if (!ValidPrinter())
                return VoucherPrinterState.NOTVALID;
            var mStatus = CheckManagment();
            if (mStatus != VoucherPrinterState.OK)
                // Si dio un estado distinto a OK, me quedo con este.
                return mStatus;
            return CheckQueueStatus();
        }

        private static bool ValidPrinter() {
            var printer = new PrinterSettings {
                PrinterName = PrinterName
            };
            return printer.IsValid;
        }

        private static PrintQueue GetQueue() {
            var server = new LocalPrintServer();
            return server.GetPrintQueue(PrinterName, new string[0] { });
        }

        private static VoucherPrinterState CheckQueueStatus() {
            var queue = GetQueue();
            // Evito que se acumulen en cola la impresión del voucher.
            // Si queda uno colgado, probablemente se quedó sin papel.
            if (queue.NumberOfJobs > 0)
                return VoucherPrinterState.BUSY;
            
            // Estos estados no funcionan para esta impresora.
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

        static void PrintProps(ManagementObject o, string prop) {
            if(!Config.DebugMode)
                return;
            try {
                Console.WriteLine(prop + "|" + o[prop]);
            }
            catch (Exception e) {
                Console.Write(e.ToString());
            }
        }

        private static VoucherPrinterState CheckManagment() {
            var searcher = new ManagementObjectSearcher(
                $"SELECT * FROM Win32_Printer " +
                $"WHERE Name = '{PrinterName.ToLower()}'");

            foreach (var o in searcher.Get()) {
                var printer = o as ManagementObject;
                if (o == null)
                    return VoucherPrinterState.NOTFOUND;
                
                PrintProps(printer, "Caption");
                PrintProps(printer, "ExtendedPrinterStatus");
                PrintProps(printer, "Availability");
                PrintProps(printer, "Default");
                PrintProps(printer, "DetectedErrorState");
                PrintProps(printer, "ExtendedDetectedErrorState");
                PrintProps(printer, "ExtendedPrinterStatus");
                PrintProps(printer, "LastErrorCode");
                PrintProps(printer, "PrinterState");
                PrintProps(printer, "PrinterStatus");
                PrintProps(printer, "Status");
                PrintProps(printer, "WorkOffline");
                PrintProps(printer, "Local");

                // En las pruebas, fue la unica manera de detectar si está offline.
                if (bool.TryParse(o["WorkOffline"].ToString(), out bool offline)) {
                    if (offline)
                        return VoucherPrinterState.OFFLINE;
                }
            }

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
                if (!success) {
                    err = "RawPrinter fail.";
                    return false;
                }

                var st = VoucherPrinterState.BUSY;
                var timeout = Config.VoucherPrinterTimeout;
                while (st != VoucherPrinterState.OK && timeout > 0) {
                    Thread.Sleep(1000);
                    st = GetState();
                    timeout--;
                    if (st == VoucherPrinterState.OK) {
                        LastFailed = false;
                        return true;
                    }
                }
                LastFailed = true;
                CancelJob();
                err = $"Timeout. ({st}) Impresión cancelada.";
                Logger.WriteAsync(
                    $"Falló impresión de Voucher.");
                return false;
            }
            catch (Exception e) {
                err = e.Message;
                Logger.Exception(e);
                return false;
            }
        }

        // Cuando no hay papel, la impresora queda en estado "imprimiendo"
        // y el job queda pendiente.
        private static void CancelJob() {
            try {
                var queue = GetQueue();
                if (queue.NumberOfJobs == 0)
                    return;
                var jobs = queue.GetPrintJobInfoCollection();
                foreach (var j in jobs) {
                    j.Cancel();
                }
            }
            catch (Exception e) {
                Logger.WriteAsync(
                    "No se pudo cancelar la impresion de voucher.");
                Logger.Exception(e);
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
        NOTFOUND = 6
    }
}
