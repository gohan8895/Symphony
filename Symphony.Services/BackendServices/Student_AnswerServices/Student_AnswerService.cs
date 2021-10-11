using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.Student_AnswerServices
{
    public class Student_AnswerService : IStudent_AnswerService
    {
        private readonly SymphonyDBContext _context;

        public Student_AnswerService(SymphonyDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student_AnswerVM>> GetStudent_AnswerVMAsync(Guid studentId, int examId)
        {
            var student_answers = await _context.Student_Answers
                                    .Include(x => x.Exam)
                                    .Where(x => x.UserId == studentId && x.ExamId == examId)
                                    .Select(x => x.AsVM())
                                    .ToListAsync();

            return student_answers;
        }

        public async Task<IEnumerable<Student_AnswerVM>> CreateStudent_AnswerVMAsync(Student_AnswerCreateRequest request)
        {
            //check if student has submited exam before
            if (await CheckExist(request.UserId, request.ExamId))
            {
                //return null;
                throw new Exception("Student has already taken the exam");
            }

            int totalScore = 0;
            var timeNow = DateTime.Now;
            var studentAnswers = new List<Student_Answer>();

            //calculating students Score
            var QuestionsWithAnswer = new Dictionary<int, int>();
            var _questionsExam = await _context.QuestionExams
                .Include(x => x.Question)
                .Where(x => x.ExamId == request.ExamId).ToListAsync();
            foreach (var x in _questionsExam)
            {
                QuestionsWithAnswer.Add(x.QuestionId, x.Question.Valid_Opt_key);
            }
            foreach (var studentAnswer in request.studentAnswers)
            {
                var _stdAnswer = new Student_Answer()
                {
                    UserId = request.UserId,
                    QuestionId = studentAnswer.Key,
                    ExamId = request.ExamId,
                    Answer_value = studentAnswer.Value,
                    CreatedAt = timeNow
                };

                //For every correct answer, student get 10
                if (_stdAnswer.Answer_value == QuestionsWithAnswer[_stdAnswer.QuestionId])
                {
                    totalScore += 10;
                }

                studentAnswers.Add(_stdAnswer);
            }

            await _context.Student_Answers.AddRangeAsync(studentAnswers);
            await _context.SaveChangesAsync();

            var createdStdAns = await _context.Student_Answers
                                .Include(x => x.Exam)
                                .Where(x => x.ExamId == request.ExamId && x.UserId == request.UserId)
                                .Select(x => x.AsVM()).ToListAsync();
            //inserting ExamResult after student submit test
            var _examResult = new Exam_Result()
            {
                ExamId = request.ExamId,
                UserId = request.UserId,
                CreatedAt = timeNow,
                TotalScore = totalScore,
                IsShown = true,
                HasPassed = totalScore >= 50 ? true : false
            };

            await _context.Exam_Results.AddAsync(_examResult);
            await _context.SaveChangesAsync();
            return createdStdAns;
        }

        private async Task<bool> CheckExist(Guid studentId, int examId)
        {
            var _studentResult = await _context.Exam_Results
                                .FirstOrDefaultAsync(x => x.UserId == studentId && x.ExamId == examId);
            if (_studentResult is not null) return true;
            return false;
        }
    }
}