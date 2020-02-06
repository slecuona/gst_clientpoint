using System;
using ClientPoint;
using ClientPoint.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class ConfigFixture {
        [TestMethod]
        public void Settings() {
            Assert.IsFalse(string.IsNullOrEmpty(Config.EspfIp));
            Assert.AreEqual("18000", Config.EspfPort);
            Assert.AreEqual("Evolis KC200", Config.EspfPrinter);
        }

        [TestMethod]
        public void Strings() {
            ClientPoint.Strings.Init();
            Assert.AreEqual("BIENVENIDO",
                ClientPoint.Strings.Get("bienvenido"));

            Assert.AreEqual("En este momento hay problemas de conexión.\nDisculpe las molestias.",
                ClientPoint.Strings.Get("problemas_conexion"));
        }

        [TestMethod]
        public void CodArea() {
            ClientPoint.CodArea.Init();
            Assert.IsTrue(ClientPoint.CodArea.Valid(11));
            Assert.IsFalse(ClientPoint.CodArea.Valid(12));

            var test1 = ClientPoint.CodArea.Parse("1112345678");
            Assert.AreEqual("11", test1.Item1);
            Assert.AreEqual("12345678", test1.Item2);

            // Aca probamos que no detecte 385 como cod de area
            var test2 = ClientPoint.CodArea.Parse("3858123456");
            Assert.AreEqual("3858", test2.Item1);
            Assert.AreEqual("123456", test2.Item2);

            var test3 = ClientPoint.CodArea.Parse("12345678");
            Assert.AreEqual("", test3.Item1);
            Assert.AreEqual("12345678", test3.Item2);

            // Cod.Area desconocido, fallback
            var test4 = ClientPoint.CodArea.Parse("3895123456");
            Assert.AreEqual("3895", test4.Item1);
            Assert.AreEqual("123456", test4.Item2);
        }
    }
}
