using System;
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
            if (!IsApiConnected())
                return;
            if (!Config.DebugMode && !IsEspfReady())
                return;

            DocInput.OnConfirm = res => {
                if (res.NotExists) {
                    //ShowWindow(Window.ClientCreate);
                    ShowView(View.ClientCreate);
                    return null;
                }
                else {
                    // El usuario ya existe.
                    return Strings.Get("cliente_ya_existe");
                }
            };
            //ShowWindow(Window.DocumentInput);
            ShowView(View.DocumentInput);
        }

        // Accion a realizar luego de ingresar el documento, cuando el usuario
        // desea confirmar o actualizar datos.
        private static string OnConfirmDocInputExistingUsr(ClientStatusResponse res) {
            if (res.NotExists) {
                return Strings.Get("cliente_no_existe");
            }
            else {
                var cl = ClientSession.CurrClient;
                if (cl.Status != ClientStatus.Pendiente &&
                    cl.Status != ClientStatus.SinTarjeta)
                    return Strings.Get("cliente_confirmado");
                //ShowWindow(Window.PasswordInput);
                ShowView(View.PasswordInput);
                return null;
            }
        }

        // Varias acciones, envia el codigo para la confirmacion automaticamente.
        // Si no puede imprimir tarjeta, no tiene sentido permitir realizar estas acciones.
        private static bool IsEspfReady() {
            Status.EspfSupDeviceState();
            if (Status.EspfMayor == EspfMayorState.READY) return true;
            MsgBox.Show(Strings.Get("no_impresora_tarjeta"));
            return false;
        }

        private static bool IsApiConnected() {
            Status.Api();
            if (Status.ApiState == "OK")
                return true;
            SafeExec(() => {
                MsgBox.Show(Strings.Get("problemas_conexion"));
            });
            return false;
        }

        public static void ClientConfirm() {
            if (!IsApiConnected())
                return;
            if (!Config.DebugMode && !IsEspfReady())
                return;

            DocInput.OnConfirm = OnConfirmDocInputExistingUsr;

            //PasswordInput.OnConfirm = () => { ShowWindow(Window.Confirm); };
            PassInput.OnConfirm = () => { ShowView(View.Confirm); };

            //ShowWindow(Window.DocumentInput);
            ShowView(View.DocumentInput);
        }

        public static void ClientUpdate() {
            if (!IsApiConnected())
                return;
            if (!Config.DebugMode && !IsEspfReady())
                return;

            DocInput.OnConfirm = OnConfirmDocInputExistingUsr;

            //PasswordInput.OnConfirm = () => { ShowWindow(Window.ClientUpdate); };
            PassInput.OnConfirm = () => {  ShowView(View.ClientUpdate); };

            //ShowWindow(Window.DocumentInput);
            ShowView(View.DocumentInput);
        }

        //private static Timer _printCardTimer;

        public static void PrintCard() {
            try {
                SafeExec(() => {
                    StatusMainView.SetState(States.PrintingCard);
                    ShowView(View.StatusMain);
                });
                var card = ApiService.GetNumberCard();
                var cl = ClientSession.CurrClient;
                cl.IdCard = card;
                var pj = new PrintJob(cl);
                pj.OnStateChanged = OnPrintStateChanged;
                pj.OnFinish = OnPrintCardFinish;
                pj.StartAsync();
            } catch (Exception ex) {
                Logger.Exception(ex);
                MsgBox.Error(Strings.Get("error_tarjeta"));
                ShowWindow(Window.Ads);
            }
        }

        private static void OnPrintCardFinish(bool success) {
            if (!success) {
                SafeExec(() => {
                    MsgBox.Error(Strings.Get("error_tarjeta"));
                    ShowWindow(Window.Ads);
                });
            }
            Status.RefreshAsync();
        }

        private static void OnPrintStateChanged(PrintState s) {
            if (s == PrintState.CardEjected) {
                SafeExec(() => {
                    StatusMainView.SetState(States.RemoveCard);
                    ShowView(View.StatusMain);
                });
            }

            if (s == PrintState.Success) {
                var cl = ClientSession.CurrClient;
                var cardCreated = ApiService.CreateCard(new CreateCardRequest() {
                    DocumentNumber = cl.DocumentNumber,
                    Password = cl.Password,
                    IdCard = cl.IdCard
                }, out string err);
                DieIf(!cardCreated, err);
                SafeExec(()=> ShowWindow(Window.Ads));
            }
        }
        
        public static void Client() {
            if (!IsApiConnected())
                return;
            ShowView(View.SwipeCard);
        }

        public static void ClientLoadAsync(string idCard) {
            if (!IsApiConnected())
                return;
            Logger.DebugWrite($"Card Swiped: {idCard}");
            var t = new Thread(() => ClientLoadSync(idCard));
            t.Start();
        }

        private static void ClientLoadSync(string idCard) {
            try {
                ClientSession.Clear();
                DieIf(string.IsNullOrEmpty(idCard), "IdCard null.");
                var clientData = ApiService.ClientLoad(new ClientLoadRequest() {
                    IdCard = idCard
                }, out string errMsg);
                if (clientData == null) {
                    MsgBox.Error(errMsg);
                    return;
                }
                // Cargo todos los datos del usuario
                ClientSession.Load(clientData, null);
                // Busco si tiene un premio pendiente de campaña
                var reward = ApiService.GetRewardsCampaign(idCard);
                if (reward != null) {
                    ClientSession.CampaignReward = reward;
                }

                if(UIManager.CurrView != View.ClientMenu)
                    ShowView(View.ClientMenu);
                else {
                    // Este caso se da despues de canjear un premio de campaña
                    // Ya estamos en esta vista, pero hay que actualizar los datos
                    UIManager.ClientMenuView.LoadData();
                }
            }
            catch (Exception e) {
                Logger.Exception(e);
                ClientSession.Clear();
                SafeExec(() => {
                    MsgBox.Error(Strings.Get("error_cliente"));
                });
            }
        }

        public static void CancelCampaignReward() {
            try {
                if(ClientSession.CampaignReward == null)
                    return;

                var nrMov = ClientSession.CampaignReward.NroMvt;
                var success = ApiService.CancelRewardCampaign(nrMov, out string errMsg);
                if (!success) {
                    MsgBox.Error(errMsg);
                    return;
                }
                ClientSession.CampaignReward = null;
            }
            catch (Exception e) {
                Logger.Exception(e);
                SafeExec(() => {
                    MsgBox.Error(
                        "Hubo un error al cancelar el premio de campaña.");
                });
            }
        }

        public static void ClientLogin() {
            DocInput.OnConfirm = OnConfirmDocInputLogin;
            
            PassInput.OnConfirm = () => { ShowView(View.ClientMenu); };
            
            ShowView(View.DocumentInput);
        }

        private static string OnConfirmDocInputLogin(ClientStatusResponse res) {
            if (res.NotExists) {
                return Strings.Get("cliente_no_existe");
            } else {
                var cl = ClientSession.CurrClient;
                if (cl.Status != ClientStatus.Activo)
                    return Strings.Get("cliente_no_activo");
                ShowView(View.PasswordInput);
                return null;
            }
        }

        public static void ShowReward(Reward reward) {
            UIManager.RewardModal.LoadReward(reward);
            SafeExecOnActiveForm(owner => {
                UIManager.Overlay.Show(owner);
                UIManager.RewardModal.ShowDialog(Overlay);
            });
        }

        public static void ExchangeRewardAsync(Reward r, int quantity = 1) {
            SafeExec(() => {
                StatusMainView.SetState(
                    r.IsTicket ? States.PrintingTicket : States.PrintingVoucher);
                ShowView(View.StatusMain);
            });
            var t = new Thread(() => ExchangeRewardSync(r, quantity));
            t.Start();
        }

        private static void ExchangeRewardSync(Reward r, int quantity) {
            try {
                if(r.IsTicket)
                    r.ExchangeTicket(OnRewardExchangeFinish);
                else
                    r.ExchangeVoucher(OnRewardExchangeFinish, quantity);
            }
            catch (Exception e) {
                Logger.Exception(e);
                SafeExec(() => {
                    MsgBox.Error(Strings.Get("error_premio"));
                    ShowWindow(Window.Ads);
                });
            }
        }

        private static void OnRewardExchangeFinish(bool success, string errMsg) {
            Status.RefreshAsync();
            if (!success) {
                Logger.WriteAsync(errMsg);
                SafeExec(() => {
                    MsgBox.Error(Strings.Get("error_premio"));
                    ShowWindow(Window.Ads);
                });
                return;
            }

            var cl = ClientSession.CurrClient;
            // Vuelvo a cargar el cliente y lo llevo a la pantalla principal.
            SafeExec(() => {
                ClientLoadSync(cl?.IdCard);
            });
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
