using ClientPoint.IO;

namespace ClientPoint {
    public static class VoucherPrinter {

        public static void PrintRaw(string s) {
            // Hay que imprimir "en crudo" para que salga correctamente
            // el codigo de barras
            RawPrinterHelper.SendStringToPrinter("Custom GT", s);
        }
    }
}
