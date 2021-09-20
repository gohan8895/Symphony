using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Duration).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Price).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.IsShown).IsRequired().HasDefaultValue(true);
        }
    }
}