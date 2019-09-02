using System;

namespace ClientPoint.UI.Forms
{
    public partial class FrmStatus : FrmBase
    {
        public FrmStatus()
        {
            InitializeComponent();
            imgBox.Click += ImgBoxOnClick;
        }

        private void ImgBoxOnClick(object sender, EventArgs e) {
            //UIManager.ShowWindow(Window.Ads);
        }

        public void SetState(States st) {
            if (st == States.PrintingCard) {
                imgBox.Image = Properties.Resources.print;
                headerPanel1.Title = "Imprimiendo tarjeta...";
                return;
            }
            if (st == States.RemoveCard) {
                imgBox.Image = Properties.Resources.card;
                headerPanel1.Title = "Tarjeta lista!";
                return;
            }
        }

        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }
    }

    public enum States {
        PrintingCard = 0,
        RemoveCard = 1
    }
}
