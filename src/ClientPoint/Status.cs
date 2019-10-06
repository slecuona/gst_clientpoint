using System;
using System.Net;
using ClientPoint.Api;
using ClientPoint.Espf;
using ClientPoint.UI;
using ClientPoint.Utils;
using Telerik.WinControls;

namespace ClientPoint {
    // Esta clase chequea el estado los distintos servicios / dispositivos
    public static class Status {

        public static string EspfServiceConn = "";
        public static EspfMayorState EspfMayor = EspfMayorState.NONE;
        public static string EspfMinor;

        private static void ShowError(string msg) {
            msg = $"ERROR: {msg}";
            Logger.WriteAsync(msg);
            UIManager.SafeExecOnActiveForm(owner =>
                RadMessageBox.Show(owner, msg));
        }

        public static void Init() {
            EspfInit();
            Api();
        }

        public static void Refresh() {
            var espfOk = EspfServiceConnStatus(out EspfServiceConn);
            EspfMayor = EspfMayorState.NONE;
            EspfMinor = "";
            if (espfOk) {
                EspfSupDeviceState();
                EspfCmdDeviceStatus(out string status);
            }
        }

        /// <summary>
        /// Consulta el estado inicial del servicio de Evolis
        /// </summary>
        private static void EspfInit() {
            // Busca evitar el error de
            // "An existing connection was forcibly closed by the remote host"
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var espfOk = EspfServiceConnStatus(out EspfServiceConn);
            Print($"ESPF Service => {EspfServiceConn}");

            if (espfOk) {
                EspfSupDeviceState();

                EspfCmdDeviceStatus(out string status);
                Print($"ESPF Device Binary Status => {status}");
            }
            else {
                ShowError(
                    "No se ha podido establecer la conexión con la impresora de tarjetas.\n" +
                    "Asegurese de que el servicio este funcionando correctamente.\n" +
                    "(Evolis Print Center Service)\n" +
                    $"{Config.EspfIp}:{Config.EspfPort}");
            }
        }

        private static void Print(string msg) {
            Console.WriteLine(msg);
            Logger.WriteAsync(msg);
            UIManager.SplashStatus(msg);
        }

        // Este metodo chequea el estado del servicio ESPF
        private static bool EspfServiceConnStatus(out string state) {
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
                Logger.Exception(e);
                state = e.Message;
                return false;
            }
        }

        // Estado de la impresora. (OFF, ERR, READY)
        private static bool EspfSupDeviceState() {
            var mayor = EspfMayorState.NONE;
            string minor = null;
            try {
                var state = Services.SupGetState("GST1");
                var states = state.Split(',');
                if (states.Length >= 1) {
                    if (states[0] == "OFF")
                        mayor = EspfMayorState.OFF;
                    if (states[0] == "ERROR")
                        mayor = EspfMayorState.ERROR;
                    if (states[0] == "READY")
                        mayor = EspfMayorState.READY;
                    if (states[0] == "WARNING")
                        mayor = EspfMayorState.WARNING;
                }

                if (states.Length >= 2)
                    minor = states[1];
                return true;
            }
            catch (Exception e) {
                Logger.Exception(e);
                Print($"ERR. EspfSupDeviceState => {e.Message}");
                return false;
            }
            finally {
                if (EspfMayor != mayor) {
                    EspfMayor = mayor;
                    Print($"ESPF Mayor state: {EspfMayor}");
                }

                if (EspfMinor != minor) {
                    EspfMinor = minor;
                    Print($"ESPF Minor state: {EspfMinor}");
                }
            }
        }

        // Estado de la impresora (binario)
        private static bool EspfCmdDeviceStatus(out string state) {
            try {
                state = Services.CmdGetStatus("GST2");
                return true;
            } catch (Exception e) {
                Logger.Exception(e);
                state = e.Message;
                return false;
            }
        }

        // Estado de la API GST
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

    // Estados "mayores" reportados por el servicio de Evolis.
    // Descripcion extraida de la documentacion ReferenceGuide_PremiumSDK.pdf
    public enum EspfMayorState {
        // No se pudo obtener el estado.
        NONE = 0,
        // Unable to communicate
        OFF = 1,
        // Printer error (requests a human intervention)
        // An ERROR state is only reported during a printing.
        ERROR = 2,
        // Printer Ready
        READY = 3,
        // Next printing unavailable (requests a human intervention)
        // A WARNING state is usually reported before the beginning of
        // a printing but for some specific states it can be reported
        // only when the printing starts.
        WARNING = 4
    }


}
