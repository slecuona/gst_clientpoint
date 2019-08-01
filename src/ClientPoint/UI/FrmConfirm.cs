using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Api;
using Telerik.WinControls;

namespace ClientPoint.UI {
    public partial class FrmConfirm : FrmBase {
        // Este form tiene un modo "post create" que se muestra
        // despues del alta, donde no hace falta volver a ingresar
        // el documento y el password.
        private bool _postCreate = false;
        private string _postCreateDoc = null;
        private string _postCreatePass = null;

        public FrmConfirm() {
            InitializeComponent();

            footerPanel.OnNextClick(OnNext);
            footerPanel.OnBackClick(OnBack);
            footerPanel.NextText = "Confirmar";
            footerPanel.BackText = "Cancelar";
        }

        public void PostCreateMode(string doc, string pass) {
            _postCreate = true;
            _postCreateDoc = doc;
            _postCreatePass = pass;
            fldDocument.Visible = false;
            fldPassword.Visible = false;
            fldCode.Location = new Point(0, 0);
        }

        private string DocumentValue => _postCreate ? 
            _postCreateDoc : fldDocument.Value;
        private string PasswordValue => _postCreate ? 
            _postCreatePass : fldPassword.Value;
        private string CodeValue => fldCode.Value.ToUpper();

        private bool ValidateFields() {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(CodeValue)) 
                errors.Add("Debe ingresar el código de confirmación.");
            
            if (string.IsNullOrEmpty(DocumentValue))
                errors.Add("Debe ingresar su número de documento.");

            if (string.IsNullOrEmpty(PasswordValue))
                errors.Add("Debe ingresar su contraseña.");

            if (errors.Count > 0) {
                RadMessageBox.Show(
                    this,
                    string.Join("\n", errors),
                    "Errores",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error);
                return false;
            }
            return true;
        }

        private ConfirmCodeRequest CreateRequest => 
            new ConfirmCodeRequest() {
                DocumentNumber = DocumentValue,
                Password = PasswordValue,
                Code = CodeValue,
            };

        private void OnNext(object sender, EventArgs e) {
            if (!ValidateFields())
                return;
            string errMsg;
            try {
                var sucess = ApiService.ConfirmCode(CreateRequest, out errMsg);
                if (sucess) {
                    RadMessageBox.Show("Cliente confirmado correctamente.");
                    UIManager.Show(Window.Ads);
                    return;
                }
            }
            catch (Exception ex) {
                //TODO: Log
                errMsg = ex.Message;
            }
            RadMessageBox.Show(this, errMsg, "Error", 
                MessageBoxButtons.OK, RadMessageIcon.Error);
        }

        private void OnBack(object sender, EventArgs e) {
            UIManager.Show(Window.NewUsrMenu);
        }

        public override void BeforeShow() {
            // Reset del form
            fldDocument.Value = "";
            fldPassword.Value = "";
            fldCode.Value = null;
            base.BeforeShow();
        }
    }
}
