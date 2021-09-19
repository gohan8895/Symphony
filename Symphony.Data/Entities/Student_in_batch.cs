using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Student_in_batch
    {
        public int BatchId { get; set; }
        public Batch Batch { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}