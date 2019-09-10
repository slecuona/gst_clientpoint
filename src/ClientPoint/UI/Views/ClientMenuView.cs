using System;

namespace ClientPoint.UI.Views
{
    public partial class ClientMenuView : BaseView
    {
        public ClientMenuView()
        {
            InitializeComponent();
            
            btnPrices.Click += BtnPricesOnClick;
        }

        private void BtnPricesOnClick(object sender, EventArgs e) {
            Op.Client();
        }
        
        private void btnBack_Click(object sender, EventArgs e) {
            UIManager.ShowWindow(Window.Ads);
        }

        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }

        private void LblWelcomeOnDoubleClick(object sender, EventArgs e) {
            UIManager.ShowWindow(Window.Ads);
        }
    }
}
