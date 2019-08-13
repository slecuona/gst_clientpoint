using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Ke;

namespace ClientPoint.Keyboard {
    partial class FrmNumKeyBoard {
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
            this.keyButtonRight = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonBack = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonLeft = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad3 = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad6 = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad9 = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad2 = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad5 = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad8 = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad0 = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad1 = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad4 = new ClientPoint.Keyboard.KeyButton();
            this.keyButtonNumberPad7 = new ClientPoint.Keyboard.KeyButton();
            this.tableLayoutPanelKeyButtons = new ClientPoint.Ke.MyBufferedTableLayoutPanel();
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad7)).BeginInit();
            this.tableLayoutPanelKeyButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // keyButtonRight
            // 
            this.keyButtonRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonRight.IsPressed = false;
            this.keyButtonRight.KeyCode = 39;
            this.keyButtonRight.Location = new System.Drawing.Point(303, 203);
            this.keyButtonRight.Name = "keyButtonRight";
            this.keyButtonRight.NormalText = null;
            this.keyButtonRight.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonRight.ShiftText = null;
            this.keyButtonRight.Size = new System.Drawing.Size(44, 44);
            this.keyButtonRight.TabIndex = 0;
            this.keyButtonRight.Text = "→";
            this.keyButtonRight.UnNumLockKeyCode = 0;
            this.keyButtonRight.UnNumLockText = null;
            this.keyButtonRight.UseMnemonic = false;
            // 
            // keyButtonBack
            // 
            this.tableLayoutPanelKeyButtons.SetColumnSpan(this.keyButtonBack, 2);
            this.keyButtonBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonBack.IsPressed = false;
            this.keyButtonBack.KeyCode = 8;
            this.keyButtonBack.Location = new System.Drawing.Point(3, 3);
            this.keyButtonBack.Name = "keyButtonBack";
            this.keyButtonBack.NormalText = null;
            this.keyButtonBack.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonBack.ShiftText = null;
            this.keyButtonBack.Size = new System.Drawing.Size(94, 44);
            this.keyButtonBack.TabIndex = 0;
            this.keyButtonBack.Text = "← Borrar";
            this.keyButtonBack.UnNumLockKeyCode = 0;
            this.keyButtonBack.UnNumLockText = null;
            this.keyButtonBack.UseMnemonic = false;
            // 
            // keyButtonLeft
            // 
            this.keyButtonLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonLeft.IsPressed = false;
            this.keyButtonLeft.KeyCode = 37;
            this.keyButtonLeft.Location = new System.Drawing.Point(203, 203);
            this.keyButtonLeft.Name = "keyButtonLeft";
            this.keyButtonLeft.NormalText = null;
            this.keyButtonLeft.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonLeft.ShiftText = null;
            this.keyButtonLeft.Size = new System.Drawing.Size(44, 44);
            this.keyButtonLeft.TabIndex = 0;
            this.keyButtonLeft.Text = "←";
            this.keyButtonLeft.UnNumLockKeyCode = 0;
            this.keyButtonLeft.UnNumLockText = null;
            this.keyButtonLeft.UseMnemonic = false;
            // 
            // keyButtonNumberPad3
            // 
            this.keyButtonNumberPad3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad3.IsPressed = false;
            this.keyButtonNumberPad3.KeyCode = 99;
            this.keyButtonNumberPad3.Location = new System.Drawing.Point(103, 153);
            this.keyButtonNumberPad3.Name = "keyButtonNumberPad3";
            this.keyButtonNumberPad3.NormalText = "3";
            this.keyButtonNumberPad3.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad3.ShiftText = null;
            this.keyButtonNumberPad3.Size = new System.Drawing.Size(44, 44);
            this.keyButtonNumberPad3.TabIndex = 0;
            this.keyButtonNumberPad3.Text = "3";
            this.keyButtonNumberPad3.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad3.UnNumLockText = null;
            this.keyButtonNumberPad3.UseMnemonic = false;
            // 
            // keyButtonNumberPad6
            // 
            this.keyButtonNumberPad6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad6.IsPressed = false;
            this.keyButtonNumberPad6.KeyCode = 102;
            this.keyButtonNumberPad6.Location = new System.Drawing.Point(103, 103);
            this.keyButtonNumberPad6.Name = "keyButtonNumberPad6";
            this.keyButtonNumberPad6.NormalText = "6";
            this.keyButtonNumberPad6.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad6.ShiftText = null;
            this.keyButtonNumberPad6.Size = new System.Drawing.Size(44, 44);
            this.keyButtonNumberPad6.TabIndex = 0;
            this.keyButtonNumberPad6.Text = "6";
            this.keyButtonNumberPad6.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad6.UnNumLockText = null;
            this.keyButtonNumberPad6.UseMnemonic = false;
            // 
            // keyButtonNumberPad9
            // 
            this.keyButtonNumberPad9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad9.IsPressed = false;
            this.keyButtonNumberPad9.KeyCode = 105;
            this.keyButtonNumberPad9.Location = new System.Drawing.Point(103, 53);
            this.keyButtonNumberPad9.Name = "keyButtonNumberPad9";
            this.keyButtonNumberPad9.NormalText = "9";
            this.keyButtonNumberPad9.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad9.ShiftText = null;
            this.keyButtonNumberPad9.Size = new System.Drawing.Size(44, 44);
            this.keyButtonNumberPad9.TabIndex = 0;
            this.keyButtonNumberPad9.Text = "9";
            this.keyButtonNumberPad9.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad9.UnNumLockText = null;
            this.keyButtonNumberPad9.UseMnemonic = false;
            // 
            // keyButtonNumberPad2
            // 
            this.keyButtonNumberPad2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad2.IsPressed = false;
            this.keyButtonNumberPad2.KeyCode = 98;
            this.keyButtonNumberPad2.Location = new System.Drawing.Point(53, 153);
            this.keyButtonNumberPad2.Name = "keyButtonNumberPad2";
            this.keyButtonNumberPad2.NormalText = "2";
            this.keyButtonNumberPad2.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad2.ShiftText = null;
            this.keyButtonNumberPad2.Size = new System.Drawing.Size(44, 44);
            this.keyButtonNumberPad2.TabIndex = 0;
            this.keyButtonNumberPad2.Text = "2";
            this.keyButtonNumberPad2.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad2.UnNumLockText = null;
            this.keyButtonNumberPad2.UseMnemonic = false;
            // 
            // keyButtonNumberPad5
            // 
            this.keyButtonNumberPad5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad5.IsPressed = false;
            this.keyButtonNumberPad5.KeyCode = 101;
            this.keyButtonNumberPad5.Location = new System.Drawing.Point(53, 103);
            this.keyButtonNumberPad5.Name = "keyButtonNumberPad5";
            this.keyButtonNumberPad5.NormalText = "5";
            this.keyButtonNumberPad5.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad5.ShiftText = null;
            this.keyButtonNumberPad5.Size = new System.Drawing.Size(44, 44);
            this.keyButtonNumberPad5.TabIndex = 0;
            this.keyButtonNumberPad5.Text = "5";
            this.keyButtonNumberPad5.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad5.UnNumLockText = null;
            this.keyButtonNumberPad5.UseMnemonic = false;
            // 
            // keyButtonNumberPad8
            // 
            this.keyButtonNumberPad8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad8.IsPressed = false;
            this.keyButtonNumberPad8.KeyCode = 104;
            this.keyButtonNumberPad8.Location = new System.Drawing.Point(53, 53);
            this.keyButtonNumberPad8.Name = "keyButtonNumberPad8";
            this.keyButtonNumberPad8.NormalText = "8";
            this.keyButtonNumberPad8.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad8.ShiftText = null;
            this.keyButtonNumberPad8.Size = new System.Drawing.Size(44, 44);
            this.keyButtonNumberPad8.TabIndex = 0;
            this.keyButtonNumberPad8.Text = "8";
            this.keyButtonNumberPad8.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad8.UnNumLockText = null;
            this.keyButtonNumberPad8.UseMnemonic = false;
            // 
            // keyButtonNumberPad0
            // 
            this.tableLayoutPanelKeyButtons.SetColumnSpan(this.keyButtonNumberPad0, 2);
            this.keyButtonNumberPad0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad0.IsPressed = false;
            this.keyButtonNumberPad0.KeyCode = 96;
            this.keyButtonNumberPad0.Location = new System.Drawing.Point(3, 203);
            this.keyButtonNumberPad0.Name = "keyButtonNumberPad0";
            this.keyButtonNumberPad0.NormalText = "0";
            this.keyButtonNumberPad0.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad0.ShiftText = null;
            this.keyButtonNumberPad0.Size = new System.Drawing.Size(94, 44);
            this.keyButtonNumberPad0.TabIndex = 0;
            this.keyButtonNumberPad0.Text = "0";
            this.keyButtonNumberPad0.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad0.UnNumLockText = null;
            this.keyButtonNumberPad0.UseMnemonic = false;
            // 
            // keyButtonNumberPad1
            // 
            this.keyButtonNumberPad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad1.IsPressed = false;
            this.keyButtonNumberPad1.KeyCode = 97;
            this.keyButtonNumberPad1.Location = new System.Drawing.Point(3, 153);
            this.keyButtonNumberPad1.Name = "keyButtonNumberPad1";
            this.keyButtonNumberPad1.NormalText = "1";
            this.keyButtonNumberPad1.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad1.ShiftText = null;
            this.keyButtonNumberPad1.Size = new System.Drawing.Size(44, 44);
            this.keyButtonNumberPad1.TabIndex = 0;
            this.keyButtonNumberPad1.Text = "1";
            this.keyButtonNumberPad1.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad1.UnNumLockText = null;
            this.keyButtonNumberPad1.UseMnemonic = false;
            // 
            // keyButtonNumberPad4
            // 
            this.keyButtonNumberPad4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad4.IsPressed = false;
            this.keyButtonNumberPad4.KeyCode = 100;
            this.keyButtonNumberPad4.Location = new System.Drawing.Point(3, 103);
            this.keyButtonNumberPad4.Name = "keyButtonNumberPad4";
            this.keyButtonNumberPad4.NormalText = "4";
            this.keyButtonNumberPad4.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad4.ShiftText = null;
            this.keyButtonNumberPad4.Size = new System.Drawing.Size(44, 44);
            this.keyButtonNumberPad4.TabIndex = 0;
            this.keyButtonNumberPad4.Text = "4";
            this.keyButtonNumberPad4.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad4.UnNumLockText = null;
            this.keyButtonNumberPad4.UseMnemonic = false;
            // 
            // keyButtonNumberPad7
            // 
            this.keyButtonNumberPad7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyButtonNumberPad7.IsPressed = false;
            this.keyButtonNumberPad7.KeyCode = 103;
            this.keyButtonNumberPad7.Location = new System.Drawing.Point(3, 53);
            this.keyButtonNumberPad7.Name = "keyButtonNumberPad7";
            this.keyButtonNumberPad7.NormalText = "7";
            this.keyButtonNumberPad7.Padding = new System.Windows.Forms.Padding(2);
            this.keyButtonNumberPad7.ShiftText = null;
            this.keyButtonNumberPad7.Size = new System.Drawing.Size(44, 44);
            this.keyButtonNumberPad7.TabIndex = 0;
            this.keyButtonNumberPad7.Text = "7";
            this.keyButtonNumberPad7.UnNumLockKeyCode = 0;
            this.keyButtonNumberPad7.UnNumLockText = null;
            this.keyButtonNumberPad7.UseMnemonic = false;
            // 
            // tableLayoutPanelKeyButtons
            // 
            this.tableLayoutPanelKeyButtons.ColumnCount = 6;
            this.tableLayoutPanelKeyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonRight, 5, 3);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonLeft, 4, 3);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonBack, 4, 0);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad3, 2, 2);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad6, 2, 1);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad0, 0, 3);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad2, 1, 2);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad9, 2, 0);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad5, 1, 1);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad1, 0, 2);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad8, 1, 0);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad4, 0, 1);
            this.tableLayoutPanelKeyButtons.Controls.Add(this.keyButtonNumberPad7, 0, 0);
            this.tableLayoutPanelKeyButtons.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelKeyButtons.Name = "tableLayoutPanelKeyButtons";
            this.tableLayoutPanelKeyButtons.RowCount = 4;
            this.tableLayoutPanelKeyButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelKeyButtons.Size = new System.Drawing.Size(360, 240);
            this.tableLayoutPanelKeyButtons.TabIndex = 3;
            // 
            // FrmNumKeyBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 240);
            this.Controls.Add(this.tableLayoutPanelKeyButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(480, 510);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FrmNumKeyBoard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Teclado Numerico";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.KeyBoardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyButtonNumberPad7)).EndInit();
            this.tableLayoutPanelKeyButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private KeyButton keyButtonBack;
        private KeyButton keyButtonLeft;
        private KeyButton keyButtonRight;
        private KeyButton keyButtonNumberPad7;
        private KeyButton keyButtonNumberPad8;
        private KeyButton keyButtonNumberPad9;
        private KeyButton keyButtonNumberPad4;
        private KeyButton keyButtonNumberPad5;
        private KeyButton keyButtonNumberPad6;
        private KeyButton keyButtonNumberPad1;
        private KeyButton keyButtonNumberPad2;
        private KeyButton keyButtonNumberPad3;
        private KeyButton keyButtonNumberPad0;
        private Telerik.WinControls.Themes.FluentTheme fluentTheme1;
        private MyBufferedTableLayoutPanel tableLayoutPanelKeyButtons;
    }
}