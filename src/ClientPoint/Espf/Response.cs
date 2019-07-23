namespace ClientPoint.Espf {
    /// <summary>
    /// Respuesta de ESPF.
    /// Este obj se deserializa desde un json.
    /// </summary>
    public class Response {
        public Response() {
            jsonrpc = "2.0";
        }
        public string jsonrpc;
        public string result;
        public Error error;
        public string id;

        public static Response FromJson(string json) => 
            (Response)JsonUtils.Deserialize(typeof(Response), json);
    }
    public class Error {
        public int code;
        public string message;
    }
}
