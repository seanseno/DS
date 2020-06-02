using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class RequestOrderItems
    {
        public int Id { get; set; }
        public int AdministratorId { get; set; }
        public string RequestOrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime InsertTime { get; set; }

    }
}
