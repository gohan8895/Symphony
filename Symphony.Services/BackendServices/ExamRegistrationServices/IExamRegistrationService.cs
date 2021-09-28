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
        Task<ExamRegistrationVM> GetExamRegistrationbyExamIdAsync(int id);

        Task<IEnumerable<ExamRegistrationVM>> GetExamRegistrationsAsync();

        Task<ExamRegistrationVM> CreateExamRegistrationAsync(ExamRegistrationCreateRequest request);

        Task<int> UpdateExamRegistraion(ExamRegistrationUpdateRequest request);
    }
}