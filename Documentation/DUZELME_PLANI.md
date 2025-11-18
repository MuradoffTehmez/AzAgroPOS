# 📋 AzAgroPOS Layihəsi - Ətraflı Düzəlmə Planı

**Tarix:** 2025-11-11
**Versiya:** 1.0
**Status:** 🟡 Başlanğıc

---

## 📊 ÜMUMI İNFORMASİYA

### Cari Vəziyyət:
- **Arxitektura:** 7/10
- **Kod Keyfiyyəti:** 6.5/10
- **Test Coverage:** 2/10 (~5%)
- **Performans:** 7.5/10
- **Təhlükəsizlik:** 7/10
- **Ümumi:** 6.1/10

### Target:
- **Arxitektura:** 9/10
- **Kod Keyfiyyəti:** 9/10
- **Test Coverage:** 80%+
- **Performans:** 9/10
- **Təhlükəsizlik:** 9/10
- **Ümumi:** 8.5+/10

### Əsas Problemlər:
1. 🔴 Test coverage çox aşağıdır (5%)
2. 🔴 God Object forms (SatisFormu: 891 sətir, AnaMenuFormu: 588 sətir)
3. 🔴 Kod təkrarları (85+ SaveChanges, 145 MessageBox)
4. 🔴 Circular dependency issues
5. 🟠 OnModelCreating çox böyükdür (873 sətir)
6. 🟠 Service Locator anti-pattern
7. 🟠 Dispose pattern tam deyil
8. 🟠 Memory leak potensialı

---

## 📅 FAZA XÜLASƏSİ

| Faza | Ad | Müddət | Status |
|------|----|---------|---------|
| 1 | Kritik Təhlükəsizlik və Stability | 1-2 həftə | 🔴 Gözləyir |
| 2 | Test Infrastructure | 2-3 həftə | ⚪ Planlaşdırılır |
| 3 | Kod Təkrarlarını Aradan Qaldırmaq | 2 həftə | ⚪ Planlaşdırılır |
| 4 | Database və Performance Optimizasiya | 2-3 həftə | ⚪ Planlaşdırılır |
| 5 | Entity Configuration Refactor | 1-2 həftə | ⚪ Planlaşdırılır |
| 6 | God Object - SatisFormu Refactor | 2-3 həftə | ⚪ Planlaşdırılır |
| 7 | God Object - AnaMenuFormu Refactor | 1-2 həftə | ⚪ Planlaşdırılır |
| 8 | Circular Dependency Həlli | 1 həftə | ⚪ Planlaşdırılır |
| 9 | Manager Interface-ləri və SOLID | 2 həftə | ⚪ Planlaşdırılır |
| 10 | Service Decomposition - SRP | 2-3 həftə | ⚪ Planlaşdırılır |
| 11 | Dispose Pattern və Memory Leak | 1 həftə | ⚪ Planlaşdırılır |
| 12 | Authentication və Təhlükəsizlik | 1-2 həftə | ⚪ Planlaşdırılır |
| 13 | Konfiqurasiya və Environment | 1 həftə | ⚪ Planlaşdırılır |
| 14 | Null Safety və Validation | 1-2 həftə | ⚪ Planlaşdırılır |
| 15 | Async/Await Optimizasiya | 1 həftə | ⚪ Planlaşdırılır |
| 16 | Arxiv və Data Management | 1 həftə | ⚪ Planlaşdırılır |
| 17 | Strategy Pattern və Configuration | 1 həftə | ⚪ Planlaşdırılır |
| 18 | Test Coverage Artırmaq | 3-4 həftə | ⚪ Planlaşdırılır |
| 19 | Performans Testing və Monitoring | 1-2 həftə | ⚪ Planlaşdırılır |
| 20 | Statik Kod Analiz və Quality | 1 həftə | ⚪ Planlaşdırılır |
| 21 | CI/CD Pipeline | 1 həftə | ⚪ Planlaşdırılır |
| 22 | Sənədləşdirmə | 1-2 həftə | ⚪ Planlaşdırılır |
| 23 | Final Test və Optimizasiya | 1-2 həftə | ⚪ Planlaşdırılır |

**Ümumi Müddət:** 30-50 həftə (~7-12 ay)

---

# 🔴 FAZA 1: KRİTİK TƏHLÜKƏSİZLİK VƏ STABILITY

**Müddət:** 1-2 həftə
**Prioritet:** 🔴 Yüksək
**Status:** Gözləyir

