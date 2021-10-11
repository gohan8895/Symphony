using System;

namespace Symphony.ViewModels.VMs
{
    public class ConsultVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Message { get; set; }
        public string IsContacted { get; set; }
    }

    public class ConsultCreateRequest
    {
        public Guid? UserId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}