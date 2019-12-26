using System.Windows.Forms;
using ClientPoint.UI.Forms;
using ClientPoint.Utils;

namespace ClientPoint.UI.Views {
    public partial class BaseView : UserControl {
        public BaseView() {
            InitializeComponent();
            headerPanel.Font = FontUtils.Roboto(18);
        }

        public Window GetParentWindow() {
            var f = this.ParentForm as FrmBase;
            return f?.Window ?? Window.Main;
        }

        public virtual void AfterHide() { }
        public virtual void AfterShow() { }

        public virtual void BeforeHide() { }

        public virtual void BeforeShow() {
            headerPanel.lblError.Visible = Status.HasErrors && !Config.DebugMode;
        }
    }
}
