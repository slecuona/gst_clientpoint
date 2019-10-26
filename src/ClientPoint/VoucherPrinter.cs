using System;
using ClientPoint.IO;
using ClientPoint.Utils;

namespace ClientPoint {
    public static class VoucherPrinter {

        public static bool TryPrintRaw(string s) {
            try {
                // Hay que imprimir "en crudo" para que salga correctamente
                // el codigo de barras
                // https://techtaalks.wordpress.com/2018/01/11/raw-printing-from-c/
                RawPrinterHelper.SendStringToPrinter(Config.VoucherPrinterName, s);
                return true;
            }
            catch (Exception e) {
                Logger.Exception(e);
                return false;
            }
        }
    }
}
