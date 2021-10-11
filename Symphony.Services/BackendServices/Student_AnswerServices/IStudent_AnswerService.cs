using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.Services.BackendServices.Student_AnswerServices
{
    public interface IStudent_AnswerService
    {
        Task<IEnumerable<Student_AnswerVM>> GetStudent_AnswerVMAsync(Guid studentId, int examId);

        Task<IEnumerable<Student_AnswerVM>> CreateStudent_AnswerVMAsync(Student_AnswerCreateRequest request);
    }
}