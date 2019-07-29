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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnBack = new ClientPoint.UI.CustomButton();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.customField1 = new ClientPoint.UI.CustomField();
            this.customField2 = new ClientPoint.UI.CustomField();
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
            this.radPanel1.Location = new System.Drawing.Point(0, 405);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 20);
            this.radPanel1.Size = new System.Drawing.Size(1044, 95);
            this.radPanel1.TabIndex = 3;
            ((Telerik.WinControls.UI.RadPanelElement)(this.radPanel1.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 0, 20, 20);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::ClientPoint.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(624, 0);
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
            this.radScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel1.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            this.radScrollablePanel1.Padding = new System.Windows.Forms.Padding(0);
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.customField2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.customField1);
            this.radScrollablePanel1.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(1044, 405);
            this.radScrollablePanel1.Size = new System.Drawing.Size(1044, 405);
            this.radScrollablePanel1.TabIndex = 4;
            this.radScrollablePanel1.Click += new System.EventHandler(this.radScrollablePanel1_Click);
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radScrollablePanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // customField1
            // 
            this.customField1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customField1.Label = "Nombre/s";
            this.customField1.Location = new System.Drawing.Point(196, 37);
            this.customField1.Name = "customField1";
            this.customField1.Size = new System.Drawing.Size(676, 53);
            this.customField1.TabIndex = 0;
            // 
            // customField2
            // 
            this.customField2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customField2.Label = "Apellido/s";
            this.customField2.Location = new System.Drawing.Point(196, 117);
            this.customField2.Name = "customField2";
            this.customField2.Size = new System.Drawing.Size(676, 53);
            this.customField2.TabIndex = 1;
            // 
            // FrmAddUsr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 500);
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
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private CustomButton btnBack;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private CustomField customField1;
        private CustomField customField2;
    }
}
