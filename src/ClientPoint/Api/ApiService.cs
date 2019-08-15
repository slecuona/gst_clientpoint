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

        private static BaseResponse PrepareAndSendRequest<TResType>(
            string op, object req, out string errMsg) {
            try {
                errMsg = "";
                var json = SendRequest(op, ToJson(req));
                var res = (BaseResponse)JsonUtils.Deserialize(typeof(TResType), json);
                if (res.ResponseCode != 0) {
                    errMsg = res.ResponseDesc;
                }
                return res;
            } catch (Exception ex) {
                throw new Exception($"Error al preparar request de {op}.", ex);
            }
        }

        // Para testear conexion con la API
        public static void Ping() {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(Config.ApiUrl);
                client.PostAsync("", 
                    new StringContent("")).Wait();
            }
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
            var res = PrepareAndSendRequest<BaseResponse>("ClientCreate", req, out errMsg);
            return res.ResponseCode == 0;
        }

        public static bool ClientUpdate(ClientUpdateRequest req, out string errMsg) {
            var res = PrepareAndSendRequest<BaseResponse>("ClientUpdate", req, out errMsg);
            return res.ResponseCode == 0;
        }

        // Confirma alta de cliente mediante codigo de validacion
        public static bool ConfirmCode(ConfirmCodeRequest req, out string errMsg) {
            var res = PrepareAndSendRequest<BaseResponse>("ConfirmCode", req, out errMsg);
            return res.ResponseCode == 0;
        }

        // Nos permite consultar el estado del cliente mediante DocNumber
        public static ClientStatusResponse ClientStatus(ClientStatusRequest req, out string errMsg) {
            var res = (ClientStatusResponse)PrepareAndSendRequest<ClientStatusResponse>(
                "ClientStatus", req, out errMsg);
            if (res.ResponseCode != 0) {
                if (res.NotExists) {
                    // No es un error, el cliente no existe
                    return res;
                }
                errMsg = res.ResponseDesc;
                return null;
            }
            return res;
        }

        // Nos permite consultar el estado del cliente mediante IdCard
        public static ClientStatusResponse ClientLoad(ClientLoadRequest req, out string errMsg) {
            var res = (ClientStatusResponse)PrepareAndSendRequest<ClientStatusResponse>(
                "ClientLoad", req, out errMsg);
            if (res.ResponseCode != 0) {
                if (res.NotExists) {
                    // No es un error, el cliente no existe
                    return res;
                }
                errMsg = res.ResponseDesc;
                return null;
            }
            return res;
        }

        public static string GetNumberCard() {
            try {
                var json = SendRequest("GetNumberCard", "");
                var res = (string)JsonUtils.Deserialize(typeof(string), json);
                return res;
            } catch (Exception ex) {
                throw new Exception("Error al obtener numero de tarjeta.", ex);
            }
        }
    }
}
