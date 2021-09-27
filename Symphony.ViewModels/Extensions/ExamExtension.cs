using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class ExamExtension
    {
        public static ExamVM AsVM(this Exam exam) => new ExamVM
        {
            Id = exam.Id,
            Name = exam.Name,
            Description = exam.Description,
            BatchId = exam.BatchId,
            SubjectId = exam.SubjectId,
            ExamDate = exam.ExamDate,
            IsEntranceExam = exam.IsEntranceExam,
            CourseId = exam.CourseId,
            Duration = exam.Duration,
            Questions = exam.QuestionExams.Select(x => x.Question.AsVM()).ToList()
        };
    }
}