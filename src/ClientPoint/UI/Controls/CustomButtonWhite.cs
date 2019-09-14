using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
    public partial class CustomButtonWhite : RadButton {
        public CustomButtonWhite() {
            InitializeComponent();
            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            this.Image = Properties.Resources.btn_white;
        }

        private void OnMouseDown(object sender, MouseEventArgs e) {
            this.Image = Properties.Resources.btn_white_press;
        }
    }
}
