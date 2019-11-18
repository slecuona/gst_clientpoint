using System;
using System.Windows.Forms;
using AxWMPLib;
using ClientPoint.Ads;
using ClientPoint.Session;
using ClientPoint.UI.Views;

namespace ClientPoint.UI.Forms {
    public partial class FrmAds : FrmBase, IMessageFilter {
        private SwipeReader _swipeReader;
        private AdsPlayer _adsPlayer;
        private bool _started = false;

        public FrmAds() {
            InitializeComponent();
            _adsPlayer = new AdsPlayer();
            _adsPlayer.ClickEvent += AdsPlayerOnClickEvent;
            _adsPlayer.OnPause += AdsPlayerPause;
            this.Controls.Add(_adsPlayer);
            _swipeReader = new SwipeReader(OnSwipe);
            this.Shown += OnShown;
        }

        // En fullscreen no hay manera de capturar el click.
        // Cuando se hace click, pausa el video.
        private void AdsPlayerPause(object sender, EventArgs e) {
            UIManager.ShowView(View.MainMenu);
        }

        private void AdsPlayerOnClickEvent(object sender, _WMPOCXEvents_ClickEvent e) {
            UIManager.ShowView(View.MainMenu);
        }

        private void OnShown(object sender, EventArgs e) {
            _adsPlayer.Init();
            // Es el main form, hay que ejecutar el before show manualmente
            //BeforeShow();
        }

        public override void BeforeShow() {
            IdleTimer.Enabled = false;
            _adsPlayer.PlayRandom();
            _started = true;
            UIManager.SetKeyboard(Keyboard.None);
            if(UIManager.RewardModal.Visible)
                UIManager.RewardModal.Close();
            // Si muestro este form es porque ya termino la sesion
            ClientSession.Clear();
            Application.AddMessageFilter(this);
            base.BeforeShow();
        }

        public override void AfterHide() {
            _adsPlayer.Stop();
            Application.RemoveMessageFilter(this);
            IdleTimer.Enabled = true;
        }

        private void OnSwipe(string data) {
            Op.ClientLoadAsync(data);
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

        // Esto nos permite capturar el input del teclado
        // cuando el video esta en fullscreen
        private const UInt32 WM_KEYDOWN = 0x0100;
        public bool PreFilterMessage(ref Message m) {
            if (m.Msg == WM_KEYDOWN) {
                Keys keyCode = (Keys)(int)m.WParam & Keys.KeyCode;
                //Debug.WriteLine(keyCode);
                _swipeReader.OnKeyPress(keyCode);
                return true;
            }
            return false;
        }
    }
}
