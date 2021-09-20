using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Exam_Result
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalScore { get; set; }
        public bool IsShown { get; set; }
        public bool HasPassed { get; set; }
        public Exam Exam { get; set; }
        public AppUser AppUser { get; set; }
    }
}