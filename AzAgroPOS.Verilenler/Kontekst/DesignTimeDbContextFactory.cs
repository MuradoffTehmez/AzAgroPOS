using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// Entity Framework design-time factory so that tooling can create the DbContext consistently.
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AzAgroPOSDbContext>
{
    public AzAgroPOSDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = ConnectionStringResolver.BuildConfiguration(Directory.GetCurrentDirectory());

        string connectionString = ConnectionStringResolver.Resolve(configuration);

        var optionsBuilder = new DbContextOptionsBuilder<AzAgroPOSDbContext>()
            .UseSqlServer(connectionString);

        return new AzAgroPOSDbContext(optionsBuilder.Options);
    }
}
