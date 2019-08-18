using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ClientPoint.Keyboard;
using ClientPoint.Keyboard.NoActivate;

namespace ClientPoint.UI {
    public static class UIManager {
        private static Dictionary<Window, FrmBase> _windows;
        private static SynchronizationContext _syncCtx;

        public static Window CurrWindow = Window.Ads;

        public static FrmBase Get(Window w) => _windows[w];
        
        public static FrmBase GetCurrent() => _windows[CurrWindow];
        public static void ActivateCurrentControl() {
            var w = GetCurrent()?.ActiveControl;
            if (w is FrmBaseDialog dlg) {
                dlg.CurrentControl?.Select();
            }
        }

        private static FrmKeyBoard KeyBoard;
        private static FrmNumKeyBoard NumKeyBoard;

        // Debe ser ejecutado en UI Thread
        public static void Init() {
            _syncCtx = new WindowsFormsSynchronizationContext();
            _windows = new Dictionary<Window, FrmBase>() {
                { Window.Ads, new FrmAds()},
                { Window.DocumentInput, new FrmDocumentInput()},
                { Window.PasswordInput, new FrmPasswordInput()},
                { Window.NewClientMenu, new FrmNewClientMenu()},
                { Window.ClientCreate, new FrmClientCreate()},
                { Window.ClientUpdate, new FrmClientUpdate()},
                { Window.Confirm, new FrmConfirm()},
                { Window.MainMenu, new FrmMainMenu()},
                { Window.Status, new FrmStatus()},
            };
            KeyBoard = new FrmKeyBoard();
            NumKeyBoard = new FrmNumKeyBoard();
            // Hago el render al inicio
            // (evito el flickering)
            foreach (var w in _windows) {
                w.Value.Show();
                w.Value.Hide();
                w.Value.Opacity = 1;
            }
            KeyBoard.Show();
            KeyBoard.Hide();
            NumKeyBoard.Show();
            NumKeyBoard.Hide();
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

        public static void ShowKeyboard() {
            //new KeyBoardForm().Show();
            //return;
            KeyBoard.Show();
            KeyBoard.ActiveControl = null;
        }

        public static void HideKeyboard() =>
            KeyBoard.Hide();

        public static void ShowNumKeyboard() {
            NumKeyBoard.Show();
            NumKeyBoard.ActiveControl = null;
        }

        public static void HideNumKeyboard() =>
            NumKeyBoard.Hide();

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

    }

    public enum Window {
        Ads = 0,
        DocumentInput = 1,
        PasswordInput = 2,
        NewClientMenu = 3,
        ClientCreate = 4,
        ClientUpdate = 5,
        Confirm = 6,
        MainMenu = 7,
        Status = 8
    }
}
