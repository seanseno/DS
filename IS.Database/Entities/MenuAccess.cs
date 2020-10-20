using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class MenuAccess 
    {
        public int? Id { get; set; }
        public string AdminId { get; set; }
        public string MenuName { get; set; }
        public string MenuText { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
