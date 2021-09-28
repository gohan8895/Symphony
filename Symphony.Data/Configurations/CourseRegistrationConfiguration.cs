using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class CourseRegistrationConfiguration : IEntityTypeConfiguration<CourseRegistration>
    {
        public void Configure(EntityTypeBuilder<CourseRegistration> builder)
        {
            builder.ToTable("CourseRegistrations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.IsApproved).HasDefaultValue(false);
            builder.Property(x => x.IsApproved).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.ExamRequired).HasDefaultValue(false);

            builder.HasOne(x => x.AppUser).WithMany(x => x.CourseRegistrations).HasForeignKey(x => x.UserId);
        }
    }
}