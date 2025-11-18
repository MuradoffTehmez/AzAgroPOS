using System;
using Microsoft.EntityFrameworkCore;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

class ResetAdminPassword
{
    static void Main()
    {
        Console.WriteLine("=== Admin Parol Sıfırlama ===");
        Console.WriteLine();

        // Configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Setup DbContext
        var optionsBuilder = new DbContextOptionsBuilder<AzAgroPOSDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using (var context = new AzAgroPOSDbContext(optionsBuilder.Options))
        {
            // Find admin user
            var admin = context.Istifadeciler.FirstOrDefault(i => i.Id == 1);

            if (admin == null)
            {
                Console.WriteLine("Admin istifadəçi tapılmadı!");
                return;
            }

            Console.WriteLine($"Tapılan istifadəçi: {admin.IstifadeciAdi} ({admin.TamAd})");

            // Reset password
            string newPassword = "admin123";
            admin.ParolHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            admin.UgursuzGirisCehdi = 0;
            admin.HesabKilidlenmeTarixi = null;
            admin.SonSifreDeyismeTarixi = DateTime.Now;
            admin.HesabAktivdir = true;

            // Save changes
            context.SaveChanges();

            Console.WriteLine();
            Console.WriteLine("✓ Parol uğurla sıfırlandı!");
            Console.WriteLine($"  Yeni parol: {newPassword}");
            Console.WriteLine($"  Hash uzunluğu: {admin.ParolHash.Length}");
            Console.WriteLine($"  Hesab statusu: Açıq");
            Console.WriteLine($"  Uğursuz cəhd: 0");

            // Verify
            bool verified = BCrypt.Net.BCrypt.Verify(newPassword, admin.ParolHash);
            Console.WriteLine($"  Təsdiq: {(verified ? "SUCCESS ✓" : "FAILED ✗")}");
        }

        Console.WriteLine();
        Console.WriteLine("İndi giriş edə bilərsiniz:");
        Console.WriteLine("  İstifadəçi: admin");
        Console.WriteLine("  Parol: admin123");
    }
}
