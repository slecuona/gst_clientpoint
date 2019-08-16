using System;
using System.Collections.Generic;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI {
    public partial class FrmConfirm : FrmBaseDialog {
        public FrmConfirm() {
            InitializeComponent();
            this.fldCode.CustomMaskType = CustomMaskType.ConfirmCode;
            this.fldCode.Uppercase = true;
            ConfigureCurrentControlHandle();
            headerPanel.Title = 
                "Ingrese el código de confirmación enviado por SMS o a su casilla de correo.";
        }
        
        private string CodeValue => fldCode?.Value?.ToUpper();

        protected override void PerformValidation(ref List<string> errors) {
            if (string.IsNullOrEmpty(CodeValue))
                errors.Add("Debe ingresar el código de confirmación.");
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
            UIManager.HideKeyboard();
        }

        protected override void OnBack(object sender, EventArgs e) {
            UIManager.Show(Window.NewClientMenu);
        }

        public override void BeforeShow() {
            // Reset del form
            fldCode.Value = null;
        }

        public override void AfterShow() {
            UIManager.ShowKeyboard();
            fldCode.Control.Select();
            this.Select();
        }
    }
}
