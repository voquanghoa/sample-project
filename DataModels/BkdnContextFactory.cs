using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataModels
{
    public class BkdnContextFactory: IDesignTimeDbContextFactory<BkdnContext>
    {
        public BkdnContext CreateDbContext(string[] args)
        {
            Console.WriteLine($"Load config from appsettings.json");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            var optionsBuilder = new DbContextOptionsBuilder<BkdnContext>();

            var sqlConnection = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Connection string = {sqlConnection}");
            optionsBuilder.UseSqlServer(sqlConnection);

            return new BkdnContext(optionsBuilder.Options);
        }
    }
}