using System.Windows.Forms;
using Telerik.WinControls;

namespace ClientPoint.Utils {
    public static class MsgBox {

        public static void Show(Form owner, string msg, string title = "") {
            RadMessageBox.Show(
                owner,
                msg,
                title,
                MessageBoxButtons.OK,
                RadMessageIcon.Info);
        }

        public static void Error(Form owner, string msg) {
            RadMessageBox.Show(
                owner,
                msg,
                "Error",
                MessageBoxButtons.OK,
                RadMessageIcon.Error);
        }

        public static bool Confirm(Form owner, string msg, string title = "") {
            return RadMessageBox.Show(
                owner,
                msg,
                title,
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question) == DialogResult.Yes;
        }
    }
}
