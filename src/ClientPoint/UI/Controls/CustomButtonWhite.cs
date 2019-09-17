using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
    public partial class CustomButtonWhite : RadButton {
        private bool _checked;

        public CustomButtonWhite() {
            InitializeComponent();
            //this.MouseDown += OnMouseDown;
            //this.MouseUp += OnMouseUp;
        }

        //private void OnMouseUp(object sender, MouseEventArgs e) {
        //    if (_checked)
        //        return;
        //    this.Image = Properties.Resources.btn_white_dark;
        //}

        //private void OnMouseDown(object sender, MouseEventArgs e) {
        //    if (_checked)
        //        return;
        //    this.Image = Properties.Resources.btn_white_press;
        //}

        public bool Checked {
            get => _checked;
            set {
                _checked = value;
                if (_checked) {
                    this.Image = Properties.Resources.btn_white;
                    ForeColor = Color.FromArgb(255, 169, 54, 54);
                }
                else {
                    this.Image = Properties.Resources.btn_white_dark;
                    ForeColor = Color.Black;
                }
            }
        }
    }
}
