using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientPoint.UI;

namespace ClientPoint.Utils {
    public static class Logger {
        private const string ERR_INIT =
            "Error al inicializar logs.";

        static object _syncRoot = new object();

        private static StringBuilder _buff;

        private static string LogPath;

        private static string LogFileName =>
            $"{DateTime.Now.Date:yyyy-MM-dd}.log";

        private static string Timestamp =>
            $"[{DateTime.Now:HH:mm:ss:fff}]";

        public static void Init() {
            try {
                LogPath = Path.GetFullPath("./log");
                if (!Directory.Exists(LogPath))
                    Directory.CreateDirectory(LogPath);
                Write("Init. Logs OK.").Wait();
                UIManager.SplashStatus("LOGS => [OK]");
            } catch (Exception ex) {
                var msg = ERR_INIT;
                if (!string.IsNullOrEmpty(LogPath))
                    msg += $" Path: {LogPath}";
                throw new Exception(msg, ex);
            }
        }

        public static async Task Write(string info, bool time = true) {
            try {
                lock (_syncRoot) {
                    var file = Path.Combine(LogPath, LogFileName);
                    using (StreamWriter outputFile = new StreamWriter(file, true)) {
                        outputFile.WriteLineAsync(
                            $"{(time ? $"{Timestamp} " : "")}{info}");
                    }
                }
            } catch (Exception ex) {
                // Si falla log, nada
            }
        }

        public static void WriteAsync(string info) {
            var t = new Thread(() =>
                Write(info).Wait()
            );
            t.Start();
        }

        public static void WriteBuff(string info) {
            if(_buff == null)
                _buff = new StringBuilder();

            _buff.AppendLine($"{Timestamp} {info}");
        }

        public static void Commit() {
            if (_buff == null)
                return;
            Write(_buff.ToString(), false).Wait();
            _buff.Clear();
        }

        // Loggea toda la info posible de una excepcion
        public static void Exception(Exception ex) {
            WriteAsync($"=> [EX Type]: ({ex.GetType()})");
            WriteAsync($"=> [EX Message]: {ex.Message}");
            WriteAsync($"=> [EX StackTrace]:\n{ex.StackTrace}");
            
            if(ex.InnerException != null)
                Exception(ex.InnerException);
        }

        public static void DebugWrite(string msg) {
            Debug.WriteLine(msg);
            if(Config.DebugMode)
                Write(msg).Wait();
        }
    }
}
