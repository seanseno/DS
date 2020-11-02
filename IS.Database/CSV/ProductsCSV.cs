using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class ProductsCSV
    {

        [Name("ProductId")]
        public string ProductId { get; set; }

        [Name("Product Name")]
        public string ProductName { get; set; }

        [Name("Price")]
        public string Price { get; set; }

        [Name("Inser Time")]
        public string InserTime { get; set; }

        [Name("Update Time")]
        public string UpdateTime { get; set; }

        [Name("Barcode")]
        public string Barcode { get; set; }

        [Name("Active")]
        public string Active { get; set; }
    }
}
