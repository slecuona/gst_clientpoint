using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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
        private List<CustomButtonWhite> _btns;

        public RewardsView() {
            InitializeComponent();
            headerPanel1.Title = "                                                    Premios";
            btnNext.SetRight();
            btnNext.Click += BtnNextOnClick;
            btnPrev.Click += BtnPrevOnClick;
            btnBack.Click += BtnBackOnClick;
            btnAll.Checked = true;
            btnAll.Tag = 0;
            btnAll.Click += BtnCategoryOnClick;
            _btns = new List<CustomButtonWhite>();
        }

        private void BtnCategoryOnClick(object sender, EventArgs e) {
            var btn = sender as CustomButtonWhite;
            if (btn == null)
                return;
            if (!(btn.Tag is int id))
                return;
            foreach (var b in _btns) {
                b.Checked = false;
            }
            btn.Checked = true;
            _rewards.Filter(id);
            FillRewardsAsync();
        }

        private void BtnBackOnClick(object sender, EventArgs e) {
            UIManager.ShowView(View.ClientMenu);
        }

        private void BtnPrevOnClick(object sender, EventArgs e) {
            if (_rewards == null)
                return;
            _rewards?.Prev();
            FillRewardsAsync();
        }

        private void BtnNextOnClick(object sender, EventArgs e) {
            if (_rewards == null)
                return;
            _rewards?.Next();
            FillRewardsAsync();
        }

        public override void BeforeShow() {
            _btns.Clear();
            _rewards = null;
            _lastBtnCatergoryY = 0;
            container.Controls.Clear();
        }

        private void LoadRewardsAsync() {
            headerPanel1.Waiting = true;
            var t = new Thread(LoadRewards);
            t.Start();
        }

        private void LoadRewards() {
            _lastBtnCatergoryY = btnAll.Top;
            var res = ApiService.GetRewards("0010100000123");
            _rewards = new RewardsManager(res);
            this.InvokeIfRequired(() => {
                _btns.Add(btnAll);
                categoryPanel.Controls.Add(btnAll);
                foreach (var c in _rewards.Categories) {
                    AddCategoryBtn(c.Key, c.Value);
                }
            });
            btnAll.Checked = true;
            FillRewards();
        }

        private void FillRewards() {
            var rewards = _rewards.CurrentRewards;
            var panels = new List<RadPanel>();
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
                panels.Add(pnl);
            }

            this.InvokeIfRequired(() => {
                container.Controls.AddRange(controls: panels?.ToArray());
                RefreshPageInfo();
                headerPanel1.Waiting = false;
            });
        }

        private void FillRewardsAsync() {
            headerPanel1.Waiting = true;
            container.Controls.Clear();
            var t = new Thread(FillRewards);
            t.Start();
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
            lblImg.ImageScalingSize = new Size(100, 100);

            try {
                // Saco los primero 36 caracteres
                var base64 = r.ImageData.Substring(36, r.ImageData.Length - 36);
                if (GraphUtils.TryGetImageFromBase64(base64, out Image img))
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
            btn.Text = name.ToUpper().Replace(' ', '\n');
            btn.Tag = id;
            btn.Location = new Point(0, _lastBtnCatergoryY + 100);
            btn.Click += this.BtnCategoryOnClick;
            this.categoryPanel.Controls.Add(btn);
            _lastBtnCatergoryY = btn.Top;
            _btns.Add(btn);
        }


        public override void AfterHide() {
            _rewards = null;
            _btns.Clear();
            container.Controls.Clear();
            categoryPanel.Controls.Clear();
        }

        public override void AfterShow() {
            LoadRewardsAsync();
        }
    }
}
