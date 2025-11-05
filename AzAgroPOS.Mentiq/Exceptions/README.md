# Custom Exception Hierarchy - İstifadə Təlimatı

## 📋 Ümumi Baxış

Bu qovluqda AzAgroPOS layihəsi üçün custom exception class-ları yerləşir. Bu exception-lar generic `catch (Exception ex)` əvəzinə daha spesifik xəta idarəetməsi təmin edir.

## 🎯 Exception Növləri

### 1. **BusinessRuleException**
Business rule pozulduqda istifadə olunur.

**Nə zaman istifadə olunur:**
- Stokda kifayət qədər məhsul yoxdur
- Kredit limiti keçilir
- Minimum sifariş məbləği qarşılanmır
- və s.

**Nümunə:**
```csharp
if (mehsul.MovcudSay < sifarisEdilmisMiqdar)
{
    throw new BusinessRuleException(
        $"Stokda kifayət qədər məhsul yoxdur. Mövcud: {mehsul.MovcudSay}, Tələb olunan: {sifarisEdilmisMiqdar}",
        "INSUFFICIENT_STOCK",
        new Dictionary<string, object>
        {
            { "MehsulId", mehsul.Id },
            { "MovcudSay", mehsul.MovcudSay },
            { "TelebOlunanMiqdar", sifarisEdilmisMiqdar }
        });
}
```

---

### 2. **ValidationException**
Məlumat validation xətası baş verdikdə istifadə olunur.

**Nə zaman istifadə olunur:**
- Required field-lər boşdur
- Format düzgün deyil (email, telefon, və s.)
- Uzunluq məhdudiyyəti pozulur
- və s.

**Nümunə:**
```csharp
var errors = new Dictionary<string, string>();

if (string.IsNullOrWhiteSpace(dto.Ad))
{
    errors.Add("Ad", "Məhsul adı mütləq daxil edilməlidir");
}

if (dto.PerakendeSatisQiymeti <= 0)
{
    errors.Add("PerakendeSatisQiymeti", "Satış qiyməti 0-dan böyük olmalıdır");
}

if (errors.Any())
{
    throw new ValidationException(errors);
}

// Və ya tək bir xəta üçün:
if (string.IsNullOrWhiteSpace(dto.Ad))
{
    throw new ValidationException("Ad", "Məhsul adı mütləq daxil edilməlidir");
}
```

---

### 3. **DataNotFoundException**
Axtarılan məlumat tapılmadıqda istifadə olunur.

**Nə zaman istifadə olunur:**
- ID-yə görə entity tapılmadı
- Axtarış nəticəsiz qaldı
- Foreign key relation mövcud deyil
- və s.

**Nümunə:**
```csharp
var mehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulId);

if (mehsul == null)
{
    throw new DataNotFoundException("Məhsul", mehsulId);
}

// Və ya custom mesaj ilə:
if (musteri == null)
{
    throw new DataNotFoundException($"ID {musteriId} ilə müştəri tapılmadı");
}
```

---

### 4. **DatabaseException**
Database əməliyyatları zamanı xəta baş verdikdə istifadə olunur.

**Nə zaman istifadə olunur:**
- DbUpdateException baş verdi
- UNIQUE constraint pozuldu
- FOREIGN KEY constraint pozuldu
- Connection string xətası
- və s.

**Nümunə:**
```csharp
try
{
    await _unitOfWork.TamamlaAsync();
}
catch (DbUpdateException ex)
{
    throw DatabaseException.FromDbUpdateException(ex);
}

// Və ya custom mesaj ilə:
catch (SqlException ex)
{
    throw new DatabaseException(
        "Verilənlər bazası ilə əlaqə kəsildi",
        "Query",
        ex);
}
```

---

### 5. **AuthorizationException**
İcazə problemi olduqda istifadə olunur.

**Nə zaman istifadə olunur:**
- İstifadəçi bu əməliyyatı etmək hüququna malik deyil
- Rol tələb olunur amma mövcud deyil
- Permission check fail oldu
- və s.

**Nümunə:**
```csharp
if (AktivSessiya.AktivIstifadeci?.Rol?.Ad != "Admin")
{
    throw new AuthorizationException(
        "Məhsul Silmə",
        "Admin",
        AktivSessiya.AktivIstifadeci?.Rol?.Ad ?? "Qonaq");
}

// Və ya sadə:
if (!IsAuthorized(currentUser, "DELETE_PRODUCT"))
{
    throw new AuthorizationException("Bu əməliyyatı yerinə yetirmək üçün icazəniz yoxdur");
}
```

---

## 🔧 Manager-lərdə İstifadə Nümunəsi

