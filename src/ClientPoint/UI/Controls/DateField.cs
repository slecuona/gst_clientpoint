using System;
using System.Windows.Forms;

namespace ClientPoint.UI.Controls {
    public partial class DateField : UserControl {
        public DateField() {
            InitializeComponent();
        }

        public string Label {
            get => radLabel1.Text;
            set => radLabel1.Text = value;
        }

        public DateTime Value {
            get => dateTimePicker.Value;
            set => dateTimePicker.Value = value;
        }
    }
}
