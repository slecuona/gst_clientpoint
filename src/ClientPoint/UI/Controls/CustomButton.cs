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

            //this.Controls.Add(new PictureBox() {
            //    Name = "glow",
            //    Size = this.Size,
            //    BackColor = Color.Transparent,
            //    Image = global::ClientPoint.Properties.Resources.btn_glow2
            //});
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
            if (_type == Type.Price) {
                this.Image = Properties.Resources.btn_price_press;
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
            if (_type == Type.Price) {
                Image = Properties.Resources.btn_price;
                Size = new Size(240, 89);
                return;
            }
            if (_type == Type.Cancel) {
                Image = Properties.Resources.btn_cancel;
                Size = new Size(121, 41);
                return;
            }
            if (_type == Type.ViewReward) {
                Image = Properties.Resources.btn_view_reward;
                Size = new Size(121, 41);
                return;
            }
        }

    }

    public enum Type {
        NewClient = 0,
        Client = 1,
        Next = 2,
        Back = 3,
        Price = 4,
        Cancel = 5,
        ViewReward = 6
    }
}
