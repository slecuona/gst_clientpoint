using System.Windows.Forms;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public class CustomTextBox : RadTextBox {
        public CustomTextBox() : base() {
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.SetRoundBorders(e, 10);
        }
    }
}
