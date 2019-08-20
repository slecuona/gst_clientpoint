namespace ClientPoint.UI
{
    partial class FrmClientCreate {
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
            this.fldSex = new ClientPoint.UI.SexField();
            this.fldName = new ClientPoint.UI.CustomField();
            this.fldLastname = new ClientPoint.UI.CustomField();
            this.fldDocument = new ClientPoint.UI.CustomField();
            this.fldEmail = new ClientPoint.UI.CustomField();
            this.fldEmail2 = new ClientPoint.UI.CustomField();
            this.fldCellphone = new ClientPoint.UI.CustomField();
            this.fldPassword = new ClientPoint.UI.CustomField();
            this.fldPassword2 = new ClientPoint.UI.CustomField();
            this.fldBirthDate = new ClientPoint.UI.DateField();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // footerPanel
            // 
            this.footerPanel.Location = new System.Drawing.Point(0, 612);
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Location = new System.Drawing.Point(0, 7);
            this.radScrollablePanel1.Padding = new System.Windows.Forms.Padding(20);
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldBirthDate);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldSex);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldName);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldLastname);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldDocument);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldEmail);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldEmail2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldCellphone);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldPassword);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldPassword2);
            this.radScrollablePanel1.PanelContainer.Location = new System.Drawing.Point(20, 20);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(1326, 543);
            // 
            // fldName
            // 
            this.fldName.Label = "Nombre/s";
            this.fldName.Location = new System.Drawing.Point(35, 65);
            this.fldName.Name = "fldName";
            this.fldName.Password = false;
            this.fldName.Size = new System.Drawing.Size(615, 53);
            this.fldName.TabIndex = 0;
            this.fldName.Value = "";
            // 
            // fldLastname
            // 
            this.fldLastname.Label = "Apellido/s";
            this.fldLastname.Location = new System.Drawing.Point(35, 145);
            this.fldLastname.Name = "fldLastname";
            this.fldLastname.Password = false;
            this.fldLastname.Size = new System.Drawing.Size(615, 53);
            this.fldLastname.TabIndex = 1;
            this.fldLastname.Value = "";
            // 
            // fldDocument
            // 
            this.fldDocument.Label = "Nr. Documento";
            this.fldDocument.Location = new System.Drawing.Point(35, 230);
            this.fldDocument.Name = "fldDocument";
            this.fldDocument.Size = new System.Drawing.Size(615, 53);
            this.fldDocument.TabIndex = 4;
            this.fldDocument.Value = "";
            this.fldDocument.Visible = false;
            // 
            // fldSex
            // 
            this.fldSex.Location = new System.Drawing.Point(715, 65);
            this.fldSex.Name = "fldSex";
            this.fldSex.Size = new System.Drawing.Size(600, 50);
            this.fldSex.TabIndex = 7;
            this.fldSex.Value = null;
            // 
            // fldBirthDate
            // 
            this.fldBirthDate.Label = "Fecha Nacimiento";
            this.fldBirthDate.Location = new System.Drawing.Point(715, 145);
            this.fldBirthDate.Name = "fldBirthDate";
            this.fldBirthDate.Size = new System.Drawing.Size(600, 50);
            this.fldBirthDate.TabIndex = 8;
            this.fldBirthDate.Value = new System.DateTime(2019, 7, 30, 0, 0, 0, 0);

            // 
            // fldEmail
            // 
            this.fldEmail.Label = "Correo Electrónico";
            this.fldEmail.Location = new System.Drawing.Point(35, 65);
            this.fldEmail.Name = "fldEmail";
            this.fldEmail.Size = new System.Drawing.Size(650, 53);
            this.fldEmail.TabIndex = 3;
            this.fldEmail.Value = "";
            // 
            // fldEmail2
            // 
            this.fldEmail2.Label = "Repita Correo E.:";
            this.fldEmail2.Location = new System.Drawing.Point(35, 145);
            this.fldEmail2.Name = "fldEmail2";
            this.fldEmail2.Size = new System.Drawing.Size(650, 53);
            this.fldEmail2.TabIndex = 3;
            this.fldEmail2.Value = "";
            // 
            // fldCellphone
            // 
            this.fldCellphone.Label = "Nr. Celular";
            this.fldCellphone.Location = new System.Drawing.Point(35, 230);
            this.fldCellphone.Name = "fldCellphone";
            this.fldCellphone.Password = false;
            this.fldCellphone.Size = new System.Drawing.Size(615, 53);
            this.fldCellphone.TabIndex = 2;
            this.fldCellphone.Value = "";
            // 
            // fldPassword
            // 
            this.fldPassword.Label = "Contraseña";
            this.fldPassword.Location = new System.Drawing.Point(715, 65);
            this.fldPassword.Name = "fldPassword";
            this.fldPassword.Password = true;
            this.fldPassword.Size = new System.Drawing.Size(615, 53);
            this.fldPassword.TabIndex = 5;
            this.fldPassword.Value = "";
            // 
            // fldPassword2
            // 
            this.fldPassword2.Label = "Repita Contraseña";
            this.fldPassword2.Location = new System.Drawing.Point(715, 145);
            this.fldPassword2.Name = "fldPassword2";
            this.fldPassword2.Password = true;
            this.fldPassword2.Size = new System.Drawing.Size(615, 53);
            this.fldPassword2.TabIndex = 6;
            this.fldPassword2.Value = "";
            // 
            // FrmClientCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1386, 712);
            this.Name = "FrmClientCreate";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
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
