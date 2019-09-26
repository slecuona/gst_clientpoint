using System.Drawing;
using ClientPoint.Utils;

namespace ClientPoint.UI.Controls {
    partial class SexField {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnM = new Telerik.WinControls.UI.RadButton();
            this.btnF = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = FontUtils.Roboto(15F);
            this.radLabel1.Location = new System.Drawing.Point(4, 15);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 34);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Sexo";
            this.radLabel1.ForeColor = Color.White;
            // 
            // radioM
            // 
            this.btnM.Font = FontUtils.Roboto(15.75F);
            this.btnM.Location = new System.Drawing.Point(165, 0);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(205, 55);
            this.btnM.TabIndex = 1;
            this.btnM.Text = "";
            this.btnM.ForeColor = Color.White;
            this.btnM.BackColor = System.Drawing.Color.Transparent;
            this.btnM.Image = Properties.Resources.btn_male;
            this.btnM.ImageAlignment = ContentAlignment.MiddleCenter;
            this.btnM.TabStop = false;
            this.btnM.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnM.ButtonElement.BorderElement.Width = 0;
            ((Telerik.WinControls.Primitives.TextPrimitive)(btnM.GetChildAt(0).GetChildAt(1).GetChildAt(1))).PositionOffset = new System.Drawing.SizeF(0F, -2F);
            // 
            // radioF
            // 
            this.btnF.Font = FontUtils.Roboto(15.75F);
            this.btnF.Location = new System.Drawing.Point(385, 0);
            this.btnF.Name = "btnF";
            this.btnF.Size = new System.Drawing.Size(205, 55);
            this.btnF.TabIndex = 2;
            this.btnF.Text = "";
            this.btnF.ForeColor = Color.White;
            this.btnF.BackColor = System.Drawing.Color.Transparent;
            this.btnF.Image = Properties.Resources.btn_female;
            this.btnF.ImageAlignment = ContentAlignment.MiddleCenter;
            this.btnF.TabStop = false;
            this.btnF.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnF.ButtonElement.BorderElement.Width = 0;
            ((Telerik.WinControls.Primitives.TextPrimitive)(btnF.GetChildAt(0).GetChildAt(1).GetChildAt(1))).PositionOffset = new System.Drawing.SizeF(0F, -2F);
            // 
            // SexField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnF);
            this.Controls.Add(this.btnM);
            this.Controls.Add(this.radLabel1);
            this.Name = "SexField";
            this.Size = new System.Drawing.Size(600, 70);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnM;
        private Telerik.WinControls.UI.RadButton btnF;
    }
}
