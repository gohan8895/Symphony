using Symphony.Data.EF;
using Symphony.ViewModels.ExamRegistrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.ExamRegistrationServices
{
    public class ExamRegistrationService : IExamRegistrationService
    {
        private readonly SymphonyDBContext _context;

        public Task<ExamRegistrationVM> CreateExamRegistrationAsync(ExamRegistrationCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ExamRegistrationVM> GetExamRegistrationbyExamIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamRegistrationVM>> GetExamRegistrationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateExamRegistraion(ExamRegistrationUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}