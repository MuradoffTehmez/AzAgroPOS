# AzAgroPOS Kritik Düzəliş Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Repo-dan sızmış admin parolunu təmizləmək, WinForms DI scope sızmasını düzəltmək, satış/qaytarma tranzaksiya bütövlüyünü təmin etmək, stok overselling race condition-unu aradan qaldırmaq, və dublikat `MehsulManager`/`MehsulMeneceri` sinifini birləşdirmək — layihəni "işlək və düzgün" vəziyyətə gətirmək.

**Architecture:** Mövcud qat-qat arxitektura (Varliglar/Verilenler/Mentiq/Teqdimat/Tests) saxlanılır, yeni layer/servis əlavə edilmir. Bütün düzəlişlər mövcud sinif/fayl daxilində edilir, yalnız `IMehsulRepozitori`-yə bir yeni metod (`StoquAtomicAzaltAsync`) əlavə olunur.

**Tech Stack:** .NET 9 / C# (Teqdimat/Mentiq/Verilenler), .NET 8 test layihəsi (`AzAgroPOS.Tests`, xUnit + Moq + FluentAssertions), EF Core 9.0.8 + SQL Server, WinForms.

**Spec:** `docs/superpowers/specs/2026-08-24-critical-fixes-design.md`

## Global Constraints

- Mühit yalnız dev/test — real production data yoxdur, repo yalnız lokal (tək istifadəçi) — git history rewrite sərbəstdir.
- Hər tapşırıqdan sonra `dotnet build` (0 xəta) və `dotnet test` (bütün mövcud testlər keçir) icra olunur.
- Yeni kod comment yazmır, yalnız WHY qeyri-aşkar olduqda (mövcud kod bazasının konvensiyasına uyğun, Azərbaycan dilində, `///` XML-doc minimal).
- `AzAgroPOS.Tests` yalnız EF Core InMemory provider istifadə edir — `ExecuteUpdateAsync` orada dəstəklənmir, ona görə DB-səviyyəli atomic əməliyyatlar ayrıca repository metodu arxasında gizlədilib ki, çağıran tərəf (Manager) Moq ilə test edilə bilsin.
- Mövcud kod konvensiyası: Manager metodları `try/catch` + `Logger.XetaYaz`/`Logger.XəbərdarlıqYaz` + `EmeliyyatNeticesi<T>.Ugurlu/Ugursuz` qaytarır. Yeni kod bu pattern-ə uyğunlaşır.

---

### Task 1: Sızmış parol/hash fayllarını sil və git tarixçəsindən təmizlə

**Files:**
- Delete: `PasswordHasher/GenerateHash.cs`
- Delete: `PasswordHasher/ResetAdminPassword.cs`
- Delete: `PasswordHasher/DatabaseTest.cs`
- Delete: `PasswordHasher/Program.cs`
- Delete: `PasswordHasher/PasswordHasher.csproj`
- Delete: `sql scrip/ResetPassword.sql`
- Modify: `AzAgroPOS.sln` (PasswordHasher layihə girişini sil)

**Interfeys:** Yoxdur — təcrid olunmuş fayl silmə, kod dəyişikliyi yoxdur.

**Kontekst:** `PasswordHasher/Program.cs` aktiv şəkildə `"admin123"` sabit parolunu BCrypt ilə hash-ləyib SQL update əmri çap edir. `GenerateHash.cs` və `ResetAdminPassword.cs` eyni şeyi edən, tamamilə şərh içində (`/* ... */`) ölü kod nüsxələridir. `sql scrip/ResetPassword.sql` real BCrypt hash-i (`$2a$11$bwcdAYMDlqwe...`) açıq mətn kimi saxlayır və admin hesabını bu hash-ə sıfırlayır. `PasswordHasher.csproj` `AzAgroPOS.sln`-də layihə kimi qeydiyyatlıdır (sətir 16), amma əsas tətbiqin bir hissəsi deyil — sırf tək dəfəlik dev alətidir.

- [ ] **Step 1: Faylların silinməzdən əvvəl heç yerdə istinad olunmadığını təsdiqlə**

Run: `grep -rn "PasswordHasher" --include=*.cs --include=*.csproj . | grep -v "PasswordHasher/"`
Expected: Yalnız `AzAgroPOS.sln`-dəki referans görünür, başqa heç nə.

- [ ] **Step 2: Faylları sil**

```bash
git rm -r "PasswordHasher"
git rm "sql scrip/ResetPassword.sql"
```

- [ ] **Step 3: `AzAgroPOS.sln`-dən PasswordHasher layihə girişini sil**

`AzAgroPOS.sln` faylını aç, aşağıdakı bloku (və ona uyğun `GlobalSection(ProjectConfigurationPlatforms)` daxilindəki `{C2B5CD7B-CE36-8DB5-C4DA-7D41A30DDAD6}` sətirlərini) tamamilə sil:

```
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "PasswordHasher", "PasswordHasher\PasswordHasher.csproj", "{C2B5CD7B-CE36-8DB5-C4DA-7D41A30DDAD6}"
EndProject
```

- [ ] **Step 4: Build ilə təsdiqlə**

Run: `dotnet build AzAgroPOS.sln`
Expected: 0 xəta, PasswordHasher artıq həll (resolve) olunmur.

- [ ] **Step 5: Commit**

```bash
git add AzAgroPOS.sln
git commit -m "security: remove PasswordHasher dev tool and ResetPassword.sql (hardcoded admin credentials)"
```

- [ ] **Step 6: Git tarixçəsindən tam təmizlə**

Repo yalnız lokal və tək istifadəçidədir (təsdiqlənib) — `git filter-repo` quraşdırılmayıb, ona görə built-in `git filter-branch` istifadə olunur:

```bash
git filter-branch --force --index-filter \
  "git rm -r --cached --ignore-unmatch PasswordHasher 'sql scrip/ResetPassword.sql'" \
  --prune-empty -- --all
```

- [ ] **Step 7: Köhnə referansları təmizlə və təsdiqlə**

```bash
rm -rf .git/refs/original/
git reflog expire --expire=now --all
git gc --prune=now --aggressive
git log -p --all -- PasswordHasher/GenerateHash.cs
```

Expected: son komanda heç bir nəticə qaytarmır (fayl heç bir commit-də görünmür).

---

### Task 2: `appsettings.json` template-dən real connection string-i sil, env-spesifik faylları untrack et

**Files:**
- Modify: `AzAgroPOS.Teqdimat/appsettings.json:3`
- Modify: `.gitignore` (təsdiq, dəyişiklik yoxdursa saxla)
- Untrack (git rm --cached, disk-də saxla): `AzAgroPOS.Teqdimat/appsettings.Development.json`, `AzAgroPOS.Teqdimat/appsettings.Production.json`, `AzAgroPOS.Teqdimat/appsettings.Staging.json`, `AzAgroPOS.Teqdimat/appsettings_new.json`

**Kontekst:** `.gitignore:369-373`-də artıq `appsettings.Development.json`, `appsettings.Production.json`, `appsettings.Staging.json`, `appsettings.*.json` (istisna `!appsettings.json`) qaydaları var — amma bu fayllar qayda əlavə edilməzdən ÖNCƏ artıq commit olunduğu üçün `.gitignore` onları tracking-dən çıxarmır (yalnız yeni fayllar üçün işləyir). Əlavə olaraq, "təhlükəsiz template" sayılan `appsettings.json`-un özündə belə real developer machine adı (`MURADOV-TAHMAZ\MURADOVTAHMAZ`) var — halbuki faylın öz şərhləri (`_comment1..3`) real qiymətin User Secrets-də saxlanmasını tövsiyə edir.

- [ ] **Step 1: `appsettings.json` template-i düzəlt**

`AzAgroPOS.Teqdimat/appsettings.json`, sətir 3:

```json
    "DefaultConnection": "",
```

(əvəzinə: `"Server=MURADOV-TAHMAZ\\MURADOVTAHMAZ;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;"`)

- [ ] **Step 2: Env-spesifik faylları git tracking-dən çıxar (diskdə saxla)**

```bash
git rm --cached "AzAgroPOS.Teqdimat/appsettings.Development.json"
git rm --cached "AzAgroPOS.Teqdimat/appsettings.Production.json"
git rm --cached "AzAgroPOS.Teqdimat/appsettings.Staging.json"
git rm --cached "AzAgroPOS.Teqdimat/appsettings_new.json"
```

`appsettings_new.json` `.gitignore`-un `appsettings.*.json` qaydasına uyğun gəlir (`appsettings.json` deyil) — `git status` ilə artıq ignored olduğunu təsdiqlə.

- [ ] **Step 3: `.gitignore`-a `appsettings_new.json` üçün aydınlıq üçün əlavə sətir əlavə et (əgər `appsettings.*.json` glob-u onu artıq tutmursa)**

Run: `git check-ignore -v AzAgroPOS.Teqdimat/appsettings_new.json`
Expected: `.gitignore:372:appsettings.*.json` çıxışı görünür (artıq tutur). Tutmursa, `.gitignore`-a `appsettings_new.json` sətri əlavə et.

- [ ] **Step 4: Yerli konfiqurasiyanın işlək qaldığını təsdiqlə**

Run: `dotnet build AzAgroPOS.sln` və tətbiqi lokal olaraq işə sal (mövcud `appsettings.Development.json` diskdə qalıb, connection string dəyişməyib — yalnız git-dən çıxarılıb).
Expected: tətbiq əvvəlki kimi verilənlər bazasına qoşulur (fayl fiziki olaraq yerindədir, yalnız artıq izlənmir).

- [ ] **Step 5: Commit**

```bash
git add AzAgroPOS.Teqdimat/appsettings.json .gitignore
git commit -m "security: strip real connection string from appsettings.json template, untrack env-specific appsettings files"
```

- [ ] **Step 6: Git tarixçəsindən developer machine adını təmizlə (Task 1-in davamı olaraq eyni filter-branch keçidində edilə bilərdi, amma ayrıca `appsettings.json`-un əvvəlki versiyalarında machine adı qaldığından, bu addım xəbərdarlıq xarakterlidir, mütləq deyil)**

Qeyd: `appsettings.Development/Production/Staging.json` və `appsettings_new.json` bu addımdan sonra da əvvəlki commit-lərdə görünəcək (yalnız untrack edilib, tarixçədən silinməyib) — çünki bu fayllar developer-in öz maşınında qalmalıdır və Windows Trusted_Connection istifadə etdiyi üçün risk yalnız machine adının ifşasıdır (parol yoxdur). Əgər user tam tarixçə təmizliyi istəyirsə, bu fayllar da Task 1-in `filter-branch --index-filter` siyahısına əlavə edilə bilər — hazırkı plan bunu MƏCBURI hesab etmir (aşağı risk), amma addım qeyd olunur ki, gələcəkdə asanlıqla təkrarlana bilsin.

