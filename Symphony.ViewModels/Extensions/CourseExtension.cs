using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class CourseExtension
    {
        public static CourseVM AsVM(this Course course)
        {
            return new CourseVM
            {

                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Price = course.Price,
                DiscountedPrice = course.DiscountedPrice,
                IsExtra = course.IsExtra,
                IsBasic = course.IsBasic,
                CreatedAt = course.CreatedAt,
                UpdatedAt = course.UpdatedAt,
                IsShown = course.IsShown
            };
        }

        public static CourseWithSubjects AsCourseWithSubjects(this Course course)
        {
            return new CourseWithSubjects
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Price = course.Price,
                DiscountedPrice = course.DiscountedPrice,
                IsExtra = course.IsExtra,
                IsBasic = course.IsBasic,
                CreatedAt = course.CreatedAt,
                UpdatedAt = course.UpdatedAt,
                IsShown = course.IsShown,
                SimpleSubjectVMs = course.Subject_Courses.Select(x => x.Subject.AsSimpleVM()).ToList()
            };
        }
    }
}