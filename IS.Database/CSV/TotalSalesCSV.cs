using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class TotalSalesCSV
    {
        [Name("Cashier Name")]
        public string CashierName { get; set; }
        [Name("Product Name")]
        public string ProductName { get; set; }
        [Name("Amount")]
        public string Amount { get; set; }
        [Name("Quantity")]
        public string Qty { get; set; }
    }
}
