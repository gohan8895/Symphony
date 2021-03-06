using System;

namespace Symphony.ViewModels.VMs
{
    public class PaymentStatusVM
    {
        public int Id { get; set; }
        public int CourseRegistrationId { get; set; }
        public double Amount { get; set; }
        public bool HasPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    //public class CreatePaymentStatusVM
    //{
    //    [Required]
    //    [DisplayName("Course Register Id ")]
    //    public int CourseRegistrationId { get; set; }

    //[Required]
    //[DisplayName("Amount")]
    //public double Amount { get; set; }

    //[DefaultValue(false)]
    //[DisplayName("Has Paid")]
    //public bool HasPaid { get; set; }
    //}

    //public class UpdatePaymentStatusVM
    //{
    //    public int Id { get; set; }

    //    [Required]
    //    [DisplayName("Course Register Id ")]
    //    public int CourseRegistrationId { get; set; }

    //    [Required]
    //    [DisplayName("Amount")]
    //    public double Amount { get; set; }

    //    [DefaultValue(false)]
    //    [DisplayName("Has Paid")]
    //    public bool HasPaid { get; set; }

    //    public DateTime UpdatedAt { get; set; }
    //}

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