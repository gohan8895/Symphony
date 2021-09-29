using Symphony.ViewModels.Consult;
using Symphony.ViewModels.ExamRegistrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.ExamRegistrationServices
{
    public interface IExamRegistrationService
    {
        Task<IEnumerable<ExamRegistrationVM>> GetExamRegistrationbyExamIdAsync(int examId);

        Task<IEnumerable<ExamRegistrationVM>> GetExamRegistrationsAsync();

        Task<IEnumerable<ExamRegistrationVM>> CreateExamRegistrationAsync(ExamRegistrationCreateRequest request);

        Task<int> UpdateExamRegistraion(ExamRegistrationUpdateRequest request);

        Task<int> DeleteExamRegistraionAsync(int examId);
    }
}