using Common;
using Espf.Request;

namespace Espf {
    // La documentacion de estos Servicios/metodos estan en ReferenceGuide_PremiumSDK.pdf
    public static class Services {
        // Nos permite verificar que ESPF este funcionando
        public static string Echo(string id, string data) {
            var req = new EchoRequest(id, data);
            return Client.Send(req);
        }

        // Inicializa la session de impresion
        public static string PrintBegin(string id) {
            var req = new PrintRequest(id, PrintMethods.Begin, 
                new PrintParams() {
                    device = Config.EspfPrinter
                });
            // devuelve session/job id
            return Client.Send(req);
        }

        // Setea los parametros de impresion
        // data ej: "FColorBrightness=VAL12;GRibbonType=RC_YMCKO"
        public static string PrintSet(string id, string session, string data) {
            var req = new PrintRequest(id, PrintMethods.Set,
                new PrintParams() {
                    session = session,
                    data = data
                });
            // devuelve "OK"
            return Client.Send(req);
        }

        public static string PrintSetBitmap(string id, string session, string data) {
            var req = new PrintRequest(id, PrintMethods.SetBitmap,
                new PrintParams() {
                    session = session,
                    data = data,
                    // Estos datos por ahora van hardcodeados.
                    // (no creo que haya otro caso de uso)
                    face = "front",
                    panel = "resin"
                });
            // devuelve "OK"
            return Client.Send(req);
        }

        // Arranca la impresion
        // El metodo se llama "PRINT.Print"
        public static string PrintStart(string id, string session) {
            var req = new PrintRequest(id, PrintMethods.Print,
                new PrintParams() {
                    session = session
                });
            // devuelve "OK"
            return Client.Send(req);
        }

        // Devuelve la session actual.
        // (No creo que lo usemos)
        public static string PrintGetJobID(string id, string session) {
            var req = new PrintRequest(id, PrintMethods.GetJobID,
                new PrintParams() {
                    device = Config.EspfPrinter
                });
            // devuelve session/job id
            return Client.Send(req);
        }

        // Finaliza la session de impresion
        public static string PrintEnd(string id, string session) {
            var req = new PrintRequest(id, PrintMethods.End,
                new PrintParams() {
                    session = session
                });
            // devuelve "OK"
            return Client.Send(req);
        }

        // Estado de la impresora
        public static string SupGetState(string id) {
            var req = new SupRequest(id, "GetState");
            // devuelve string [majorstate, minorstate]
            return Client.Send(req);
        }

        // CMD.SendCommand
        public static string CmdSend(string id, string cmd) {
            var req = new CmdRequest(id, CmdMethods.SendCommand, cmd);
            // devuelve respuesta del cmd
            return Client.Send(req);
        }

        // CMD.GetStatus
        public static string CmdGetStatus(string id) {
            var req = new CmdRequest(id, CmdMethods.GetStatus);
            // devuelve un string binario (Ver 5.1. Binary status of a printer)
            return Client.Send(req);
        }

        // CMD.ResetCom: reinicia la comunicacion con la impresora
        public static string CmdResetCom(string id) {
            var req = new CmdRequest(id, CmdMethods.ResetCom);
            // devuelve "OK"
            return Client.Send(req);
        }

    }
}
