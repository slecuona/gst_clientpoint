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
            var res = ApiService.ClientStatus(CreateRequest, out errMsg);
            if (res != null) {
                // Password OK.
                ClientSession.CurrClient.Password = PasswordValue;
                UIManager.Show(Window.NotConfirmedMenu);
                return true;
            } else {
                // El cliente no existe
                UIManager.Show(Window.Ads);
                return true;
            }
        }

        protected override void AfterError() {
            fldPassword.Control.Select();
        }

        protected override void OnBack(object sender, EventArgs e) {
            UIManager.Show(Window.DocumentInput);
        }

        public override void BeforeShow() {
            // Reset del form
            fldPassword.Value = "";
            fldPassword.Control.Select();
        }
    }
}
