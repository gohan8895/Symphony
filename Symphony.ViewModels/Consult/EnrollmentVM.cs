using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Consult
{
    public class EnrollmentVM
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public bool? IsDelete { get; set; }
    }
    public class EnrollmentWithData
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public bool? IsDelete { get; set; }
        public AppUserVM AppUserVM { get; set; }
        public CourseVM CourseVM { get; set; }
    }
    public class CreateEnrollmentVM
    {
        [Required]
        [DisplayName("User Id")]
        public Guid UserId { get; set; }
        [Required]
        [DisplayName("Course Id")]
        public int CourseId { get; set; }
        [Required]
        [DisplayName("Delete")]
        [DefaultValue(false)]
        public bool? IsDelete { get; set; }
    }
    public class UpdateEnrollmentVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("User Id")]
        public Guid UserId { get; set; }
        [Required]
        [DisplayName("Course Id")]
        public int CourseId { get; set; }
        [Required]
        [DisplayName("Delete")]
        [DefaultValue(false)]
        public bool? IsDelete { get; set; }
    }

}