using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

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
                DetailDescription = course.DetailDescription,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Price = course.Price,
                DiscountedPrice = course.DiscountedPrice,
                IsExtra = course.IsExtra,
                IsBasic = course.IsBasic,
                ImagePath = course.ImagePath,
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
                DetailDescription = course.DetailDescription,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Price = course.Price,
                DiscountedPrice = course.DiscountedPrice,
                IsExtra = course.IsExtra,
                IsBasic = course.IsBasic,
                CreatedAt = course.CreatedAt,
                UpdatedAt = course.UpdatedAt,
                ImagePath = course.ImagePath,
                IsShown = course.IsShown,
                SimpleSubjectVMs = course.Subject_Courses.Select(x => x.Subject.AsSimpleVM()).ToList()
            };
        }
    }
}