## Məqsəd:
Layihədəki kritik təhlükəsizlik və stability problemlərini dərhal aradan qaldırmaq.

## Tapşırıqlar:

### 1. SQL Injection Parametric Query-lərini Yoxlamaq və Təsdiqləmə
**Fayl:** `AzAgroPOS.Mentiq/Idareciler/BazaIdareetmeManager.cs`

**Problem:**
```csharp
// ƏVVƏL (həll edilib ✅):
var sql = $"WHERE database_name = '{databaseName}'";  // ❌ Injection risk
```

**Yoxlanılmalı:**
- ✅ `QuoteName` metodu istifadə edilir
- ✅ Parametric query-lər istifadə edilir
- ⚠️ Digər manager-lərdə də yoxlanılmalı

**Əlavə Yoxlama Lazımdır:**
```bash
# SQL injection pattern-lərini axtarın:
grep -r "WHERE.*\$" --include="*.cs" AzAgroPOS.Mentiq/
grep -r "SET.*\$" --include="*.cs" AzAgroPOS.Mentiq/
grep -r "FROM.*\$" --include="*.cs" AzAgroPOS.Mentiq/
```

### 2. SemaphoreSlim Dispose Pattern-ini Düzəltmək
**Fayl:** `AzAgroPOS.Verilenler/Realizasialar/Repozitori.cs:14`

**Problem:**
```csharp
private readonly SemaphoreSlim _semaphore = new(1, 1);
// ❌ Heç vaxt dispose edilmir - memory leak!
```

**Həll:**
```csharp
public class Repozitori<T> : IRepozitori<T>, IDisposable where T : BazaVarligi
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private bool _disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _semaphore?.Dispose();
            }
            _disposed = true;
        }
    }

    ~Repozitori()
    {
        Dispose(false);
    }
}
```

**QEYD:** Semaphore əslində lazım olmaya bilər (DbContext scoped-dir). Faza 4-də silinəcək.

### 3. Custom Exception Hierarchy Yaratmaq

**Fayllar:**
- `AzAgroPOS.Mentiq/Istisnalar/ValidationException.cs` ✅ (Var)
- `AzAgroPOS.Mentiq/Istisnalar/BusinessRuleException.cs` ✅ (Var)
- `AzAgroPOS.Mentiq/Istisnalar/DataNotFoundException.cs` (Yaradılmalı)
- `AzAgroPOS.Mentiq/Istisnalar/UnauthorizedException.cs` (Yaradılmalı)
- `AzAgroPOS.Mentiq/Istisnalar/ConcurrencyException.cs` (Yaradılmalı)

**Yaradılmalı Yeni Exception-lar:**

```csharp
// DataNotFoundException.cs
namespace AzAgroPOS.Mentiq.Istisnalar
{
    public class DataNotFoundException : Exception
    {
        public string EntityName { get; }
        public object EntityId { get; }

        public DataNotFoundException(string entityName, object entityId)
            : base($"{entityName} tapılmadı (ID: {entityId})")
        {
            EntityName = entityName;
            EntityId = entityId;
        }

        public DataNotFoundException(string entityName, object entityId, Exception innerException)
            : base($"{entityName} tapılmadı (ID: {entityId})", innerException)
        {
            EntityName = entityName;
            EntityId = entityId;
        }
    }
}

// UnauthorizedException.cs
namespace AzAgroPOS.Mentiq.Istisnalar
{
    public class UnauthorizedException : Exception
    {
        public string RequiredPermission { get; }

        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, string requiredPermission)
            : base(message)
        {
            RequiredPermission = requiredPermission;
        }
    }
}

// ConcurrencyException.cs
namespace AzAgroPOS.Mentiq.Istisnalar
{
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException(string message) : base(message)
        {
        }

        public ConcurrencyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
```

### 4. Global Exception Handler-i Təkmilləşdirmək

**Fayl:** `AzAgroPOS.Teqdimat/Yardimcilar/GlobalExceptionHandler.cs`

**Cari vəziyyət:** ✅ Var, amma təkmilləşdirilməli

**Təkmilləşdirmə:**

