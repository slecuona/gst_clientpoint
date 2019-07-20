using System;
using System.Net.Cache;
using Common;
using Espf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class EspfFixture {
        
        [TestMethod]
        public void Json() {
            const string JSON_EMPTY_REQUEST =
                "{\"id\":null,\"jsonrpc\":\"2.0\",\"method\":null}";

            var req = new Request();
            var json = JsonUtils.Serialize<Request>(req);
            Assert.AreEqual(JSON_EMPTY_REQUEST, json);

            // Request deserializado
            var req2 = JsonUtils.Deserialize<Request>(JSON_EMPTY_REQUEST);
            Assert.AreEqual(null, req2.id);
            Assert.AreEqual(null, req2.method);
            Assert.AreEqual("2.0", req2.jsonrpc);
        }

        [ExpectedException(typeof(Exception), "Error de comunicación con ESPF.")]
        [TestMethod]
        public void Send() {
            var req = new Request();
            var res = ServiceClient.Send(req);
        }

    }
}
