using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
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
            if (_type == Type.Next) {
                this.Image = Properties.Resources.btn_next_press;
                return;
            }
            if (_type == Type.Back) {
                this.Image = Properties.Resources.btn_back_press;
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
            if (_type == Type.Next) {
                Image = Properties.Resources.btn_next;
                Size = new Size(234, 78);
                return;
            }
            if (_type == Type.Back) {
                Image = Properties.Resources.btn_back;
                Size = new Size(234, 78);
                return;
            }
        }

    }

    public enum Type {
        NewClient = 0,
        Client = 1,
        Next = 2,
        Back = 3
    }
}
