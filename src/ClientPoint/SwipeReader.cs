using System;
using System.Windows.Forms;

namespace ClientPoint {
    public class SwipeReader {
        private string _data;
        private string _buff;
        private bool _reading = false;
        private Action<string> _onSwipe;

        public SwipeReader(FrmMain frm, Action<string> onSwipe) {
            _onSwipe = onSwipe;
            frm.KeyPreview = true;
            frm.KeyPress += FrmOnKeyPress;
        }
        
        private void FrmOnKeyPress(object sender, KeyPressEventArgs e) {

            if (!_reading) {
                if (e.KeyChar == 'ñ')
                    _reading = true;
                return;
            }

            if (_reading && e.KeyChar == '_') {
                End();
                return;
            }

            _buff += e.KeyChar;
        }

        private void End() {
            _reading = false;
            _data = _buff;
            _buff = "";
            _onSwipe?.Invoke(_data);
        }
    }
}
