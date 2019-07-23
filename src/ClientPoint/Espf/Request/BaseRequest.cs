namespace ClientPoint.Espf.Request {
    /// <summary>
    /// Estructura base de un request de ESPF.
    /// Este obj se serializa a json.
    /// </summary>
    public class BaseRequest {
        public BaseRequest() {
            jsonrpc = "2.0";
        }
        public BaseRequest(string id = null) : base() {
            this.id = id;
            jsonrpc = "2.0";
        }

        public string jsonrpc;
        public string method;
        public string id;

        public string ToJson() => 
            JsonUtils.Serialize(this.GetType(), this)
                // En .NET no podemos utilizar "params" como propiedad
                .Replace("parameters", "params");
    }
}
