using Microsoft.AspNetCore.Http;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.ExamRegistrations
{
    public class ExamRegistrationVM
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid UserId { get; set; }
        public string StudentFullName { get; set; }
    }

    public class ExamRegistrationCreateRequest
    {
        public int ExamId { get; set; }
        public IFormFile excelsheet { get; set; }
    }

    public class ExamRegistrationUpdateRequest
    {
        public int ExamId { get; set; }
        public IFormFile excelsheet { get; set; }
    }
}