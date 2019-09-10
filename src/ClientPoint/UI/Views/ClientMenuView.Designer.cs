using System.Drawing;
using System.Windows.Forms;
using ClientPoint.UI.Controls;
using ClientPoint.Utils;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuView));
            this.btnBack = new ClientPoint.UI.Controls.CustomButton();
            this.btnPrices = new ClientPoint.UI.Controls.CustomButton();
            this.lblWelcome = new ClientPoint.UI.Controls.CustomLabel();
            this.userInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.userInfo);
            this.panelContainer.Controls.Add(this.lblWelcome);
            this.panelContainer.Controls.Add(this.btnPrices);
            this.panelContainer.Controls.Add(this.btnBack);
            this.panelContainer.Size = new System.Drawing.Size(1352, 661);
            // 
            // btnNewlient
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnNewlient.Image")));
            this.btnBack.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.Location = new System.Drawing.Point(356, 600);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(240, 89);
            this.btnBack.TabIndex = 6;
            this.btnBack.TabStop = false;
            this.btnBack.Type = ClientPoint.UI.Controls.Type.Back;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPrices
            // 
            this.btnPrices.BackColor = System.Drawing.Color.Transparent;
            this.btnPrices.ForeColor = System.Drawing.Color.White;
            this.btnPrices.Image = ((System.Drawing.Image)(resources.GetObject("btnClient.Image")));
            this.btnPrices.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPrices.Location = new System.Drawing.Point(744, 600);
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
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.lblWelcome.Size = new System.Drawing.Size(1352, 143);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "BIENVENIDO";
            this.lblWelcome.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imgHost
            // 
            this.userInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.userInfo.Image = global::ClientPoint.Properties.Resources.user_box;
            this.userInfo.Location = new System.Drawing.Point(0, 180);
            this.userInfo.Name = "userInfo";
            this.userInfo.Size = new System.Drawing.Size(1352, 303);
            this.userInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.userInfo.TabIndex = 0;
            this.userInfo.TabStop = false;
            // 
            // MainMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "MainMenuView";
            this.Size = new System.Drawing.Size(1352, 661);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton btnBack;
        private CustomButton btnPrices;
        private CustomLabel lblWelcome;
        private PictureBox userInfo;
    }
}
