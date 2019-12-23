using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDodeer.NoticeDomain;

namespace ToDodeer
{
    public class Point
    {
        public string Name { get; set; }
        public Content Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
