using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPoint {
    public static class VoucherPrinter {
        public static void Print(string t) {
            var doc = new PrintDocument();
            doc.PrinterSettings.PrinterName = "Custom GT";
            var font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular, GraphicsUnit.Point);

            doc.PrintController = new StandardPrintController();

            doc.PrintPage += delegate (object sender1, PrintPageEventArgs e1) {
                e1.Graphics.DrawString(t, 
                    font, 
                    new SolidBrush(Color.Black), 
                    new RectangleF(0, 0, 
                        doc.DefaultPageSettings.PrintableArea.Width, 
                        doc.DefaultPageSettings.PrintableArea.Height));
                e1.HasMorePages = false;
            };
            try {
                doc.Print();
            } catch (Exception ex) {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        public static void PrintPOS(string t) {
            //var p = new OPOS
        }
    }
}
