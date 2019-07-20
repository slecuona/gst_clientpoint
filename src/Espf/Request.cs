namespace Espf {
    /// <summary>
    /// Estructura base de un request de ESPF.
    /// Este obj se des/serializa en json.
    /// </summary>
    public class Request {
        public Request() {
            jsonrpc = "2.0";
        }
        public string jsonrpc;
        public string method;
        public string id;
    }
}
