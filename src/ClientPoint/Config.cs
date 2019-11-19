using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using ClientPoint.Properties;
using System.IO.Ports;

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

            VoucherPrinterName = GetSetting("VoucherPrinterName", "Custom GT");
            VoucherPrinterTimeout = GetInt("VoucherPrinterTimeout", 5);

            TicketPrinterPort = GetSetting("TicketPrinterPort", "COM3");
            TicketPrinterBaud = GetInt("TicketPrinterBaud", 38400);
            TicketPrinterDataBits = GetInt("TicketPrinterDataBits", 8);
            TicketPrinterParity = (Parity)GetInt("TicketPrinterParity", 
                (int)Parity.None);
            TicketPrinterStopBits = (StopBits)GetInt("TicketPrinterStopBits", 
                (int)StopBits.One);
            TicketPrinterHandshake = (Handshake)GetInt("TicketPrinterHandshake", 
                (int)Handshake.XOnXOff);
            
            VoucherPrinterPort = GetSetting("VoucherPrinterPort", "Com1");
            VoucherPrinterBaud = GetInt("VoucherPrinterBaud", 9600);
            VoucherPrinterDataBits = GetInt("VoucherPrinterDataBits", 8);
            VoucherPrinterParity = (Parity)GetInt("VoucherPrinterParity",
                (int)Parity.None);
            VoucherPrinterStopBits = (StopBits)GetInt("VoucherPrinterStopBits",
                (int)StopBits.One);
            VoucherPrinterHandshake = (Handshake)GetInt("VoucherPrinterHandshake",
                (int)Handshake.None);

            ApiUrl = GetSetting("ApiUrl", API_URL_DEF);

            CardNameX = GetInt("CardNameX", 40);
            CardNameY = GetInt("CardNameY", 400);
            CardNameSize = GetInt("CardNameSize", 28);

            IdleSeconds = GetInt("IdleSeconds", 15);
            IdleMessageSeconds = GetInt("IdleMessageSeconds", 10);

            DebugMode = GetBool("Debug", false);

            ControlPin = GetSetting("ControlPin", "478"); //GST

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

        public static string VoucherPrinterName;
        public static int VoucherPrinterTimeout;

        public static string TicketPrinterPort;
        public static int TicketPrinterBaud;
        public static int TicketPrinterDataBits;
        public static Parity TicketPrinterParity;
        public static StopBits TicketPrinterStopBits;
        public static Handshake TicketPrinterHandshake;
        
        public static string VoucherPrinterPort;
        public static int VoucherPrinterBaud;
        public static int VoucherPrinterDataBits;
        public static Parity VoucherPrinterParity;
        public static StopBits VoucherPrinterStopBits;
        public static Handshake VoucherPrinterHandshake;

        public static bool DebugMode;

        public static int CardNameX = 0;
        public static int CardNameY = 0;
        public static int CardNameSize = 16;

        public static int IdleSeconds = 0;
        public static int IdleMessageSeconds = 0;

        public static string ControlPin;

        /// <summary>
        /// URL Base de la API.
        /// </summary>
        private const string API_URL_DEF = 
            "http://192.168.10.12/mobile/api/ClientPoint/";
        public static string ApiUrl;

        public const string TEST_CARD = "0010100000999";

        public const string TEST_VOUCHER =
            " ************************************* \n        CASINO DE GST INTERNATIONAL \n           CANJE DE PREMIO \nN#TICKET:                      45\nCAJA#:                         26\nUSUARIO:              CajaCliente\nFECHA:                 21/10/2019\nHORA:                    11:22:37\nFECHA APLICACION:      21/10/2019\nPremio                 Sorpresa\nPuntos Canjeados                20\n\u001ba\u0001\u001dhZ\u001dk\u000525183\0\n\u001ba\u000125183\n  \n  \n  \n ____________________________________ \n Firma Cliente \n  \n  \n  \n ___________________________________ \n Firma Supervisor \n  \n *************************************   \n\n\n\n\n\n\n\n\u001bi";

        public const string TEST_TICKET =
            "^C|^^P|9|1|00-4631-5728-6704-5160|Casino GST|DIRECCION GST DIRECCION|ESTADO GST ESTADO|TICKET PROMOCIONAL|Validacion|00-4631-5728-6704-5160|Fecha:10/21/2019|Hora:12:51| TITULO TICKET|diez pesos con cero centavos||$10.00|Expiracion en  1 Dias|CAJA# 26|004631572867045160|^";

        public static Image HostLogo;

        public static Color LightBlue = 
            Color.FromArgb(80, 186, 226);


        public static Color FocusColor =
            Color.FromArgb(246, 239, 121);
    }
}
