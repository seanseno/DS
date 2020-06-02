using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Common.Utilities
{
    public static class DateTimeConvertion
    {
        public static string ConvertDateString(DateTime entity)
        {
            //return entity.ToString("yyyy-MM-dd HH:mm:ss");
            return entity.ToString("yyy-MM-dd HH:mm:ss");
        }
    }
}
