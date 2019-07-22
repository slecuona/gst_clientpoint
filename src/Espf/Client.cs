using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Common;

namespace Espf {
    /// <summary>
    /// Esta clase se encarga de comunicarse con el ESPF por TCP
    /// </summary>
    public static class Client {

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

        // Este metodo se replicó del DemoProgram (EspfClientProcessor)
        private static string GetStream(TcpClient client, Request.BaseRequest req) {
            var res = string.Empty;
            var reqJson = req.ToJson();
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

            } finally {
                client.Close();
            }
            return res;
        }

        private static object _locker = new object();

        public static string Send(Request.BaseRequest req) {
            lock (_locker) {
                var client = NewClient();
                var json = GetStream(client, req);
                if (string.IsNullOrEmpty(json))
                    throw new Exception("Se esperaba un json.");
                var res = Response.FromJson(json);
                if (res.error != null)
                    throw new Exception(
                        $"Response error: {res.error.code} - {res.error.message}");
                return res.result;
            }
        }
    }
}
