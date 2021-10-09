using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class Student_CourseConfiguration : IEntityTypeConfiguration<Student_Course>
    {
        public void Configure(EntityTypeBuilder<Student_Course> builder)
        {
            builder.ToTable("Student_Course");
            builder.HasKey(x => new { x.UserId, x.CourseId });
            builder.HasOne(x => x.AppUser).WithMany(x => x.Student_Courses).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Course).WithMany(x => x.Student_Courses).HasForeignKey(x => x.CourseId);
        }
    }
}