using System;
using System.Diagnostics;
using System.Windows.Forms;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Forms
{
    public partial class FrmControl : Telerik.WinControls.UI.RadForm {
        private DataGridViewCell debugMode;

        private DataGridViewCell espfService;
        private DataGridViewCell espfStateMayor;
        private DataGridViewCell espfStateMinor;
        private DataGridViewCell espfStateBinary;
        private DataGridViewCell espfIp;
        private DataGridViewCell espfPort;
        private DataGridViewCell espfPrinter;
        private DataGridViewCell espfCommMethod;

        private DataGridViewCell apiState;
        private DataGridViewCell apiUrl;

        private DataGridViewCell cardNameX;
        private DataGridViewCell cardNameY;
        private DataGridViewCell cardNameSize;

        private DataGridViewCell idleSeconds;
        private DataGridViewCell idleMessageSeconds;

        
        public FrmControl()
        {
            InitializeComponent();

            debugMode = AddRow("APP - Modo debug");

            espfService = AddRow("ESPF - Estado de conexión al servicio");
            espfStateMayor = AddRow("ESPF - Estado de supervición mayor");
            espfStateMinor = AddRow("ESPF - Estado de supervición menor");
            espfStateBinary = AddRow("ESPF - Estado binario");
            espfIp = AddRow("ESPF - Dirección IP");
            espfPort = AddRow("ESPF - Puerto");
            espfPrinter = AddRow("ESPF - Nombre de impresora");
            espfCommMethod = AddRow("ESPF - Metodo de comunicación");

            apiState = AddRow("API - Estado de conexión");
            apiUrl = AddRow("API - Dirección URL");

            cardNameX = AddRow("Tarjeta - Coordenada X");
            cardNameY = AddRow("Tarjeta - Coordenada Y");
            cardNameSize = AddRow("Tarjeta - Tamaño");

            idleSeconds = AddRow("Segundos de inactividad");
            idleMessageSeconds = AddRow("Segundos de espera en mensaje de inactividad");

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

            debugMode.Value = Config.DebugMode;

            espfService.Value = Status.EspfServiceConn;
            espfStateMayor.Value = Status.EspfMayor;
            espfStateMinor.Value = Status.EspfMinor;
            espfStateBinary.Value = Status.EspfBinary;
            espfIp.Value = Config.EspfIp;
            espfPort.Value = Config.EspfPort;
            espfPrinter.Value = Config.EspfPrinter;
            espfCommMethod.Value = Config.EspfCommMethod == 0 ? "NamedPipes" : "TCP";

            apiState.Value = Status.ApiState;
            apiUrl.Value = Config.ApiUrl;

            cardNameX.Value = Config.CardNameX;
            cardNameY.Value = Config.CardNameY;
            cardNameSize.Value = Config.CardNameSize;

            idleSeconds.Value = Config.IdleSeconds;
            idleMessageSeconds.Value = Config.IdleMessageSeconds;

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

        private void btnLog_Click(object sender, EventArgs e) {
            Process.Start(Logger.FullPath);
        }
    }
}
