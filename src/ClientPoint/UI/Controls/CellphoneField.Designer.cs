using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
    partial class CellphoneField {
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
            this.lblField = new Telerik.WinControls.UI.RadLabel();
            this.lblCod = new Telerik.WinControls.UI.RadLabel();
            this.lbl15 = new Telerik.WinControls.UI.RadLabel();
            this.txtCod = new CustomTextBox();
            this.txtNum = new CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.lblField.Font = FontUtils.Roboto(15.75F);
            this.lblField.Location = new System.Drawing.Point(4, 10);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(106, 34);
            this.lblField.TabIndex = 0;
            this.lblField.Text = "";
            this.lblField.ForeColor = Color.White;
            // 
            // lblSlash
            // 
            this.lblCod.Font = FontUtils.Roboto(18, FontStyle.Bold);
            this.lblCod.Location = new System.Drawing.Point(235, 8);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(50, 34);
            this.lblCod.TabIndex = 0;
            this.lblCod.Text = "+54 9";
            this.lblCod.ForeColor = Color.White;
            // 
            // lblSlash2
            // 
            this.lbl15.Font = FontUtils.Roboto(18, FontStyle.Bold);
            this.lbl15.Location = new System.Drawing.Point(410, 8);
            this.lbl15.Name = "lbl15";
            this.lbl15.Size = new System.Drawing.Size(40, 34);
            this.lbl15.TabIndex = 0;
            this.lbl15.Text = "15";
            this.lbl15.ForeColor = Color.White;
            // 
            // txtDay
            // 
            this.txtCod.Font = FontUtils.Roboto(15.75F);
            this.txtCod.Location = new System.Drawing.Point(315, 0);
            this.txtCod.Name = "txtCod";
            this.txtCod.Padding = new System.Windows.Forms.Padding(10);
            this.txtCod.Size = new System.Drawing.Size(90, 50);
            this.txtCod.TabIndex = 1;
            this.txtCod.MaxLength = 4;
            this.txtCod.TextAlign = HorizontalAlignment.Center;
            // 
            // txtMonth
            // 
            this.txtNum.Font = FontUtils.Roboto(15.75F);
            this.txtNum.Location = new System.Drawing.Point(459, 0);
            this.txtNum.Name = "txtNum";
            this.txtNum.Padding = new System.Windows.Forms.Padding(10);
            this.txtNum.Size = new System.Drawing.Size(165, 50);
            this.txtNum.TabIndex = 1;
            this.txtNum.MaxLength = 10;
            this.txtNum.TextAlign = HorizontalAlignment.Center;
            // 
            // CellphoneField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.lbl15);
            this.Name = "CellphoneField";
            this.Size = new System.Drawing.Size(600, 50);
            ((System.ComponentModel.ISupportInitialize)(this.lblField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblField;
        private CustomTextBox txtCod;
        private CustomTextBox txtNum;
        private RadLabel lblCod;
        private RadLabel lbl15;
    }
}
