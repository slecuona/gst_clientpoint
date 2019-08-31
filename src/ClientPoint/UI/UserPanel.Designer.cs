using ClientPoint.Utils;

namespace ClientPoint.UI {
    partial class UserPanel {
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
            this.lblUsr = new Telerik.WinControls.UI.RadLabel();
            this.lblPoints = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.lblUsr.Location = new System.Drawing.Point(20, 30);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(100, 25);
            this.lblUsr.TabIndex = 0;
            this.lblUsr.Text = "";
            this.lblUsr.Font = FontUtils.Roboto(15.75F);
            // 
            // radLabel2
            // 
            this.lblPoints.Location = new System.Drawing.Point(20, 70);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(100, 25);
            this.lblPoints.TabIndex = 0;
            this.lblPoints.Text = "";
            this.lblPoints.Font = FontUtils.Roboto(15.75F);
            // 
            // UserPanel
            // 
            this.Controls.Add(lblUsr);
            this.Controls.Add(lblPoints);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Name = "userPanel";
            this.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.Size = new System.Drawing.Size(1340, 100);
            ((Telerik.WinControls.UI.RadPanelElement)(this.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.GetChildAt(0).GetChildAt(1))).Width = 0F;
            ((System.ComponentModel.ISupportInitialize)(this.lblUsr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblUsr;
        private Telerik.WinControls.UI.RadLabel lblPoints;
    }
}
