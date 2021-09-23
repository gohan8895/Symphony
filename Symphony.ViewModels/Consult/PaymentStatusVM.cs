using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Consult
{
    public class PaymentStatusVM
    {
        public int Id { get; set; }
        public int CourseRegistrationId { get; set; }
        public double Amount { get; set; }
        public bool HasPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CourseRegistration CourseRegistration { get; set; }
    }
}