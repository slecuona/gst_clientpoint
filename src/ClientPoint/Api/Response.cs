namespace ClientPoint.Api {
    public class BaseResponse {
        public int ResponseCode;
        public string ResponseDesc;
    }

    public class ClientStatusResponse : BaseResponse {
        public int IdClient;
        public string BirthDate;
        public string Name;
        public string LastName;
        public string Status;
        public string Sex;
        public string StatusCard;
        public string IdCard;
        public int Points;

        // Es la manera que encontre de diferenciar un error
        // de servidor o que el cliente no exista
        // (La API devuelve ResponseCode = 1)
        public bool NotExists => ResponseDesc?.Contains("Documento Inexistente") ?? false;
    }
}