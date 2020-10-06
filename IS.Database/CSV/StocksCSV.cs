using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class StocksCSV
    {
        [Name("Principal Name")]
        public string PrincipalName { get; set; }

        [Name("Product Name")]
        public string ProductName { get; set; }

        [Name("Category")]
        public string CategoryName { get; set; }

        [Name("Stocks")]
        public string Quantity { get; set; }

        [Name("Supplier Price")]
        public string SupplierPrice { get; set; }

        [Name("Total Amount")]
        public string TotalAmount { get; set; }

        [Name("Unit Price With Added Formula")]
        public string UnitPriceWithAddedFormula { get; set; }

        [Name("Selling Price")]
        public string SellingPrice { get; set; }

        [Name("Unit Sold")]
        public string UnitSold { get; set; }

        [Name("Remaining Items")]
        public string RemainingQuantity { get; set; }

        [Name("Remaining Amount")]
        public string RemainingAmount { get; set; }

        [Name("Additional Notes")]
        public string Remarks { get; set; }
    }
}
