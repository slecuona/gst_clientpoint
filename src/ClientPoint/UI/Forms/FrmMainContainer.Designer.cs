using ClientPoint.UI.Views;

namespace ClientPoint.UI.Forms
{
    partial class FrmMainContainer {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new ClientPoint.UI.Views.MainMenuView();
            this.DocInput = new DocInputView();
            this.PassInput = new PassInputView();
            this.ClientCreate = new ClientCreateView();
            this.ClientUpdate = new ClientUpdateView();
            this.Confirm = new ConfirmView();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMainMenu1
            // 
            this.MainMenu.Name = "MainMenu";
            // 
            // FrmMainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.DocInput);
            this.Controls.Add(this.PassInput);
            this.Controls.Add(this.ClientCreate);
            this.Controls.Add(this.ClientUpdate);
            this.Controls.Add(this.Confirm);
            this.Name = "FrmMainContainer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Views.MainMenuView MainMenu;
        public Views.DocInputView DocInput;
        public Views.PassInputView PassInput;
        public Views.ClientCreateView ClientCreate;
        public Views.ClientUpdateView ClientUpdate;
        public Views.ConfirmView Confirm;
    }
}
