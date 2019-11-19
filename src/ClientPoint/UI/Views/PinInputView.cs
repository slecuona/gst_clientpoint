using System;
using System.Collections.Generic;

namespace ClientPoint.UI.Views {
    public partial class PinInputView : BaseViewDialogView {
        public PinInputView() {
            InitializeComponent();
            fldPin.Password = true;
            ConfigureCurrentControlHandle();
            headerPanel.Title = "Ingrese el PIN";
        }
        
        private string PINValue => fldPin.Value;

        protected override void PerformValidation(ref List<string> errors) {
            if (string.IsNullOrEmpty(PINValue))
                errors.Add("Debe ingresar el PIN.");
        }
        
        public Action OnConfirm;
        protected override bool PerformConfirm(out string errMsg) {
            if (PINValue == Config.ControlPin) {
                OnConfirm?.Invoke();
                errMsg = "";
                return true;
            }
            errMsg = "PIN incorrecto.";
            return false;
        }

        protected override void OnBack(object sender, EventArgs e) {
            UIManager.ShowWindow(Window.Ads);
        }

        public override void BeforeShow() {
            // Reset del form
            fldPin.Value = "";

            base.BeforeShow();
        }

        public override void AfterShow() {
            //UIManager.SetNumKeyboardCenter(true);
            //UIManager.SetKeyboard(Keyboard.Num);
            fldPin.Control.Select();
            this.Select();
        }

        public override void AfterHide() {
            fldPin.ResetViewPass();
        }

        protected override void AfterError() {
            fldPin.ResetViewPass();
            fldPin.Value = "";
            fldPin.Control.Select();
        }
    }
}
