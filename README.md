# AzAgroPOS 🗞
**Versiya:** 1.0 
**Tətbiq Növü:** Windows Forms əsaslı Satış və Anbar İdarəetmə Sistemi  
**Hazırlayan:** Təhməz Muradov  
**Tarix:** 2025-07-08  

---

## 📌 Layihənin Təsviri
**AzAgroPOS** – kənd təsərrüfatı və kiçik müəssisələr üçün hazırlanmış bir **POS (Point of Sale)** və **Əməliyyat İdarəetmə Sistemi**dir. Tətbiq satış, alış, təmir, nisyə ticarət, borc idarəsi, müştəri əlaqələri, stok idarəsi və qəbz/faktura çapı daxil olmaqla bir sıra funksiyaları özündə birləşdirir.

Layihə, istifadəçi dostu interfeysə, güclü verilənlər bazasına və genifləndirilə bilən struktur dizayna sahibdir.

---

## ⚙️ Texnologiyalar

| Komponent        | Texnologiya                     |
|------------------|----------------------------------|
| Proqramlaşdırma  | C# (.NET Framework 4.8)         |
| UI Platforması   | Windows Forms                   |
| Verilənlər Bazası| Microsoft SQL Server 2019+      |
| ORM Layer        | ADO.NET (Entity Framework optional) |
| Barkod Kitabxanası | ZXing.NET, BarCodeLib         |
| Çap Sistemi      | RawPrinterHelper, Zebra ZPL     |
| Şifrələmə        | SHA-256 və ya bcrypt            |

---

## 🧱 Qovluq Strukturu

```plaintext
AzAgroPOS.sln
│
├── AzAgroPOS.PL              → Tətbiqin əsas UI (WinForms) hissəsi
│   ├── Forms                 → Bütün formalar: Satış, Məhsul, Tədarük, Təmir və s.
│   ├── Controls              → İstifadə olunan custom control-lar
│   ├── Themes                → Qaranlıq/açıq tema faylları və rəng konfiqurasiyaları
│   └── Resources             → Icon, şəkil, .resx faylları
│
├── AzAgroPOS.BLL             → Business Logic Layer (iş məntiqi)
│   ├── Services              → Satış, Məhsul, Borc və s. üçün servis sinifləri
│   ├── Interfaces            → BLL interfeysləri (test və genişlənmə məqsədli)
│   └── Validators            → Giriş məlumatlarını yoxlayan siniflər (validation)
│
├── AzAgroPOS.DAL             → Data Access Layer (məlumat bazası əlaqələri)
│   ├── Repositories          → CRUD əməliyyatlarını icra edən siniflər
│   ├── Interfaces            → Repository interfeysləri
│   └── DbConnection          → SQL bağlantısı və connection string idarəsi
│
├── AzAgroPOS.Entities        → Data model-lər (verilənlər strukturu)
│   ├── DTO                   → Data Transfer Object-lər (Form → BLL → DAL arası)
│   └── Domain                → Əsas model sinifləri (Mehsul, Musteri, Satis və s.)
│
├── AzAgroPOS.Tests           → Test layihəsi (Unit və Integration testlər)
│   ├── BLL.Tests             → Xidmət siniflərinin testləri
│   ├── DAL.Tests             → Verilənlər bazası əməliyyatlarının testləri
│   └── MockData              → Test üçün nümunə məlumatlar və fake obyektlər
│
├── AzAgroPOS.DB              → SQL Scripts, backup və database sənədləri
│   ├── Tables.sql            → CREATE TABLE skriptləri
│   ├── Views.sql             → CREATE VIEW skriptləri
│   ├── Triggers.sql          → CREATE TRIGGER skriptləri
│   ├── Procedures.sql        → Stored Procedure-lər
│   └── SeedData.sql          → İlkin məlumatlar (admin hesabı, nümunə məhsul və s.)
│
└── README.md                 → Layihənin sənədi, quraşdırma və texniki qeydlər

```

---

## 📦 Quraşdırma Təlimatı

