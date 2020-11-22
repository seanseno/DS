using IS.Database.Entities.Extender;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class StocksDataHistory : StocksDataHistoryExtender
    {
        public string ProductId{ get; set; }
        public string PrincipalId { get; set; }
        public string CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int RemainingQuantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Remarks { get; set; }
        public string TransactionBy { get; set; }
        public DateTime InsertTime { get; set; }

        public int StocksDataId { get; set; }
    }
}
