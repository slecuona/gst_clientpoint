using System.Drawing;
using System.Windows.Forms;
using ClientPoint.UI.Controls;
using ClientPoint.Utils;

namespace ClientPoint.UI.Forms
{
    partial class FrmRewardModal {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRewardModal));
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.lblImage = new Telerik.WinControls.UI.RadLabel();
            this.lblCategory = new Telerik.WinControls.UI.RadLabel();
            this.lblPointsCurr = new Telerik.WinControls.UI.RadLabel();
            this.lblPointsReq = new Telerik.WinControls.UI.RadLabel();
            this.lblPointsAfter = new Telerik.WinControls.UI.RadLabel();
            this.lblPointsCurrVal = new Telerik.WinControls.UI.RadLabel();
            this.lblQuantity = new Telerik.WinControls.UI.RadLabel();
            this.lblPointsReqVal = new Telerik.WinControls.UI.RadLabel();
            this.lblPointsAfterVal = new Telerik.WinControls.UI.RadLabel();
            this.btnPlus = new ClientPoint.UI.Controls.CustomButtonCount();
            this.btnMinus = new ClientPoint.UI.Controls.CustomButtonCount();
            this.picBox1 = new ClientPoint.UI.Controls.PicBox();
            this.btnCancel = new ClientPoint.UI.Controls.CustomButtonWhiteRound();
            this.btnConfirm = new ClientPoint.UI.Controls.CustomButtonWhite();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsCurr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsCurrVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsReqVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsAfterVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(20);
            this.lblTitle.Size = new System.Drawing.Size(620, 63);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "NOMBRE PREMIO";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = false;
            this.lblImage.BackColor = System.Drawing.Color.Transparent;
            this.lblImage.BackgroundImage = global::ClientPoint.Properties.Resources.bg_rewards;
            this.lblImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lblImage.Location = new System.Drawing.Point(20, 20);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(547, 252);
            this.lblImage.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = false;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCategory.ForeColor = System.Drawing.Color.White;
            this.lblCategory.Location = new System.Drawing.Point(0, 328);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Padding = new System.Windows.Forms.Padding(20);
            this.lblCategory.Size = new System.Drawing.Size(620, 63);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "CATEGORIA";
            this.lblCategory.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointsCurr
            // 
            this.lblPointsCurr.AutoSize = false;
            this.lblPointsCurr.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsCurr.ForeColor = System.Drawing.Color.White;
            this.lblPointsCurr.Location = new System.Drawing.Point(18, 395);
            this.lblPointsCurr.Name = "lblPointsCurr";
            this.lblPointsCurr.Size = new System.Drawing.Size(228, 17);
            this.lblPointsCurr.TabIndex = 3;
            this.lblPointsCurr.Text = "PUNTOS ACTUALES";
            // 
            // lblPointsReq
            // 
            this.lblPointsReq.AutoSize = false;
            this.lblPointsReq.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsReq.ForeColor = System.Drawing.Color.White;
            this.lblPointsReq.Location = new System.Drawing.Point(18, 422);
            this.lblPointsReq.Name = "lblPointsReq";
            this.lblPointsReq.Size = new System.Drawing.Size(228, 17);
            this.lblPointsReq.TabIndex = 4;
            this.lblPointsReq.Text = "PUNTOS REQUERIDOS";
            // 
            // lblPointsAfter
            // 
            this.lblPointsAfter.AutoSize = false;
            this.lblPointsAfter.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsAfter.ForeColor = System.Drawing.Color.White;
            this.lblPointsAfter.Location = new System.Drawing.Point(18, 449);
            this.lblPointsAfter.Name = "lblPointsAfter";
            this.lblPointsAfter.Size = new System.Drawing.Size(224, 17);
            this.lblPointsAfter.TabIndex = 5;
            this.lblPointsAfter.Text = "SALDO";
            // 
            // lblPointsCurrVal
            // 
            this.lblPointsCurrVal.AutoSize = false;
            this.lblPointsCurrVal.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsCurrVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsCurrVal.ForeColor = System.Drawing.Color.White;
            this.lblPointsCurrVal.Location = new System.Drawing.Point(235, 392);
            this.lblPointsCurrVal.Name = "lblPointsCurrVal";
            this.lblPointsCurrVal.Size = new System.Drawing.Size(84, 17);
            this.lblPointsCurrVal.TabIndex = 4;
            this.lblPointsCurrVal.Text = "147";
            this.lblPointsCurrVal.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCount
            // 
            this.lblQuantity.AutoSize = false;
            this.lblQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.White;
            this.lblQuantity.Location = new System.Drawing.Point(391, 397);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(175, 66);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "1";
            this.lblQuantity.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointsReqVal
            // 
            this.lblPointsReqVal.AutoSize = false;
            this.lblPointsReqVal.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsReqVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsReqVal.ForeColor = System.Drawing.Color.White;
            this.lblPointsReqVal.Location = new System.Drawing.Point(247, 419);
            this.lblPointsReqVal.Name = "lblPointsReqVal";
            this.lblPointsReqVal.Size = new System.Drawing.Size(71, 17);
            this.lblPointsReqVal.TabIndex = 5;
            this.lblPointsReqVal.Text = "-20";
            this.lblPointsReqVal.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPointsAfterVal
            // 
            this.lblPointsAfterVal.AutoSize = false;
            this.lblPointsAfterVal.BackColor = System.Drawing.Color.Transparent;
            this.lblPointsAfterVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsAfterVal.ForeColor = System.Drawing.Color.White;
            this.lblPointsAfterVal.Location = new System.Drawing.Point(248, 446);
            this.lblPointsAfterVal.Name = "lblPointsAfterVal";
            this.lblPointsAfterVal.Size = new System.Drawing.Size(71, 17);
            this.lblPointsAfterVal.TabIndex = 6;
            this.lblPointsAfterVal.Text = "107";
            this.lblPointsAfterVal.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.Transparent;
            this.btnPlus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(186)))), ((int)(((byte)(226)))));
            this.btnPlus.Image = ((System.Drawing.Image)(resources.GetObject("btnPlus.Image")));
            this.btnPlus.Location = new System.Drawing.Point(505, 387);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Plus = false;
            this.btnPlus.Size = new System.Drawing.Size(96, 89);
            this.btnPlus.TabIndex = 7;
            this.btnPlus.TabStop = false;
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.Transparent;
            this.btnMinus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(186)))), ((int)(((byte)(226)))));
            this.btnMinus.Image = ((System.Drawing.Image)(resources.GetObject("btnMinus.Image")));
            this.btnMinus.Location = new System.Drawing.Point(359, 388);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Plus = false;
            this.btnMinus.Size = new System.Drawing.Size(96, 89);
            this.btnMinus.TabIndex = 6;
            this.btnMinus.TabStop = false;
            // 
            // picBox1
            // 
            this.picBox1.BackColor = System.Drawing.Color.White;
            this.picBox1.Location = new System.Drawing.Point(18, 62);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(578, 279);
            this.picBox1.TabIndex = 5;
            this.picBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(186)))), ((int)(((byte)(226)))));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(12, 485);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(234, 78);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "CANCELAR";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.Checked = true;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.Location = new System.Drawing.Point(362, 487);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(234, 78);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "CONFIRMAR";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfim_Click);
            // 
            // FrmRewardModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(186)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(600, 574);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblPointsAfterVal);
            this.Controls.Add(this.lblPointsReqVal);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.lblPointsCurrVal);
            this.Controls.Add(this.lblPointsAfter);
            this.Controls.Add(this.lblPointsReq);
            this.Controls.Add(this.lblPointsCurr);
            this.Controls.Add(this.picBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblQuantity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRewardModal";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsCurr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsCurrVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsReqVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPointsAfterVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private Telerik.WinControls.UI.RadLabel lblTitle;
        private Telerik.WinControls.UI.RadLabel lblImage;
        private CustomButtonWhite btnConfirm;
        private CustomButtonWhiteRound btnCancel;
        private PicBox picBox1;
        private Telerik.WinControls.UI.RadLabel lblCategory;
        private Telerik.WinControls.UI.RadLabel lblPointsCurr;
        private Telerik.WinControls.UI.RadLabel lblPointsReq;
        private Telerik.WinControls.UI.RadLabel lblPointsAfter;
        private Telerik.WinControls.UI.RadLabel lblPointsCurrVal;
        private CustomButtonCount btnMinus;
        private CustomButtonCount btnPlus;
        private Telerik.WinControls.UI.RadLabel lblQuantity;
        private Telerik.WinControls.UI.RadLabel lblPointsReqVal;
        private Telerik.WinControls.UI.RadLabel lblPointsAfterVal;
    }
}
