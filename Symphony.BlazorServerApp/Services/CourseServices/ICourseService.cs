using Symphony.ViewModels.CourseViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.CourseServices
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseVM>> GetCourseVMsAsync();
        Task<CourseWithSubjects> GetCourseVMAsync(int id);
        Task CreateAsync(CourseCreateRequest course);
        Task UpdateAsync(CourseUpdateRequest course);
        Task DeleteAsync(int id);
    }
}
