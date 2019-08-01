namespace ClientPoint.Api {
    public struct ClientCreateRequest {
        public string DocumentNumber;
        public string Password;
        public string CelPhone; //TODO: o CellPhone?
        public string Email;
        public string Name;
        public string LastName;
        public string BirthDate;
        public string Sex;
    }
}