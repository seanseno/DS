using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class ReturnStocksData
    {
        public int Id { get; set; }
        public int StockDataId { get; set; }
        public int ReturnQty { get; set; }
        public string Remarks { get; set; }
        public string LoginName { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
