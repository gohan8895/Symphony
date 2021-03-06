using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.ConsultServices
{
    public interface IConsultService
    {
        Task<IEnumerable<ConsultVM>> GetConsultRegistrations();

        Task<ConsultVM> GetConsultRegistration(int id);

        Task<int> PostConsultRegistration(ConsultCreateRequest registration);

        Task PutConsultRegistration(int id);

        Task DeleteConsultRegistration(int id);
    }
}