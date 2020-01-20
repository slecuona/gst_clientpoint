using System;
using System.Collections.Generic;
using System.Drawing;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Views {
    public partial class ConfirmView : BaseViewDialogView {
        public ConfirmView() {
            InitializeComponent();
            ConfigureCurrentControlHandle();
            fldCode.Control.Width = 180;
            fldCode.Control.Left = 150;
            headerPanel.Title = $"           {Strings.Get("titulo_confirmar_cliente")}";
            headerPanel.Label.Font = FontUtils.Roboto(18, FontStyle.Bold);
        }
        
        private string CodeValue => fldCode?.Value?.ToUpper();

        protected override void PerformValidation(ref List<string> errors) {
            if (string.IsNullOrEmpty(CodeValue))
                errors.Add("error_codigo");
        }

        private ConfirmCodeRequest CreateRequest => 
            new ConfirmCodeRequest() {
                DocumentNumber = ClientSession.CurrClient.DocumentNumber,
                Password = ClientSession.CurrClient.Password,
                Code = CodeValue,
            };

        protected override bool PerformConfirm(out string errMsg) {
            var sucess = ApiService.ConfirmCode(CreateRequest, out errMsg);
            if (!sucess) return false;

            Op.PrintCard();
            return true;
        }

        //protected override void AfterError() {
        //    fldCode.Control.Select();
        //}

        public override void BeforeHide() {
            //UIManager.HideKeyboard();
        }

        protected override void OnBack(object sender, EventArgs e) {
            //UIManager.ShowWindow(Window.MainMenu);
            UIManager.ShowView(View.MainMenu);
        }

        public override void BeforeShow() {
            // Reset del form
            fldCode.Value = null;

            base.BeforeShow();
        }

        public override void AfterShow() {
            UIManager.SetKeyboard(Keyboard.AlphaNum);
            fldCode.Control.Select();
            this.Select();
        }
    }
}
