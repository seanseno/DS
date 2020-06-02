using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Administrators
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Active { get; set; }

    }
}
