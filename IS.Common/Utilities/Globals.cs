using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Common.Utilities
{
    public static class Globals
    {
        // parameterless constructor required for static class
        static Globals() { LoginId = null; LoginName = null; } // default value

        // public get, and private set for strict access control
        public static int? LoginId { get; private set; }
        public static string LoginName { get; private set; }
        // GlobalInt can be changed only via this method
        public static void SetLoginId(int loginId, string loginName)
        {
            LoginId = loginId;
            LoginName = loginName;
        }
    }
}