```csharp
public static class GlobalExceptionHandler
{
    public static string Handle(Exception exception, string source, bool isTerminating)
    {
        var errorId = Guid.NewGuid().ToString("N").Substring(0, 8);
        var errorMessage = $"[{errorId}] ";

        switch (exception)
        {
            case DataNotFoundException notFoundEx:
                Logger.XeberdarligYaz($"[{errorId}] Data tapılmadı: {notFoundEx.EntityName} (ID: {notFoundEx.EntityId})");
                errorMessage += $"Məlumat tapılmadı: {notFoundEx.EntityName}";
                break;

            case ValidationException validationEx:
                Logger.XeberdarligYaz($"[{errorId}] Validation xətası: {validationEx.Message}");
                errorMessage += $"Məlumatlar düzgün deyil:\n{string.Join("\n", validationEx.Errors)}";
                break;

            case BusinessRuleException businessEx:
                Logger.XeberdarligYaz($"[{errorId}] Business rule xətası: {businessEx.Message}");
                errorMessage += $"Əməliyyat icra oluna bilməz: {businessEx.Message}";
                break;

            case UnauthorizedException unauthorizedEx:
                Logger.XeberdarligYaz($"[{errorId}] Icazə xətası: {unauthorizedEx.Message}");
                errorMessage += "Bu əməliyyatı yerinə yetirmək üçün icazəniz yoxdur.";
                break;

            case ConcurrencyException concurrencyEx:
                Logger.XeberdarligYaz($"[{errorId}] Concurrency xətası: {concurrencyEx.Message}");
                errorMessage += "Məlumat başqa istifadəçi tərəfindən dəyişdirilib. Yenidən yükləyin.";
                break;

            case DbUpdateException dbEx:
                Logger.XetaYaz(dbEx, $"[{errorId}] Database xətası: {source}");
                errorMessage += "Verilənlər bazası xətası baş verdi.";
                break;

            case OutOfMemoryException:
                Logger.XetaYaz(exception, $"[{errorId}] KRITIK: Yaddaş bitdi - {source}");
                errorMessage += "SİSTEM XƏTASI: Yaddaş kifayət deyil. Proqramı yenidən başladın.";
                break;

            default:
                Logger.XetaYaz(exception, $"[{errorId}] Gözlənilməz xəta: {source}");
                errorMessage += $"Gözlənilməz xəta baş verdi.";
                break;
        }

        if (isTerminating)
        {
            errorMessage += $"\n\nProqram bağlanmalıdır.\nXəta ID: {errorId}";
        }
        else
        {
            errorMessage += $"\n\nXəta ID: {errorId}\n(Dəstək üçün bu ID-ni göndərin)";
        }

        return errorMessage;
    }
}
```

### 5. Connection String-ləri User Secrets-ə Köçürmək

**Məqsəd:** Git repository-də şifrələr və connection string-lər saxlamamaq

**Addımlar:**

#### 5.1. User Secrets İnit
```bash
cd AzAgroPOS.Teqdimat
dotnet user-secrets init
```

#### 5.2. Connection String Əlavə Et
```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=AzAgroPOS_DB;Trusted_Connection=true;TrustServerCertificate=true"
```

#### 5.3. appsettings.json Təmizlə
```json
{
  "ConnectionStrings": {
    "DefaultConnection": ""  // Boş burax - user secrets və ya env var-dan oxunacaq
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.EntityFrameworkCore": "Warning"
    }
  }
}
```

#### 5.4. Program.cs Update
```csharp
var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true)
    .AddUserSecrets<Program>()  // ✅ User Secrets
    .AddEnvironmentVariables("AZAGROPOS_");  // ✅ Environment Variables

var configuration = builder.Build();
```

#### 5.5. .gitignore Update
```gitignore
# Connection Strings və Secrets
appsettings.Development.json
appsettings.Production.json
appsettings.Staging.json
**/appsettings.*.json
!appsettings.json

# User Secrets
secrets.json
```

### 6. Generic Exception Catching-i Düzəltmək

**Problem:** 53 faylda generic `catch (Exception ex)` var

**Strategy:**
1. Hər manager-də specific exception-ları tut
2. Generic catch-i ən sonda saxla, amma log et

**Nümunə Refactor:**

**Əvvəl:**
```csharp
try
{
    // Əməliyyat
    await _unitOfWork.EmeliyyatiTesdiqleAsync();
    return EmeliyyatNeticesi<T>.Ugurlu(data);
}
catch (Exception ex)  // ❌ Çox generic
{
    Logger.XetaYaz(ex, "Xəta");
    return EmeliyyatNeticesi<T>.Ugursuz(ex.Message);
}
```

