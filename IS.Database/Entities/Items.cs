using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Items : ItemReceivedOrders
    {
        public override int Id { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public override string CategoryName { get; set; }
        public override string CompanyName { get; set; }
        public override string GenericName { get; set; }
        public override string BrandName { get; set; }
        public override string Description { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public string PriceString
        {
            get
            {
                return String.Format("{0:n}", Price);
            }
        }

        public int Stock { get;set; }

        public string StockString
        {
            get
            {
                return String.Format("{0:n0}", Stock);
            }
        }

        public override DateTime InsertTime { get; set; }
        public override DateTime UpdateTime { get; set; }
        public override int Active { get; set; }

        public int TempItemId { get; set; }
    }
}
