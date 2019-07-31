using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientPoint.UI {
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radDateTimePicker1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0 = new Telerik.WinControls.RootRadElement();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(4, 10);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(106, 34);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "radLabel1";
            // 
            // radDateTimePicker1
            // 
            this.radDateTimePicker1.CalendarSize = new System.Drawing.Size(350, 300);
            this.radDateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.radDateTimePicker1.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.radDateTimePicker1.Location = new System.Drawing.Point(415, 3);
            this.radDateTimePicker1.Name = "radDateTimePicker1";
            // 
            // 
            // 
            this.radDateTimePicker1.RootElement.AutoSize = false;
            this.radDateTimePicker1.Size = new System.Drawing.Size(172, 41);
            this.radDateTimePicker1.TabIndex = 1;
            this.radDateTimePicker1.TabStop = false;
            this.radDateTimePicker1.Text = "30/07/2019";
            this.radDateTimePicker1.Value = new System.DateTime(2019, 7, 30, 0, 0, 0, 0);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.radDateTimePicker1.GetChildAt(0))).CalendarSize = new System.Drawing.Size(350, 300);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.radDateTimePicker1.GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            ((Telerik.WinControls.UI.RadMaskedEditBoxElement)(this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "30/07/2019";
            ((Telerik.WinControls.UI.RadMaskedEditBoxElement)(this.radDateTimePicker1.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(20, 5, 2, 5);
            // 
            // object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0
            // 
            this.object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0.AutoSize = false;
            this.object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0.Name = "object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0";
            this.object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0.StretchHorizontally = true;
            this.object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0.StretchVertically = true;
            // 
            // DateField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radDateTimePicker1);
            this.Controls.Add(this.radLabel1);
            this.Name = "DateField";
            this.Size = new System.Drawing.Size(600, 50);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;
        private Telerik.WinControls.RootRadElement object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0;
    }
}
