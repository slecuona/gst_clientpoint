using System.Drawing;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public class CustomLabel : RadLabel {
        public CustomLabel() : base() {
            this.Font = FontUtils.Roboto(15);
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
        }

        public void SetFont(float size, bool bold = false) {
            this.Font = FontUtils.Roboto(size, 
                bold ? FontStyle.Bold : FontStyle.Regular);
        }
    }
}
