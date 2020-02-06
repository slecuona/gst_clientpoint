using System;
using System.IO;
using System.Linq;
using System.Text;
using ClientPoint.Espf;
using ClientPoint.Utils;
using Telerik.WinControls;
using StorageDic = System.Collections.Generic.Dictionary<int, string>;

namespace ClientPoint {
    public static class CodArea {
        private const string FILE_NAME = "CodArea.json";

        private static StorageDic _storage;

        public static bool Init() {
            try {
                // Encoding de windows que permite los caracteres con tildes y ñ
                var encoding = Encoding.GetEncoding(1252);
                var file = Path.Combine(Directory.GetCurrentDirectory(), FILE_NAME);
                var json = File.ReadAllText(file, encoding);
                _storage = (StorageDic)JsonUtils.Deserialize(
                    typeof(StorageDic), json);
                return true;
            }
            catch (Exception e) {
                Logger.Exception(e);
                RadMessageBox.Show(
                    $"Error al leer archivo de recursos '{FILE_NAME}'.\n" +
                    "Verifique que el archivo exista y sea un json válido.");
                return false;
            }
        }

        // Es un cod. de area valido?
        public static bool Valid(int c) =>
            _storage.ContainsKey(c);

        public static Tuple<string, string> Parse(string num) {
            if(string.IsNullOrEmpty(num))
                return new Tuple<string, string>("", "");
            // Es importante que este ordenado por codigo de area descendiente.
            foreach (var ca in _storage.OrderByDescending(ca => ca.Key)) {
                var cod = ca.Key.ToString();
                if (num.StartsWith(cod)) {
                    return new Tuple<string, string>(cod, num.Substring(cod.Length));
                }
            }
            // Si llegamos hasta, no hay un codigo de area valido.
            if (num.Length <= 8) {
                // Debe faltar el codigo de area...
                return new Tuple<string, string>("", num);
            }
            // Lo mas probable es que sea un num invalido,
            // o cod de area de 4 digitos desconocido.
            return new Tuple<string, string>(num.Substring(0, 4), num.Substring(4));
        }
    }
}
