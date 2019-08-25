using System.Drawing;
using Telerik.WinControls;

namespace ClientPoint.UI {
    partial class CustomButton {
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
            Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Padding = new System.Windows.Forms.Padding(20, 10, 0, 5);
            DisplayStyle = DisplayStyle.ImageAndText;
            ImageAlignment = ContentAlignment.MiddleLeft;
            // No deben tener foco
            TabStop = false;
        }

        #endregion
    }
}
