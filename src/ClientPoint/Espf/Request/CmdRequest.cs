namespace ClientPoint.Espf.Request {
    public class CmdRequest : BaseRequest {
        private const int DEF_TIMEOUT = 5000;
        public CmdParams parameters;

        public CmdRequest() {}
        public CmdRequest(string id, CmdMethods method, string cmd = null, int timeout = 0) : base(id) {
            if (timeout == 0)
                timeout = DEF_TIMEOUT;

            this.parameters = new CmdParams() {
                command = cmd,
                timeout = timeout.ToString()
            };
            this.method = $"CMD.{method}";
        }
    }

    public enum CmdMethods {
        SendCommand = 0,
        GetStatus = 1,
        ResetCom = 2
    }

    public class CmdParams {
        public string device = Config.EspfPrinter;
        public string command;
        public string timeout;
    }
}
