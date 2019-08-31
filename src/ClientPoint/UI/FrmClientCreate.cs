using System;
using System.Collections.Generic;
using System.Drawing;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI {
    public partial class FrmClientCreate : FrmBaseDialog {
        public FrmClientCreate() {
            InitializeComponent();
            ConfigureCurrentControlHandle();
        }

        private string NameValue => fldName.Value;
        private string LastNameValue => fldLastname.Value;
        private string DocumentValue => fldDocument.Value;
        private string EmailValue => fldEmail.Value;
        private string Email2Value => fldEmail2.Value;
        private string CellphoneValue => fldCellphone.Value;
        private string PasswordValue => fldPassword.Value;
        private string Password2Value => fldPassword2.Value;
        private string SexValue => fldSex.Value;
        private DateTime BirthDateValue => fldBirthDate.Value;

        // Mayor de 18 años?
        private static DateTime MaxBirthDate => DateTime.Today.AddYears(-18);

        protected override void PerformValidation(ref List<string> errors) {
            if (_stepNr == 1 && string.IsNullOrEmpty(NameValue))
                errors.Add("Debe ingresar su nombre.");

            if (_stepNr == 1 && string.IsNullOrEmpty(LastNameValue))
                errors.Add("Debe ingresar su apellido.");

            if (_stepNr == 1 && string.IsNullOrEmpty(DocumentValue))
                errors.Add("Debe ingresar su número de documento.");

            if (_stepNr == 1 && SexValue == null)
                errors.Add("Debe especificar su sexo.");

            if (_stepNr == 1 && BirthDateValue.Date > MaxBirthDate.Date)
                errors.Add("Debe tener mas de 18 años para registrarse.");

            if (_stepNr == 2 && string.IsNullOrEmpty(EmailValue) && string.IsNullOrEmpty(CellphoneValue))
                errors.Add("Debe ingresar una dirección de correo electrónico o un número de celular.");

            if (_stepNr == 2 && (string.IsNullOrEmpty(PasswordValue) || string.IsNullOrEmpty(Password2Value)))
                errors.Add("Debe ingresar una contraseña y su repetición.");

            if (_stepNr == 2 && PasswordValue != Password2Value)
                errors.Add("Las contraseñas ingresadas no son iguales.");

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
            if (_stepNr == 1) {
                SafeInvoke(InitStepTwo);
                errMsg = "";
                return true;
            }

            var sucess = ApiService.ClientCreate(CreateRequest, out errMsg);
            if (!sucess) return false;
            
            MsgBox.Show(
                "Cliente creado correctamente. " +
                "Se ha enviado el código de confirmación.",
                this);

            // Cargo la password ingresada para enviar en el request
            // de confirmacion
            ClientSession.CurrClient.Password = PasswordValue;
            // Cargo los datos necesarios para el resto de la sesión
            ClientSession.CurrClient.Name = NameValue;
            ClientSession.CurrClient.LastName = LastNameValue;
            UIManager.Show(Window.Confirm);
            return true;
        }

        //protected override void AfterError() {
        //    fldName.Control.Select();
        //}

        protected override void OnBack(object sender, EventArgs e) {
            if (_stepNr == 1) {
                UIManager.Show(Window.Ads);
                return;
            }
            if (_stepNr == 2) {
                InitStepOne();
                return;
            }
        }

        public override void BeforeShow() {
            // Reset del form
            fldName.Value = "";
            fldLastname.Value = "";
            fldDocument.Control.ReadOnly = true;
            fldDocument.Control.BackColor = Color.LightGray;
            fldDocument.Value = ClientSession.CurrClient.DocumentNumber;
            fldEmail.Value = "";
            fldEmail2.Value = "";
            fldCellphone.Value = "";
            fldPassword.Value = "";
            fldPassword2.Value = "";
            fldSex.Value = null;
            fldBirthDate.Value = MaxBirthDate;

            InitStepOne();

            UIManager.SetKeyboard(Keyboard.None);
        }

        public override void AfterShow() {
            UIManager.SetKeyboard(Keyboard.AlphaNum);
            fldName.Control.Select();
            this.Select();
        }

        private void ShowHideFields(bool stepOne) {
            fldName.Visible = stepOne;
            fldLastname.Visible = stepOne;
            fldDocument.Visible = stepOne;
            fldSex.Visible = stepOne;
            fldBirthDate.Visible = stepOne;

            fldEmail.Visible = !stepOne;
            fldEmail2.Visible = !stepOne;
            fldCellphone.Visible = !stepOne;
            fldPassword.Visible = !stepOne;
            fldPassword2.Visible = !stepOne;
        }

        private int _stepNr = 0;
        private void InitStepOne() {
            _stepNr = 1;
            ShowHideFields(true);
            
            fldName.Control.Select();
        }
        private void InitStepTwo() {
            _stepNr = 2;
            ShowHideFields(false);
            
            fldEmail.Control.Select();
        }
    }
}
