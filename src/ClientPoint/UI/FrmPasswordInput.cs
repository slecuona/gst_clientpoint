using System;
using System.Collections.Generic;
using ClientPoint.Session;

namespace ClientPoint.UI {
    public partial class FrmPasswordInput : FrmBaseDialog {
        public FrmPasswordInput() {
            InitializeComponent();
            fldPassword.Password = true;
            ConfigureCurrentControlHandle();
            headerPanel.Title = "";
        }
        
        private string PasswordValue => fldPassword.Value;

        protected override void PerformValidation(ref List<string> errors) {
            if (string.IsNullOrEmpty(PasswordValue))
                errors.Add("Debe ingresar su contraseña.");
        }
        
        // devuelve mensaje de error (si hay)
        public Action OnConfirm;
        protected override bool PerformConfirm(out string errMsg) {
            if (PasswordValue == ClientSession.CurrClient.Password) {
                OnConfirm?.Invoke();
                errMsg = "";
                return true;
            }
            errMsg = "Contraseña incorrecta.";
            return false;
        }

        //protected override void AfterError() {
        //    UIManager.Show(Window.NewClientMenu);
        //}
        
        protected override void OnBack(object sender, EventArgs e) {
            UIManager.Show(
                ClientSession.AccessByCard ? Window.Ads : Window.DocumentInput);
        }

        public override void BeforeShow() {
            // Reset del form
            fldPassword.Value = "";
        }

        public override void AfterShow() {
            UIManager.ShowKeyboard();
            fldPassword.Control.Select();
            this.Select();
        }

        public override void AfterHide() {
            UIManager.HideKeyboard();
        }
    }
}
