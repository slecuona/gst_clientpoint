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
                //TODO: Falta este GIF...
                imgBox.Image = Properties.Resources.print;
                headerPanel.Title = "Imprimiendo tarjeta...";
                return;
            }
            if (st == States.RemoveCard) {
                imgBox.Image = Properties.Resources.remove_card;
                headerPanel.Title = "Tarjeta lista! retírela por favor.";
                return;
            }
            if (st == States.PrintingVoucher) {
                //TODO: por ahora queda el mismo que ticket
                imgBox.Image = Properties.Resources.remove_ticket;
                headerPanel.Title = "Imprimiendo voucher...";
                return;
            }
            if (st == States.PrintingTicket) {
                imgBox.Image = Properties.Resources.remove_ticket;
                headerPanel.Title = "Imprimiendo ticket de promoción...";
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
