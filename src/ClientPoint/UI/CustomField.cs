using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientPoint.UI {
    public partial class CustomField : UserControl {
        public CustomField() {
            InitializeComponent();
            radTextBox1.GotFocus += RadTextBox1OnGotFocus;
            //radTextBox1.LostFocus += RadTextBox1OnLostFocus;
            radTextBox1.TextChanged += RadTextBox1OnTextChanged;
            btnClear.Click += BtnClearOnClick;
        }

        private void BtnClearOnClick(object sender, EventArgs e) {
            radTextBox1.Clear();
            radTextBox1.Select();
            RefreshBtnClear();
        }

        private void RefreshBtnClear() {
            if (string.IsNullOrEmpty(radTextBox1.Text)) {
                btnClear.Visible = false;
                return;
            }
            btnClear.Location = new Point(
                radTextBox1.Left + radTextBox1.Width - 51, 1);
            btnClear.Visible = true;
        }

        private void RadTextBox1OnTextChanged(object sender, EventArgs e) {
            RefreshBtnClear();
        }

        //private void RadTextBox1OnLostFocus(object sender, EventArgs e) {
        //    btnClear.Visible = false;
        //}

        private void RadTextBox1OnGotFocus(object sender, EventArgs e) {
            RefreshBtnClear();
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
                if (value) {
                    radTextBox1.PasswordChar =  '*';
                }
            }
            get => radTextBox1.PasswordChar == '*';
        }
    }
}
