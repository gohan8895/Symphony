using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Question_Text).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Opt1_key).IsRequired().HasDefaultValue(1);
            builder.Property(x => x.Opt1_value).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Opt2_key).IsRequired().HasDefaultValue(2);
            builder.Property(x => x.Opt2_value).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Opt3_key).IsRequired().HasDefaultValue(3);
            builder.Property(x => x.Opt3_value).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Opt4_key).IsRequired().HasDefaultValue(4);
            builder.Property(x => x.Opt4_value).HasMaxLength(512).IsRequired();
            builder.Property(x => x.Valid_Opt_key).IsRequired();
            builder.Property(x => x.Score).IsRequired().HasDefaultValue(20);
        }
    }
}