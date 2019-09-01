namespace ClientPoint.UI.Views
{
    partial class ClientUpdateView {
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
            this.fldEmail = new ClientPoint.UI.CustomField();
            this.fldCellphone = new ClientPoint.UI.CustomField();
            this.SuspendLayout();
            this.containerPanel.Controls.Add(this.fldEmail);
            this.containerPanel.Controls.Add(this.fldCellphone);
            // 
            // fldEmail
            // 
            this.fldEmail.Label = "Correo Electrónico";
            this.fldEmail.Location = new System.Drawing.Point(350, 120);
            this.fldEmail.Name = "fldEmail";
            this.fldEmail.Size = new System.Drawing.Size(650, 53);
            this.fldEmail.TabIndex = 3;
            this.fldEmail.Keyboard = Keyboard.AlphaNum;
            // 
            // fldCellphone
            // 
            this.fldCellphone.Label = "Nr. Celular";
            this.fldCellphone.Location = new System.Drawing.Point(350, 207);
            this.fldCellphone.Name = "fldCellphone";
            this.fldCellphone.Password = false;
            this.fldCellphone.Size = new System.Drawing.Size(615, 53);
            this.fldCellphone.TabIndex = 2;
            this.fldCellphone.Value = "";
            this.fldCellphone.Keyboard = Keyboard.Num;

            this.Name = "ClientUpdateView";
            // 
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion
        
        private CustomField fldEmail;
        private CustomField fldCellphone;
    }
}
