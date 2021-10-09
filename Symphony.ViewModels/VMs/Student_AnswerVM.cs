using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Student_AnswerViewModel
{
    public class Student_AnswerVM
    {
        public Guid UserId { get; set; }
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public int Answer_value { get; set; }
    }

    public class Student_AnswerCreateRequest
    {
        public Guid UserId { get; set; }
        public int ExamId { get; set; }
        public Dictionary<int, int> studentAnswers { get; set; }
    }
}