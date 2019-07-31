using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientPoint.Api;
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

        private string NameValue => fldName.GetValue();
        private string LastNameValue => fldLastname.GetValue();
        private string DocumentValue => fldDocument.GetValue();
        private string EmailValue => fldEmail.GetValue();
        private string CellphoneValue => fldCellphone.GetValue();
        private string PasswordValue => fldPassword.GetValue();
        private string Password2Value => fldPassword2.GetValue();
        private string SexValue => fldSex.GetValue();
        private DateTime BirthDateValue => fldBirthDate.GetValue();

        // Mayor de 18 años?
        private static DateTime MaxBirthDate => DateTime.Today.AddYears(-18);

        private bool ValidateFields() {
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

            if(BirthDateValue.Date > MaxBirthDate.Date)
                errors.Add("Debe tener mas de 18 años para registrarse.");

            //TODO: Que otras validaciones?

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

        private ClientCreateRequest CreateRequest => 
            new ClientCreateRequest() {
                DocumentNumber = DocumentValue,
                Password = PasswordValue,
                CelPhone = CellphoneValue,
                Email = EmailValue,
                Name = NameValue,
                LastName = LastNameValue,
                BirthDate = BirthDateValue.ToString("yyyy-MM-dd"),
                Sex = SexValue
            };

        private void OnNext(object sender, EventArgs e) {
            if (!ValidateFields())
                return;
            string errMsg;
            try {
                var sucess = ApiService.ClientCreate(CreateRequest, out errMsg);
                if (sucess) {
                    RadMessageBox.Show("Cliente creado correctamente.");
                    UIManager.Show(Window.NewUsr);
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
            UIManager.Show(Window.NewUsr);
        }
    }
}
