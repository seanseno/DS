using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class SalesCSV
    {
        [Name("Date")]
        public string Date { get; set; }

        [Name("Time")]
        public string Time { get; set; }

        [Name("Clerk")]
        public string Fullname { get; set; }

        [Name("Additional Info.")]
        public string CustmerName { get; set; }

        [Name("Transactio No")]
        public string Id { get; set; }

        [Name("Month")]
        public string Month { get; set; }

        [Name("Category")]
        public string CategoryName { get; set; }

        [Name("Sold Products")]
        public string ProductName { get; set; }

        [Name("Quantity")]
        public string SoldQuantity { get; set; }

        [Name("Unit Price")]
        public string SellingPrice { get; set; }

        [Name("Total Amount")]
        public string TotalAmount { get; set; }

        [Name("Supplier Price")]
        public string SupplierPrice { get; set; }

        [Name("Profit")]
        public string Profit { get; set; }

        [Name("Additional Note")]
        public string Remarks { get; set; }
    }
}
