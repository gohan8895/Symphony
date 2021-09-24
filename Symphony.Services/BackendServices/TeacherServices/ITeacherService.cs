using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.TeacherServices
{
  
   public interface ITeacherService
    {
        Task<TeacherVM> GetTeacherVMAsync(int id);
        Task<IEnumerable<TeacherVM>> GetTeacherVmsAsync();
        Task<TeacherVM> CreateTeacherAsync(CreateTeacherVM teacherVM);
        Task<TeacherVM> UpdateTeacherAsync(UpdateTeacherVM teacherVM);
        Task DeleteTeacherAsync(int id);

    }
}
