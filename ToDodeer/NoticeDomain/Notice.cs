using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDodeer
{
    public class Notice
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; } = new List<Point>();
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
