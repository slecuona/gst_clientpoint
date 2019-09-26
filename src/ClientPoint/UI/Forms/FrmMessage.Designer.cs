using ClientPoint.UI.Controls;
using ClientPoint.Utils;

namespace ClientPoint.UI.Forms
{
    partial class FrmMessage {
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
            this.lblMessage = new Telerik.WinControls.UI.RadLabel();
            this.lblIcon = new Telerik.WinControls.UI.RadLabel();
            this.btnOk = new CustomButtonWhiteRound();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(100, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(40, 55, 20, 20);
            this.lblMessage.Size = new System.Drawing.Size(62, 77);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblIcon
            // 
            this.lblIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon.Image = global::ClientPoint.Properties.Resources.info;
            this.lblIcon.Location = new System.Drawing.Point(20, 20);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(82, 82);
            this.lblIcon.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(150, 120);
            this.btnOk.Name = "btnOk";
            this.btnOk.TabIndex = 3;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "ACEPTAR";
            this.btnOk.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(186)))), ((int)(((byte)(226)))));
            //this.BackgroundImage = global::ClientPoint.Properties.Resources.bg_light;
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(516, 220);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblIcon);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMessage";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientPoint";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.lblMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private Telerik.WinControls.UI.RadLabel lblMessage;
        private Telerik.WinControls.UI.RadLabel lblIcon;
        private CustomButtonWhiteRound btnOk;
    }
}
