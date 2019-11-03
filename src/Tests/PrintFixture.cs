using System;
using ClientPoint;
using ClientPoint.Espf;
using ClientPoint.IO;
using ClientPoint.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class PrintFixture {
        [TestMethod]
        public void CreateCardBMP() {
            var p = new PrintJob(new Client() {
                Name = "Juan José",
                LastName = "Perez Gonzalez"
            });
            p.CreateImage();
            var base64 = p.GetImageBase64();
            // Para que se envie correctamente en el request,
            // no debe ser muy largo.
            Assert.IsTrue(base64.Length < 1000000, 
                "La imagen en base64 no debe superar el millon de caracteres.");
        }

        [TestMethod]
        public void VoucherPrinterStatus() {
            var p = new VoucherPrinter();
            p.TryGetSerialStatus(out string st);
        }
    }
}
