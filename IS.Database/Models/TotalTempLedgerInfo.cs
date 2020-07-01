using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Models
{
    public class TotalTempLedgerInfo
    {
        public int? Id { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? TotalQty { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
