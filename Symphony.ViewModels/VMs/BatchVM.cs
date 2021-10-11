using System;
using System.ComponentModel.DataAnnotations;
using Symphony.ViewModels.CustomAttributes;

namespace Symphony.ViewModels.VMs
{
    public class BatchVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class BatchCreateRequest
    {
        [Required]
        public string Description { get; set; }

        [Required]
        [StartDate]
        public DateTime StartDate { get; set; }

        [Required]
        [EndDate("StartDate")]
        public DateTime EndDate { get; set; }
    }

    public class BatchUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StartDate]
        public DateTime StartDate { get; set; }

        [Required]
        [EndDate("StartDate")]
        public DateTime EndDate { get; set; }
    }
}