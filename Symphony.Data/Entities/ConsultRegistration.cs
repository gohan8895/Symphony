using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class ConsultRegistration
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Message { get; set; }
        public bool IsContacted { get; set; }
        public AppUser AppUser { get; set; }
    }
}