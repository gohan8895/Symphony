using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #nullable enable
        public string? DetailDescription { get; set; }
        #nullable disable
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public bool IsExtra { get; set; }
        public bool IsBasic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ImagePath { get; set; }
        public bool IsShown { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Subject_Course> Subject_Courses { get; set; }
        public List<Student_Course> Student_Courses { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<CourseRegistration> CourseRegistrations { get; set; }
    }
}