using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.ConsultRegisationService
{
    public interface IConsultRegistrationService
    {
        Task<IEnumerable<ConsultVM>> GetConsultRegistrations();

        Task<ConsultVM> GetConsultRegistration(int id);

        Task<int> PostConsultRegistration(ConsultCreateRequest registration);

        Task PutConsultRegistration(int id);

        Task DeleteConsultRegistration(int id);
    }
}