using System;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;

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
            this.dateTimePicker = new Telerik.WinControls.UI.RadDateTimePicker();
            this.object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0 = new Telerik.WinControls.RootRadElement();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = FontUtils.Roboto(15.75F);
            this.radLabel1.Location = new System.Drawing.Point(4, 10);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(106, 34);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "radLabel1";
            this.radLabel1.ForeColor = Color.White;
            // 
            // radDateTimePicker1
            // 
            this.dateTimePicker.CalendarSize = new System.Drawing.Size(350, 300);
            this.dateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker.Font = FontUtils.Roboto(15F);
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(415, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            // 
            // 
            // 
            this.dateTimePicker.RootElement.AutoSize = false;
            this.dateTimePicker.Size = new System.Drawing.Size(172, 41);
            this.dateTimePicker.TabIndex = 1;
            this.dateTimePicker.TabStop = false;
            this.dateTimePicker.Text = "30/07/2019";
            this.dateTimePicker.Value = new System.DateTime(2019, 7, 30, 0, 0, 0, 0);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dateTimePicker.GetChildAt(0))).CalendarSize = new System.Drawing.Size(350, 300);
            ((Telerik.WinControls.UI.RadDateTimePickerElement)(this.dateTimePicker.GetChildAt(0))).AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.FitToAvailableSize;
            ((Telerik.WinControls.UI.RadMaskedEditBoxElement)(this.dateTimePicker.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Text = "30/07/2019";
            ((Telerik.WinControls.UI.RadMaskedEditBoxElement)(this.dateTimePicker.GetChildAt(0).GetChildAt(2).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(20, 5, 2, 5);
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
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.radLabel1);
            this.Name = "DateField";
            this.Size = new System.Drawing.Size(600, 50);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker dateTimePicker;
        private Telerik.WinControls.RootRadElement object_5358a662_49a9_42bb_8ad6_af1fc98ba3e0;
    }
}
