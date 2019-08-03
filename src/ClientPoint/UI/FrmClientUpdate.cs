using System;
using System.Collections.Generic;
using ClientPoint.Api;
using ClientPoint.Utils;

namespace ClientPoint.UI {
    public partial class FrmClientUpdate : FrmBase {
        public FrmClientUpdate() {
            InitializeComponent();

            footerPanel.OnNextClick(OnNext);
            footerPanel.OnBackClick(OnBack);
            footerPanel.NextText = "Siguiente";
            footerPanel.BackText = "Cancelar";
        }

        private string EmailValue => fldEmail.Value;
        private string CellphoneValue => fldCellphone.Value;
        
        private bool ValidateFields() {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(EmailValue) && string.IsNullOrEmpty(CellphoneValue))
                errors.Add("Debe ingresar una dirección de correo electrónico o un número de celular.");

            if (errors.Count > 0) {
                MsgBox.Error(this, string.Join("\n", errors));
                return false;
            }
            return true;
        }

        private ClientCreateRequest CreateRequest => 
            new ClientCreateRequest() {
                CelPhone = CellphoneValue,
                Email = EmailValue,
            };

        private void OnNext(object sender, EventArgs e) {
            if (!ValidateFields())
                return;
            string errMsg;
            try {
                var sucess = ApiService.ClientCreate(CreateRequest, out errMsg);
                if (sucess) {
                    MsgBox.Show(this, 
                        "Cliente creado correctamente. " +
                        "Se ha enviado el código de confirmación.");
                    UIManager.Show(Window.Confirm);
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
            UIManager.Show(Window.Ads);
        }

        public override void BeforeShow() {
            fldEmail.Value = "";
            fldCellphone.Value = "";
            base.BeforeShow();
        }
    }
}
