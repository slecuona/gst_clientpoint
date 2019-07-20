namespace Espf {
    /// <summary>
    /// Estructura base de un request de ESPF.
    /// Este obj se serializa a json.
    /// </summary>
    public class Request {
        public Request() {
            jsonrpc = "2.0";
        }
        public string jsonrpc;
        public string method;
        public string id;

        public string ToJson() => 
            JsonUtils.Serialize<Request>(this)
                // En .NET no podemos utilizar "params" como propiedad
                .Replace("parameters", "params");
    }
}
