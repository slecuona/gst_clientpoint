using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Ads;
using ClientPoint.Espf;

namespace ClientPoint.UI {
    public partial class FrmAds : FrmBase {
        private SwipeReader _swipeReader;
        private AdsPlayer _adsPlayer;
        private bool _started = false;

        public FrmAds() {
            InitializeComponent();
            _adsPlayer = new AdsPlayer() {
                Size = new Size(500, 500),
                Location = new Point(100, 50)
            };
            this.Controls.Add(_adsPlayer);
            _swipeReader = new SwipeReader(this, OnSwipe);
            this.Shown += OnShown;
            this.Click += OnClick;
            this.MouseClick += OnMouseClick;
            this.MouseUp += OnMouseUp;
        }

        private void OnMouseUp(object sender, MouseEventArgs e) {
            Console.WriteLine("Mouse Up");
        }

        private void OnMouseClick(object sender, MouseEventArgs e) {
            Console.WriteLine("Mouse Click");
        }

        private void OnClick(object sender, EventArgs e) {
            Console.WriteLine("Click");
        }
        

        private void AdsPlayerOnClick(object sender, EventArgs e) {
            //this.Visible = false;
            
        }

        private void OnShown(object sender, EventArgs e) {
            _adsPlayer.Init();
            _adsPlayer.PlayRandom();
            _started = true;
        }

        private void OnSwipe(string data) {
            label1.Text = data;
        }
        
        protected override void WndProc(ref Message m) {
            // Listen for operating system messages.
            Debug.WriteLine($"Msg: {m.Msg}");

            // El reproductor no tiene un handle para el click.
            // Por ahora es la forma que se encontró para que la ventana
            // reaccione correctamente al 'tap'
            // TODO: Hacer pruebas con W10 tablet mode
            if (_started && m.Msg == 528) {
                //UIManager.Show(Window.NewUsr);
                return;
            }

            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                var job = new PrintJob();
                job.WriteData();
            }
            catch (Exception ex) {
                MessageBox.Show($"ERR: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e) {
            UIManager.Show(Window.NewUsr);
        }
    }
}
