using System.Collections.Generic;

namespace ClientPoint.UI {
    public static class UIManager {
        private static Dictionary<Window, FrmBase> _windows;

        public static FrmBase Get(Window w) => _windows[w];

        public static void Init() {
            _windows = new Dictionary<Window, FrmBase>() {
                { Window.Ads, new FrmAds()},
                { Window.NewUsr, new FrmNewUsr()}
            };
        }

        public static void Show(Window toShow) {
            _windows[toShow].Show();
            foreach (var w in _windows) {
                if(w.Key == toShow)
                    continue;
                w.Value.Hide();
            }
        }
    }

    public enum Window {
        Ads = 0,
        NewUsr = 1
    }
}
