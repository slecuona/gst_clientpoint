using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ClientPoint.Api;
using ClientPoint.Espf;
using ClientPoint.IO;
using ClientPoint.UI;
using ClientPoint.Utils;
using Telerik.WinControls;

namespace ClientPoint {
    // Esta clase chequea el estado los distintos servicios / dispositivos
    public static class Status {

        public static string EspfServiceConn = "";
        // The major states provide global information on the device.
        public static EspfMayorState EspfMayor = EspfMayorState.NONE;
        // The minor states, offers more detailed information of the major states
        public static string EspfMinor;
        public static string EspfBinary;
        public static string ApiState;

        public static List<TicketPrinterState> TicketPrinter;
        public static string TicketPrinterString;

        public static List<VoucherPrinterState> VoucherPrinter;
        public static bool HasErrors { get; set; }

        private static void ShowError(string msg) {
            msg = $"ERROR: {msg}";
            Logger.WriteAsync(msg);
            UIManager.SafeExecOnActiveForm(owner =>
                RadMessageBox.Show(owner, msg));
        }

        public static void Init() {
            Espf(true);
            Api(true);
            CheckTicketPrinter(true);
            CheckVoucherPrinter(true);
        }

        public static void Refresh() {
            Espf();
            Api();
            CheckTicketPrinter();
            CheckVoucherPrinter();
            SendMailAlert();
        }

        private static StringBuilder _lastMsg;

        private static void SendMailAlert() {
            if (ApiState != "OK")
                // No tenemos manera de mandar mail.
                return;

            if (string.IsNullOrEmpty(Config.AlertMailSentTo))
                return;

            var body = new StringBuilder();
            if (EspfMayor != EspfMayorState.READY) {
                //body.AppendLine("\\r \\n \r \n \\n\\n \\u000d \u000d \u000a \\u000a \u000d\u000a \\u000d\\u000a \\r \\n \r \n \\n\\n \\u000d \r \n \\u000a \r\n \\u000d\\u000a");
                body.AppendLine($"Estado de impresora de tarjeta: ");
                body.AppendLine($" - EspfMayorState: {EspfMayor} ");
                body.AppendLine($" - EspfMinorState: {EspfMinor} ");
                if (EspfMinor == "FEEDER_EMPTY")
                    body.AppendLine(" - No hay tarjetas, no se puede imprimir. ");
                if (EspfMinor == "INF_FEEDER_NEAR_EMPTY")
                    body.AppendLine(" - Quedan pocas tarjetas. ");
            }
            if (!TicketPrinter.Contains(TicketPrinterState.OK)) {
                body.AppendLine($"Estado de impresora de tickets: ");
                foreach (var s in TicketPrinter) {
                    body.AppendLine($" - {s} ");
                }
                if (TicketPrinter.Contains(TicketPrinterState.EMPTY))
                    body.AppendLine($" - Sin papel. ");
                if (TicketPrinter.Contains(TicketPrinterState.ALMOST_EMPTY))
                    body.AppendLine($" - Queda poco papel. ");
            }

            if (!VoucherPrinter.Contains(VoucherPrinterState.OK)) {
                body.AppendLine($"Estado de impresora de voucher: ");
                foreach (var s in VoucherPrinter) {
                    body.AppendLine($" - {s} ");
                }
                if (VoucherPrinter.Contains(VoucherPrinterState.EMPTY))
                    body.AppendLine($" - Sin papel. ");
                if (VoucherPrinter.Contains(VoucherPrinterState.ALMOST_EMPTY))
                    body.AppendLine($" - Queda poco papel. ");
            }

            if (body.Length > 0) {
                var bodyStr = body.ToString();
                if (_lastMsg?.ToString() == bodyStr)
                    // Evito enviar el mismo mail...
                    return;
                Logger.DebugWrite(
                    $"SendMail: {Environment.NewLine}{bodyStr}");
                _lastMsg = body;
                ApiService.SendMail(
                    Config.AlertMailSentTo,
                    $"{Config.AlertMailSubject} [#1]",
                    bodyStr, out string errMsg);
            }
        }

        private static void CheckErrors() {
            HasErrors =
                EspfMayor != EspfMayorState.READY ||
                (TicketPrinter != null && !TicketPrinter.Contains(TicketPrinterState.OK)) ||
                (VoucherPrinter != null && !VoucherPrinter.Contains(VoucherPrinterState.OK)) ||
                ApiState != "OK";
            UIManager.RefreshErrorIcon();
        }

