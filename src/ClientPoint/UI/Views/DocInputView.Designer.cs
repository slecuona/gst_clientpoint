using System.Drawing;

namespace ClientPoint.UI.Views
{
    partial class DocumentInput {
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
            this.fldDocument = new ClientPoint.UI.CustomField();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerPanel)).BeginInit();
            this.containerPanel.PanelContainer.SuspendLayout();
            this.containerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            this.containerPanel.Controls.Add(this.fldDocument);
            // 
            // fldDocument
            // 
            this.fldDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.fldDocument.Label = "Nr. Documento";
            this.fldDocument.Location = new System.Drawing.Point(500, 110);
            this.fldDocument.Name = "fldDocument";
            this.fldDocument.Password = false;
            this.fldDocument.Size = new System.Drawing.Size(460, 53);
            this.fldDocument.TabIndex = 0;
            this.fldDocument.Value = "";
            // 
            // PanelDocumentInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "DocumentInput";
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.containerPanel.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.containerPanel)).EndInit();
            this.containerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion
        
        private CustomField fldDocument;
    }
}
