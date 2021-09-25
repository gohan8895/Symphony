using Microsoft.AspNetCore.Http;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.SubjectServices
{
    public interface ISubjectService
    {
        Task<SubjectVM> GetSubjectVMAsync(int id);

        Task<IEnumerable<SubjectVM>> GetSubjectVMsAsync();

        Task<SubjectVM> CreateSubjectVMAsync(SubjectCreateRequest createRequest);

        Task<SimpleSubjectVM> UpdateSubjectVMAsync(SubjectUpdateRequest subjectVM);

        Task ChangeSubjectState(int id);
    }
}