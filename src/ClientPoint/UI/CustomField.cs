using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void CustomField_Load(object sender, EventArgs e) {

        }
    }
}