### 1. Əvvəlcədən Şərtlər
- Visual Studio 2019 və ya 2022
- .NET Framework 4.8 Developer Pack
- Microsoft SQL Server 2019 və ya daha yeni
- SQL Server Management Studio (SSMS)

### 2. Verilənlər Bazasının Yaradılması
1. `AzAgroPOS.DB/Tables.sql` faylını SSMS üzərindən icra edin.
2. `Views.sql`, `Triggers.sql` və `SeedData.sql` fayllarını ardıcıllıqla icra edin.
3. `AzAgroPOS_DB` adlı bir verilənlər bazası yaradılmış olacaq.

### 3. Config Dəyişiklikləri
`App.config` və ya `DbConnection/Config.cs` faylında bağlantı sətrinizi dəyişdirin:

```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Server=localhost;Database=AzAgroPOS_DB;Trusted_Connection=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. Layihənin İcrası
Visual Studio üzərindən `AzAgroPOS.sln` faylını açın və başlanğıc layihə kimi `AzAgroPOS.PL` secin. `F5` ilə proqramı başladın.

---

## 📃 Ə sas Modullar

- **İstifadəçi və Rol İdarəetməsi** – Giriş, icazələr, tema və audit sistemi
- **Məhsul və Kataloq İdarəetməsi** – Barkodlu məhsul əlavəetmə, kateqoriya və ölçü vahidləri
- **Tədarük və Alış Sistemi** – Alış əməliyyatları və stok artırma
- **Anbar İzləmə** – Giriş/çıxış tarixçəsi və balans
- **Satış Sistemi** – Barkodla satış, endirim, çaplı qəbz
- **Borc və Nisyə Modulu** – Avtomatik borc qeydləri və ödənişlər
- **Təmir və Servis** – Cihaz qəbulu, texnik təyin edilməsi və hesabat
- **Çap və Qəbz Sistemi** – Zebra printer və JSON əsaslı dizayn sablonları

---

## 🧲 Çek və Faktura Adlandırma Sistemi

| Sənəd Növü | Format | Açıqlama |
|------------|--------|----------|
| Satış Qəbzi | `SATIS-YYYYMMDD-0000001` | Pərakəndə satışın təsdiqi |
| Borc Qəbzi | `BORC-YYYYMMDD-0000001` | Nisyə satışın qeydiyyatı |
| Ödəniş Qəbzi | `BORCODE-YYYYMMDD-0000001` | Borc üzrə edilən ödəniş |
| Geri Qaytarma | `QAYTARMA-YYYYMMDD-0000001` | Müştəri qaytarması |
| Satış Fakturası | `F-SATIS-YYYYMM-000001` | Rəsmi satış sənədi |
| Alış Fakturası | `F-ALIS-YYYYMM-000001` | Tədarükçü alışları üçün |
| Xidmət Aktı | `XIDMET-AKT-YYYYMM-000001` | Təmir və xidmət təsdiqi |

---

## 🛡️ Təhlükəsizlik və Audit

- **Soft Delete:** Məlumat silinmir, `IsDeleted = 1` ilə arxivlənir.
- **Audit Trail:** Bütün əməliyyatlar `AuditLog` cədvəlində qeyd olunur.
- **Rol əsasında giriş:** İcazələr `RolIcazesi` və `Modul + Ə məliyyat` əsasında təyin edilir.
- **Parol təhlükəsizliyi:** SHA-256 və ya bcrypt alqoritmi

---

## 🔮 Test Mühiti və Məlumatları

Testlər üçün `AzAgroPOS.Tests` layihəsində:
- Servis metod testləri (`BLL.Tests`)
- Saxta məlumatlar (`MockData`)
- Test edilə bilən `Unit of Work` strukturu

---

## 📄 Lisenziya

Bu layihə yalnız **MuradovCode** daxili istifadə və sifariş əsasında hazırlanmış layihədir. İcazəsiz istifadə və ya yayım hüquqi məsuliyyət doğura bilər.

---

## 📞 Əlaqə

**Təhməz Muradov**  
**Email:** muradofftehmez01@gmail.com  
**Mobil:** +994 51 871 74 83  
**Şirkət:** MuradovCode  
**Məkan:** Naxçıvan, Azərbaycan

---
