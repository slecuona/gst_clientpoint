using System.Drawing;
using System.Windows.Forms;

namespace ClientPoint.UI
{
    partial class FrmAddUsr {
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
            this.fldSex = new ClientPoint.UI.SexField();
            this.fldName = new ClientPoint.UI.CustomField();
            this.fldLastname = new ClientPoint.UI.CustomField();
            this.fldDocument = new ClientPoint.UI.CustomMaskedField();
            this.fldEmail = new ClientPoint.UI.CustomMaskedField();
            this.fldCellphone = new ClientPoint.UI.CustomField();
            this.fldPassword = new ClientPoint.UI.CustomField();
            this.fldPassword2 = new ClientPoint.UI.CustomField();
            this.fldBirthDate = new ClientPoint.UI.DateField();
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
            this.radScrollablePanel1.Location = new System.Drawing.Point(85, 116);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            this.radScrollablePanel1.Padding = new System.Windows.Forms.Padding(0);
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.AutoScrollMargin = new System.Drawing.Size(0, 50);
            this.radScrollablePanel1.PanelContainer.AutoScrollMinSize = new System.Drawing.Size(0, 50);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldBirthDate);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldSex);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldName);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldLastname);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldDocument);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldEmail);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldCellphone);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldPassword);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldPassword2);
            this.radScrollablePanel1.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(1335, 443);
            this.radScrollablePanel1.Size = new System.Drawing.Size(1335, 443);
            this.radScrollablePanel1.TabIndex = 4;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // sexField1
            // 
            this.fldSex.Location = new System.Drawing.Point(0, 270);
            this.fldSex.Name = "fldSex";
            this.fldSex.Size = new System.Drawing.Size(600, 50);
            this.fldSex.TabIndex = 7;
            // 
            // fldName
            // 
            this.fldName.Label = "Nombre/s";
            this.fldName.Location = new System.Drawing.Point(0, 0);
            this.fldName.Name = "fldName";
            this.fldName.Size = new System.Drawing.Size(615, 53);
            this.fldName.TabIndex = 0;
            // 
            // fldLastname
            // 
            this.fldLastname.Label = "Apellido/s";
            this.fldLastname.Location = new System.Drawing.Point(0, 90);
            this.fldLastname.Name = "fldLastname";
            this.fldLastname.Size = new System.Drawing.Size(615, 53);
            this.fldLastname.TabIndex = 1;
            // 
            // fldDocument
            // 
            this.fldDocument.CustomMaskType = ClientPoint.UI.CustomMaskType.Email;
            this.fldDocument.Label = "Nr. Documento";
            this.fldDocument.Location = new System.Drawing.Point(0, 180);
            this.fldDocument.Name = "fldDocument";
            this.fldDocument.Size = new System.Drawing.Size(615, 53);
            this.fldDocument.TabIndex = 4;
            // 
            // fldEmail
            // 
            this.fldEmail.CustomMaskType = ClientPoint.UI.CustomMaskType.Email;
            this.fldEmail.Label = "Correo Electrónico";
            this.fldEmail.Location = new System.Drawing.Point(680, 0);
            this.fldEmail.Name = "fldEmail";
            this.fldEmail.Size = new System.Drawing.Size(650, 53);
            this.fldEmail.TabIndex = 3;
            // 
            // fldCellphone
            // 
            this.fldCellphone.Label = "Nr. Celular";
            this.fldCellphone.Location = new System.Drawing.Point(680, 90);
            this.fldCellphone.Name = "fldCellphone";
            this.fldCellphone.Size = new System.Drawing.Size(615, 53);
            this.fldCellphone.TabIndex = 2;
            // 
            // fldPasword
            // 
            this.fldPassword.Label = "Contraseña";
            this.fldPassword.Location = new System.Drawing.Point(680, 180);
            this.fldPassword.Name = "fldPassword";
            this.fldPassword.Size = new System.Drawing.Size(615, 53);
            this.fldPassword.TabIndex = 5;
            // 
            // fldPassword2
            // 
            this.fldPassword2.Label = "Repita Contraseña";
            this.fldPassword2.Location = new System.Drawing.Point(680, 270);
            this.fldPassword2.Name = "fldPassword2";
            this.fldPassword2.Size = new System.Drawing.Size(615, 53);
            this.fldPassword2.TabIndex = 6;
            // 
            // dateField1
            // 
            this.fldBirthDate.Location = new System.Drawing.Point(0, 334);
            this.fldBirthDate.Name = "fldBirthDate";
            this.fldBirthDate.Size = new System.Drawing.Size(600, 50);
            this.fldBirthDate.TabIndex = 8;
            this.fldBirthDate.Label = "Fecha Nacimiento";
            // 
            // FrmAddUsr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 660);
            this.Controls.Add(this.radScrollablePanel1);
            this.Controls.Add(this.footerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddUsr";
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
        private CustomField fldName;
        private CustomField fldLastname;
        private CustomMaskedField fldDocument;
        private CustomMaskedField fldEmail;
        private CustomField fldCellphone;
        private CustomField fldPassword;
        private CustomField fldPassword2;
        private SexField fldSex;
        private DateField fldBirthDate;
    }
}
