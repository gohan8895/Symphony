using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.EnrollmentServices
{
    public interface IEnrollmentService
    {
        Task<EnrollmentVM> GetEnrollmentVMAsync(Guid studentId, int courseId);

        Task<IEnumerable<EnrollmentWithData>> GetEnrollmentWithDataVM();

        /*Task<EnrollmentVM> CreateEnrollment(CreateEnrollmentVM enrollmentVM);*/

        Task<int> UpdateEnrollment(UpdateEnrollmentVM enrollmentVM);

        Task<int> ChangeEnrollmentStatus(Guid studentId, int courseId);
    }
}
