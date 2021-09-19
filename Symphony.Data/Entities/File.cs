using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}