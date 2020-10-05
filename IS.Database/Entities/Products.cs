
using IS.Database.Entities.Extender;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Products 
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Active { get; set; }
        public string BarCode { get; set; }
        public string ActiveString { get; set; }
    }
    public class ProductsKiosk
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Active { get; set; }
        public int Stock { get; set; }
        public string BarCode { get; set; }
    }
}
