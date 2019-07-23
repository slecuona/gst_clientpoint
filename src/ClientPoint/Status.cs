using System;
using Espf;

namespace ClientPoint {
    // Esta clase chequea el estado los distintos servicios / dispositivos
    public static class Status {

        public static void Espf() {
            var espfOk = EspfService(out string espfService);
            Console.WriteLine($"ESPF Service => {espfService}");

            if (espfOk) {
                EspfSupDeviceState(out string state);
                Console.WriteLine($"ESPF Sup. Device State => {state}");

                EspfCmdDeviceStatus(out string status);
                Console.WriteLine($"ESPF Device Binary Status => {status}");
            }
        }
        
        // Este metodo chequea el estado del servicio ESPF
        private static bool EspfService(out string state) {
            const string PING = "ping";
            state = "OK";
            try {
                var echo = Services.Echo("ECHO1", PING);
                if (echo == PING) {
                    return true;
                }
                return false;
            }
            catch (Exception e) {
                state = e.Message;
                return false;
            }
        }

        // Estado de la impresora. (OFF, ERR, READY)
        private static bool EspfSupDeviceState(out string state) {
            try {
                state = Services.SupGetState("GST1");
                return true;
            } catch (Exception e) {
                state = e.Message;
                return false;
            }
        }

        // Estado de la impresora (binario)
        private static bool EspfCmdDeviceStatus(out string state) {
            try {
                state = Services.CmdGetStatus("GST2");
                return true;
            } catch (Exception e) {
                state = e.Message;
                return false;
            }
        }
    }
}
