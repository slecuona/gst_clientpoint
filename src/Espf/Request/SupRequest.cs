using Common;

namespace Espf.Request {
    public class SupRequest : BaseRequest {
        public SupParams parameters;

        public SupRequest() {}
        public SupRequest(string id, string method) : base(id) {
            this.parameters = new SupParams();
            this.method = $"SUPERVISION.{method}";
        }
    }

    public class SupParams {
        public string device = Config.EspfPrinter;
    }
}
