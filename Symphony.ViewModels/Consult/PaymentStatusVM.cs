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
        //public CourseRegistrationVM CourseRegistrationVM { get; set; }
    }

    public class CreatePaymentStatusVM
    {
     
        public int CourseRegistrationId { get; set; }
        public double Amount { get; set; }
        public bool HasPaid { get; set; }
    }
      
      
    public class UpdatePaymentStatusVM
    {
        public int Id { get; set; }
        public int CourseRegistrationId { get; set; }
        public double Amount { get; set; }
        public bool HasPaid { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class PaymentStatusWithData
    {
        public int Id { get; set; }
        public int CourseRegistrationId { get; set; }
        public double Amount { get; set; }
        public bool HasPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CourseRegistrationVM CourseRegistrationVM { get; set; }
    }

}