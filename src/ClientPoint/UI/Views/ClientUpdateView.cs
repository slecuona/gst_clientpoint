using System;
using System.Collections.Generic;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Views {
    public partial class ClientUpdateView : BaseViewDialogView {
        public ClientUpdateView() {
            InitializeComponent();
            ConfigureCurrentControlHandle();
            headerPanel.Title =
                "Al confirmar, se reenviará el código de confirmación.";
        }

        private string EmailValue => fldEmail.Value;
        private string CellphoneValue => fldCellphone.Value;

        protected override void PerformValidation(ref List<string> errors) {
            if (string.IsNullOrEmpty(EmailValue) && string.IsNullOrEmpty(CellphoneValue))
                errors.Add("Debe ingresar una dirección de correo electrónico o un número de celular.");
        }
        
        private ClientUpdateRequest CreateRequest => 
            new ClientUpdateRequest() {
                DocumentNumber = ClientSession.CurrClient.DocumentNumber,
                Password = ClientSession.CurrClient.Password,
                CelPhone = CellphoneValue,
                Email = EmailValue,
            };

        protected override bool PerformConfirm(out string errMsg) {
            var sucess = ApiService.ClientUpdate(CreateRequest, out errMsg);
            if (!sucess) return false;

            MsgBox.Show(
                "Datos actualizados correctamente. " +
                "Se ha enviado el código de confirmación.");
            //UIManager.ShowWindow(Window.Confirm);
            UIManager.ShowView(View.Confirm);
            return true;
        }

        //protected override void AfterError() {
        //    fldEmail.Control.Select();
        //}

        protected override void OnBack(object sender, EventArgs e) {
            //UIManager.ShowWindow(Window.MainMenu);
            UIManager.ShowView(View.MainMenu);
        }

        public override void BeforeShow() {
            fldEmail.Value = ClientSession.CurrClient.Email;
            fldCellphone.Value = ClientSession.CurrClient.CellPhone;
        }

        public override void AfterShow() {
            UIManager.SetKeyboard(Keyboard.AlphaNum);
            fldEmail.Control.Select();
            this.Select();
        }

        public override void AfterHide() {
            //UIManager.HideKeyboard();
        }
    }
}
