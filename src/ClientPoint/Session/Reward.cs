using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ClientPoint.Api;
using ClientPoint.IO;
using ClientPoint.Utils;
using Telerik.WinControls;
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

            // El string viene "escapado"
            var voucher = Regex.Unescape(res.VoucherPrinter);

            DieIf(string.IsNullOrEmpty(voucher), "Voucher vacio.");

            var success = VoucherPrinter.TryPrintRaw(voucher, out string err);
            DieIf(!success, err);
            Thread.Sleep(2000);
        }

        private void ExchangeTicket() {
            var cl = ClientSession.CurrClient;
            var res = ApiService.ExchangeTicketPromoPending(
                AmountPromotion, out string err);
            DieIf(!string.IsNullOrEmpty(err), err);

            DieIf(string.IsNullOrEmpty(res.TicketToPrinter),
                "Ticket vacio.");

            DieIf(string.IsNullOrEmpty(res.ValidationNo),
                "ValidationNo vacio.");

            var tp = new TicketPrinter();
            if(tp.TryPrint(res.TicketToPrinter, out string pErr)){
                var resExc = ApiService.ChangeReward(new ChangeRewardRequest() {
                    IdCard = cl.IdCard,
                    IdReward = IdReward.ToString(),
                    ValidationNo = res.ValidationNo
                    
                }, out string errMsg);
                // TODO: Ticket invalido??
                DieIf(!string.IsNullOrEmpty(errMsg), errMsg);
            }
            else {
                var resCancel = ApiService.CancelTicketPromoPending(
                    res.ValidationNo, out string errCancel);
                // TODO: que pasa si no se pudo cancelar el ticket?
                Die("Error al imprimir ticket");
            }
        }
    }
}
