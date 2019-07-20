using System;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class ConfigFixture {
        [TestMethod]
        public void Settings() {
            Assert.AreEqual("127.0.0.1", Config.EspfIp);
            Assert.AreEqual("18000", Config.EspfPort);
            Assert.AreEqual("Evolis KC200", Config.EspfPrinter);
        }
    }
}
