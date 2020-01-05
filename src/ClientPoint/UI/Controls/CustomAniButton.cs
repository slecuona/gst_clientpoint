using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
    public partial class CustomAniButton : PictureBox {

        public CustomAniButton() {
            InitializeComponent();
            
            this.Controls.Add(new RadLabel() {
                Text = "CLIENTE",
                Font = FontUtils.Roboto(18, FontStyle.Bold),
                AutoSize = false,
                TextAlignment = ContentAlignment.MiddleCenter,
                Size = new Size(240, 89),
                ForeColor = Color.Black
            });

        }
        

    }
}
