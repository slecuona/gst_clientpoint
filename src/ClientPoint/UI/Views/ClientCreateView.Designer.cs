using ClientPoint.UI.Controls;

namespace ClientPoint.UI.Views
{
    partial class ClientCreateView {
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
            this.fldSex = new SexField();
            this.fldName = new CustomField();
            this.fldLastname = new CustomField();
            this.fldDocument = new CustomField();
            this.fldEmail = new CustomField();
            this.fldEmail2 = new CustomField();
            this.fldCellphone = new CustomField();
            this.fldPassword = new CustomField();
            this.fldPassword2 = new CustomField();
            this.fldBirthDate = new DateField();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.SuspendLayout();

            this.containerPanel.Controls.Add(this.fldName);
            this.containerPanel.Controls.Add(this.fldLastname);
            this.containerPanel.Controls.Add(this.fldDocument);
            this.containerPanel.Controls.Add(this.fldSex);
            this.containerPanel.Controls.Add(this.fldEmail);
            this.containerPanel.Controls.Add(this.fldEmail2);
            this.containerPanel.Controls.Add(this.fldCellphone);
            this.containerPanel.Controls.Add(this.fldPassword);
            this.containerPanel.Controls.Add(this.fldPassword2);
            this.containerPanel.Controls.Add(this.fldBirthDate);

            // 
            // fldName
            // 
            this.fldName.Label = "Nombre/s";
            this.fldName.Location = new System.Drawing.Point(35, 30);
            this.fldName.Name = "fldName";
            this.fldName.Password = false;
            this.fldName.Size = new System.Drawing.Size(615, 53);
            this.fldName.TabIndex = 0;
            this.fldName.Value = "";
            this.fldName.Keyboard = Keyboard.AlphaNum;
            // 
            // fldLastname
            // 
            this.fldLastname.Label = "Apellido/s";
            this.fldLastname.Location = new System.Drawing.Point(35, 110);
            this.fldLastname.Name = "fldLastname";
            this.fldLastname.Password = false;
            this.fldLastname.Size = new System.Drawing.Size(615, 53);
            this.fldLastname.TabIndex = 1;
            this.fldLastname.Value = "";
            this.fldLastname.Keyboard = Keyboard.AlphaNum;
            // 
            // fldDocument
            // 
            this.fldDocument.Label = "Nr. Documento";
            this.fldDocument.Location = new System.Drawing.Point(35, 195);
            this.fldDocument.Name = "fldDocument";
            this.fldDocument.Size = new System.Drawing.Size(615, 53);
            this.fldDocument.TabIndex = 4;
            this.fldDocument.Value = "";
            this.fldDocument.Visible = false;
            // 
            // fldSex
            // 
            this.fldSex.Location = new System.Drawing.Point(715, 30);
            this.fldSex.Name = "fldSex";
            this.fldSex.Size = new System.Drawing.Size(600, 50);
            this.fldSex.TabIndex = 7;
            this.fldSex.Value = null;
            // 
            // fldBirthDate
            // 
            this.fldBirthDate.Label = "Fecha Nacimiento";
            this.fldBirthDate.Location = new System.Drawing.Point(715, 110);
            this.fldBirthDate.Name = "fldBirthDate";
            this.fldBirthDate.Size = new System.Drawing.Size(600, 50);
            this.fldBirthDate.TabIndex = 8;
            this.fldBirthDate.Value = new System.DateTime(2019, 7, 30, 0, 0, 0, 0);

            // 
            // fldEmail
            // 
            this.fldEmail.Label = "Correo Electrónico";
            this.fldEmail.Location = new System.Drawing.Point(35, 30);
            this.fldEmail.Name = "fldEmail";
            this.fldEmail.Size = new System.Drawing.Size(650, 53);
            this.fldEmail.TabIndex = 3;
            this.fldEmail.Value = "";
            this.fldEmail.Keyboard = Keyboard.AlphaNum;
            // 
            // fldEmail2
            // 
            this.fldEmail2.Label = "Repita Correo E.:";
            this.fldEmail2.Location = new System.Drawing.Point(35, 110);
            this.fldEmail2.Name = "fldEmail2";
            this.fldEmail2.Size = new System.Drawing.Size(650, 53);
            this.fldEmail2.TabIndex = 3;
            this.fldEmail2.Value = "";
            this.fldEmail2.Keyboard = Keyboard.AlphaNum;
            // 
            // fldCellphone
            // 
            this.fldCellphone.Label = "Nr. Celular";
            this.fldCellphone.Location = new System.Drawing.Point(35, 195);
            this.fldCellphone.Name = "fldCellphone";
            this.fldCellphone.Password = false;
            this.fldCellphone.Size = new System.Drawing.Size(615, 53);
            this.fldCellphone.TabIndex = 2;
            this.fldCellphone.Value = "";
            this.fldCellphone.Keyboard = Keyboard.Num;
            // 
            // fldPassword
            // 
            this.fldPassword.Label = "Contraseña";
            this.fldPassword.Location = new System.Drawing.Point(715, 30);
            this.fldPassword.Name = "fldPassword";
            this.fldPassword.Password = true;
            this.fldPassword.Size = new System.Drawing.Size(615, 53);
            this.fldPassword.TabIndex = 5;
            this.fldPassword.Value = "";
            this.fldPassword.Keyboard = Keyboard.AlphaNum;
            // 
            // fldPassword2
            // 
            this.fldPassword2.Label = "Repita Contraseña";
            this.fldPassword2.Location = new System.Drawing.Point(715, 110);
            this.fldPassword2.Name = "fldPassword2";
            this.fldPassword2.Password = true;
            this.fldPassword2.Size = new System.Drawing.Size(615, 53);
            this.fldPassword2.TabIndex = 6;
            this.fldPassword2.Value = "";
            this.fldPassword2.Keyboard = Keyboard.AlphaNum;

            this.Name = "ClientCreateView";
            // 
            // 
            // 
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion
        
        private CustomField fldName;
        private CustomField fldLastname;
        private CustomField fldDocument;
        private CustomField fldEmail;
        private CustomField fldEmail2;
        private CustomField fldCellphone;
        private CustomField fldPassword;
        private CustomField fldPassword2;
        private SexField fldSex;
        private DateField fldBirthDate;
    }
}
