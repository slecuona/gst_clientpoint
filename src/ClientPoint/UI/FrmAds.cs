using System;
using System.Diagnostics;
using System.Windows.Forms;
using AxWMPLib;
using ClientPoint.Ads;
using ClientPoint.Session;

namespace ClientPoint.UI {
    public partial class FrmAds : FrmBase {
        private SwipeReader _swipeReader;
        private AdsPlayer _adsPlayer;
        private bool _started = false;

        public FrmAds() {
            InitializeComponent();
            _adsPlayer = new AdsPlayer();
            _adsPlayer.ClickEvent += AdsPlayerOnClickEvent;
            _adsPlayer.OnPause += AdsPlayerPause;
            this.Controls.Add(_adsPlayer);
            _swipeReader = new SwipeReader(this, OnSwipe);
            this.Shown += OnShown;
        }

        // En fullscreen no hay manera de capturar el click.
        // Cuando se hace click, pausa el video.
        private void AdsPlayerPause(object sender, EventArgs e) {
            UIManager.Show(Window.DocumentInput);
        }

        private void AdsPlayerOnClickEvent(object sender, _WMPOCXEvents_ClickEvent e) {
            UIManager.Show(Window.DocumentInput);
        }

        private void OnShown(object sender, EventArgs e) {
            _adsPlayer.Init();
            // Es el main form, hay que ejecutar el before show manualmente
            BeforeShow();
        }

        public override void BeforeShow() {
            _adsPlayer.PlayRandom();
            _started = true;
            // Si muestro este form es porque ya termino la sesion
            ClientSession.Clear();
            base.BeforeShow();
        }

        public override void AfterHide() {
            _adsPlayer.Stop();
        }

        private void OnSwipe(string data) {
            Debug.WriteLine($"Card Swiped: {data}");
        }
        
        //protected override void WndProc(ref Message m) {
        //    // Listen for operating system messages.
        //    Debug.WriteLine($"Msg: {m.Msg}");

        //    // El reproductor no tiene un handle para el click.
        //    // Por ahora es la forma que se encontró para que la ventana
        //    // reaccione correctamente al 'tap'
        //    // TODO: Hacer pruebas con W10 tablet mode
        //    if (_started && m.Msg == 528) {
        //        //UIManager.Show(Window.NewUsr);
        //        return;
        //    }

        //    base.WndProc(ref m);
        //}
    }
}
