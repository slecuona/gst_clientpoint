using System;

namespace ClientPoint.UI
{
    public partial class FrmAddUsr : FrmBase
    {
        public FrmAddUsr()
        {
            InitializeComponent();
        }
        
        private void btnBack_Click(object sender, EventArgs e) {
            UIManager.Show(Window.NewUsr);
        }
    }
}
