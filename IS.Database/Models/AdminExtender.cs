using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Models
{
    public class AdminExtender : GlobalExtender
    {
        public virtual string UserTypeString { get; set; }
    }
}
