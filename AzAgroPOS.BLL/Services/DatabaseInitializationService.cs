using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class DatabaseInitializationService
    {
        public async Task ClearAndInitializeDatabaseAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                // Database-i sil və yenidən yarat
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();
            }
            
            // Sonra məlumatları əlavə et
            await InitializeDatabaseAsync();
        }

        public async Task InitializeDatabaseAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                // Database-i yarad
                await context.Database.EnsureCreatedAsync();

                // Əgər admin istifadəçisi varsa, heç nə etmə
                var existingAdmin = await context.Istifadeciler.FirstOrDefaultAsync(u => u.Email == "admin@azagropos.az");
                if (existingAdmin != null)
                {
                    // Admin artıq mövcuddur
                    return;
                }

                // Roller əlavə et
                var adminRole = new Rol
                {
                    Ad = "Administrator",
                    Aciklama = "Sistem administratoru - bütün hüquqlar",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                };

                var userRole = new Rol
                {
                    Ad = "İstifadəçi",
                    Aciklama = "Adi istifadəçi - məhdud hüquqlar",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                };

                context.Roller.AddRange(adminRole, userRole);
                await context.SaveChangesAsync();

                // Temalar əlavə et
                var lightTheme = new Tema
                {
                    Ad = "Açıq Tema",
                    ArxaplanRengi = "#FFFFFF",
                    MetinRengi = "#000000",
                    Icon = "light-theme.png",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                };

                var darkTheme = new Tema
                {
                    Ad = "Qaranlıq Tema",
                    ArxaplanRengi = "#2C2C2C",
                    MetinRengi = "#FFFFFF",
                    Icon = "dark-theme.png",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                };

                context.Temalar.AddRange(lightTheme, darkTheme);
                await context.SaveChangesAsync();

                // Reload-dan sonra ID-ləri əldə edək
                var savedAdminRole = await context.Roller.FirstAsync(r => r.Ad == "Administrator");
                var savedLightTheme = await context.Temalar.FirstAsync(t => t.Ad == "Açıq Tema");

                // Admin istifadəçisi əlavə et
                var adminUser = new Istifadeci
                {
                    Ad = "Admin",
                    Soyad = "Sistem",
                    Email = "admin@azagropos.az",
                    ParolHash = ComputeSha256Hash("admin123"),
                    RolId = savedAdminRole.Id,
                    TemaId = savedLightTheme.Id,
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                };

                context.Istifadeciler.Add(adminUser);
                await context.SaveChangesAsync();

                // Rol ID-lərini yenidən əldə edək
                var savedUserRole = await context.Roller.FirstAsync(r => r.Ad == "İstifadəçi");

                // Əsas icazələr əlavə et
                var permissions = new[]
                {
                    new RolIcazesi
                    {
                        RolId = savedAdminRole.Id,
                        Modul = "İstifadəçi",
                        Emeliyyat = "Əlavə",
                        IcazeVerilib = true,
                        YaradilmaTarixi = DateTime.Now,
                        Aciklama = "Yeni istifadəçi əlavə etmək"
                    },
                    new RolIcazesi
                    {
                        RolId = savedAdminRole.Id,
                        Modul = "İstifadəçi",
                        Emeliyyat = "Redaktə",
                        IcazeVerilib = true,
                        YaradilmaTarixi = DateTime.Now,
                        Aciklama = "İstifadəçi məlumatlarını redaktə etmək"
                    },
                    new RolIcazesi
                    {
                        RolId = savedAdminRole.Id,
                        Modul = "İstifadəçi",
                        Emeliyyat = "Silmə",
                        IcazeVerilib = true,
                        YaradilmaTarixi = DateTime.Now,
                        Aciklama = "İstifadəçini silmək"
                    },
                    new RolIcazesi
                    {
                        RolId = savedUserRole.Id,
                        Modul = "İstifadəçi",
                        Emeliyyat = "Əlavə",
                        IcazeVerilib = false,
                        YaradilmaTarixi = DateTime.Now,
                        Aciklama = "Adi istifadəçi yeni istifadəçi əlavə edə bilməz"
                    }
                };

                context.RolIcazeleri.AddRange(permissions);
                await context.SaveChangesAsync();
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}