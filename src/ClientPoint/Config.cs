using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using ClientPoint.Properties;

namespace ClientPoint {
    public static class Config {

        private static NameValueCollection AppSettings => 
            ConfigurationManager.AppSettings;

        static string GetSetting(string key, string def) =>
            AppSettings[key] ?? def;

        static bool GetBool(string key, bool def) {
            var val = AppSettings[key];
            if (val == null)
                return def;
            return bool.Parse(val);
        }

        static int GetInt(string key, int def) {
            var val = AppSettings[key];
            if (val == null)
                return def;
            return int.Parse(val);
        }

        static Config() {
            // ESPF
            EspfIp = GetSetting("EspfIp", "127.0.0.1");
            EspfPort = GetSetting("EspfPort", "18000");
            EspfPrinter = GetSetting("EspfPrinter", "Evolis KC200");
            EspfSettingsX = GetSetting("EspfSettingsX", null);
            EspfCommMethod = GetInt("EspfCommMethod", 0);

            ApiUrl = GetSetting("ApiUrl", API_URL_DEF);

            CardNameX = GetInt("CardNameX", 40);
            CardNameY = GetInt("CardNameY", 400);
            CardNameSize = GetInt("CardNameSize", 28);

            IdleSeconds = GetInt("IdleSeconds", 10);
            IdleMessageSeconds = GetInt("IdleMessageSeconds", 5);

            DebugMode = GetBool("Debug", false);

            LoadHostLogo();
        }

        static void LoadHostLogo() {
            try {
                HostLogo = Resources.logo_big;
                var path = GetSetting("HostLogo", null);
                if (path == null)
                    return;
                if (!File.Exists(path))
                    return;
                HostLogo = Image.FromFile(path);
            }
            catch (Exception e) {
                throw new Exception("Error al cargar imagen logo host.", e);
            }
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
        /// Extension de settings de impresion de ESPF
        /// </summary>
        public static string EspfSettingsX;

        public static int EspfCommMethod = 0;

        public static bool DebugMode;

        public static int CardNameX = 0;
        public static int CardNameY = 0;
        public static int CardNameSize = 16;

        public static int IdleSeconds = 0;
        public static int IdleMessageSeconds = 0;

        /// <summary>
        /// URL Base de la API.
        /// </summary>
        private const string API_URL_DEF = 
            "http://192.168.10.12/mobile/api/ClientPoint/";
        public static string ApiUrl;

        public const string TEST_CARD = "6000100000006";

        public static Image HostLogo;

        public static Color LightBlue = 
            Color.FromArgb(80, 186, 226);
        
    }
}
