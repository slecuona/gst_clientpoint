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
            Op.ClientConfirm();
        }

        private void btnBack_Click_1(object sender, EventArgs e) {
            UIManager.Show(Window.Ads);
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            Op.ClientUpdate();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            Op.ClientCreate();
        }

        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }
    }
}
