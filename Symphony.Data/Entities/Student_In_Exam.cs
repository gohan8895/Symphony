using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Student_In_Exam
    {
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}