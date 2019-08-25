using System;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI
{
    public partial class FrmMainMenu : FrmBase
    {
        public FrmMainMenu()
        {
            InitializeComponent();

            btnRewards.Click += BtnRewardsOnClick;
        }

        private void BtnRewardsOnClick(object sender, EventArgs e) {
            MsgBox.Show("Not implemented.", this);
        }

        private void btnBack_Click_1(object sender, EventArgs e) {
            ClientSession.Clear();
            UIManager.Show(Window.Ads);
        }

        public override void BeforeShow() {
            usrPanel.LoadUserData();
            base.BeforeShow();
        }

        public override void AfterHide() {
            usrPanel.ClearData();
            base.AfterHide();
        }
    }
}
