using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities.Extender
{
    public class TempSalesExtender 
    {
        public virtual string ProductName { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal TotalPrice { get; set; }
        public virtual decimal Discount { get; set; }
    }
}
