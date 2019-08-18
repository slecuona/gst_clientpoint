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
    public partial class FrmSplash : Telerik.WinControls.UI.RadForm
    {
        public FrmSplash()
        {
            InitializeComponent();
            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e) {
            radWaitingBar1.StartWaiting();
        }

        public void AppendText(string t) => radLabel1.Text += $"\n{t}";
    }
}
