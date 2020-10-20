using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Views
{
    public class ReturnItemsToSupplierView : ReturnStocksData
    {
        public string Fullname { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string PrincipalId { get; set; }
        public string PrincipalName { get; set; }
    }
}
