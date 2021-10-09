using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public int CourseRegistrationId { get; set; }
        public double Amount { get; set; }
        public bool HasPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CourseRegistration CourseRegistration { get; set; }
        public bool IsDeleted { get; set; }
    }
}