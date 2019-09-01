using System.Windows.Forms;

namespace ClientPoint.UI.Panels {
    public partial class PanelBase : UserControl {
        public PanelBase() {
            InitializeComponent();
        }

        public Window GetParentWindow() {
            var f = this.ParentForm as FrmBase;
            return f?.Window ?? Window.Main;
        }

        public virtual void AfterHide() { }
        public virtual void AfterShow() { }

        public virtual void BeforeHide() { }
        public virtual void BeforeShow() { }
    }
}
