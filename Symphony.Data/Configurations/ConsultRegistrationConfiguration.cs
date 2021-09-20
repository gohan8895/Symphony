using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class ConsultRegistrationConfiguration : IEntityTypeConfiguration<ConsultRegistration>

    {
        public void Configure(EntityTypeBuilder<ConsultRegistration> builder)
        {
            builder.ToTable("ConsultRegistrations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.FullName).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(512).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.Message).HasMaxLength(512).IsRequired();
            builder.Property(x => x.IsContacted).HasDefaultValue(false);
            builder.HasOne(x => x.AppUser).WithMany(x => x.ConsultRegistrations).HasForeignKey(x => x.UserId);
        }
    }
}