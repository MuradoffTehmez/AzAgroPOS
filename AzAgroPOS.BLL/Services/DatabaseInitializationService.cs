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
        public async Task InitializeDatabaseAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                // Database-i yarad
                await context.Database.EnsureCreatedAsync();

                // Əgər məlumatlar varsa, heç nə etmə
                if (context.Roller.Any())
                    return;

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

                // Admin istifadəçisi əlavə et
                var adminUser = new Istifadeci
                {
                    Ad = "Admin",
                    Soyad = "Sistem",
                    Email = "admin@azagropos.az",
                    ParolHash = ComputeSha256Hash("admin123"),
                    RolId = adminRole.Id,
                    TemaId = lightTheme.Id,
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                };

                context.Istifadeciler.Add(adminUser);
                await context.SaveChangesAsync();

                // Əsas icazələr əlavə et
                var permissions = new[]
                {
                    new RolIcazesi
                    {
                        RolId = adminRole.Id,
                        Modul = "İstifadəçi",
                        Emeliyyat = "Əlavə",
                        IcazeVerilib = true,
                        YaradilmaTarixi = DateTime.Now,
                        Aciklama = "Yeni istifadəçi əlavə etmək"
                    },
                    new RolIcazesi
                    {
                        RolId = adminRole.Id,
                        Modul = "İstifadəçi",
                        Emeliyyat = "Redaktə",
                        IcazeVerilib = true,
                        YaradilmaTarixi = DateTime.Now,
                        Aciklama = "İstifadəçi məlumatlarını redaktə etmək"
                    },
                    new RolIcazesi
                    {
                        RolId = adminRole.Id,
                        Modul = "İstifadəçi",
                        Emeliyyat = "Silmə",
                        IcazeVerilib = true,
                        YaradilmaTarixi = DateTime.Now,
                        Aciklama = "İstifadəçini silmək"
                    },
                    new RolIcazesi
                    {
                        RolId = userRole.Id,
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