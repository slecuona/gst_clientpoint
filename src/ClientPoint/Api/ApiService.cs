using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using ClientPoint.Espf;
using ClientPoint.Session;
using ClientPoint.Utils;

namespace ClientPoint.Api {
    public static class ApiService {
        private static string SendRequest(string op, string json) {
            try {
                Logger.DebugWrite($"[JSON REQUEST] [{op}] => {json}");
                using (var client = new HttpClient()) {
                    client.BaseAddress = new Uri(Config.ApiUrl);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(op, content).Result;
                    var res = result.Content.ReadAsStringAsync().Result;
                    Logger.DebugWrite($"[JSON RESPONSE] [{op}] => {res}");
                    return res;
                }
            }
            catch (Exception ex) {
                throw new Exception(
                    $"API: Error al enviar request a la API. " +
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
                throw new Exception($"API: Error al preparar request de {op}.", ex);
            }
        }

        // Para testear conexion con la API
        public static void Ping() {
            using (var client = new HttpClient() {
                // Para que no se quede mucho tiempo colgado.
                // La API corre local, no deberia demorar
                Timeout = TimeSpan.FromSeconds(10)
            }) {
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
                throw new Exception("API: Error al obtener publicidades.", ex);
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

        public static bool CreateCard(CreateCardRequest req, out string errMsg) {
            var res = PrepareAndSendRequest<BaseResponse>("CreateCard", req, out errMsg);
            return res.ResponseCode == 0;
        }
        
        public static List<Reward> GetRewards(string idCard) {
            try {
                var json = SendRequest("GetRewards", ToJson(new ClientLoadRequest() {
                    IdCard = idCard
                }));
                var res = (Reward[])JsonUtils.Deserialize(typeof(Reward[]), json);
                return res.ToList();
            }
            catch (Exception e) {
                throw new Exception("Error al obtener premios.", e);
            }
        }

        public static Reward GetRewardsCampaign(string idCard) {
            try {
                //if (Config.DebugMode) {
                //    return GetRewards(idCard)[0];
                //}
                var json = SendRequest("GetRewardsCampaign", ToJson(new ClientLoadRequest() {
                    IdCard = idCard
                }));
                var res = (Reward[])JsonUtils.Deserialize(typeof(Reward[]), json);
                if (res.Length == 0)
                    return null;
                return res[0];
            } catch (Exception e) {
                throw new Exception("API: Error al obtener premios.", e);
            }
        }

        public static bool CancelRewardCampaign(Int64 nroMvt, out string errMsg) {
            try {
                var res = PrepareAndSendRequest<BaseResponse>(
                    "CancelRewardCampaign", new CancelRewardCampaignRequest() {
                        NroMvt = nroMvt.ToString()
                    }, out errMsg);
                return res.ResponseCode == 0;
            } catch (Exception e) {
                throw new Exception("API: Error al cancelar premio de campaña.", e);
            }
        }

        public static ChangeRewardResponse ChangeReward(ChangeRewardRequest req, out string errMsg) {
            var res = PrepareAndSendRequest<ChangeRewardResponse>("ChangeReward", req, out errMsg);
            return (ChangeRewardResponse)res;
        }
        
        public static ChangeRewardResponse ChangeRewardCampaign(ChangeRewardRequest req, out string errMsg) {
            var res = PrepareAndSendRequest<ChangeRewardResponse>(
                "ChangeRewardCampaign", req, out errMsg);
            return (ChangeRewardResponse)res;
        }

        public static ExchangeTPPResponse ExchangeTicketPromoPending(double amount, out string errMsg) {
            var req = new ExchangeTPPRequest() {
                Amount = amount.ToString()
            };
            var res = PrepareAndSendRequest<ExchangeTPPResponse>(
                "ExchangeTicketPromoPending", req, out errMsg);
            return (ExchangeTPPResponse)res;
        }


        public static bool CancelTicketPromoPending(string validationNo, out string errMsg) {
            var req = new CancelTPPRequest() {
                ValidationNo = validationNo
            };
            var res = PrepareAndSendRequest<BaseResponse>(
                "CancelTicketPromoPending", req, out errMsg);
            return res.ResponseCode == 0;
        }
    }
}
