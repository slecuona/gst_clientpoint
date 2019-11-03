using System.Drawing;
using System.Windows.Forms;

namespace ClientPoint.UI.Views {
    partial class BaseView {
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
            this.headerPanel = new ClientPoint.UI.HeaderPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            //
            this.panelContainer.Controls.Add(this.headerPanel);
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            //this.radPanel1.Size = new System.Drawing.Size(200, 100);
            this.panelContainer.TabIndex = 0;
            this.panelContainer.BackColor = Color.Transparent;
            this.panelContainer.Dock = DockStyle.Fill;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.panelContainer.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20, 40, 20, 0);
            this.headerPanel.Size = new System.Drawing.Size(1366, 80);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.Title = "";
            // 
            // PanelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Size = new Size(1366, 768);
            this.Name = "BaseView";
            this.BackColor = Color.Transparent;
            this.Dock = DockStyle.Fill;
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        protected Telerik.WinControls.UI.RadPanel panelContainer;
        protected HeaderPanel headerPanel;
    }
}
