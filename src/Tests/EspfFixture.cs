using System;
using Common;
using Espf;
using Espf.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class EspfFixture {
        
        [TestMethod]
        public void Json() {
            const string JSON_EMPTY_REQUEST =
                "{\"id\":null,\"jsonrpc\":\"2.0\",\"method\":null}";

            var req = new BaseRequest();
            var json = JsonUtils.Serialize(typeof(BaseRequest), req);
            Assert.AreEqual(JSON_EMPTY_REQUEST, json);

            // Request deserializado
            var req2 = (BaseRequest)JsonUtils.Deserialize(typeof(BaseRequest), JSON_EMPTY_REQUEST);
            Assert.AreEqual(null, req2.id);
            Assert.AreEqual(null, req2.method);
            Assert.AreEqual("2.0", req2.jsonrpc);
        }

        // Los siguientes tests utilizan el ESPF
        // (Fallan si no existe o no está configurado correctamente)

        [TestMethod]
        public void SendEchoRequest() {
            var result = Services.Echo("ECHO1", "test");
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void SendPrintRequest() {
            var session = Services.PrintBegin("PRINT1");
            Assert.IsFalse(string.IsNullOrEmpty(session));
            var res = Services.PrintEnd("PRINT2", session);
            Assert.AreEqual("OK", res);
        }

        // Para los test, no deberia detectar una impresora
        [ExpectedException(typeof(Exception), "Device not found")]
        [TestMethod]
        public void SendGetStateRequest() {
            Services.SupGetState("STATE1");
        }

        [Ignore]
        [ExpectedException(typeof(Exception), "Error de comunicación con ESPF.")]
        [TestMethod]
        public void SendFail() {
            // Asigno una puerto invalido
            var org = Config.EspfPort;
            Config.EspfPort = "999";
            var req = new BaseRequest();
            var res = Client.Send(req);
            Config.EspfPort = org;
        }
    }
}
