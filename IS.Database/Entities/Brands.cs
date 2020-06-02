using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Brands
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Active { get; set; }
    }
}
