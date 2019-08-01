namespace ClientPoint.UI
{
    partial class FrmPasswordInput {
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
            this.footerPanel = new FooterPanel();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.fldPassword = new ClientPoint.UI.CustomField();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radScrollablePanel1.AutoScrollMargin = new System.Drawing.Size(0, 50);
            this.radScrollablePanel1.AutoScrollMinSize = new System.Drawing.Size(0, 50);
            this.radScrollablePanel1.Location = new System.Drawing.Point(400, 116);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            this.radScrollablePanel1.Padding = new System.Windows.Forms.Padding(0);
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.AutoScrollMargin = new System.Drawing.Size(0, 50);
            this.radScrollablePanel1.PanelContainer.AutoScrollMinSize = new System.Drawing.Size(0, 50);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldPassword);
            this.radScrollablePanel1.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(650, 443);
            this.radScrollablePanel1.Size = new System.Drawing.Size(650, 443);
            this.radScrollablePanel1.TabIndex = 4;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // fldPassword
            // 
            this.fldPassword.Label = "Contraseña";
            this.fldPassword.Location = new System.Drawing.Point(0, 0);
            this.fldPassword.Name = "fldPassword";
            this.fldPassword.Size = new System.Drawing.Size(615, 53);
            this.fldPassword.TabIndex = 0;
            // 
            // FrmPasswordInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 660);
            this.Controls.Add(this.radScrollablePanel1);
            this.Controls.Add(this.footerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPasswordInput";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion

        private FooterPanel footerPanel;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private CustomField fldPassword;
    }
}
