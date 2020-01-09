using System;
using System.Windows.Forms;

namespace ClientPoint.UI.Views
{
    public partial class SwipeView : BaseView
    {
        private SwipeReader _swipeReader;

        public SwipeView()
        {
            InitializeComponent();
            imgBox.Click += ImgBoxOnClick;
            headerPanel.Title = "";
            _swipeReader = new SwipeReader(OnSwipe);

            lblMsg.Text = "Por favor, deslice su tarjeta por el lector.";
            lblMsg.Text = lblMsg.Text.ToUpper();

            btnLogin.Click += BtnLoginOnClick;
        }

        private void BtnLoginOnClick(object sender, EventArgs e) {
            Op.ClientLogin();
        }

        private void ImgBoxOnClick(object sender, EventArgs e) {
            if(Config.DebugMode)
                Op.ClientLoadAsync(Config.TEST_CARD);
        }
        
        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            imgBox.Visible = true;
            this.ParentForm.KeyDown += ParentFormOnKeyDown;

            base.BeforeShow();
        }

        private void ParentFormOnKeyDown(object sender, KeyEventArgs e) {
            _swipeReader.OnKeyPress(e.KeyCode);
        }

        public override void AfterHide() {
            imgBox.Visible = false;
            this.ParentForm.KeyDown -= ParentFormOnKeyDown;
        }

        private void BtnBackOnClick(object sender, EventArgs e) {
            UIManager.ShowView(View.MainMenu);
        }

        private void OnSwipe(string data) {
            IdleTimer.OnBusy();
            Op.ClientLoadAsync(data);
        }
    }
}
