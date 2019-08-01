using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using ClientPoint.Espf;

namespace ClientPoint.Api {
    public static class ApiService {

        private static string SendRequest(string op, string json) {
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

        private static string ToJson(object obj) {
            return JsonUtils.Serialize(obj.GetType(), obj);
        }

        public static List<string> LoadAdvertising() {
            try {
                var json = SendRequest("LoadAdvertising", "");
                var res = (string[]) JsonUtils.Deserialize(typeof(string[]), json);
                return res.ToList();
            }
            catch (Exception ex) {
                throw new Exception("Error al obtener publicidades.", ex);
            }
        }

        // Crea cliente y envia codigo de validacion.
        public static bool ClientCreate(ClientCreateRequest req, out string errMsg) {
            try {
                errMsg = "";
                var json = SendRequest("ClientCreate", ToJson(req));
                var res = (GenResponse)JsonUtils.Deserialize(typeof(GenResponse), json);
                if (res.ResponseCode != 0) {
                    errMsg = res.ResponseDesc;
                    return false;
                }
                return true;
            } catch (Exception ex) {
                throw new Exception("Error al crear cliente.", ex);
            }
        }

        // Confirma alta de cliente mediante codigo de validacion
        public static bool ConfirmCode(ConfirmCodeRequest req, out string errMsg) {
            try {
                errMsg = "";
                var json = SendRequest("ConfirmCode", ToJson(req));
                var res = (GenResponse)JsonUtils.Deserialize(typeof(GenResponse), json);
                if (res.ResponseCode != 0) {
                    errMsg = res.ResponseDesc;
                    return false;
                }
                return true;
            } catch (Exception ex) {
                throw new Exception("Error al confirmar alta de cliente.", ex);
            }
        }

    }
}
