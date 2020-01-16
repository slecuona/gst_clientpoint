using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using ClientPoint.Api;
using ClientPoint.IO;
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
        public Int64 NroMvt;

        public Image GetImage(bool trunc = true) {
            try {
                string base64;
                if (trunc) {
                    // Por default, saco los primero 36 caracteres.
                    // Por alguna razon, trae esos caracteres de más,
                    // sin embargo aveces tampoco puede hacer conversion 
                    // correctamente.
                    base64 = ImageData.Substring(36, ImageData.Length - 36);
                }
                else
                    base64 = ImageData;
                
                var img = GraphUtils.TryGetImageFromBase64(base64);
                return img;
            } catch (Exception e) {
                Logger.WriteAsync($"Err. convert base64 trunc: {trunc}");
                Logger.Exception(e);
                // Fallback, intento sin truncar.
                if (trunc)
                    return GetImage(false);
            }
            return Properties.Resources.gift;
        }

        public bool IsTicket => IdCategory == 2;

        //public void Exchange() {
        //    if (IsTicket)
        //        ExchangeTicket();
        //    else
        //        ExchangeVoucher();
        //}

        public void ExchangeVoucher(Action<bool, string> onFinish, int quantity) {
            DieIf(IsTicket, "Reward debe ser tipo voucher.");

            // Antes de llamar a la API chequeo el estado...
            Status.CheckVoucherPrinter();
            if (!Status.VoucherPrinter.Contains(VoucherPrinterState.OK)) {
                Die("La impresora de voucher no esta disponible.");
            }
            
            var toPrint = new StringBuilder();
            var cl = ClientSession.CurrClient;
            var idx = 1;
            for (idx = 1; idx <= quantity; idx++) {
                var req = new ChangeRewardRequest() {
                    IdCard = cl.IdCard,
                    IdReward = IdReward.ToString(),
                    NroMvt = NroMvt.ToString()
                };
                string errMsg;
                var res = NroMvt > 0
                    ? ApiService.ChangeRewardCampaign(req, out errMsg)
                    : ApiService.ChangeReward(req, out errMsg);
                DieIf(!string.IsNullOrEmpty(errMsg), errMsg);

                // El string viene "escapado"
                var voucher = Regex.Unescape(res.VoucherPrinter);
                DieIf(string.IsNullOrEmpty(voucher), "Voucher vacio.");

                toPrint.AppendLine(voucher);
            }
            var p = new VoucherPrinter();
            p.OnFinish = onFinish;
            p.PrintAsync(toPrint.ToString());
        }

        public void ExchangeTicket(Action<bool, string> onFinish) {
            DieIf(!IsTicket, "Reward debe ser ticket promocional.");

            // Antes de llamar a la API chequeo el estado...
            Status.CheckTicketPrinter();
            if (!Status.TicketPrinter.Contains(TicketPrinterState.OK)) {
                Die("La impresora de tickets no esta disponible.");
            }

            var cl = ClientSession.CurrClient;
            var res = ApiService.ExchangeTicketPromoPending(
                AmountPromotion, out string err);
            DieIf(!string.IsNullOrEmpty(err), err);

            DieIf(string.IsNullOrEmpty(res.TicketToPrinter),
                "Ticket vacio.");

            DieIf(string.IsNullOrEmpty(res.ValidationNo),
                "ValidationNo vacio.");

            var p = new TicketPrinter();
            var onFinishCalled = false;
            p.OnFinish = (success, errMsg) => {
                if (onFinishCalled)
                    return;
                onFinishCalled = true;
                if (success) {
                    var req = new ChangeRewardRequest() {
                        IdCard = cl.IdCard,
                        IdReward = IdReward.ToString(),
                        ValidationNo = res.ValidationNo,
                        NroMvt = NroMvt.ToString()
                    };
                    string err2;
                    var resExc = NroMvt > 0 ?
                        ApiService.ChangeRewardCampaign(req, out err2) :
                        ApiService.ChangeReward(req, out err2);
                    // TODO: Ticket invalido??
                    DieIf(!string.IsNullOrEmpty(err2), err2);
                    onFinish?.Invoke(true, null);
                }
                else {
                    var resCancel = ApiService.CancelTicketPromoPending(
                        res.ValidationNo, out string errCancel);
                    // TODO: que pasa si no se pudo cancelar el ticket?
                    onFinish?.Invoke(false, $"No se pudo imprimir el Ticket: {errMsg}");
                }
            };
            p.PrintAsync(res.TicketToPrinter);
        }
    }
}
