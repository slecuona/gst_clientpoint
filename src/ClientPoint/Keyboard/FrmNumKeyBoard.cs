using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClientPoint.Keyboard.NoActivate;
using ClientPoint.UI;
using ClientPoint.Utils;
using Telerik.WinControls;

namespace ClientPoint.Keyboard
{
    public partial class FrmNumKeyBoard : NoActivateWindow
    {
        protected override bool ShowWithoutActivation => false;

        IEnumerable<KeyButton> keyButtonList = null;
        IEnumerable<KeyButton> KeyButtonList
        {
            get
            {
                if (keyButtonList == null)
                {
                    keyButtonList = Enumerable.OfType<KeyButton>(this.tableLayoutPanelKeyButtons.Controls);
                }
                return keyButtonList;
            }
        }


        List<int> pressedModifierKeyCodes = null;

        /// <summary>
        /// The pressed modifier keys.
        /// </summary>
        List<int> PressedModifierKeyCodes
        {
            get
            {
                if (pressedModifierKeyCodes == null)
                {
                    pressedModifierKeyCodes = new List<int>();
                }
                return pressedModifierKeyCodes;
            }
        }


        public FrmNumKeyBoard()
        {
            InitializeComponent();
            this.SetPosCenter();
        }
        
        #region Handle key board event

        private void KeyBoardForm_Load(object sender, EventArgs e)
        {
            // Register the key button click event.
            foreach (KeyButton btn in this.KeyButtonList) {
                if(btn.Visible)
                    btn.Click += new EventHandler(KeyButton_Click);
            }
        }
        
        /// <summary>
        /// Handle the key button click event.
        /// </summary>
        void KeyButton_Click(object sender, EventArgs e) {
            // para que no quede el foco en el boton
            this.ActiveControl = null;

            UIManager.ActivateCurrWindow();

            var btn = sender as KeyButton;
            if (btn == null)
                return;

            UserInteraction.KeyboardInput.SendKey(PressedModifierKeyCodes, btn.KeyCode);
        }

        #endregion

        //protected override void WndProc(ref Message m) {
        //    // Listen for operating system messages.
        //    Debug.WriteLine($"Msg: {m.Msg}");
            
        //    // Mouse activate
        //    if (m.Msg == 33) {
        //        this.ActiveControl = null;
        //        UIManager.ActivateCurrWindow();
        //        UIManager.ActivateCurrentControl();
        //        return;
        //    }

        //    base.WndProc(ref m);
        //}

        private void OnActivated(object sender, EventArgs e) {
            this.ActiveControl = null;
            //UIManager.ActivateCurrWindow();
            //UIManager.ActivateCurrentControl();
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            //empty implementation
        }

        public void SetPosCenter() {
            this.Location = new Point(530, 310);
        }
    }
}
