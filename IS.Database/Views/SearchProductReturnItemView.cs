using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Views
{
    public class SearchProductReturnItemView
    {
        public DateTime InsertTime { get; set; }
        public string ProductName { get; set; }
        public int StockDataId { get; set; }
        public int SalesId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string Fullname { get; set; }
        public string CustomerName { get; set; }
        public string TransactionNo { get; set; }
    }
}
