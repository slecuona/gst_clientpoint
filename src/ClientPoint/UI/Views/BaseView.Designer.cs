using System.Drawing;
using System.Windows.Forms;

namespace ClientPoint.UI.Panels {
    partial class PanelBase {
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
            this.panelContainer = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            //this.radPanel1.Size = new System.Drawing.Size(200, 100);
            this.panelContainer.TabIndex = 0;
            this.panelContainer.BackColor = Color.Transparent;
            this.panelContainer.Dock = DockStyle.Fill;
            // 
            // PanelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Size = new Size(1366, 768);
            this.Name = "PanelBase";
            this.BackColor = Color.Transparent;
            this.Dock = DockStyle.Fill;
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        protected Telerik.WinControls.UI.RadPanel panelContainer;
    }
}
