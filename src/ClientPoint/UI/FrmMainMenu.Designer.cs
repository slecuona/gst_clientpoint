namespace ClientPoint.UI
{
    partial class FrmMainMenu {
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
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnBack = new ClientPoint.UI.CustomButton();
            this.btnRewards = new ClientPoint.UI.CustomButton();
            this.usrPanel = new ClientPoint.UI.UserPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRewards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usrPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radPanel1.Controls.Add(this.btnBack);
            this.radPanel1.Controls.Add(this.btnRewards);
            this.radPanel1.Location = new System.Drawing.Point(261, 109);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(400, 325);
            this.radPanel1.TabIndex = 3;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radPanel1.GetChildAt(0).GetChildAt(1))).Width = 0F;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::ClientPoint.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(0, 194);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnBack.Size = new System.Drawing.Size(400, 75);
            this.btnBack.TabIndex = 5;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "Salir";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // btnRewards
            // 
            this.btnRewards.Font = new System.Drawing.Font("Helvetica-Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRewards.Image = global::ClientPoint.Properties.Resources.confirm;
            this.btnRewards.Location = new System.Drawing.Point(0, 37);
            this.btnRewards.Name = "btnRewards";
            this.btnRewards.Padding = new System.Windows.Forms.Padding(20, 5, 0, 5);
            this.btnRewards.Size = new System.Drawing.Size(400, 75);
            this.btnRewards.TabIndex = 4;
            this.btnRewards.TabStop = false;
            this.btnRewards.Text = "Premios";
            // 
            // userPanel1
            // 
            this.usrPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.usrPanel.Location = new System.Drawing.Point(0, 0);
            this.usrPanel.Name = "usrPanel";
            this.usrPanel.Padding = new System.Windows.Forms.Padding(20);
            this.usrPanel.Size = new System.Drawing.Size(926, 100);
            this.usrPanel.TabIndex = 4;
            // 
            // FrmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 451);
            this.Controls.Add(this.usrPanel);
            this.Controls.Add(this.radPanel1);
            this.Name = "FrmMainMenu";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FrmMainMenu";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRewards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usrPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private CustomButton btnRewards;
        private CustomButton btnBack;
        private UserPanel usrPanel;
    }
}
