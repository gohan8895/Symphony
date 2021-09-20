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
        public int CoursRegistrationId { get; set; }
        public double Amount { get; set; }
        public bool HasPaid { get; set; }
        public DateTime CreaatAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CourseRegistration CoursRegistration { get; set; }
    }
}