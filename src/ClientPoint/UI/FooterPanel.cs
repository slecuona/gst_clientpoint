using System;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {
    public partial class FooterPanel : RadPanel {
        public FooterPanel() {
            InitializeComponent();
        }

        public void OnBackClick(EventHandler action) => 
            btnBack.Click += action;

        public void OnNextClick(EventHandler action) =>
            btnNext.Click += action;

        public string NextText {
            set => btnNext.Text = value;
        }

        public string BackText {
            set => btnBack.Text = value;
        }
    }
}
