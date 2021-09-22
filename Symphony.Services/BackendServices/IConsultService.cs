using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices
{
    public interface IConsultService
    {
        Task<IEnumerable<ConsultVM>> GetConsultRegistrations();

        Task<ConsultVM> GetConsultRegistration(int id);

        Task<int> PostConsultRegistration(ConsultCreateRequest registration);

        Task PutConsultRegistration(ConsultUpdateRequest registration, int id);

        Task DeleteConsultRegistration(int id);
    }
}