---

### Task 3: `MehsulManager`-in unikal metodlarını `MehsulMeneceri`-yə köçür

**Files:**
- Modify: `AzAgroPOS.Mentiq/Idareciler/MehsulMeneceri.cs`
- Test: `AzAgroPOS.Tests/Unit/Managers/MehsulMeneceriTests.cs` (yeni, `MehsulManagerTests.cs`-dən köçürülür)

**Interfeysler:**
- Consumes: `IUnitOfWork.Mehsullar` (`IMehsulRepozitori`), mövcud `MehsulDto` (`AzAgroPOS.Mentiq.DTOs`).
- Produces: `MehsulMeneceri.AxtarAsync(string axtarisMetni, int sayLimit = 100)`, `MehsulMeneceri.StokKoduGeneralasiyaEtAsync(string mehsulAdi)`, `MehsulMeneceri.BarkodGeneralasiyaEtAsync()` — bu 3 metod indi `MehsulMeneceri`-nin bir hissəsidir, Task 4-ün istifadə edəcəyi `MehsulMeneceri` tam metod dəstinə malikdir.

- [ ] **Step 1: `MehsulManager.cs`-in 3 unikal metodunu oxu və `MehsulMeneceri.cs`-yə əlavə et**

`AzAgroPOS.Mentiq/Idareciler/MehsulMeneceri.cs`-in sonuna (sinif bağlanmadan əvvəl) `MehsulManager.cs:200-269,271-310`-dan `StokKoduGeneralasiyaEtAsync`, `BarkodGeneralasiyaEtAsync`, `AxtarAsync` metodlarını olduğu kimi köçür (loglama və məzmun dəyişmədən). Fayl başına `using System.Text.RegularExpressions;` əlavə et (`StokKoduGeneralasiyaEtAsync` `Regex.Replace` istifadə edir).

`AxtarAsync`-ın DTO map-i `MehsulMeneceri`-nin digər metodlarındakı tam sahə dəstinə (KateqoriyaId, KateqoriyaAdi, BrendId, BrendAdi, TedarukcuId, TedarukcuAdi, MinimumStok, SekilYolu) uyğunlaşdırılır — `MehsulManager`-dəki köhnə, məhdud map əvəzinə `MehsulMeneceri.ButunMehsullariGetirAsync`-dakı tam map pattern-i istifadə olunur:

```csharp
    public async Task<EmeliyyatNeticesi<string>> StokKoduGeneralasiyaEtAsync(string mehsulAdi)
    {
        Logger.MelumatYaz("Stok kodu yaratma əməliyyatı başlayır");
        try
        {
            if (string.IsNullOrWhiteSpace(mehsulAdi))
            {
                return EmeliyyatNeticesi<string>.Ugursuz("Stok Kodu yaratmaq üçün məhsul adı daxil edilməlidir.");
            }

            string yeniStokKodu;
            Random random = new();

            string[] hisseler = mehsulAdi.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string prefix = hisseler.Length > 0 ? new string(hisseler[0].Take(3).ToArray()).ToUpper() : "SKU";
            prefix = Regex.Replace(prefix, @"[^A-Z]", "");
            if (prefix.Length == 0)
            {
                prefix = "SKU";
            }

            do
            {
                yeniStokKodu = $"{prefix}-{random.Next(10000, 99999)}";
            } while ((await _unitOfWork.Mehsullar.AxtarAsync(m => m.StokKodu == yeniStokKodu)).Any());

            return EmeliyyatNeticesi<string>.Ugurlu(yeniStokKodu);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Stok kodu yaratma əməliyyatı zamanı istisna baş verdi");
            return EmeliyyatNeticesi<string>.Ugursuz("Stok kodu yaratma əməliyyatı zamanı istisna baş verdi: " + ex.Message);
        }
    }

    public async Task<EmeliyyatNeticesi<string>> BarkodGeneralasiyaEtAsync()
    {
        Logger.MelumatYaz("Barkod yaratma əməliyyatı başlayır");
        try
        {
            string yeniBarkod;
            Random random = new();

            do
            {
                yeniBarkod = "2" + random.NextInt64(100_000_000_000, 999_999_999_999).ToString();
            } while ((await _unitOfWork.Mehsullar.AxtarAsync(m => m.Barkod == yeniBarkod)).Any());

            return EmeliyyatNeticesi<string>.Ugurlu(yeniBarkod);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Barkod yaratma əməliyyatı zamanı istisna baş verdi");
            return EmeliyyatNeticesi<string>.Ugursuz("Barkod yaratma əməliyyatı zamanı istisna baş verdi: " + ex.Message);
        }
    }

    public async Task<EmeliyyatNeticesi<List<MehsulDto>>> AxtarAsync(string axtarisMetni, int sayLimit = 100)
    {
        Logger.MelumatYaz($"Məhsul axtarışı başlayır. Axtarış mətni: {axtarisMetni}");
        try
        {
            IEnumerable<Mehsul> butunMehsullar = await _unitOfWork.Mehsullar.AxtarAsync(m => m.Aktivdir);

            if (!string.IsNullOrWhiteSpace(axtarisMetni))
            {
                string axtaris = axtarisMetni.ToLower();
                butunMehsullar = butunMehsullar.Where(m =>
                    m.Ad.ToLower().Contains(axtaris) ||
                    (m.StokKodu != null && m.StokKodu.ToLower().Contains(axtaris)) ||
                    (m.Barkod != null && m.Barkod.Contains(axtaris))
                );
            }

            List<MehsulDto> dtolar = butunMehsullar.Take(sayLimit).Select(m => new MehsulDto
            {
                Id = m.Id,
                Ad = m.Ad,
                Barkod = m.Barkod,
                StokKodu = m.StokKodu,
                AlisQiymeti = m.AlisQiymeti,
                PerakendeSatisQiymeti = m.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = m.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = m.TekEdedSatisQiymeti,
                MovcudSay = m.MovcudSay,
                Aktivdir = m.Aktivdir,
                OlcuVahidi = m.OlcuVahidi,
                AnbarMiqdari = m.MovcudSay,
                OlcuVahidiAdi = m.OlcuVahidi.ToString(),
                KateqoriyaId = m.KateqoriyaId,
                KateqoriyaAdi = m.Kateqoriya?.Ad,
                BrendId = m.BrendId,
                BrendAdi = m.Brend?.Ad,
                TedarukcuId = m.TedarukcuId,
                TedarukcuAdi = m.Tedarukcu?.Ad,
                MinimumStok = m.MinimumStok,
                SekilYolu = m.SekilYolu
            }).ToList();

            return EmeliyyatNeticesi<List<MehsulDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsul axtarışı zamanı istisna baş verdi");
            return EmeliyyatNeticesi<List<MehsulDto>>.Ugursuz("Məhsul axtarışı zamanı istisna baş verdi: " + ex.Message);
        }
    }
```

- [ ] **Step 2: `MehsulManager.cs`-i sil**

```bash
git rm AzAgroPOS.Mentiq/Idareciler/MehsulManager.cs
```

- [ ] **Step 3: Bütün istehlakçı fayllarda `MehsulManager` → `MehsulMeneceri` tipini dəyiş**

Aşağıdakı 15 faylda `MehsulManager` sətirlərini (sahə elanı, konstruktor parametri, DI çağırışı) `MehsulMeneceri` ilə əvəz et — metod adları (`MehsulYaratAsync`, `MehsulYenileAsync`, `MehsulSilAsync`, `ButunMehsullariGetirAsync`, `MehsullariSehifelenmisGetirAsync`) hər iki sinifdə eynidir, ona görə yalnız TİP adı dəyişir, çağırış kodu toxunulmaz qalır:

```
AzAgroPOS.Teqdimat/AlisSifarisFormu.cs
AzAgroPOS.Teqdimat/EhtiyatHissəsiFormu.cs
AzAgroPOS.Teqdimat/AlisSenedFormu.cs
AzAgroPOS.Teqdimat/Teqdimatcilar/TemirPresenter.cs
AzAgroPOS.Teqdimat/BarkodCapiFormu.cs
AzAgroPOS.Teqdimat/MehsulIdareetmeFormu.cs
AzAgroPOS.Teqdimat/Teqdimatcilar/QaytarmaPresenter.cs
AzAgroPOS.Teqdimat/AnaMenuFormu.cs
AzAgroPOS.Teqdimat/Teqdimatcilar/MehsulPresenter.cs
AzAgroPOS.Teqdimat/Teqdimatcilar/SatisPresenter.cs
AzAgroPOS.Teqdimat/Teqdimatcilar/EhtiyatHissəsiPresenter.cs
AzAgroPOS.Teqdimat/Teqdimatcilar/AlisSifarisPresenter.cs
AzAgroPOS.Teqdimat/Teqdimatcilar/AlisSenedPresenter.cs
AzAgroPOS.Teqdimat/Teqdimatcilar/BarkodCapiPresenter.cs
```

Bash ilə mexaniki əvəzetmə (hər faylda `MehsulManager` sözünün bütün keçidləri):

```bash
for f in \
  "AzAgroPOS.Teqdimat/AlisSifarisFormu.cs" \
  "AzAgroPOS.Teqdimat/EhtiyatHissəsiFormu.cs" \
  "AzAgroPOS.Teqdimat/AlisSenedFormu.cs" \
  "AzAgroPOS.Teqdimat/Teqdimatcilar/TemirPresenter.cs" \
  "AzAgroPOS.Teqdimat/BarkodCapiFormu.cs" \
  "AzAgroPOS.Teqdimat/MehsulIdareetmeFormu.cs" \
  "AzAgroPOS.Teqdimat/Teqdimatcilar/QaytarmaPresenter.cs" \
  "AzAgroPOS.Teqdimat/AnaMenuFormu.cs" \
  "AzAgroPOS.Teqdimat/Teqdimatcilar/MehsulPresenter.cs" \
  "AzAgroPOS.Teqdimat/Teqdimatcilar/SatisPresenter.cs" \
  "AzAgroPOS.Teqdimat/Teqdimatcilar/EhtiyatHissəsiPresenter.cs" \
  "AzAgroPOS.Teqdimat/Teqdimatcilar/AlisSifarisPresenter.cs" \
  "AzAgroPOS.Teqdimat/Teqdimatcilar/AlisSenedPresenter.cs" \
  "AzAgroPOS.Teqdimat/Teqdimatcilar/BarkodCapiPresenter.cs" \
; do
  sed -i 's/\bMehsulManager\b/MehsulMeneceri/g' "$f"
done
```

