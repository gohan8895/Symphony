﻿using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.ViewModels.Extensions
{
    public static class TeacherExtension
    {
        public static TeacherVM AsVM(this Teacher teacher) => new TeacherVM
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName
        };
    }
}
