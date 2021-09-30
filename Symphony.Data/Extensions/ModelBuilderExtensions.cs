using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Symphony.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "ADMIN",
                Description = "Administrator Role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "trung.nguyen@gmail.com",
                NormalizedUserName = "TRUNG.NGUYEN@GMAIL.COM",
                Email = "trung.nguyen@gmail.com",
                NormalizedEmail = "TRUNG.NGUYEN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Trung",
                LastName = "Nguyen",
                DOB = new DateTime(1995, 08, 08)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<About>().HasData(new About
            {
                Id = 1,
                Title = "Opening",
                Content = "Founded in 2000 in the heart of London, <b>Symphony Ltd.</b> is London's leading private institute, with more than 1000 staffs and 2000 students from different countries. We are a diverse community with the freedom and courage to challenge, to question and to think differently.",
                IsShown = true
            },
            new About
            {
                Id = 2,
                Title = "First Question",
                Content = "Who we are",
                IsShown = true
            },
            new About
            {
                Id = 3,
                Title = "First Answer",
                Content = "Symphony Institute is a diverse global community of world-class academics, students, industry links, external partners, and alumni. Our powerful collective of individuals and institutes work together to explore new possibilities.",
                IsShown = true
            },
            new About
            {
                Id = 4,
                Title = "Second Question",
                Content = "Symphony's vision and impact",
                IsShown = true
            },
            new About
            {
                Id = 5,
                Title = "Second Answer",
                Content = "Symphony Institute is a diverse global community of world-class academics, students, industry links, external partners, and alumni. Our powerful collective of individuals and institutes work together to explore new possibilities.",
                IsShown = true
            },
            new About
            {
                Id = 6,
                Title = "Third Question",
                Content = "What we has to offer",
                IsShown = true
            },
            new About
            {
                Id = 7,
                Title = "Third Answer",
                Content = "Symphony Institute provides many courses on subject about programming languages like C Sharp, Java, C++, Javascript, Php, Python, Ruby and more... ",
                IsShown = true
            });
        }
    }
}