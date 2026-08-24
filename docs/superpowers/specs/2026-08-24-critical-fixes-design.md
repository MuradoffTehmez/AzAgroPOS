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

### 2. DbContext ömrü — scope sızması və qismən scope-lanmamış çağırışlar

**Düzəliş: ilkin fərziyyə səhv idi.** Dərin araşdırma göstərdi ki, `AnaMenuFormu.UsaqFormuAc<T>()` (`AnaMenuFormu.cs:94-133`) artıq **hər tab/forma üçün öz `IServiceScope`-unu yaradır** (`ServiceProvider.CreateScope()`, sətir 105) və bu, `_formButtonMap`-dəki bütün formalar (Satış, Qaytarma, Xərc, Təmir, Məhsul/Anbar/Hesabat və s.) üçün işləyir. Real problem daha dardır:

**a) Scope sızması (real bug):** `_tabScopes` dictionary-yə (sətir 20, 120) hər yaradılan scope əlavə olunur, amma `CloseTab` (sətir 208-215) tab bağlananda scope-u heç vaxt `Dispose()` etmir və dictionary-dən silmir. Nəticə: eyni forma tipi bağlanıb-yenidən açıldıqca köhnə scope-lar (və onların DbContext-ləri) heç vaxt sərbəst buraxılmır — real memory/connection leak.

**b) Scope-lanmamış birbaşa çağırışlar:** `AnaMenuFormu`-nun özü bir sıra yerlərdə `UsaqFormuAc<T>()` pattern-ini keçib, root `ServiceProvider`-dən birbaşa Manager həll edir: dashboard yeniləmə (`HesabatManager`, sətir 321), növbə yoxlaması (`NovbeManager`, sətir 347), `MusteriManager` (368), `MehsulMeneceri` (416), və `NovbeIdareetmesiFormu` iki yerdə xüsusi işlədilir (502, 524) — bunlar `UsaqFormuAc` scope-undan kənardadır, root-un default scope-undakı paylaşılan DbContext-i istifadə edir.

**c) `Program.RunApplication()` (`Program.cs:118-137`):** `LoginFormu`, `TehlukesizlikManager`, `IUnitOfWork`, `IcazeManager`, sonra `AnaMenuFormu` özü də root `ServiceProvider`-dən birbaşa həll olunur — aşağı riskli (tək dəfə, qısa ömürlü), amma prinsipial olaraq eyni paylaşılan DbContext-i AnaMenuFormu-nun bütün ömrü boyu "root default scope" kimi saxlayır.

**Həll:**
- `CloseTab`-a scope dispose məntiqini əlavə et: tab bağlananda `_tabScopes`-dan scope-u tap, `Dispose()` et, dictionary-dən sil. (Sətir 122-129-dakı boş `Deselecting` handler də silinir — məqsədi elə bu idi, heç nə etmirdi.)
- `AnaMenuFormu`-nun scope-lanmamış birbaşa çağırışlarını (dashboard, `NovbeManager`, `MusteriManager`, `MehsulMeneceri`, `NovbeIdareetmesiFormu`) hər çağırışda qısaömürlü `using IServiceScope scope = ServiceProvider.CreateScope();` bloku ilə əhatə et.
- `Program.RunApplication()`-da `LoginFormu` və `AnaMenuFormu`-nun özünün həll edilməsini bir `using IServiceScope` bloku daxilinə al.

**Qəbul meyarı:** tab açıb-bağlama dövrü təkrarlandıqda (məsələn 10 dəfə Satış formasını aç/bağla) `_tabScopes.Count` sızmır (hər bağlamada dictionary-dən silinir); `AnaMenuFormu`-nun birbaşa Manager çağırışları öz qısaömürlü scope-undan istifadə edir; mövcud bütün formalar əvvəlki kimi işləyir (manual smoke test: login, satış, məhsul CRUD, qaytarma, dashboard).

### 3. Tranzaksiya bütövlüyü

**Fayl:** `AzAgroPOS.Verilenler/Realizasialar/UnitOfWork.cs:288-314` (`EmeliyyatiTesdiqleAsync`)

**Problem:** Əsas data və audit jurnalı iki ayrı `SaveChangesAsync` çağırışı, vahid tranzaksiyada deyil. Sinif artıq `ExecuteInTransactionAsync` metodunu təmin edir (şərhdə "bütün tranzaksiyalı əməliyyatlar bununla icra olunmalıdır" yazılıb), amma əsas metod ona əməl etmir.

