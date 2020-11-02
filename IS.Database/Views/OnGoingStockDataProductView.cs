using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Views
{
    public class OnGoingStockDataProductView
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal? SupplierPrice { get; set; }
        public string LoginName { get; set; }
    }
}
