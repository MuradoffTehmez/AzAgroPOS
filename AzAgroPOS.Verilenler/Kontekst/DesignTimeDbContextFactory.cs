using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
            
            string connectionString = "Server=MURADOV-TAHMAZ\\TAHMAZ_MURADOV;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);

            return new AzAgroPOSDbContext(optionsBuilder.Options);
        }
    }
}