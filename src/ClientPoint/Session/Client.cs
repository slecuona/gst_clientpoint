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
            return ClientStatus.Desconocido;
        }
    }

    public enum ClientStatus {
        Desconocido = 0,
        Pendiente = 1, // P
        Activo = 2, // A
        NoExiste = 3, // X
        SinTarjeta = 4 // T
    }
}
