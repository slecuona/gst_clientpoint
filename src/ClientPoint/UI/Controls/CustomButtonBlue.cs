using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
    public partial class CustomButtonBlue : RadButton {
        private bool _small = false;

        public CustomButtonBlue() {
            InitializeComponent();
            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            this.Image = _small ? 
                Properties.Resources.btn_blue_small : Properties.Resources.btn_1;
        }

        private void OnMouseDown(object sender, MouseEventArgs e) {
            this.Image = _small ?
                Properties.Resources.btn_blue_small_press : Properties.Resources.btn_1_press;
        }

        public void SetSmall() {
            _small = true;
            this.Image = Properties.Resources.btn_blue_small;
            this.Size = new Size(234, 78);
        }
    }
}
