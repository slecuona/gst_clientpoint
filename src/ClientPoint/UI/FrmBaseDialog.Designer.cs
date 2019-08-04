namespace ClientPoint.UI
{
    partial class FrmBaseDialog {
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.footerPanel = new ClientPoint.UI.FooterPanel();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // footerPanel
            // 
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 598);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.footerPanel.Size = new System.Drawing.Size(1386, 100);
            this.footerPanel.TabIndex = 5;
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radScrollablePanel1.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            this.radScrollablePanel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Location = new System.Drawing.Point(20, 20);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(1326, 560);
            this.radScrollablePanel1.Size = new System.Drawing.Size(1366, 600);
            this.radScrollablePanel1.TabIndex = 4;
            ((Telerik.WinControls.UI.RadScrollablePanelElement)(this.radScrollablePanel1.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(20);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // FrmBaseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1386, 698);
            this.Controls.Add(this.radScrollablePanel1);
            this.Controls.Add(this.footerPanel);
            this.Name = "FrmBaseDialog";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion

        protected FooterPanel footerPanel;
        protected Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
    }
}
