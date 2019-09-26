using System;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Forms {
    public partial class FrmRewardModal : Telerik.WinControls.UI.RadForm {
        private int _count = 1;
        private int _max = 1;
        private int _pointsPerUnit = 0;
        private int _totalPoints = 0;
        private int _pointsReq = 0;

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

            lblCount.Font = FontUtils.Roboto(18, FontStyle.Bold);

            btnPlus.Click += BtnPlusOnClick;
            btnMinus.Click += BtnMinusOnClick;

            lblImage.Parent = picBox1;
            lblImage.Location = new Point(15, 15);
            lblImage.Size = new Size(picBox1.Width - 30, picBox1.Height - 30);
        }

        private void BtnMinusOnClick(object sender, EventArgs e) {
            if (_count == 1)
                return;
            _count--;
            Recalc();
        }

        private void BtnPlusOnClick(object sender, EventArgs e) {
            if (_count == _max)
                return;
            _count++;
            Recalc();
        }

        public void LoadReward(Reward r) {
            _totalPoints = ClientSession.CurrClient.Points;
            _max = r.Stock;
            _count = 1;
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
        }

        private void Recalc() {
            lblCount.Text = _count.ToString();
            _pointsReq = _pointsPerUnit * _count;
            lblPointsReqVal.Text = $"{_pointsReq}";
            lblPointsAfterVal.Text = (_totalPoints - _pointsReq).ToString();
        }

        private void customButton1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
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
    }
}
