using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;

namespace ClientPoint.UI
{
    partial class FrmMainMenu {
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnConfirm = new ClientPoint.UI.CustomButton();
            this.btnCreate = new ClientPoint.UI.CustomButton();
            this.btnUpdate = new ClientPoint.UI.CustomButton();
            this.btnBack = new ClientPoint.UI.CustomButton();
            this.headerPanel1 = new ClientPoint.UI.HeaderPanel();
            this.imgSwipe = new System.Windows.Forms.PictureBox();
            this.lblSwipe = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSwipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSwipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radPanel1.BackColor = System.Drawing.Color.Transparent;
            this.radPanel1.Controls.Add(this.btnConfirm);
            this.radPanel1.Controls.Add(this.btnCreate);
            this.radPanel1.Controls.Add(this.btnUpdate);
            this.radPanel1.Controls.Add(this.btnBack);
            this.radPanel1.Location = new System.Drawing.Point(460, 129);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(400, 375);
            this.radPanel1.TabIndex = 3;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Image = global::ClientPoint.Properties.Resources.confirm;
            this.btnConfirm.Location = new System.Drawing.Point(0, 100);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnConfirm.Size = new System.Drawing.Size(400, 75);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "Confirmar";
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::ClientPoint.Properties.Resources.plus;
            this.btnCreate.Location = new System.Drawing.Point(0, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnCreate.Size = new System.Drawing.Size(400, 75);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.TabStop = false;
            this.btnCreate.Text = "Crear cuenta";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::ClientPoint.Properties.Resources.edit;
            this.btnUpdate.Location = new System.Drawing.Point(0, 200);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnUpdate.Size = new System.Drawing.Size(400, 75);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Actualizar datos";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Image = global::ClientPoint.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(0, 300);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnBack.Size = new System.Drawing.Size(400, 75);
            this.btnBack.TabIndex = 5;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Salir";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
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
            // imgSwipe
            // 
            this.imgSwipe.BackColor = System.Drawing.Color.Transparent;
            this.imgSwipe.Image = global::ClientPoint.Properties.Resources.swipe_card;
            this.imgSwipe.Location = new System.Drawing.Point(796, 159);
            this.imgSwipe.Name = "imgSwipe";
            this.imgSwipe.Size = new System.Drawing.Size(804, 433);
            this.imgSwipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgSwipe.TabIndex = 5;
            this.imgSwipe.TabStop = false;
            // 
            // lblSwipe
            // 
            this.lblSwipe.BackColor = System.Drawing.Color.Transparent;
            this.lblSwipe.Font = FontUtils.Roboto(14);
            this.lblSwipe.ForeColor = System.Drawing.Color.White;
            this.lblSwipe.Location = new System.Drawing.Point(1004, 220);
            this.lblSwipe.Name = "lblSwipe";
            this.lblSwipe.Size = new System.Drawing.Size(357, 53);
            this.lblSwipe.TabIndex = 6;
            this.lblSwipe.Text = "Si ya es cliente y tiene su tarjeta,\n        deslícela por el lector.";
            this.lblSwipe.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // FrmNewClientMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 648);
            this.Controls.Add(this.lblSwipe);
            this.Controls.Add(this.headerPanel1);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.imgSwipe);
            this.Name = "FrmMainMenu";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FrmNewUsr";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSwipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSwipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private CustomButton btnConfirm;
        private CustomButton btnUpdate;
        private CustomButton btnBack;
        private CustomButton btnCreate;
        private HeaderPanel headerPanel1;
        private PictureBox imgSwipe;
        private Telerik.WinControls.UI.RadLabel lblSwipe;
    }
}