**Sonra:**
```csharp
try
{
    // Əməliyyat
    await _unitOfWork.EmeliyyatiTesdiqleAsync();
    return EmeliyyatNeticesi<T>.Ugurlu(data);
}
catch (DataNotFoundException ex)
{
    Logger.XeberdarligYaz($"Məlumat tapılmadı: {ex.EntityName}");
    return EmeliyyatNeticesi<T>.Ugursuz(ex.Message);
}
catch (ValidationException ex)
{
    Logger.XeberdarligYaz($"Validation xətası: {string.Join(", ", ex.Errors)}");
    return EmeliyyatNeticesi<T>.Ugursuz("Məlumatlar düzgün deyil", ex.Errors);
}
catch (BusinessRuleException ex)
{
    Logger.XeberdarligYaz($"Business rule pozuldu: {ex.Message}");
    return EmeliyyatNeticesi<T>.Ugursuz(ex.Message);
}
catch (DbUpdateConcurrencyException ex)
{
    Logger.XeberdarligYaz("Concurrency xətası - məlumat başqası tərəfindən dəyişdirilib");
    return EmeliyyatNeticesi<T>.Ugursuz("Məlumat artıq dəyişdirilib. Yenidən yükləyin.");
}
catch (DbUpdateException ex)
{
    Logger.XetaYaz(ex, "Database update xətası");
    return EmeliyyatNeticesi<T>.Ugursuz("Verilənlər bazası xətası baş verdi");
}
catch (Exception ex) when (!(ex is OutOfMemoryException || ex is StackOverflowException))
{
    Logger.XetaYaz(ex, "Gözlənilməz xəta");
    return EmeliyyatNeticesi<T>.Ugursuz("Gözlənilməz xəta baş verdi");
}
// OutOfMemoryException və StackOverflowException tutulmur - crash etsin
```

---

## ✅ Acceptance Criteria (Faza 1)

- [ ] SQL injection riski yoxdur (parametric query-lər istifadə olunur)
- [ ] SemaphoreSlim düzgün dispose edilir
- [ ] 5 custom exception class mövcuddur və istifadə olunur
- [ ] GlobalExceptionHandler specific exception-ları handle edir
- [ ] Connection string-lər user secrets-də saxlanılır
- [ ] appsettings.json-da sensitive data yoxdur
- [ ] Generic exception catching 50%-dən çox azalıb
- [ ] Bütün kritik exception-lar log olunur

---

## 📝 Qeydlər

- Semaphore Faza 4-də tam silinəcək (DbContext scoped-dir, thread-safe-dir)
- Exception handling pattern bütün manager-lərə Faza 3-də tətbiq olunacaq (BaseManager vasitəsilə)
- User Secrets yalnız development üçündür - production-da environment variables istifadə olunmalı

---

## 🔗 Növbəti Faza

**Faza 2:** Test Infrastructure Qurmaq

---

# 🟠 FAZA 2: TEST INFRASTRUCTURE QURA

**Müddət:** 2-3 həftə
**Prioritet:** 🔴 Yüksək
**Status:** Planlaşdırılır

## Məqsəd:
Test infrastructure qurmaq və ilk unit test-ləri yazmaq. Test coverage-i 5%-dən 40%-ə çatdırmaq.

## Tapşırıqlar:

### 1. Test Proyektini Genişləndirmək

**Struktur:**
```
AzAgroPOS.Tests/
├── Unit/
│   ├── Managers/
│   │   ├── SatisManagerTests.cs
│   │   ├── MehsulManagerTests.cs
│   │   ├── MusteriManagerTests.cs
│   │   ├── AlisManagerTests.cs
│   │   └── IsciManagerTests.cs
│   ├── Repositories/
│   │   ├── RepozitoriTests.cs ✅
│   │   ├── UnitOfWorkTests.cs
│   │   └── MehsulRepozitoriTests.cs
│   ├── Presenters/
│   │   ├── SatisPresenterTests.cs
│   │   └── MusteriPresenterTests.cs
│   └── Services/
│       └── (Faza 10-da əlavə olunacaq)
├── Integration/
│   ├── DatabaseTests.cs
│   ├── RepositoryIntegrationTests.cs
│   └── UnitOfWorkIntegrationTests.cs
├── TestHelpers/
│   ├── MockData/
│   │   ├── MehsulMockFactory.cs
│   │   ├── MusteriMockFactory.cs
│   │   ├── SatisMockFactory.cs
│   │   └── IstifadeciMockFactory.cs
│   ├── TestDbContext.cs
│   ├── TestFixture.cs
│   └── AutoMoqDataAttribute.cs
└── TestData/
    └── test_seed_data.sql
```

