using System;
using System.Windows.Forms;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Forms
{
    public partial class FrmControl : Telerik.WinControls.UI.RadForm {
        private DataGridViewCell espfService;
        private DataGridViewCell espfStateMayor;
        private DataGridViewCell espfStateMinor;
        private DataGridViewCell espfIp;
        private DataGridViewCell espfPort;
        private DataGridViewCell espfPrinter;
        private DataGridViewCell espfCommMethod;


        public FrmControl()
        {
            InitializeComponent();

            espfService = AddRow("ESPF - Conexión al servicio");
            espfStateMayor = AddRow("ESPF - Estado de supervición mayor");
            espfStateMinor = AddRow("ESPF - Estado de supervición menor");
            espfIp = AddRow("ESPF - Dirección IP");
            espfPort = AddRow("ESPF - Puerto");
            espfPrinter = AddRow("ESPF - Nombre de impresora");
            espfCommMethod = AddRow("ESPF - Metodo de comunicación");

            this.Shown += OnShown;
        }

        private DataGridViewCell AddRow(string t) {
            var i = grid.Rows.Add(t, "");
            return grid.Rows[i].Cells[1];
        }

        private void OnShown(object sender, EventArgs e) {
            RefreshStatus();
        }

        private void RefreshStatus() {
            radWaitingBar1.StartWaiting();

            Status.Refresh();
            espfService.Value = Status.EspfServiceConn;
            espfStateMayor.Value = Status.EspfMayor;
            espfStateMinor.Value = Status.EspfMinor;
            espfIp.Value = Config.EspfIp;
            espfPort.Value = Config.EspfPort;
            espfPrinter.Value = Config.EspfPrinter;
            espfCommMethod.Value = Config.EspfCommMethod == 0 ? "NamedPipes" : "TCP";

            radWaitingBar1.StopWaiting();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.SetRoundBorders(e, 30);
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            RefreshStatus();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }
    }
}
