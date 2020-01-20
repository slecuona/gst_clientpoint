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
            headerPanel.Title = Strings.Get("titulo_actualizar_cliente");
        }

        private string EmailValue => fldEmail.Value;
        private string Email2Value => fldEmail2.Value;
        private string CellphoneValue => fldCellphone.Value;

        protected override void PerformValidation(ref List<string> errors) {
            if (string.IsNullOrEmpty(EmailValue) && string.IsNullOrEmpty(CellphoneValue))
                errors.Add(Strings.Get("error_mail_celular"));
            if ((!string.IsNullOrEmpty(EmailValue) || !string.IsNullOrEmpty(Email2Value)) && 
                EmailValue != Email2Value)
                errors.Add(Strings.Get("error_mail_iguales"));
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

            var byMail = !string.IsNullOrEmpty(EmailValue);
            if (byMail) {
                MsgBox.Email(
                    Strings.Get("cliente_actualizado") + Environment.NewLine +
                    Strings.Get("codigo_enviado_mail"));
            }
            else {
                MsgBox.Sms(
                    Strings.Get("cliente_actualizado") + Environment.NewLine +
                    Strings.Get("codigo_enviado_sms"));
            }
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
            fldEmail2.Value = ClientSession.CurrClient.Email;
            fldCellphone.Value = ClientSession.CurrClient.CellPhone;

            base.BeforeShow();
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
