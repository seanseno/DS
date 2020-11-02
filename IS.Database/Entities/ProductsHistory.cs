
using IS.Database.Entities.Extender;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class ProductsHistory
    {
        public int Id { get; set; }
        public string Remarks { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertTime { get; set; }
        public int Active { get; set; }
        public string BarCode { get; set; }

        public string FullName { get; set; }
        
    }
}
