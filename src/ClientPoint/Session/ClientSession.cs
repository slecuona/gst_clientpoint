using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPoint.Session {
    public class ClientSession {
        public static string DocumentNumber;

        public static void Clear() {
            DocumentNumber = null;
        }

        public static void EnterDocument(string doc) {
            DocumentNumber = doc;
        }
    }
}
