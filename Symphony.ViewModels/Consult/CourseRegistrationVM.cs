using Symphony.Data.Entities;
using Symphony.ViewModels.CourseViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Consult
{
    public class CourseRegistrationVM
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool ExamRequired { get; set; }
    }
    public class CreateCourseRegistrationVM
    {
        [Required]
        [DisplayName("User Id")]
        public Guid UserId { get; set; }

        [Required]
        [DisplayName("Course Id ")]
        public int CourseId { get; set; }
        [Required]
        [DisplayName("Approved ")]
        [DefaultValue(false)]
        public bool IsApproved { get; set; }
        [Required]
        [DisplayName("Exam Require ")]
        [DefaultValue(false)]
        public bool ExamRequired { get; set; }
    }

    public class UpdateCourseRegistrationVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("User Id")]
        public Guid UserId { get; set; }

        [Required]
        [DisplayName("Course Id ")]
        public int CourseId { get; set; }
        [Required]
        [DisplayName("Approved ")]
        [DefaultValue(false)]
        public bool IsApproved { get; set; }

        [Required]
        [DisplayName("Exam Require ")]
        [DefaultValue(false)]
        public bool ExamRequired { get; set; }
    }



    public class CourseRegistrationWithDataVM
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool ExamRequired { get; set; }
        public AppUserVM AppUserVM { get; set; }
        public CourseVM CourseVM { get; set; }
    }
}









