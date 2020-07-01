using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class TempLedgerSales : GlobalExtender
    {
        public int? Id { get; set; }
        public string CashierId { get; set; }
        //public string Fullname { get; set; }
        //public decimal? TotalAmount { get; set; }
        //public int? TotalQty { get; set; }
        //public int? OrdersId { get; set; }
        public DateTime InsertTime { get; set; }
        public string CustomerName { get; set; }
        public int?  Active { get; set; }
    }
}
