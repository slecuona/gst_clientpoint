using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientPoint.Utils;

namespace ClientPoint.Session {
    public class Reward {
        public int IdReward;
        public string Name;
        public int PointsRequired;
        public int Stock;
        public int IdCategory;
        public int Available;
        public string CategoryName;
        public double AmountPromotion;
        public string ImageData;

        public Image GetImage() {
            try {
                // Saco los primero 36 caracteres
                var base64 = ImageData.Substring(36, ImageData.Length - 36);
                if (GraphUtils.TryGetImageFromBase64(base64, out Image img))
                    return img;
            } catch (Exception e) {
                Logger.Exception(e);
            }
            return Properties.Resources.gift;
        }
    }
}