        private static void Print(string msg) {
            Console.WriteLine(msg);
            Logger.WriteAsync(msg);
            UIManager.SplashStatus(msg);
        }

        /// <summary>
        /// Consulta el estado inicial del servicio de Evolis
        /// </summary>
        private static void Espf(bool init = false) {
            // Busca evitar el error de
            // "An existing connection was forcibly closed by the remote host"
            if(init)
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var espfOk = EspfServiceConnStatus(out EspfServiceConn);
            
            if (init)
                Print($"ESPF Service => {EspfServiceConn}");

            //EspfMayor = EspfMayorState.NONE;
            //EspfMinor = "";
            //EspfBinary = "";

            if (espfOk) {
                EspfSupDeviceState();

                if (init) {
                    Print($"ESPF Mayor state: {EspfMayor}");
                    Print($"ESPF Minor state: {EspfMinor}");
                }

                EspfCmdDeviceStatus(out EspfBinary);
                //if(init)
                //    Print($"ESPF Device Binary Status => {EspfBinary}");
            }
            else {
                if(init)
                    ShowError(
                        "No se ha podido establecer la conexión con la impresora de tarjetas.\n" +
                        "Asegurese de que el servicio este funcionando correctamente.\n" +
                        "(Evolis Print Center Service)\n" +
                        $"{Config.EspfIp}:{Config.EspfPort}");
            }
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
        public static bool EspfSupDeviceState(bool checkErrors = true) {
            var mayor = EspfMayorState.NONE;
            string minor = null;
            try {
                // Esta llamada debe evitar el lockeo
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
                //Print($"ERR. EspfSupDeviceState => {e.Message}");
                return false;
            }
            finally {
                EspfMayor = mayor;
                EspfMinor = minor;
                if(checkErrors)
                    CheckErrors();
                Logger.Commit();
            }
        }

        // Estado de la impresora (binario)
        private static bool EspfCmdDeviceStatus(out string state) {
            try {
                // Esta llamada no se debe lockear.
                // Ya que puede ser utilizada durante la impresion.
                state = Services.CmdGetStatus("GST2", false);
                return true;
            }
            catch (Exception e) {
                Logger.Exception(e);
                state = e.Message;
                return false;
            }
            finally {
                Logger.Commit();
            }
        }

        // Estado de la API GST
        public static void Api(bool init = false) {
            try {
                ApiService.Ping();
                ApiState = "OK";
            }
            catch (Exception e) {
                ApiState = e.Message;
                if(init)
                    ShowError(
                        "No se ha podido establecer la comunicación con la API.\n" +
                        $"URL: {Config.ApiUrl}");
                Logger.Exception(e);
            }
            finally {
                if (init)
                    Print($"API Connection => {ApiState}");
                CheckErrors();
            }
        }

        public static void CheckTicketPrinter(bool init = false) {
            TicketPrinter = new List<TicketPrinterState>();
            TicketPrinterString = "";
            try {
                var t = new TicketPrinter();
                TicketPrinter = t.GetStatus(out TicketPrinterString);
            } catch (Exception e) {
                Logger.Exception(e);
            } finally {
                if (init) {
                    Print($"Ticket Printer => {string.Join(" | ", TicketPrinter)}");
                    Print($"Ticket Printer Str => {TicketPrinterString}");
                }
                CheckErrors();
            }
        }

        public static void CheckVoucherPrinter(bool init = false) {
            VoucherPrinter = new List<VoucherPrinterState>();
            try {
                var v = new VoucherPrinter();
                VoucherPrinter = v.GetStatus();
            } catch (Exception e) {
                Logger.Exception(e);
                VoucherPrinter.Add(VoucherPrinterState.NO_RESPONSE);
            } finally {
                if (init)
                    Print($"Voucher Printer => {string.Join("|", VoucherPrinter.ToArray())}");
                CheckErrors();
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

    // Solo son algunos...
    public class EspfMinorState {
        public const string ERR_MECHANICAL = "ERR_MECHANICAL";
        public const string ERR_WRITE_MAGNETIC = "ERR_WRITE_MAGNETIC";
        public const string FEEDER_EMPTY = "FEEDER_EMPTY";
        public const string DEF_CARD_ON_EJECT = "DEF_CARD_ON_EJECT";
    }
}
