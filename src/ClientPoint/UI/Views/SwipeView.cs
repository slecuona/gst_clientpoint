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
            headerPanel1.Title = "Por favor, deslice su tarjeta por el lector.                                                   ";
            _swipeReader = new SwipeReader(OnSwipe);
        }

        private void ImgBoxOnClick(object sender, EventArgs e) {
            if(Config.DebugMode)
                Op.ClientLoadAsync(Config.TEST_CARD);
        }
        
        public override void BeforeShow() {
            imgBox.Visible = true;
            this.ParentForm.KeyDown += ParentFormOnKeyDown;
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
            Op.ClientLoadAsync(data);
        }
    }
}
