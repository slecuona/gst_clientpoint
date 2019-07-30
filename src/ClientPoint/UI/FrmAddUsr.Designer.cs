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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnBack = new ClientPoint.UI.CustomButton();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.fldName = new ClientPoint.UI.CustomField();
            this.fldLastname = new ClientPoint.UI.CustomField();
            this.fldDocument = new ClientPoint.UI.CustomField();
            this.fldEmail = new ClientPoint.UI.CustomField();
            this.fldCellphone = new ClientPoint.UI.CustomField();
            this.fldPasword = new ClientPoint.UI.CustomField();
            this.fldPassword2 = new ClientPoint.UI.CustomField();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnBack);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 565);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 20);
            this.radPanel1.Size = new System.Drawing.Size(1484, 95);
            this.radPanel1.TabIndex = 3;
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel1.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 0, 20, 20);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::ClientPoint.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(1064, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnBack.Size = new System.Drawing.Size(400, 75);
            this.btnBack.TabIndex = 6;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Salir";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
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
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldName);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldLastname);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldDocument);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldEmail);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldCellphone);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldPasword);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldPassword2);
            this.radScrollablePanel1.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(1299, 379);
            this.radScrollablePanel1.Size = new System.Drawing.Size(1299, 379);
            this.radScrollablePanel1.TabIndex = 4;
            this.radScrollablePanel1.Click += new System.EventHandler(this.radScrollablePanel1_Click);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
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
            this.fldDocument.Label = "Nr. Documento";
            this.fldDocument.Location = new System.Drawing.Point(0, 180);
            this.fldDocument.Name = "fldDocument";
            this.fldDocument.Size = new System.Drawing.Size(615, 53);
            this.fldDocument.TabIndex = 4;
            // 
            // fldEmail
            // 
            this.fldEmail.Label = "Correo Electrónico";
            this.fldEmail.Location = new System.Drawing.Point(680, 0);
            this.fldEmail.Name = "fldEmail";
            this.fldEmail.Size = new System.Drawing.Size(615, 53);
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
            this.fldPasword.Label = "Contraseña";
            this.fldPasword.Location = new System.Drawing.Point(680, 180);
            this.fldPasword.Name = "fldPasword";
            this.fldPasword.Size = new System.Drawing.Size(615, 53);
            this.fldPasword.TabIndex = 5;
            // 
            // fldPassword2
            // 
            this.fldPassword2.Label = "Repita Contraseña";
            this.fldPassword2.Location = new System.Drawing.Point(680, 270);
            this.fldPassword2.Name = "fldPassword2";
            this.fldPassword2.Size = new System.Drawing.Size(615, 53);
            this.fldPassword2.TabIndex = 6;
            // 
            // FrmAddUsr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 660);
            this.Controls.Add(this.radScrollablePanel1);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddUsr";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmAddUsr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private CustomButton btnBack;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private CustomField fldName;
        private CustomField fldLastname;
        private CustomField fldDocument;
        private CustomField fldEmail;
        private CustomField fldCellphone;
        private CustomField fldPasword;
        private CustomField fldPassword2;
    }
}
