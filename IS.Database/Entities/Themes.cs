using IS.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Themes
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string WallPaper { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public string CompanyName { get; set; }
    }
}
