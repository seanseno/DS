
using IS.Database.Entities.Extender;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class ProductPriceHistory 
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Fullname { get; set; }
        public decimal ChangeFrom { get; set; }
        public decimal ChangeTo { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
