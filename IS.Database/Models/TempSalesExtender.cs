using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Models
{
    public class TempSalesExtender 
    {
        public virtual string ProductName { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
