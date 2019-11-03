using System.IO.Ports;

namespace ClientPoint.IO {

    // GEN2
    // Utiliza protocolo TCL
    // https://stackoverflow.com/questions/5903331/tcl-thermal-control-language-printer-protocol-references

    public class TicketPrinter : SerialPrinter {
        protected override string PortName => 
            Config.TicketPrinterPort;
        protected override int BaudRate => 
            Config.TicketPrinterBaud;
        protected override int DataBits => 
            Config.TicketPrinterDataBits;
        protected override Parity Parity => 
            Config.TicketPrinterParity;
        protected override StopBits StopBits => 
            Config.TicketPrinterStopBits;
        protected override Handshake Handshake => 
            Config.TicketPrinterHandshake;

        public TicketPrinter() { }
        
        // Mando a imprimir tal cual viene de la API
        public bool TryPrint(string t, out string errMsg) {
            return base.TryWrite(t, out errMsg);
        }
        
        private bool TryGetStatus(out string status) {
            return TrySendCmd("^S|^", out status);
        }

        public TicketPrinterState GetStatus(out string statusStr) {
            if (!TryGetStatus(out statusStr))
                return TicketPrinterState.ERROR;

            // Ejemplo: "S|0|GRUSA4100|@|@|@|@|@|P0|"

            var items = statusStr.Split('|');
            if (items.Length < 8)
                return TicketPrinterState.ERROR; // Algo anda mal...

            if (items[3][0] == 0x4) {
                return TicketPrinterState.EMPTY;
            }

            if (items[6][0] == 0x1) {
                return TicketPrinterState.ALMOSTEMPTY;
            }
            return items[7][0] == 0x10 ?
                TicketPrinterState.OK :
                TicketPrinterState.NOTOK;
        }

    }

    public enum TicketPrinterState {
        OK = 0,
        NOTOK = 1,
        ERROR = 2,
        EMPTY = 3,
        ALMOSTEMPTY = 4
    }
}
