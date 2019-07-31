using ClientPoint.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class ApiFixture {
        [TestMethod]
        public void LoadAdvertising() {
            var res = ApiService.LoadAdvertising();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void ClientCreate() {
            var success = ApiService.ClientCreate(new ClientCreateRequest(), out string errMsg);
            // Cuando enviamos vacio, si la api esta ok, nos devuelve lo siguiente:
            Assert.IsFalse(success);
            Assert.IsTrue(errMsg.Contains("El Documento ingresado ya existe."));
        }
    }
}
