# AzAgroPOS — Sub-layihə A: Kritik Düzəliş Dizaynı

**Tarix:** 2026-08-24
**Status:** Təsdiqlənib (chat-da), implementasiya planına keçid gözlənilir
**Əhatə:** Yalnız korrektlik/təhlükəsizlik kritik bugları. Memarlıq refaktoru (God-form bölünməsi, SRP servis ayrılması, strukturlu logging, session timeout, account lockout) bu sub-layihənin əhatəsindən kənardır — gələcək Sub-layihə C.

## Kontekst

Layihə 441 C# fayl, ~55k sətir, qat-qat arxitektura (Varliglar/Verilenler/Mentiq/Teqdimat/Tests). 4 paralel audit (data qatı, biznes məntiq, UI, test/config) və mövcud `Documentation/LAYIHE_ANALIZI.md` + `DUZELME_PLANI.md` (23 fazalı, 30-50 həftəlik plan) bir sıra kritik problem üzə çıxardı. Bu sənəd yalnız **dərhal düzəldilməli** olan alt hissəni əhatə edir.

**Mühit:** Yalnız dev/test, real production datası yoxdur. Repo yalnız lokal, tək istifadəçi — git history rewrite (filter-repo + force-push) sərbəstdir. `dotnet build`/`dotnet test` tam işləyir, DB bağlantısı var.

## Əhatə olunan 5 problem

### 1. Təhlükəsizlik sızıntısı — sabit admin parolu repoda

**Fayllar:**
- `PasswordHasher/GenerateHash.cs`
- `PasswordHasher/ResetAdminPassword.cs`
- `sql scrip/ResetPassword.sql`
- `AzAgroPOSDbContext.cs:781-787` (seed data, sabit BCrypt hash)
- `AzAgroPOS.Teqdimat/appsettings.Development.json`, `appsettings.Production.json`, `appsettings.Staging.json` (git-də tracked, developer maşın adı ifşa olunur)

**Problem:** "admin123" parolu və hazır BCrypt hash-i açıq repoda. Kim bu SQL-i real bazada işlətsə admin/admin123 ilə giriş açılır.

**Həll:**
- Yuxarıdakı 3 fayl (`GenerateHash.cs`, `ResetAdminPassword.cs`, `ResetPassword.sql`) repo-dan silinir.
- `git filter-repo` ilə bu fayllar bütün git tarixçədən təmizlənir (lokal-only repo olduğu üçün təhlükəsiz).
- Seed data-da sabit hash əvəzinə: ilk quraşdırmada təsadüfi parol generasiya edilir (`RandomNumberGenerator` və ya `Guid`), bir dəfə konsola/log-a yazılır, `Istifadeci.MecburiParolDeyisikliyi = true` bayrağı ilə ilk girişdə parol dəyişikliyi məcburi edilir. Bu bayraq `Istifadeci` entity-yə yeni sütun kimi əlavə olunur (kiçik migration).
- `appsettings.Development/Production/Staging.json` `git rm --cached` ilə tracking-dən çıxarılır, `.gitignore`-da mövcud qayda (`appsettings.*.json`) artıq yeni faylları tutur, təsdiqlənir.

**Qəbul meyarı:** repo-da heç bir sabit parol/hash string qalmır; `git log -p -- PasswordHasher/` boş qayıdır; yeni quraşdırmada admin ilk girişdə parol dəyişməyə məcbur olur.

### 2. DbContext ömrü — root provider-dən singleton kimi istifadə

**Fayl:** `AzAgroPOS.Teqdimat/Program.cs:120-134`

**Problem:** Bütün Manager-lər və `IUnitOfWork`/`AzAgroPOSDbContext` `AddScoped` qeydiyyatlıdır, amma `ServiceProvider.GetRequiredService<T>()` birbaşa root provider-dən çağırılır, heç yerdə `CreateScope()` yoxdur. Nəticədə tətbiq ömrü boyu TEK DbContext instansı işləyir (praktikada singleton): ChangeTracker zamanla şişir, paralel async əməliyyatlarda ("second operation started on context") istisna riski yaranır.

