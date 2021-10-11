using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.ViewModels.Extensions
{
    public static class Exam_ResultExtension
    {
        public static Exam_ResultVM AsVM(this Exam_Result result) => new Exam_ResultVM
        {
            Id = result.Id,
            ExamId = result.ExamId,
            ExamName = result.Exam.Name,
            UserId = result.UserId,
            StudentName = result.AppUser.FirstName + " " + result.AppUser.LastName,
            CreatedAt = result.CreatedAt,
            TotalScore = result.TotalScore,
            Result = result.HasPassed ? "Passed" : "Failed"
        };
    }
}