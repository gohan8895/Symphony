using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Consult
{
    public class FileVM
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int SubjectId { get; set; }
        public SubjectVM Subject { get; set; }
    }
}