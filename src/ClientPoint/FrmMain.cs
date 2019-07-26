using System;
using System.Drawing;
using System.Windows.Forms;
using ClientPoint.Ads;
using ClientPoint.Espf;

namespace ClientPoint {
    public partial class FrmMain : Form {
        private SwipeReader _swipeReader;
        private AdsPlayer _adsPlayer;

        public FrmMain() {
            InitializeComponent();
            _adsPlayer = new AdsPlayer() {
                Size = new Size(500, 500),
                Location = new Point(100, 50)
            };
            this.Controls.Add(_adsPlayer);
            _swipeReader = new SwipeReader(this, OnSwipe);
            this.Shown += OnShown;
            
        }

        private void OnShown(object sender, EventArgs e) {
            _adsPlayer.Init();
            _adsPlayer.PlayRandom();
        }

        private void OnSwipe(string data) {
            label1.Text = data;
        }

        //protected override void WndProc(ref Message m) {
        //    // Listen for operating system messages.
        //    //Console.WriteLine($"Msg: {m.Msg}");
        //    base.WndProc(ref m);
        //}

        private void button1_Click(object sender, EventArgs e) {
            try {
                var job = new PrintJob();
                job.WriteData();
            }
            catch (Exception ex) {
                MessageBox.Show($"ERR: {ex.Message}");
            }
        }
    }
}
