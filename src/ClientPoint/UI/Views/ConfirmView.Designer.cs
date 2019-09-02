using ClientPoint.UI.Controls;

namespace ClientPoint.UI.Views
{
    partial class ConfirmView {
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
            this.fldCode = new CustomField();
            this.SuspendLayout();
            this.panelContainer.Controls.Add(fldCode);
            // 
            // fldCode
            // 
            this.fldCode.Label = "Código";
            this.fldCode.Location = new System.Drawing.Point(350, 110);
            this.fldCode.Name = "fldCode";
            this.fldCode.Size = new System.Drawing.Size(615, 53);
            this.fldCode.TabIndex = 2;
            // 
            this.Name = "ConfirmView";
            // 
            // 
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion
        
        private CustomField fldCode;
    }
}
