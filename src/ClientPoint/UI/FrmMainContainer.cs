namespace ClientPoint.UI
{
    public partial class FrmMainContainer : FrmBase {
        public FrmMainContainer() {
            InitializeComponent();
            this.Window = Window.Main;
            UIManager.AddView(View.MainMenu, MainMenu);
        }
        
        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }
    }
}
