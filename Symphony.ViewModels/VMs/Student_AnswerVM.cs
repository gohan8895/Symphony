using System;
using System.Collections.Generic;

namespace Symphony.ViewModels.VMs
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