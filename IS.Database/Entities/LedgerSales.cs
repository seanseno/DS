using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class LedgerSales
    {
        public int Id { get; set; }
        public string CashierId { get; set; }
        public decimal PayAmount { get; set; }
        public decimal Change { get; set; }
        public string CustomerName { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
