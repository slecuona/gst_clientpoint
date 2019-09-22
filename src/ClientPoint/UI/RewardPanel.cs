using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientPoint.Session;
using ClientPoint.Utils;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {

    public class RewardPanel : RadPanel {
        const int width = 515;
        const int height = 139;
        private Reward _reward;

        public RewardPanel(Reward r) {
            _reward = r;

            Size = new Size(width, height);
            Anchor = AnchorStyles.Top;
            BackColor = Color.Transparent;

            // Saco el borde
            ((BorderPrimitive)(GetChildAt(0).GetChildAt(1))).Width = 0F;

            LoadData();
            this.Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e) {
            ShowRewardModal();
        }
        
        private void LoadData() {
            var lblImg = new RadLabel();
            lblImg.Size = new Size(100, 100);
            lblImg.Location = new Point(20, 20);
            //lblImg.ImageScalingSize = new Size(100, 100);
            lblImg.AutoSize = false;
            lblImg.BackgroundImageLayout = ImageLayout.Zoom;
            lblImg.BackgroundImage = _reward.GetImage();
            lblImg.Click += OnClick;

            this.Controls.Add(lblImg);

            var lblName = new RadLabel();
            lblName.Text = _reward.Name?.ToUpper();
            lblName.Size = new Size(380, 20);
            lblName.Font = FontUtils.Roboto(16);
            lblName.Location = new Point(140, 30);
            lblName.ForeColor = Color.White;
            lblName.Click += OnClick;

            this.Controls.Add(lblName);

            var lblPoints = new RadLabel();
            lblPoints.Text = $"PUNTOS: {_reward?.PointsRequired}";
            lblPoints.Size = new Size(380, 20);
            lblPoints.Font = FontUtils.Roboto(12);
            lblPoints.Location = new Point(142, 60);
            lblPoints.ForeColor = Color.White;
            lblPoints.Click += OnClick;

            this.Controls.Add(lblPoints);
        }
        
        private void ShowRewardModal() {
            Op.ShowReward(_reward);
        }
    }
}
