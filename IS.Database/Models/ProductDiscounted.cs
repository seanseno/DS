using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Models
{
    public class ProductDiscounted
    {
        public string ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal PriceDiscounted { get; set; }
        public decimal Discounted { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
