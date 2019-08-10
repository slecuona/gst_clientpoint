using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientPoint.Api;
using ClientPoint.Utils;
using ClientPoint.Session;

namespace ClientPoint.UI {
    public partial class FrmDocumentInput : FrmBaseDialog {
        public FrmDocumentInput() {
            InitializeComponent();
            //fldDocument.CustomMaskType = CustomMaskType.Document;
        }
        
        private string DocumentValue => fldDocument.Value;

        protected override void PerformValidation(ref List<string> errors) {
            if (string.IsNullOrEmpty(DocumentValue))
                errors.Add("Debe ingresar su número de documento.");
        }

        private ClientStatusRequest CreateRequest => 
            new ClientStatusRequest() {
                DocumentNumber = DocumentValue
            };

        protected override bool PerformConfirm(out string errMsg) {
            var res = ApiService.ClientStatus(CreateRequest, out errMsg);
            if (res == null) {
                return false;
            }
            // Cargo todos los datos del usuario
            ClientSession.Load(res, DocumentValue);
            if (res.NotExists) {
                var createNew = MsgBox.Confirm(this,
                    "No hay ningun cliente registrado con este número de documento." +
                    "¿Desea crear una cuenta?");
                if (createNew) {
                    UIManager.Show(Window.ClientCreate);
                    return true;
                } else {
                    // Salir / cancela
                    UIManager.Show(Window.Ads);
                    return true;
                }
            } else {
                // El usuario ya existe, debe ingresar password para continuar.
                UIManager.Show(Window.PasswordInput);
                return true;
            }
        }

        protected override void AfterError() {
            fldDocument.Control.Select();
        }

        protected override void OnBack(object sender, EventArgs e) {
            UIManager.HideKeyboard();
            UIManager.Show(Window.Ads);
        }

        public override void BeforeShow() {
            // Reset del form
            fldDocument.Value = "";
            fldDocument.Control.Select();
            UIManager.ShowKeyboard();
        }

        private void radButton1_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
