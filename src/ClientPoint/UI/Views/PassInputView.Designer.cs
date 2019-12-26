using ClientPoint.UI.Controls;

namespace ClientPoint.UI.Views
{
    partial class PassInputView {
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
            this.fldPassword = new CustomField();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.dialogPanel.Controls.Add(this.fldPassword);
            // 
            // fldPassword
            // 
            this.fldPassword.Label = "Contraseña";
            this.fldPassword.Location = new System.Drawing.Point(350, 100);
            this.fldPassword.Name = "fldPassword";
            this.fldPassword.Password = false;
            this.fldPassword.Size = new System.Drawing.Size(650, 53);
            this.fldPassword.TabIndex = 0;
            this.fldPassword.Value = "";

            this.Name = "PassInputView";
            // 
            // 
            // 
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion
        
        private CustomField fldPassword;
    }
}
