using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
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
            var res = p.GetStatus();
            Debug.WriteLine(string.Join("|", res));
            Assert.IsTrue(res.Contains(VoucherPrinterState.OK),
                $"get status not OK");
        }

        [TestMethod]
        public void TicketPrinterStatus() {
            const string noPaper = "*S|0|GRUSA4100|T|@|@|P |*";
            var s1 = new List<TicketPrinterState>();
            TicketPrinter.ParseStatus(noPaper, ref s1);
            Assert.IsTrue(s1.Contains(TicketPrinterState.EMPTY));
            Assert.IsTrue(s1.Contains(TicketPrinterState.SYS_ERROR));

            const string coverOpen = "*S|0|GRUSA4100|X|@|@|P |*";
            var s2 = new List<TicketPrinterState>();
            TicketPrinter.ParseStatus(coverOpen, ref s2);
            Assert.IsTrue(s2.Contains(TicketPrinterState.COVER_OPEN));
            
            const string standBy = "*S|0|GRUSA4100|@|@|@|P |*";
            var s3 = new List<TicketPrinterState>();
            TicketPrinter.ParseStatus(standBy, ref s3);
            Assert.IsTrue(s3.Contains(TicketPrinterState.OK));

            const string afterPrint = "*S|0|GRUSA4100|T|P|@|P9|*";
            var s4 = new List<TicketPrinterState>();
            TicketPrinter.ParseStatus(afterPrint, ref s4);
            Assert.IsTrue(s4.Contains(TicketPrinterState.PAPER_IN_CHUTE));
            
        }
    }
}
