namespace ClientPoint.UI.Views
{
    partial class BaseViewDialogView {
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
            this.dialogPanel = new Telerik.WinControls.UI.RadScrollablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogPanel)).BeginInit();
            this.dialogPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.dialogPanel);
            this.panelContainer.Controls.Add(this.footerPanel);
            this.panelContainer.Size = new System.Drawing.Size(1366, 567);
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.Transparent;
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 447);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.footerPanel.Size = new System.Drawing.Size(1366, 120);
            this.footerPanel.TabIndex = 5;
            // 
            // containerPanel
            // 
            this.dialogPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dialogPanel.Location = new System.Drawing.Point(0, 0);
            this.dialogPanel.Name = "dialogPanel";
            this.dialogPanel.Padding = new System.Windows.Forms.Padding(20);
            // 
            // containerPanel.PanelContainer
            // 
            this.dialogPanel.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.dialogPanel.PanelContainer.Size = new System.Drawing.Size(1366, 568);
            this.dialogPanel.Size = new System.Drawing.Size(1366, 568);
            this.dialogPanel.TabIndex = 4;
            ((Telerik.WinControls.UI.RadScrollablePanelElement)(this.dialogPanel.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.dialogPanel.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // PanelBaseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "BaseViewDialogView";
            this.Size = new System.Drawing.Size(1366, 567);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogPanel)).EndInit();
            this.dialogPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion

        protected FooterPanel footerPanel;
        protected Telerik.WinControls.UI.RadScrollablePanel dialogPanel;
        
    }
}
