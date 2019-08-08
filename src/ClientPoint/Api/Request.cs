// Este archivo contiene la estructura de todos los request
// que realiza la API
namespace ClientPoint.Api {
    public struct ClientCreateRequest {
        public string DocumentNumber;
        public string Password;
        public string CelPhone;
        public string Email;
        public string Name;
        public string LastName;
        public string BirthDate;
        public string Sex;
    }

    public struct ClientUpdateRequest {
        public string DocumentNumber;
        public string Password;
        public string CelPhone;
        public string Email;
    }

    public struct ConfirmCodeRequest {
        public string DocumentNumber;
        public string Password;
        public string Code;
    }

    public struct ClientStatusRequest {
        public string DocumentNumber;
    }

    public struct ClientLoadRequest {
        public string IdCard;
    }
}
