using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ClientPoint.Utils;

namespace ClientPoint.UI.Controls {
    public partial class DateField : UserControl {
        public DateField() {
            InitializeComponent();

            txtDay.GotFocus += TxtOnGotFocus;
            txtMonth.GotFocus += TxtOnGotFocus;
            txtYear.GotFocus += TxtOnGotFocus;

            txtDay.Click += TxtOnClick;
            txtMonth.Click += TxtOnClick;
            txtYear.Click += TxtOnClick;

            txtDay.TextChanged += TxtOnTextChanged;
            txtMonth.TextChanged += TxtOnTextChanged;
            txtYear.TextChanged += TxtOnTextChanged;

            txtDay.Validated += TxtDayOnValidated;
            txtMonth.Validated += TxtMonthOnValidated;
            txtYear.Validated += TxtYearOnValidated;
        }

        private void TxtYearOnValidated(object sender, EventArgs e) {
            if (int.TryParse(txtYear.Text, out int day)) {
                if (day > 1900 && day <= 2050)
                    return;
            }

            txtYear.BackColor = Color.Pink;
            if (txtYear.Text == string.Empty) {
                MsgBox.Error($"Debe ingresar el año de la fecha de nacimiento.");
                return;
            }

            MsgBox.Error(
                $"'{txtYear.Text}' no es un año válido para la fecha ingresada.");
        }

        private void TxtMonthOnValidated(object sender, EventArgs e) {
            if (int.TryParse(txtMonth.Text, out int day)) {
                if (day > 0 && day <= 12)
                    return;
            }

            txtMonth.BackColor = Color.Pink;
            if (txtMonth.Text == string.Empty) {
                MsgBox.Error($"Debe ingresar el mes de la fecha de nacimiento.");
                return;
            }

            MsgBox.Error(
                $"'{txtMonth.Text}' no es un mes válido para la fecha ingresada.");
        }
        
        private void TxtDayOnValidated(object sender, EventArgs e) {
            if (int.TryParse(txtDay.Text, out int day)) {
                if (day > 0 && day <= 31)
                    return;
            }

            txtDay.BackColor = Color.Pink;
            if (txtDay.Text == string.Empty) {
                MsgBox.Error($"Debe ingresar el día de la fecha de nacimiento.");
                return;
            }

            MsgBox.Error(
                $"'{txtDay.Text}' no es un día válido para la fecha ingresada.");
        }


        private void TxtOnTextChanged(object sender, EventArgs e) {
            var txt = sender as CustomTextBox;
            if (txt == null)
                return;
            txt.BackColor = Color.White;
        }

        private void TxtOnClick(object sender, EventArgs e) {
            var txt = sender as CustomTextBox;
            txt?.SelectAll();
        }

        private void TxtOnGotFocus(object sender, EventArgs e) {
            UIManager.SetNumKeyboardCenter(false);
            UIManager.SetKeyboard(Keyboard.Num);
        }

        public string Label {
            get => lblField.Text;
            set => lblField.Text = value;
        }

        public bool IsValid() {
            try {
                var val = Value;
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public DateTime Value {
            get {
                var str = $"{txtDay.Text}/{txtMonth.Text}/{txtYear.Text}";
                return DateTime.Parse(str, new CultureInfo("es-AR"));
            }
            set {
                txtDay.Text = value.Date.Day.ToString();
                txtMonth.Text = value.Date.Month.ToString();
                txtYear.Text = value.Date.Year.ToString();
            }
        }
    }
}
