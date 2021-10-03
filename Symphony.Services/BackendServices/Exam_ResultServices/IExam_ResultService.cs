﻿using Symphony.ViewModels.Exam_ResultViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.Exam_ResultServices
{
    public interface IExam_ResultService
    {
        Task<IEnumerable<Exam_ResultVM>> GetAllExamResultAsync();

        Task<IEnumerable<Exam_ResultVM>> GetExamResultByExamIdAsync(int examId);

        Task<IEnumerable<Exam_ResultVM>> GetExamResultByStudentIdAsync(Guid studentId);
    }
}