Əlavə: `QaytarmaManager.cs:189-208, 218-237` — kassa hərəkəti (`KassaHareketiElaveEtAsync`) uğursuz olsa belə, yalnız log yazılır, exception atılmır/rollback edilmir → qaytarma "uğurlu" sayılır, kassa balansı ilə tarixçə uyğunsuzlaşır.

**Dəqiqləşdirmə:** `SatisManager.SatisYaratAsync` artıq bütün gövdəsini `_unitOfWork.ExecuteInTransactionAsync(...)` daxilinə alır (`SatisManager.cs:61-122`) — bu hissə üçün əlavə iş lazım deyil. Əsl boşluq `QaytarmaManager.QaytarmaYaratAsync`-dır (`QaytarmaManager.cs:47-256`): bu metod heç bir `ExecuteInTransactionAsync` istifadə etmir, `EmeliyyatiTesdiqleAsync()`-i iki dəfə (sətir 114, 246) ayrı-ayrı avtomatik-commit səviyyəsində çağırır.

**Həll:**
- `QaytarmaManager.QaytarmaYaratAsync`-ın validasiyadan sonrakı əsas gövdəsi `SatisManager`-dəki eyni pattern ilə `_unitOfWork.ExecuteInTransactionAsync(async () => {...})` bloku daxilinə alınır.
- Kassa hərəkəti (`KassaHareketiElaveEtAsync`) uğursuz olanda (`QaytarmaManager.cs:200-203, 229-232`) və ya istisna atanda (`205-208, 234-237`) — hazırda log yazılıb sakitcə davam edilir. Bu, `SatisManager`-in stok-hərəkəti xətası üçün etdiyi kimi `throw new InvalidOperationException(...)` ilə əvəz olunur ki, xarici `ExecuteInTransactionAsync` tranzaksiyanı rollback etsin.
- `UnitOfWork.EmeliyyatiTesdiqleAsync` (`UnitOfWork.cs:288-314`) əlavə təhlükəsizlik qatı kimi: `_kontekst.Database.CurrentTransaction == null` olduqda (yəni çağıran özü artıq `ExecuteInTransactionAsync` daxilində deyilsə — sadə CRUD manager-lər: `MehsulMeneceri`, `MusteriManager` və s.) əsas save + audit save-i öz `ExecuteInTransactionAsync` çağırışına sarır. `CurrentTransaction != null` olduqda (artıq xarici tranzaksiya aktivdirsə) sadəcə mövcud tranzaksiya daxilində save edir, ikinci dəfə tranzaksiya açmır (EF Core nested-transaction xətasının qarşısı alınır).

**Qəbul meyarı:** audit save süni şəkildə fail etdirildikdə (test-də mock ilə, həm sadə manager, həm `ExecuteInTransactionAsync`-daxili yol üçün) əsas data da rollback olunur; kassa hərəkəti fail etdirildikdə bütün qaytarma əməliyyatı uğursuz olur, part-fail qalmır (qaytarma header-i DB-də tək qalmır).

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

**Test qeyd:** `AzAgroPOS.Tests` layihəsi yalnız EF Core **InMemory** provider istifadə edir (`InMemoryDbContextFactory.cs`), o isə `ExecuteUpdateAsync`-i dəstəkləmir. Ona görə atomic decrement `IMehsulRepozitori.StoquAtomicAzaltAsync(int, int)` adlı ayrı interfeys metodu kimi çıxarılır ki, `StokHareketiManager`-in davranışı (uğur/uğursuzluq yolu) Moq ilə saf unit test edilə bilsin. Əsl paralel-tranzaksiya sınağı (iki eyni anlı satış) real SQL Server tələb edir və avtomatlaşdırılmış `dotnet test`-in xaricindədir — bu, tətbiqi iki nüsxə/pəncərədə paralel işə salaraq manual yoxlanılır (qəbul meyarına aşağıda "manual" qeydi ilə əlavə edilib).

**Qəbul meyarı:** `StokHareketiManager.StokHareketiQeydeAlAsync`-in Çıxış yolu `StoquAtomicAzaltAsync` false qaytaranda `BusinessRuleException`/uğursuz nəticə verir (unit test ilə yoxlanılır); `QaytarmaEmeliyyatiAsync` kodda mövcud deyil; eyni malın 2-ci dəfə artıq-qaytarılması rədd edilir (mövcud `QaytarmaManager` testi ilə). **Manual:** tətbiqi iki paralel nüsxədə işə salıb eyni məhsulu eyni anda satmaqla stokun mənfiyə düşmədiyi təsdiqlənir.

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
