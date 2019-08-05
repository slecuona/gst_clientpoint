using System;

namespace ClientPoint.Session {
    public class Client {
        public int Id;
        public DateTime BirthDate;
        public string Name;
        public string LastName;
        public ClientStatus Status;
        public string Sex;
        public string StatusCard;
        public string IdCard;
        public int Points;

        // Se utiliza para la etapa de Alta/Confirmacion
        // del usuario.
        public string DocumentNumber;

        // La ingresa el usuario y se utiliza
        // para los requests con la API
        public string Password;

        public static ClientStatus ParseStatus(string s) {
            if (s == "P")
                return ClientStatus.Pendiente;
            if (s == "A")
                return ClientStatus.Activo;
            if (s == "X")
                return ClientStatus.NoExiste;
            if (s == "T")
                return ClientStatus.SinTarjeta;
            throw new Exception($"ClientStatus no valido: {s}");
        }
    }

    public enum ClientStatus {
        Pendiente = 0, // P
        Activo = 1, // A
        NoExiste = 2, // X
        SinTarjeta = 3 // T
    }
}
