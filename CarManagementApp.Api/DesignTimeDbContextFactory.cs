using CarManagementApp.Infrastructure.Data;
using CarManagementApp.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarManagementApp.Api
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var dbOptions = configuration.GetSection(DbOptions.SECTION).Get<DbOptions>() ?? throw new Exception("DbOptions not found");

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(dbOptions.ConnectionString)
                .Options;

            return new ApplicationDbContext(dbContextOptions);
        }
    }
}
