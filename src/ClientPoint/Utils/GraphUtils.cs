using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientPoint.Utils {
    public static class GraphUtils {
        public static GraphicsPath GetRoundPath(RectangleF Rect, int radius) {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        /// <summary>
        /// Convierte el bitmap a un formato monocromatico.
        /// </summary>
        /// <param name="mono"></param>
        /// <returns></returns>
        public static Bitmap ConvertTo1Bpp(Bitmap mono) {
            Bitmap bmp = mono.Clone(new Rectangle(0, 0, mono.Width, mono.Height), PixelFormat.Format32bppArgb);

            try {
                //bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
                BitmapData bmdo = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                Bitmap bm = new Bitmap(mono.Width, mono.Height, PixelFormat.Format1bppIndexed);
                BitmapData bmdn = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);

                //scan through the pixels Y by X
                int x, y;
                for (y = 0; y < bmp.Height; y++) {
                    for (x = 0; x < bmp.Width; x++) {
                        //generate the address of the colour pixel
                        int index = y * bmdo.Stride + (x * 4);
                        //check its brightness
                        if (Color.FromArgb(Marshal.ReadByte(bmdo.Scan0, index + 2),
                                Marshal.ReadByte(bmdo.Scan0, index + 1),
                                Marshal.ReadByte(bmdo.Scan0, index)).GetBrightness() > 0.5f)
                            SetIndexedPixel(x, y, bmdn, true); //set it if its bright.
                    }
                }

                bmp.UnlockBits(bmdo);

                int length = Math.Abs(bmdn.Stride) * bmdn.Height;
                byte[] bytes = new byte[length];

                Marshal.Copy(bmdn.Scan0, bytes, 0, length);
                bm.UnlockBits(bmdn);

                return bm;
            } catch (Exception e) {
                return null;
            }
        }

        private static void SetIndexedPixel(int x, int y, BitmapData bmd, bool pixel) {
            int index = y * bmd.Stride + (x >> 3);
            byte p = Marshal.ReadByte(bmd.Scan0, index);
            byte mask = (byte)(0x80 >> (x & 0x7));
            if (pixel)
                p |= mask;
            else
                p &= (byte)(mask ^ 0xff);
            Marshal.WriteByte(bmd.Scan0, index, p);
        }

        public static bool TryGetImageFromBase64(string base64, out Image img) {
            img = null;
            try {
                    var imgData = Convert.FromBase64String(base64);

                    MemoryStream ms = new MemoryStream(imgData);
                    ms.Seek(0, SeekOrigin.Begin);

                    img = Image.FromStream(ms);

                //    var bitmap = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
                //    var bitmap_data = bitmap.LockBits(
                //        new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                //        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                //    Marshal.Copy(imgData, 0, bitmap_data.Scan0, imgData.Length);
                //    bitmap.UnlockBits(bitmap_data);
                //    img = bitmap as Image;

                //ImageConverter imageConverter = new System.Drawing.ImageConverter();
                //img = imageConverter.ConvertFrom(imgData) as System.Drawing.Image;


                //Bitmap bmp = new Bitmap(ms);
                //img = (Image) bmp;
                return true;
            }
            catch (Exception e) {
                Logger.Exception(e);
                return false;
            }
        }
    }


}
