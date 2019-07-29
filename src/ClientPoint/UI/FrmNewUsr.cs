using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ClientPoint.UI
{
    public partial class FrmNewUsr : FrmBase
    {
        public FrmNewUsr()
        {
            InitializeComponent();
        }
        
        private void btnBack_Click(object sender, EventArgs e) {
            
        }

        private void btnBack_Click_1(object sender, EventArgs e) {
            UIManager.Show(Window.Ads);
        }
    }
}
