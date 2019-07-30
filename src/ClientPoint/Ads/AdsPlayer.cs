using System;
using System.Diagnostics;
using System.Windows.Forms;
using AxWMPLib;

namespace ClientPoint.Ads {
    public class AdsPlayer : AxWindowsMediaPlayer {
        private bool _playing = false;
        public EventHandler OnPause;

        public AdsPlayer() {
            this.Name = "adsPlayer";
            this.Enabled = true;
            this.Dock = DockStyle.Fill;
            this.PlayStateChange += OnPlayStateChange;
        }

        private void OnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e) {
            // Termino el video
            if (e.newState == 8) {
                _playing = false;
                // Ejecuta en UI Thread
                this.BeginInvoke(new Action(PlayRandom));
                return;
            }

            // Playing
            if (e.newState == 3) {
                this.fullScreen = true;
            }

            // Paused
            if (e.newState == 2) {
                this.OnPause?.Invoke(null, null);
            }
            
            //// El reproductor se detuvo
            //if (e.newState == 1 && !_playing) {
            //    // No se puede dar play directamente del Event Handler
            //    this.BeginInvoke(new Action(PlayRandom));
            //}
        }

        // El control ya debe estar creado
        public void Init() {
            this.enableContextMenu = true;
            this.uiMode = "none";
            this.settings.autoStart = false;
        }

        public void PlayRandom() {
            this.URL = AdsManager.LoadRandom();
            _playing = true;
            this.Ctlcontrols.play();
        }

        public void Stop() {
            this.URL = null;
            _playing = false;
            this.Ctlcontrols.stop();
        }
    }
}
