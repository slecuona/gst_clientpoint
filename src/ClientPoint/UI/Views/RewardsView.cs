using System;
using System.Windows.Forms;

namespace ClientPoint.UI.Views
{
    public partial class RewardsView : BaseView {

        public RewardsView() {
            InitializeComponent();
            headerPanel1.Title = "Premios";
            btnNext.SetRight();
        }
        
        public override void BeforeShow() {
        }
        

        public override void AfterHide() {
        }

        private void BtnBackOnClick(object sender, EventArgs e) {
            UIManager.ShowView(View.MainMenu);
        }
    }
}
