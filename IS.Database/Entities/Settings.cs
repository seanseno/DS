using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Settings
    {
        public int Id { get; set; }
        public int ExpirationAlert { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
