
using IS.Database.Entities.Extender;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class ProductsDiscounted
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int IsSenior { get; set; }
        public int IsPWD { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public string ProductName { get; set; }
    }
  
}
