using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.CourseRegistrationServices
{
    public interface ICourseRegistrationService
    {
        Task<IEnumerable<CourseRegistrationVM>> GetAllCourseRegistrationVMsAsync();

        Task<IEnumerable<CourseRegistrationWithDataVM>> GetCourseRegistrationWithDataVMsAsync();

        Task<CourseRegistrationWithDataVM> GetCourseRegistrationVMAsync(int id);

        Task<CourseRegistrationWithDataVM> CreateCourseRegistrationAsync(CreateCourseRegistrationVM courseRegistration);

        Task<CourseRegistrationVM> UpdateCourseRegistrationAsync(int courseRegistration);

        Task<CourseRegistrationVM> DeleteCourseRegistrationAsync(int id);
    }
}