using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.CourseViewModel
{
    public class CourseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public double Price { get; set; }

        [Display(Name = "Discount Price")]
        public double DiscountedPrice { get; set; }

        [DisplayName("Extra Course")]
        public bool IsExtra { get; set; }

        [DisplayName("Basic Course")]
        public bool IsBasic { get; set; }

        [DisplayName("Create Date")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Update Date")]
        public DateTime UpdatedAt { get; set; }

        public bool IsShown { get; set; }
    }

    public class CourseWithSubjects : CourseVM
    {
        public List<SimpleSubjectVM> SimpleSubjectVMs { get; set; }
    }

    public class CourseCreateRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsExtra { get; set; }

        [Required]
        public bool IsBasic { get; set; }
        public List<int> SubjectIds { get; set; }
    }

    public class CourseUpdateRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public double DiscountedPrice { get; set; }

        [Required]
        public bool IsExtra { get; set; }

        [Required]
        public bool IsBasic { get; set; }
    }
}