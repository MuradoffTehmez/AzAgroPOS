# AzAgroPOS Layihəsi - SQL və EF Core Refaktorinq Təlimatı

Sən bir Təcrübəli C# / .NET və SQL Server Memarısan (Software Architect). 
Aşağıda təqdim edilən "AzAgroPOS" layihəsindəki arxitektura, Entity Framework Core və tranzaksiya (transaction) problemlərini həll etməyin tələb olunur.

## ⚠️ Mövcud Problemlər və Səndən Tələb Olunan Tapşırıqlar:

### Tapşırıq 1: Tranzaksiya (Explicit Transaction) İdarəetməsinin Əlavə Edilməsi (ACID Təminatı)
**Problem:** `SatisManager.cs` daxilindəki `SatisYaratAsync` və `QaytarmaEmeliyyatiAsync` metodlarında `_unitOfWork.EmeliyyatiTesdiqleAsync()` (SaveChanges) funksiyası eyni biznes məntiqi daxilində birdən çox çağırılır. Ortada xəta baş verərsə, məlumat bazasında yarımçıq qeydlər (tutarsızlıq) yaranır.
**Həll Tələbi:**
1. `IUnitOfWork` interfeysinə və onun realizasiyasına `BeginTransactionAsync()`, `CommitTransactionAsync()`, və `RollbackTransactionAsync()` metodlarını əlavə et.
2. `SatisManager` sinfindəki `SatisYaratAsync` və `QaytarmaEmeliyyatiAsync` metodlarını bu tranzaksiya blokları daxilində yenidən yazın. Bütün proses bitdikdən sonra məlumatlar commit edilməli, xəta olduqda rollback olunmalıdır.

### Tapşırıq 2: Global Query Filter (Soft Delete) Tətbiqi
**Problem:** `Repozitori.cs` faylında hər LINQ sorğusunda əllə `.Where(e => !e.Silinib)` yazılıb. Bu kod təkrarıdır və xətaya meyllidir.
**Həll Tələbi:**
1. `AzAgroPOSDbContext.cs` faylında `OnModelCreating` daxilində reflection istifadə edərək və ya birbaşa bütün müvafiq entity-lər üçün `.HasQueryFilter(e => !e.Silinib)` qlobal filtrini tətbiq et.
2. `Repozitori.cs` faylındakı metodlardan (`AxtarAsync`, `GetirAsync` və s.) əllə yazılmış `!e.Silinib` şərtlərini təmizlə. Silinmişləri gətirmək üçün `.IgnoreQueryFilters()` funksiyasından istifadə edən metodları yenilə.

### Tapşırıq 3: Eager Loading üçün "Magic String"-lərin Ləğvi
**Problem:** Repozitoriyada relation-ları yükləmək üçün `string[] includeProperties` istifadə olunur (məs: `"SatisDetallari.Mehsul"`).
**Həll Tələbi:**
1. `IRepozitori<T>` və `Repozitori<T>` fayllarında `includeProperties` parametrini Type-Safe hala gətir. Məsələn: `params Expression<Func<T, object>>[] includes` istifadə et.
2. `SatisManager.cs` daxilində `_unitOfWork.Satislar.GetirAsync(satisId, new[] { "SatisDetallari.Mehsul" })` çağırışını Type-Safe versiya ilə (Məsələn: `query.Include(s => s.SatisDetallari).ThenInclude(d => d.Mehsul)` formatına uyğun) əvəz et.

---

## 💻 Gözlənilən Çıxış (Output):
Zəhmət olmasa, aşağıdakı faylların yenilənmiş, tam və işlək (refactored) kodlarını mənə təqdim et:
1. `AzAgroPOSDbContext.cs` (Global Query Filter əlavə edilmiş halda)
2. `IUnitOfWork.cs` və `UnitOfWork.cs` (Transaction metodları əlavə edilmiş halda)
3. `IRepozitori.cs` və `Repozitori.cs` (Type-safe Includes və təmizlənmiş Soft Delete məntiqi ilə)
4. `SatisManager.cs` (Transaction bloku ilə tam qorunan satış və qaytarma prosesi)

Kodlar standartlara uyğun, asan oxunan və try-catch bloklarında düzgün error-handling ilə təchiz olunmalıdır.
