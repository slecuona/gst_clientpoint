using System;

namespace ClientPoint.Utils {
    public static class ExUtils {
        public static void Die(string msg, Exception ex = null) {
            throw new Exception(msg, ex);
        }

        public static void DieIf(bool cond, string msg) {
            if(cond) Die(msg);
        }
    }
}
