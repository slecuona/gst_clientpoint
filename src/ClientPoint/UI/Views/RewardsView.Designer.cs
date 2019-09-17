using System.Drawing;
using System.Windows.Forms;
using ClientPoint.UI.Controls;
using ClientPoint.Utils;
using Telerik.WinControls.Primitives;

namespace ClientPoint.UI.Views
{
    partial class RewardsView {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RewardsView));
            this.headerPanel1 = new ClientPoint.UI.HeaderPanel();
            this.btnBack = new ClientPoint.UI.Controls.CustomButton();
            this.btnAll = new ClientPoint.UI.Controls.CustomButtonWhite();
            this.btnPrev = new ClientPoint.UI.Controls.CustomButtonArrow();
            this.btnNext = new ClientPoint.UI.Controls.CustomButtonArrow();
            this.container = new System.Windows.Forms.PictureBox();
            this.lblPages = new Telerik.WinControls.UI.RadLabel();
            this.categoryPanel = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.container)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPages)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.lblPages);
            this.panelContainer.Controls.Add(this.container);
            this.panelContainer.Controls.Add(this.btnPrev);
            this.panelContainer.Controls.Add(this.btnNext);
            this.panelContainer.Controls.Add(this.headerPanel1);
            this.panelContainer.Controls.Add(this.btnBack);
            this.panelContainer.Controls.Add(this.categoryPanel);
            this.panelContainer.Size = new System.Drawing.Size(1352, 661);
            // 
            // headerPanel1
            // 
            this.headerPanel1.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel1.Location = new System.Drawing.Point(0, 0);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.Size = new System.Drawing.Size(1352, 80);
            this.headerPanel1.TabIndex = 4;
            this.headerPanel1.Title = "";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.Location = new System.Drawing.Point(30, 670);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(234, 78);
            this.btnBack.TabIndex = 1;
            this.btnBack.TabStop = false;
            this.btnBack.Type = ClientPoint.UI.Controls.Type.Back;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAll.Location = new System.Drawing.Point(0, 0);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(240, 89);
            this.btnAll.TabIndex = 5;
            this.btnAll.TabStop = false;
            this.btnAll.Text = "TODOS";
            // 
            // categoryPanel
            // 
            this.categoryPanel.BackColor = System.Drawing.Color.Transparent;
            this.categoryPanel.Location = new System.Drawing.Point(31, 115);
            this.categoryPanel.Size = new Size(240, 600);
            this.categoryPanel.Name = "categoryPanel";
            ((BorderPrimitive)(categoryPanel.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Location = new System.Drawing.Point(298, 695);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(152, 60);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.TabStop = false;
            this.btnPrev.Text = "ANTERIOR";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(1193, 695);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(152, 60);
            this.btnNext.TabIndex = 6;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "SIGUIENTE  ";
            // 
            // container
            // 
            this.container.Image = global::ClientPoint.Properties.Resources.bg_rewards;
            this.container.Location = new System.Drawing.Point(306, 115);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1040, 560);
            this.container.TabIndex = 7;
            this.container.TabStop = false;
            // 
            // lblPages
            // 
            this.lblPages.Location = new System.Drawing.Point(770, 705);
            this.lblPages.Name = "lblPages";
            this.lblPages.Font = FontUtils.Roboto(16, FontStyle.Bold);
            this.lblPages.ForeColor = Color.White;
            this.lblPages.Size = new System.Drawing.Size(55, 18);
            this.lblPages.TabIndex = 8;
            this.lblPages.Text = "";
            // 
            // RewardsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "RewardsView";
            this.Size = new System.Drawing.Size(1352, 661);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.container)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private HeaderPanel headerPanel1;
        private CustomButton btnBack;
        private Telerik.WinControls.UI.RadPanel categoryPanel;
        private CustomButtonWhite btnAll;
        private CustomButtonArrow btnPrev;
        private CustomButtonArrow btnNext;
        private PictureBox container;
        private Telerik.WinControls.UI.RadLabel lblPages;
    }
}
