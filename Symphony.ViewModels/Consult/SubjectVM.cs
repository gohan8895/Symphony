using Microsoft.AspNetCore.Http;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
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

    public class SubjectCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public List<IFormFile> images { get; set; }
        public List<IFormFile> attachments { get; set; }
    }

    public class SubjectUpdateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public bool IsShown { get; set; }
    }
}