**Həll:**
- `IServiceScopeFactory` DI-a inject edilir.
- Hər əsas forma (`AnaMenuFormu`, `SatisFormu`, `LoginFormu` və s.) açılanda `_scopeFactory.CreateScope()` çağırılır, forma bu scope-dan öz Manager instansiyalarını alır.
- Forma bağlananda (`FormClosed`/`Dispose`) scope dispose edilir.
- Presenter-lərdə DbContext ömrü formanın ömrünə bağlanır — WinForms üçün təbii sərhəd.

**Qəbul meyarı:** heç bir yerdə root `ServiceProvider.GetRequiredService<AzAgroPOSDbContext>()` (və ya Manager-lər üçün) birbaşa çağırılmır; hər forma öz scope-unu yaradır və bağlayır; mövcud bütün formalar əvvəlki kimi işləyir (manual smoke test: login, satış, məhsul CRUD, qaytarma).

### 3. Tranzaksiya bütövlüyü

**Fayl:** `AzAgroPOS.Verilenler/Realizasialar/UnitOfWork.cs:288-314` (`EmeliyyatiTesdiqleAsync`)

**Problem:** Əsas data və audit jurnalı iki ayrı `SaveChangesAsync` çağırışı, vahid tranzaksiyada deyil. Sinif artıq `ExecuteInTransactionAsync` metodunu təmin edir (şərhdə "bütün tranzaksiyalı əməliyyatlar bununla icra olunmalıdır" yazılıb), amma əsas metod ona əməl etmir.

Əlavə: `QaytarmaManager.cs:189-208, 218-237` — kassa hərəkəti (`KassaHareketiElaveEtAsync`) uğursuz olsa belə, yalnız log yazılır, exception atılmır/rollback edilmir → qaytarma "uğurlu" sayılır, kassa balansı ilə tarixçə uyğunsuzlaşır.

**Həll:**
- `EmeliyyatiTesdiqleAsync` daxilində əsas data save + audit save `ExecuteInTransactionAsync` bloku daxilinə alınır.
- `QaytarmaManager`-də kassa hərəkəti fail olanda log-dan sonra exception yenidən atılır (və ya `EmeliyyatNeticesi.Ugursuz` qaytarılıb çağıran yerdə tranzaksiya explicit rollback edilir) ki, əsas qaytarma qeydi də DB-yə yazılmasın.

**Qəbul meyarı:** audit save süni şəkildə fail etdirildikdə (test-də mock ilə) əsas data da rollback olunur; kassa hərəkəti fail etdirildikdə qaytarma əməliyyatı bütöv şəkildə uğursuz olur, part-fail qalmır.

### 4. Stok/satış bütövlüyü

**Fayllar:** `SatisManager.cs:47-58,67,198-308,276`, `StokHareketiManager.cs:93-100`, `QaytarmaManager.QaytarmaYaratAsync`

**Problemlər:**
- Stok yoxlaması tranzaksiyadan kənar sadə oxu ilə edilir, sonra decrement heç bir təkrar yoxlama olmadan tətbiq olunur → paralel satışda overselling.
- İki paralel qaytarma implementasiyası: `SatisManager.QaytarmaEmeliyyatiAsync` artıq-qaytarma yoxlaması etmir, `QaytarmaManager.QaytarmaYaratAsync` edir.
- `UmumiMebleg` client-dən gələn cəmə etibar edir, server-də yenidən hesablanmır.
- `NisyeHereketi.SatisId = 0` hardcode.

**Həll:**
- Stok decrement EF Core-un `ExecuteUpdateAsync` ilə atomic edilir: `UPDATE Mehsullar SET MovcudSay = MovcudSay - @miqdar WHERE Id=@id AND MovcudSay >= @miqdar`. Təsirlənən sətir sayı 0-dırsa `BusinessRuleException("Stokda kifayət qədər məhsul yoxdur")` atılır. Bu, #2-dəki DbContext-scope düzəlişindən sonra edilir (eyni scope daxilində atomic update mənalıdır).
- `SatisManager.QaytarmaEmeliyyatiAsync` metodu tamamilə silinir; bütün çağırış yerləri `QaytarmaManager.QaytarmaYaratAsync`-a yönləndirilir.
- `SatisManager.SatisYaratAsync`-da `UmumiMebleg` sərbədə cəmlənmir, hər sətir üçün `Miqdar * VahidinQiymeti` server-də yenidən hesablanıb cəmlənir.
- `SatisManager.cs:276`-da `NisyeHereketi.SatisId = 0` real `satis.Id` ilə əvəz olunur.

