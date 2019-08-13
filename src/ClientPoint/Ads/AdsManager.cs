using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using ClientPoint.Api;

namespace ClientPoint.Ads {
    public static class AdsManager {
        private const string PATH = "ads";

        private static readonly Random _random;

        private static int GetRandom(int max) => 
            _random.Next(-1, max) + 1;

        static AdsManager() {
            _random = new Random();
        }

        public static string LoadRandom() {
            try {
                List<string> res;
                if (Config.DebugMode) {
                    // En modo Debug hardcodeo
                    // (Porque la URL viene con IP local)
                    res = new List<string>() {
                        "c:\\ads\\Adv1.mp4",
                        "c:\\ads\\Adv2.mp4"
                    };
                } else
                    res = ApiService.LoadAdvertising();
                
                // Del listado, recibo uno al azar
                var rnd = GetRandom(res.Count - 1);
                Debug.WriteLine($"Random: {rnd}");
                // No seria necesario descargarlo
                return res.ElementAt(rnd);
            }
            catch (Exception ex) {
                throw new Exception("Error al cargar publicidades.", ex);
            }
        }

        //private static void Download(string ad) {
        //    var uri = new Uri(ad);
        //    var filename = Path.GetFileName(uri.LocalPath);
        //    //Current = filename;
        //    var dir = Path.Combine(Directory.GetCurrentDirectory(), PATH);
        //    if (!Directory.Exists(dir))
        //        Directory.CreateDirectory(dir);
        //    var fullPath = Path.Combine(dir, filename);
        //    if(File.Exists(fullPath))
        //        File.Delete(fullPath);
        //    using (var client = new WebClient()) {
        //        client.DownloadFile(uri, fullPath);
        //    }
        //}
    }
}
