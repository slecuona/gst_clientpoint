using System.Windows.Forms;
using ClientPoint.UI;
using ClientPoint.UI.Forms;
using Telerik.WinControls;

namespace ClientPoint.Utils {
    public static class MsgBox {

        private static void PrepareAndShow(string msg, MsgType type = MsgType.Info) {
            UIManager.SafeExecOnActiveForm((owner) => {
                var frm = new FrmMessage(msg, type);
                frm.ShowDialog(owner);
            });
        }

        public static void Show(string msg) {
            // Safe thread
            PrepareAndShow(msg);
        }

        public static void Error(string msg) {
            PrepareAndShow(msg, MsgType.Error);
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
