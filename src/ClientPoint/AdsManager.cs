using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using ClientPoint.Api;

namespace ClientPoint {
    public static class AdsManager {
        private const string PATH = "ads";

        public static void Load() {
            try {
                var ads = ApiQuery.LoadAdvertising();
                Download(ads);
            }
            catch (Exception ex) {
                throw new Exception("Error al cargar publicidades.", ex);
            }
        }

        private static void Download(List<string> ads) {
            ads.ForEach(a => {
                var uri = new Uri(a);
                var filename = Path.GetFileName(uri.LocalPath);
                var dir = Path.Combine(Directory.GetCurrentDirectory(), PATH);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                using (var client = new WebClient()) {
                    client.DownloadFile(uri, Path.Combine(dir, filename));
                }
            });
        }
    }
}
