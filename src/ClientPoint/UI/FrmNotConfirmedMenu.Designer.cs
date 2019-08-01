using System.Drawing;
using System.Windows.Forms;

namespace ClientPoint.UI
{
    partial class FrmNotConfirmedMenu {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnUpdate = new ClientPoint.UI.CustomButton();
            this.btnBack = new ClientPoint.UI.CustomButton();
            this.btnConfirm = new ClientPoint.UI.CustomButton();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radPanel1.Controls.Add(this.btnUpdate);
            this.radPanel1.Controls.Add(this.btnBack);
            this.radPanel1.Controls.Add(this.btnConfirm);
            this.radPanel1.Location = new System.Drawing.Point(19, 69);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(400, 325);
            this.radPanel1.TabIndex = 3;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Image = global::ClientPoint.Properties.Resources.confirm;
            this.btnConfirm.Location = new System.Drawing.Point(0, 0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnConfirm.Size = new System.Drawing.Size(400, 75);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "Confirmar";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::ClientPoint.Properties.Resources.edit;
            this.btnUpdate.Location = new System.Drawing.Point(0, 125);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnUpdate.Size = new System.Drawing.Size(400, 75);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Actualizar datos";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::ClientPoint.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(0, 250);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnBack.Size = new System.Drawing.Size(400, 75);
            this.btnBack.TabIndex = 5;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Salir";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(3, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Cerrar";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmNewUsr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 451);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNewUsr";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FrmNewUsr";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private CustomButton btnConfirm;
        private CustomButton btnUpdate;
        private CustomButton btnBack;
        private Button btnExit;
    }
}
