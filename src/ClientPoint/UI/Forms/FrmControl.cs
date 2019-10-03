using System;
using System.Windows.Forms;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Forms
{
    public partial class FrmControl : Telerik.WinControls.UI.RadForm
    {
        public FrmControl()
        {
            InitializeComponent();
            
            grid.Rows.Add("ESPF - Conexión al servicio", "");
            grid.Rows.Add("ESPF - Estado de supervición mayor", "");
            grid.Rows.Add("ESPF - Estado de supervición menor", "");

            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e) {
            RefreshStatus();
        }

        private void RefreshStatus() {
            radWaitingBar1.StartWaiting();
            
            

            radWaitingBar1.StopWaiting();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.SetRoundBorders(e, 30);
        }

        private void radButton2_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void radButton1_Click(object sender, EventArgs e) {
            RefreshStatus();
        }
    }
}
