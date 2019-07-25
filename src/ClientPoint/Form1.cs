using System;
using System.Windows.Forms;
using ClientPoint.Espf;

namespace ClientPoint {
    public partial class Form1 : Form {
        private SwipeReader _swipeReader;

        public Form1() {
            InitializeComponent();
            
            _swipeReader = new SwipeReader(this, OnSwipe);
            
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
