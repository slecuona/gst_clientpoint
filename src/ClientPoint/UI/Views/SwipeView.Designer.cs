using System.Windows.Forms;
using ClientPoint.UI.Controls;

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
            this.headerPanel1 = new ClientPoint.UI.HeaderPanel();
            this.btnBack = new CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            //this.imgBox.Dock = DockStyle.Fill;
            this.imgBox.BackColor = System.Drawing.Color.Transparent;
            this.imgBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imgBox.Image = global::ClientPoint.Properties.Resources.swipe_card;
            this.imgBox.Location = new System.Drawing.Point(0, 180);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(1366, 350);
            this.imgBox.TabIndex = 3;
            this.imgBox.TabStop = false;
            this.imgBox.Visible = false;
            imgBox.SizeMode = PictureBoxSizeMode.CenterImage;
            // 
            // headerPanel1
            // 
            this.headerPanel1.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel1.Location = new System.Drawing.Point(0, 0);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.Size = new System.Drawing.Size(1366, 80);
            this.headerPanel1.TabIndex = 4;
            this.headerPanel1.Title = "";
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
            // 
            // 
            this.panelContainer.Controls.Add(this.headerPanel1);
            this.panelContainer.Controls.Add(this.btnBack);
            this.panelContainer.Controls.Add(this.imgBox);
            this.Name = "StatusView";
            // 
            // 
            // 
            this.Text = "StatusView";
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox imgBox;
        private HeaderPanel headerPanel1;
        private CustomButton btnBack;
    }
}
