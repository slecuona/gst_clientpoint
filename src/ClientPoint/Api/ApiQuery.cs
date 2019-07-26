using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using ClientPoint.Espf;

namespace ClientPoint.Api {
    public static class ApiQuery {

        private static string Request(string op, string json) {
            try {
                Debug.WriteLine($"[JSON REQUEST] => {json}");
                using (var client = new HttpClient()) {
                    client.BaseAddress = new Uri(Config.ApiUrl);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(op, content).Result;
                    var res = result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine($"[JSON RESPONSE] => {res}");
                    return res;
                }
            }
            catch (Exception ex) {
                throw new Exception(
                    $"Error al enviar request a la API. " +
                    $"Op => {op}. Json => {json}", ex);
            }
        }

        public static List<string> LoadAdvertising() {
            try {
                var json = Request("LoadAdvertising", "");
                var res = (string[]) JsonUtils.Deserialize(typeof(string[]), json);
                return res.ToList();
            }
            catch (Exception ex) {
                throw new Exception("Error al obtener publicidades.", ex);
            }
        }
    }
}
