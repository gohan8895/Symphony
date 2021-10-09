using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class Exam_ResultConfiguration : IEntityTypeConfiguration<Exam_Result>
    {
        public void Configure(EntityTypeBuilder<Exam_Result> builder)
        {
            builder.ToTable("Exam_Results");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.TotalScore).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsShown).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.HasPassed).IsRequired().HasDefaultValue(false);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Exam_Results).HasForeignKey(x => x.UserId);
        }
    }
}