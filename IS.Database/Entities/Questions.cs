using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
