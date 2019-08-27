using System;
using ClientPoint;
using ClientPoint.Espf;
using ClientPoint.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class PrintFixture {
        [TestMethod]
        public void CreateBMP() {
            var p = new PrintJob(new Client() {
                Name = "Juan José",
                LastName = "Perez Gonzalez"
            });
            p.CreateImage();
            Assert.IsTrue(true);
        }
    }
}
