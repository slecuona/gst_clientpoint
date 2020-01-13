using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientPoint.Session;
using ClientPoint.UI.Controls;
using ClientPoint.Utils;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace ClientPoint.UI {

    public class RewardPopupPanel : RadPanel {
        const int width = 746;
        const int height = 140;
        private Reward _reward;

        private RadLabel _lblImg;
        private CustomButton _btnCancel;

        public Action OnCancel;

        public RewardPopupPanel() {
            Size = new Size(width, height);
            //Anchor = AnchorStyles.Top;
            BackColor = Color.Transparent;

            this.BackgroundImage = Properties.Resources.bg_reward_popup;

            // Saco el borde
            ((BorderPrimitive)(GetChildAt(0).GetChildAt(1))).Width = 0F;

            _lblImg = new RadLabel();
            _lblImg.Size = new Size(100, 100);
            _lblImg.Location = new Point(20, 12);
            _lblImg.AutoSize = false;
            _lblImg.BackgroundImageLayout = ImageLayout.Zoom;
            _lblImg.BackgroundImage = Properties.Resources.gift_thumb;

            this.Controls.Add(_lblImg);

            var lbl = new RadLabel();
            lbl.Text = "¡Tienes un premio pendiente! ¿Deseas canjearlo?";
            lbl.Size = new Size(500, 30);
            lbl.Font = FontUtils.Roboto(18);
            lbl.Location = new Point(150, 20);
            lbl.ForeColor = Color.White;

            this.Controls.Add(lbl);

            _btnCancel = new CustomButton();
            _btnCancel.Location = new System.Drawing.Point(280, 70);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Type = ClientPoint.UI.Controls.Type.Cancel;
            _btnCancel.Click += BtnCancelOnClick;

            this.Controls.Add(_btnCancel);

            var btnView = new CustomButton();
            btnView.Location = new System.Drawing.Point(450, 70);
            btnView.Name = "btnView";
            btnView.Type = ClientPoint.UI.Controls.Type.ViewReward;
            btnView.Click += BtnViewOnClick;

            this.Controls.Add(btnView);
        }

        private void BtnCancelOnClick(object sender, EventArgs e) {
            OnCancel?.Invoke();
        }

        private void BtnViewOnClick(object sender, EventArgs e) {
            ShowRewardModal();
        }
        
        public void LoadData(Reward r) {
            _reward = r;

            _lblImg.BackgroundImage = _reward.GetImage();


            //if (!Config.PointsEnabled)
            //    return;

            //var lblPoints = new RadLabel();
            //lblPoints.Text = $"PUNTOS: {_reward?.PointsRequired}";
            //lblPoints.Size = new Size(380, 20);
            //lblPoints.Font = FontUtils.Roboto(12);
            //lblPoints.Location = new Point(142, 60);
            //lblPoints.ForeColor = Color.White;
            //lblPoints.Click += OnClick;

            //this.Controls.Add(lblPoints);
        }
        
        private void ShowRewardModal() {
            Op.ShowReward(_reward);
        }
    }
}
