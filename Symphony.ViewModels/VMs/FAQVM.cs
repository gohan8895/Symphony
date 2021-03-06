using System;
using System.ComponentModel.DataAnnotations;

namespace Symphony.ViewModels.VMs
{
    public class FAQVM
    {
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public bool IsShown { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class CreateFAQVM
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }
    public class UpdateFAQVM
    {
        public int Id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }
}