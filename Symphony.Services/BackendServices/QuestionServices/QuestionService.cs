using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Symphony.Services.BackendServices.QuestionServices
{
    public class QuestionService : IQuestionService
    {
        private readonly SymphonyDBContext _context;

        public QuestionService(SymphonyDBContext context)
        {
            _context = context;
        }

        public async Task<QuestionVM> CreateQuestionAsync(QuestionCreateRequest request)
        {
            var _question = new Question()
            {
                Question_Text = request.Question_Text,
                Opt1_key = 1,
                Opt1_value = request.Opt1_value,
                Opt2_key = 2,
                Opt2_value = request.Opt2_value,
                Opt3_key = 3,
                Opt3_value = request.Opt3_value,
                Opt4_key = 4,
                Opt4_value = request.Opt4_value,
                Valid_Opt_key = request.Valid_Opt_key,
                SubjectId = request.SubjectId
            };

            if (request.Score != 0)
            {
                _question.Score = request.Score;
            }
            else _question.Score = 20;

            await _context.Questions.AddAsync(_question);
            await _context.SaveChangesAsync();

            return _question.AsVM();
        }
    }
}