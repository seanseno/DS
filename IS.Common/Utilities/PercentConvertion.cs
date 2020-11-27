using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Common.Utilities
{
    public static class PercentConvertion
    {
        public static string Percent(decimal percent)
        {
            var val = Convert.ToDecimal(percent).ToString("N2");
            var res = val.Substring(val.Length - 3, 3);

            if (res == ".00")
            {
                return val.Replace(".00", "");
            }
            else
            {
                return Convert.ToDecimal(percent).ToString("N2");
            }
        }
        public static string PercentWithSymbol(decimal percent)
        {
            var val = Convert.ToDecimal(percent).ToString("N2");
            var res = val.Substring(val.Length - 3, 3);

            if (res == ".00")
            {
                return val.Replace(".00", "") + " %";
            }
            else
            {
                return Convert.ToDecimal(percent).ToString("N2") + " %";
            }
        }
    }
}
