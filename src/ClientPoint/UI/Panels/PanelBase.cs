using System.Windows.Forms;

namespace ClientPoint.UI.Panels {
    public partial class PanelBase : UserControl {
        public PanelBase() {
            InitializeComponent();
        }

        public virtual void AfterHide() { }
        public virtual void AfterShow() { }

        public virtual void BeforeHide() { }
        public virtual void BeforeShow() { }
    }
}
