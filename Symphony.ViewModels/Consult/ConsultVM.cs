using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Consult
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

    public class ConsultUpdateRequest
    {
        public bool IsContacted { get; set; }
    }
}