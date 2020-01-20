using System;
using System.Collections.Generic;
using System.Drawing;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Views {
    public partial class ClientCreateView : BaseViewDialogView {
        public ClientCreateView() {
            InitializeComponent();
            ConfigureCurrentControlHandle();
            headerPanel.Title = Strings.Get("titulo_nuevo_cliente");
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
                errors.Add(Strings.Get("error_nombre"));

            if (_stepNr == 1 && string.IsNullOrEmpty(LastNameValue))
                errors.Add(Strings.Get("error_apellido"));

            if (_stepNr == 1 && string.IsNullOrEmpty(DocumentValue))
                errors.Add(Strings.Get("error_documento"));

            if (_stepNr == 1 && SexValue == null)
                errors.Add("error_sexo");

            if(_stepNr == 1 && !fldBirthDate.IsValid())
                errors.Add(Strings.Get("error_fecha_nac"));

            if (_stepNr == 1 && fldBirthDate.IsValid() && BirthDateValue.Date > MaxBirthDate.Date)
                errors.Add(Strings.Get("error_mayor_edad"));

            if (_stepNr == 2 && string.IsNullOrEmpty(EmailValue) && string.IsNullOrEmpty(CellphoneValue))
                errors.Add(Strings.Get("error_mail_celular"));

            if (_stepNr == 2 && 
                (!string.IsNullOrEmpty(EmailValue) || !string.IsNullOrEmpty(Email2Value)) && 
                EmailValue != Email2Value)
                errors.Add(Strings.Get("error_mail_iguales"));

            if (_stepNr == 2 && (string.IsNullOrEmpty(PasswordValue) || string.IsNullOrEmpty(Password2Value)))
                errors.Add(Strings.Get("error_pass_repeticion"));

            if (_stepNr == 2 && PasswordValue != Password2Value)
                errors.Add(Strings.Get("error_pass_iguales"));

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
                UIManager.SafeExec(InitStepTwo);
                errMsg = "";
                return true;
            }

            var sucess = ApiService.ClientCreate(CreateRequest, out errMsg);
            if (!sucess) return false;

            var byMail = !string.IsNullOrEmpty(EmailValue);
            if (byMail) {
                MsgBox.Email(
                    Strings.Get("cliente_creado") + Environment.NewLine +
                    Strings.Get("codigo_enviado_mail"));
            } else {
                MsgBox.Sms(
                    Strings.Get("cliente_creado") + Environment.NewLine +
                    Strings.Get("codigo_enviado_sms"));
            }

            // Cargo la password ingresada para enviar en el request
            // de confirmacion
            ClientSession.CurrClient.Password = PasswordValue;
            // Cargo los datos necesarios para el resto de la sesión
            ClientSession.CurrClient.Name = NameValue;
            ClientSession.CurrClient.LastName = LastNameValue;
            //UIManager.ShowWindow(Window.Confirm);
            UIManager.ShowView(View.Confirm);
            return true;
        }

        //protected override void AfterError() {
        //    fldName.Control.Select();
        //}

        protected override void OnBack(object sender, EventArgs e) {
            if (_stepNr == 1) {
                UIManager.ShowWindow(Window.Ads);
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
            fldPassword.ResetViewPass();
            fldPassword2.Value = "";
            fldPassword2.ResetViewPass();
            fldSex.Value = null;
            fldBirthDate.Value = MaxBirthDate;

            InitStepOne();

            UIManager.SetKeyboard(Keyboard.None);

            base.BeforeShow();
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
