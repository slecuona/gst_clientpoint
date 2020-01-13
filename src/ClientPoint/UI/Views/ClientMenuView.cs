using System;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Views
{
    public partial class ClientMenuView : BaseView
    {
        public ClientMenuView()
        {
            InitializeComponent();
            
            btnPrices.Click += BtnPricesOnClick;

            lblName.Font = FontUtils.Roboto(20);
            lblPointsT.Font = FontUtils.Roboto(13);
            lblCardT.Font = FontUtils.Roboto(13);
            lblPoints.Font = FontUtils.Roboto(15);
            lblCard.Font = FontUtils.Roboto(14);

            if (!Config.PointsEnabled) {
                lblPointsT.Visible = false;
                lblPoints.Visible = false;
                lblCardT.Left = 635;
                lblCard.Left = 600;
            }

            pnlRewardPopup.OnCancel = OnCancelRewardPopup;
        }

        private void OnCancelRewardPopup() {
            LoadRewardPopup(null);
        }

        private void BtnPricesOnClick(object sender, EventArgs e) {
            UIManager.ShowView(View.Rewards);
        }
        
        private void btnBack_Click(object sender, EventArgs e) {
            ClientSession.Clear();
            UIManager.ShowWindow(Window.Ads);
        }

        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            IdleTimer.Enabled = true;
            
            LoadData();

            base.BeforeShow();
        }

        private void LoadData() {
            var cl = ClientSession.CurrClient;

            lblName.Text = $"{cl?.Name} {cl?.LastName}".ToCamelCase();
            lblPoints.Text = cl?.Points.ToString() ?? "0";
            lblCard.Text = cl?.IdCard;
            
            LoadRewardPopup(ClientSession.CampaignReward);

        }

        private void LoadRewardPopup(Reward r) {
            var show = r != null;
            if (show)
                pnlRewardPopup.LoadData(r);

            pnlRewardPopup.Visible = show;
            btnBack.Top = show ? 660 : 600;
            btnPrices.Top = show ? 660 : 600;
            userInfo.Top = show ? 180 : 200;
        }

        public override void AfterHide() {
            lblName.Text = "-";
            lblPoints.Text = "-";
            lblCard.Text = "-";
        }

        private void LblWelcomeOnDoubleClick(object sender, EventArgs e) {
            UIManager.ShowWindow(Window.Ads);
        }
    }
}
