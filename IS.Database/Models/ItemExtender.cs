using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Models
{
    public class ItemExtender
    {
        public virtual string CategoryName { get; set; }
        public virtual string PrincipalName { get; set; }
        public virtual string ActiveString { get; set; }
        public virtual int Stock { get; set; }
    }
}
