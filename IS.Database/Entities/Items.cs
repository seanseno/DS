using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Items : ItemExtender
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string CategoryId { get; set; }
        public string PrincipalId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int Active { get; set; }
        public string BarCode { get; set; }
    }
}
