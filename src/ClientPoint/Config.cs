using System.Collections.Specialized;
using System.Configuration;

namespace ClientPoint {
    public static class Config {

        private static NameValueCollection AppSettings => 
            ConfigurationManager.AppSettings;

        static string GetSetting(string key, string def) =>
            AppSettings[key] ?? def;

        static Config() {
            // ESPF
            EspfIp = GetSetting("EspfIp", "127.0.0.1");
            EspfPort = GetSetting("EspfPort", "18000");
            EspfPrinter = GetSetting("EspfPrinter", "Evolis KC200");

            ApiUrl = GetSetting("ApiUrl", API_URL_DEF);
        }

        /// <summary>
        /// Ip del servidor ESPF
        /// </summary>
        public static string EspfIp;

        /// <summary>
        /// Puerto del servidor ESPF
        /// </summary>
        public static string EspfPort;

        /// <summary>
        /// Nombre de la impresora configurada en el ESPF
        /// </summary>
        public static string EspfPrinter;

        /// <summary>
        /// URL Base de la API.
        /// </summary>
        private const string API_URL_DEF = 
            "http://192.168.10.100/mobile/api/ClientPoint/";
        public static string ApiUrl;

    }
}
