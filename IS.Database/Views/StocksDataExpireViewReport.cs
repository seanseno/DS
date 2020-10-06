using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Views
{
    public class StocksDataExpireViewReport
    {
        public int Id { get; set; }
        public string PrincipalId { get; set; }
        public string PrincipalName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
   
        public int Quantity { get; set; }
        public int RemainingQuantity { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Remarks { get; set; }
    }
}
