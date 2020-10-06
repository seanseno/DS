using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Views
{
    public class StocksDataViewReport
    {
        public string PrincipalName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal UnitPriceWithAddedFormula { get; set; }
        public decimal SellingPrice { get; set; }
        public int UnitSold { get; set; }
        public int RemainingQuantity { get; set; }
        public decimal RemainingAmount { get; set; }
        public string Remarks { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
