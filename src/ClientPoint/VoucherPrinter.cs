using ClientPoint.IO;

namespace ClientPoint {
    public static class VoucherPrinter {

        public static void PrintRaw(string s) {
            // Hay que imprimir "en crudo" para que salga correctamente
            // el codigo de barras
            // https://techtaalks.wordpress.com/2018/01/11/raw-printing-from-c/
            RawPrinterHelper.SendStringToPrinter("Custom GT", s);
        }
    }
}
