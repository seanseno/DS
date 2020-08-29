using IS.Database.Entities.Extender;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class TempSales : TempSalesExtender
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int Qty { get; set; }
        public DateTime InsertTime { get; set; } 
        public int TempLedgerId { get; set; }
    }
}
