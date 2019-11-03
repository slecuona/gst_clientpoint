using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ClientPoint.Espf;
using ClientPoint.IO;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Forms {
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

        private DataGridViewCell ticketState;
        private DataGridViewCell ticketStr;

        private DataGridViewCell voucherState;
        private DataGridViewCell voucherLastFailed;

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

            ticketState = AddRow("Impresora Ticket - Estado");
            ticketStr = AddRow("Impresora Ticket - Estado (str)");

            voucherState = AddRow("Impresora Voucher - Estado");
            voucherLastFailed = AddRow("Impresora Voucher - Falló última");

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

        private Color ColorOk => Color.DarkSeaGreen;
        private Color ColorWarning => Color.Goldenrod;
        private Color ColorError => Color.LightPink;

        private void SetStatusColor(DataGridViewCell cell, object ok, object warn) {
            if (cell.Value?.ToString() == ok?.ToString()) {
                cell.Style.BackColor = ColorOk;
                return;
            }
            if (cell.Value?.ToString() == warn?.ToString()) {
                cell.Style.BackColor = ColorWarning;
                return;
            }
            cell.Style.BackColor = ColorError;
        }

        //private Color EspfStateMayorColor(EspfMayorState s) {
        //    if (s == EspfMayorState.READY)
        //        return ColorOk;
        //    if (s == EspfMayorState.WARNING)
        //        return ColorWarning;
        //    return ColorError;
        //}

        //private Color TicketPrinterStateColor(TicketPrinterState s) {
        //    if (s == TicketPrinterState.OK)
        //        return ColorOk;
        //    if (s == TicketPrinterState.ALMOSTEMPTY)
        //        return ColorWarning;
        //    return ColorError;
        //}

        private void RefreshGrid() {
            debugMode.Value = Config.DebugMode;

            espfService.Value = Status.EspfServiceConn;

            espfStateMayor.Value = Status.EspfMayor;
            SetStatusColor(espfStateMayor, 
                EspfMayorState.READY, 
                EspfMayorState.WARNING);

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

            ticketState.Value = Status.TicketPrinter;
            SetStatusColor(ticketState,
                TicketPrinterState.OK,
                TicketPrinterState.ALMOSTEMPTY);

            ticketStr.Value = Status.TicketPrinterString;

            voucherState.Value = Status.VoucherPrinter;
            SetStatusColor(voucherState,
                VoucherPrinterState.OK,
                VoucherPrinterState.BUSY);
            voucherLastFailed.Value = VoucherPrinterOld.LastFailed;

            apiState.Value = Status.ApiState;
            SetStatusColor(apiState, "OK", null);
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
        
        private void btnPrintCard_Click(object sender, EventArgs e) {
            lblStatus.Text = "Imprimiendo tarjeta de prueba...";
            Loading(true);
            btnPrintCard.Enabled = false;
            btnRefresh.Enabled = false;

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

        private void OnPrintCardFinish(bool success) {
            this.InvokeIfRequired(() => {
                Loading(false);
                lblStatus.Text = success ? "Impresion de tarjeta de prueba finalizada" :
                    "Error al imprimir tarjeta de prueba";
                btnPrintCard.Enabled = true;
                btnRefresh.Enabled = true;
            });
        }

        private void btnVoucher_Click(object sender, EventArgs e) {
            //lblStatus.Text = "Imprimiendo voucher";
            //if (VoucherPrinter.TryPrintRaw(Config.TEST_VOUCHER, out string err))
            //    lblStatus.Text = "Voucher listo!";
            //else
            //    lblStatus.Text = $"Error al imprimir voucher: {err}";

            //var p = new VoucherPrinterSerial();
            //if (p.TryPrint(Config.TEST_VOUCHER, out string err))
            //    lblStatus.Text = "Voucher listo!";
            //else
            //    lblStatus.Text = $"Error al imprimir voucher: {err}";

            var p = new VoucherPrinter();
            if (p.TryGetSerialStatus(out string st))
                lblStatus.Text = $"Estado: {st}";
            else
                lblStatus.Text = $"Err GetStatus";
        }

        private void btnTicket_Click(object sender, EventArgs e) {
            lblStatus.Text = "Imprimiendo ticket...";
            var p = new TicketPrinter();
            if (p.TryPrint(Config.TEST_TICKET, out string err)) {
                lblStatus.Text = "Ticket listo!";
            } else {
                lblStatus.Text = $"Error al imprimir ticket: {err}";
            }
        }
    }
}
