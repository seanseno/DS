using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class ReturnItemsCSV
    {
        [Name("Cashier Name")]
        public string Fullname { get; set; }

        [Name("Product Name")]
        public string ProductName { get; set; }

        [Name("Quantity")]
        public string Qty { get; set; }

        [Name("Price")]
        public string Price { get; set; }

        [Name("Date And Time")]
        public string InsertTime { get; set; }
    }
}
