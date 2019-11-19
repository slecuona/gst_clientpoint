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
            
            var cl = ClientSession.CurrClient;

            lblName.Text = $"{cl?.Name} {cl?.LastName}".ToCamelCase();
            lblPoints.Text = cl?.Points.ToString() ?? "0";
            lblCard.Text = cl?.IdCard;

            base.BeforeShow();
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
