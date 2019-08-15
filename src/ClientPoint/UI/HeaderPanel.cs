using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class HeaderPanel : RadPanel {
        public HeaderPanel() {
            InitializeComponent();
            Waiting = false;
        }

        public string Title {
            set => lblTitle.Text = value;
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
    }
}
