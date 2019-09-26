using System;
using System.Windows.Forms;

namespace ClientPoint.UI.Controls {
    public partial class SexField : UserControl {
        private bool _male = true;

        public SexField() {
            InitializeComponent();
            Value = "M";
            btnM.Click += BtnMOnClick;
            btnF.Click += BtnFOnClick;
        }

        private void BtnFOnClick(object sender, EventArgs e) {
            Value = "F";
        }

        private void BtnMOnClick(object sender, EventArgs e) {
            Value = "M";
        }

        public string Value {
            get { return _male ? "M" : "F"; }
            set {
                if (value == "M") {
                    btnM.Image = Properties.Resources.btn_male_press;
                    btnF.Image = Properties.Resources.btn_female;
                    _male = true;
                    return;
                }
                if (value == "F") {
                    btnM.Image = Properties.Resources.btn_male;
                    btnF.Image = Properties.Resources.btn_female_press;
                    _male = false;
                    return;
                }
            }
        }
    }
}
