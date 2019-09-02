using System.Windows.Forms;

namespace ClientPoint.UI.Forms
{
    partial class FrmStatus {
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
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgBox.BackColor = System.Drawing.Color.Transparent;
            this.imgBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imgBox.Image = global::ClientPoint.Properties.Resources.print;
            this.imgBox.Location = new System.Drawing.Point(468, 125);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(400, 375);
            this.imgBox.TabIndex = 3;
            this.imgBox.TabStop = false;
            imgBox.SizeMode = PictureBoxSizeMode.CenterImage;
            // 
            // headerPanel1
            // 
            this.headerPanel1.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel1.Location = new System.Drawing.Point(0, 0);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.Size = new System.Drawing.Size(1341, 80);
            this.headerPanel1.TabIndex = 4;
            this.headerPanel1.Title = "";
            // 
            // FrmStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 648);
            this.Controls.Add(this.headerPanel1);
            this.Controls.Add(this.imgBox);
            this.Name = "FrmStatus";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FrmStatus";
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox imgBox;
        private HeaderPanel headerPanel1;
    }
}
