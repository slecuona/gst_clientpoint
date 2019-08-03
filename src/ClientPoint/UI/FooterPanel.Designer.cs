using System.Windows.Forms;
using Telerik.WinControls.Enumerations;

namespace ClientPoint.UI {
    partial class FooterPanel {
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
            this.btnNext = new ClientPoint.UI.CustomButton();
            this.btnBack = new ClientPoint.UI.CustomButton();
            this.waitingBar = new Telerik.WinControls.UI.RadWaitingBar();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::ClientPoint.Properties.Resources.confirm;
            this.btnNext.Location = new System.Drawing.Point(0, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnNext.Size = new System.Drawing.Size(400, 75);
            this.btnNext.TabIndex = 0;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "Siguiente";
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::ClientPoint.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnBack.Size = new System.Drawing.Size(400, 75);
            this.btnBack.TabIndex = 1;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Atrás";
            // 
            // radWaitingBar1
            // 
            this.waitingBar.Location = new System.Drawing.Point(650, 0);
            this.waitingBar.Name = "waitingBar";
            this.waitingBar.Size = new System.Drawing.Size(70, 70);
            this.waitingBar.TabIndex = 0;
            this.waitingBar.Text = "radWaitingBar1";
            this.waitingBar.WaitingStyle = WaitingBarStyles.LineRing;
            this.waitingBar.WaitingSpeed = 50;
            // 
            // FooterPanel
            // 
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.waitingBar);
            this.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Name = "footerPanel";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.Size = new System.Drawing.Size(1340, 100);
            ((Telerik.WinControls.UI.RadPanelElement)(this.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.GetChildAt(0).GetChildAt(1))).Width = 0F;
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton btnNext;
        private CustomButton btnBack;
        private Telerik.WinControls.UI.RadWaitingBar waitingBar;
    }
}
