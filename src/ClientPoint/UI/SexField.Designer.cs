using System.Drawing;

namespace ClientPoint.UI {
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
            this.radioM = new Telerik.WinControls.UI.RadRadioButton();
            this.radioF = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioF)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(4, 10);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 34);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Sexo";
            this.radLabel1.ForeColor = Color.White;
            // 
            // radioM
            // 
            this.radioM.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioM.Location = new System.Drawing.Point(290, 8);
            this.radioM.Name = "radioM";
            this.radioM.Size = new System.Drawing.Size(121, 34);
            this.radioM.TabIndex = 1;
            this.radioM.Text = "Masculino";
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.radioM.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.radioM.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(0);
            // 
            // radioF
            // 
            this.radioF.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioF.Location = new System.Drawing.Point(456, 8);
            this.radioF.Name = "radioF";
            this.radioF.Size = new System.Drawing.Size(101, 34);
            this.radioF.TabIndex = 2;
            this.radioF.Text = "Femenino";
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.radioF.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            ((Telerik.WinControls.Layouts.ImageAndTextLayoutPanel)(this.radioF.GetChildAt(0).GetChildAt(1).GetChildAt(0))).Margin = new System.Windows.Forms.Padding(0);
            // 
            // SexField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioF);
            this.Controls.Add(this.radioM);
            this.Controls.Add(this.radLabel1);
            this.Name = "SexField";
            this.Size = new System.Drawing.Size(600, 50);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadRadioButton radioM;
        private Telerik.WinControls.UI.RadRadioButton radioF;
    }
}
