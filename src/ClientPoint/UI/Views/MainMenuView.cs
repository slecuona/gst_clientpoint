using System;

namespace ClientPoint.UI.Views
{
    public partial class MainMenuView : BaseView
    {
        public MainMenuView()
        {
            InitializeComponent();

            btnConfirm.Click += BtnConfirmOnClick;
            btnClient.Click += BtnClientOnClick;
        }

        private void BtnClientOnClick(object sender, EventArgs e) {
            UIManager.StatusMainView.SetState(States.RemoveCard);
            UIManager.ShowView(View.StatusMain);
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
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }

        private void LblWelcomeOnDoubleClick(object sender, EventArgs e) {
            UIManager.ShowWindow(Window.Ads);
        }
    }
}
