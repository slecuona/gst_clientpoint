using System;
using ClientPoint.Api;

namespace ClientPoint.Session {
    public class ClientSession {
        public static Client CurrClient;
        // Nos indica si el cliente accedió por Tarjeta (o #Doc)
        public static bool AccessByCard;

        public static void Clear() {
            CurrClient = null;
            AccessByCard = false;
        }

        public static void Load(ClientStatusResponse res, string doc) {
            AccessByCard = doc == null;
            CurrClient = new Client() {
                Id = res.IdClient,
                BirthDate = res.BirthDate != null ? DateTime.Parse(res.BirthDate) : DateTime.MinValue,
                Name = res.Name,
                LastName = res.LastName,
                Status = Client.ParseStatus(res.Status),
                Sex = res.Sex,
                StatusCard = res.StatusCard,
                IdCard = res.IdCard,
                Points = res.Points,
                DocumentNumber = doc,
            };
        }
    }
}
