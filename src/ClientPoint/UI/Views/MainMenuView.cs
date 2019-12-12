using System;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Views
{
    public partial class MainMenuView : BaseView
    {
        public MainMenuView()
        {
            InitializeComponent();

            btnConfirm.Click += BtnConfirmOnClick;
            btnClient.Click += BtnClientOnClick;

            //this.panelContainer.Controls.SetChildIndex(this.headerPanel, 6);
        }

        private void BtnClientOnClick(object sender, EventArgs e) {
            //UIManager.StatusMainView.SetState(States.PrintingCard);
            //UIManager.ShowView(View.StatusMain);
            Op.Client();
        }

        private void BtnConfirmOnClick(object sender, EventArgs e) {
            Op.ClientConfirm();
        }
        
        private void btnUpdate_Click(object sender, EventArgs e) {
            Op.ClientUpdate();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            //Op.TestPrint();
            //return;
            Op.ClientCreate();
        }

        public override void BeforeShow() {
            ClientSession.Clear();
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }

        public override void AfterShow() {
            IdleTimer.Enabled = true;
            // En esta pantalla, no mostramos el mensaje.
            IdleTimer.ShowMessage = false;
            base.AfterShow();
        }

        public override void AfterHide() {
            IdleTimer.ShowMessage = true;
            base.AfterHide();
        }

        private void LblWelcomeOnDoubleClick(object sender, EventArgs e) {
            UIManager.ShowWindow(Window.Ads);
        }
    }
}
