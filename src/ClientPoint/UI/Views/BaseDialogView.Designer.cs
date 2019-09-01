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
            this.containerPanel = new Telerik.WinControls.UI.RadScrollablePanel();
            this.headerPanel = new ClientPoint.UI.HeaderPanel();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerPanel)).BeginInit();
            this.containerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.headerPanel);
            this.panelContainer.Controls.Add(this.containerPanel);
            this.panelContainer.Controls.Add(this.footerPanel);
            this.panelContainer.Size = new System.Drawing.Size(1302, 567);
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.Transparent;
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 447);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.footerPanel.Size = new System.Drawing.Size(1302, 120);
            this.footerPanel.TabIndex = 5;
            // 
            // containerPanel
            // 
            this.containerPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.containerPanel.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Padding = new System.Windows.Forms.Padding(20);
            // 
            // containerPanel.PanelContainer
            // 
            this.containerPanel.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.containerPanel.PanelContainer.Size = new System.Drawing.Size(1366, 600);
            this.containerPanel.Size = new System.Drawing.Size(1366, 600);
            this.containerPanel.TabIndex = 4;
            ((Telerik.WinControls.UI.RadScrollablePanelElement)(this.containerPanel.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.containerPanel.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20, 40, 20, 0);
            this.headerPanel.Size = new System.Drawing.Size(1302, 80);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.Title = "";
            // 
            // PanelBaseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "BaseViewDialogView";
            this.Size = new System.Drawing.Size(1302, 567);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerPanel)).EndInit();
            this.containerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion

        protected FooterPanel footerPanel;
        protected Telerik.WinControls.UI.RadScrollablePanel containerPanel;
        protected HeaderPanel headerPanel;
    }
}
