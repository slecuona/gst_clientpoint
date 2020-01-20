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
    }
}
