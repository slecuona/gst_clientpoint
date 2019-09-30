using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;
using Telerik.WinControls.UI;

namespace ClientPoint.UI.Controls {
    partial class DateField {
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
            this.lblSlash = new Telerik.WinControls.UI.RadLabel();
            this.lblSlash2 = new Telerik.WinControls.UI.RadLabel();
            this.txtDay = new CustomTextBox();
            this.txtMonth = new CustomTextBox();
            this.txtYear = new CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSlash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSlash2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.lblField.Font = FontUtils.Roboto(15.75F);
            this.lblField.Location = new System.Drawing.Point(4, 10);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(106, 34);
            this.lblField.TabIndex = 0;
            this.lblField.Text = "radLabel1";
            this.lblField.ForeColor = Color.White;
            // 
            // lblSlash
            // 
            this.lblSlash.Font = FontUtils.Roboto(18, FontStyle.Bold);
            this.lblSlash.Location = new System.Drawing.Point(275, 8);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(20, 34);
            this.lblSlash.TabIndex = 0;
            this.lblSlash.Text = "/";
            this.lblSlash.ForeColor = Color.White;
            // 
            // lblSlash2
            // 
            this.lblSlash2.Font = FontUtils.Roboto(18, FontStyle.Bold);
            this.lblSlash2.Location = new System.Drawing.Point(365, 8);
            this.lblSlash2.Name = "lblSlash2";
            this.lblSlash2.Size = new System.Drawing.Size(20, 34);
            this.lblSlash2.TabIndex = 0;
            this.lblSlash2.Text = "/";
            this.lblSlash2.ForeColor = Color.White;
            // 
            // txtDay
            // 
            this.txtDay.Font = FontUtils.Roboto(15.75F);
            this.txtDay.Location = new System.Drawing.Point(210, 0);
            this.txtDay.Name = "txtDay";
            this.txtDay.Padding = new System.Windows.Forms.Padding(10);
            this.txtDay.Size = new System.Drawing.Size(60, 50);
            this.txtDay.TabIndex = 1;
            this.txtDay.MaxLength = 2;
            this.txtDay.TextAlign = HorizontalAlignment.Center;
            // 
            // txtMonth
            // 
            this.txtMonth.Font = FontUtils.Roboto(15.75F);
            this.txtMonth.Location = new System.Drawing.Point(300, 0);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Padding = new System.Windows.Forms.Padding(10);
            this.txtMonth.Size = new System.Drawing.Size(60, 50);
            this.txtMonth.TabIndex = 1;
            this.txtMonth.MaxLength = 2;
            this.txtMonth.TextAlign = HorizontalAlignment.Center;
            // 
            // txtYear
            // 
            this.txtYear.Font = FontUtils.Roboto(15.75F);
            this.txtYear.Location = new System.Drawing.Point(390, 0);
            this.txtYear.Name = "txtYear";
            this.txtYear.Padding = new System.Windows.Forms.Padding(10);
            this.txtYear.Size = new System.Drawing.Size(80, 50);
            this.txtYear.TabIndex = 1;
            this.txtYear.MaxLength = 4;
            this.txtYear.TextAlign = HorizontalAlignment.Center;
            // 
            // DateField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.lblSlash);
            this.Controls.Add(this.lblSlash2);
            this.Name = "DateField";
            this.Size = new System.Drawing.Size(600, 50);
            ((System.ComponentModel.ISupportInitialize)(this.lblField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSlash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSlash2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel lblField;
        private CustomTextBox txtDay;
        private CustomTextBox txtMonth;
        private CustomTextBox txtYear;
        private RadLabel lblSlash;
        private RadLabel lblSlash2;
    }
}
