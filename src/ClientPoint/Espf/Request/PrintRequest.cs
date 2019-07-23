namespace ClientPoint.Espf.Request {
    public class PrintRequest : BaseRequest {
        public PrintParams parameters;

        public PrintRequest() {}
        public PrintRequest(string id, PrintMethods method, PrintParams parameters) : base(id) {
            this.parameters = parameters;
            this.method = $"PRINT.{method}";
        }
    }

    public enum PrintMethods {
        Begin = 0,
        Set = 1,
        SetBitmap = 2,
        Print = 3,
        GetJobID = 4,
        End = 5
    }

    public class PrintParams {
        public string session;
        public string face;
        public string panel;
        public string data;
        public string device;
    }
}
