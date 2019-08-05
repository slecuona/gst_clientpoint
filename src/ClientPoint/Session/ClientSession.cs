using System;
using ClientPoint.Api;

namespace ClientPoint.Session {
    public class ClientSession {
        public static Client CurrClient;

        public static void Clear() {
            CurrClient = null;
        }

        public static void Load(ClientStatusResponse res, string doc) {
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
                DocumentNumber = doc
            };
        }
    }
}
