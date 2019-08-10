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

            //ThemeResolutionService.ApplicationThemeName = "Fluent";
        }
        

        #region Handle key board event

        private void KeyBoardForm_Load(object sender, EventArgs e)
        {
            try
            {
                //InitializeKeyButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            {
                return;
            }

            // para que no quede el foco en el boton
            this.ActiveControl = null;
            UserInteraction.KeyboardInput.SendKey(PressedModifierKeyCodes, btn.KeyCode);

        }

        /// <summary>
        /// Initialize the key buttons.
        /// </summary>
        void InitializeKeyButtons()
        {
            
            var keysMappingDoc = XDocument.Load("Resources\\KeysMapping.xml");
            foreach (var key in keysMappingDoc.Root.Elements())
            {
                int keyCode = int.Parse(key.Element("KeyCode").Value);

                IEnumerable<KeyButton> btns = KeyButtonList.Where(btn => btn.KeyCode == keyCode);

                foreach (KeyButton btn in btns)
                {
                    btn.NormalText = key.Element("NormalText").Value;

                    if (key.Elements("ShiftText").Count() > 0)
                    {
                        btn.ShiftText = key.Element("ShiftText").Value;
                    }

                    if (key.Elements("UnNumLockText").Count() > 0)
                    {
                        btn.UnNumLockText = key.Element("UnNumLockText").Value;
                    }

                    if (key.Elements("UnNumLockKeyCode").Count() > 0)
                    {
                        btn.UnNumLockKeyCode =
                            int.Parse(key.Element("UnNumLockKeyCode").Value);
                    }

                    btn.UpdateDisplayText(false, true, true);
                }
            }
        }

        #endregion


    }
}