- [ ] **Step 4: `Program.cs`-də DI qeydiyyatını təmizlə**

`AzAgroPOS.Teqdimat/Program.cs:298` sətrini sil:

```csharp
services.AddScoped<MehsulManager>();
```

(`services.AddScoped<MehsulMeneceri>();` sətir 299-da artıq var, saxlanılır.)

- [ ] **Step 5: Build et, xətaları düzəlt**

Run: `dotnet build AzAgroPOS.sln`
Expected: ilk keçiddə mümkün qalıq `MehsulManager` istinadları (məs. dəyişən adları `mehsulManager` — bunlar dəyişməyib, sadəcə TİP dəyişib, kompilyasiya problem yaratmamalıdır) aşkarlanarsa, hər birini `MehsulMeneceri`-yə uyğunlaşdır. 0 xəta ilə bitməlidir.

- [ ] **Step 6: Test faylını köçür**

`AzAgroPOS.Tests/Unit/Managers/MehsulManagerTests.cs`-i `AzAgroPOS.Tests/Unit/Managers/MehsulMeneceriTests.cs` adı ilə yenidən yarat, sinif adını və konstruktor çağırışını dəyiş:

```csharp
// Fayl: AzAgroPOS.Tests/Unit/Managers/MehsulMeneceriTests.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Tests.TestHelpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Linq.Expressions;

namespace AzAgroPOS.Tests.Unit.Managers;

public class MehsulMeneceriTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMehsulRepozitori> _mockMehsulRepo;
    private readonly MehsulMeneceri _mehsulMeneceri;

    public MehsulMeneceriTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMehsulRepo = new Mock<IMehsulRepozitori>();
        _mockUnitOfWork.Setup(x => x.Mehsullar).Returns(_mockMehsulRepo.Object);
        _mehsulMeneceri = new MehsulMeneceri(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task MehsulYaratAsync_ValidMehsul_ReturnsSuccess()
    {
        MehsulDto dto = MehsulMockFactory.CreateValidDto();
        _mockMehsulRepo.Setup(x => x.ElaveEtAsync(It.IsAny<Mehsul>()))
            .Callback<Mehsul>(m => m.Id = 1)
            .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        EmeliyyatNeticesi<int> result = await _mehsulMeneceri.MehsulYaratAsync(dto);

        result.UgurluDur.Should().BeTrue();
        result.Data.Should().BeGreaterThan(0);
        _mockMehsulRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Mehsul>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Once);
    }

    [Fact]
    public async Task MehsulYaratAsync_EmptyAd_ReturnsFailure()
    {
        MehsulDto dto = MehsulMockFactory.CreateValidDto();
        dto.Ad = "";

        EmeliyyatNeticesi<int> result = await _mehsulMeneceri.MehsulYaratAsync(dto);

        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("Məhsul adı boş ola bilməz");
        _mockMehsulRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Mehsul>()), Times.Never);
    }

    [Fact]
    public async Task ButunMehsullariGetirAsync_ReturnsAllMehsullar()
    {
        List<Mehsul> mehsullar = MehsulMockFactory.CreateList(5);
        _mockMehsulRepo.Setup(x => x.ButununuGetirAsync())
            .ReturnsAsync(mehsullar);

        EmeliyyatNeticesi<List<MehsulDto>> result = await _mehsulMeneceri.ButunMehsullariGetirAsync();

        result.UgurluDur.Should().BeTrue();
        result.Data.Should().HaveCount(5);
        _mockMehsulRepo.Verify(x => x.ButununuGetirAsync(), Times.Once);
    }

    [Fact]
    public async Task MehsulSilAsync_ValidId_SoftDeletesSuccessfully()
    {
        Mehsul mehsul = MehsulMockFactory.CreateValid(1);
        _mockMehsulRepo.Setup(x => x.GetirAsync(1))
            .ReturnsAsync(mehsul);
        _mockMehsulRepo.Setup(x => x.Sil(It.IsAny<Mehsul>()))
            .Callback<Mehsul>(m => m.Silinib = true);
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        EmeliyyatNeticesi result = await _mehsulMeneceri.MehsulSilAsync(1);

        result.UgurluDur.Should().BeTrue();
        mehsul.Silinib.Should().BeTrue();
        _mockMehsulRepo.Verify(x => x.Sil(mehsul), Times.Once);
        _mockUnitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Once);
    }

    [Fact]
    public async Task AxtarAsync_ReturnsMatchingMehsullar()
    {
        List<Mehsul> mehsullar = MehsulMockFactory.CreateList(3);
        _mockMehsulRepo.Setup(x => x.AxtarAsync(It.IsAny<Expression<Func<Mehsul, bool>>>(), It.IsAny<Expression<Func<Mehsul, object>>[]>()))
            .ReturnsAsync(mehsullar);

        EmeliyyatNeticesi<List<MehsulDto>> result = await _mehsulMeneceri.AxtarAsync("");

        result.UgurluDur.Should().BeTrue();
        result.Data.Should().HaveCount(3);
    }
}
```

Köhnə `MehsulManagerTests.cs`-i sil:

```bash
git rm AzAgroPOS.Tests/Unit/Managers/MehsulManagerTests.cs
```

(Qeyd: `MehsulYaratAsync_DuplicateStokKodu_ReturnsFailure` testi köçürülmür — `MehsulMeneceri.MehsulYaratAsync` mövcud halda stok-kodu unikallıq yoxlaması etmir, `MehsulManager`-də var idi. Bu davranış fərqi bilərəkdən qorunur — Sub-A əhatəsi yalnız dublikat sinfi birləşdirməkdir, yeni validasiya əlavə etmək deyil. İstəyə görə gələcəkdə əlavə oluna bilər.)

- [ ] **Step 7: Testləri işə sal**

Run: `dotnet test AzAgroPOS.Tests`
Expected: bütün testlər (`MehsulMeneceriTests` daxil) keçir, 0 uğursuzluq.

- [ ] **Step 8: Commit**

```bash
git add -A
git commit -m "refactor: merge MehsulManager into MehsulMeneceri, remove duplicate class"
```

---

### Task 4: `AnaMenuFormu` scope sızmasını düzəlt

**Files:**
- Modify: `AzAgroPOS.Teqdimat/AnaMenuFormu.cs`
- Modify: `AzAgroPOS.Teqdimat/Program.cs`

**Interfeysler:**
- Consumes: mövcud `IServiceProvider ServiceProvider` property (`AnaMenuFormu.cs:23`), mövcud `_tabScopes` dictionary (`AnaMenuFormu.cs:20`).
- Produces: heç bir yeni public interfeys — daxili düzəliş.

- [ ] **Step 1: `CloseTab`-a scope dispose əlavə et, ölü `Deselecting` handler-i sil**

`AzAgroPOS.Teqdimat/AnaMenuFormu.cs:104-133` (`UsaqFormuAc<T>` metodu daxilindəki boş `Deselecting` event handler-i):

Sil:
```csharp
            // Tab bağlananda scope-u dispose edirik
            mdiTabControl.Deselecting += (s, e) =>
            {
                if (e.TabPage != null && _tabScopes.ContainsKey(e.TabPage) && e.Action == TabControlAction.Deselected)
                {
                    // Burada dispose etmirik, yalnız tab remove olunanda edəcəyik
                }
            };

```

`AzAgroPOS.Teqdimat/AnaMenuFormu.cs:208-215` (`CloseTab` metodu):

Əvvəl:
```csharp
    private void CloseTab(TabPage tab)
    {
        if (tab.Controls.Count > 0 && tab.Controls[0] is Form form)
        {
            form.Close();
        }
        mdiTabControl.TabPages.Remove(tab);
    }
```

Sonra:
```csharp
    private void CloseTab(TabPage tab)
    {
        if (tab.Controls.Count > 0 && tab.Controls[0] is Form form)
        {
            form.Close();
        }
        mdiTabControl.TabPages.Remove(tab);

        if (_tabScopes.TryGetValue(tab, out IServiceScope? scope))
        {
            scope.Dispose();
            _tabScopes.Remove(tab);
        }
    }
```

- [ ] **Step 2: Form bağlanarkən (AnaMenuFormu özü bağlananda) qalan bütün scope-ları dispose et**

`AnaMenuFormu` konstruktorunda (`AzAgroPOS.Teqdimat/AnaMenuFormu.cs:29-73`) `FormClosing` event-inə əlavə et — mövcud sətir:

```csharp
        FormClosing += (sender, e) => FormBaglaniyor?.Invoke(this, e);
```

ilə əvəz et:

```csharp
        FormClosing += (sender, e) =>
        {
            foreach (IServiceScope scope in _tabScopes.Values)
            {
                scope.Dispose();
            }
            _tabScopes.Clear();
            FormBaglaniyor?.Invoke(this, e);
        };
```

- [ ] **Step 3: `AnaMenuFormu`-nun scope-lanmamış birbaşa Manager çağırışlarını qısaömürlü scope-a al**

Aşağıdakı 5 yerdə (`ServiceProvider.GetRequiredService<...>()` birbaşa root-dan) `using IServiceScope scope = ServiceProvider.CreateScope();` bloku ilə əhatə et, `ServiceProvider.GetRequiredService` yerinə `scope.ServiceProvider.GetRequiredService` istifadə et:

`AzAgroPOS.Teqdimat/AnaMenuFormu.cs:321` ətrafı (`HesabatManager`):
```csharp
using IServiceScope scope = ServiceProvider.CreateScope();
HesabatManager hesabatManager = scope.ServiceProvider.GetRequiredService<HesabatManager>();
```

`AzAgroPOS.Teqdimat/AnaMenuFormu.cs:347` ətrafı (`NovbeManager`):
```csharp
using IServiceScope scope = ServiceProvider.CreateScope();
NovbeManager novbeManager = scope.ServiceProvider.GetRequiredService<NovbeManager>();
```

`AzAgroPOS.Teqdimat/AnaMenuFormu.cs:368` ətrafı (`MusteriManager`):
```csharp
using IServiceScope scope = ServiceProvider.CreateScope();
MusteriManager musteriManager = scope.ServiceProvider.GetRequiredService<MusteriManager>();
```

`AzAgroPOS.Teqdimat/AnaMenuFormu.cs:416` ətrafı (`MehsulMeneceri`):
```csharp
using IServiceScope scope = ServiceProvider.CreateScope();
MehsulMeneceri mehsulMeneceri = scope.ServiceProvider.GetRequiredService<MehsulMeneceri>();
```

