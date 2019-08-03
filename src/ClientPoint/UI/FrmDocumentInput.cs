using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientPoint.Api;
using ClientPoint.Utils;
using ClientPoint.Session;
using Telerik.WinControls;

namespace ClientPoint.UI {
    public partial class FrmDocumentInput : FrmBase {
        public FrmDocumentInput() {
            InitializeComponent();

            footerPanel.OnNextClick(OnNext);
            footerPanel.OnBackClick(OnBack);
            footerPanel.NextText = "Siguiente";
            footerPanel.BackText = "Cancelar";
        }
        
        private string DocumentValue => fldDocument.Value;

        private bool ValidateFields() {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(DocumentValue))
                errors.Add("Debe ingresar su número de documento.");
            
            if (errors.Count > 0) {
                MsgBox.Error(this, string.Join("\n", errors));
                return false;
            }
            return true;
        }

        private ClientStatusRequest CreateRequest => 
            new ClientStatusRequest() {
                DocumentNumber = DocumentValue
            };

        private void OnNext(object sender, EventArgs e) {
            if (!ValidateFields())
                return;
            string errMsg;
            try {
                footerPanel.Waiting = true;
                var res = ApiService.ClientStatus(CreateRequest, out errMsg);
                if (res != null) {
                    if (res.NotExists) {
                        var createNew = MsgBox.Confirm(this,
                            "No hay ningun cliente registrado con este número de documento." +
                            "¿Desea crear una cuenta?");
                        if (createNew) {
                            ClientSession.EnterDocument(DocumentValue);
                            UIManager.Show(Window.ClientCreate);
                            return;
                        }
                        else {
                            // Salir / cancela
                            UIManager.Show(Window.Ads);
                            return;
                        }
                    }
                    else {
                        // El usuario ya existe, debe ingresar password para continuar.
                        UIManager.Show(Window.PasswordInput);
                        return;
                    }
                }
            }
            catch (Exception ex) {
                //TODO: Log
                errMsg = ex.Message;
            }
            finally {
                footerPanel.Waiting = false;
            }
            MsgBox.Error(this, errMsg);
        }

        private void OnBack(object sender, EventArgs e) {
            UIManager.Show(Window.Ads);
        }

        public override void BeforeShow() {
            // Reset del form
            fldDocument.Value = "";
            base.BeforeShow();
        }
    }
}
