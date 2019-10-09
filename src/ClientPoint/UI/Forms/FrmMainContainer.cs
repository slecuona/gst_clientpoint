using System;
using System.Windows.Forms;
using ClientPoint.Keyboard.UserInteraction;

namespace ClientPoint.UI.Forms
{
    public partial class FrmMainContainer : FrmBase {
        public FrmMainContainer() {
            InitializeComponent();
            this.Window = Window.Main;
            UIManager.AddView(View.MainMenu, MainMenu);
            UIManager.AddView(View.DocumentInput, DocInput);
            UIManager.AddView(View.PasswordInput, PassInput);
            UIManager.AddView(View.PinInput, PinInput);
            UIManager.AddView(View.ClientCreate, ClientCreate);
            UIManager.AddView(View.ClientUpdate, ClientUpdate);
            UIManager.AddView(View.Confirm, Confirm);
            UIManager.AddView(View.StatusMain, Status);
            UIManager.AddView(View.SwipeCard, Swipe);
            UIManager.AddView(View.ClientMenu, ClientMenu);
            UIManager.AddView(View.Rewards, Rewards);
            MainMenu.Visible = true;
            DocInput.Visible = false;
            PassInput.Visible = false;
            PinInput.Visible = false;
            ClientCreate.Visible = false;
            ClientUpdate.Visible = false;
            Confirm.Visible = false;
            Status.Visible = false;
            Swipe.Visible = false;
            ClientMenu.Visible = false;
            Rewards.Visible = false;
        }
        
        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }

        protected override void WndProc(ref Message m) {
            //Console.WriteLine($"FrmMain Msg: {m.Msg}");
            if (NativeMethods.IsActiveMsg(m.Msg)) {
                IdleTimer.OnBusy();
            }
            base.WndProc(ref m);
        }
    }
}
