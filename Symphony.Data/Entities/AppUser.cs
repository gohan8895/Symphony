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
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string Address { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
        [PersonalData]
        public char Gender { get; set; }
        [PersonalData]
        public int BatchId { get; set; }
        [PersonalData]
        public DateTime CreatedAt { get; set; }
        [PersonalData]
        public DateTime UpdatedAt { get; set; }
        [PersonalData]
        public Batch Batch { get; set; }
        public List<Student_Course> Student_Courses { get; set; }
        public List<Student_In_Exam> Student_In_Exams { get; set; }
        public List<Exam_Result> Exam_Results { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<CourseRegistration> CourseRegistrations { get; set; }
        public List<ExamRegistration> ExamRegistrations { get; set; }
    }
}