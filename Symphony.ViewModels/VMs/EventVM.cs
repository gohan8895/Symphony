using System;
using System.ComponentModel.DataAnnotations;

namespace Symphony.ViewModels.VMs
{
    public class EventVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }
    public class CreateEventVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }
    public class UpdateEventVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }
}