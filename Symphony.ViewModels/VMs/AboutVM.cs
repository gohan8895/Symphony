using System.ComponentModel.DataAnnotations;

namespace Symphony.ViewModels.VMs
{
    public class AboutVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }

    public class CreateAboutVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }

    public class UpdateAboutVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }
}