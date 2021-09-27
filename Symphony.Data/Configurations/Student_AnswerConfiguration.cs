using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class Student_AnswerConfiguration : IEntityTypeConfiguration<Student_Answer>
    {
        public void Configure(EntityTypeBuilder<Student_Answer> builder)
        {
            builder.ToTable("Student_Answer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Answer_value).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.HasOne(x => x.Question).WithMany(x => x.Student_Answers).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Student_Answers).HasForeignKey(x => x.UserId);
        }
    }
}