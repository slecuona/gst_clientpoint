using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class CustomButton : RadButton {
        private Type _type;

        public Type Type {
            get => _type;
            set {
                _type = value;
                RefreshType();
            }
        }

        public CustomButton() {
            InitializeComponent();
            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            RefreshType();
        }

        private void OnMouseDown(object sender, MouseEventArgs e) {
            if (_type == Type.NewClient) {
                this.Image = Properties.Resources.btn_new_client_press;
                return;
            }
            if (_type == Type.Client) {
                this.Image = Properties.Resources.btn_client_press;
                return;
            }
        }

        private void RefreshType() {
            if (_type == Type.NewClient) {
                Image = Properties.Resources.btn_new_client;
                Size = new Size(240, 89);
                return;
            }
            if (_type == Type.Client) {
                Image = Properties.Resources.btn_client;
                Size = new Size(240, 89);
                return;
            }
        }

    }

    public enum Type {
        NewClient = 0,
        Client = 1
    }
}
