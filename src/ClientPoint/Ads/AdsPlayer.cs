using System;
using System.Windows.Forms;
using AxWMPLib;

namespace ClientPoint.Ads {
    public class AdsPlayer : AxWindowsMediaPlayer {
        private bool _playing = false;

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
                this.BeginInvoke(new Action(PlayRandom));
                return;
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
    }
}
