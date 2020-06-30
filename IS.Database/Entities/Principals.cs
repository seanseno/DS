using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Principals
    {
        public int Id { get; set; }
        public string PrincipalId{ get; set; }
        public string PrincipalName { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
