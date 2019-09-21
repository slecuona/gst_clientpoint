using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
    public class PicBox : PictureBox {
        public PicBox() : base() {
            //this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.SetRoundBorders(e, 10);
        }
    }
}
