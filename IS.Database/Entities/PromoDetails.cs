
using IS.Database.Entities.Extender;
using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class PromoDetails
    {
        public int Id { get; set; }
        public int PromoId { get; set; }
        public string ProductId{ get; set; }
        public decimal Price { get; set;}
        public DateTime? InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}
