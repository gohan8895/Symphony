using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Symphony.Data.EF
{
    public class SymphonyDBContextFactory : IDesignTimeDbContextFactory<SymphonyDBContext>
    {
        public SymphonyDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SymphonyDb");

            var optionsBuilder = new DbContextOptionsBuilder<SymphonyDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SymphonyDBContext(optionsBuilder.Options);
        }
    }
}