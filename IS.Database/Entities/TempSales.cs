using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class TempSales
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public DateTime InsertTime { get; set; } 
    }
}
