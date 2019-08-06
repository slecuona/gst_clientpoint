using ClientPoint.Session;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class UserPanel : RadPanel {
        public UserPanel() {
            InitializeComponent();
        }

        public void LoadUserData() {
            var usr = ClientSession.CurrClient;
            if (usr == null)
                return;

            lblUsr.Text = $"[{usr.Id}] {usr.Name} {usr.LastName}";
            lblPoints.Text = $"{usr.Points} puntos.";
        }

        public void ClearData() {
            lblUsr.Text = "";
            lblPoints.Text = "";
        }
    }
}
