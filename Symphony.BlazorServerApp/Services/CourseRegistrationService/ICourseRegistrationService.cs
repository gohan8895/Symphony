using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.CourseRegistrationService
{
    public interface ICourseRegistrationService
    {
        Task<IEnumerable<CourseRegistrationVM>> GetAllCourseRegistrationVMsAsync();
        Task<IEnumerable<CourseRegistrationWithDataVM>> GetCourseRegistrationWithDataVMsAsync();
        Task<CourseRegistrationVM> GetCourseRegistrationVMAsync(int id);
        Task CreateCourseRegistrationAsync(CreateCourseRegistrationVM courseRegistration);
        Task UpdateCourseRegistrationAsync(int id);
        Task DeleteCourseRegistrationAsync(int id);
    }
}
