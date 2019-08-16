using System;
using System.Threading;
using ClientPoint.Api;
using ClientPoint.Espf;
using ClientPoint.Session;
using ClientPoint.UI;
using ClientPoint.Utils;
using static ClientPoint.UI.UIManager;
using static ClientPoint.Utils.ExUtils;

namespace ClientPoint {
    // Esta clase contiene las distintas operaciones/procesos
    // que realiza la app.
    public static class Op {

        public static void ClientCreate() {
            DocumentInput.OnConfirm = res => {
                if (res.NotExists) {
                    Show(Window.ClientCreate);
                    return null;
                }
                else {
                    // El usuario ya existe.
                    return "Ya existe un usuario con el numero de documento ingresado.";
                }
            };
            Show(Window.DocumentInput);
        }

        // Accion a realizar luego de ingresar el documento, cuando el usuario
        // desea confirmar o actualizar datos.
        private static string OnConfirmDocInputExistingUsr(ClientStatusResponse res) {
            if (res.NotExists) {
                return "No existe un usuario con el numero de documento ingresado.";
            }
            else {
                var cl = ClientSession.CurrClient;
                if (cl.Status != ClientStatus.Pendiente &&
                    cl.Status != ClientStatus.SinTarjeta)
                    return "El usuario ya fue confirmado.";
                Show(Window.PasswordInput);
                return null;
            }
        }

        public static void ClientConfirm() {
            DocumentInput.OnConfirm = OnConfirmDocInputExistingUsr;

            PasswordInput.OnConfirm = () => { Show(Window.Confirm); };

            Show(Window.DocumentInput);
        }

        public static void ClientUpdate() {
            DocumentInput.OnConfirm = OnConfirmDocInputExistingUsr;

            PasswordInput.OnConfirm = () => { Show(Window.ClientUpdate); };

            Show(Window.DocumentInput);
        }

        public static void PrintCard() {
            SafeExec(() => {
                StatusWindow.SetState(States.PrintingCard);
                Show(Window.Status);
            });
            var t = new Thread(PrintCardAsync);
            t.Start();
        }

        private static void PrintCardAsync() {
            try {
                var card = ApiService.GetNumberCard();
                var pj = new PrintJob(card);
                var cl = ClientSession.CurrClient;
                pj.WriteData();
                pj.Start();
                var success = ApiService.CreateCard(new CreateCardRequest() {
                    DocumentNumber = cl.DocumentNumber,
                    Password = cl.Password,
                    IdCard = card
                }, out string err);
                DieIf(!success, err);

                SafeExec(() => { StatusWindow.SetState(States.RemoveCard); });
            }
            catch (Exception ex) {
                Logger.Exception(ex);
                MsgBox.Error(StatusWindow, "Error al imprimir tarjeta.");
            }
        }

    }
}
