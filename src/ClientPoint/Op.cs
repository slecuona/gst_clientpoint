using System;
using System.Threading;
using ClientPoint.Api;
using ClientPoint.Espf;
using ClientPoint.Session;
using ClientPoint.UI;
using ClientPoint.UI.Views;
using ClientPoint.Utils;
using static ClientPoint.UI.UIManager;
using static ClientPoint.Utils.ExUtils;

namespace ClientPoint {
    // Esta clase contiene las distintas operaciones/procesos
    // que realiza la app.
    public static class Op {

        public static void ClientCreate() {
            DocInput.OnConfirm = res => {
                if (res.NotExists) {
                    //ShowWindow(Window.ClientCreate);
                    ShowView(View.ClientCreate);
                    return null;
                }
                else {
                    // El usuario ya existe.
                    return "Ya existe un usuario con el numero de documento ingresado.";
                }
            };
            //ShowWindow(Window.DocumentInput);
            ShowView(View.DocumentInput);
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
                ShowView(View.PasswordInput);
                return null;
            }
        }

        public static void ClientConfirm() {
            DocInput.OnConfirm = OnConfirmDocInputExistingUsr;

            //PasswordInput.OnConfirm = () => { ShowWindow(Window.Confirm); };
            PassInput.OnConfirm = () => { ShowView(View.Confirm); };

            //ShowWindow(Window.DocumentInput);
            ShowView(View.DocumentInput);
        }

        public static void ClientUpdate() {
            DocInput.OnConfirm = OnConfirmDocInputExistingUsr;

            //PasswordInput.OnConfirm = () => { ShowWindow(Window.ClientUpdate); };
            PassInput.OnConfirm = () => {  ShowView(View.ClientUpdate); };

            //ShowWindow(Window.DocumentInput);
            ShowView(View.DocumentInput);
        }

        public static void PrintCard() {
            SafeExec(() => {
                UIManager.StatusMainView.SetState(States.PrintingCard);
                ShowView(View.StatusMain);
            });
            var t = new Thread(PrintCardSync);
            t.Start();
        }

        private static void PrintCardSync() {
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

                SafeExec(() => {
                    UIManager.StatusMainView.SetState(States.RemoveCard);
                    ShowView(View.StatusMain);
                });
            }
            catch (Exception ex) {
                Logger.Exception(ex);
                MsgBox.Error("Error al imprimir tarjeta.");
                UIManager.ShowWindow(Window.Ads);
            }
        }

        public static void TestPrintAsync() {
            SafeExec(() => {
                UIManager.StatusMainView.SetState(States.PrintingCard);
                ShowView(View.StatusMain);
            });
            var t = new Thread(TestPrintSync);
            t.Start();
        }

        public static void TestPrintSync() {
            try {
                var pj = new PrintJob(new Client() {
                    Name = "SANTIAGO ELIAS",
                    LastName = "LECUONA TOURNEE",
                    IdCard = "00000012312312312"
                });

                pj.Start();

                SafeExec(() => {
                    MsgBox.Show("OK");
                    ShowView(View.MainMenu);
                });
            }
            catch (Exception ex) {
                Logger.Exception(ex);
                MsgBox.Error("Error al imprimir tarjeta.");
                UIManager.ShowWindow(Window.Ads);
            }
        }

    }
}
