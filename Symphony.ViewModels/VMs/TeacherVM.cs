using System;
using System.ComponentModel.DataAnnotations;

namespace Symphony.ViewModels.VMs
{
    public class TeacherVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class CreateTeacherVM
    {
        [Required(ErrorMessage = " FirstName can not blank")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName can not blank")]
        public string LastName { get; set; }
    }
    public class UpdateTeacherVM
    {   
        public int Id { get; set; }
       [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        

    }

}