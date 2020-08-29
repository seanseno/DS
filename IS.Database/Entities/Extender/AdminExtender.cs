using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities.Extender
{
    public class AdminExtender : GlobalExtender
    {
        public virtual string UserTypeString { get; set; }
    }
}
