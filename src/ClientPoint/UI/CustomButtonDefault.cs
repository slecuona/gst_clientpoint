using System.Windows.Forms;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class CustomButtonDefault : RadButton {
        public CustomButtonDefault() {
            InitializeComponent();
        }
        
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.SetRoundBorders(e, 20);
        }
    }
}
