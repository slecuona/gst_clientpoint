using System.Windows.Forms;

namespace ClientPoint.Utils {
    public static class Extensions {
        public static void InvokeIfRequired(this Control control, MethodInvoker action) {
            if (control.InvokeRequired) {
                control.Invoke(action);
            } else {
                action();
            }
        }
    }
}
