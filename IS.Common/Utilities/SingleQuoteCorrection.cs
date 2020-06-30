using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Common.Utilities
{
    public static class SingleQuoteCorrection
    {
        public static string convert(string input)
        {
            return input.Replace("'", "''");
        }

    }
}
