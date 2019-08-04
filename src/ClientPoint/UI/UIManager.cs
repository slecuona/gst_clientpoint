using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ClientPoint.UI {
    public static class UIManager {
        private static Dictionary<Window, FrmBase> _windows;
        private static SynchronizationContext _syncCtx;

        public static FrmBase Get(Window w) => _windows[w];

        // Debe ser ejecutado en UI Thread
        public static void Init() {
            _syncCtx = new WindowsFormsSynchronizationContext();
            _windows = new Dictionary<Window, FrmBase>() {
                { Window.Ads, new FrmAds()},
                { Window.DocumentInput, new FrmDocumentInput()},
                { Window.PasswordInput, new FrmPasswordInput()},
                { Window.NotConfirmedMenu, new FrmNotConfirmedMenu()},
                { Window.ClientCreate, new FrmClientCreate()},
                { Window.Confirm, new FrmConfirm()},
            };
        }

        public static void SafeExec(Action action) {
            if (_syncCtx != null)
                _syncCtx.Send(ui => { action.Invoke(); }, null);
            else
                action.Invoke();
        }

        public static void Show(Window toShow) {
            SafeExec(() => {
                _windows[toShow].BeforeShow();
                _windows[toShow].Show();
                foreach (var w in _windows) {
                    if (w.Key == toShow)
                        continue;
                    w.Value.Hide();
                    w.Value.AfterHide();
                }
            });
        }
    }

    public enum Window {
        Ads = 0,
        DocumentInput = 1,
        PasswordInput = 2,
        NotConfirmedMenu = 3,
        ClientCreate = 4,
        Confirm = 5
    }
}
