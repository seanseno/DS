using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Views
{
    public class ReturnIemsView : ReturnItems
    {
        public string Fullname { get; set; }
        public string ProductName { get; set; }
    }
}
