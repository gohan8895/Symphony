using Symphony.Data.Entities;
using Symphony.ViewModels.Student_AnswerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class Student_AnswerExtension
    {
        public static Student_AnswerVM AsVM(this Student_Answer stdAnswer) => new Student_AnswerVM
        {
            UserId = stdAnswer.UserId,
            QuestionId = stdAnswer.QuestionId,
            ExamId = stdAnswer.ExamId,
            ExamName = stdAnswer.Exam.Name,
            Answer_value = stdAnswer.Answer_value
        };
    }
}