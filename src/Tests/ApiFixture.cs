using System;
using ClientPoint;
using ClientPoint.Api;
using ClientPoint.Session;
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

        [TestMethod]
        public void GetNumberCard() {
            var res = ApiService.GetNumberCard();
            Assert.IsFalse(string.IsNullOrEmpty(res));
        }

        [TestMethod]
        public void CreateCard() {
            var res = ApiService.CreateCard(new CreateCardRequest(), out string errMsg);
            // Cuando enviamos vacio, nos devuelve:
            // "El Cliente ya tiene Tarjeta Asignada."
            Assert.IsFalse(string.IsNullOrEmpty(errMsg));
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void GetRewardsInvalid() {
            var res = ApiService.GetRewards("");
            Assert.IsTrue(res.Count == 0);
        }

        [TestMethod]
        public void GetRewardsNotEmpty() {
            var res = ApiService.GetRewards(Config.TEST_CARD);
            Assert.IsTrue(res.Count > 0);
        }

        [TestMethod]
        public void GetRewards() {
            var cl = ApiService.ClientStatus(new ClientStatusRequest() {
                DocumentNumber = "123456789"
            }, out string errMsg);
            if (cl.IdCard == null) {
                Assert.Fail("IdCard no puede ser null.");
                return;
            }
            var res = ApiService.GetRewards(cl.IdCard);
            Assert.IsTrue(res.Count > 0);

            var mgr = new RewardsManager(res);
            Assert.IsTrue(mgr.Categories.Count > 0);
        }

        [TestMethod]
        public void ChangeRewardErr() {
            //TODO: esto me devuelve An error has occurred.
            //Habria que ajustar la API para que no cambie el formato de la respuesta.
            var res = ApiService.ChangeReward(new ChangeRewardRequest() {
                IdCard = "0010100001234",
                IdReward = "2"
            }, out string err);
            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ChangeRewardVoucher() {
            var res = ApiService.ChangeReward(new ChangeRewardRequest() {
                IdCard = Config.TEST_CARD,
                IdReward = "2"
            }, out string err);
            Assert.AreEqual(err, "");
        }

        [TestMethod]
        public void ExchangeTPP() {
            var res = ApiService.ExchangeTicketPromoPending(10d, out string err);
            Assert.IsNotNull(res.TicketToPrinter);
            Assert.IsNotNull(res.ValidationNo);
        }

        [TestMethod]
        public void CancelTPP() {
            var res = ApiService.CancelTicketPromoPending("123", out string err);
            Assert.IsFalse(res);
            Assert.IsTrue(err.Contains("No se encontró"));
        }

        [TestMethod]
        public void GetRewardsCampaign() {
            var res = ApiService.GetRewardsCampaign(Config.TEST_CARD);
            Assert.IsTrue(res != null);
        }
    }
}