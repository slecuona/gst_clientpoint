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
        private DataGridViewCell errors;
        private DataGridViewCell points;
        
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
        private DataGridViewCell ticketPort;
        private DataGridViewCell ticketBaud;

        private DataGridViewCell voucherState;
        private DataGridViewCell voucherPort;
        private DataGridViewCell voucherBaud;

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

            errors = AddRow("APP - Errores / Excepciones");
            points = AddRow("APP - Sistema de puntos habilitado");

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
            ticketPort = AddRow("Impresora Ticket - Puerto");
            ticketBaud = AddRow("Impresora Ticket - Baud rate");

            voucherState = AddRow("Impresora Voucher - Estado");
            voucherPort = AddRow("Impresora Voucher - Puerto");
            voucherBaud = AddRow("Impresora Voucher - Baud rate");

            apiState = AddRow("API - Estado de conexión");
            apiUrl = AddRow("API - Dirección URL");

            cardNameX = AddRow("Tarjeta - Coordenada X");
            cardNameY = AddRow("Tarjeta - Coordenada Y");
            cardNameSize = AddRow("Tarjeta - Tamaño");

            idleSeconds = AddRow("Segundos de inactividad");
            idleMessageSeconds = AddRow("Segundos de espera en mensaje de inactividad");

            this.Shown += OnShown;
            this.Closed += OnClosed;
        }

        private void OnClosed(object sender, EventArgs e) {
            UIManager.HideOverlay();
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

            btnLog.Enabled = !enabled;
            btnTicket.Enabled = !enabled;
            btnVoucher.Enabled = !enabled;
            btnPrintCard.Enabled = !enabled;
            btnRefresh.Enabled = !enabled;
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
            if (cell.Value == null) {
                if (ok == null) {
                    cell.Style.BackColor = ColorOk;
                    return;
                }
                if (warn == null) {
                    cell.Style.BackColor = ColorWarning;
                    return;
                }
                cell.Style.BackColor = ColorError;
                return;
            }

            if (warn != null && cell.Value.ToString().Contains(warn.ToString())) {
                cell.Style.BackColor = ColorWarning;
                return;
            }

            if (ok != null && cell.Value.ToString().Contains(ok.ToString())) {
                cell.Style.BackColor = ColorOk;
                return;
            }
            
            cell.Style.BackColor = ColorError;
        }
        
        private void RefreshGrid() {
            debugMode.Value = Config.DebugMode;
            var errC = Logger.ExceptionCount;
            errors.Value = errC;
            errors.Style.BackColor = errC > 0 ? ColorWarning : ColorOk;

            points.Value = Config.PointsEnabled;

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

            ticketState.Value = string.Join("|", Status.TicketPrinter);
            SetStatusColor(ticketState,
                TicketPrinterState.OK,
                TicketPrinterState.ALMOST_EMPTY);
            ticketStr.Value = Status.TicketPrinterString;
            ticketPort.Value = Config.TicketPrinterPort;
            ticketBaud.Value = Config.TicketPrinterBaud;
            
            voucherState.Value = string.Join("|", Status.VoucherPrinter);
            SetStatusColor(voucherState,
                VoucherPrinterState.OK,
                VoucherPrinterState.ALMOST_EMPTY);
            voucherPort.Value = Config.VoucherPrinterPort;
            voucherBaud.Value = Config.VoucherPrinterBaud;

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
            Environment.Exit(0);
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
            });
        }

        private void btnVoucher_Click(object sender, EventArgs e) {
            lblStatus.Text = "Imprimiendo voucher de prueba...";
            Loading(true);
            var p = new VoucherPrinter();
            p.OnFinish += OnPrintVoucherFinish;
            p.PrintAsync(Config.TEST_VOUCHER);
        }

        private void OnPrintVoucherFinish(bool success, string err) {
            this.InvokeIfRequired(() => {
                Loading(false);
                lblStatus.Text = success ? 
                    "Impresion de voucher de prueba finalizada correctamente." :
                    $"Error: {err}";
            });
        }

        private void btnTicket_Click(object sender, EventArgs e) {
            lblStatus.Text = "Imprimiendo ticket de prueba...";
            Loading(true);
            var p = new TicketPrinter();
            p.OnFinish += OnPrintTicketFinish;
            p.PrintAsync(Config.TEST_TICKET);
        }

        private void OnPrintTicketFinish(bool success, string err) {
            this.InvokeIfRequired(() => {
                Loading(false);
                lblStatus.Text = success ?
                    "Impresion de ticket de prueba finalizada correctamente." :
                    $"Error: {err}";
            });
        }
    }
}
