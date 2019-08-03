using System;
using System.Collections.Generic;
using ClientPoint.Utils;

namespace ClientPoint.UI {
    /// <summary>
    /// Form base para una ventana de dialogo. (Ingreso de campos)
    /// Incluye el panel de navegacion
    /// </summary>
    public partial class FrmBaseDialog : FrmBase {
        public FrmBaseDialog() {
            InitializeComponent();
            footerPanel.OnNextClick(OnNext);
            footerPanel.OnBackClick(OnBack);
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
            string errMsg;
            try {
                footerPanel.Waiting = true;
                var sucess = PerformConfirm(out errMsg);
                if (sucess)
                    return;
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
