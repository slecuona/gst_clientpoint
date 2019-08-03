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
            this.fldPassword = new ClientPoint.UI.CustomField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();

            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldPassword);
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
            this.Name = "FrmPasswordInput";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion
        
        private CustomField fldPassword;
    }
}
