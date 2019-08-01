using System.Collections.Generic;

namespace ClientPoint.UI {
    public static class UIManager {
        private static Dictionary<Window, FrmBase> _windows;

        public static FrmBase Get(Window w) => _windows[w];

        public static void Init() {
            _windows = new Dictionary<Window, FrmBase>() {
                { Window.Ads, new FrmAds()},
                { Window.DocumentInput, new FrmDocumentInput()},
                { Window.NewUsrMenu, new FrmNewUsrMenu()},
                { Window.ClientCreate, new FrmClientCreate()},
                { Window.Confirm, new FrmConfirm()},
            };
        }

        public static void Show(Window toShow) {
            _windows[toShow].BeforeShow();
            _windows[toShow].Show();
            foreach (var w in _windows) {
                if(w.Key == toShow)
                    continue;
                w.Value.Hide();
                w.Value.AfterHide();
            }
        }
    }

    public enum Window {
        Ads = 0,
        DocumentInput = 1,
        NewUsrMenu = 2,
        ClientCreate = 3,
        Confirm = 4
    }
}
