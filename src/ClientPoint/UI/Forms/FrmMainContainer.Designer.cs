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
            this.PinInput = new PinInputView();
            this.ClientCreate = new ClientCreateView();
            this.ClientUpdate = new ClientUpdateView();
            this.Confirm = new ConfirmView();
            this.Status = new StatusView();
            this.Swipe = new SwipeView();
            this.ClientMenu = new ClientMenuView();
            this.Rewards = new RewardsView();
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
            this.Controls.Add(this.PinInput);
            this.Controls.Add(this.ClientCreate);
            this.Controls.Add(this.ClientUpdate);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Swipe);
            this.Controls.Add(this.ClientMenu);
            this.Controls.Add(this.Rewards);
            this.Name = "FrmMainContainer";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Main";
            this.KeyPreview = true;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Views.MainMenuView MainMenu;
        public Views.DocInputView DocInput;
        public Views.PassInputView PassInput;
        public Views.PinInputView PinInput;
        public Views.ClientCreateView ClientCreate;
        public Views.ClientUpdateView ClientUpdate;
        public Views.ConfirmView Confirm;
        public Views.StatusView Status;
        public Views.SwipeView Swipe;
        public Views.ClientMenuView ClientMenu;
        public Views.RewardsView Rewards;
    }
}
