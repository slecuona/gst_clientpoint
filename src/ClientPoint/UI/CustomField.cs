using System.Windows.Forms;

namespace ClientPoint.UI {
    public partial class CustomField : UserControl {
        public CustomField() {
            InitializeComponent();
        }

        public string Label {
            get => radLabel1.Text;
            set => radLabel1.Text = value;
        }

        public string Value {
            get => radTextBox1.Text;
            set => radTextBox1.Text = value;
        }
    }
}
