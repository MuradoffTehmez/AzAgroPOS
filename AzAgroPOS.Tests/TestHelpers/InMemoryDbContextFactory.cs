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

        // Seed data-nı təmizləyirik - testlər üçün lazım deyil
        context.Mehsullar.RemoveRange(context.Mehsullar);
        context.Istifadeciler.RemoveRange(context.Istifadeciler);
        context.Rollar.RemoveRange(context.Rollar);
        context.Isciler.RemoveRange(context.Isciler);
        context.Tedarukculer.RemoveRange(context.Tedarukculer);
        context.Kateqoriyalar.RemoveRange(context.Kateqoriyalar);
        context.Brendler.RemoveRange(context.Brendler);
        context.Icazeler.RemoveRange(context.Icazeler);
        context.RolIcazeleri.RemoveRange(context.RolIcazeleri);
        context.SaveChanges();

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
