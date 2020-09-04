using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Library.Utility
{
    public static class DateConvertion
    {
        public static DateTime ConvertDateFromTime(DateTime DateFrom)
        {
            var strDate = DateFrom.ToShortDateString() + " 00:00:00";
            return Convert.ToDateTime(strDate);
        }
        public static DateTime ConvertDateToTime(DateTime DateFrom)
        {
            var strDate = DateFrom.ToShortDateString() + " 23:59:59";
            return Convert.ToDateTime(strDate);
        }

        public static double DaysBetween(DateTime d1, DateTime  DateTotay)
        {
            return (d1 - DateTotay).TotalDays;
        }
    }
}
