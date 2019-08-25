using System.Drawing;
using System.Drawing.Drawing2D;
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

        public static void SetRoundBorders(this Control control, PaintEventArgs e, int radius) {
            RectangleF Rect = new RectangleF(0, 0, control.Width, control.Height);
            using (GraphicsPath GraphPath = GraphUtils.GetRoundPath(Rect, radius)) {
                control.Region = new Region(GraphPath);
                using (Pen pen = new Pen(Color.CadetBlue, 1.75f)) {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, GraphPath);
                }
            }
        }
    }
}
