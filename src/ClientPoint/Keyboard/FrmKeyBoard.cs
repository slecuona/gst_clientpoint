
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using ClientPoint.Keyboard.NoActivate;
using ClientPoint.UI;

namespace ClientPoint.Keyboard
{
    public partial class FrmKeyBoard : NoActivateWindow
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


        public FrmKeyBoard()
        {
            InitializeComponent();
        }
        
        private void KeyBoardForm_Load(object sender, EventArgs e)
        {

            // Register the key button click event.
            foreach (KeyButton btn in this.KeyButtonList)
            {
                if(btn.Visible)
                    btn.Click += new EventHandler(KeyButton_Click);
            }

            //this.Activate();
        }
        
        /// <summary>
        /// Handle the key button click event.
        /// </summary>
        void KeyButton_Click(object sender, EventArgs e) {
            UIManager.ActivateCurrWindow();

            KeyButton btn = sender as KeyButton;
            if (btn == null)
                return;
            
            // para que no quede el foco en el boton
            this.ActiveControl = null;

            if (btn.Text == "@") {
                // ALT Gr + Q
                UserInteraction.KeyboardInput.SendKey(new List<int>() {165}, 81);
                return;
            }

            if (btn.Text == "_") {
                // Shift + (-)
                UserInteraction.KeyboardInput.SendKey(new List<int>() {16}, 189);
                return;
            }

            UserInteraction.KeyboardInput.SendKey(PressedModifierKeyCodes, btn.KeyCode);
        }
        


    }
}
