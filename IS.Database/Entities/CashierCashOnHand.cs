using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class CashierCashOnHand : Cashiers
    {
        public override int Id { get; set; }
        public int CashierId { get; set; }
        public decimal Amount { get; set; }
        public override DateTime InsertTime { get; set; }
        public override DateTime UpdateTime { get; set; }
    }
}
