using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ClientPoint.UI {
    public partial class FrmAddUsr : FrmBase {
        public FrmAddUsr() {
            InitializeComponent();

            footerPanel.OnNextClick(OnNext);
            footerPanel.OnBackClick(OnBack);
            footerPanel.NextText = "Siguiente";
            footerPanel.BackText = "Cancelar";
        }

        private string NameValue => fldName.Text;
        private string LastNameValue => fldLastname.Text;
        private string DocumentValue => fldDocument.Text;
        private string EmailValue => fldEmail.Text;
        private string CellphoneValue => fldCellphone.Text;
        private string PasswordValue => fldPassword.Text;
        private string Password2Value => fldPassword2.Text;
        private string SexValue => fldSex.GetValue();
        private DateTime BornDateValue => fldBornDate.GetValue();

        // Mayor de 18 años?
        private static DateTime MaxBornDate => DateTime.Today.AddYears(-18);

        private List<string> Validate() {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(NameValue)) 
                errors.Add("Debe ingresar su nombre.");

            if (string.IsNullOrEmpty(LastNameValue))
                errors.Add("Debe ingresar su apellido.");

            if (string.IsNullOrEmpty(DocumentValue))
                errors.Add("Debe ingresar su número de documento.");

            if (string.IsNullOrEmpty(EmailValue) && string.IsNullOrEmpty(CellphoneValue))
                errors.Add("Debe ingresar una dirección de correo electrónico o un número de celular.");

            if (string.IsNullOrEmpty(PasswordValue) || string.IsNullOrEmpty(Password2Value))
                errors.Add("Debe ingresar una contraseña y su repetición.");

            if (PasswordValue != Password2Value)
                errors.Add("Las contraseñas ingresadas no son iguales.");

            if(SexValue == null)
                errors.Add("Debe especificar su sexo.");

            if(BornDateValue.Date > MaxBornDate.Date)
                errors.Add("Debe tener mas de 18 años para registrarse.");

            return errors;
        }

        private void OnNext(object sender, EventArgs e) {
            var errors = Validate();
            if (errors.Count > 0) {
                RadMessageBox.Show(
                    this, 
                    string.Join("\n", errors), 
                    "Errores", 
                    MessageBoxButtons.OK, 
                    RadMessageIcon.Error);
                return;
            }
        }

        private void OnBack(object sender, EventArgs e) {
            UIManager.Show(Window.NewUsr);
        }
    }
}
