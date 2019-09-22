using System;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.UI.Forms {
    public partial class FrmRewardModal : Telerik.WinControls.UI.RadForm {

        public FrmRewardModal() {
            InitializeComponent();
            Shown += OnShown;
            lblTitle.Text = "CRUCERO POR EL CARIBE";
            lblTitle.Font = FontUtils.Roboto(16, FontStyle.Bold);
            btnConfirm.Font = FontUtils.Roboto(16, FontStyle.Bold);
        }

        public void LoadReward(Reward r) {
            lblTitle.Text = r.Name?.ToUpper();
            lblImage.BackgroundImage = r.GetImage();
        }

        private void customButton1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.SetRoundBorders(e, 10);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnShown(object sender, EventArgs e) {
            this.CenterToScreen();
        }
    }
}
