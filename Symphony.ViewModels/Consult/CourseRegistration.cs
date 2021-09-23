using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Consult
{
    public class CourseRegistration
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool ExamRequired { get; set; }
        public AppUser AppUser { get; set; }
        public CourseVM Course { get; set; }
    }
}