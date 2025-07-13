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

                // Product module seed data
                await CreateProductSeedDataAsync(context);
            }
        }

        private async Task CreateProductSeedDataAsync(AzAgroDbContext context)
        {
            // Vahidlər əlavə et
            var units = new[]
            {
                new Vahid { Ad = "Ədəd", QisaAd = "ədəd", Tesvir = "Say üçün vahid", Tipi = "Saya", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Kiloqram", QisaAd = "kq", Tesvir = "Çəki üçün vahid", Tipi = "Çəki", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Qram", QisaAd = "q", Tesvir = "Çəki üçün kiçik vahid", Tipi = "Çəki", CevirmeEmsali = 0.001m, Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Litr", QisaAd = "L", Tesvir = "Həcm üçün vahid", Tipi = "Həcm", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Millilitr", QisaAd = "mL", Tesvir = "Həcm üçün kiçik vahid", Tipi = "Həcm", CevirmeEmsali = 0.001m, Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Metr", QisaAd = "m", Tesvir = "Uzunluq üçün vahid", Tipi = "Uzunluq", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Santimetr", QisaAd = "sm", Tesvir = "Uzunluq üçün kiçik vahid", Tipi = "Uzunluq", CevirmeEmsali = 0.01m, Status = "Aktiv", YaradilmaTarixi = DateTime.Now }
            };

            context.Vahidler.AddRange(units);
            await context.SaveChangesAsync();

            // Ana vahid əlaqələrini qur
            var kg = await context.Vahidler.FirstAsync(u => u.QisaAd == "kq");
            var gram = await context.Vahidler.FirstAsync(u => u.QisaAd == "q");
            gram.AnaVahidId = kg.Id;

            var liter = await context.Vahidler.FirstAsync(u => u.QisaAd == "L");
            var ml = await context.Vahidler.FirstAsync(u => u.QisaAd == "mL");
            ml.AnaVahidId = liter.Id;

            var meter = await context.Vahidler.FirstAsync(u => u.QisaAd == "m");
            var cm = await context.Vahidler.FirstAsync(u => u.QisaAd == "sm");
            cm.AnaVahidId = meter.Id;

            await context.SaveChangesAsync();

            // Kateqoriyalar əlavə et
            var categories = new[]
            {
                new MehsulKateqoriyasi { Ad = "Ərzaq", Kod = "ERZ", Tesvir = "Qida məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "İçki", Kod = "ICK", Tesvir = "İçkilər və məşrubatlar", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Meyve-Tərəvəz", Kod = "MTV", Tesvir = "Təzə meyve və tərəvəzlər", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Süd Məhsulları", Kod = "SUD", Tesvir = "Süd və süd məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Ərzaq Dəyirmanı", Kod = "DYR", Tesvir = "Un, düyü və taxıl məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now }
            };

            context.MehsulKateqoriyalari.AddRange(categories);
            await context.SaveChangesAsync();

            // Alt kateqoriyalar əlavə et
            var erzaqCategory = await context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "ERZ");
            var subCategories = new[]
            {
                new MehsulKateqoriyasi { Ad = "Konservlər", Kod = "ERZ001", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Konserv məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Makaron", Kod = "ERZ002", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Makaron məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Şirniyyat", Kod = "ERZ003", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Şokolad və şirniyyatlar", Status = "Aktiv", YaradilmaTarixi = DateTime.Now }
            };

            context.MehsulKateqoriyalari.AddRange(subCategories);
            await context.SaveChangesAsync();

            // Nümunə məhsullar əlavə et
            var konservCategory = await context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "ERZ001");
            var edadUnit = await context.Vahidler.FirstAsync(u => u.QisaAd == "ədəd");
            var kgUnit = await context.Vahidler.FirstAsync(u => u.QisaAd == "kq");
            var literUnit = await context.Vahidler.FirstAsync(u => u.QisaAd == "L");

            var products = new[]
            {
                new Mehsul
                {
                    Ad = "Pomidor Konservi",
                    Tesvir = "400q pomidor konservi",
                    Barkod = "2991234567890",
                    SKU = "ERZ001-POM-0001",
                    KateqoriyaId = konservCategory.Id,
                    VahidId = edadUnit.Id,
                    AlisQiymeti = 1.50m,
                    SatisQiymeti = 2.20m,
                    MovcudMiqdar = 50,
                    MinimumMiqdar = 10,
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                },
                new Mehsul
                {
                    Ad = "Buğda Unu",
                    Tesvir = "1kq buğda unu",
                    Barkod = "2991234567891",
                    SKU = "DYR-BUG-0001",
                    KateqoriyaId = (await context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "DYR")).Id,
                    VahidId = kgUnit.Id,
                    AlisQiymeti = 2.00m,
                    SatisQiymeti = 2.80m,
                    MovcudMiqdar = 25,
                    MinimumMiqdar = 5,
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                },
                new Mehsul
                {
                    Ad = "Alma",
                    Tesvir = "Təzə qırmızı alma",
                    Barkod = "2991234567892",
                    SKU = "MTV-ALM-0001",
                    KateqoriyaId = (await context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "MTV")).Id,
                    VahidId = kgUnit.Id,
                    AlisQiymeti = 3.00m,
                    SatisQiymeti = 4.50m,
                    MovcudMiqdar = 15,
                    MinimumMiqdar = 5,
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                },
                new Mehsul
                {
                    Ad = "Süd",
                    Tesvir = "Təzə inek südü",
                    Barkod = "2991234567893",
                    SKU = "SUD-SUD-0001",
                    KateqoriyaId = (await context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "SUD")).Id,
                    VahidId = literUnit.Id,
                    AlisQiymeti = 2.50m,
                    SatisQiymeti = 3.20m,
                    MovcudMiqdar = 8,
                    MinimumMiqdar = 10,
                    Qeydler = "Az stokludur",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                }
            };

            context.Mehsullar.AddRange(products);
            await context.SaveChangesAsync();
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