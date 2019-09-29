using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ClientPoint.UI.Forms
{
    public partial class FrmIdle : Telerik.WinControls.UI.RadForm {
        private Timer _timer;
        private int _secsToClose;

        public FrmIdle()
        {
            InitializeComponent();
            btnContinue.Click += BtnContinueOnClick;
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += TimerOnTick;
            _timer.Enabled = false;

            this.Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e) {
            _secsToClose = Config.IdleMessageSeconds;
            lblTime.Text = $"{_secsToClose}";
            _timer.Enabled = true;
            _timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e) {
            if (_secsToClose == 0) {
                _timer.Stop();
                _timer.Enabled = false;
                UIManager.ShowWindow(Window.Ads);
                DialogResult = DialogResult.Cancel;
                return;
            }

            lblTime.Text = $"{_secsToClose}";
            _secsToClose--;
        }

        private void BtnContinueOnClick(object sender, EventArgs e) {
            IdleTimer.Enabled = true;

            _timer.Stop();
            _timer.Enabled = false;
            
            DialogResult = DialogResult.OK;
        }
        
    }
}
