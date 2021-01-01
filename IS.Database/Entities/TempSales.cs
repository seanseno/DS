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
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PriceDiscounted { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discounted { get; set; }
        public int TempLedgerId { get; set; }
        public int IsSenior { get; set; }
        public int IsPWD { get; set; }
        public int IsPromo { get; set; }
        public int? PromoId { get; set; }
        public DateTime InsertTime { get; set; } 
     

    }
}
