using System.ComponentModel.DataAnnotations;

namespace Symphony.ViewModels.Consult
{
    public class AboutVM
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }

    public class CreateAboutVM
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }
    
    public class UpdateAboutVM
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsShown { get; set; }
    }
}