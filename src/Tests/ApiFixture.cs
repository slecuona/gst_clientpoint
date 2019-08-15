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

        [TestMethod]
        public void ClientUpdate() {
            var success = ApiService.ClientUpdate(new ClientUpdateRequest(), out string errMsg);
            // Cuando enviamos vacio, si la api esta ok, nos devuelve lo siguiente:
            Assert.IsFalse(success);
            Assert.IsTrue(errMsg.Contains("El Cliente ya se encuentra Activo."));
        }

        [TestMethod]
        public void ConfirmCode() {
            var success = ApiService.ConfirmCode(new ConfirmCodeRequest(), out string errMsg);
            // Cuando enviamos vacio, si la api esta ok, nos devuelve lo siguiente:
            Assert.IsFalse(success);
            Assert.IsTrue(errMsg.Contains("El Cliente ya se encuentra Activo."));
        }

        [TestMethod]
        public void ClientStatus() {
            var res = ApiService.ClientStatus(new ClientStatusRequest(), out string errMsg);
            // Cuando enviamos vacio, nos devuelve el cliente 1
            Assert.IsTrue(string.IsNullOrEmpty(errMsg));
            Assert.AreEqual(1, res.IdClient);
        }

        [TestMethod]
        public void ClientStatusNotExists() {
            var res = ApiService.ClientStatus(new ClientStatusRequest() {
                DocumentNumber = "NOTEXISTS"
            }, out string errMsg);
            Assert.IsTrue(res != null);
            Assert.IsTrue(res.NotExists);
        }

        [TestMethod]
        public void ClientSession() {
            const string doc = "123456789";
            var res = ApiService.ClientStatus(new ClientStatusRequest() {
                DocumentNumber = doc // Es valido
            }, out string errMsg);
            Assert.IsTrue(res != null);
            Assert.IsFalse(res.NotExists);

            ClientPoint.Session.ClientSession.Load(res, doc);
            var client = ClientPoint.Session.ClientSession.CurrClient;
            Assert.IsFalse(client == null);
        }

        [TestMethod]
        public void ClientLoadInvalid() {
            var res = ApiService.ClientLoad(new ClientLoadRequest() {
                IdCard = ""
            }, out string errMsg);
            // Si enviamos null, nos da error, devuelve este json:
            // {"Message":"An error has occurred."}
            // Si enviamos vacio, nos devuelve Tarjeta Inexistente
            Assert.IsTrue(errMsg.Contains("Tarjeta Inexistente"));
            Assert.IsTrue(res == null);
        }
    }
}
