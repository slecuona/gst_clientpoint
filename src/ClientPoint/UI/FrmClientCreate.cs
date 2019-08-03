using System;
using System.Collections.Generic;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI {
    public partial class FrmClientCreate : FrmBaseDialog {
        public FrmClientCreate() {
            InitializeComponent();
        }

        private string NameValue => fldName.Value;
        private string LastNameValue => fldLastname.Value;
        private string DocumentValue => fldDocument.Value;
        private string EmailValue => fldEmail.Value;
        private string CellphoneValue => fldCellphone.Value;
        private string PasswordValue => fldPassword.Value;
        private string Password2Value => fldPassword2.Value;
        private string SexValue => fldSex.Value;
        private DateTime BirthDateValue => fldBirthDate.Value;

        // Mayor de 18 años?
        private static DateTime MaxBirthDate => DateTime.Today.AddYears(-18);

        protected override void PerformValidation(ref List<string> errors) {
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

            if (SexValue == null)
                errors.Add("Debe especificar su sexo.");

            if (BirthDateValue.Date > MaxBirthDate.Date)
                errors.Add("Debe tener mas de 18 años para registrarse.");

            //TODO: Que otras validaciones?
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

        protected override bool PerformConfirm(out string errMsg) {
            var sucess = ApiService.ClientCreate(CreateRequest, out errMsg);
            if (!sucess) return false;

            MsgBox.Show(this,
                "Cliente creado correctamente. " +
                "Se ha enviado el código de confirmación.");
            UIManager.Show(Window.Confirm);
            return true;
        }

        protected override void OnBack(object sender, EventArgs e) {
            UIManager.Show(Window.Ads);
        }

        public override void BeforeShow() {
            // Reset del form
            fldName.Value = "";
            fldLastname.Value = "";
            fldDocument.Value = ClientSession.DocumentNumber;
            fldDocument.TextBox.Enabled = false;
            fldEmail.Value = "";
            fldCellphone.Value = "";
            fldPassword.Value = "";
            fldPassword2.Value = "";
            fldSex.Value = null;
            fldBirthDate.Value = MaxBirthDate;
            base.BeforeShow();
        }
    }
}
