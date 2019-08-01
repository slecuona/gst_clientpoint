using System;
using System.Windows.Forms;

namespace ClientPoint.UI
{
    public partial class FrmNewUsrMenu : FrmBase
    {
        public FrmNewUsrMenu()
        {
            InitializeComponent();

            btnConfirm.Click += BtnConfirmOnClick;
        }

        private void BtnConfirmOnClick(object sender, EventArgs e) {
            UIManager.Show(Window.Confirm);
        }

        private void btnBack_Click_1(object sender, EventArgs e) {
            UIManager.Show(Window.Ads);
        }

        private void btnNewClient_Click(object sender, EventArgs e) {
            UIManager.Show(Window.ClientCreate);
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
