using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ClientPoint.Utils;

namespace ClientPoint.UI {
    /// <summary>
    /// Form base para una ventana de dialogo. (Ingreso de campos)
    /// Incluye el panel de navegacion
    /// </summary>
    public partial class FrmBaseDialog : FrmBase {
        public Control CurrentControl = null;

        public FrmBaseDialog() {
            InitializeComponent();
            footerPanel.OnNextClick(OnNext);
            footerPanel.OnBackClick(OnBack);
            //ConfigureCurrentHandle();
        }

        // Nos permite monitorear el control activo
        // (En donde se debe hacer foco al utilizar el teclado)
        // Este metodo se debe llamar luego de agregar los controles del dialogo.
        protected void ConfigureCurrentControlHandle() {
            foreach (Control ctrl in radScrollablePanel1.PanelContainer.Controls) {
                if (ctrl is CustomField field) {
                    field.Control.GotFocus += ControlOnGotFocus;
                    continue;
                }
                if (ctrl is CustomMaskedField maskedField) {
                    maskedField.Control.GotFocus += ControlOnGotFocus;
                    continue;
                }
            }
        }

        private void ControlOnGotFocus(object sender, EventArgs e) {
            CurrentControl = sender as Control;
        }

        /// <summary>
        /// Este metodo se debe sobreescribir para realizar las valdiaciones
        /// de cada dialogo
        /// </summary>
        /// <param name="errors"></param>
        protected virtual void PerformValidation(ref List<string> errors) {
        }

        /// <summary>
        /// Procedimiento default para la validacion
        /// </summary>
        /// <returns></returns>
        private bool Validation() {
            var errors = new List<string>();

            PerformValidation(ref errors);
            
            if (errors.Count > 0) {
                MsgBox.Error(this, string.Join("\n", errors));
                AfterError();
                return false;
            }
            return true;
        }


        /// <summary>
        /// Este metodo se debe sobreescribir para definir el procedimiento
        /// a realizar al confirmar el dialogo.
        /// </summary>
        /// <param name="errMsg"></param>
        protected virtual bool PerformConfirm(out string errMsg) {
            errMsg = "";
            return true;
        }

        /// <summary>
        /// Procedimiento default al confirmar el dialogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNext(object sender, EventArgs e) {
            if (!Validation())
                return;
            footerPanel.Waiting = true;
            var t = new Thread(ConfirmAsync);
            t.Start();
        }

        private void ConfirmAsync() {
            string errMsg;
            try {
                var sucess = PerformConfirm(out errMsg);
                if (sucess)
                    return;
            } catch (Exception ex) {
                Logger.Exception(ex);
                errMsg = ex.Message;
            } finally {
                SafeInvoke(() => {
                    footerPanel.Waiting = false;
                });
            }
            MsgBox.Error(this, errMsg);
            SafeInvoke(AfterError);
        }

        // Handle safe thread
        protected virtual void AfterError() {
            CurrentControl?.Select();
        }

        /// <summary>
        /// Accion a realizar al retroceder el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnBack(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
    }
}
