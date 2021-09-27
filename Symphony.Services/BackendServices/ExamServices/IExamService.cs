using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.ExamServices
{
    public interface IExamService
    {
        Task<ExamVM> GetExamAsync(int id);

        Task<IEnumerable<ExamVM>> GetExamsAsync();

        Task<ExamVM> CreateExamAsync(ExamCreateRequest request);

        Task<int> UpdateExamDetails(ExamUpdateRequest request);

        Task<int> MarkExamAsFinished(int examId);
    }
}