using System;
using System.Windows.Forms;

namespace ClientPoint.UI {
    public partial class SexField : UserControl {
        public SexField() {
            InitializeComponent();
        }

        public string GetValue() {
            if (this.radioF.IsChecked)
                return "F";
            if (this.radioM.IsChecked)
                return "M";
            return null;
        }
    }
}
