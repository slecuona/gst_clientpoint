using System;

namespace ClientPoint.UI.Views
{
    public partial class StatusView : BaseView
    {
        public StatusView()
        {
            InitializeComponent();
            imgBox.Click += ImgBoxOnClick;
        }

        private void ImgBoxOnClick(object sender, EventArgs e) {
            //UIManager.ShowWindow(Window.Ads);
        }

        public void SetState(States st) {
            btnBack.Visible = false;
            if (st == States.PrintingCard) {
                imgBox.Image = Properties.Resources.print;
                headerPanel1.Title = "Imprimiendo tarjeta...";
                return;
            }
            if (st == States.RemoveCard) {
                imgBox.Image = Properties.Resources.card;
                headerPanel1.Title = "Tarjeta lista! retírela por favor.";
                btnBack.Visible = true;
                return;
            }
        }

        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }

        private void BtnBackOnClick(object sender, EventArgs e) {
            UIManager.ShowWindow(Window.Ads);
        }
    }

    public enum States {
        PrintingCard = 0,
        RemoveCard = 1,
    }
}
