using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class RequestOrderItemDetails
    {
        public int Id { get; set; }
        public int RequestOrderItemId { get; set; }
        public int ItemId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertTime { get; set; }

    }
}
