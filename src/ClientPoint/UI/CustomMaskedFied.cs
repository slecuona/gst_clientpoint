using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class CustomMaskedField : UserControl {
        public CustomMaskedField() {
            InitializeComponent();
        }

        public string Label {
            get => radLabel1.Text;
            set => radLabel1.Text = value;
        }

        public CustomMaskType CustomMaskType {
            set {
                if (value == CustomMaskType.Document) {
                    radTextBox1.MaskType = MaskType.Numeric;
                    return;
                }
                if (value == CustomMaskType.Email) {
                    radTextBox1.MaskType = MaskType.EMail;
                    return;
                }
            }
            get => CustomMaskType.Email;
        }
    }

    public enum CustomMaskType {
        Document = 0,
        Email = 1
    }
}
