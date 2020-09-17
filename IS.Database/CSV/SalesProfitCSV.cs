using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class SalesProfitCSV
    {
        [Name("Cashier Name")]
        public string Fullname { get; set; }
        [Name("Principal Name")]
        public string PrincipalName { get; set; }
        [Name("Category Name")]
        public string CategoryName { get; set; }
        [Name("Product Id")]
        public string ProductId { get; set; }
        [Name("Product Name")]
        public string ProductName { get; set; }
        [Name("Sold Quantity")]
        public string SoldQuantity { get; set; }
        [Name("Supplier Price")]
        public string SupplierPrice { get; set; }
        [Name("TotalA mount")]
        public string TotalAmount { get; set; }
        [Name("Selling Price")]
        public string SellingPrice { get; set; }
        [Name("Total Sales")]
        public string TotalSales { get; set; }
        [Name("Profit")]
        public string Profit { get; set; }
        [Name("InsertTime")]
        public string InsertTime { get; set; }
    }
}
