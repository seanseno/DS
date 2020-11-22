using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class SalesDetailCSV
    {
        [Name("Trnasaction No.")]
        public string Id { get; set; }
        [Name("Cashier")]
        public string Fullname { get; set; }

        [Name("Customer Name")]
        public string CustomerName { get; set; }
        [Name("Addtional Info.")]
        public string AdditionalInfo { get; set; }

        [Name("Category")]
        public string CategoryName { get; set; }

        [Name("Product Id")]
        public string ProductId { get; set; }
        [Name("Product Name")]
        public string ProductName { get; set; }
        [Name("Quantity")]
        public string Qty { get; set; }
        [Name("Price")]
        public string Price { get; set; }
        [Name("Total Price")]
        public string TotalPrice { get; set; }
        [Name("Transaction Date and Time")]
        public string InsertTime { get; set; }
    }
}
