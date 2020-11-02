
using IS.Database.Entities.Extender;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class PrinterCoordinates
    {
        public int Id { get; set; }
        public int PrintingType { get; set; }
        public string PrintingLabel { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
