using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class QuestionExamConfiguration : IEntityTypeConfiguration<QuestionExam>
    {
        public void Configure(EntityTypeBuilder<QuestionExam> builder)
        {
            builder.ToTable("QuestionExam");
            builder.HasKey(x => new { x.QuestionId, x.ExamId });
            builder.HasOne(x => x.Question).WithMany(x => x.QuestionExams).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Exam).WithMany(x => x.QuestionExams).HasForeignKey(x => x.ExamId);
        }
    }
}