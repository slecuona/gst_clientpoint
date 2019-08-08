using System;
using System.Collections.Generic;
using ClientPoint.Api;
using ClientPoint.Session;

namespace ClientPoint.UI {
    public partial class FrmPasswordInput : FrmBaseDialog {
        public FrmPasswordInput() {
            InitializeComponent();
            fldPassword.Password = true;
        }
        
        private string PasswordValue => fldPassword.Value;

        protected override void PerformValidation(ref List<string> errors) {
            if (string.IsNullOrEmpty(PasswordValue))
                errors.Add("Debe ingresar su contraseña.");
        }

        //TODO: Falta un endpoint de autenticacion
        private ClientStatusRequest CreateRequest => 
            new ClientStatusRequest() {
                DocumentNumber = ClientSession.CurrClient.DocumentNumber
            };

        protected override bool PerformConfirm(out string errMsg) {
            if (PasswordValue == ClientSession.CurrClient.Password) {
                // Si el cliente no esta confirmado, lo envio al menu
                // donde puede actualizar datos e ingresar el cod. de confirmacion.
                // Si no, va al menu principal
                UIManager.Show(
                    ClientSession.CurrClient.Status == ClientStatus.Pendiente
                        ? Window.NotConfirmedMenu
                        : Window.MainMenu);
                errMsg = "";
                return true;
            }
            errMsg = "Contraseña incorrecta.";
            return false;
        }

        protected override void AfterError() {
            fldPassword.Control.Select();
        }

        protected override void OnBack(object sender, EventArgs e) {
            UIManager.Show(
                ClientSession.AccessByCard ? Window.Ads : Window.DocumentInput);
        }

        public override void BeforeShow() {
            // Reset del form
            fldPassword.Value = "";
            fldPassword.Control.Select();
        }
    }
}
