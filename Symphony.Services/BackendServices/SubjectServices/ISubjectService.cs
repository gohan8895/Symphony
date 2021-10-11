using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.SubjectServices
{
    public interface ISubjectService
    {
        Task<SubjectVM> GetSubjectVMAsync(int id);

        Task<IEnumerable<SubjectVM>> GetSubjectVMsAsync();

        Task<SimpleSubjectVM> CreateSubjectVMAsync(SubjectCreateRequest request);

        Task<SimpleSubjectVM> UpdateSubjectVMAsync(SubjectUpdateRequest request);

        Task<SimpleSubjectVM> UpdateSubjectImageVMAsync(int id, List<IFormFile> images);
        Task<SimpleSubjectVM> UpdateSubjectFileVMAsync(int id,  List<IFormFile> files);

        Task ChangeSubjectState(int id);
    }
}