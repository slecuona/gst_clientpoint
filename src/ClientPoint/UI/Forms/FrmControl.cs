using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using ClientPoint.Espf;
using ClientPoint.Session;
using ClientPoint.Utils;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Timer = System.Threading.Timer;

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

        private void Loading(bool enabled) {
            radWaitingBar1.Visible = enabled;
            if(enabled)
                radWaitingBar1.StartWaiting();
            else
                radWaitingBar1.StopWaiting();
        }

        private Thread _refreshThread;
        private void RefreshStatus() {
            Loading(true);

            _refreshThread?.Abort();

            _refreshThread = new Thread(() => {
                Status.Refresh();
                this.InvokeIfRequired(() => {
                    RefreshGrid();
                    Loading(false);
                });
            });
            _refreshThread.Start();
        }

        private void RefreshGrid() {
            debugMode.Value = Config.DebugMode;

            espfService.Value = Status.EspfServiceConn;
            espfStateMayor.Value = Status.EspfMayor;
            espfStateMinor.Value = Status.EspfMinor;
            espfStateBinary.Value = Status.EspfBinary;
            espfIp.Value = Config.EspfIp;
            espfPort.Value = Config.EspfPort;
            espfPrinter.Value = Config.EspfPrinter;

            var commMtd = "No definido";
            switch (Config.EspfCommMethod) {
                case 0: commMtd = "TCP"; break;
                case 1: commMtd = "TCP Alternative"; break;
                case 2: commMtd = "NamedPipedStream"; break;
            }
            espfCommMethod.Value = commMtd;

            apiState.Value = Status.ApiState;
            apiUrl.Value = Config.ApiUrl;

            cardNameX.Value = Config.CardNameX;
            cardNameY.Value = Config.CardNameY;
            cardNameSize.Value = Config.CardNameSize;

            idleSeconds.Value = Config.IdleSeconds;
            idleMessageSeconds.Value = Config.IdleMessageSeconds;
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

        //private Timer _printCardTimer;

        private void btnPrintCard_Click(object sender, EventArgs e) {
            lblStatus.Text = "Imprimiendo tarjeta de prueba...";
            Loading(true);
            btnPrintCard.Enabled = false;
            btnRefresh.Enabled = false;
            //_printCardTimer = new Timer(PrintCardStatusCheck, null, 1000, 2000);
            //Op.TestPrintAsync(OnPrintCardFinish);

            try {
                var pj = new PrintJob(new Client() {
                    Name = "TARJETA",
                    LastName = "DE PRUEBA",
                    IdCard = Config.TEST_CARD
                });
                pj.OnFinish = OnPrintCardFinish;
                pj.OnStateChanged = OnStateChanged;
                pj.StartAsync();
            } catch (Exception ex) {
                Logger.Exception(ex);
            }
        }

        private void OnStateChanged(PrintState state) {
            this.InvokeIfRequired(() => {
                if (state == PrintState.CardEjected)
                    lblStatus.Text = "Retire la tarjeta para finalizar la tarea.";
                espfStateMayor.Value = Status.EspfMayor;
                espfStateMinor.Value = Status.EspfMinor;
                espfStateBinary.Value = Status.EspfBinary;
            });
        }

        //private void PrintCardStatusCheck(object state) {
        //    Status.EspfSupDeviceState();
        //    Debug.WriteLine(
        //        $"EspfStatus: {Status.EspfMayor}|{Status.EspfMinor}");
        //    this.InvokeIfRequired(() => {
        //        if (Status.EspfMinor == EspfMinorState.DEF_CARD_ON_EJECT)
        //            lblStatus.Text = "Retire la tarjeta para finalizar la tarea.";
        //        espfStateMayor.Value = Status.EspfMayor;
        //        espfStateMinor.Value = Status.EspfMinor;
        //        espfStateBinary.Value = Status.EspfBinary;
        //    });
        //}

        private void OnPrintCardFinish(bool success) {
            //_printCardTimer?.Dispose();
            this.InvokeIfRequired(() => {
                Loading(false);
                lblStatus.Text = "";
                btnPrintCard.Enabled = true;
                btnRefresh.Enabled = true;
                RadMessageBox.Show(this,
                    success ? "Impresion de tarjeta de prueba finalizada" : 
                        "Error al imprimir tarjeta de prueba");
            });
        }

        private void btnVoucher_Click(object sender, EventArgs e) {
            lblStatus.Text = "Imprimiendo voucher";
            VoucherPrinter.Print(Config.TEST_VOUCHER);
            lblStatus.Text = "Voucher listo!";
        }

        private void btnTicket_Click(object sender, EventArgs e) {
            lblStatus.Text = "Imprimiendo ticket...";
            TicketPrinter.Print(Config.TEST_TICKET);
            lblStatus.Text = "Ticket listo!";
        }
    }
}
