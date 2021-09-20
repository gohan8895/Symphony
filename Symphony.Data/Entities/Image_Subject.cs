using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Image_Subject
    {
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}