using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.QuestionServices
{
    public interface IQuestionService
    {
        Task<QuestionVM> CreateQuestionAsync(QuestionCreateRequest request);
    }
}