using System.Windows.Forms;
using ClientPoint.UI;
using Telerik.WinControls;

namespace ClientPoint.Utils {
    public static class MsgBox {

        private static void PrepareAndShow(string msg, Form owner = null, MsgType type = MsgType.Info) {
            var frm = new FrmMessage(msg, type);
            frm.ShowDialog(owner);
        }

        public static void Show(string msg, Form owner = null) {
            // Safe thread
            if (owner != null && owner.InvokeRequired) {
                owner.Invoke((MethodInvoker)delegate {
                    Show(msg, owner);
                });
                return;
            }
            PrepareAndShow(msg, owner);
        }

        public static void Error(string msg, Form owner = null) {
            // Safe thread
            if (owner != null && owner.InvokeRequired) {
                owner.Invoke((MethodInvoker) delegate {
                    Error(msg, owner);
                });
                return;
            }
            PrepareAndShow(msg, owner, MsgType.Error);
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
