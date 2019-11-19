using System.Drawing;
using System.Windows.Forms;
using ClientPoint.UI.Controls;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Views
{
    partial class SwipeView {
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
        private void InitializeComponent()
        {
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.btnBack = new CustomButton();
            this.imgHost = new RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHost)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            //this.imgBox.Dock = DockStyle.Fill;
            this.imgBox.BackColor = System.Drawing.Color.Transparent;
            this.imgBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imgBox.Image = global::ClientPoint.Properties.Resources.swipe_card;
            this.imgBox.Location = new System.Drawing.Point(1050, 180);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(250, 400);
            this.imgBox.TabIndex = 3;
            this.imgBox.TabStop = false;
            this.imgBox.Visible = false;
            imgBox.SizeMode = PictureBoxSizeMode.CenterImage;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(550, 650);
            this.btnBack.Name = "btnBack";
            this.btnBack.TabIndex = 1;
            this.btnBack.TabStop = false;
            this.btnBack.Type = Type.Back;
            this.btnBack.Click += BtnBackOnClick;
            // 
            // imgHost
            // 
            this.imgHost.Location = new System.Drawing.Point(300, 200);
            this.imgHost.Size = new Size(480, 300);
            this.imgHost.Name = "imgHost";
            this.imgHost.TabIndex = 1;
            this.imgHost.TabStop = false;
            this.imgHost.AutoSize = false;
            this.imgHost.BackgroundImage = Config.HostLogo;
            this.imgHost.BackgroundImageLayout = ImageLayout.Center;
            // 
            // 
            // 
            this.panelContainer.Controls.Add(this.btnBack);
            this.panelContainer.Controls.Add(this.imgBox);
            this.panelContainer.Controls.Add(this.imgHost);
            this.Name = "StatusView";
            // 
            // 
            // 
            this.Text = "StatusView";
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox imgBox;
        private CustomButton btnBack;
        private RadLabel imgHost;
    }
}