### 2. Mock Data Factory Classes

```csharp
// MehsulMockFactory.cs
public static class MehsulMockFactory
{
    public static Mehsul CreateValid(int id = 1)
    {
        return new Mehsul
        {
            Id = id,
            Ad = $"Test Məhsul {id}",
            StokKodu = $"STK{id:D6}",
            Barkod = $"1234567890{id:D3}",
            Qiymet = 10.50m,
            TopQiymet = 15.00m,
            PerekendeQiymet = 20.00m,
            MovcudSay = 100,
            MinimumStok = 10,
            Silinib = false,
            YaradilmaTarixi = DateTime.Now
        };
    }

    public static MehsulDto CreateValidDto(int id = 1)
    {
        return new MehsulDto
        {
            Id = id,
            Ad = $"Test Məhsul {id}",
            StokKodu = $"STK{id:D6}",
            Barkod = $"1234567890{id:D3}",
            Qiymet = 10.50m,
            MovcudSay = 100
        };
    }

    public static List<Mehsul> CreateList(int count = 10)
    {
        return Enumerable.Range(1, count)
            .Select(i => CreateValid(i))
            .ToList();
    }
}

// MusteriMockFactory.cs
public static class MusteriMockFactory
{
    public static Musteri CreateValid(int id = 1)
    {
        return new Musteri
        {
            Id = id,
            TamAd = $"Test Müştəri {id}",
            TelefonNomresi = $"+994501234{id:D3}",
            Email = $"test{id}@example.com",
            Unvan = "Bakı şəhəri",
            KreditLimiti = 1000m,
            UmumiBorc = 0m,
            Silinib = false
        };
    }
}

// SatisMockFactory.cs
public static class SatisMockFactory
{
    public static Satis CreateValid(int id = 1, int? musteriId = null)
    {
        return new Satis
        {
            Id = id,
            NovbeId = 1,
            MusteriId = musteriId,
            OdenisMetodu = OdenisMetodu.Negd,
            UmumiMebleg = 100m,
            Endirim = 0m,
            YekunMebleg = 100m,
            Tarix = DateTime.Now,
            Silinib = false
        };
    }
}
```

### 3. Test DbContext

```csharp
public class TestDbContext
{
    public static AzAgroPOSDbContext CreateInMemory(string dbName = null)
    {
        var options = new DbContextOptionsBuilder<AzAgroPOSDbContext>()
            .UseInMemoryDatabase(databaseName: dbName ?? Guid.NewGuid().ToString())
            .Options;

        var context = new AzAgroPOSDbContext(options);
        context.Database.EnsureCreated();
        return context;
    }

    public static void SeedTestData(AzAgroPOSDbContext context)
    {
        // Rol
        var adminRole = new Rol { Id = 1, Ad = "Admin", Izahlar = "Test Admin", Silinib = false };
        context.Rollar.Add(adminRole);

        // İstifadəçi
        var admin = new Istifadeci
        {
            Id = 1,
            IstifadeciAdi = "testadmin",
            TamAd = "Test Admin",
            SifreHash = BCrypt.Net.BCrypt.HashPassword("test123"),
            RolId = 1,
            Silinib = false
        };
        context.Istifadeciler.Add(admin);

        // Məhsullar
        context.Mehsullar.AddRange(MehsulMockFactory.CreateList(20));

        // Müştərilər
        for (int i = 1; i <= 10; i++)
        {
            context.Musteriler.Add(MusteriMockFactory.CreateValid(i));
        }

        context.SaveChanges();
    }
}
```

### 4. SatisManager Unit Tests

