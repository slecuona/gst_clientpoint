using System;
using System.Windows.Forms;

namespace ClientPoint.UI {
    public partial class FrmBase : Telerik.WinControls.UI.RadForm {
        protected FrmBase() {
            InitializeComponent();

            this.Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e) {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
