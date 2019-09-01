namespace ClientPoint.UI
{
    public partial class FrmMainContainer : FrmBase
    {
        public FrmMainContainer()
        {
            InitializeComponent();
        }
        
        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }
    }
}
