using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Views
{
    public class SalesViewReport
    {
        public DateTime? InsertTime { get; set; }
        public string Fullname { get; set; }
        public int? Id { get; set; }      
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int? SoldQuantity { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? SupplierPrice { get; set; }
        public decimal? Profit { get; set; }
        public decimal? Discounted { get; set; }
        public string Remarks { get; set; }
    }
}
