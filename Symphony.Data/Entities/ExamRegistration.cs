using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class ExamRegistration
    {
        public int Id { get; set; }
        [ForeignKey("AppUser")]
        public Guid UserId { get; set; }
        public int ExamId { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid AppUser { get; set; }
        public Exam Exam { get; set; }
    }
}