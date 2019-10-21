using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientPoint.Api;
using ClientPoint.Utils;

using static ClientPoint.Utils.ExUtils;

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

        public bool IsTicket => IdCategory == 2;

        public void Exchange() {
            if (IsTicket)
                ExchangeTicket();
            else
                ExchangeVoucher();
        }

        private void ExchangeVoucher() {
            var cl = ClientSession.CurrClient;
            var res = ApiService.ChangeReward(new ChangeRewardRequest() {
                IdCard = cl.IdCard,
                IdReward = IdReward.ToString()
            }, out string errMsg);
            DieIf(!string.IsNullOrEmpty(errMsg), errMsg);

            var voucher = res.VoucherPrinter;
            DieIf(string.IsNullOrEmpty(voucher), "Voucher vacio.");


            Debug.WriteLine(voucher);
            //TODO: Print Voucher
            Thread.Sleep(2000);
        }

        private void ExchangeTicket() {
            throw new NotImplementedException();
        }
    }
}
