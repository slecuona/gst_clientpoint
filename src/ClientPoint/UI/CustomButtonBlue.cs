using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class CustomButtonBlue : RadButton {
        public CustomButtonBlue() {
            InitializeComponent();
            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            this.Image = Properties.Resources.btn_1;
        }

        private void OnMouseDown(object sender, MouseEventArgs e) {
            this.Image = Properties.Resources.btn_1_press;
        }
    }
}
