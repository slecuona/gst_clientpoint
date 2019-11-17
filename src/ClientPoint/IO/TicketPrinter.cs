using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using static ClientPoint.Utils.ExUtils;

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
        
        public Action<bool, string> OnFinish;

        // Mando a imprimir tal cual viene de la API
        private string Ticket;

        public TicketPrinter() { }

        public void PrintAsync(string ticket) {
            DieIf(string.IsNullOrEmpty(ticket), $"Ticket null or empty.");
            Ticket = ticket;
            var t = new Thread(Print);
            t.Start();
        }

        private void Print() {
            var success = base.TryWrite(Ticket, out string errMsg);
            if (!success) {
                OnFinish?.Invoke(false, errMsg);
                return;
            }

            string s = null;
            var tries = 0;
            while (true) {
                tries++;
                Thread.Sleep(500);
                var status = GetStatus(out s);
                if (status.Contains(TicketPrinterState.PAPER_IN_CHUTE)) {
                    continue;
                }

                if (tries > 20) {
                    // Quiere decir que paso al menos 10 segundos sin respuesta valida.
                    OnFinish?.Invoke(false, "No se pudo imprimir el ticket. (timeout)");
                }

                if (status.Contains(TicketPrinterState.OK) ||
                    // Si esta vacio, asumimos que dio error, pero imprimio OK.
                    status.Contains(TicketPrinterState.EMPTY)) {
                    break;
                }

                //if (status.Contains(TicketPrinterState.SYS_ERROR)) {
                //    OnFinish?.Invoke(false, 
                //        "Error impresion de ticket. (sys_error)");
                //    return;
                //}
            }

            OnFinish?.Invoke(true, null);
        }

        private bool TryGetStatus(out string status) {
            return TrySendCmd("^Se|^", out status);
        }

        public List<TicketPrinterState> GetStatus(out string statusStr) {
            if (!PortExists()) {
                statusStr = "-";
                return new List<TicketPrinterState>() {
                    TicketPrinterState.PORT_NOT_EXISTS
                };
            }

            if (!TryGetStatus(out statusStr))
                return new List<TicketPrinterState>() {
                    TicketPrinterState.ERROR
                };

            // Ejemplo: "S|0|GRUSA4100|@|@|@|@|@|P0|"

            var res = new List<TicketPrinterState>();
            ParseStatus(statusStr, ref res);
            return res;
        }

        public static void ParseStatus(string s, ref List<TicketPrinterState> states) {
            var items = s.Split('|');
            if (items.Length < 8) {
                // Algo anda mal, no llegaron todos los bytes
                states.Add(TicketPrinterState.ERROR);
                return;
            }

            var flag1 = items[3][0];

            if (flag1 == '@' || flag1 == 'P') {
                // No hay flag de error
                // Segun las pruebas, aveces luego de imprimir el byte queda como 'P'.
                // que seria System Error | Library reference error | Al top of Form.
                // (Quizas es un tema de compatibilidad de firmware con la doc.)
                states.Add(TicketPrinterState.OK);
            }
            else {
                if (IsBitSet((byte)flag1, 0))
                    states.Add(TicketPrinterState.VOLTAGE_ERROR);
                if (IsBitSet((byte)flag1, 2))
                    states.Add(TicketPrinterState.EMPTY);
                if (IsBitSet((byte)flag1, 3))
                    states.Add(TicketPrinterState.COVER_OPEN);
                if (IsBitSet((byte)flag1, 4))
                    states.Add(TicketPrinterState.SYS_ERROR);
            }

            var flag3 = items[5][0];
            if (IsBitSet((byte)flag3, 3))
                states.Add(TicketPrinterState.PAPER_IN_CHUTE);


            var flag4 = items[6][0];
            if (IsBitSet((byte)flag4, 0))
                states.Add(TicketPrinterState.ALMOST_EMPTY);
        }

    }

    public enum TicketPrinterState {
        OK = 0,
        //NOT_OK = 1,
        PORT_NOT_EXISTS = 2,
        ERROR = 3,
        EMPTY = 4,
        ALMOST_EMPTY = 5,
        COVER_OPEN = 6,
        VOLTAGE_ERROR = 7,
        SYS_ERROR = 8,
        BUSY = 9,
        PAPER_IN_CHUTE = 10

    }
}
