using System.Windows.Forms;

namespace ClientPoint.UI.Views {
    public partial class BaseView : UserControl {
        public BaseView() {
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
