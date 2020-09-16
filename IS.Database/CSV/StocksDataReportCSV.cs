using CsvHelper.Configuration.Attributes;
using IS.Database.Entities;
using IS.Database.Entities.Extender;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class StocksDataReportCSV  
    {
        [Name("Principal Name")]
        public  string PrincipalName { get; set; }

        [Name("Product Name")]
        public string ProductName { get; set; }

        [Name("Category Name")]
        public string CategoryName { get; set; }

        public string Quantity { get; set; }

        [Name("Supplier Price")]
        public string SupplierPrice { get; set; }

        [Name("Total Amount")]
        public string TotalAmount { get; set; }

        [Name("Remaining Quantity")]
        public string RemainingQuanity { get; set; }

        [Name("Unit Sold")]
        public string UnitSold { get; set; }

        [Name("Product Selling Price")]
        public string ProductSellingPrice { get; set; }

        [Name("Total Sales")]
        public string TotalSales { get; set; }

        public string Profit { get; set; }

        [Name("Delivery Date")]
        public string DeliveryDate { get; set; }

        [Name("Expiration Date")]
        public string ExpirationDate { get; set; }
        
    }
}