`AzAgroPOS.Teqdimat/AnaMenuFormu.cs:502` və `524` (`NovbeIdareetmesiFormu`) — bu forma `UsaqFormuAc<T>` pattern-indən kənar, ayrıca `using` bloku ilə açılır:

Əvvəl (hər iki yerdə eyni struktur):
```csharp
using (NovbeIdareetmesiFormu form = ServiceProvider.GetRequiredService<NovbeIdareetmesiFormu>())
```

Sonra:
```csharp
using IServiceScope novbeScope = ServiceProvider.CreateScope();
using (NovbeIdareetmesiFormu form = novbeScope.ServiceProvider.GetRequiredService<NovbeIdareetmesiFormu>())
```

(Dəqiq dəyişən adı ətraf koddakı `scope`/`form` adları ilə toqquşmayacaq şəkildə seç — hər iki yerdə eyni metod daxilindədirsə fərqli adlar istifadə et, məsələn `novbeScope1`/`novbeScope2`.)

- [ ] **Step 4: `Microsoft.Extensions.DependencyInjection` using-in mövcudluğunu təsdiqlə**

`AzAgroPOS.Teqdimat/AnaMenuFormu.cs` faylının başında `using Microsoft.Extensions.DependencyInjection;` artıq var (sətir 12) — `IServiceScope`/`CreateScope`/`GetRequiredService` üçün kifayətdir.

- [ ] **Step 5: `Program.RunApplication()`-da Login+AnaMenu resolution-unu scope-a al**

`AzAgroPOS.Teqdimat/Program.cs:118-137`:

Əvvəl:
```csharp
        private static void RunApplication()
        {
            LoginFormu loginFormu = ServiceProvider.GetRequiredService<LoginFormu>();
            TehlukesizlikManager tehlukesizlikManager = ServiceProvider.GetRequiredService<TehlukesizlikManager>();
            IUnitOfWork unitOfWork = ServiceProvider.GetRequiredService<IUnitOfWork>();
            IcazeManager icazeManager = ServiceProvider.GetRequiredService<IcazeManager>();

            using LoginPresenter loginPresenter = new(
                loginFormu, tehlukesizlikManager, unitOfWork, icazeManager, ServiceProvider);

            loginFormu.InitializePresenter(loginPresenter);

            DialogResult dialogResult = loginFormu.ShowDialog();

            if (dialogResult == DialogResult.OK && loginFormu.UgurluDaxilOlundu)
            {
                AnaMenuFormu anaMenuFormu = ServiceProvider.GetRequiredService<AnaMenuFormu>();
                Application.Run(anaMenuFormu);
            }
        }
```

Sonra:
```csharp
        private static void RunApplication()
        {
            using IServiceScope loginScope = ServiceProvider.CreateScope();
            LoginFormu loginFormu = loginScope.ServiceProvider.GetRequiredService<LoginFormu>();
            TehlukesizlikManager tehlukesizlikManager = loginScope.ServiceProvider.GetRequiredService<TehlukesizlikManager>();
            IUnitOfWork unitOfWork = loginScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            IcazeManager icazeManager = loginScope.ServiceProvider.GetRequiredService<IcazeManager>();

            using LoginPresenter loginPresenter = new(
                loginFormu, tehlukesizlikManager, unitOfWork, icazeManager, ServiceProvider);

            loginFormu.InitializePresenter(loginPresenter);

            DialogResult dialogResult = loginFormu.ShowDialog();

            if (dialogResult == DialogResult.OK && loginFormu.UgurluDaxilOlundu)
            {
                using IServiceScope anaMenuScope = ServiceProvider.CreateScope();
                AnaMenuFormu anaMenuFormu = anaMenuScope.ServiceProvider.GetRequiredService<AnaMenuFormu>();
                Application.Run(anaMenuFormu);
            }
        }
```

**Diqqət:** `LoginPresenter`-ə hələ də root `ServiceProvider` ötürülür (`AciqNovbeniYukle`-nin öz scope-u var, `LoginPresenter.cs:96` — bu artıq düzgündür, dəyişməyə ehtiyac yoxdur). `AnaMenuFormu`-nun özü isə indi `anaMenuScope`-dan həll olunur — bu, `AnaMenuFormu` konstruktoruna inject olunan `IServiceProvider serviceProvider` (`AnaMenuFormu.cs:29`) artıq `anaMenuScope.ServiceProvider` olacaq, ona görə Step 3-dəki `ServiceProvider.CreateScope()` çağırışları bu scope-un ALT-scope-ları olacaq (iç-içə scope — EF Core/DI üçün tam dəstəklənir, problem yaratmır).

- [ ] **Step 6: Build et**

Run: `dotnet build AzAgroPOS.sln`
Expected: 0 xəta.

- [ ] **Step 7: Manual smoke test**

Tətbiqi işə sal, login et, Satış/Qaytarma/Məhsul İdarəetmə formalarını aç-bağla (bir neçə dəfə eyni formanı), dashboard-un yeniləndiyini yoxla, növbə aç/bağla. Gözlənilən: heç bir "second operation started on context", "already being tracked" xətası çıxmır, bütün formalar əvvəlki kimi işləyir.

- [ ] **Step 8: Testləri işə sal**

Run: `dotnet test AzAgroPOS.Tests`
Expected: bütün testlər keçir (bu dəyişiklik yalnız Teqdimat qatındadır, Mentiq/Verilenler testlərinə təsir etmir).

- [ ] **Step 9: Commit**

```bash
git add AzAgroPOS.Teqdimat/AnaMenuFormu.cs AzAgroPOS.Teqdimat/Program.cs
git commit -m "fix: dispose IServiceScope on tab close, scope remaining direct manager resolutions in AnaMenuFormu"
```

---

### Task 5: `UnitOfWork.EmeliyyatiTesdiqleAsync`-i özünü tranzaksiyaya sarmaqla təhlükəsizləşdir

**Files:**
- Modify: `AzAgroPOS.Verilenler/Realizasialar/UnitOfWork.cs`
- Test: `AzAgroPOS.Tests/Unit/Repositories/UnitOfWorkTests.cs` (yeni)

**Interfeysler:**
- Consumes: mövcud `_kontekst.Database.CurrentTransaction` (EF Core `DatabaseFacade`), mövcud `ExecuteInTransactionAsync<T>(Func<Task<T>> operation)`.
- Produces: `EmeliyyatiTesdiqleAsync()` public siqnaturası dəyişmir (`Task<int>`), amma daxili davranışı dəyişir — çağıran tərəf üçün şəffaf.

- [ ] **Step 1: `EmeliyyatiTesdiqleAsync`-i private `SaveWithAuditAsync`-ə ayır və şərti tranzaksiyaya sar**

`AzAgroPOS.Verilenler/Realizasialar/UnitOfWork.cs:288-314`:

Əvvəl:
```csharp
    public async Task<int> EmeliyyatiTesdiqleAsync()
    {
        // Əməliyyat jurnalı qeydlərini yaradırıq
        List<EmeliyyatJurnali> auditEntries = OnBeforeSaveChanges();

        // İlk SaveChangesAsync - əsas dəyişiklikləri saxlayır
        int result = await _kontekst.SaveChangesAsync();

        // Əgər audit qeydləri varsa, onları verilənlər bazasına əlavə edirik
        // ChangeTracker.Clear() ilə DbContext-i təmizləyirik ki, concurrency problemi yaranmasın
        if (auditEntries.Any())
        {
            // ChangeTracker-i təmizləyirik - bu, DbContext-in tracking state-ni sıfırlayır
            _kontekst.ChangeTracker.Clear();

            foreach (EmeliyyatJurnali auditEntry in auditEntries)
            {
                // Audit qeydini birbaşa DbSet-ə əlavə edirik
                _kontekst.Set<EmeliyyatJurnali>().Add(auditEntry);
            }

            // İkinci SaveChangesAsync artıq yalnız audit qeydlərini saxlayacaq
            await _kontekst.SaveChangesAsync();
        }

        return result;
    }
```

Sonra:
```csharp
    public async Task<int> EmeliyyatiTesdiqleAsync()
    {
        // Əgər artıq xarici bir tranzaksiya aktivdirsə (məs. çağıran ExecuteInTransactionAsync
        // daxilindədir), onun içində sadəcə save edirik — yenidən tranzaksiya açmırıq
        // (EF Core eyni DbContext üzərində iç-içə BeginTransactionAsync-i dəstəkləmir).
        if (_kontekst.Database.CurrentTransaction != null)
        {
            return await SaveWithAuditAsync();
        }

        // Xarici tranzaksiya yoxdursa (sadə CRUD manager-lər birbaşa çağırır),
        // əsas data + audit save-i öz tranzaksiyamıza sarırıq ki, audit save fail
        // olduqda əsas data da rollback olunsun.
        return await ExecuteInTransactionAsync(SaveWithAuditAsync);
    }

    private async Task<int> SaveWithAuditAsync()
    {
        // Əməliyyat jurnalı qeydlərini yaradırıq
        List<EmeliyyatJurnali> auditEntries = OnBeforeSaveChanges();

        // İlk SaveChangesAsync - əsas dəyişiklikləri saxlayır
        int result = await _kontekst.SaveChangesAsync();

        // Əgər audit qeydləri varsa, onları verilənlər bazasına əlavə edirik
        // ChangeTracker.Clear() ilə DbContext-i təmizləyirik ki, concurrency problemi yaranmasın
        if (auditEntries.Any())
        {
            // ChangeTracker-i təmizləyirik - bu, DbContext-in tracking state-ni sıfırlayır
            _kontekst.ChangeTracker.Clear();

            foreach (EmeliyyatJurnali auditEntry in auditEntries)
            {
                // Audit qeydini birbaşa DbSet-ə əlavə edirik
                _kontekst.Set<EmeliyyatJurnali>().Add(auditEntry);
            }

            // İkinci SaveChangesAsync artıq yalnız audit qeydlərini saxlayacaq
            await _kontekst.SaveChangesAsync();
        }

        return result;
    }
```

- [ ] **Step 2: Build et**

Run: `dotnet build AzAgroPOS.sln`
Expected: 0 xəta.

- [ ] **Step 3: Regression test yaz — `UnitOfWorkTests.cs`**

