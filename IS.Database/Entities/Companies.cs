using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Companies
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
