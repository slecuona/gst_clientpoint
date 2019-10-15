using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ClientPoint.Keyboard;
using ClientPoint.Keyboard.NoActivate;
using ClientPoint.UI.Forms;
using ClientPoint.UI.Views;
using ClientPoint.Utils;

namespace ClientPoint.UI {
    public static class UIManager {
        private static Dictionary<Window, FrmBase> _windows;
        private static Dictionary<Keyboard, Form> _keyboards;
        private static Dictionary<View, BaseView> _views;

        private static SynchronizationContext _syncCtx;

        public static Window CurrWindow = Window.None;
        public static Keyboard CurrKeyboard = Keyboard.None;
        public static View CurrView = View.None;

        public static FrmBase Get(Window w) => _windows[w];
        public static Form GetKeyboard(Keyboard k) => 
            k == Keyboard.None ? null : _keyboards[k];
        
        // Devuelve la ventana contenedora actual.
        public static FrmBase GetCurrentWindow() => _windows[CurrWindow];

        // Devuelve el Form activo.
        public static Form GetActiveForm() {
            if (Splash.Visible)
                return Splash;
            if (CurrKeyboard != Keyboard.None)
                return GetKeyboard(CurrKeyboard);
            if (RewardModal.Visible)
                return RewardModal;
            if (Control.Visible)
                return Control;
            if (CurrWindow != Window.None)
                return GetCurrentWindow();
            return null;
        }

        public static void SafeExecOnActiveForm(Action<Form> a) {
            var owner = GetActiveForm();
            if (owner == null) {
                a?.Invoke(null);
                return;
            }
            owner.InvokeIfRequired(()=> a?.Invoke(owner));
        }

        //public static void ActivateCurrentControl() {
        //    var w = GetCurrent()?.ActiveControl;
        //    if (w is FrmBaseDialog dlg) {
        //        dlg.CurrentControl?.Select();
        //    }
        //}

        public static FrmControl Control;
        public static FrmSplash Splash;
        public static FrmRewardModal RewardModal;

        // Debe ser ejecutado en UI Thread
        public static void Init() {
            SplashStatus("Iniciando UI...");
            _syncCtx = new WindowsFormsSynchronizationContext();
            _views = new Dictionary<View, BaseView>();
            _windows = new Dictionary<Window, FrmBase>() {
                { Window.Ads, new FrmAds()},
                { Window.Main, new FrmMainContainer()},
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
                    continue;
                w.Value.Show();
                w.Value.Hide();
                w.Value.Opacity = 1;
            }
            RewardModal = new FrmRewardModal();
            Control = new FrmControl();
        }

        public static void AddView(View v, BaseView p) {
            _views.Add(v, p);
        }

        public static void SafeExec(Action action) {
            if (_syncCtx != null)
                _syncCtx.Send(ui => { action.Invoke(); }, null);
            else
                action.Invoke();
        }

        public static void ShowWindow(Window toShow) {
            if (toShow == CurrWindow)
                return;
            var prev = CurrWindow;
            CurrWindow = toShow;
            SafeExec(() => {
                try {
                    if (prev != Window.None)
                        _windows[prev].BeforeHide();
                    _windows[toShow].BeforeShow();
                    _windows[toShow].Show();
                    if (prev != Window.None) {
                        _windows[prev].Hide();
                        _windows[prev].AfterHide();
                    }
                    _windows[toShow].AfterShow();
                }
                catch (Exception e) {
                    Logger.Exception(e);
                }
            });
        }

        public static void ShowView(View toShow) {
            var w = _views[toShow].GetParentWindow();
            ShowWindow(w);

            var prev = CurrView;
            if (prev != toShow) {
                CurrView = toShow;
                SafeExec(() => {
                    try {
                        if (prev != View.None) {
                            _views[prev].BeforeHide();
                            _views[prev].Visible = false;
                            _views[prev].AfterHide();
                        }
                        GetCurrentWindow().Refresh();
                        _views[toShow].BeforeShow();
                        _views[toShow].Visible = true;
                        _views[toShow].AfterShow();
                    } catch (Exception e) {
                        Logger.Exception(e);
                    }
                });
            }
            
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
            var wdw = GetCurrentWindow().Handle;
            if (curr != wdw) {
                UnsafeNativeMethods.SetForegroundWindow(wdw);
            }
        }
        
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
            if (Splash == null || !Splash.Visible)
                return;
            Splash.InvokeIfRequired(()=> Splash?.AppendText(m));
            // Esto es solo para buscar un efecto mas progresivo
            Thread.Sleep(500);
        }

        public static void ShowControl() {
            IdleTimer.Enabled = false;
            if (Config.DebugMode) {
                // En debug mode no pido PIN
                ShowControlOnConfirm();
                return;
            }
            PinInput.OnConfirm = ShowControlOnConfirm;
            ShowView(View.PinInput);
        }

        private static void ShowControlOnConfirm() {
            ShowView(View.MainMenu);
            SafeExecOnActiveForm(owner =>
                Control.ShowDialog(owner));
            IdleTimer.Enabled = true;
        }

        public static DocInputView DocInput => 
            (DocInputView)_views[View.DocumentInput];
        public static PassInputView PassInput => 
            (PassInputView)_views[View.PasswordInput];
        public static PinInputView PinInput => 
            (PinInputView)_views[View.PinInput];
        public static StatusView StatusMainView =>
            (StatusView)_views[View.StatusMain];
    }

    public enum Window {
        None = 0,
        Ads = 1,
        Main = 2
    }

    public enum View {
        None = 0,
        DocumentInput = 1,
        PasswordInput = 2,
        MainMenu = 3,
        SwipeCard = 4,
        ClientCreate = 5,
        ClientUpdate = 6,
        Confirm = 7,
        StatusMain = 8,
        ClientMenu = 9,
        Rewards = 10,
        PinInput = 11
    }

    public enum Keyboard {
        None = 0,
        Num = 1,
        AlphaNum = 2,
    }
}
