using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Symphony.ViewModels.CustomAttributes;

namespace Symphony.ViewModels.VMs
{
    public class CourseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
#nullable enable
        [Display(Name = "Description")]
        public string? DetailDescription { get; set; }
#nullable disable

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public double Price { get; set; }

        [Display(Name = "Discount Price")]
        public double DiscountedPrice { get; set; }

        [Display(Name = "Extra Course")]
        public bool IsExtra { get; set; }

        [Display(Name = "Basic Course")]
        public bool IsBasic { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Update Date")]
        public DateTime UpdatedAt { get; set; }

        [Display(Name = "Status")]
        public bool IsShown { get; set; }
    }

    public class CourseWithSubjects : CourseVM
    {
        public List<SimpleSubjectVM> SimpleSubjectVMs { get; set; }
    }

    public class CourseCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        public string Description { get; set; }

        #nullable enable
        [Display(Name = "Full Description")]
        public string? DetailDescription { get; set; }
        #nullable disable

        [Required]
        [DataType(DataType.Date)]
        [StartDate]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [EndDate("StartDate")]
        [Display(Name = "Start Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Extra Lab")]
        public bool IsExtra { get; set; }

        [Required]
        [DisplayName("Basic Course")]
        public bool IsBasic { get; set; }

        [Display(Name = "Subject")]
        public List<int> SubjectIds { get; set; }
    }

    public class CourseUpdateRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        public string Description { get; set; }

        #nullable enable
        [Display(Name = "Full Description")]
        public string? DetailDescription { get; set; }
        #nullable disable

        [Display(Name = "Discount Price")]
        public double DiscountedPrice { get; set; }

        [Required]
        [StartDate]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [EndDate("StartDate")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Extra Lab")]
        public bool IsExtra { get; set; }

        [Required]
        [Display(Name = "Course Level")]
        public bool IsBasic { get; set; }
    }
}