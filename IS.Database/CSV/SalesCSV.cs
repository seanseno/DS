using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class SalesCSV
    {
        public int Id { get; set; }
        public int CashierId { get; set; }
        public string CashierName { get; set; }
        public int ItemId { get; set; }
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public string Amount { get; set; }
        public DateTime InsertTime { get; set; } 
    }
}
