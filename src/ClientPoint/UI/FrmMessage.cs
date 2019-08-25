using System;
using System.Diagnostics;
using System.Windows.Forms;
using ClientPoint.Utils;

namespace ClientPoint.UI
{
    public enum MsgType {
        Info = 0,
        Error = 1
    }

    public partial class FrmMessage : Telerik.WinControls.UI.RadForm
    {
        public FrmMessage(string msg, MsgType msgType = MsgType.Info)
        {
            InitializeComponent();
            lblMessage.Text = msg;
            Shown += OnShown;

            switch (msgType) {
                case MsgType.Info:
                    lblIcon.Image = Properties.Resources.info;
                    break;
                case MsgType.Error:
                    lblIcon.Image = Properties.Resources.error;
                    break;
            }
        }

        // Dimensiona la ventana segun el contenido del mensaje
        private void ReSize() {
            var lns = lblMessage.Text.Split('\n').Length;
            var offset = (lns - 1) * 22;
            if (offset == 0) // Una sola linea
                return;
            lblMessage.Height = lblMessage.Height + offset;
            btnOk.Top = btnOk.Top + offset;
            lblIcon.Top = lblIcon.Top + (offset / 2);
            this.Height = this.Height + offset;
            Debug.WriteLine($"Label width: {lblMessage.Width}");
            if (lblMessage.Width < 400)
                return;
            var offset2 = lblMessage.Width - 400;
            this.Width = this.Width + offset2;
            btnOk.Left = btnOk.Left + (offset2 / 2);
        }

        private void OnShown(object sender, EventArgs e) {
            ReSize();
            this.CenterToScreen();
        }

        private void customButton1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.SetRoundBorders(e, 10);
        }
    }
}
