using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.ViewModels.Exam_ResultViewModel;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.Exam_ResultServices
{
    public class Exam_ResultService : IExam_ResultService
    {
        private readonly SymphonyDBContext _context;

        public Exam_ResultService(SymphonyDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exam_ResultVM>> GetAllExamResultAsync()
        {
            var _result = await _context.Exam_Results
                            .Include(x => x.Exam)
                            .Include(x => x.AppUser)
                            .Select(x => x.AsVM()).ToListAsync();

            return _result;
        }

        public async Task<IEnumerable<Exam_ResultVM>> GetExamResultByExamIdAsync(int examId)
        {
            var _result = await _context.Exam_Results
                            .Include(x => x.Exam)
                            .Include(x => x.AppUser)
                            .Where(x => x.ExamId == examId)
                            .Select(x => x.AsVM()).ToListAsync();

            return _result;
        }

        public async Task<IEnumerable<Exam_ResultVM>> GetExamResultByStudentIdAsync(Guid studentId)
        {
            var _result = await _context.Exam_Results
                           .Include(x => x.Exam)
                           .Include(x => x.AppUser)
                           .Where(x => x.UserId == studentId)
                           .Select(x => x.AsVM()).ToListAsync();

            return _result;
        }
    }
}