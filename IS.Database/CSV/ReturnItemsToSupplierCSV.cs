using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class ReturnItemsToSupplierCSV
    {
        [Name("Transaction By")]
        public string Fullname { get; set; }

        [Name("Principal Name")]
        public string PrincipalName { get; set; }

        [Name("Category Name")]
        public string CategoryName { get; set; }

        [Name("Product ID")]
        public string ProductId { get; set; }

        [Name("Product Name")]
        public string ProductName { get; set; }

        [Name("Return Quantity")]
        public string ReturnQty { get; set; }

        [Name("Date And Time")]
        public string InsertTime { get; set; }

        [Name("Remarks")]
        public string Remarks { get; set; }
    }
}
