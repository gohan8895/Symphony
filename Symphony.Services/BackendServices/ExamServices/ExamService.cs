using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.Services.BackendServices.CourseServices;
using Symphony.Services.BackendServices.QuestionServices;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.ExamServices
{
    public class ExamService : IExamService
    {
        private readonly SymphonyDBContext _context;
        private readonly IQuestionService _service;

        public ExamService(SymphonyDBContext context, IQuestionService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<ExamVM> GetExamAsync(int id)
        {
            var _exam = await _context.Exams
                            .Include(x => x.QuestionExams).ThenInclude(x => x.Question)
                            .FirstOrDefaultAsync(x => x.Id == id);

            if (_exam is null)
            {
                throw new Exception(@"Exam id: {id} is not found");
            }
            return _exam.AsVM();
        }

        public async Task<IEnumerable<ExamVM>> GetExamsAsync()
        {
            var _exams = await _context.Exams
                        .Include(x => x.QuestionExams).ThenInclude(x => x.Question)
                        //.Where(x => x.IsShown == true)
                        .Select(x => x.AsVM())
                        .ToListAsync();
            return _exams;
        }

        public async Task<ExamVM> CreateExamAsync(ExamCreateRequest request)
        {
            var timeNow = DateTime.Now;
            var _exam = new Exam()
            {
                Name = request.Name,
                Description = request.Description,
                BatchId = request.BatchId,
                SubjectId = request.SubjectId,
                ExamDate = request.ExamDate,
                CreatedAt = timeNow,
                IsEntranceExam = request.IsEntranceExam,
                CourseId = request.CourseId,
                Duration = request.Duration
            };

            await _context.AddAsync(_exam);
            await _context.SaveChangesAsync();

            var createdQuestions = new List<QuestionVM>();
            if (request.excelsheet is not null)
            {
                var file = request.excelsheet;
                var questionList = new List<QuestionCreateRequest>();
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowcount; row++)
                        {
                            questionList.Add(new QuestionCreateRequest()
                            {
                                Question_Text = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                Opt1_value = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                Opt2_value = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                Opt3_value = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                Opt4_value = worksheet.Cells[row, 5].Value.ToString().Trim(),
                                Valid_Opt_key = int.Parse(worksheet.Cells[row, 6].Value.ToString().Trim()),
                                Score = int.Parse(worksheet.Cells[row, 7].Value.ToString().Trim()),
                                SubjectId = request.SubjectId
                            });
                        }
                    }

                    foreach (var question in questionList)
                    {
                        var createdQuestion = await _service.CreateQuestionAsync(question);
                        createdQuestions.Add(createdQuestion);
                    }

                    foreach (var createdQuestion in createdQuestions)
                    {
                        var _questionExam = new QuestionExam()
                        {
                            QuestionId = createdQuestion.Id,
                            ExamId = _exam.Id
                        };
                        await _context.QuestionExams.AddAsync(_questionExam);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            var _createdExam = await _context.Exams
                           .Include(x => x.QuestionExams).ThenInclude(x => x.Question)
                           .FirstOrDefaultAsync(x => x.Id == _exam.Id);

            return _createdExam.AsVM();
        }

        public Task<int> MarkExamAsFinished(int examId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateExamDetails(ExamUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}