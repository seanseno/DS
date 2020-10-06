using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string CategoryId{ get; set; }
        public string CategoryName { get; set; }
        public Decimal PercentSuggestedPrice { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
