using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class Student_In_ExamConfiguration : IEntityTypeConfiguration<Student_In_Exam>
    {
        public void Configure(EntityTypeBuilder<Student_In_Exam> builder)
        {
            builder.ToTable("Student_In_Exam");
            builder.HasKey(x => new { x.UserId, x.ExamId });
            builder.HasOne(x => x.AppUser).WithMany(x => x.Student_In_Exams).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Exam).WithMany(x => x.Student_In_Exams).HasForeignKey(x => x.ExamId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}