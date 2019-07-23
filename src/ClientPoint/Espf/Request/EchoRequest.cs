namespace ClientPoint.Espf.Request {
    public class EchoRequest : BaseRequest {
        public EchoParams parameters;

        public EchoRequest() {}
        public EchoRequest(string id, string data) : base(id) {
            this.parameters = new EchoParams() {
                data = data
            };
            this.method = "ECHO.Echo";
        }
    }

    public class EchoParams {
        public string data;
    }
}
