using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Symphony.Data.Entities;

namespace Symphony.ViewModels.VMs
{
    public class ExamVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BatchId { get; set; }
        public int SubjectId { get; set; }
        public DateTime ExamDate { get; set; }
        public bool IsEntranceExam { get; set; }
        public int CourseId { get; set; }
        public int Duration { get; set; }
        public int MaxScore { get; set; }
        public int RequiredScore { get; set; }
        public bool? IsDelete { get; set; }

        public List<QuestionVM> Questions { get; set; }
    }

    public class ExamExtendVM
    {
        public List<Student_In_Exam> Student_In_Exams { get; set; }
        public List<Exam_Result> Exam_Results { get; set; }
        public List<QuestionExam> QuestionExams { get; set; }
        public List<Student_Answer> Student_Answers { get; set; }
        public List<ExamRegistration> ExamRegistrations { get; set; }
        public BatchVM Batch { get; set; }
        public SubjectVM Subject { get; set; }
        public CourseVM Course { get; set; }
    }

    public class ExamCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int BatchId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }

        [Required]
        public bool IsEntranceExam { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public IFormFile excelsheet { get; set; }
    }

    public class ExamUpdateRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }

        [Required]
        public bool IsEntranceExam { get; set; }

        [Required]
        public int Duration { get; set; }

        public IFormFile excelsheet { get; set; }
    }
}