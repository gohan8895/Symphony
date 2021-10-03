using Microsoft.AspNetCore.Http;
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
    public class SubjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public bool IsShown { get; set; }
        public List<Subject_Course> Subject_Courses { get; set; }
        public List<ImageVM> Images { get; set; }
        public List<QuestionVM> Questions { get; set; }
        public List<FileVM> Files { get; set; }
        public List<ExamVM> Exams { get; set; }
    }

    public class SimpleSubjectVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public bool IsShown { get; set; }
    }

    public class SubjectCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer number")]
        public int Duration { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer number")]
        public double Price { get; set; }
    }

    /*public class ImageUpdateRequest
    {
        [Display(Name = "Image")]
        public List<IFormFile> Images { get; set; }
    }
    
    public class FileUpdateRequest
    {
        [Display(Name = "File")]
        public List<IFormFile> Files { get; set; }
    }*/

    public class SubjectUpdateRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer number")]
        public int Duration { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer number")]
        public double Price { get; set; }
    }
}