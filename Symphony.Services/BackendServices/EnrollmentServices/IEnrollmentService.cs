using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.EnrollmentServices
{
    public interface IEnrollmentService
    {
        Task<EnrollmentVM> GetEnrollmentVMAsync(Guid studentId, int courseId);

        Task<IEnumerable<EnrollmentVM>> GetEnrollmentVMsAsync();

        Task<EnrollmentVM> CreateEnrollment(CreateEnrollmentVM enrollmentVM);

        Task<EnrollmentVM> UpdateEnrollment(UpdateEnrollmentVM enrollmentVM);

        Task<int> ChangeEnrollmentStatus(Guid studentId, int courseId);

        Task<IEnumerable<EnrollmentWithData>> GetEnrollmentWithDataVM();
    }
}