### Əvvəl (Generic Exception):
```csharp
public async Task<EmeliyyatNeticesi<int>> MehsulYaratAsync(MehsulDto dto)
{
    try
    {
        // Validation
        if (string.IsNullOrWhiteSpace(dto.Ad))
            return EmeliyyatNeticesi<int>.Ugursuz("Məhsul adı boş ola bilməz");

        // Business logic
        var mehsul = new Mehsul { Ad = dto.Ad };
        await _unitOfWork.Mehsullar.ElaveEtAsync(mehsul);
        await _unitOfWork.TamamlaAsync();

        return EmeliyyatNeticesi<int>.Ugurlu(mehsul.Id);
    }
    catch (Exception ex)  // ❌ Generic catch
    {
        Logger.XetaYaz(ex, "Xəta");
        return EmeliyyatNeticesi<int>.Ugursuz(ex.Message);
    }
}
```

### İndi (Custom Exceptions):
```csharp
public async Task<EmeliyyatNeticesi<int>> MehsulYaratAsync(MehsulDto dto)
{
    try
    {
        // Validation
        var errors = new Dictionary<string, string>();

        if (string.IsNullOrWhiteSpace(dto.Ad))
            errors.Add("Ad", "Məhsul adı mütləq daxil edilməlidir");

        if (dto.PerakendeSatisQiymeti <= 0)
            errors.Add("PerakendeSatisQiymeti", "Satış qiyməti 0-dan böyük olmalıdır");

        if (errors.Any())
            throw new ValidationException(errors);

        // Unikal yoxlama
        var movcud = (await _unitOfWork.Mehsullar
            .AxtarAsync(m => m.StokKodu == dto.StokKodu))
            .FirstOrDefault();

        if (movcud != null)
        {
            throw new BusinessRuleException(
                $"'{dto.StokKodu}' stok kodlu məhsul artıq mövcuddur",
                "DUPLICATE_STOCK_CODE");
        }

        // Business logic
        var mehsul = new Mehsul { Ad = dto.Ad, StokKodu = dto.StokKodu };
        await _unitOfWork.Mehsullar.ElaveEtAsync(mehsul);
        await _unitOfWork.TamamlaAsync();

        return EmeliyyatNeticesi<int>.Ugurlu(mehsul.Id);
    }
    catch (ValidationException ex)
    {
        Logger.XeberdarligYaz($"Validation xətası: {ex.Message}");
        return EmeliyyatNeticesi<int>.Ugursuz(
            "Məlumat validation xətası",
            ex.Errors);
    }
    catch (BusinessRuleException ex)
    {
        Logger.XeberdarligYaz($"Business rule pozuldu: {ex.Message}");
        return EmeliyyatNeticesi<int>.Ugursuz(ex.Message);
    }
    catch (DbUpdateException ex)
    {
        Logger.XetaYaz(ex, "Database xətası");
        var dbEx = DatabaseException.FromDbUpdateException(ex);
        return EmeliyyatNeticesi<int>.Ugursuz(dbEx.Message);
    }
    // OutOfMemoryException və s. tutulmasın - proqram crash etsin
}
```

---

## 📊 Exception Hierarchy

```
Exception (System)
├── BusinessRuleException
│   ├── RuleCode
│   └── AdditionalData
├── ValidationException
│   └── Errors (Dictionary)
├── DataNotFoundException
│   ├── EntityName
│   └── EntityId
├── DatabaseException
│   ├── OperationType
│   └── TableName
└── AuthorizationException
    ├── RequiredRole
    ├── CurrentRole
    └── OperationName
```

---

## ✅ Faydaları

1. **Daha yaxşı debug** - Hansı növ xəta olduğu bilinir
2. **Spesifik handling** - Hər exception növü üçün fərqli handle
3. **Test edilə bilən** - Specific exception-lar test etmək asandır
4. **Logging** - Structured logging üçün əlavə məlumat
5. **User-friendly mesajlar** - Hər exception növü üçün uyğun mesaj

---

## 🚫 Tutulmamalı Exception-lar

Bu exception-lar catch edilməməlidir (proqram crash etməlidir):
- `OutOfMemoryException`
- `StackOverflowException`
- `ThreadAbortException`
- `AccessViolationException`

---

## 📝 Migration Plan

**53 faylda** generic `catch (Exception ex)` istifadə olunur. Bunlar aşağıdakı ardıcıllıqla yenilənməlidir:

### Faza 1: Core Modules (1 həftə)
1. MehsulManager
2. SatisManager
3. MusteriManager
4. TedarukcuManager
5. KassaHereketiManager

### Faza 2: Supporting Modules (1 həftə)
6. IsciManager
7. NovbeManager
8. XercManager
9. BonusManager
10. EmekHaqqiManager

### Faza 3: Remaining Modules (1 həftə)
11-53. Qalan bütün Manager-lər

---

**Yaradılma tarixi:** 2025-01-05
**Son yeniləmə:** 2025-01-05
**Müəllif:** AzAgroPOS Development Team
