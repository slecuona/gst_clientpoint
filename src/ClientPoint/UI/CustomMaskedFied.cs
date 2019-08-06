using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class CustomMaskedField : UserControl {
        public CustomMaskedField() {
            InitializeComponent();
        }

        public Control Control => radTextBox1;

        public string Label {
            get => radLabel1.Text;
            set => radLabel1.Text = value;
        }

        public string Value {
            get => radTextBox1.Value?.ToString();
            set => radTextBox1.Value = value;
        }

        public bool Uppercase {
            set {
                if (value)
                    radTextBox1.CharacterCasing = CharacterCasing.Upper;
                else
                    radTextBox1.CharacterCasing = CharacterCasing.Normal;
            }
        }

        public CustomMaskType CustomMaskType {
            set {
                if (value == CustomMaskType.Document) {
                    radTextBox1.MaskType = MaskType.Standard;
                    radTextBox1.Mask = "99999999";
                    return;
                }
                if (value == CustomMaskType.Email) {
                    radTextBox1.MaskType = MaskType.EMail;
                    return;
                }
                if (value == CustomMaskType.ConfirmCode) {
                    Uppercase = true;
                    radTextBox1.MaskType = MaskType.Standard;
                    radTextBox1.Mask = "AAAA";
                    radTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    radTextBox1.Click += SelectText;
                    return;
                }
            }
            get => CustomMaskType.None;
        }

        private void SelectText(object sender, EventArgs e) {
            radTextBox1.SelectionStart = 0;
            radTextBox1.SelectionLength = radTextBox1.Text.Length;
        }
    }

    public enum CustomMaskType {
        None = 0,
        Document = 1,
        Email = 2,
        ConfirmCode = 3
    }
}
