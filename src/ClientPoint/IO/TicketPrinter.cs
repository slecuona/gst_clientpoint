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
        
        public bool TryGetStatus(out string status) {
            return TrySendCmd("^S|^", out status);
        }
    }
}
