using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.QuestionServices
{
    public interface IQuestionService
    {
        Task<QuestionVM> CreateQuestionAsync(QuestionCreateRequest request);
    }
}