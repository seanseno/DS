using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities.Extender
{
    public class ProductExtender : GlobalExtender
    {
        public virtual int Stock { get; set; }
    }
}
