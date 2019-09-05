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

    public class PrintRequestStart : BaseRequest {
        public PrintParamsStart parameters;

        public PrintRequestStart() { }
        public PrintRequestStart(string id, PrintMethods method, PrintParamsStart parameters) : base(id) {
            this.parameters = parameters;
            this.method = $"PRINT.{method}";
        }
    }

    public class PrintParamsStart {
        public string session;
    }

    public class PrintRequestSet : BaseRequest {
        public PrintParamsSet parameters;

        public PrintRequestSet() { }
        public PrintRequestSet(string id, PrintMethods method, PrintParamsSet parameters) : base(id) {
            this.parameters = parameters;
            this.method = $"PRINT.{method}";
        }
    }

    public class PrintParamsSet {
        public string data;
        public string session;
    }
}
