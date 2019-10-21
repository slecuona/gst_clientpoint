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
            //TODO: Faltan los GIFS
            if (st == States.PrintingCard) {
                imgBox.Image = Properties.Resources.print;
                headerPanel1.Title = "Imprimiendo tarjeta...";
                return;
            }
            if (st == States.RemoveCard) {
                imgBox.Image = Properties.Resources.card;
                headerPanel1.Title = "Tarjeta lista! retírela por favor.";
                return;
            }
            if (st == States.PrintingVoucher) {
                imgBox.Image = Properties.Resources.print;
                headerPanel1.Title = "Imprimiendo voucher...";
                return;
            }
            if (st == States.PrintingTicket) {
                imgBox.Image = Properties.Resources.print;
                headerPanel1.Title = "Imprimiendo ticket de promoción...";
                return;
            }
        }

        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            IdleTimer.Enabled = false;
            base.BeforeShow();
        }

        public override void AfterHide() {
            IdleTimer.Enabled = true;
        }

        private void BtnBackOnClick(object sender, EventArgs e) {
            UIManager.ShowWindow(Window.Ads);
        }
    }

    public enum States {
        PrintingCard = 0,
        RemoveCard = 1,
        PrintingVoucher = 2,
        PrintingTicket = 3
    }
}