```csharp
public class SatisManagerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<NisyeManager> _nisyeManagerMock;
    private readonly SatisManager _sut;

    public SatisManagerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _nisyeManagerMock = new Mock<NisyeManager>();
        _sut = new SatisManager(_unitOfWorkMock.Object, _nisyeManagerMock.Object);
    }

    [Fact]
    public async Task SatisYaratAsync_ValidData_ReturnsSuccess()
    {
        // Arrange
        var dto = new SatisYaratDto
        {
            NovbeId = 1,
            MusteriId = null,
            OdenisMetodu = OdenisMetodu.Negd,
            SebetElementleri = new List<SatisSebetiElementiDto>
            {
                new() { MehsulId = 1, Miqdar = 2, VahidinQiymeti = 10m, UmumiMebleg = 20m }
            },
            UmumiMebleg = 20m,
            Endirim = 0m,
            YekunMebleg = 20m
        };

        var mehsul = MehsulMockFactory.CreateValid(1);
        mehsul.MovcudSay = 100;

        _unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1))
            .ReturnsAsync(mehsul);

        _unitOfWorkMock.Setup(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()))
            .Returns(Task.CompletedTask);

        _unitOfWorkMock.Setup(u => u.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _sut.SatisYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.YekunMebleg.Should().Be(20m);

        _unitOfWorkMock.Verify(u => u.Mehsullar.GetirAsync(1), Times.Once);
        _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.AtLeastOnce);
    }

    [Fact]
    public async Task SatisYaratAsync_InsufficientStock_ReturnsFailure()
    {
        // Arrange
        var dto = new SatisYaratDto
        {
            NovbeId = 1,
            SebetElementleri = new List<SatisSebetiElementiDto>
            {
                new() { MehsulId = 1, Miqdar = 200, VahidinQiymeti = 10m }
            }
        };

        var mehsul = MehsulMockFactory.CreateValid(1);
        mehsul.MovcudSay = 50; // Stokda kifayət deyil

        _unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1))
            .ReturnsAsync(mehsul);

        // Act
        var result = await _sut.SatisYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("stokda");
    }

    [Fact]
    public async Task SatisYaratAsync_CreditLimit_ReturnsFailure()
    {
        // Arrange
        var musteri = MusteriMockFactory.CreateValid(1);
        musteri.KreditLimiti = 100m;
        musteri.UmumiBorc = 90m;

        var dto = new SatisYaratDto
        {
            NovbeId = 1,
            MusteriId = 1,
            OdenisMetodu = OdenisMetodu.Nisye,
            YekunMebleg = 20m, // 90 + 20 = 110 > 100 limit
            SebetElementleri = new List<SatisSebetiElementiDto>
            {
                new() { MehsulId = 1, Miqdar = 2, VahidinQiymeti = 10m }
            }
        };

        _unitOfWorkMock.Setup(u => u.Musteriler.GetirAsync(1))
            .ReturnsAsync(musteri);

        // Act
        var result = await _sut.SatisYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("kredit limit");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public async Task SatisYaratAsync_InvalidQuantity_ReturnsFailure(int miqdar)
    {
        // Arrange
        var dto = new SatisYaratDto
        {
            SebetElementleri = new List<SatisSebetiElementiDto>
            {
                new() { MehsulId = 1, Miqdar = miqdar, VahidinQiymeti = 10m }
            }
        };

        // Act
        var result = await _sut.SatisYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
    }
}
```

### 5. MehsulManager Unit Tests

```csharp
public class MehsulManagerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly MehsulManager _sut;

    public MehsulManagerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _sut = new MehsulManager(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task MehsulYaratAsync_ValidData_ReturnsSuccess()
    {
        // Arrange
        var dto = MehsulMockFactory.CreateValidDto();

        _unitOfWorkMock.Setup(u => u.Mehsullar.ElaveEtAsync(It.IsAny<Mehsul>()))
            .Returns(Task.CompletedTask);

        _unitOfWorkMock.Setup(u => u.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _sut.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Ad.Should().Be(dto.Ad);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task MehsulYaratAsync_EmptyName_ReturnsFailure(string ad)
    {
        // Arrange
        var dto = MehsulMockFactory.CreateValidDto();
        dto.Ad = ad;

        // Act
        var result = await _sut.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("ad");
    }

    [Fact]
    public async Task MehsulYaratAsync_DuplicateBarkod_ReturnsFailure()
    {
        // Arrange
        var existingMehsul = MehsulMockFactory.CreateValid(1);
        var dto = MehsulMockFactory.CreateValidDto(2);
        dto.Barkod = existingMehsul.Barkod; // Duplicate

        _unitOfWorkMock.Setup(u => u.Mehsullar.AxtarAsync(
            It.IsAny<Expression<Func<Mehsul, bool>>>(),
            null))
            .ReturnsAsync(new[] { existingMehsul });

        // Act
        var result = await _sut.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("barkod");
    }

    [Fact]
    public async Task MehsulSilAsync_ExistingMehsul_SoftDeletes()
    {
        // Arrange
        var mehsul = MehsulMockFactory.CreateValid(1);
        mehsul.Silinib = false;

        _unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1))
            .ReturnsAsync(mehsul);

        // Act
        var result = await _sut.MehsulSilAsync(1);

        // Assert
        result.UgurluDur.Should().BeTrue();
        mehsul.Silinib.Should().BeTrue();
        mehsul.SilinmeTarixi.Should().NotBeNull();
    }
}
```

