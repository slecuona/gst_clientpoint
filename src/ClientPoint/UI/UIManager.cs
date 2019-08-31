using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ClientPoint.Keyboard;
using ClientPoint.Keyboard.NoActivate;
using ClientPoint.Utils;

namespace ClientPoint.UI {
    public static class UIManager {
        private static Dictionary<Window, FrmBase> _windows;
        private static Dictionary<Keyboard, Form> _keyboards;

        private static SynchronizationContext _syncCtx;

        public static Window CurrWindow = Window.Ads;
        public static Keyboard CurrKeyboard = Keyboard.None;

        public static FrmBase Get(Window w) => _windows[w];
        
        public static FrmBase GetCurrent() => _windows[CurrWindow];
        public static void ActivateCurrentControl() {
            var w = GetCurrent()?.ActiveControl;
            if (w is FrmBaseDialog dlg) {
                dlg.CurrentControl?.Select();
            }
        }

        private static FrmSplash Splash;

        // Debe ser ejecutado en UI Thread
        public static void Init() {
            SplashStatus("Iniciando UI...");
            _syncCtx = new WindowsFormsSynchronizationContext();
            _windows = new Dictionary<Window, FrmBase>() {
                { Window.Ads, new FrmAds()},
                { Window.DocumentInput, new FrmDocumentInput()},
                { Window.PasswordInput, new FrmPasswordInput()},
                { Window.MainMenu, new FrmMainMenu()},
                { Window.ClientCreate, new FrmClientCreate()},
                { Window.ClientUpdate, new FrmClientUpdate()},
                { Window.Confirm, new FrmConfirm()},
                { Window.UserMenu, new FrmUserMenu()},
                { Window.Status, new FrmStatus()},
            };
            _keyboards = new Dictionary<Keyboard, Form>() {
                { Keyboard.None, null},
                { Keyboard.AlphaNum, new FrmKeyBoard()},
                { Keyboard.Num, new FrmNumKeyBoard()},
            };
            // Hago el render al inicio
            // (evito el flickering)
            foreach (var w in _windows) {
                w.Value.Show();
                w.Value.Hide();
                w.Value.Opacity = 1;
            }
            foreach (var w in _keyboards) {
                if (w.Key == Keyboard.None)
                    return;
                w.Value.Show();
                w.Value.Hide();
                w.Value.Opacity = 1;
            }
        }

        public static void SafeExec(Action action) {
            if (_syncCtx != null)
                _syncCtx.Send(ui => { action.Invoke(); }, null);
            else
                action.Invoke();
        }

        public static void Show(Window toShow) {
            var prev = CurrWindow;
            CurrWindow = toShow;
            SafeExec(() => {
                _windows[prev].BeforeHide();
                _windows[toShow].BeforeShow();
                _windows[toShow].Show();
                _windows[prev].Hide();
                _windows[prev].AfterHide();
                _windows[toShow].AfterShow();
                //foreach (var w in _windows) {
                //    if (w.Key == toShow)
                //        continue;
                //    w.Value.Hide();
                //    w.Value.AfterHide();
                //}
                //_windows[toShow].AfterShow();
            });
        }

        public static void SetKeyboard(Keyboard k) {
            if (CurrKeyboard == k)
                return;
            var prev = CurrKeyboard;
            CurrKeyboard = k;
            if (k == Keyboard.None) {
                _keyboards[prev]?.Hide();
                return;
            }
            SafeExec(() => {
                _keyboards[prev]?.Hide();
                _keyboards[k].Show();
                _keyboards[k].ActiveControl = null;
            });
        }

        // Nos permite setear las 2 posiciones posibles para
        // el teclado numerico.
        public static void SetNumKeyboardCenter(bool center) {
            _keyboards[Keyboard.Num].Top = center ? 310 : 400;
        }

        // Esto nos permite activar la ventana actual de la app
        // al clickear el teclado virtual.
        // (Por default el teclado no funcionaba correctamente para las ventanas
        // que se generan dentro de la app, estaba pensado para que sea un proceso
        // aparte.)
        public static void ActivateCurrWindow() {
            var curr = UnsafeNativeMethods.GetForegroundWindow();
            var wdw = GetCurrent().Handle;
            if (curr != wdw) {
                UnsafeNativeMethods.SetForegroundWindow(wdw);
            }
        }

        public static FrmDocumentInput DocumentInput => 
            (FrmDocumentInput)_windows[Window.DocumentInput];

        public static FrmPasswordInput PasswordInput =>
            (FrmPasswordInput)_windows[Window.PasswordInput];

        public static FrmStatus StatusWindow =>
            (FrmStatus)_windows[Window.Status];

        public static void StartSplash() {
            var t = new Thread(() => {
                Splash = new FrmSplash();
                Splash.InvokeIfRequired(() => { Splash.ShowDialog(); });
            });
            t.Start();
            while (Splash == null) {
                // Wait for it
                Thread.Sleep(500);
            }
        }

        public static void StopSplash() {
            Splash?.InvokeIfRequired(()=> Splash?.Close());
        }
        
        public static void SplashStatus(string m) {
            Splash.InvokeIfRequired(()=> Splash?.AppendText(m));
            // Esto es solo para buscar un efecto mas progresivo
            Thread.Sleep(500);
        }
    }

    public enum Window {
        Ads = 0,
        DocumentInput = 1,
        PasswordInput = 2,
        MainMenu = 3,
        ClientCreate = 4,
        ClientUpdate = 5,
        Confirm = 6,
        UserMenu = 7,
        Status = 8
    }

    public enum Keyboard {
        None = 0,
        Num = 1,
        AlphaNum = 2,
    }
}
