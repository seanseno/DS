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
        [Name("Addtional Info.")]
        public string CustomerName { get; set; }
        [Name("Product Id")]
        public string ProductId { get; set; }
        [Name("Product Name")]
        public string ProductName { get; set; }
        [Name("Quantity")]
        public string Qty { get; set; }
        [Name("Price")]
        public string price { get; set; }
        [Name("Transaction Date and Time")]
        public string InsertTime { get; set; }
    }
}
