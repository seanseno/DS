using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Stocks 
    {
        public string ProductId { get; set; }
        public int? Stock { get; set; }
        public string ProductName { get; set; }
    }
}
