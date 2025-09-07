using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main(string[] args)
    {
        // Build configuration
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        // Get connection string
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Console.WriteLine($"Connection String: {connectionString}");

        // Create DbContext options
        var optionsBuilder = new DbContextOptionsBuilder<AzAgroPOSDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        // Create DbContext
        using var context = new AzAgroPOSDbContext(optionsBuilder.Options);

        try
        {
            // Get all migrations
            var migrations = context.Database.GetPendingMigrations();
            Console.WriteLine($"Found {migrations.Count()} pending migrations:");

            foreach (var migration in migrations)
            {
                Console.WriteLine($"  - {migration}");
            }

            // Apply migrations one by one
            Console.WriteLine("Applying migrations one by one...");
            foreach (var migration in migrations)
            {
                try
                {
                    Console.WriteLine($"Applying migration: {migration}");
                    context.Database.Migrate(migration);
                    Console.WriteLine($"Migration {migration} applied successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error applying migration {migration}: {ex.Message}");
                    Console.WriteLine($"Stack trace: {ex.StackTrace}");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting pending migrations: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
        }
    }
}