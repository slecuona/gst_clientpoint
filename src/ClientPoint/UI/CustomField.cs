using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class CustomField : UserControl {
        private bool _isPass = false;
        private bool _passVisible = false;

        public Keyboard Keyboard = Keyboard.None;

        public CustomField() {
            InitializeComponent();
            radTextBox1.GotFocus += RadTextBox1OnGotFocus;
            //radTextBox1.LostFocus += RadTextBox1OnLostFocus;
            radTextBox1.TextChanged += RadTextBox1OnTextChanged;
            btnClear.Click += BtnClearOnClick;
            btnViewPass.Click += BtnViewPassOnClick;
        }

        private void BtnViewPassOnClick(object sender, EventArgs e) {
            if (_passVisible) {
                radTextBox1.PasswordChar = '*';
                btnViewPass.Image = Properties.Resources.eye;
                _passVisible = false;
                return;
            }
            else {
                radTextBox1.PasswordChar = '\0';
                btnViewPass.Image = Properties.Resources.eye_on;
                _passVisible = true;
                return;
            }
        }

        private void BtnClearOnClick(object sender, EventArgs e) {
            radTextBox1.Clear();
            radTextBox1.Select();
            RefreshBtnClear();
        }

        private void ShowBtn(RadButton btn) {
            btn.Location = new Point(
                radTextBox1.Left + radTextBox1.Width - 51, 1);
            var p = radTextBox1.Padding;
            radTextBox1.Padding = new Padding(p.Left,p.Top,60,p.Bottom);
            btn.Visible = true;
        }

        private void RefreshBtnClear() {
            if(Password || !radTextBox1.Enabled)
                return;
            if (string.IsNullOrEmpty(radTextBox1.Text)) {
                btnClear.Visible = false;
                return;
            }
            ShowBtn(btnClear);
        }

        private void RefreshBtnViewPass() {
            if (!Password)
                return;
            if (string.IsNullOrEmpty(radTextBox1.Text)) {
                btnViewPass.Visible = false;
                return;
            }
            ShowBtn(btnViewPass);
        }

        private void RadTextBox1OnTextChanged(object sender, EventArgs e) {
            RefreshBtnClear();
            RefreshBtnViewPass();
        }

        //private void RadTextBox1OnLostFocus(object sender, EventArgs e) {
        //    btnClear.Visible = false;
        //}

        private void RadTextBox1OnGotFocus(object sender, EventArgs e) {
            RefreshBtnClear();
            RefreshBtnViewPass();
            // En este caso, no forzamos el ocultamiento de los teclados.
            if (Keyboard == Keyboard.None)
                return;
            UIManager.SetNumKeyboardCenter(false);
            UIManager.SetKeyboard(Keyboard);
        }

        public Control Control => radTextBox1;

        public string Label {
            get => radLabel1.Text;
            set => radLabel1.Text = value;
        }

        public string Value {
            get => radTextBox1.Text;
            set => radTextBox1.Text = value;
        }

        public bool Password {
            set {
                _isPass = value;
                if (value) {
                    radTextBox1.PasswordChar =  '*';
                    _passVisible = false;
                }
            }
            get => _isPass;
        }
    }
}
