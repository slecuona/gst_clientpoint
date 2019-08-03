using System;
using System.Collections.Generic;
using ClientPoint.Api;
using ClientPoint.Utils;
using ClientPoint.Session;

namespace ClientPoint.UI {
    public partial class FrmPasswordInput : FrmBase {
        public FrmPasswordInput() {
            InitializeComponent();

            footerPanel.OnNextClick(OnNext);
            footerPanel.OnBackClick(OnBack);
            footerPanel.NextText = "Siguiente";
            footerPanel.BackText = "Cancelar";
        }
        
        private string PasswordValue => fldPassword.Value;

        private bool ValidateFields() {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(PasswordValue))
                errors.Add("Debe ingresar su contraseña.");
            
            if (errors.Count > 0) {
                MsgBox.Error(this, string.Join("\n", errors));
                return false;
            }
            return true;
        }

        //TODO: Falta un endpoint se autenticacion
        private ClientStatusRequest CreateRequest => 
            new ClientStatusRequest() {
                DocumentNumber = ClientSession.DocumentNumber
            };

        private void OnNext(object sender, EventArgs e) {
            if (!ValidateFields())
                return;
            string errMsg;
            try {
                footerPanel.Waiting = true;
                var res = ApiService.ClientStatus(CreateRequest, out errMsg);
                if (res != null) {
                    // Password OK.
                    ClientSession.EnterPassword(PasswordValue);
                    UIManager.Show(Window.NotConfirmedMenu);
                    return;
                }
                else {
                    // El cliente no existe
                    UIManager.Show(Window.Ads);
                    return;
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
            UIManager.Show(Window.DocumentInput);
        }

        public override void BeforeShow() {
            // Reset del form
            fldPassword.Value = "";
            base.BeforeShow();
        }
    }
}
