using System;
using System.IO.Pipes;
using System.Net.Http;
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

                string json = "";

                // Metodo default: TcpClient
                if (Config.EspfCommMethod == 0)
                    json = GetStream(req);

                // Metodo alternativo 1 (TcpClient)
                if (Config.EspfCommMethod == 1)
                    json = SendTcpAlternative(req);

                // Metodo NamedPipedStream
                if (Config.EspfCommMethod == 2)
                    json = SendPipe(req.ToJson());
                
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

        /// <summary>
        /// Utiliza otro metodo TCP para consumir la API
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private static string SendTcpAlternative(Request.BaseRequest req) {
            string json = "";
            try {
                json = req.ToJson();
                using (var socket = NewClient()) {
                    var body = Encoding.UTF8.GetBytes(json);
                    var bodyLength = Encoding.UTF8.GetByteCount(json);

                    var headerContent = new StringBuilder();
                    headerContent.AppendLine("POST /someUrl/someReceiver.aspx HTTP/1.0");
                    headerContent.AppendLine("Accept: */*");
                    headerContent.AppendLine("Host: " + Config.EspfIp);
                    headerContent.AppendLine("Content-Type: application/javascript; charset=utf-8");
                    headerContent.AppendLine("Content-Length: " + bodyLength);
                    headerContent.AppendLine("Connection: Close");
                    headerContent.AppendLine();

                    var headerString = headerContent.ToString();
                    var header = Encoding.UTF8.GetBytes(headerString);
                    var headerLength = Encoding.UTF8.GetByteCount(headerString);

                    var received = 0;
                    var res = "";

                    var data = new byte[1024];
                    var recv = 0;
                    var hasAnswers = false;

                    using (var stream = socket.GetStream()) {
                        stream.Write(header, 0, headerLength);
                        stream.Write(body, 0, bodyLength);

                        //stream.Flush();

                        while ((stream.DataAvailable) || (!hasAnswers)) {
                            recv = stream.Read(data, 0, data.Length);
                            received += recv;
                            res += Encoding.UTF8.GetString(data, 0, recv);
                            hasAnswers = true;
                            Thread.Sleep(10);
                        }
                        stream.Close();
                    }
                    // make post request
                    //socket.Client.Send(header, headerLength, SocketFlags.ControlDataTruncated);

                    //// get response
                    //byte[] bytes = new byte[1024];
                    //int lengthOfResponse = socket.Client.Receive(bytes);

                    //var resp = System.Text.Encoding.UTF8.GetString(bytes, 0, lengthOfResponse);
                    return res;
                }
            } catch (Exception ex) {
                throw new Exception(
                    $"Error al enviar request a ESPF (Send2). " +
                    $"Json => {json}", ex);
            }
        }

        public static string SendPipe(string request) {
            NamedPipeClientStream pipeClient;

            string res = string.Empty;

            pipeClient = new NamedPipeClientStream(
                ".", "EspfServer00", PipeDirection.InOut);
            try {
                pipeClient.Connect(5000);
                pipeClient.ReadMode = PipeTransmissionMode.Message;
                if (pipeClient.IsConnected == true) {
                    byte[] datain = Encoding.UTF8.GetBytes(request);
                    pipeClient.Write(datain, 0, datain.Length);

                    // Get answer
                    int recv = 0;
                    byte[] data = new byte[1024];

                    do {
                        recv = pipeClient.Read(data, 0, data.Length);
                        res += Encoding.UTF8.GetString(data, 0, recv);
                    } while (!pipeClient.IsMessageComplete);
                }
            } catch (Exception ex) {
                throw ex;
            } finally {
                pipeClient.Close();
                pipeClient.Dispose();
            }

            return res;
        }
    }
}
