namespace ClientPoint.Espf.Request {
    public class CmdRequest : BaseRequest {
        public CmdParams parameters;

        public CmdRequest() {}
        public CmdRequest(string id, CmdMethods method, string cmd = null) : base(id) {
            this.parameters = new CmdParams() {
                command = cmd
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
        public string timeout = "3000"; //TODO: config?
    }
}
