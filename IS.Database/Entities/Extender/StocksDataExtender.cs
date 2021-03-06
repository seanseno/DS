﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities.Extender
{
    public class StocksDataExtender
    {
        public virtual string PrincipalName { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual decimal Profit { get; set; }
        public virtual decimal TotalSales { get; set; }
        //public virtual int RemainingAmount { get; set; }
    }
}