InMemory provider `ExecuteInTransactionAsync`-dəki `CreateExecutionStrategy()`/retry strategy-ni dəstəkləmir (relational-only), ona görə bu davranış real DbContext əvəzinə **InMemory DbContext + mock-lanmış audit-fail ssenarisi** ilə deyil, birbaşa `OnBeforeSaveChanges`/`SaveChangesAsync` axınının çağırıldığını təsdiqləyən sadə inteqrasiya testi ilə yoxlanılır (`InMemoryDbContextFactory` istifadə edərək):

```csharp
// Fayl: AzAgroPOS.Tests/Unit/Repositories/UnitOfWorkTests.cs

using AzAgroPOS.Tests.TestHelpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

namespace AzAgroPOS.Tests.Unit.Repositories;

public class UnitOfWorkTests
{
    [Fact]
    public async Task EmeliyyatiTesdiqleAsync_AddsEntityAndAuditEntry()
    {
        // InMemory provider CreateExecutionStrategy/transaction-ları dəstəkləmir,
        // ona görə EmeliyyatiTesdiqleAsync-in CurrentTransaction==null yolu InMemory
        // üzərində ExecuteInTransactionAsync-i "no-op transaction" kimi keçəcək
        // (InMemory-nin öz IDbContextTransaction stub-u) — əsas davranış (data+audit save)
        // hər iki halda eyni qalır.
        AzAgroPOSDbContext context = InMemoryDbContextFactory.Create();
        UnitOfWork unitOfWork = new(context);

        Mehsul mehsul = MehsulMockFactory.CreateValid(100);
        await unitOfWork.Mehsullar.ElaveEtAsync(mehsul);

        int result = await unitOfWork.EmeliyyatiTesdiqleAsync();

        result.Should().BeGreaterThan(0);
        Mehsul? saxlanilan = await context.Mehsullar.FindAsync(mehsul.Id);
        saxlanilan.Should().NotBeNull();

        int auditSayi = context.Set<EmeliyyatJurnali>().Count();
        auditSayi.Should().BeGreaterThan(0);

        InMemoryDbContextFactory.Destroy(context);
    }
}
```

- [ ] **Step 4: Test-i işə sal**

Run: `dotnet test AzAgroPOS.Tests --filter UnitOfWorkTests`
Expected: keçir. InMemory provider `Database.CreateExecutionStrategy()`-i dəstəkləmirsə (`InvalidOperationException: The configured execution strategy...`) xətası çıxarsa, `ExecuteInTransactionAsync`-i InMemory-də bypass edən alternativ yol lazımdır — bu halda Step 1-i genişləndir: `_kontekst.Database.IsInMemory()` yoxlaması əlavə et (`Microsoft.EntityFrameworkCore.InMemory` namespace-dən `EF.IsInMemory` yoxdur, `_kontekst.Database.ProviderName` ilə yoxla: `.Contains("InMemory")`), InMemory-də isə `ExecuteInTransactionAsync` çağırmadan birbaşa `SaveWithAuditAsync()` çağır:

```csharp
    public async Task<int> EmeliyyatiTesdiqleAsync()
    {
        if (_kontekst.Database.CurrentTransaction != null || _kontekst.Database.ProviderName?.Contains("InMemory") == true)
        {
            return await SaveWithAuditAsync();
        }

        return await ExecuteInTransactionAsync(SaveWithAuditAsync);
    }
```

(Bu qol yalnız Step 3 InMemory-də faktiki xəta versə aktivləşdirilir — əvvəlcə sınanmadan əlavə edilmir, çünki `UseInMemoryDatabase` real SqlServer execution strategy tələb etməyə bilər və mövcud `SatisManager`/`QaytarmaManager` testləri onsuz da `ExecuteInTransactionAsync`-i mock-lanmış `IUnitOfWork` üzərindən keçir, real DbContext-ə toxunmur.)

- [ ] **Step 5: Bütün test paketini işə sal**

Run: `dotnet test AzAgroPOS.Tests`
Expected: bütün testlər keçir (`SatisManagerTests`, `MehsulMeneceriTests`, yeni `UnitOfWorkTests` daxil).

- [ ] **Step 6: Commit**

```bash
git add AzAgroPOS.Verilenler/Realizasialar/UnitOfWork.cs AzAgroPOS.Tests/Unit/Repositories/UnitOfWorkTests.cs
git commit -m "fix: wrap EmeliyyatiTesdiqleAsync's main+audit save in a transaction when no ambient transaction exists"
```

---

### Task 6: `QaytarmaManager.QaytarmaYaratAsync`-i tranzaksiyaya sar, kassa hərəkəti uğursuzluğunu propagate et

**Files:**
- Modify: `AzAgroPOS.Mentiq/Idareciler/QaytarmaManager.cs`
- Test: `AzAgroPOS.Tests/Unit/Managers/QaytarmaManagerTests.cs` (yeni)

**Interfeysler:**
- Consumes: `IUnitOfWork.ExecuteInTransactionAsync<T>` (mövcud), `MaliyyeManager.KassaHareketiElaveEtAsync` (mövcud siqnatura, dəyişmir).
- Produces: `QaytarmaYaratAsync` public siqnaturası dəyişmir.

- [ ] **Step 1: Metodun gövdəsini `ExecuteInTransactionAsync` bloku daxilinə al, kassa hərəkəti xətasını at**

`AzAgroPOS.Mentiq/Idareciler/QaytarmaManager.cs:47-256` — `SatisManager.SatisYaratAsync`-dakı eyni pattern tətbiq olunur: validasiya (1-3-cü addımlar, sətir 58-98) tranzaksiyadan KƏNARDA qalır (erkən, ucuz uğursuzluq üçün), 4-cü addımdan (qaytarma yaratma) etibarən hər şey `ExecuteInTransactionAsync` daxilinə keçir:

Əvvəl (sətir 100-256, struktur):
```csharp
            // 4. Qaytarma məbləğini hesabla
            decimal umumiMebleg = qaytarilanMehsullar.Sum(m => m.Miqdar * m.VahidinQiymeti);

            // 5. Qaytarma qeydini yarat
            Qaytarma qaytarma = new() { ... };

            await _unitOfWork.Qaytarmalar.ElaveEtAsync(qaytarma);
            await _unitOfWork.EmeliyyatiTesdiqleAsync(); // ID əldə etmək üçün

            // 6. Qaytarma detallarını və stok hərəkətlərini qeydə al
            foreach (...) { ... }

            // 7. Nisyə hesabını düzəlt
            if (...) { ... }

            // 8. Növbə maliyyəsini yenilə
            if (aktivNovbeId.HasValue) { ... }

            // 9. Bütün dəyişiklikləri təsdiqlə
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Qaytarma uğurla yaradıldı: ID={qaytarma.Id}, Məbləğ={umumiMebleg}");
            return EmeliyyatNeticesi<int>.Ugurlu(qaytarma.Id);
```

Sonra (bütün 4-9-cu addımlar `ExecuteInTransactionAsync` daxilinə köçür):
```csharp
            return await _unitOfWork.ExecuteInTransactionAsync(async () =>
            {
                // 4. Qaytarma məbləğini hesabla
                decimal umumiMebleg = qaytarilanMehsullar.Sum(m => m.Miqdar * m.VahidinQiymeti);

                // 5. Qaytarma qeydini yarat
                Qaytarma qaytarma = new()
                {
                    Tarix = DateTime.Now,
                    SatisId = satisId,
                    Sebeb = sebeb,
                    KassirId = kassirId,
                    UmumiMebleg = umumiMebleg
                };

                await _unitOfWork.Qaytarmalar.ElaveEtAsync(qaytarma);
                await _unitOfWork.EmeliyyatiTesdiqleAsync(); // ID əldə etmək üçün

                // 6. Qaytarma detallarını və stok hərəkətlərini qeydə al
                foreach ((int mehsulId, int miqdar, decimal vahidinQiymeti) in qaytarilanMehsullar)
                {
                    QaytarmaDetali detali = new()
                    {
                        QaytarmaId = qaytarma.Id,
                        MehsulId = mehsulId,
                        Miqdar = miqdar,
                        Qiymet = vahidinQiymeti,
                        UmumiMebleg = miqdar * vahidinQiymeti
                    };
                    qaytarma.QaytarmaDetallari.Add(detali);

                    EmeliyyatNeticesi<int> stokNeticesi = await _stokHareketiManager.StokHareketiQeydeAlAsync(
                        StokHareketTipi.Daxilolma,
                        SenedNovu.Qaytarma,
                        qaytarma.Id,
                        mehsulId,
                        miqdar,
                        vahidinQiymeti,
                        vahidinQiymeti,
                        $"Qaytarma: ID={qaytarma.Id}, Səbəb: {sebeb}",
                        kassirId
                    );

                    if (!stokNeticesi.UgurluDur)
                    {
                        Logger.XəbərdarlıqYaz($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                        throw new InvalidOperationException($"Stok hərəkəti qeydə alınarkən xəta: {stokNeticesi.Mesaj}");
                    }
                }

                // 7. Nisyə hesabını düzəlt (əgər satış nisyə idisə)
                if (satis.OdenisMetodu == OdenisMetodu.Nisyə && satis.MusteriId.HasValue)
                {
                    Musteri musteri = await _unitOfWork.Musteriler.GetirAsync(satis.MusteriId.Value);
                    if (musteri != null)
                    {
                        musteri.UmumiBorc -= umumiMebleg;
                        _unitOfWork.Musteriler.Yenile(musteri);

                        NisyeHereketi nisyeHereketi = new()
                        {
                            MusteriId = satis.MusteriId.Value,
                            Mebleg = -umumiMebleg,
                            Tarix = DateTime.Now,
                            EmeliyyatNovu = EmeliyyatNovu.Qaytarma,
                            SatisId = satisId,
                            Qeyd = $"Qaytarma: {sebeb}"
                        };
                        await _unitOfWork.NisyeHereketleri.ElaveEtAsync(nisyeHereketi);

                        Logger.MelumatYaz($"Nisyə hesabı yeniləndi: Müştəri={satis.MusteriId.Value}, Məbləğ={umumiMebleg}");
                    }
                }

                // 8. Növbə maliyyəsini yenilə
                if (aktivNovbeId.HasValue)
                {
                    Novbe novbe = await _unitOfWork.Novbeler.GetirAsync(aktivNovbeId.Value);
                    if (novbe != null)
                    {
                        if (satis.OdenisMetodu == OdenisMetodu.Nağd)
                        {
                            novbe.FaktikiMebleg -= umumiMebleg;
                            Logger.MelumatYaz($"Növbə nağd pulu azaldıldı: {umumiMebleg}");

                            EmeliyyatNeticesi<int> kassaHareketiNetice = await _maliyyeManager.KassaHareketiElaveEtAsync(
                                KassaHareketiNovu.Cixis,
                                EmeliyyatNovu.Qaytarma,
                                emeliyyatId: qaytarma.Id,
                                mebleg: -umumiMebleg,
                                qeyd: $"Qaytarma ödənişinin geri qaytarılması (Nağd): {sebeb}, Satış ID={satisId}",
                                istifadeciId: kassirId
                            );

                            if (!kassaHareketiNetice.UgurluDur)
                            {
                                Logger.XəbərdarlıqYaz($"Kassa hərəkəti qeydiyyatı zamanı xəta: {kassaHareketiNetice.Mesaj}");
                                throw new InvalidOperationException($"Kassa hərəkəti qeydiyyatı zamanı xəta: {kassaHareketiNetice.Mesaj}");
                            }
                        }
                        else if (satis.OdenisMetodu == OdenisMetodu.Kart)
                        {
                            novbe.FaktikiMebleg -= umumiMebleg;
                            Logger.MelumatYaz($"Növbə kart məbləği azaldıldı: {umumiMebleg}");

                            EmeliyyatNeticesi<int> kassaHareketiNetice = await _maliyyeManager.KassaHareketiElaveEtAsync(
                                KassaHareketiNovu.Cixis,
                                EmeliyyatNovu.Qaytarma,
                                emeliyyatId: qaytarma.Id,
                                mebleg: -umumiMebleg,
                                qeyd: $"Qaytarma ödənişinin geri qaytarılması (Kart): {sebeb}, Satış ID={satisId}",
                                istifadeciId: kassirId
                            );

                            if (!kassaHareketiNetice.UgurluDur)
                            {
                                Logger.XəbərdarlıqYaz($"Kassa hərəkəti qeydiyyatı zamanı xəta: {kassaHareketiNetice.Mesaj}");
                                throw new InvalidOperationException($"Kassa hərəkəti qeydiyyatı zamanı xəta: {kassaHareketiNetice.Mesaj}");
                            }
                        }

                        _unitOfWork.Novbeler.Yenile(novbe);
                    }
                }

                // 9. Bütün dəyişiklikləri təsdiqlə
                await _unitOfWork.EmeliyyatiTesdiqleAsync();

                Logger.MelumatYaz($"Qaytarma uğurla yaradıldı: ID={qaytarma.Id}, Məbləğ={umumiMebleg}");
                return EmeliyyatNeticesi<int>.Ugurlu(qaytarma.Id);
            });
```

