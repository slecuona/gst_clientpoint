using System;
using ClientPoint;
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
    }
}
