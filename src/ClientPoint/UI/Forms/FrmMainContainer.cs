namespace ClientPoint.UI.Forms
{
    public partial class FrmMainContainer : FrmBase {
        public FrmMainContainer() {
            InitializeComponent();
            this.Window = Window.Main;
            UIManager.AddView(View.MainMenu, MainMenu);
            UIManager.AddView(View.DocumentInput, DocInput);
            UIManager.AddView(View.PasswordInput, PassInput);
            UIManager.AddView(View.ClientCreate, ClientCreate);
            UIManager.AddView(View.ClientUpdate, ClientUpdate);
            UIManager.AddView(View.Confirm, Confirm);
            UIManager.AddView(View.StatusMain, Status);
            UIManager.AddView(View.SwipeCard, Swipe);
            MainMenu.Visible = true;
            DocInput.Visible = false;
            PassInput.Visible = false;
            ClientCreate.Visible = false;
            ClientUpdate.Visible = false;
            Confirm.Visible = false;
            Status.Visible = false;
            Swipe.Visible = false;
        }
        
        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }
    }
}
