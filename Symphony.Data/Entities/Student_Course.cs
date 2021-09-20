using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Student_Course
    {
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}