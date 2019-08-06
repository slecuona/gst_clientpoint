using System;
using System.Windows.Forms;

namespace ClientPoint {
    public class SwipeReader {
        private string _data;
        private string _buff;
        private bool _reading = false;
        private KeysConverter _converter;
        private Action<string> _onSwipe;

        public SwipeReader(Action<string> onSwipe) {
            _onSwipe = onSwipe;
            _converter = new KeysConverter();
        }
        
        public void OnKeyPress(Keys k) {
            if (!_reading) {
                if (k == Keys.Oemtilde) // "ñ"
                    _reading = true;
                return;
            }

            // "_" (ShiftKey + Oemminus)
            if (_reading && k == Keys.ShiftKey) {
                End();
                return;
            }

            // Convierto la tecla "presionada" a string
            _buff += _converter.ConvertToString(k);
        }

        private void End() {
            _reading = false;
            _data = _buff;
            _buff = "";
            _onSwipe?.Invoke(_data);
        }
    }
}
