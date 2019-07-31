using System;

namespace ClientPoint.UI {
    public partial class FrmAddUsr : FrmBase {
        public FrmAddUsr() {
            InitializeComponent();

            footerPanel.OnBackClick(OnBack);
            footerPanel.NextText = "Siguiente";
            footerPanel.BackText = "Cancelar";
        }

        private void OnBack(object sender, EventArgs e) {
            UIManager.Show(Window.NewUsr);
        }
    }
}
