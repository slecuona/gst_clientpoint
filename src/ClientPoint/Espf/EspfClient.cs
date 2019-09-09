using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ClientPoint.Utils;

namespace ClientPoint.Espf {
    /// <summary>
    /// Esta clase se encarga de comunicarse con el ESPF por TCP
    /// </summary>
    public static class EspfClient {

        private static void Log(string msg) {
            if (!Config.DebugMode)
                return;
            Logger.WriteBuff(msg);
        }

        private static TcpClient NewClient() {
            TcpClient client = null;
            try {
                var ip = Config.EspfIp;
                var port = int.Parse(Config.EspfPort);
                client = new TcpClient(ip, port);
            }
            catch (Exception e) {
                throw new Exception("Error de comunicación con ESPF.", e);
            }
            return client;
        }

        private static string GetStream(Request.BaseRequest req) {
            var intents = 0;
            do {
                intents++;
                var client = NewClient();
                if (TryGetStream(client, req, out string res))
                    return res;
                Thread.Sleep(1000);
                Log($"Fail GetStream intent {intents}.");
            } while (intents < 3);
            return null;
        }

        // Este metodo se replicó del DemoProgram (EspfClientProcessor)
        private static bool TryGetStream(TcpClient client, Request.BaseRequest req, out string res) {
            res = "";
            var reqJson = req.ToJson();
            Log($"[JSON SEND] => {reqJson}");
            var datain = Encoding.UTF8.GetBytes(reqJson);
            try {
                NetworkStream ns = client.GetStream();
                var received = 0;
                ns.Write(datain, 0, datain.Length);
                ns.Flush();
                var data = new byte[1024];
                var recv = 0;
                var hasAnswers = false;

                while ((ns.DataAvailable) || (!hasAnswers)) {
                    recv = ns.Read(data, 0, data.Length);
                    received += recv;
                    res += Encoding.UTF8.GetString(data, 0, recv);
                    hasAnswers = true;
                    Thread.Sleep(10);
                }
                ns.Close();
            } catch (Exception ex) {
                Log($"ERR. GetStream. => {ex.Message}");
                Logger.Exception(ex);
                return false;
            } finally {
                client.Close();
            }
            return !string.IsNullOrEmpty(res);
        }

        private static object _locker = new object();

        public static string Send(Request.BaseRequest req) {
            lock (_locker) {
                var json = GetStream(req);
                if (string.IsNullOrEmpty(json))
                    throw new Exception("Se esperaba un json.");
                Log($"[JSON RESPONSE] => {json}");
                var res = Response.FromJson(json);
                if (res.error != null)
                    throw new Exception(
                        $"Response error: {res.error.code} - {res.error.message}");
                return res.result;
            }
        }
    }
}
