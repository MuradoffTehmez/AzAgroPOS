// Fayl: AzAgroPOS.Tests/TestHelpers/InMemoryDbContextFactory.cs

using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.Tests.TestHelpers;

/// <summary>
/// Test üçün InMemory database context yaradır
/// </summary>
public static class InMemoryDbContextFactory
{
    /// <summary>
    /// Unique database adı ilə InMemory DbContext yaradır
    /// </summary>
    public static AzAgroPOSDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AzAgroPOSDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new AzAgroPOSDbContext(options);

        // Database-i initialize et
        context.Database.EnsureCreated();

        return context;
    }

    /// <summary>
    /// Mövcud context-i sil və təmizlə
    /// </summary>
    public static void Destroy(AzAgroPOSDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
