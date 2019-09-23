using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
    public partial class CustomButtonCount : RadButton {
        private bool _plus = false;

        public bool Plus {
            get => _plus;
            set {
                _plus = value;
                this.Image = _plus ? 
                    Properties.Resources.btn_plus : 
                    Properties.Resources.btn_minus;
            }
        }

        public CustomButtonCount() {
            InitializeComponent();
        }
    }
}
