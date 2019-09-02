using System.Drawing;
using ClientPoint.Utils;
using Telerik.WinControls;

namespace ClientPoint.UI.Controls {
    partial class CustomButtonBlue {
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
            components = new System.ComponentModel.Container();
            Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            DisplayStyle = DisplayStyle.ImageAndText;
            ImageAlignment = ContentAlignment.MiddleLeft;
            Image = Properties.Resources.btn_1;
            Size = new Size(421, 77);
            Font = FontUtils.Roboto(18);
            TextAlignment = ContentAlignment.MiddleCenter;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            // No deben tener foco
            TabStop = false;
            ButtonElement.BorderElement.Width = 0;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.GetChildAt(0).GetChildAt(1).GetChildAt(1))).PositionOffset = new System.Drawing.SizeF(0F, -2F);
        }

        #endregion
    }
}
