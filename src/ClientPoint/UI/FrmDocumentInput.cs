using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientPoint.Api;
using ClientPoint.Session;

namespace ClientPoint.UI {
    public partial class FrmDocumentInput : FrmBaseDialog {
        public FrmDocumentInput() {
            InitializeComponent();
            //fldDocument.CustomMaskType = CustomMaskType.Document;
            ConfigureCurrentControlHandle();
            headerPanel.Title = "Por favor, ingrese su número de documento.";
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

        // devuelve mensaje de error (si hay)
        public Func<ClientStatusResponse, string> OnConfirm;
        protected override bool PerformConfirm(out string errMsg) {
            var res = ApiService.ClientStatus(CreateRequest, out errMsg);
            if (res == null) {
                return false;
            }
            // Cargo los datos del usuario
            ClientSession.Load(res, DocumentValue);
            errMsg = OnConfirm.Invoke(res);
            return errMsg == null;
        }
        
        protected override void OnBack(object sender, EventArgs e) {
            UIManager.Show(Window.NewClientMenu);
        }

        protected override void AfterError() {
            UIManager.Show(Window.NewClientMenu);
        }

        public override void BeforeShow() {
            // Reset del form
            fldDocument.Value = "";
        }

        public override void AfterShow() {
            UIManager.ShowNumKeyboard();
            fldDocument.Control.Select();
            this.Select();
        }

        public override void AfterHide() {
            UIManager.HideNumKeyboard();
        }

        private void radButton1_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
