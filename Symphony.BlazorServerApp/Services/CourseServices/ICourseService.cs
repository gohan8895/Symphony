using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.CourseServices
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseWithSubjects>> GetCourseVMsAsync();
        Task<IEnumerable<CourseVM>> SearchCourseAsync(string context);
        Task<CourseWithSubjects> GetCourseVMAsync(int id);
        Task<int> CreateAsync(CourseCreateRequest course);
        Task<int> UpdateAsync(CourseUpdateRequest course);
        Task<int> UpdateImageAsync(int id, MultipartFormDataContent content);
        Task<int> UpdateCourseStatusAsync(int courseId);
        Task<int> UpdateSubjectInCourseAsync(int courseId, List<int> request);
    }
}
