using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.CourseRegistrationService
{
    public interface ICourseRegistrationService
    {
        Task<IEnumerable<CourseRegistrationVM>> GetAllCourseRegistrationVMsAsync();
        Task<IEnumerable<CourseRegistrationWithDataVM>> GetCourseRegistrationWithDataVMsAsync();
        Task<CourseRegistrationWithDataVM> GetCourseRegistrationVMAsync(int id);
        Task<int> CreateAsync(CreateCourseRegistrationVM courseRegistration);
        Task<int> UpdateAsync(int id);
        Task<int> DeleteAsync(int id);
    }
}
