using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Subject_Course
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}