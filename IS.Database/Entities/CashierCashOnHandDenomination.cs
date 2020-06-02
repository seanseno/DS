using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class CashierCashOnHandDenomination
    {
        public int Id { get; set; }
        public string CashierId { get; set; }
        public decimal Thousand { get; set; }
        public decimal FiveHundred { get; set; }
        public decimal OneHundred { get; set; }
        public decimal Fifty { get; set; }
        public decimal Twenty { get; set; }
        public decimal Coins { get; set; }
        public decimal Cents { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
