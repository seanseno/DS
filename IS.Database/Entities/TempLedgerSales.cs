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
        public DateTime InsertTime { get; set; }
        public int?  Active { get; set; }
    }
}
