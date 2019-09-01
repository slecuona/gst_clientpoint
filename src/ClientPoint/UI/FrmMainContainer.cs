using ClientPoint.UI.Views;

namespace ClientPoint.UI
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
            MainMenu.Visible = true;
            DocInput.Visible = false;
            PassInput.Visible = false;
            ClientCreate.Visible = false;
            ClientUpdate.Visible = false;
            Confirm.Visible = false;
        }
        
        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }
    }
}
