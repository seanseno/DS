using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Models
{
    public class ItemExtender
    {
        public virtual string CategoryName { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string GenericName { get; set; }
        public virtual string BrandName { get; set; }
        public virtual string Description { get; set; }
    }
}
