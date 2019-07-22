using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Espf.Request;

namespace Espf {
    public static class Services {
        public static string Echo(string id, string data) {
            var req = new EchoRequest(id, data);
            var res = Client.Send(req);
            if(res.error != null)
                throw new Exception(
                    $"Response error: {res.error.code} - {res.error.message}");
            return res.result;
        }
    }
}
