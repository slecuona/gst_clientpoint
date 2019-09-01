using System;
using System.Collections.Generic;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.UI.Panels;

namespace ClientPoint.UI.Views {
    public partial class DocumentInput : BaseDialogView {
        public DocumentInput() {
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
            //UIManager.ShowWindow(Window.MainMenu);
            UIManager.ShowWindow(Window.Main);
        }

        protected override void AfterError() {
            //UIManager.ShowWindow(Window.MainMenu);
            UIManager.ShowWindow(Window.Main);
        }

        public override void BeforeShow() {
            // Reset del form
            fldDocument.Value = "";
        }

        public override void AfterShow() {
            UIManager.SetNumKeyboardCenter(true);
            UIManager.SetKeyboard(Keyboard.Num);
            fldDocument.Control.Select();
            this.Select();
        }

        public override void BeforeHide() {
            //UIManager.HideNumKeyboard();
        }
    }
}