Diqqət: köhnə kodda hər `try/catch (Exception ex) { Logger.XetaYaz(...); }` bloku kassa hərəkəti ətrafında var idi (sətir 189-208, 218-237) — bu try/catch-lər TAMAMILƏ silinir, belə ki, `KassaHareketiElaveEtAsync`-dən atılan istənilən istisna metodun xarici `catch (Exception ex)` blokuna (sətir 251-254, dəyişməz qalır) qədər yayılıb `ExecuteInTransactionAsync`-in rollback-ini tetikləsin.

- [ ] **Step 2: Build et**

Run: `dotnet build AzAgroPOS.sln`
Expected: 0 xəta.

- [ ] **Step 3: Regression test yaz**

```csharp
// Fayl: AzAgroPOS.Tests/Unit/Managers/QaytarmaManagerTests.cs

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Tests.TestHelpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Tests.Unit.Managers;

public class QaytarmaManagerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<ISatisRepozitori> _mockSatisRepo;
    private readonly Mock<IQaytarmaRepozitori> _mockQaytarmaRepo;
    private readonly Mock<IMehsulRepozitori> _mockMehsulRepo;
    private readonly Mock<IStokHareketiRepozitori> _mockStokHareketiRepo;
    private readonly StokHareketiManager _stokHareketiManager;
    private readonly MaliyyeManager _maliyyeManager;
    private readonly QaytarmaManager _qaytarmaManager;

    public QaytarmaManagerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockSatisRepo = new Mock<ISatisRepozitori>();
        _mockQaytarmaRepo = new Mock<IQaytarmaRepozitori>();
        _mockMehsulRepo = new Mock<IMehsulRepozitori>();
        _mockStokHareketiRepo = new Mock<IStokHareketiRepozitori>();

        _mockUnitOfWork.Setup(x => x.Satislar).Returns(_mockSatisRepo.Object);
        _mockUnitOfWork.Setup(x => x.Qaytarmalar).Returns(_mockQaytarmaRepo.Object);
        _mockUnitOfWork.Setup(x => x.Mehsullar).Returns(_mockMehsulRepo.Object);
        _mockUnitOfWork.Setup(x => x.Musteriler).Returns(new Mock<IMusteriRepozitori>().Object);
        _mockUnitOfWork.Setup(x => x.NisyeHereketleri).Returns(new Mock<INisyeHereketiRepozitori>().Object);
        _mockUnitOfWork.Setup(x => x.Novbeler).Returns(new Mock<INovbeRepozitori>().Object);
        _mockUnitOfWork.Setup(x => x.KassaHareketleri).Returns(new Mock<IKassaHareketiRepozitori>().Object);
        _mockUnitOfWork
            .Setup(x => x.ExecuteInTransactionAsync(It.IsAny<Func<Task<EmeliyyatNeticesi<int>>>>()))
            .Returns<Func<Task<EmeliyyatNeticesi<int>>>>(operation => operation());

        _stokHareketiManager = new StokHareketiManager(_mockUnitOfWork.Object, _mockStokHareketiRepo.Object);
        _maliyyeManager = new MaliyyeManager(_mockUnitOfWork.Object);
        _qaytarmaManager = new QaytarmaManager(_mockUnitOfWork.Object, _stokHareketiManager, _maliyyeManager);
    }

    [Fact]
    public async Task QaytarmaYaratAsync_ExceedingReturnedQuantity_ReturnsFailure()
    {
        Satis satis = new()
        {
            Id = 1,
            OdenisMetodu = OdenisMetodu.Nağd,
            SatisDetallari = new List<SatisDetali>
            {
                new() { MehsulId = 1, Miqdar = 2, Qiymet = 10m }
            }
        };
        _mockSatisRepo.Setup(x => x.GetirAsync(1)).ReturnsAsync(satis);
        _mockQaytarmaRepo.Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Qaytarma, bool>>>(), It.IsAny<System.Linq.Expressions.Expression<Func<Qaytarma, object>>[]>()))
            .ReturnsAsync(new List<Qaytarma>());

        EmeliyyatNeticesi<int> result = await _qaytarmaManager.QaytarmaYaratAsync(
            1,
            new List<(int MehsulId, int Miqdar, decimal VahidinQiymeti)> { (1, 5, 10m) }, // satışda 2 var, 5 istənir
            "Zay",
            kassirId: 1);

        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("maksimum");
        _mockQaytarmaRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Qaytarma>()), Times.Never);
    }

    [Fact]
    public async Task QaytarmaYaratAsync_CashRegisterFailure_ThrowsAndDoesNotReturnSuccess()
    {
        Satis satis = new()
        {
            Id = 1,
            OdenisMetodu = OdenisMetodu.Nağd,
            SatisDetallari = new List<SatisDetali>
            {
                new() { MehsulId = 1, Miqdar = 2, Qiymet = 10m }
            }
        };
        _mockSatisRepo.Setup(x => x.GetirAsync(1)).ReturnsAsync(satis);
        _mockQaytarmaRepo.Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Qaytarma, bool>>>(), It.IsAny<System.Linq.Expressions.Expression<Func<Qaytarma, object>>[]>()))
            .ReturnsAsync(new List<Qaytarma>());
        _mockMehsulRepo.Setup(x => x.GetirAsync(1)).ReturnsAsync(new Mehsul { Id = 1, MovcudSay = 10 });

        Novbe novbe = new() { Id = 1, FaktikiMebleg = 100m };
        _mockUnitOfWork.Setup(x => x.Novbeler).Returns(() =>
        {
            Mock<INovbeRepozitori> mock = new();
            mock.Setup(r => r.GetirAsync(1)).ReturnsAsync(novbe);
            return mock.Object;
        });

        // Kassa hərəkəti hər zaman uğursuz olsun (KassaHareketiElaveEtAsync daxilində istisna atdırmaq
        // əvəzinə, sadə yol: KassaHareketleri.ElaveEtAsync-i istisna atacaq şəkildə mock-la)
        _mockUnitOfWork.Setup(x => x.KassaHareketleri.ElaveEtAsync(It.IsAny<KassaHareketiTarixce>()))
            .ThrowsAsync(new InvalidOperationException("DB xətası"));

        // Act
        EmeliyyatNeticesi<int> result = await _qaytarmaManager.QaytarmaYaratAsync(
            1,
            new List<(int MehsulId, int Miqdar, decimal VahidinQiymeti)> { (1, 1, 10m) },
            "Zay",
            kassirId: 1,
            aktivNovbeId: 1);

        // Assert: kassa hərəkəti fail olduqda bütün əməliyyat uğursuz olmalıdır (əvvəlki davranış:
        // yalnız log yazılıb "uğurlu" qaytarılırdı)
        result.UgurluDur.Should().BeFalse();
    }
}
```

**Qeyd:** `KassaHareketiTarixce` tipi/`KassaHareketleri.ElaveEtAsync` metod imzası `MaliyyeManager.KassaHareketiElaveEtAsync`-in daxilində istifadə etdiyi real entity/repository adı ilə uyğunlaşdırılmalıdır — implementasiya zamanı `AzAgroPOS.Mentiq/Idareciler/MaliyyeManager.cs:445-...`-i oxuyub dəqiq entity tipini (`KassaHareketi` və ya oxşar) və `IKassaHareketiRepozitori`-nin `ElaveEtAsync` metodunun tam imzasını təsdiqlə, testi ona uyğun düzəlt.

- [ ] **Step 4: Testləri işə sal, lazım gələrsə mock setup-ları düzəlt**

Run: `dotnet test AzAgroPOS.Tests --filter QaytarmaManagerTests`
Expected: hər iki test keçir. `KassaHareketiElaveEtAsync`-in daxili strukturuna görə (məsələn əgər o özü də `try/catch` ilə istisnaları udub `Ugursuz` qaytarırsa, `ElaveEtAsync`-i throw etdirmək kifayət deyil) — bu halda test-i `MaliyyeManager.KassaHareketiElaveEtAsync`-in `Ugursuz` NƏTİCƏ qaytardığı ssenari ilə əvəz et (`_mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync()).ThrowsAsync(...)` kimi daha yuxarı səviyyəli mock nöqtəsi də alternativdir).

