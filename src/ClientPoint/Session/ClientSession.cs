namespace ClientPoint.Session {
    public class ClientSession {
        public static string DocumentNumber;
        public static string Password;

        public static void Clear() {
            DocumentNumber = null;
            Password = null;
        }

        public static void EnterDocument(string doc) {
            DocumentNumber = doc;
        }
        public static void EnterPassword(string pass) {
            Password = pass;
        }
    }
}
