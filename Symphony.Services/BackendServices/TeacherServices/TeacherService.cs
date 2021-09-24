using Microsoft.EntityFrameworkCore;
using Symphony.Data.EF;
using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using Symphony.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.TeacherServices
{
   public class TeacherService:ITeacherService
    {

        private readonly SymphonyDBContext symphonyDBContext;

        public TeacherService(SymphonyDBContext symphonyDBContext)
        {
            this.symphonyDBContext = symphonyDBContext;
        }
        public async Task<TeacherVM> GetTeacherVMAsync(int id)

        {
            var teacher = await symphonyDBContext.Teachers.FirstOrDefaultAsync(t => t.Id == id);
            if (teacher is null) return null;
            return teacher.AsVM();
        }

        public async Task<IEnumerable<TeacherVM>> GetTeacherVmsAsync()
        {
            var teacher = await symphonyDBContext.Teachers.Select(a => a.AsVM()).ToListAsync();
            return teacher;

        }

        public async Task<TeacherVM> CreateTeacherAsync(CreateTeacherVM teacherVM)
        {
            var teacher = new Teacher { FirstName = teacherVM.FirstName, LastName = teacherVM.LastName };

            await symphonyDBContext.Teachers.AddAsync(teacher);
            await symphonyDBContext.SaveChangesAsync();
            return teacher.AsVM();
        }



        public async Task<TeacherVM> UpdateTeacherAsync(UpdateTeacherVM teacherVM)
        {
            var teacher = await symphonyDBContext.Teachers.FirstOrDefaultAsync(a => a.Id == teacherVM.Id);
            if (teacher is null) return null;
            teacher.FirstName = teacherVM.FirstName;
            teacher.LastName = teacher.LastName;

            await symphonyDBContext.SaveChangesAsync();
            return teacher.AsVM();

        }
        public async Task DeleteTeacherAsync(int id)
        {
            var teacher = await symphonyDBContext.Teachers.FirstOrDefaultAsync(a => a.Id == id);
            symphonyDBContext.Teachers.Remove(teacher);
            await symphonyDBContext.SaveChangesAsync();
        }
    }
}
