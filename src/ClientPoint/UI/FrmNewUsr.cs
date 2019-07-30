using System;
using System.Windows.Forms;

namespace ClientPoint.UI
{
    public partial class FrmNewUsr : FrmBase
    {
        public FrmNewUsr()
        {
            InitializeComponent();
        }
        
        private void btnBack_Click_1(object sender, EventArgs e) {
            UIManager.Show(Window.Ads);
        }

        private void btnNewClient_Click(object sender, EventArgs e) {
            UIManager.Show(Window.AddUsr);
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
