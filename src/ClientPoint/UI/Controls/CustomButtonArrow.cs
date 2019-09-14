using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
    public partial class CustomButtonArrow : RadButton {
        private bool _right = false;

        public CustomButtonArrow() {
            InitializeComponent();
            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            this.Image = _right ? 
                Properties.Resources.btn_right : Properties.Resources.btn_left;
        }

        private void OnMouseDown(object sender, MouseEventArgs e) {
            this.Image = _right ?
                Properties.Resources.btn_right_press : Properties.Resources.btn_left_press;
        }

        public void SetRight() {
            _right = true;
            this.Image = Properties.Resources.btn_right;
        }
    }
}
