using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public int CashierId { get; set; }
        public int ItemId { get; set; }
        public string CustumerName { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public string AmountString { get { return String.Format("{0:n}", Amount); } }
        public DateTime InsertTime { get; set; } 

        public string CashierName { get; set; }
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
    }
}
