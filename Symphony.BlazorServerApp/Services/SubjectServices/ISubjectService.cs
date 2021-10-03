using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.SubjectServices
{
    public interface ISubjectService
    {
        Task<SubjectVM> GetSubjectVMAsync(int id);

        Task<IEnumerable<SubjectVM>> GetSubjectVMsAsync();

        Task CreateSubjectVMAsync(SubjectCreateRequest createRequest, MultipartFormDataContent Image, MultipartFormDataContent File);

        Task UpdateSubjectVMAsync(SubjectUpdateRequest subjectVM);

        Task ChangeSubjectState(int id);
    }
}
