using System;
using System.ComponentModel.DataAnnotations;

namespace Symphony.ViewModels.VMs
{
    public class Exam_ResultVM
    {
        public int Id { get; set; }

        [Display(Name = "Exam Id")]
        public int ExamId { get; set; }

        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }

        [Display(Name = "Student Id")]
        public Guid UserId { get; set; }

        [Display(Name = "Student Full Name")]
        public string StudentName { get; set; }

        [Display(Name = "Exam Taken Date")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Score")]
        public int TotalScore { get; set; }

        [Display(Name = "Result")]
        public string Result { get; set; }
    }
}