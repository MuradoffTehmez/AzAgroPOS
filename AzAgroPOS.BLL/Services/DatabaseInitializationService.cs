using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.Extensions.Logging;

namespace AzAgroPOS.BLL.Services
{
    public interface IDatabaseInitializationService
    {
        Task ClearAndInitializeDatabaseAsync();
        Task InitializeDatabaseAsync();
    }

    public class DatabaseInitializationService : IDatabaseInitializationService
    {
        private readonly ILogger<DatabaseInitializationService> _logger;
        private readonly AzAgroDbContext _context;

        public DatabaseInitializationService(
            AzAgroDbContext context,
            ILogger<DatabaseInitializationService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task ClearAndInitializeDatabaseAsync()
        {
            try
            {
                _logger.LogInformation("Starting database reset and initialization...");

                // Delete and recreate database
                await _context.Database.EnsureDeletedAsync();
                await _context.Database.EnsureCreatedAsync();

                _logger.LogInformation("Database successfully reset");

                // Initialize with seed data
                await InitializeDatabaseAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error resetting and initializing database");
                throw;
            }
        }

        public async Task InitializeDatabaseAsync()
        {
            try
            {
                _logger.LogInformation("Starting database initialization...");

                // Ensure database is created
                await _context.Database.EnsureCreatedAsync();

                // Check if admin exists
                if (await _context.Istifadeciler.AnyAsync(u => u.Email == "admin@azagropos.az"))
                {
                    _logger.LogInformation("Admin user already exists - skipping initialization");
                    return;
                }

                // Seed roles
                await SeedRolesAsync();

                // Seed themes
                await SeedThemesAsync();

                // Seed admin user
                await SeedAdminUserAsync();

                // Seed permissions
                await SeedPermissionsAsync();

                // Seed product data
                await SeedProductDataAsync();

                _logger.LogInformation("Database initialization completed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initializing database");
                throw;
            }
        }

        #region Seed Methods

        private async Task SeedRolesAsync()
        {
            var roles = new[]
            {
                new Rol
                {
                    Ad = "Administrator",
                    Aciklama = "Sistem administratoru - bütün hüquqlar",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                },
                new Rol
                {
                    Ad = "İstifadəçi",
                    Aciklama = "Adi istifadəçi - məhdud hüquqlar",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                }
            };

            await _context.Roller.AddRangeAsync(roles);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Seeded roles successfully");
        }

        private async Task SeedThemesAsync()
        {
            var themes = new[]
            {
                new Tema
                {
                    Ad = "Açıq Tema",
                    ArxaplanRengi = "#FFFFFF",
                    MetinRengi = "#000000",
                    Icon = "light-theme.png",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                },
                new Tema
                {
                    Ad = "Qaranlıq Tema",
                    ArxaplanRengi = "#2C2C2C",
                    MetinRengi = "#FFFFFF",
                    Icon = "dark-theme.png",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                }
            };

            await _context.Temalar.AddRangeAsync(themes);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Seeded themes successfully");
        }

        private async Task SeedAdminUserAsync()
        {
            var adminRole = await _context.Roller.FirstAsync(r => r.Ad == "Administrator");
            var lightTheme = await _context.Temalar.FirstAsync(t => t.Ad == "Açıq Tema");

            var adminUser = new Istifadeci
            {
                Ad = "Admin",
                Soyad = "Sistem",
                Email = "admin@azagropos.az",
                ParolHash = BCrypt.Net.BCrypt.HashPassword("Admin123!", BCrypt.Net.BCrypt.GenerateSalt(12)),
                RolId = adminRole.Id,
                TemaId = lightTheme.Id,
                Status = "Aktiv",
                YaradilmaTarixi = DateTime.Now
            };

            await _context.Istifadeciler.AddAsync(adminUser);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Seeded admin user successfully");
        }

        private async Task SeedPermissionsAsync()
        {
            var adminRole = await _context.Roller.FirstAsync(r => r.Ad == "Administrator");
            var userRole = await _context.Roller.FirstAsync(r => r.Ad == "İstifadəçi");

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

            await _context.RolIcazeleri.AddRangeAsync(permissions);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Seeded permissions successfully");
        }

        private async Task SeedProductDataAsync()
        {
            await SeedUnitsAsync();
            await SeedCategoriesAsync();
            await SeedProductsAsync();
        }

        private async Task SeedUnitsAsync()
        {
            var units = new[]
            {
                new Vahid { Ad = "Ədəd", QisaAd = "ədəd", Tesvir = "Say üçün vahid", Tipi = "Saya", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Kiloqram", QisaAd = "kq", Tesvir = "Çəki üçün vahid", Tipi = "Çəki", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Qram", QisaAd = "q", Tesvir = "Çəki üçün kiçik vahid", Tipi = "Çəki", CevirmeEmsali = 0.001m, Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Litr", QisaAd = "L", Tesvir = "Həcm üçün vahid", Tipi = "Həcm", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Millilitr", QisaAd = "mL", Tesvir = "Həcm üçün kiçik vahid", Tipi = "Həcm", CevirmeEmsali = 0.001m, Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Metr", QisaAd = "m", Tesvir = "Uzunluq üçün vahid", Tipi = "Uzunluq", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Santimetr", QisaAd = "sm", Tesvir = "Uzunluq üçün kiçik vahid", Tipi = "Uzunluq", CevirmeEmsali = 0.01m, Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Desilitr", QisaAd = "dL", Tesvir = "Həcm üçün vahid", Tipi = "Həcm", CevirmeEmsali = 0.1m, Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Desimetr", QisaAd = "dm", Tesvir = "Uzunluq üçün vahid", Tipi = "Uzunluq", CevirmeEmsali = 0.1m, Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new Vahid { Ad = "Mililitr", QisaAd = "mL", Tesvir = "Həcm üçün kiçik vahid", Tipi = "Həcm", CevirmeEmsali = 0.001m, Status = "Aktiv", YaradilmaTarixi = DateTime.Now }
            };

            await _context.Vahidler.AddRangeAsync(units);
            await _context.SaveChangesAsync();

            // Set parent-child relationships
            var kg = await _context.Vahidler.FirstAsync(u => u.QisaAd == "kq");
            var gram = await _context.Vahidler.FirstAsync(u => u.QisaAd == "q");
            gram.AnaVahidId = kg.Id;

            var liter = await _context.Vahidler.FirstAsync(u => u.QisaAd == "L");
            var ml = await _context.Vahidler.FirstAsync(u => u.QisaAd == "mL");
            ml.AnaVahidId = liter.Id;

            var meter = await _context.Vahidler.FirstAsync(u => u.QisaAd == "m");
            var cm = await _context.Vahidler.FirstAsync(u => u.QisaAd == "sm");
            cm.AnaVahidId = meter.Id;

            await _context.SaveChangesAsync();
            _logger.LogInformation("Seeded units successfully");
        }

        private async Task SeedCategoriesAsync()
        {
            var categories = new[]
            {
                new MehsulKateqoriyasi { Ad = "Ərzaq", Kod = "ERZ", Tesvir = "Qida məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "İçki", Kod = "ICK", Tesvir = "İçkilər və məşrubatlar", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Meyve-Tərəvəz", Kod = "MTV", Tesvir = "Təzə meyve və tərəvəzlər", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Süd Məhsulları", Kod = "SUD", Tesvir = "Süd və süd məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Ərzaq Dəyirmanı", Kod = "DYR", Tesvir = "Un, düyü və taxıl məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Deterjanlar", Kod = "DTR", Tesvir = "Ev və şəxsi təmizlik məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Elektronika", Kod = "ELK", Tesvir = "Elektron cihazlar və aksesuarlar", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Geyim", Kod = "GEY", Tesvir = "Kişi və qadın geyimləri", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Ev Əşyaları", Kod = "EVA", Tesvir = "Ev əşyaları və dekorasiyalar", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Kitablar", Kod = "KIT", Tesvir = "Kitab və nəşriyyat məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Oyun və Əyləncə", Kod = "OYN", Tesvir = "Oyun və əyləncə məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Uşaq Məhsulları", Kod = "USK", Tesvir = "Uşaq məhsulları və oyuncaq", Status = "Aktiv", YaradilmaTarixi = DateTime.Now }
               
            };

            await _context.MehsulKateqoriyalari.AddRangeAsync(categories);
            await _context.SaveChangesAsync();

            // Seed subcategories
            var erzaqCategory = await _context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "ERZ");
            var subCategories = new[]
            {
                new MehsulKateqoriyasi { Ad = "Konservlər", Kod = "ERZ001", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Konserv məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Makaron", Kod = "ERZ002", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Makaron məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Şirniyyat", Kod = "ERZ003", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Şokolad və şirniyyatlar", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Düyü və Taxıl", Kod = "ERZ004", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Düyü və taxıl məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Qənnadı", Kod = "ERZ005", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Qənnad məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Qəhvə və Çay", Kod = "ERZ006", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Qəhvə və çay məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Dondurulmuş Qida", Kod = "ERZ007", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Dondurulmuş qida məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Quru Meyvə", Kod = "ERZ008", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Quru meyvə və qoz-fındıq məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Duz və Ədviyyat", Kod = "ERZ009", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Duz və ədviyyat məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now },
                new MehsulKateqoriyasi { Ad = "Süd Məhsulları", Kod = "ERZ010", UstKateqoriyaId = erzaqCategory.Id, Tesvir = "Süd və süd məhsulları", Status = "Aktiv", YaradilmaTarixi = DateTime.Now }


            };

            await _context.MehsulKateqoriyalari.AddRangeAsync(subCategories);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Seeded categories successfully");
        }

        private async Task SeedProductsAsync()
        {
            var konservCategory = await _context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "ERZ001");
            var edadUnit = await _context.Vahidler.FirstAsync(u => u.QisaAd == "ədəd");
            var kgUnit = await _context.Vahidler.FirstAsync(u => u.QisaAd == "kq");
            var literUnit = await _context.Vahidler.FirstAsync(u => u.QisaAd == "L");

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
                    KateqoriyaId = (await _context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "DYR")).Id,
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
                    KateqoriyaId = (await _context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "MTV")).Id,
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
                    KateqoriyaId = (await _context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "SUD")).Id,
                    VahidId = literUnit.Id,
                    AlisQiymeti = 2.50m,
                    SatisQiymeti = 3.20m,
                    MovcudMiqdar = 8,
                    MinimumMiqdar = 10,
                    Qeydler = "Az stokludur",
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                },
                new Mehsul
                {
                    Ad = "Qəhvə",
                    Tesvir = "Təzə qovrulmuş qəhvə dənələri",
                    Barkod = "2991234567894",
                    SKU = "ERZ006-QHF-0001",
                    KateqoriyaId = (await _context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "ERZ006")).Id,
                    VahidId = kgUnit.Id,
                    AlisQiymeti = 5.00m,
                    SatisQiymeti = 6.50m,
                    MovcudMiqdar = 20,
                    MinimumMiqdar = 5,
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                },
                new Mehsul
                {
                    Ad = "Çay",
                    Tesvir = "Təzə quru çay yarpaqları",
                    Barkod = "2991234567895",
                    SKU = "ERZ006-CAY-0001",
                    KateqoriyaId = (await _context.MehsulKateqoriyalari.FirstAsync(c => c.Kod == "ERZ006")).Id,
                    VahidId = kgUnit.Id,
                    AlisQiymeti = 4.00m,
                    SatisQiymeti = 5.00m,
                    MovcudMiqdar = 30,
                    MinimumMiqdar = 10,
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                }
            };

            await _context.Mehsullar.AddRangeAsync(products);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Seeded products successfully");
        }

        #endregion
    }
}