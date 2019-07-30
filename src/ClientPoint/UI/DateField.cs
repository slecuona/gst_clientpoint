using System.Windows.Forms;

namespace ClientPoint.UI {
    public partial class DateField : UserControl {
        public DateField() {
            InitializeComponent();
        }

        public string Label {
            get => radLabel1.Text;
            set => radLabel1.Text = value;
        }
    }
}
