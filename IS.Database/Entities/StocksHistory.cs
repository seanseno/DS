using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class StocksHistory
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int? Stock { get;set; }
        public int? Credit { get; set; }
        public int? Debit { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
