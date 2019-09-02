using System.Windows.Forms;

namespace ClientPoint.UI.Controls {
    public partial class SexField : UserControl {
        public SexField() {
            InitializeComponent();
        }

        public string Value {
            get {
                if (this.radioF.IsChecked)
                    return "F";
                if (this.radioM.IsChecked)
                    return "M";
                return null;
            }
            set {
                if (value == "F") {
                    radioF.CheckState = CheckState.Checked;
                    return;
                }
                if (value == "M") {
                    radioM.CheckState = CheckState.Checked;
                    return;
                }
                radioF.CheckState = CheckState.Unchecked;
                radioM.CheckState = CheckState.Unchecked;
            }
        }
    }
}
