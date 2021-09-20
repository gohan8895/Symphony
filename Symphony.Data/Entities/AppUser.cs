using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public char Gender { get; set; }
        public int? BatchId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Batch Batch { get; set; }
        public List<Student_Course> Student_Courses { get; set; }
        public List<Student_In_Exam> Student_In_Exams { get; set; }
        public List<Exam_Result> Exam_Results { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<CourseRegistration> CourseRegistrations { get; set; }
        public List<ExamRegistration> ExamRegistrations { get; set; }
        public List<ConsultRegistration> ConsultRegistrations { get; set; }
    }
}