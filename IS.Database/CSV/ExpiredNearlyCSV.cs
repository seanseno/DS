using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.CSV
{
    public class ExpiredNearlyCSV
    {
        [Name("Principal Name")]
        public string PrincipalName { get; set; }

        [Name("Product Name")]
        public string ProductName { get; set; }

        [Name("Category")]
        public string CategoryName { get; set; }

        [Name("Remaining Items")]
        public string RemainingQuantity { get; set; }

        [Name("Remaining Amount")]
        public string RemainingAmount { get; set; }

        [Name("Delivery Date")]
        public string DeliveryDate { get; set; }

        [Name("Expiration Date")]
        public string ExpirationDate { get; set; }

        [Name("Additional Notes")]
        public string Remarks { get; set; }
    }
}
