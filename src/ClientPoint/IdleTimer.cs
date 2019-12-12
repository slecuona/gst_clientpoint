using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientPoint.UI;
using ClientPoint.UI.Forms;

namespace ClientPoint {
    public static class IdleTimer {
        private static Timer _timer;
        private static bool _idle;
        private static FrmIdle _form;
        private static bool _enabled;

        // Si no muestra el mensaje, vuelve a la 
        // publicidad directamente
        public static bool ShowMessage = true;

        static IdleTimer() {
            _timer = new Timer();
            _timer.Interval = Config.IdleSeconds * 1000;
            _timer.Tick += TimerOnTick;
            _timer.Enabled = false;
            _idle = false;
            _form = new FrmIdle();
            _enabled = false;

            Application.Idle += ApplicationOnIdle;
        }

        public static bool Enabled {
            set {
                _enabled = value;
                if(!value)
                    Stop();
                else
                    Start();
            }
        }

        private static void ApplicationOnIdle(object sender, EventArgs e) {
            if (_idle || !_enabled)
                return;
            Stop();
            Start();
        }

        public static void Start() {
            Debug.WriteLine("IDLE Starting...");
            _idle = true;
            _timer.Enabled = true;
            _timer.Start();
        }

        public static void Stop() {
            Debug.WriteLine("IDLE Stopping...");
            _timer.Enabled = false;
            _timer.Stop();
            _idle = false;
        }

        public static void OnBusy() {
            if (!_enabled)
                return;
            Stop();
        }

        private static void TimerOnTick(object sender, EventArgs e) {
            if (UIManager.CurrWindow == Window.None)
                return;
            Debug.WriteLine("IDLE Tick!");
            _idle = true;
            Enabled = false;
            if(ShowMessage)
                UIManager.SafeExecOnActiveForm(owner =>
                    _form.ShowDialog(owner));
            else 
                UIManager.ShowWindow(Window.Ads);
        }
    }
}
