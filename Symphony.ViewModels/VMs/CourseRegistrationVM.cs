using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Symphony.ViewModels.VMs
{
    public class CourseRegistrationVM
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }
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
        public bool IsDelete { get; set; }
        public AppUserVM AppUserVM { get; set; }
        public CourseVM CourseVM { get; set; }
        public double EntranceExamFee { get; set; }
        public double FinalPrice { get; set; }
    }

    public class CreateCourseRegistrationVM
    {
        [Required]
        [DisplayName("User Id")]
        public Guid UserId { get; set; }

        [Required]
        [DisplayName("Course Id ")]
        public int CourseId { get; set; }

        //[Required]
        //[DisplayName("Approved ")]
        //[DefaultValue(false)]
        //public bool IsApproved { get; set; }
        //[Required]
        //[DisplayName("Exam Require ")]
        //[DefaultValue(false)]
        //public bool ExamRequired { get; set; }
    }

    //public class UpdateCourseRegistrationVM
    //{
    //    [Required]
    //    public int Id { get; set; }

    //    [Required]
    //    [DisplayName("User Id")]
    //    public Guid UserId { get; set; }

    //    [Required]
    //    [DisplayName("Course Id ")]
    //    public int CourseId { get; set; }

    //    [Required]
    //    [DisplayName("Approved ")]
    //    [DefaultValue(false)]
    //    public bool IsApproved { get; set; }

    //    [Required]
    //    [DisplayName("Exam Require ")]
    //    [DefaultValue(false)]
    //    public bool ExamRequired { get; set; }
    //}
}