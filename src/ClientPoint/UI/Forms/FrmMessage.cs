using System;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;

namespace ClientPoint.UI.Forms
{
    public enum MsgType {
        Info = 0,
        Error = 1,
        Sms = 2,
        Email = 3
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
                case MsgType.Sms:
                    lblIcon.Image = Properties.Resources.sms;
                    break;
                case MsgType.Email:
                    lblIcon.Image = Properties.Resources.email;
                    break;
            }

            this.lblMessage.Font = FontUtils.Roboto(17, FontStyle.Bold);
            this.btnOk.Font = FontUtils.Roboto(17, FontStyle.Bold);

            this.BackColor = Color.FromArgb(63, 63, 77);
            this.btnOk.ForeColor = Color.FromArgb(63, 63, 77);
        }

        // Dimensiona la ventana segun el contenido del mensaje
        private void ReSize() {
            var lns = lblMessage.Text.Split('\n').Length;
            var offset = (lns - 1) * 22;
            if (offset > 0) {
                lblMessage.Height = lblMessage.Height + offset;
                btnOk.Top = btnOk.Top + offset;
                lblIcon.Top = lblIcon.Top + (offset / 2);
                this.Height = this.Height + offset;
            }
            
            var offset2 = lblMessage.Width - 400;
            if (offset2 > 0) {
                this.Width = this.Width + offset2;
                btnOk.Left = btnOk.Left + (offset2 / 2);
            }
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
