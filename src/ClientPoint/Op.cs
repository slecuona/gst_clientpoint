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
                    //ShowWindow(Window.ClientCreate);
                    ShowWindow(Window.Main);
                    return null;
                }
                else {
                    // El usuario ya existe.
                    return "Ya existe un usuario con el numero de documento ingresado.";
                }
            };
            //ShowWindow(Window.DocumentInput);
            ShowWindow(Window.Main);
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
                //ShowWindow(Window.PasswordInput);
                ShowWindow(Window.Main);
                return null;
            }
        }

        public static void ClientConfirm() {
            DocumentInput.OnConfirm = OnConfirmDocInputExistingUsr;

            //PasswordInput.OnConfirm = () => { ShowWindow(Window.Confirm); };
            PasswordInput.OnConfirm = () => { ShowWindow(Window.Main); };

            //ShowWindow(Window.DocumentInput);
            ShowWindow(Window.Main);
        }

        public static void ClientUpdate() {
            DocumentInput.OnConfirm = OnConfirmDocInputExistingUsr;

            //PasswordInput.OnConfirm = () => { ShowWindow(Window.ClientUpdate); };
            PasswordInput.OnConfirm = () => { ShowWindow(Window.Main); };

            //ShowWindow(Window.DocumentInput);
            ShowWindow(Window.Main);
        }

        public static void PrintCard() {
            SafeExec(() => {
                StatusWindow.SetState(States.PrintingCard);
                //ShowWindow(Window.Status);
                ShowWindow(Window.Main);
            });
            var t = new Thread(PrintCardAsync);
            t.Start();
        }

        private static void PrintCardAsync() {
            try {
                var card = ApiService.GetNumberCard();
                var cl = ClientSession.CurrClient;
                cl.IdCard = card;
                var pj = new PrintJob(cl);
                
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
                MsgBox.Error("Error al imprimir tarjeta.", StatusWindow);
                UIManager.ShowWindow(Window.Ads);
            }
        }

        public static void TestPrint() {
            try {
                var pj = new PrintJob(new Client() {
                    Name = "SANTIAGO ELIAS",
                    LastName = "LECUONA TOURNEE",
                    IdCard = "00000012312312312"
                });

                pj.Start();
            }
            catch (Exception ex) {
                Logger.Exception(ex);
                MsgBox.Error("Error al imprimir tarjeta.");
            }

            
        }

    }
}
