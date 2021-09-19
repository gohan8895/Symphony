using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class Subject_CourseConfiguration
    {
        public void Configure(EntityTypeBuilder<Subject_Course> builder)
        {
            builder.ToTable("Subject_Course");
            builder.HasKey(sc => new { sc.SubjectId, sc.CourseId });
        }
    }
}