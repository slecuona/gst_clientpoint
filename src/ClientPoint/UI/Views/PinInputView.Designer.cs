using ClientPoint.UI.Controls;

namespace ClientPoint.UI.Views
{
    partial class PinInputView {
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
            this.fldPin = new CustomField();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.dialogPanel.Controls.Add(this.fldPin);
            // 
            // fldPassword
            // 
            this.fldPin.Label = "PIN";
            this.fldPin.Location = new System.Drawing.Point(350, 100);
            this.fldPin.Name = "fldPin";
            this.fldPin.Password = true;
            this.fldPin.Size = new System.Drawing.Size(615, 53);
            this.fldPin.TabIndex = 0;
            this.fldPin.Value = "";
            this.fldPin.Keyboard = Keyboard.Num;

            this.Name = "PinInputView";
            // 
            // 
            // 
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion
        
        private CustomField fldPin;
    }
}
