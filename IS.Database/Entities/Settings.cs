using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Settings
    {
        public int Id { get; set; }
        public int ExpirationAlert { get; set; }
        public int ReturnItem { get; set; }
        public DateTime InsertTime { get; set; }
        public decimal SeniorDiscount { get; set; }
        public decimal PWDDiscount { get; set; }
    }
}
