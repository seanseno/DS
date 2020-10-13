using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class ReturnItems
    {
        public int Id { get; set; }
        public string ProductId{ get; set; }
        public int SalesId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string LoginName  { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
