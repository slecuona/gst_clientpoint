using System;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Forms
{
    public partial class FrmUserMenu : FrmBase
    {
        public FrmUserMenu()
        {
            InitializeComponent();

            btnRewards.Click += BtnRewardsOnClick;
        }

        private void BtnRewardsOnClick(object sender, EventArgs e) {
            MsgBox.Show("Not implemented.");
        }

        private void btnBack_Click_1(object sender, EventArgs e) {
            ClientSession.Clear();
            UIManager.ShowWindow(Window.Ads);
        }

        public override void BeforeShow() {
            usrPanel.LoadUserData();
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }

        public override void AfterHide() {
            usrPanel.ClearData();
            base.AfterHide();
        }
    }
}
