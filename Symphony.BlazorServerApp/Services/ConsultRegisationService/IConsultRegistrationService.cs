using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.ConsultRegisationService
{
    public interface IConsultRegistrationService
    {
        Task<IEnumerable<ConsultVM>> GetConsultRegistrations();

        Task<ConsultVM> GetConsultRegistration(int id);

        Task<int> PostConsultRegistration(ConsultCreateRequest registration);

        Task<int> PutConsultRegistration(int id);

        Task DeleteConsultRegistration(int id);
    }
}