- [ ] **Step 5: Bütün test paketini işə sal**

Run: `dotnet test AzAgroPOS.Tests`
Expected: bütün testlər keçir.

- [ ] **Step 6: Commit**

```bash
git add AzAgroPOS.Mentiq/Idareciler/QaytarmaManager.cs AzAgroPOS.Tests/Unit/Managers/QaytarmaManagerTests.cs
git commit -m "fix: wrap QaytarmaYaratAsync in ExecuteInTransactionAsync, propagate cash-register failures instead of swallowing them"
```

---

### Task 7: Stok azaltmasını atomic et (overselling qarşısını al)

**Files:**
- Modify: `AzAgroPOS.Verilenler/Interfeysler/IMehsulRepozitori.cs`
- Modify: `AzAgroPOS.Verilenler/Realizasialar/MehsulRepozitori.cs`
- Modify: `AzAgroPOS.Mentiq/Idareciler/StokHareketiManager.cs`
- Modify: `AzAgroPOS.Tests/Unit/Managers/SatisManagerTests.cs` (mövcud 2 test uyğunlaşdırılır)

**Interfeysler:**
- Produces: `IMehsulRepozitori.StoquAtomicAzaltAsync(int mehsulId, int miqdar) : Task<bool>` — `true` = uğurla azaldıldı, `false` = stok kifayət etmədi (0 sətir təsirləndi).
- Consumes: `StokHareketiManager.StokHareketiQeydeAlAsync` bu metodu `Cixis` tipi üçün çağırır.

- [ ] **Step 1: `IMehsulRepozitori`-yə atomic metod əlavə et**

`AzAgroPOS.Verilenler/Interfeysler/IMehsulRepozitori.cs`:

```csharp
// Fayl: AzAgroPOS.Verilenler/Interfeysler/IMehsulRepozitori.cs

using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;

public interface IMehsulRepozitori : IRepozitori<Mehsul>
{
    /// <summary>
    /// Məhsulun stokunu DB səviyyəsində atomic şəkildə azaldır (WHERE MovcudSay >= miqdar).
    /// Paralel satışlarda overselling-in qarşısını almaq üçün read-modify-write əvəzinə istifadə olunur.
    /// </summary>
    /// <returns>true = uğurla azaldıldı; false = stok kifayət etmədi (heç bir sətir təsirlənmədi)</returns>
    Task<bool> StoquAtomicAzaltAsync(int mehsulId, int miqdar);
}
```

- [ ] **Step 2: `MehsulRepozitori`-də implementasiya et**

`AzAgroPOS.Verilenler/Realizasialar/MehsulRepozitori.cs`:

```csharp
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using Microsoft.EntityFrameworkCore;

public class MehsulRepozitori : Repozitori<AzAgroPOS.Varliglar.Mehsul>, IMehsulRepozitori
{
    public MehsulRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
    }

    public async Task<bool> StoquAtomicAzaltAsync(int mehsulId, int miqdar)
    {
        int tesirlenenSetirSayi = await _dbSet
            .Where(m => m.Id == mehsulId && m.MovcudSay >= miqdar)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.MovcudSay, m => m.MovcudSay - miqdar));

        return tesirlenenSetirSayi > 0;
    }
}
```

(`_dbSet` `Repozitori<T>`-də `protected readonly DbSet<T> _dbSet` kimi elan olunub, `MehsulRepozitori`-dən əlçatandır.)

- [ ] **Step 3: `StokHareketiManager.StokHareketiQeydeAlAsync`-da `Cixis` yolunu atomic metoda keçir**

`AzAgroPOS.Mentiq/Idareciler/StokHareketiManager.cs:70-107`:

Əvvəl:
```csharp
            // Məhsulun mövcudluğunu yoxla
            Mehsul mehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulId);
            if (mehsul == null)
            {
                Logger.XəbərdarlıqYaz($"Məhsul tapılmadı: ID={mehsulId}");
                return EmeliyyatNeticesi<int>.Ugursuz("Məhsul tapılmadı.");
            }

            // Yeni stok hərəkəti yarat
            StokHareketi stokHareketi = new()
            {
                HareketTipi = hareketTipi,
                SenedNovu = senedNovu,
                SenedId = senedId,
                MehsulId = mehsulId,
                Miqdar = miqdar,
                AlisQiymeti = alisQiymeti,
                SatisQiymeti = satisQiymeti,
                Tarix = DateTime.Now,
                Qeyd = qeyd,
                IstifadeciId = istifadeciId
            };

            if (hareketTipi == StokHareketTipi.Daxilolma)
            {
                mehsul.MovcudSay += miqdar;
            }
            else if (hareketTipi == StokHareketTipi.Cixis)
            {
                mehsul.MovcudSay -= miqdar;
            }
            _unitOfWork.Mehsullar.Yenile(mehsul);

            await _stokHareketiRepo.ElaveEtAsync(stokHareketi);
            // QEYD: UnitOfWork.Save() çağıran tərəf tərəfindən həyata keçirilməlidir

            Logger.MelumatYaz($"Stok hərəkəti uğurla qeydə alındı: ID={stokHareketi.Id}, Yeni Stok={mehsul.MovcudSay}");
            return EmeliyyatNeticesi<int>.Ugurlu(stokHareketi.Id);
```

Sonra:
```csharp
            // Məhsulun mövcudluğunu yoxla
            Mehsul mehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulId);
            if (mehsul == null)
            {
                Logger.XəbərdarlıqYaz($"Məhsul tapılmadı: ID={mehsulId}");
                return EmeliyyatNeticesi<int>.Ugursuz("Məhsul tapılmadı.");
            }

            if (hareketTipi == StokHareketTipi.Cixis)
            {
                // Atomic decrement: paralel satışlarda overselling-in qarşısını alır
                // (read-modify-write əvəzinə DB səviyyəli WHERE MovcudSay >= miqdar)
                bool azaldildi = await _unitOfWork.Mehsullar.StoquAtomicAzaltAsync(mehsulId, miqdar);
                if (!azaldildi)
                {
                    Logger.XəbərdarlıqYaz($"Stokda kifayət qədər məhsul yoxdur: MəhsulId={mehsulId}, İstənilən={miqdar}");
                    return EmeliyyatNeticesi<int>.Ugursuz("Stokda kifayət qədər məhsul yoxdur.");
                }
            }
            else if (hareketTipi == StokHareketTipi.Daxilolma)
            {
                mehsul.MovcudSay += miqdar;
                _unitOfWork.Mehsullar.Yenile(mehsul);
            }

            // Yeni stok hərəkəti yarat
            StokHareketi stokHareketi = new()
            {
                HareketTipi = hareketTipi,
                SenedNovu = senedNovu,
                SenedId = senedId,
                MehsulId = mehsulId,
                Miqdar = miqdar,
                AlisQiymeti = alisQiymeti,
                SatisQiymeti = satisQiymeti,
                Tarix = DateTime.Now,
                Qeyd = qeyd,
                IstifadeciId = istifadeciId
            };

            await _stokHareketiRepo.ElaveEtAsync(stokHareketi);
            // QEYD: UnitOfWork.Save() çağıran tərəf tərəfindən həyata keçirilməlidir

            Logger.MelumatYaz($"Stok hərəkəti uğurla qeydə alındı: ID={stokHareketi.Id}");
            return EmeliyyatNeticesi<int>.Ugurlu(stokHareketi.Id);
```

**Diqqət:** `StoquAtomicAzaltAsync` `ExecuteUpdateAsync` DB-yə birbaşa yazır (`SaveChangesAsync`-i gözləmir, dərhal icra olunur) — bu, `SatisManager.SatisYaratAsync`-ın xarici `ExecuteInTransactionAsync` bloku daxilində çağırıldığından, eyni ambient tranzaksiyanın bir hissəsi olaraq rollback-ə tabedir (EF Core `ExecuteUpdateAsync` aktiv `Database.CurrentTransaction` daxilində işləyəndə avtomatik onun içinə düşür).

- [ ] **Step 4: Build et**

Run: `dotnet build AzAgroPOS.sln`
Expected: 0 xəta.

- [ ] **Step 5: Mövcud iki testi yeni davranışa uyğunlaşdır**

`AzAgroPOS.Tests/Unit/Managers/SatisManagerTests.cs:159-205` (`StokHareketiQeydeAlAsync_Cixis_DecrementsStock`, `StokHareketiQeydeAlAsync_Daxilolma_IncrementsStock`):

Əvvəl (`Cixis` testi):
```csharp
    [Fact]
    public async Task StokHareketiQeydeAlAsync_Cixis_DecrementsStock()
    {
        // Arrange
        Mehsul mehsul = new() { Id = 1, MovcudSay = 10 };
        _mockMehsulRepo.Setup(x => x.GetirAsync(1)).ReturnsAsync(mehsul);

        // Act
        EmeliyyatNeticesi<int> result = await _stokManager.StokHareketiQeydeAlAsync(
            StokHareketTipi.Cixis,
            SenedNovu.Satis,
            1, // SenedId
            1, // MehsulId
            3, // Miqdar
            5.0m, // AlisQiymeti
            7.0m // SatisQiymeti
        );

        // Assert
        result.UgurluDur.Should().BeTrue();
        mehsul.MovcudSay.Should().Be(7);
        _mockMehsulRepo.Verify(x => x.Yenile(mehsul), Times.Once);
    }
```

Sonra:
```csharp
    [Fact]
    public async Task StokHareketiQeydeAlAsync_Cixis_CallsAtomicDecrement()
    {
        // Arrange
        Mehsul mehsul = new() { Id = 1, MovcudSay = 10 };
        _mockMehsulRepo.Setup(x => x.GetirAsync(1)).ReturnsAsync(mehsul);
        _mockMehsulRepo.Setup(x => x.StoquAtomicAzaltAsync(1, 3)).ReturnsAsync(true);

        // Act
        EmeliyyatNeticesi<int> result = await _stokManager.StokHareketiQeydeAlAsync(
            StokHareketTipi.Cixis,
            SenedNovu.Satis,
            1, // SenedId
            1, // MehsulId
            3, // Miqdar
            5.0m, // AlisQiymeti
            7.0m // SatisQiymeti
        );

        // Assert
        result.UgurluDur.Should().BeTrue();
        _mockMehsulRepo.Verify(x => x.StoquAtomicAzaltAsync(1, 3), Times.Once);
        _mockMehsulRepo.Verify(x => x.Yenile(It.IsAny<Mehsul>()), Times.Never);
    }

    [Fact]
    public async Task StokHareketiQeydeAlAsync_Cixis_InsufficientStock_ReturnsFailure()
    {
        // Arrange
        Mehsul mehsul = new() { Id = 1, MovcudSay = 2 };
        _mockMehsulRepo.Setup(x => x.GetirAsync(1)).ReturnsAsync(mehsul);
        _mockMehsulRepo.Setup(x => x.StoquAtomicAzaltAsync(1, 3)).ReturnsAsync(false);

        // Act
        EmeliyyatNeticesi<int> result = await _stokManager.StokHareketiQeydeAlAsync(
            StokHareketTipi.Cixis,
            SenedNovu.Satis,
            1,
            1,
            3,
            5.0m,
            7.0m
        );

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("kifayət qədər məhsul yoxdur");
    }
```

