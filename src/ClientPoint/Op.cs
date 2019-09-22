using System;
using System.Diagnostics;
using System.IO;
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
                    Name = "PRIMERO",
                    LastName = "GST",
                    IdCard = Config.TEST_CARD
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

        public static void Client() {
            ShowView(View.SwipeCard);
        }

        public static void ClientLoadAsync(string idCard) {
            Debug.WriteLine($"Card Swiped: {idCard}");
            var t = new Thread(() => ClientLoadSync(idCard));
            t.Start();
        }

        private static void ClientLoadSync(string idCard) {
            var res = ApiService.ClientLoad(new ClientLoadRequest() {
                IdCard = idCard
            }, out string errMsg);
            if (res == null) {
                MsgBox.Error(errMsg);
                return;
            }
            // Cargo todos los datos del usuario
            ClientSession.Load(res, null);
            UIManager.ShowView(View.ClientMenu);
        }

        public static void ShowReward(Reward reward) {
            UIManager.RewardModal.LoadReward(reward);
            UIManager.RewardModal.ShowDialog(UIManager.GetCurrent());
        }

        public static void TestBase64() {
            using (MemoryStream m = new MemoryStream()) {
                var image = Properties.Resources.crucero;
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                Console.WriteLine(base64String);
            }

        }
    }
}
