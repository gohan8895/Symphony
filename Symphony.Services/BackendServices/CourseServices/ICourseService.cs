﻿using Symphony.ViewModels.Consult;
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

        Task<CourseWithSubjects> CreateCourseAsync(CourseCreateRequest request);

        Task<int> UpdateCourseDetails(CourseUpdateRequest request);

        Task<int> UpdateSubjectInCourse(int courseId, List<int> request);

        Task<int> UpdateCourseStatus(int courseId);
    }
}