### 6. Repository Integration Tests

```csharp
public class RepositoryIntegrationTests : IDisposable
{
    private readonly AzAgroPOSDbContext _context;
    private readonly IRepozitori<Mehsul> _repository;

    public RepositoryIntegrationTests()
    {
        _context = TestDbContext.CreateInMemory();
        TestDbContext.SeedTestData(_context);
        _repository = new MehsulRepozitori(_context);
    }

    [Fact]
    public async Task ElaveEtAsync_ValidEntity_AddsToDatabase()
    {
        // Arrange
        var mehsul = MehsulMockFactory.CreateValid(999);

        // Act
        await _repository.ElaveEtAsync(mehsul);
        await _context.SaveChangesAsync();

        // Assert
        var saved = await _context.Mehsullar.FindAsync(999);
        saved.Should().NotBeNull();
        saved.Ad.Should().Be(mehsul.Ad);
    }

    [Fact]
    public async Task AxtarAsync_WithFilter_ReturnsFilteredResults()
    {
        // Act
        var results = await _repository.AxtarAsync(m => m.Qiymet > 12m);

        // Assert
        results.Should().NotBeEmpty();
        results.Should().OnlyContain(m => m.Qiymet > 12m);
    }

    [Fact]
    public async Task GetirAsync_NonExistent_ReturnsNull()
    {
        // Act
        var result = await _repository.GetirAsync(99999);

        // Assert
        result.Should().BeNull();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
```

### 7. Code Coverage Tool Quraşdırmaq

**Packages:**
```xml
<PackageReference Include="coverlet.collector" Version="6.0.0" />
<PackageReference Include="ReportGenerator" Version="5.2.0" />
```

**Commands:**
```bash
# Test run with coverage
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura

# Generate HTML report
reportgenerator -reports:**/coverage.cobertura.xml -targetdir:coverage-report -reporttypes:Html

# Open report
start coverage-report/index.html
```

**GitHub Actions Integration:**
```yaml
- name: Run tests with coverage
  run: dotnet test --configuration Release --collect:"XPlat Code Coverage"

- name: Generate coverage report
  uses: codecov/codecov-action@v3
  with:
    files: ./**/coverage.cobertura.xml
```

---

## ✅ Acceptance Criteria (Faza 2)

- [ ] Test proyekti strukturu yaradılıb
- [ ] 4 Mock Factory class mövcuddur
- [ ] TestDbContext və seed data hazırdır
- [ ] SatisManager üçün minimum 10 unit test
- [ ] MehsulManager üçün minimum 8 unit test
- [ ] MusteriManager üçün minimum 6 unit test
- [ ] Repository integration test-ləri yazılıb
- [ ] Code coverage tool quraşdırılıb
- [ ] Coverage 40%+ (ilkin target)
- [ ] Bütün test-lər pass edir

---

# 🟡 FAZA 3-23: QALANLAR

*(Saxlanmışdır - hər fazanın detalları oxşar formatda davam edir)*

---

## 📊 PROGRESS TRACKER

| Faza | Başlama | Bitirmə | Status | Coverage |
|------|---------|---------|--------|----------|
| 1 | - | - | 🔴 Gözləyir | - |
| 2 | - | - | ⚪ Gələcək | - |
| ... | - | - | ⚪ Gələcək | - |

---

## 📚 FAYDA LI RESURLAR

### Tools:
- **xUnit** - Unit testing framework
- **Moq** - Mocking library
- **FluentAssertions** - Assertion library
- **Coverlet** - Code coverage
- **ReportGenerator** - Coverage reports
- **BenchmarkDotNet** - Performance testing
- **SonarQube** - Code quality

### Documentation:
- [xUnit Documentation](https://xunit.net/)
- [Moq Quickstart](https://github.com/moq/moq4/wiki/Quickstart)
- [FluentAssertions](https://fluentassertions.com/)
- [EF Core Testing](https://learn.microsoft.com/en-us/ef/core/testing/)

---

**Son Yenilənmə:** 2025-11-11
**Versiya:** 1.0
