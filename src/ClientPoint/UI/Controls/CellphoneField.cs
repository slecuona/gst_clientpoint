using System;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;

namespace ClientPoint.UI.Controls {
    public partial class CellphoneField : UserControl {
        public CellphoneField() {
            InitializeComponent();

            txtCod.GotFocus += TxtOnGotFocus;
            txtNum.GotFocus += TxtOnGotFocus;

            txtCod.Click += TxtOnClick;
            txtNum.Click += TxtOnClick;

            txtCod.TextChanged += TxtOnTextChanged;
            txtNum.TextChanged += TxtOnTextChanged;

            txtCod.Validated += TxtCodOnValidated;
            txtNum.Validated += TxtNumOnValidated;
        }
        

        private void TxtNumOnValidated(object sender, EventArgs e) {
            if (int.TryParse(txtNum.Text, out int day)) {
                if (day > 0)
                    return;
            }

            //txtNum.BackColor = Color.Pink;
            //if (txtNum.Text == string.Empty) {
            //    MsgBox.Error($"Debe ingresar un número de ce.");
            //    return;
            //}
        }
        
        private void TxtCodOnValidated(object sender, EventArgs e) {
            if (int.TryParse(txtCod.Text, out int day)) {
                if (day > 0 && day <= 4000)
                    return;
            }

            if (txtCod.Text == string.Empty)
                return;

            txtCod.BackColor = Color.Pink;

            MsgBox.Error(
                $"'{txtCod.Text}' no es un código de área válido.");
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
        
        public string Value {
            get {
                return $"{txtCod.Text}{txtNum.Text}";
            }
            set {
                if (value == null || value == string.Empty) {
                    txtCod.Text = "";
                    txtNum.Text = "";
                    return;
                }

                txtCod.Text = "11";
                txtNum.Text = value;
            }
        }
    }
}
