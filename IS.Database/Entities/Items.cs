using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Items
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
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
        public DateTime DateManufactured { get; set; }
        public DateTime ExpirationDate { get; set; }

        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Active { get; set; }

        public int TempItemId { get; set; }
    }
}
