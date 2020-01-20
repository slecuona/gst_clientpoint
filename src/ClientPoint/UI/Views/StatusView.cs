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
                imgBox.Image = Properties.Resources.printing_card;
                headerPanel.Title = Strings.Get("imprimiendo_tarjeta");
                return;
            }
            if (st == States.RemoveCard) {
                imgBox.Image = Properties.Resources.remove_card;
                headerPanel.Title = Strings.Get("tarjeta_lista");
                return;
            }
            if (st == States.PrintingVoucher) {
                imgBox.Image = Properties.Resources.remove_coupon;
                headerPanel.Title = Strings.Get("imprimiendo_voucher");
                return;
            }
            if (st == States.PrintingTicket) {
                imgBox.Image = Properties.Resources.remove_ticket;
                headerPanel.Title = Strings.Get("imprimiendo_ticket");
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
