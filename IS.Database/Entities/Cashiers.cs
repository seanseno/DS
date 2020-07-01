using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Cashiers : GlobalExtender
    {
        public virtual int Id { get; set; }
        public string CashierId { get; set; }
        public string Fullname { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public virtual DateTime InsertTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }
        public int Active { get; set; }
    }
}
