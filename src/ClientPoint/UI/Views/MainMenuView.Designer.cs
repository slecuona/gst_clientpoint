using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Utils;

namespace ClientPoint.UI.Views
{
    partial class MainMenuView {
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuView));
            this.btnUpdate = new ClientPoint.UI.CustomButtonBlue();
            this.btnNewlient = new ClientPoint.UI.CustomButton();
            this.btnConfirm = new ClientPoint.UI.CustomButtonBlue();
            this.btnClient = new ClientPoint.UI.CustomButton();
            this.lblWelcome = new ClientPoint.UI.CustomLabel();
            this.imgHost = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHost)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.lblWelcome);
            this.panelContainer.Controls.Add(this.imgHost);
            this.panelContainer.Controls.Add(this.btnClient);
            this.panelContainer.Controls.Add(this.btnConfirm);
            this.panelContainer.Controls.Add(this.btnNewlient);
            this.panelContainer.Controls.Add(this.btnUpdate);
            this.panelContainer.Size = new System.Drawing.Size(1302, 567);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(744, 549);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnUpdate.Size = new System.Drawing.Size(421, 87);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "ACTUALIZACIÓN DE DATOS";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNewlient
            // 
            this.btnNewlient.BackColor = System.Drawing.Color.Transparent;
            this.btnNewlient.ForeColor = System.Drawing.Color.White;
            this.btnNewlient.Image = ((System.Drawing.Image)(resources.GetObject("btnNewlient.Image")));
            this.btnNewlient.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNewlient.Location = new System.Drawing.Point(356, 410);
            this.btnNewlient.Name = "btnNewlient";
            this.btnNewlient.Size = new System.Drawing.Size(240, 89);
            this.btnNewlient.TabIndex = 6;
            this.btnNewlient.TabStop = false;
            this.btnNewlient.Type = ClientPoint.UI.Type.NewClient;
            this.btnNewlient.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.Location = new System.Drawing.Point(175, 549);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnConfirm.Size = new System.Drawing.Size(421, 87);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "CONFIRMACIÓN DE CLIENTE";
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.Color.Transparent;
            this.btnClient.ForeColor = System.Drawing.Color.White;
            this.btnClient.Image = ((System.Drawing.Image)(resources.GetObject("btnClient.Image")));
            this.btnClient.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClient.Location = new System.Drawing.Point(744, 410);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(240, 89);
            this.btnClient.TabIndex = 7;
            this.btnClient.TabStop = false;
            this.btnClient.Type = ClientPoint.UI.Type.Client;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = false;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.lblWelcome.Size = new System.Drawing.Size(1302, 143);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "BIENVENIDO";
            this.lblWelcome.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.lblWelcome.DoubleClick += LblWelcomeOnDoubleClick;
            // 
            // imgHost
            // 
            this.imgHost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgHost.Image = global::ClientPoint.Properties.Resources.logo_big;
            this.imgHost.Location = new System.Drawing.Point(1289, 725);
            this.imgHost.Name = "imgHost";
            this.imgHost.Size = new System.Drawing.Size(1366, 251);
            this.imgHost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgHost.TabIndex = 0;
            this.imgHost.TabStop = false;
            // 
            // PanelMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "MainMenuView";
            this.Size = new System.Drawing.Size(1302, 567);
            ((System.ComponentModel.ISupportInitialize)(this.panelContainer)).EndInit();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWelcome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton btnNewlient;
        private CustomButton btnClient;
        private CustomButtonBlue btnUpdate;
        private CustomButtonBlue btnConfirm;
        private CustomLabel lblWelcome;
        private PictureBox imgHost;
    }
}
