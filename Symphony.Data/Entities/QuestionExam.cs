using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class QuestionExam
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}