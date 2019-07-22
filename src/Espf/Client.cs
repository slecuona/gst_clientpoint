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
        private static string GetStream(TcpClient client, Request req) {
            var res = string.Empty;
            try {
                NetworkStream ns = client.GetStream();
                var received = 0;
                var datain = Encoding.UTF8.GetBytes(req.ToJson());
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
        
        public static Response Send(Request req) {
            var client = NewClient();
            var json = GetStream(client, req);
            return Response.FromJson(json);
        }
    }
}
