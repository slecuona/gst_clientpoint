using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace ClientPoint.Utils {
    public static class FontUtils {
        private static PrivateFontCollection _pfc;

        /// <summary>
        /// Carga en memoria las fuentes alojadas como recurso.
        /// </summary>
        private static void Init() {
            _pfc = new PrivateFontCollection();
            
            var fontLength = Properties.Resources.Roboto_Regular.Length;
            var fontData = Properties.Resources.Roboto_Regular;
            var data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            _pfc.AddMemoryFont(data, fontLength);
        }

        public static Font Roboto(float size, FontStyle style = FontStyle.Regular) {
            if(_pfc == null)
                Init();
            return new Font(_pfc.Families[0], size, style);
        }
    }
}
