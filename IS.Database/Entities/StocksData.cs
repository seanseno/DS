﻿using IS.Database.Entities.Extender;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class StocksData : StocksDataExtender
    {
        public int Id { get; set; }
        public string ProductId{ get; set; }
        public string PrincipalId { get; set; }
        public string CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal SuggestedPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SellingPrice { get; set; }
        public int RemainingQuantity { get; set; }
        public int UnitSold { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Remarks { get; set; }
        public string Loginname { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
