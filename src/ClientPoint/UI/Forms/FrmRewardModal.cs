using System;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Keyboard.UserInteraction;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Forms {
    public partial class FrmRewardModal : Telerik.WinControls.UI.RadForm {
        private int _quantity = 1;
        private int _max = 1;
        private int _pointsPerUnit = 0;
        private int _totalPoints = 0;
        private int _pointsReq = 0;
        private Reward _reward;

        public FrmRewardModal() {
            InitializeComponent();
            Shown += OnShown;
            lblTitle.Text = "NOMBRE DEL PREMIO";
            btnPlus.Plus = true;

            lblTitle.Font = FontUtils.Roboto(17, FontStyle.Bold);
            btnConfirm.Font = FontUtils.Roboto(16, FontStyle.Bold);
            btnCancel.Font = FontUtils.Roboto(16, FontStyle.Bold);
            lblCategory.Font = FontUtils.Roboto(15, FontStyle.Bold);

            lblPointsCurr.Font = FontUtils.Roboto(14, FontStyle.Bold);
            lblPointsCurrVal.Font = FontUtils.Roboto(14, FontStyle.Bold);
            lblPointsReq.Font = FontUtils.Roboto(14, FontStyle.Bold);
            lblPointsReqVal.Font = FontUtils.Roboto(14, FontStyle.Bold);
            lblPointsAfter.Font = FontUtils.Roboto(14, FontStyle.Bold);
            lblPointsAfterVal.Font = FontUtils.Roboto(14, FontStyle.Bold);

            lblQuantity.Font = FontUtils.Roboto(18, FontStyle.Bold);

            btnPlus.Click += BtnPlusOnClick;
            btnMinus.Click += BtnMinusOnClick;

            lblImage.Parent = picBox1;
            lblImage.Location = new Point(15, 15);
            lblImage.Size = new Size(picBox1.Width - 30, picBox1.Height - 30);

            if (!PointsEnabled) {
                btnMinus.Left = 185;
                btnPlus.Left = 330;
                lblQuantity.Left = 218;
            }

            this.Closed += OnClosed;
        }

        private void OnClosed(object sender, EventArgs e) {
            UIManager.HideOverlay();
        }

        private void BtnMinusOnClick(object sender, EventArgs e) {
            if (_quantity == 1)
                return;
            _quantity--;
            Recalc();
        }

        private void BtnPlusOnClick(object sender, EventArgs e) {
            if (_quantity == _max)
                return;
            _quantity++;
            Recalc();
        }

        public void LoadReward(Reward r) {
            _reward = r;
            _totalPoints = ClientSession.CurrClient.Points;
            _max = r.Stock;
            _quantity = 1;
            _pointsPerUnit = r.PointsRequired;

            if (_pointsPerUnit > 0) {
                var maxByPoints = _totalPoints / _pointsPerUnit;
                if (maxByPoints < _max)
                    _max = maxByPoints;
            }

            lblTitle.Text = r.Name?.ToUpper();
            lblCategory.Text = r.CategoryName?.ToUpper();
            lblImage.BackgroundImage = r.GetImage();
            
            lblPointsCurrVal.Text = _totalPoints.ToString();
            Recalc();
            
            LoadCountPanel(!r.IsTicket);
        }

        private static bool PointsEnabled => Config.PointsEnabled;

        private void LoadCountPanel(bool visible) {
            lblPointsAfter.Visible = visible && PointsEnabled;
            lblPointsAfterVal.Visible = visible && PointsEnabled;
            lblPointsCurr.Visible = visible && PointsEnabled;
            lblPointsCurrVal.Visible = visible && PointsEnabled;
            lblPointsReq.Visible = visible && PointsEnabled;
            lblPointsReqVal.Visible = visible && PointsEnabled;
            lblQuantity.Visible = visible;
            btnMinus.Visible = visible;
            btnPlus.Visible = visible;
            btnCancel.Top = visible ? 485 : 400;
            btnConfirm.Top = visible ? 485 : 400;
            this.Height = visible ? 575 : 490;
        }

        private void Recalc() {
            lblQuantity.Text = _quantity.ToString();
            _pointsReq = _pointsPerUnit * _quantity;
            lblPointsReqVal.Text = $"{_pointsReq}";
            lblPointsAfterVal.Text = (_totalPoints - _pointsReq).ToString();
        }

        private void btnConfim_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
            Op.ExchangeRewardAsync(_reward, _quantity);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.SetRoundBorders(e, 10);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnShown(object sender, EventArgs e) {
            this.CenterToScreen();
        }

        protected override void WndProc(ref Message m) {
            if (NativeMethods.IsActiveMsg(m.Msg)) {
                IdleTimer.OnBusy();
            }
            base.WndProc(ref m);
        }
    }
}
