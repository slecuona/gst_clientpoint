namespace ClientPoint.UI
{
    partial class FrmConfirm {
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
            this.fldCode = new ClientPoint.UI.CustomMaskedField();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();

            this.radScrollablePanel1.PanelContainer.Controls.Add(this.fldCode);
            // 
            // fldCode
            // 
            this.fldCode.Label = "Código";
            this.fldCode.Location = new System.Drawing.Point(0, 180);
            this.fldCode.Name = "fldCode";
            this.fldCode.Size = new System.Drawing.Size(615, 53);
            this.fldCode.TabIndex = 2;
            this.fldCode.CustomMaskType = CustomMaskType.ConfirmCode;

            this.Name = "FrmConfirm";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion
        
        private CustomMaskedField fldCode;
    }
}
