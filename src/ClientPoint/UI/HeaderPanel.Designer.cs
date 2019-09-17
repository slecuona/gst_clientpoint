using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;
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
            this.lblHost = new Telerik.WinControls.UI.RadLabel();
            this.lblGst = new Telerik.WinControls.UI.RadLabel();
            this.lblTitle = new Telerik.WinControls.UI.RadLabel();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            ((System.ComponentModel.ISupportInitialize)(this.lblHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lblImg
            // 
            this.lblHost.Location = new System.Drawing.Point(20, 20);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(120, 65);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "";
            this.lblHost.AutoSize = false;
            this.lblHost.Dock = DockStyle.None;
            this.lblHost.BackgroundImage = Properties.Resources.logo2;
            this.lblHost.BackgroundImageLayout = ImageLayout.None;
            this.lblHost.DoubleClick += LblHostOnDoubleClick;
            // 
            // LblGst
            // 
            this.lblGst.Location = new System.Drawing.Point(1200, 20);
            this.lblGst.Name = "lblHost";
            this.lblGst.Size = new System.Drawing.Size(120, 65);
            this.lblGst.TabIndex = 0;
            this.lblGst.Text = "";
            this.lblGst.AutoSize = false;
            this.lblGst.Dock = DockStyle.None;
            this.lblGst.BackgroundImage = Properties.Resources.logo2;
            this.lblGst.BackgroundImageLayout = ImageLayout.None;
            this.lblGst.Visible = false;
            // 
            // radLabel1
            // 
            //this.lblTitle.Location = new System.Drawing.Point(150, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 100);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "";
            this.lblTitle.Font = FontUtils.Roboto(15.75F);
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
            this.Controls.Add(lblHost);
            this.Controls.Add(lblGst);
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
            ((System.ComponentModel.ISupportInitialize)(this.lblHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblTitle;
        public Telerik.WinControls.UI.RadLabel lblHost;
        public Telerik.WinControls.UI.RadLabel lblGst;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
    }
}
