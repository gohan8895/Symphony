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

namespace Symphony.Services.BackendServices.CourseServices
{
    public class CourseService : ICourseService
    {
        private readonly SymphonyDBContext _context;

        public CourseService(SymphonyDBContext context)
        {
            _context = context;
        }

        public async Task<CourseWithSubjects> GetCourseWithSubjectsAsync(int id)
        {
            var _course = await _context.Courses
                        .Include(x => x.Subject_Courses).ThenInclude(x => x.Subject)
                        .SingleOrDefaultAsync(x => x.Id == id);
            if (_course is null)
            {
                throw new Exception(@"Course id: {id} is not found");
            }
            return _course.AsCourseWithSubjects();
        }

        public async Task<IEnumerable<CourseWithSubjects>> GetCoursesWithSubjectsAsync()
        {
            var _courses = await _context.Courses
                        .Include(x => x.Subject_Courses).ThenInclude(x => x.Subject)
                        .Where(x => x.IsShown == true)
                        .Select(x => x.AsCourseWithSubjects())
                        .ToListAsync();
            return _courses;
        }

        public async Task<CourseWithSubjects> CreateCourseAsync(CourseCreateRequest request)
        {
            var timeNow = DateTime.Now;
            var coursePrice = _context.Subjects
                            .Where(x => request.SubjectIds.Contains(x.Id))
                            .Sum(x => x.Price);

            var _course = new Course()
            {
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Price = coursePrice,
                DiscountedPrice = coursePrice,
                IsExtra = request.IsExtra,
                IsBasic = request.IsBasic,
                CreatedAt = timeNow,
                UpdatedAt = timeNow,
                IsShown = true
            };

            await _context.Courses.AddAsync(_course);
            await _context.SaveChangesAsync();

            await AddSubjectsToCourse(_course.Id, request.SubjectIds);
            await _context.SaveChangesAsync();

            var _createdCourse = await _context.Courses
                                .Include(x => x.Subject_Courses).ThenInclude(x => x.Subject)
                                .FirstOrDefaultAsync(x => x.Id == _course.Id);
            return _createdCourse.AsCourseWithSubjects();
        }

        public async Task<int> UpdateCourseDetails(CourseUpdateRequest request)
        {
            var _course = await _context.Courses
                        .FirstOrDefaultAsync(x => x.Id == request.Id);
            _course.Name = request.Name;
            _course.Description = request.Description;
            _course.StartDate = request.StartDate;
            _course.EndDate = request.EndDate;
            _course.DiscountedPrice = request.DiscountedPrice;
            _course.IsBasic = request.IsBasic;
            _course.IsExtra = request.IsExtra;
            _course.UpdatedAt = DateTime.Now;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCourseStatus(int courseId)
        {
            var _course = await _context.Courses
                        .FirstOrDefaultAsync(x => x.Id == courseId);
            var status = _course.IsShown;
            if (status == true)
            {
                _course.IsShown = false;
            }
            else _course.IsShown = true;
            _course.UpdatedAt = DateTime.Now;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateSubjectInCourse(int courseId, List<int> request)
        {
            var _course = await _context.Courses
                        .FirstOrDefaultAsync(x => x.Id == courseId);

            _context.Subject_Courses.RemoveRange(_course.Subject_Courses);
            await AddSubjectsToCourse(courseId, request);
            var _newPrice = _context.Subjects
                            .Where(x => request.Contains(x.Id))
                            .Sum(x => x.Price);
            _course.Price = _newPrice;
            _course.DiscountedPrice = _newPrice;
            _course.UpdatedAt = DateTime.Now;
            return await _context.SaveChangesAsync();
        }

        private async Task AddSubjectsToCourse(int courseId, List<int> courseIds)
        {
            foreach (int subjectId in courseIds)
            {
                var _subject_course = new Subject_Course()
                {
                    CourseId = courseId,
                    SubjectId = subjectId,
                };
                await _context.Subject_Courses.AddAsync(_subject_course);
            }
        }
    }
}