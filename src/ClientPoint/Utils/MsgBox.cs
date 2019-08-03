using System.Windows.Forms;
using Telerik.WinControls;

namespace ClientPoint.Utils {
    public static class MsgBox {

        public static void Show(Form owner, string msg, string title = "") {
            // Safe thread
            if (owner != null && owner.InvokeRequired) {
                owner.Invoke((MethodInvoker)delegate {
                    Show(owner, msg, title);
                });
                return;
            }
            RadMessageBox.Show(
                owner,
                msg,
                title,
                MessageBoxButtons.OK,
                RadMessageIcon.Info);
        }

        public static void Error(Form owner, string msg) {
            // Safe thread
            if (owner != null && owner.InvokeRequired) {
                owner.Invoke((MethodInvoker) delegate {
                    Error(owner, msg);
                });
                return;
            }
            RadMessageBox.Show(
                owner,
                msg,
                "Error",
                MessageBoxButtons.OK,
                RadMessageIcon.Error);
        }

        public static bool Confirm(Form owner, string msg, string title = "") {
            // Safe thread
            if (owner != null && owner.InvokeRequired) {
                var res = false;
                owner.Invoke((MethodInvoker)delegate {
                    res = Confirm(owner, msg, title);
                });
                return res;
            }
            return RadMessageBox.Show(
                owner,
                msg,
                title,
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question) == DialogResult.Yes;
        }
    }
}
