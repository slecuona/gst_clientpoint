using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Enumerations;

namespace ClientPoint.UI {
    partial class HeaderPanel {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblImg = new Telerik.WinControls.UI.RadLabel();
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            ((System.ComponentModel.ISupportInitialize)(this.lblImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblImg
            // 
            this.lblImg.Location = new System.Drawing.Point(20, 20);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(120, 65);
            this.lblImg.TabIndex = 0;
            this.lblImg.Text = "";
            this.lblImg.AutoSize = false;
            this.lblImg.Dock = DockStyle.None;
            this.lblImg.BackgroundImage = Properties.Resources.logo;
            this.lblImg.BackgroundImageLayout = ImageLayout.None;
            this.lblImg.DoubleClick += LblImgOnDoubleClick;
            // 
            // radLabel1
            // 
            //this.lblTitle.Location = new System.Drawing.Point(150, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 100);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "";
            this.lblTitle.Font = Config.DefaultFont;
            this.lblTitle.AutoSize = false;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.TextAlignment = ContentAlignment.BottomCenter;
            this.lblTitle.ForeColor = Color.White;
            // 
            // radWaitingBar1
            // 
            this.waitingBar.Location = new System.Drawing.Point(1270, 10);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Size = new System.Drawing.Size(70, 70);
            this.waitingBar.TabIndex = 0;
            this.waitingBar.Text = "radWaitingBar1";
            this.waitingBar.WaitingStyle = WaitingBarStyles.LineRing;
            this.waitingBar.WaitingSpeed = 50;
            // 
            // HeaderPanel
            // 
            this.Controls.Add(lblImg);
            this.Controls.Add(this.waitingBar);
            this.Controls.Add(lblTitle);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Name = "footerPanel";
            //this.Padding = new System.Windows.Forms.Padding(50, 50, 50, 50);
            this.Size = new System.Drawing.Size(1340, 80);
            this.BackColor = Color.Transparent;
            ((Telerik.WinControls.UI.RadPanelElement)(this.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.GetChildAt(0).GetChildAt(1))).Width = 0F;
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        private Telerik.WinControls.UI.RadLabel lblImg;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
    }
}
