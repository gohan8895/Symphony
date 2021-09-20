﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Data.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public List<Image_Subject> Image_Subjects { get; set; }
    }
}