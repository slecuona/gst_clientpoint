using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using ClientPoint.Api;
using ClientPoint.Session;
using ClientPoint.UI.Controls;
using ClientPoint.Utils;
using static ClientPoint.Utils.ExUtils;

namespace ClientPoint.UI.Views
{
    public partial class RewardsView : BaseView {
        private RewardsManager _rewards;
        private int _lastBtnCatergoryY = 0;
        private List<CustomButtonWhite> _btns;

        public RewardsView() {
            InitializeComponent();
            headerPanel.Title = "                                            Premios";
            headerPanel.Label.Font = FontUtils.Roboto(19);
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
            base.BeforeShow();
        }

        private void LoadRewardsAsync() {
            headerPanel.Waiting = true;
            var t = new Thread(LoadRewards);
            t.Start();
        }

        private void LoadRewards() {
            try {
                _lastBtnCatergoryY = btnAll.Top;
                var cl = ClientSession.CurrClient;
                DieIf(cl == null, "No se pudo recuperar el cliente.");

                var res = ApiService.GetRewards(cl.IdCard);
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
            catch (Exception e) {
                Logger.Exception(e);
                MsgBox.Error("Error al mostrar premios.");
                UIManager.ShowWindow(Window.Ads);
            }
        }

        private void FillRewards() {
            try {
                var rewards = _rewards.CurrentRewards;
                var panels = new List<RewardPanel>();
                var left = true;
                var top = 0;
                foreach (var r in rewards) {
                    var pnl = new RewardPanel(r);
                    pnl.Location = new Point(left ? 0 : (pnl.Width + 10), top);
                    if (!left)
                        top += pnl.Height;
                    left = !left;
                    panels.Add(pnl);
                }

                this.InvokeIfRequired(() => {
                    container.Controls.AddRange(controls: panels?.ToArray());
                    RefreshPageInfo();
                    headerPanel.Waiting = false;
                });
            }
            catch (Exception e) {
                Logger.Exception(e);
                MsgBox.Error(
                    "Hubo un error al obtener los premios disponibles." + 
                    Environment.NewLine + 
                    "Disculpe las molestias.");
            }
        }
        
        private void FillRewardsAsync() {
            headerPanel.Waiting = true;
            container.Controls.Clear();
            var t = new Thread(FillRewards);
            t.Start();
        }

        private void RefreshPageInfo() {
            btnPrev.Enabled = !_rewards.FirstPage;
            btnNext.Enabled = _rewards.CurrentPage < _rewards.TotalPages;
            lblPages.Text = $"{_rewards.CurrentPage} / {_rewards.TotalPages}";
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
