using Microsoft.AspNetCore.Http;
using Symphony.ViewModels.CourseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.CourseServices
{
    public interface ICourseService
    {
        Task<CourseWithSubjects> GetCourseWithSubjectsAsync(int id);

        Task<IEnumerable<CourseWithSubjects>> GetCoursesWithSubjectsAsync();

        Task<IEnumerable<CourseVM>> SearchCourseAsync(string context);

        Task<CourseWithSubjects> CreateCourseAsync(CourseCreateRequest request);

        Task<int> UpdateCourseDetails(CourseUpdateRequest request);

        Task<int> UpdateCourseImageAsync(int id, IFormFile image);

        Task<int> UpdateSubjectInCourse(int courseId, List<int> request);

        Task<int> UpdateCourseStatus(int courseId);
    }
}