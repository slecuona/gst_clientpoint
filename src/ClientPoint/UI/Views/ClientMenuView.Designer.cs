using System.Drawing;
using System.Windows.Forms;
using ClientPoint.UI.Controls;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Views
{
    partial class ClientMenuView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMenuView));
            this.btnBack = new ClientPoint.UI.Controls.CustomButton();
            this.btnPrices = new ClientPoint.UI.Controls.CustomButton();
            this.lblWelcome = new ClientPoint.UI.Controls.CustomLabel();
            this.userInfo = new System.Windows.Forms.PictureBox();
            this.lblName = new Telerik.WinControls.UI.RadLabel();
            this.lblPointsT = new Telerik.WinControls.UI.RadLabel();
            this.lblCardT = new Telerik.WinControls.UI.RadLabel();
            this.lblPoints = new Telerik.WinControls.UI.RadLabel();
            this.lblCard = new Telerik.WinControls.UI.RadLabel();
            this.pnlRewardPopup = new RewardPopupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfo)).BeginInit();
            this.userInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCardT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRewardPopup)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.userInfo);
            this.panelContainer.Controls.Add(this.lblWelcome);
            this.panelContainer.Controls.Add(this.btnPrices);
            this.panelContainer.Controls.Add(this.btnBack);
            this.panelContainer.Controls.Add(this.pnlRewardPopup);
            this.panelContainer.Size = new System.Drawing.Size(1586, 832);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.Location = new System.Drawing.Point(356, 600);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(234, 78);
            this.btnBack.TabIndex = 6;
            this.btnBack.TabStop = false;
            this.btnBack.Type = ClientPoint.UI.Controls.Type.Back;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPrices
            // 
            this.btnPrices.BackColor = System.Drawing.Color.Transparent;
            this.btnPrices.ForeColor = System.Drawing.Color.White;
            this.btnPrices.Image = ((System.Drawing.Image)(resources.GetObject("btnPrices.Image")));
            this.btnPrices.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrices.Location = new System.Drawing.Point(774, 600);
            this.btnPrices.Name = "btnPrices";
            this.btnPrices.Size = new System.Drawing.Size(240, 89);
            this.btnPrices.TabIndex = 7;
            this.btnPrices.TabStop = false;
            this.btnPrices.Type = ClientPoint.UI.Controls.Type.Price;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = false;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            //this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.lblWelcome.Size = new System.Drawing.Size(1366, 143);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "BIENVENIDO";
            this.lblWelcome.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // userInfo
            // 
            this.userInfo.Controls.Add(this.lblName);
            this.userInfo.Controls.Add(this.lblPointsT);
            this.userInfo.Controls.Add(this.lblCardT);
            this.userInfo.Controls.Add(this.lblPoints);
            this.userInfo.Controls.Add(this.lblCard);
            this.userInfo.Image = global::ClientPoint.Properties.Resources.user_box;
            this.userInfo.Location = new System.Drawing.Point(7, 205);
            this.userInfo.Name = "userInfo";
            this.userInfo.Size = new System.Drawing.Size(1352, 303);
            this.userInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.userInfo.TabIndex = 0;
            this.userInfo.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = false;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(1352, 79);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "TEST DEMO";
            this.lblName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointsT
            // 
            this.lblPointsT.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsT.ForeColor = System.Drawing.Color.DimGray;
            this.lblPointsT.Location = new System.Drawing.Point(540, 180);
            this.lblPointsT.Name = "lblPointsT";
            this.lblPointsT.Size = new System.Drawing.Size(41, 18);
            this.lblPointsT.TabIndex = 8;
            this.lblPointsT.Text = "Puntos";
            this.lblPointsT.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblCardT
            // 
            this.lblCardT.BackColor = System.Drawing.Color.Transparent;
            this.lblCardT.ForeColor = System.Drawing.Color.DimGray;
            this.lblCardT.Location = new System.Drawing.Point(710, 180);
            this.lblCardT.Name = "lblCardT";
            this.lblCardT.Size = new System.Drawing.Size(55, 18);
            this.lblCardT.TabIndex = 8;
            this.lblCardT.Text = "Id. Tarjeta";
            this.lblCardT.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblPoints
            // 
            this.lblPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblPoints.ForeColor = System.Drawing.Color.Black;
            this.lblPoints.Location = new System.Drawing.Point(530, 205);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.AutoSize = false;
            this.lblPoints.Size = new System.Drawing.Size(85, 25);
            this.lblPoints.TabIndex = 8;
            this.lblPoints.Text = "0";
            this.lblPoints.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCard
            // 
            this.lblCard.BackColor = System.Drawing.Color.Transparent;
            this.lblCard.ForeColor = System.Drawing.Color.Black;
            this.lblCard.Location = new System.Drawing.Point(680, 205);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(55, 18);
            this.lblCard.TabIndex = 8;
            this.lblCard.Text = "-------------";
            this.lblCard.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            //
            // pnlRewardPopup
            //
            this.pnlRewardPopup.Location = new Point(315, 495);
            this.pnlRewardPopup.Visible = false;
            // 
            // ClientMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ClientMenuView";
            this.Size = new System.Drawing.Size(1586, 832);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfo)).EndInit();
            this.userInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCardT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRewardPopup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton btnBack;
        private CustomButton btnPrices;
        private CustomLabel lblWelcome;
        private PictureBox userInfo;
        private RadLabel lblName;
        private RadLabel lblPointsT;
        private RadLabel lblCardT;
        private RadLabel lblPoints;
        private RadLabel lblCard;
        private RewardPopupPanel pnlRewardPopup;
    }
}
