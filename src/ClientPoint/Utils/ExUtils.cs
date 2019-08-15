using System;

namespace ClientPoint.Utils {
    public static class ExUtils {
        public static void Die(string msg) {
            throw new Exception(msg);
        }

        public static void DieIf(bool cond, string msg) {
            if(cond) Die(msg);
        }
    }
}
