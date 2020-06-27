using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class ItemReceivedOrders : ItemExtender
    {
        public virtual int Id { get; set; }
        public int RequestOrderId { get; set; }
        public int ItemId { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime DateManufactured { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public int Stocks { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal SellingPricePerPiece { get; set; }
        public virtual DateTime InsertTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }
        public virtual int Active { get; set; }
    }
}
