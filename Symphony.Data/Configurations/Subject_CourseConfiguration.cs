using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class Subject_CourseConfiguration : IEntityTypeConfiguration<Subject_Course>
    {
        public void Configure(EntityTypeBuilder<Subject_Course> builder)
        {
            builder.ToTable("Subject_Course");
            builder.HasKey(x => new { x.SubjectId, x.CourseId });
            builder.HasOne(x => x.Course).WithMany(x => x.Subject_Courses).HasForeignKey(x => x.CourseId);
            builder.HasOne(x => x.Subject).WithMany(x => x.Subject_Courses).HasForeignKey(x => x.SubjectId);
        }
    }
}