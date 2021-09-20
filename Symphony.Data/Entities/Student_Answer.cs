using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Student_Answer
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        public int Answer_value { get; set; }
        public DateTime CreatedAt { get; set; }
        public AppUser AppUser { get; set; }
        public Question Question { get; set; }
        public Exam Exam { get; set; }
    }
}