(`Daxilolma` testi dəyişmir — o yol köhnə read-modify-write pattern-ini saxlayır.)

- [ ] **Step 6: Testləri işə sal**

Run: `dotnet test AzAgroPOS.Tests`
Expected: bütün testlər keçir.

- [ ] **Step 7: Commit**

```bash
git add AzAgroPOS.Verilenler/Interfeysler/IMehsulRepozitori.cs AzAgroPOS.Verilenler/Realizasialar/MehsulRepozitori.cs AzAgroPOS.Mentiq/Idareciler/StokHareketiManager.cs AzAgroPOS.Tests/Unit/Managers/SatisManagerTests.cs
git commit -m "fix: atomic DB-level stock decrement to prevent overselling under concurrent sales"
```

- [ ] **Step 8: Manual paralel-satış yoxlaması (real SQL Server tələb edir, avtomatlaşdırılmır)**

Tətbiqi iki ayrı pəncərədə (və ya iki fərqli maşında/instansda) işə sal, hər ikisində eyni məhsulu (stokda az say olan, məs. `MovcudSay=1`) EYNİ ANDA satmağa çalış. Gözlənilən: yalnız BİR satış uğurlu olur, digəri "Stokda kifayət qədər məhsul yoxdur" mesajı alır, `MovcudSay` mənfiyə düşmür.

---

### Task 8: `SatisManager.QaytarmaEmeliyyatiAsync` ölü dublikat metodunu sil, `UmumiMebleg`-i server-də yenidən hesabla

**Files:**
- Modify: `AzAgroPOS.Mentiq/Idareciler/SatisManager.cs`

**Interfeysler:** Yoxdur — `QaytarmaEmeliyyatiAsync` heç bir çağıran tərəfindən istifadə olunmur (təsdiqlənib: `QaytarmaPresenter.cs:95` yalnız `QaytarmaManager.QaytarmaYaratAsync` çağırır), silinməsi başqa heç nəyə təsir etmir.

- [ ] **Step 1: `QaytarmaEmeliyyatiAsync` metodunu tam sil**

`AzAgroPOS.Mentiq/Idareciler/SatisManager.cs:195-308` (metodun tam gövdəsi, XML-doc şərhi daxil) tamamilə silinir — `SatisGetirAsync` (sətir 131-193) ilə `SatislariSehifelenmisGetirAsync` (sətir 316-350) arasındakı boşluqda heç nə qalmır.

- [ ] **Step 2: `SatisYaratAsync`-da `UmumiMebleg`-i server-də yenidən hesabla**

`AzAgroPOS.Mentiq/Idareciler/SatisManager.cs:63-70`:

Əvvəl:
```csharp
                Satis satis = new()
                {
                    Tarix = System.DateTime.Now,
                    OdenisMetodu = satisDto.OdenisMetodu,
                    UmumiMebleg = satisDto.SebetElementleri.Sum(e => e.UmumiMebleg),
                    NovbeId = satisDto.NovbeId,
                    MusteriId = satisDto.MusteriId
                };
```

Sonra:
```csharp
                Satis satis = new()
                {
                    Tarix = System.DateTime.Now,
                    OdenisMetodu = satisDto.OdenisMetodu,
                    // Client-dən gələn UmumiMebleg-ə etibar edilmir — server-də Miqdar*VahidinQiymeti
                    // əsasında yenidən hesablanır (client manipulyasiyasının qarşısını alır).
                    UmumiMebleg = satisDto.SebetElementleri.Sum(e => e.Miqdar * e.VahidinQiymeti),
                    NovbeId = satisDto.NovbeId,
                    MusteriId = satisDto.MusteriId
                };
```

- [ ] **Step 3: Build et**

Run: `dotnet build AzAgroPOS.sln`
Expected: 0 xəta (istifadə olunmayan `using`-lər varsa təmizlə).

- [ ] **Step 4: Regression test əlavə et — `UmumiMebleg` server-side hesablama**

`AzAgroPOS.Tests/Unit/Managers/SatisManagerTests.cs`-ə əlavə et:

```csharp
    [Fact]
    public async Task SatisYaratAsync_ClientProvidedTotalIgnored_RecalculatesServerSide()
    {
        // Arrange: DTO-da manipulyasiya edilmiş UmumiMebleg (100), amma Miqdar*VahidinQiymeti = 20
        SatisYaratDto dto = SatisMockFactory.CreateValidYaratDto();
        dto.SebetElementleri = new List<SatisSebetiElementiDto>
        {
            new() { MehsulId = 1, Miqdar = 2, VahidinQiymeti = 10m, UmumiMebleg = 100m } // manipulyasiya
        };

        Mehsul mehsul = MehsulMockFactory.CreateValid(1);
        mehsul.MovcudSay = 100;
        _mockMehsulRepo.Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Mehsul, bool>>>()))
            .ReturnsAsync(new List<Mehsul> { mehsul });
        _mockMehsulRepo.Setup(x => x.StoquAtomicAzaltAsync(1, It.IsAny<int>())).ReturnsAsync(true);
        _mockUnitOfWork
            .Setup(x => x.ExecuteInTransactionAsync(It.IsAny<Func<Task<EmeliyyatNeticesi<Satis>>>>()))
            .Returns<Func<Task<EmeliyyatNeticesi<Satis>>>>(operation => operation());
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync()).ReturnsAsync(1);

        // Act
        EmeliyyatNeticesi<Satis> result = await _satisManager.SatisYaratAsync(dto);

        // Assert: 100 yox, 2*10=20 olmalıdır
        result.UgurluDur.Should().BeTrue();
        result.Data.UmumiMebleg.Should().Be(20m);
    }
```

**Qeyd:** Bu test `_mockMehsulRepo.Setup(x => x.AxtarAsync(...))` üçün `SatisManager.SatisYaratAsync:48`-dəki tam siqnaturaya (filter + `Dictionary<int,Mehsul>` çevrilməsi) uyğunlaşdırılmalıdır — implementasiya zamanı mövcud `SatisManagerTests.cs`-dəki digər testlərin (`SatisYaratAsync_InsufficientStock_ReturnsFailure` və s.) hansı mock overload-unu istifadə etdiyini yoxla və eyni pattern-i təkrarla (bu testlər `_mockMehsulRepo.Setup(x => x.GetirAsync(1))` istifadə edir, halbuki `SatisYaratAsync` batch `AxtarAsync` çağırır — Task 7-dən əvvəl bu testlərin necə keçdiyini yoxlamaq üçün `dotnet test --filter SatisManagerTests` nəticəsinə bax, uyğunsuzluq varsa mövcud testlərin özü də bu tapşırıqda düzəldilməlidir).

- [ ] **Step 5: Testləri işə sal, aşkarlanan uyğunsuzluqları düzəlt**

Run: `dotnet test AzAgroPOS.Tests --filter SatisManagerTests`
Expected: bütün `SatisManagerTests` keçir (yeni test daxil). Mock setup-ları real metod siqnaturası ilə uyğun gəlmirsə (`AxtarAsync` vs `GetirAsync`), Step 4-dəki test-i faktiki `SatisManager.SatisYaratAsync` kodundakı (`SatisManager.cs:48`) `_unitOfWork.Mehsullar.AxtarAsync(m => mehsulIdleri.Contains(m.Id))` çağırışına tam uyğun mock et.

- [ ] **Step 6: Bütün test paketini işə sal**

Run: `dotnet test AzAgroPOS.Tests`
Expected: bütün testlər keçir.

- [ ] **Step 7: Commit**

```bash
git add AzAgroPOS.Mentiq/Idareciler/SatisManager.cs AzAgroPOS.Tests/Unit/Managers/SatisManagerTests.cs
git commit -m "fix: remove dead duplicate QaytarmaEmeliyyatiAsync, recompute sale total server-side instead of trusting client"
```

---

### Task 9: Tam regressiya yoxlaması və manual smoke test

**Files:** Yoxdur — yalnız doğrulama.

- [ ] **Step 1: Tam build**

Run: `dotnet build AzAgroPOS.sln --configuration Release`
Expected: 0 xəta, 0 xəbərdarlıq artımı (mövcud xəbərdarlıq sayı ilə müqayisə et).

- [ ] **Step 2: Tam test paketi**

Run: `dotnet test AzAgroPOS.sln`
Expected: bütün testlər (`AzAgroPOS.Tests` layihəsindəki bütün fayllar) keçir.

- [ ] **Step 3: Manual smoke test ssenarisi**

Tətbiqi işə sal və ardıcıl yoxla:
1. Login (admin) — uğurlu giriş, dashboard yüklənir.
2. Yeni növbə aç.
3. Satış Formu aç, məhsul əlavə et, satış tamamla — stok azalır, qəbz göstərilir.
4. Həmin satışı qaytar (Qaytarma Formu) — stok geri artır, nisyə/kassa balansı düzgün yenilənir.
5. Eyni satışı İKİNCİ dəfə tam miqdarda qaytarmağa cəhd et — "maksimum X ədəd qaytarıla bilər" xətası alınmalıdır (artıq-qaytarma qorunması).
6. Məhsul İdarəetmə Formu aç, yeni məhsul yarat/redaktə et/sil — `MehsulMeneceri` üzərindən işləyir.
7. Satış Formunu bağla, yenidən aç (bir neçə dəfə) — heç bir DbContext-related xəta (crash, "already tracking") görünmür.
8. Növbəni bağla.
9. Çıxış et.

Gözlənilən: bütün addımlar xətasız tamamlanır, `Logs/` qovluğunda kritik (`XetaYaz`) səviyyəli gözlənilməz istisna qeydi yoxdur.

- [ ] **Step 4: `.claude`/scratch fayllarını yoxla, sonda ümumi git statusu göstər**

Run: `git status`
Expected: yalnız qəsdən edilmiş dəyişikliklər staged/committed, heç bir təsadüfi fayl qalmayıb.
