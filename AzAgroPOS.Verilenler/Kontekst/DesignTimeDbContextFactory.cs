using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AzAgroPOS.Verilenler.Kontekst
{
    /// <summary>
    /// Bu sinif, 'Add-Migration' və 'Update-Database' kimi Entity Framework dizayn zamanı (design-time)
    /// alətlərinin AzAgroPOSDbContext-i necə yaradacağını təyin edir.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AzAgroPOSDbContext>
    {
        public AzAgroPOSDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AzAgroPOSDbContext>();

            // Build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            // Get connection string from configuration
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new AzAgroPOSDbContext(optionsBuilder.Options);
        }
    }
}