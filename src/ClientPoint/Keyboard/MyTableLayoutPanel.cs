using System.Windows.Forms;

namespace ClientPoint.Ke {
    public class MyBufferedTableLayoutPanel : TableLayoutPanel
    {
        public MyBufferedTableLayoutPanel() : base()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