**Qəbul meyarı:** iki paralel `dotnet test` thread-i eyni məhsulu eyni anda satmağa çalışanda (yeni regression test) yalnız biri uğurlu olur, stok mənfiyə düşmür; `QaytarmaEmeliyyatiAsync` kodda mövcud deyil; eyni malın 2-ci dəfə artıq-qaytarılması rədd edilir.

### 5. Dublikat manager — MehsulManager vs MehsulMeneceri

**Fayllar:** `AzAgroPOS.Mentiq/Idareciler/MehsulManager.cs` (356 sətir, 16 istifadə yeri), `MehsulMeneceri.cs` (378 sətir, 5 istifadə yeri)

**Araşdırma nəticəsi:** `MehsulMeneceri` daha tamdır — Kateqoriya/Brend/Tədarükçü əlaqələri, `MinimumStok`, `SekilYolu`, stok artır/azalt metodları, `MehsulGetirAsync`, `MinimumStokMehsullariniGetirAsync` var, hazırkı entity schema ilə tam uyğundur. `MehsulManager`-də isə `MehsulMeneceri`-də olmayan yalnız 3 unikal metod var: `StokKoduGeneralasiyaEtAsync`, `BarkodGeneralasiyaEtAsync`, `AxtarAsync`.

**Həll:**
- Bu 3 metod `MehsulMeneceri`-yə köçürülür (məzmun demək olar dəyişmədən, `MehsulMeneceri`-nin adlandırma/DTO konvensiyasına uyğunlaşdırılaraq).
- `MehsulManager.cs` faylı silinir.
- 16 çağırış yeri (`AnaMenuFormu.cs`, `Program.cs`, DI qeydiyyatı və s. daxil) `MehsulMeneceri`-yə yönləndirilir.
- `AzAgroPOS.Tests/Unit/Managers/MehsulManagerTests.cs` — testlər `MehsulMeneceri` üzərinə köçürülür/uyğunlaşdırılır.

**Qəbul meyarı:** `grep -r "MehsulManager" --include=*.cs` (sinif adı kimi) heç nə tapmır; bütün əvvəlki `MehsulManager` çağırış nöqtələri compile olur və `MehsulMeneceri` ilə işləyir; mövcud testlər keçir.

## İcra sırası

1. **#1 Təhlükəsizlik** — təcrid olunmuş, ən az risklidir, faylları silmək digər dəyişikliklərdən asılı deyil.
2. **#5 Dublikat manager** — təcrid olunmuş, digər düzəlişlərdən asılı deyil, sadə mexaniki iş.
3. **#2 DbContext scope** — infrastruktur dəyişikliyi, #3 və #4-ün düzgün işləməsi üçün əsasdır (transaction/atomic update eyni scope daxilində mənalıdır).
4. **#3 Tranzaksiya bütövlüyü** — #2-dən sonra.
5. **#4 Stok/satış bütövlüyü** — ən riskli, #2-dən (DbContext scope) asılıdır, ən son edilir.

Hər addımdan sonra `dotnet build` + `dotnet test` işə salınır, manual smoke test (login → satış → qaytarma → məhsul CRUD) həyata keçirilir.

## Əhatə xaricində (Sub-layihə B/C-yə saxlanılır)

- Test coverage artırılması (Satış/Qaytarma/Stok/Maliyyə/Nisyə manager-ləri üçün geniş unit test dəsti) — Sub-layihə B.
- God-form bölünməsi (`SatisFormu` 1080 sətir, `AnaMenuFormu` 682 sətir), SRP üzrə servis ayrılması (Stock/Credit/Loyalty/Receipt Service), strukturlu (JSON) logging, session timeout, account lockout, şifrə mürəkkəblik tələbləri, `IcazeYoxlayici` singleton-un DI-a keçirilməsi, `OperationExecutor` ilə kod təkrarının aradan qaldırılması — Sub-layihə C.
- `Repozitori.cs` full-scan `ChangeTracker.Entries().FirstOrDefault` optimallaşdırması, pagination Count/Skip-Take race — kiçik performans, kritik deyil.
