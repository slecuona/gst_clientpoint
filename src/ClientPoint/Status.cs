using System;
using System.Net;
using ClientPoint.Api;
using ClientPoint.Espf;
using ClientPoint.UI;
using ClientPoint.Utils;

namespace ClientPoint {
    // Esta clase chequea el estado los distintos servicios / dispositivos
    public static class Status {

        public static void Espf() {
            // Busca evitar el error de
            // "An existing connection was forcibly closed by the remote host"
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var espfOk = EspfService(out string espfService);
            Print($"ESPF Service => {espfService}");

            if (espfOk) {
                EspfSupDeviceState(out string state);
                Print($"ESPF Sup. Device State => {state}");

                EspfCmdDeviceStatus(out string status);
                Print($"ESPF Device Binary Status => {status}");
            }
        }

        private static void Print(string msg) {
            Console.WriteLine(msg);
            Logger.WriteAsync(msg);
            UIManager.SplashStatus(msg);
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

        public static void Api() {
            string msg = "API Connection =>";
            try {
                ApiService.Ping();
                Print($"{msg} OK");
            } catch (Exception e) {
                Print($"{msg} {e.Message}");
                Logger.Exception(e);
            }
        }
    }
}
