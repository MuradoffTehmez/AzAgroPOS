using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration configuration = ConnectionStringResolver.BuildConfiguration(Directory.GetCurrentDirectory());

        string connectionString = ConnectionStringResolver.Resolve(configuration);
        Console.WriteLine($"Connection String: {connectionString}");

        if (!await CanOpenConnectionAsync(connectionString))
        {
            Console.WriteLine("Database connection failed. Update appsettings.json or set AZAGROPOS__CONNECTIONSTRING.");
            return;
        }

        var optionsBuilder = new DbContextOptionsBuilder<AzAgroPOSDbContext>()
            .UseSqlServer(connectionString);

        await using var context = new AzAgroPOSDbContext(optionsBuilder.Options);

        try
        {
            var migrations = await context.Database.GetPendingMigrationsAsync();
            Console.WriteLine($"Found {migrations.Count()} pending migrations:");

            foreach (var migration in migrations)
            {
                Console.WriteLine($"  - {migration}");
            }

            if (migrations.Any())
            {
                Console.WriteLine("Applying migrations...");
                await context.Database.MigrateAsync();
                Console.WriteLine("All pending migrations applied successfully.");
            }
            else
            {
                Console.WriteLine("No pending migrations found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while applying migrations: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }

    private static async Task<bool> CanOpenConnectionAsync(string connectionString)
    {
        await using var connection = new SqlConnection(connectionString);
        try
        {
            await connection.OpenAsync();
            return true;
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Connection error: {ex.Message}");
            return false;
        }
    }
}
