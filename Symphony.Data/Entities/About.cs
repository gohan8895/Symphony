using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class About
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsShown { get; set; }
    }
}