using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Models
{
    public class ProductExtender : GlobalExtender
    {
        public virtual string CategoryName { get; set; }
        public virtual string PrincipalName { get; set; }
        public virtual int Stock { get; set; }
    }
}
