using System;
using System.IO;
using System.Text;
using ClientPoint.Espf;
using ClientPoint.Utils;
using Telerik.WinControls;
using StorageDic = System.Collections.Generic.Dictionary<string, string>;

namespace ClientPoint {
    public static class Strings {
        private const string FILE_NAME = "Strings.json";

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

        public static string Get(string k) =>
            _storage.ContainsKey(k) ? _storage[k] : string.Empty;
    }
}
