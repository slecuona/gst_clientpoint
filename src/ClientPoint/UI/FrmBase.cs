using System;
using System.Windows.Forms;

namespace ClientPoint.UI {
    public partial class FrmBase : Telerik.WinControls.UI.RadForm {
        protected FrmBase() {
            InitializeComponent();

            this.Load += OnLoad;

            // Esto busca reducir el flickering entre ventanas
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint |
                          System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                          System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        private void OnLoad(object sender, EventArgs e) {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
