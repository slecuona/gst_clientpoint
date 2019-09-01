using System;
using ClientPoint.UI.Panels;

namespace ClientPoint.UI.Panels
{
    public partial class PanelMainMenu : PanelBase
    {
        public PanelMainMenu()
        {
            InitializeComponent();

            btnConfirm.Click += BtnConfirmOnClick;
        }

        private void BtnConfirmOnClick(object sender, EventArgs e) {
            Op.ClientConfirm();
        }
        
        private void btnUpdate_Click(object sender, EventArgs e) {
            Op.ClientUpdate();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            //Op.TestPrint();
            //return;
            Op.ClientCreate();
        }

        public override void BeforeShow() {
            UIManager.SetKeyboard(Keyboard.None);
            base.BeforeShow();
        }
    }
}
