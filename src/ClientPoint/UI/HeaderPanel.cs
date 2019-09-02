using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class HeaderPanel : RadPanel {
        public HeaderPanel() {
            InitializeComponent();
            Waiting = false;
        }

        public string Title {
            set => lblTitle.Text = value.ToUpper();
            get => lblTitle.Text;
        }

        public bool Waiting {
            set {
                if (value) {
                    waitingBar.StartWaiting();
                    waitingBar.Visible = true;
                } else {
                    waitingBar.Visible = false;
                    waitingBar.StopWaiting();
                }
            }
        }

        private void LblImgOnDoubleClick(object sender, EventArgs e) {
            if(Config.DebugMode)
                Application.Exit();
        }
    }
}
