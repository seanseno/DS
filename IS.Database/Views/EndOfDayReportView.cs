using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Views
{
    public class EndOfDayReportView
    {
        public int? Id { get; set; }
        public string Fullname { get; set; }
        public string CustomerName { get; set; }
        public string PrincipalName { get; set; }
        public string CategoryName { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Qty { get; set; }
        public decimal? price { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
