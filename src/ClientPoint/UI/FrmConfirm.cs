using System;
using System.Collections.Generic;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI {
    public partial class FrmConfirm : FrmBase {
        public FrmConfirm() {
            InitializeComponent();

            footerPanel.OnNextClick(OnNext);
            footerPanel.OnBackClick(OnBack);
            footerPanel.NextText = "Confirmar";
            footerPanel.BackText = "Cancelar";
        }
        
        private string CodeValue => fldCode.Value.ToUpper();

        private bool ValidateFields() {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(CodeValue)) 
                errors.Add("Debe ingresar el código de confirmación.");

            if (errors.Count > 0) {
                MsgBox.Error(this, string.Join("\n", errors));
                return false;
            }
            return true;
        }

        private ConfirmCodeRequest CreateRequest => 
            new ConfirmCodeRequest() {
                DocumentNumber = ClientSession.DocumentNumber,
                Password = ClientSession.Password,
                Code = CodeValue,
            };

        private void OnNext(object sender, EventArgs e) {
            if (!ValidateFields())
                return;
            string errMsg;
            try {
                var sucess = ApiService.ConfirmCode(CreateRequest, out errMsg);
                if (sucess) {
                    MsgBox.Show(this, "Cliente confirmado correctamente.");
                    // TODO: Ir a confirmed menu
                    UIManager.Show(Window.Ads);
                    return;
                }
            }
            catch (Exception ex) {
                //TODO: Log
                errMsg = ex.Message;
            }
            MsgBox.Error(this, errMsg);
        }

        private void OnBack(object sender, EventArgs e) {
            UIManager.Show(Window.NotConfirmedMenu);
        }

        public override void BeforeShow() {
            // Reset del form
            fldCode.Value = null;
            base.BeforeShow();
        }
    }
}
