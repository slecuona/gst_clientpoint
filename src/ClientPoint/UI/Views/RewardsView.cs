using System;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.UI.Controls;
using ClientPoint.Utils;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Views
{
    public partial class RewardsView : BaseView {
        private RewardsManager _rewards;
        private int _lastBtnCatergoryY = 0;

        public RewardsView() {
            InitializeComponent();
            headerPanel1.Title = "                                                    Premios";
            btnNext.SetRight();
            btnNext.Click += BtnNextOnClick;
            btnPrev.Click += BtnPrevOnClick;
            btnBack.Click += BtnBackOnClick;
        }

        private void BtnBackOnClick(object sender, EventArgs e) {
            UIManager.ShowView(View.ClientMenu);
        }

        private void BtnPrevOnClick(object sender, EventArgs e) {
            if (_rewards == null)
                return;
            _rewards?.Prev();
            FillRewards();
        }

        private void BtnNextOnClick(object sender, EventArgs e) {
            if (_rewards == null)
                return;
            _rewards?.Next();
            FillRewards();
        }

        public override void BeforeShow() {
            LoadRewards();
        }

        private void LoadRewards() {
            _lastBtnCatergoryY = btnAll.Top;
            var res = ApiService.GetRewards("0010100000123");
            _rewards = new RewardsManager(res);
            foreach (var c in _rewards.Categories) {
                AddCategoryBtn(c.Key, c.Value);
            }
            FillRewards();
        }

        private void FillRewards() {
            container.Controls.Clear();
            var rewards = _rewards.CurrentRewards;
            var left = true;
            var top = 0;
            const int width = 515;
            const int height = 139;
            foreach (var r in rewards) {
                var pnl = new RadPanel();
                pnl.Size = new Size(width, height);
                pnl.Location = new Point(left ? 0 : (width + 10), top);
                pnl.Anchor = AnchorStyles.Top;
                pnl.BackColor = Color.Transparent;
                // Saco el borde
                ((BorderPrimitive)(pnl.GetChildAt(0).GetChildAt(1))).Width = 0F;
                if (!left)
                    top += height;
                left = !left;
                LoadSingleReward(r, ref pnl);
                container.Controls.Add(pnl);
            }

            RefreshPageInfo();
        }

        private void RefreshPageInfo() {
            btnPrev.Enabled = !_rewards.FirstPage;
            btnNext.Enabled = _rewards.CurrentPage < _rewards.TotalPages;
            lblPages.Text = $"{_rewards.CurrentPage} / {_rewards.TotalPages}";
        }

        private void LoadSingleReward(Reward r, ref RadPanel pnl) {
            var lblImg = new RadLabel();
            lblImg.Size = new Size(100, 100);
            lblImg.Location = new Point(20, 20);

            try {
                if (GraphUtils.TryGetImageFromBase64(r.ImageData, out Image img))
                    lblImg.Image = img;
                else
                    lblImg.Image = Properties.Resources.gift_thumb;
            } catch (Exception e) {
                Logger.Exception(e);
            }
            pnl.Controls.Add(lblImg);

            var lblName = new RadLabel();
            lblName.Text = r.Name;
            lblName.Size = new Size(380, 20);
            lblName.Font = FontUtils.Roboto(16);
            lblName.Location = new Point(140, 30);
            lblName.ForeColor = Color.White;
            pnl.Controls.Add(lblName);

            var lblPoints = new RadLabel();
            lblPoints.Text = $"Puntos: {r.PointsRequired}";
            lblPoints.Size = new Size(380, 20);
            lblPoints.Font = FontUtils.Roboto(12);
            lblPoints.Location = new Point(142, 60);
            lblPoints.ForeColor = Color.White;
            pnl.Controls.Add(lblPoints);
        }

        private void AddCategoryBtn(int id, string name) {
            var btn = new CustomButtonWhite();
            btn.Name = $"btnCategory{id}";
            btn.Text = name.ToUpper();
            btn.Tag = id;
            btn.Location = new Point(31, _lastBtnCatergoryY + 100);
            this.panelContainer.Controls.Add(btn);
            _lastBtnCatergoryY = btn.Top;
        }


        public override void AfterHide() {
            _rewards = null;
            container.Controls.Clear();
        }
    }
}
