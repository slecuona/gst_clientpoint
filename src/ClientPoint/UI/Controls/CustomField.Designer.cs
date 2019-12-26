using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;

namespace ClientPoint.UI.Controls {
    partial class CustomField {
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
            this.radTextBox1 = new CustomTextBox();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.btnViewPass = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewPass)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = FontUtils.Roboto(15.75F);
            this.radLabel1.ForeColor = System.Drawing.Color.White;
            this.radLabel1.Location = new System.Drawing.Point(0, 10);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(106, 34);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "radLabel1";
            // 
            // radTextBox1
            // 
            this.radTextBox1.Font = FontUtils.Roboto(15.75F);
            this.radTextBox1.Location = new System.Drawing.Point(245, 0);
            this.radTextBox1.Name = "radTextBox1";
            this.radTextBox1.Padding = new System.Windows.Forms.Padding(10);
            this.radTextBox1.Size = new System.Drawing.Size(380, 51);
            this.radTextBox1.TabIndex = 1;
            this.radTextBox1.CharacterCasing = CharacterCasing.Upper;
            // 
            // radButton1
            // 
            this.btnClear.Location = new System.Drawing.Point(550, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 47);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "";
            this.btnClear.Image = Properties.Resources.delete;
            this.btnClear.ImageAlignment = ContentAlignment.MiddleCenter;
            this.btnClear.ImageScalingSize = new Size(20, 20);
            this.btnClear.Visible = false;
            this.btnClear.TabStop = false;
            // 
            // btnViewPass
            // 
            this.btnViewPass.Location = new System.Drawing.Point(550, 0);
            this.btnViewPass.Name = "btnViewPass";
            this.btnViewPass.Size = new System.Drawing.Size(50, 47);
            this.btnViewPass.TabIndex = 2;
            this.btnViewPass.Text = "";
            this.btnViewPass.Image = Properties.Resources.eye;
            this.btnViewPass.ImageAlignment = ContentAlignment.MiddleCenter;
            this.btnViewPass.ImageScalingSize = new Size(20, 20);
            this.btnViewPass.Visible = false;
            this.btnViewPass.Focusable = false;
            this.btnViewPass.TabStop = false;
            // 
            // CustomField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnViewPass);
            this.Controls.Add(this.radTextBox1);
            this.Controls.Add(this.radLabel1);
            this.Name = "CustomField";
            this.Size = new System.Drawing.Size(600, 50);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewPass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private CustomTextBox radTextBox1;
        private Telerik.WinControls.UI.RadButton btnClear;
        private Telerik.WinControls.UI.RadButton btnViewPass;
    }
}
