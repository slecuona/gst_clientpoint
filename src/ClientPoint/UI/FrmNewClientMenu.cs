using System;

namespace ClientPoint.UI
{
    public partial class FrmNewClientMenu : FrmBase
    {
        public FrmNewClientMenu()
        {
            InitializeComponent();

            btnConfirm.Click += BtnConfirmOnClick;
        }

        private void BtnConfirmOnClick(object sender, EventArgs e) {
            UIManager.ClientConfirm();
        }

        private void btnBack_Click_1(object sender, EventArgs e) {
            UIManager.Show(Window.Ads);
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            UIManager.ClientUpdate();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            UIManager.ClientCreate();
        }
    }
}
