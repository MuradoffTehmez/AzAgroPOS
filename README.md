# AzAgroPOS - Kənd Təsərrüfatı Satış Nöqtəsi Sistemi

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12-239120?style=for-the-badge&logo=c-sharp)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![Windows](https://img.shields.io/badge/Windows-10%2F11-0078D6?style=for-the-badge&logo=windows)
![License](https://img.shields.io/badge/License-Proprietary-red?style=for-the-badge)

**Modern, Təhlükəsiz və Tam Funksional POS Sistemi**

[Xüsusiyyətlər](#-xüsusiyyətlər) • [Quraşdırma](#-quraşdirma) • [İstifadə](#-istifadə) • [Arxitektura](#-arxitektura) • [Sənədləşdirmə](#-sənədləşdirmə)

</div>

---?

## 📚 Sənədləşdirmə

**[📖 Texniki Sənədləşdirmə və Form Analizi →](Documentation/README.md)**

Layihənin tam texniki sənədləşdirməsi, form analizi və kod quality hesabatları üçün `Documentation` qovluğuna baxın.

---

## 🎯 Layihə Haqqında

AzAgroPOS kənd təsərrüfatı və pərakəndə satış mağazaları üçün hazırlanmış müasir, tam funksional Point of Sale (POS) sistemidir. .NET 8.0 və Material Design prinsipi ilə hazırlanmış bu sistem satış, anbar, maliyyə və insan resursları idarəetməsini vahid platformada birləşdirir.

### 🌟 Əsas Xüsusiyyətlər

- ✅ **Tam Azərbaycan dilində** yerelleşdirilmiş interfeys
- ✅ **Modern UI/UX** - Material Design komponentləri
- ✅ **Təhlükəsizlik** - BCrypt şifrələmə, rol əsaslı icazələr, audit trail
- ✅ **Yüksək Performans** - 50+ verilənlər bazası indexi, async əməliyyatlar
- ✅ **Geniş Funksionallıq** - Satış, anbar, maliyyə, HR, təmir idarəetməsi
- ✅ **Hesabat Sistemi** - Excel ixrac, Z-hesabat, mənfəət-zərər analizi
- ✅ **Bonus Proqramı** - Müştəri loyallıq sistemi
- ✅ **Nisyə İdarəetməsi** - Borc izləmə və idarəetmə

---

## 📊 Texniki Məlumatlar

### Texnologiya Stack

| Komponent | Texnologiya | Versiya |
|-----------|-------------|---------|
| **Framework** | .NET | 8.0 |
| **Dil** | C# | 12 |
| **ORM** | Entity Framework Core | 9.0.8 |
| **Verilənlər Bazası** | Microsoft SQL Server | 2019+ |
| **UI Framework** | Windows Forms + MaterialSkin.2 | 2.3.1 |
| **Logging** | Serilog | 4.3.0 |
| **Şifrələmə** | BCrypt.Net-Next | 4.0.3 |
| **Excel** | EPPlus | 8.1.0 |
| **DI Container** | Microsoft.Extensions.DependencyInjection | 9.0.8 |

### Layihə Statistikası

```
📁 Proyekt Sayı:        7
📄 Kod Sətirləri:       50,000+
🗃️ Entity Sayı:         53
💼 Manager Sayı:        21
🖥️ Form Sayı:           30+
🗄️ DB Cədvəlləri:       34
🔀 Migration Sayı:      25+
📊 Index Sayı:          50+
📦 DTO Sayı:            35+
```

---

## 🏗️ Layihə Strukturu

```
AzAgroPOS/
│
├── 📁 AzAgroPOS.Varliglar/              # Entity Layer (Domain Models)
│   ├── Core Entities (Mehsul, Musteri, Istifadeci, Isci)
│   ├── Sales Entities (Satis, Qaytarma, NisyeHereketi)
│   ├── Inventory Entities (StokHareketi, Kateqoriya, Brend)
│   ├── Financial Entities (KassaHareketi, Xerc, EmekHaqqi)
│   ├── Purchase Entities (Tedarukcu, AlisSifaris, AlisSened)
│   └── Enums (15+ enumeration)
│
├── 📁 AzAgroPOS.Verilenler/              # Data Access Layer
│   ├── Kontekst/
│   │   └── AzAgroPOSDbContext.cs        # Main DbContext (873 lines)
│   ├── Realizasialar/                   # Repository Implementations
│   │   └── 20+ Repository classes
│   ├── Interfeysler/                    # Repository Interfaces
│   └── Migrations/                      # EF Core Migrations (25+)
│
├── 📁 AzAgroPOS.Mentiq/                  # Business Logic Layer
│   ├── Idareciler/                      # Managers (21 managers)
│   │   ├── SatisManager.cs
│   │   ├── MehsulManager.cs
│   │   ├── IstifadeciManager.cs
│   │   ├── TehlukesizlikManager.cs
│   │   └── ...
│   ├── DTOs/                            # Data Transfer Objects (35+)
│   ├── Istisnalar/                      # Custom Exceptions
│   └── Yardimcilar/                     # Helpers & Utilities
│
├── 📁 AzAgroPOS.Teqdimat/                # Presentation Layer
│   ├── Forms (30+ Windows Forms)
│   │   ├── LoginFormu.cs
│   │   ├── AnaMenuFormu.cs
│   │   ├── SatisFormu.cs
│   │   └── ...
│   ├── Teqdimatcilar/                   # Presenters (MVP Pattern)
│   ├── Interfeysler/                    # View Interfaces
│   ├── Konfigurasiya/                   # Configuration
│   └── Xidmetler/                       # Services
│
├── 📁 AzAgroPOS.Tests/                   # Test Project
├── 📁 DatabaseTestApp/                   # DB Connection Tester
├── 📁 PasswordHasher/                    # Password Hashing Utility
├── 📁 Documentation/                     # Project Documentation
│   ├── README.md
│   ├── 00_START_HERE.md
│   ├── FormAnalysis_Report.md
│   └── ...
│
└── 📄 README.md                          # This file
```

---

## 🚀 Quraşdırma

### Sistem Tələbləri

#### Minimum Tələblər
- **OS:** Windows 10 (64-bit)
- **RAM:** 4 GB
- **Disk:** 500 MB boş yer
- **.NET:** 8.0 Runtime
- **Database:** SQL Server 2019 Express və ya LocalDB

#### Tövsiyə Edilən
- **OS:** Windows 11 (64-bit)
- **RAM:** 8 GB
- **Disk:** 2 GB SSD
- **.NET:** 8.0 SDK
- **Database:** SQL Server 2022 Developer Edition

### Quraşdırma Addımları

#### 1️⃣ .NET 8.0 SDK Quraşdırma

```bash
# Download from:
https://dotnet.microsoft.com/download/dotnet/8.0

# Verify installation:
dotnet --version
# Expected output: 8.0.x
```

#### 2️⃣ SQL Server Quraşdırma

**Variant 1: SQL Server Express (Recommended)**
```
Download: https://www.microsoft.com/sql-server/sql-server-downloads
Install: Express Edition with default settings
```

**Variant 2: SQL Server LocalDB**
```
Included with Visual Studio 2022
Or download separately from Microsoft
```

#### 3️⃣ Layihəni Əldə Etmə

```bash
git clone <repository-url>
cd AzAgroPOS
```

#### 4️⃣ NuGet Paketləri Bərpa

```bash
dotnet restore
```

#### 5️⃣ Connection String Konfiqurasiyası

**Metod 1: appsettings.json (Development)**

`AzAgroPOS.Teqdimat/appsettings.json` faylını açın:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.EntityFrameworkCore": "Warning"
    }
  }
}
```

**Metod 2: User Secrets (Recommended - Təhlükəsiz)**

```bash
cd AzAgroPOS.Teqdimat
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=YOUR_SERVER;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;"
```

**Metod 3: Environment Variable (Production)**

```bash
# Windows PowerShell
$env:AZAGROPOS__CONNECTIONSTRING = "Your_Connection_String"

# Or permanently:
setx AZAGROPOS__CONNECTIONSTRING "Your_Connection_String"
```

#### 6️⃣ Verilənlər Bazası Yaratma

```bash
cd AzAgroPOS.Verilenler

# Create database and apply all migrations
dotnet ef database update

# Verify success - should see migration list
dotnet ef migrations list
```

**Əgər xəta alırsınızsa:**
```bash
# Ensure EF tools are installed
dotnet tool install --global dotnet-ef

# Or update if already installed
dotnet tool update --global dotnet-ef
```

#### 7️⃣ Tətbiqi İşə Salma

**Metod 1: Command Line**
```bash
cd AzAgroPOS.Teqdimat
dotnet run
```

**Metod 2: Visual Studio**
1. `AzAgroPOS.sln` faylını açın
2. `AzAgroPOS.Teqdimat` proyektini **Startup Project** olaraq təyin edin
3. `F5` və ya `Ctrl+F5` basın

---

## 🔐 İlk Giriş

Tətbiq ilk dəfə işə salındıqda login ekranı açılır.

### Default İstifadəçi Məlumatları

```
👤 İstifadəçi adı: admin
🔑 Şifrə: admin123
👑 Rol: Admin (Tam icazələr)
```

### İlk Addımlar Siyahısı

- [ ] 1. İlk giriş edin
- [ ] 2. **VACİB:** Şifrəni dərhal dəyişdirin! (İstifadəçi İdarəetməsi → Şifrə Dəyişdir)
- [ ] 3. Yeni kassir istifadəçisi yaradın
- [ ] 4. Sistem konfiqurasiyalarını yoxlayın
- [ ] 5. Məhsul kateqoriyaları əlavə edin
- [ ] 6. Brend məlumatlarını əlavə edin
- [ ] 7. İlk məhsulları qeyd edin
- [ ] 8. Növbə açın
- [ ] 9. İlk satış əməliyyatını edin
- [ ] 10. Dokumentasiya oxuyun

---

## 💡 İstifadə Təlimatı

### Kassir Üçün: Gündəlik Əməliyyatlar

#### 1. Növbə Açma
```
Ana Menyu → Növbə İdarəetməsi → Növbə Aç
├── Başlanğıc məbləği: 100.00 AZN
└── Təsdiq: OK
```

#### 2. Satış Əməliyyatı
```
Ana Menyu → Yeni Satış
├── Məhsul axtarışı: Barkod/Ad/Stok kodu
├── Miqdar daxil et
├── Səbətə əlavə et
├── Ödəniş metodu seç: [Nağd | Kart | Köçürmə | Nisyə]
└── Satışı tamamla → Qəbz çap
```

#### 3. Nisyə Satış
```
Satış Forması
├── Müştəri seç (vacib!)
├── Məhsulları səbətə əlavə et
├── Ödəniş metodu: Nisyə
└── Təsdiq → Borc avtomatik qeydə alınır
```

#### 4. Məhsul Qaytarma
```
Ana Menyu → Qaytarma
├── Satış ID və ya Qəbz nömrəsi daxil et
├── Qaytarılacaq məhsulları seç
├── Miqdar və səbəb daxil et
└── Təsdiq → Stok və kassa avtomatik yenilənir
```

#### 5. Növbə Bağlama
```
Növbə İdarəetməsi → Növbə Bağla
├── Faktiki məbləği daxil et
├── Sistem məbləği ilə müqayisə et
├── Fərq varsa səbəb qeyd et
├── Z-hesabatı çap et
└── Növbəni bağla
```

### Admin Üçün: İdarəetmə Əməliyyatları

#### 1. Məhsul Əlavə Etmə
```
Ana Menyu → Məhsul İdarəetməsi → Yeni Məhsul
├── Əsas Məlumatlar
│   ├── Ad: Məhsul adı
│   ├── Stok Kodu: Unikal kod
│   ├── Barkod: Avtomatik və ya manual
│   └── Ölçü vahidi: [Ədəd | KQ | Litr | Metr]
├── Qiymətləndirmə
│   ├── Alış qiyməti: 10.00 AZN
│   ├── Pərakəndə satış: 15.00 AZN
│   ├── Topdan satış: 12.00 AZN
│   └── Tək ədəd satış: 15.50 AZN
├── Kateqoriya və Brend
│   ├── Kateqoriya: Seç və ya yeni yarat
│   └── Brend: Seç və ya yeni yarat
├── Stok
│   ├── İlkin stok: 100
│   └── Minimum stok: 10
└── Saxla
```

#### 2. İstifadəçi Yaratma
```
Ana Menyu → İstifadəçi İdarəetməsi → Yeni İstifadəçi
├── İstifadəçi adı: kassir1 (unikal)
├── Tam ad: Əli Məmmədov
├── Şifrə: ••••••• (min 6 simvol)
├── Şifrə təkrar: •••••••
├── Rol: [Admin | Kassir]
├── Email: (opsional)
└── Saxla
```

#### 3. Tədarükçü və Alış
```
1. Tədarükçü Əlavə Et
   Tədarükçü İdarəetməsi → Yeni
   ├── Ad, VÖEN, telefon, ünvan
   └── Bank məlumatları

2. Alış Sifarişi Yarat
   Alış Sifarişi → Yeni
   ├── Tədarükçü seç
   ├── Məhsul və miqdarları əlavə et
   ├── Təhvil tarixi təyin et
   └── Saxla

3. Sifariş Təhvil Alma
   Alış Sənədi → Yeni
   ├── Sifarişdən məhsul seç
   ├── Faktiki miqdarı daxil et
   └── Təsdiq → Stok avtomatik artır

4. Ödəniş Qeyd Et
   Tədarükçü Ödəmə → Yeni
   ├── Tədarükçü və məbləğ
   ├── Ödəniş metodu
   └── Təsdiq
```

#### 4. Hesabat Əldə Etmə
```
Ana Menyu → Hesabatlar
├── Hesabat növü seç
│   ├── Günlük satış
│   ├── Aylıq satış
│   ├── Məhsul üzrə satış
│   ├── Anbar qalığı
│   ├── Mənfəət-zərər
│   └── Z-hesabat arxivi
├── Tarix aralığı təyin et
├── Filtrlər tətbiq et (opsional)
├── Hesabla
└── Excel-ə ixrac et (opsional)
```

---

## 🏛️ Arxitektura

### Üç Səviyyəli (3-Tier) Arxitektura

```
┌─────────────────────────────────────────────────────────┐
│                  PRESENTATION LAYER                      │
│          (AzAgroPOS.Teqdimat - Windows Forms)           │
│                                                          │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐             │
│  │  Forms   │  │  Views   │  │Presenters│             │
│  │  (30+)   │◄─┤(Interface)├─►│  (MVP)   │             │
│  └──────────┘  └──────────┘  └────┬─────┘             │
└──────────────────────────────────────┼───────────────────┘
                                      │
                        ┌─────────────▼──────────────┐
                        │   BUSINESS LOGIC LAYER     │
                        │   (AzAgroPOS.Mentiq)       │
                        │                            │
                        │  ┌──────────────────────┐  │
                        │  │   Managers (21+)     │  │
                        │  ├──────────────────────┤  │
                        │  │   DTOs (35+)         │  │
                        │  ├──────────────────────┤  │
                        │  │   Validations        │  │
                        │  ├──────────────────────┤  │
                        │  │   Business Rules     │  │
                        │  └──────────┬───────────┘  │
                        └─────────────┼──────────────┘
                                      │
                        ┌─────────────▼──────────────┐
                        │   DATA ACCESS LAYER        │
                        │   (AzAgroPOS.Verilenler)   │
                        │                            │
                        │  ┌──────────────────────┐  │
                        │  │  DbContext           │  │
                        │  ├──────────────────────┤  │
                        │  │  Repositories (20+)  │  │
                        │  ├──────────────────────┤  │
                        │  │  Unit of Work        │  │
                        │  ├──────────────────────┤  │
                        │  │  Migrations (25+)    │  │
                        │  └──────────┬───────────┘  │
                        └─────────────┼──────────────┘
                                      │
                        ┌─────────────▼──────────────┐
                        │      ENTITY LAYER          │
                        │   (AzAgroPOS.Varliglar)    │
                        │                            │
                        │  ┌──────────────────────┐  │
                        │  │  Domain Models (53+) │  │
                        │  ├──────────────────────┤  │
                        │  │  Enums (15+)         │  │
                        │  ├──────────────────────┤  │
                        │  │  Interfaces          │  │
                        │  └──────────┬───────────┘  │
                        └─────────────┼──────────────┘
                                      │
                        ┌─────────────▼──────────────┐
                        │     DATABASE               │
                        │   (SQL Server)             │
                        │   34 Tables, 50+ Indexes   │
                        └────────────────────────────┘
```

### Dizayn Patternləri

| Pattern | Məqsəd | İmplementasiya |
|---------|--------|----------------|
| **Repository** | Data access abstraksiyası | `IRepozitori<T>`, konkret repozitorilər |
| **Unit of Work** | Transaksiya idarəetməsi | `IUnitOfWork` |
| **MVP** | UI məntiq ayrılması | View interfeyslər, Presenter sinifləri |
| **Dependency Injection** | Loose coupling | Microsoft DI Container |
| **DTO** | Data transfer | 35+ DTO sinifi |
| **Factory** | Obyekt yaratma | `DesignTimeDbContextFactory` |
| **Singleton** | Tək instansiya | Logger, Configuration |
| **Strategy** | Alqoritm dəyişdirmə | Qiymət növləri |
| **Audit Trail** | Dəyişiklik izləmə | `IAuditableEntity` |

---

## 🗄️ Verilənlər Bazası

### Cədvəl Strukturu (34 Cədvəl)

#### Core Tables (Əsas Cədvəllər)
- `Istifadeciler` - Sistem istifadəçiləri
- `Rollar` - İstifadəçi rolları
- `Icazeler` - Sistem icazələri
- `RolIcazeleri` - Rol-İcazə əlaqəsi
- `Konfiqurasiyalar` - Sistem konfiqurasiyaları

#### Product & Inventory (Məhsul və Anbar)
- `Mehsullar` - Məhsul məlumatları
- `Kateqoriyalar` - Məhsul kateqoriyaları
- `Brendler` - Məhsul brendləri
- `StokHareketleri` - Stok hərəkətləri

#### Sales (Satış)
- `Satislar` - Satış əməliyyatları
- `SatisDetallari` - Satış detalları
- `Qaytarmalar` - Qaytarma əməliyyatları
- `QaytarmaDetallari` - Qaytarma detalları

#### Customer (Müştəri)
- `Musteriler` - Müştəri məlumatları
- `NisyeHereketleri` - Nisyə (borc) hərəkətləri
- `MusteriBonuslari` - Müştəri bonus hesabları
- `BonusQeydleri` - Bonus tarixçəsi

#### Supplier & Purchase (Tədarükçü və Alış)
- `Tedarukculer` - Tədarükçülər
- `AlisSifarisleri` - Alış sifarişləri
- `AlisSifarisSetirleri` - Alış sifariş sətirləri
- `AlisSenetleri` - Alış sənədləri
- `AlisSenedSetirleri` - Alış sənəd sətirləri
- `TedarukcuOdemeleri` - Tədarükçü ödəmələri

#### Financial (Maliyyə)
- `KassaHareketleri` - Kassa hərəkətləri
- `Xercler` - Xərc qeydləri
- `Novbeler` - Növbə (vardiya) məlumatları

#### HR (İnsan Resursları)
- `Isciler` - İşçi məlumatları
- `IsciPerformanslari` - İşçi performans qeydləri
- `IsciIznleri` - İşçi izin qeydləri
- `EmekHaqqilari` - Əmək haqqı qeydləri

#### Repair (Təmir)
- `TemirSifarisleri` - Təmir sifarişləri
- `TemirMerheleleri` - Təmir mərhələləri

#### Audit (Audit)
- `EmeliyyatJurnallari` - Əməliyyat loqları
- `IstifadeciSessiyalari` - İstifadəçi sessiyaları
- `GirisLoquKaydlari` - Giriş audit loqları

### İndekslər (50+ Index)

**Critical Performance Indexes:**
```sql
-- Musteri Indexes
CREATE INDEX IX_Musteriler_TamAd ON Musteriler(TamAd)
CREATE INDEX IX_Musteriler_TelefonNomresi ON Musteriler(TelefonNomresi)
CREATE INDEX IX_Musteriler_UmumiBorc ON Musteriler(UmumiBorc)

-- Mehsul Indexes
CREATE INDEX IX_Mehsullar_Ad ON Mehsullar(Ad)
CREATE INDEX IX_Mehsullar_Barkod ON Mehsullar(Barkod) WHERE Barkod IS NOT NULL
CREATE INDEX IX_Mehsullar_StokKodu ON Mehsullar(StokKodu) WHERE StokKodu IS NOT NULL
CREATE INDEX IX_Mehsullar_Aktivdir_Id ON Mehsullar(Aktivdir, Id)

-- Satis Indexes
CREATE INDEX IX_Satislar_Tarix ON Satislar(Tarix)
CREATE INDEX IX_Satislar_NovbeId ON Satislar(NovbeId)
CREATE INDEX IX_Satislar_Silinib_Tarix_MusteriId ON Satislar(Silinib, Tarix, MusteriId)

-- Ve daha çox...
```

### Əlaqələr (Relationships)

```
Musteri (1) ──── (N) Satislar ───► (N) SatisDetallari ──── (1) Mehsul
                                                             │
Tedarukcu (1) ── (N) AlisSened ── (N) AlisSenedSetiri ──────┘
                      │
Istifadeci ──► Rol ◄──► RolIcazesi ◄──► Icaze
     │
     └──► Novbe (1) ──── (N) Satislar

Isci (1) ──┬── (N) IsciPerformans
           ├── (N) IsciIzni
           ├── (N) EmekHaqqi
           └── (N) Novbe
```

---

## ✨ Xüsusiyyətlər

### 🛒 Satış Modulu
- ✅ Real-vaxt POS interfeysi
- ✅ Barkod skaneri dəstəyi
- ✅ Çoxlu qiymət növləri (pərakəndə, topdan, tək ədəd)
- ✅ Endirim tətbiqi
- ✅ Çoxlu ödəniş metodları (nağd, kart, köçürmə, nisyə)
- ✅ Qəbz çapı
- ✅ Satış qaytarma
- ✅ Satış tarixçəsi

### 📦 Anbar Modulu
- ✅ Real-vaxt stok izləmə
- ✅ Stok hərəkətləri (giriş/çıxış)
- ✅ Minimum stok xəbərdarlığı
- ✅ Barkod generasiyası və çapı
- ✅ Kateqoriya və brend idarəetməsi
- ✅ Anbar qalıq hesabatları
- ✅ Stok düzəlişləri

### 👥 Müştəri Modulu
- ✅ Müştəri profili idarəetməsi
- ✅ Nisyə (borc) sistemi
- ✅ Kredit limiti
- ✅ Bonus loyallıq proqramı
- ✅ Müştəri satış tarixçəsi
- ✅ Borclu müştəri hesabatları

### 🚚 Tədarükçü və Alış Modulu
- ✅ Tədarükçü idarəetməsi
- ✅ Alış sifarişləri
- ✅ Alış sənədləri
- ✅ Tədarükçü ödəmələri
- ✅ Borc izləmə

### 💰 Maliyyə Modulu
- ✅ Növbə (vardiya) idarəetməsi
- ✅ Kassa hərəkətləri
- ✅ Xərc idarəetməsi
- ✅ Mənfəət-zərər hesabatı
- ✅ Z-hesabat

### 👨‍💼 İnsan Resursları Modulu
- ✅ İşçi idarəetməsi
- ✅ İzin idarəetməsi
- ✅ Əmək haqqı hesablaması
- ✅ Performans izləmə

### 🔧 Təmir Modulu
- ✅ Təmir sifarişləri
- ✅ Təmir statusu izləmə
- ✅ Ehtiyat hissələri

### 📊 Hesabat Modulu
- ✅ Günlük/Aylıq satış hesabatları
- ✅ Məhsul satış analizi
- ✅ Anbar hesabatları
- ✅ Maliyyə hesabatları
- ✅ Excel ixracı

### 🔐 Təhlükəsizlik və İdarəetmə
- ✅ İstifadəçi autentifikasiyası (BCrypt)
- ✅ Rol əsaslı icazələr
- ✅ Hesab kilidlənməsi
- ✅ Audit trail
- ✅ Sessiya idarəetməsi
- ✅ Database backup/restore

---

## 📈 Son Yenilənmələr

### v1.1.0 (2025-11-19)

#### 🎨 UI/UX Təkmilləşdirmələr
- ✅ **Modern Dashboard** - Kompakt və effektiv dizayn
  - Panel hündürlüyü 130px-dən 70px-ə endirildi
  - Kartlar 200x90px-dən 150x55px-ə kiçildildi
  - 8 kartdan 6 kart (aktiv təmir və tədarükçü borcu silindi)

- ✅ **Yeni Sidebar Dizaynı**
  - Material Design tünd tema (#2D3443)
  - Modern user panel (#34495E)
  - İkon ilə vizual naviqasiya

- ✅ **btnQebz Düyməsi**
  - Əlavə edildi və işləyir
  - Qəbz çapı funksionallığı

#### 📚 Sənədləşdirmə
- ✅ **Yeni Documentation Qovluğu** - 7 ətraflı sənəd
  - Tam layihə analizi
  - Form tamamlanma statusu
  - Texniki tövsiyələr
  - Kod nümunələri

#### 🐛 Bug Düzəlişləri
- ✅ NullReferenceException problemi həll edildi
  - `AlisSenedFormu.cs:116` - Column null check əlavə edildi
  - Bütün DataGridView column access-lərində null yoxlama

---

## 🔧 Konfiqurasiya

### Connection String Prioriteti

Sistem connection string-i aşağıdakı sıra ilə axtarır:

1. **Environment Variable** (Ən yüksək prioritet)
   ```bash
   AZAGROPOS__CONNECTIONSTRING
   ```

2. **User Secrets** (Development üçün tövsiyə)
   ```bash
   ConnectionStrings:DefaultConnection
   ```

3. **appsettings.json** (Fallback)
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "..."
     }
   }
   ```

### Logging Konfiqurasiyası

```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    },
    "WriteTo": [
      {
        "Name": "File",
        "Args": {
          "path": "logs/azagropos-.txt",
          "rollingInterval": "Day"
        }
      },
      {
        "Name": "Console"
      }
    ]
  }
}
```

---

## 🧪 Test

### Test Layihəsi

```bash
cd AzAgroPOS.Tests
dotnet test
```

### Test Coverage

- Unit Tests: Manager sinifləri
- Integration Tests: Repository əməliyyatları
- Test Helpers: Mock data və utilities

---

## 🚨 Troubleshooting

### Ümumi Problemlər

<details>
<summary><b>Problem: Database-ə qoşula bilmir</b></summary>

**Həll Addımları:**
1. SQL Server işləyirmi? → `services.msc` yoxlayın
2. Connection string düzgündür? → `appsettings.json` yoxlayın
3. Database yaradılıbmı? → `dotnet ef database update` işlədin
4. Firewall bloklamır? → Port 1433 yoxlayın

```bash
# Connection test
sqlcmd -S (localdb)\MSSQLLocalDB -Q "SELECT @@VERSION"
```
</details>

<details>
<summary><b>Problem: Login edə bilmir (admin/admin123)</b></summary>

**Həll Addımları:**
1. Migration-lar tətbiq olunubmu?
   ```bash
   cd AzAgroPOS.Verilenler
   dotnet ef database update
   ```

2. Seed data işləyibmi?
   ```sql
   SELECT * FROM Istifadeciler WHERE IstifadeciAdi = 'admin'
   ```

3. Hesab kilidlənməyibmi?
   ```sql
   UPDATE Istifadeciler
   SET HesabKilidlenmeTarixi = NULL, UgursuzGirisCehdi = 0
   WHERE IstifadeciAdi = 'admin'
   ```
</details>

<details>
<summary><b>Problem: Satış edərkən stok azalmır</b></summary>

**Diaqnostika:**
1. Logs yoxlayın → `logs/azagropos-YYYYMMDD.txt`
2. `StokHareketiManager` çağırılır?
3. Transaction commit olur?

```csharp
// Debug logging əlavə edin
Logger.MelumatYaz($"Stok əvvəl: {mehsul.MovcudSay}");
// Stok əməliyyatı
Logger.MelumatYaz($"Stok sonra: {mehsul.MovcudSay}");
```
</details>

---

## 🤝 Töhfə Vermə

### Kod Standartları

- **Dil:** Azərbaycan dili (latın əlifbası)
- **Naming:** PascalCase (sinif, metod), camelCase (parametr)
- **Comments:** Azərbaycan və ya İngilis
- **Commit Messages:** Konvensional Commits

### Pull Request Prosesi

1. Fork edin
2. Feature branch yaradın (`git checkout -b feature/YeniXususiyyet`)
3. Dəyişiklikləri commit edin (`git commit -m 'feat: yeni xüsusiyyət əlavə edildi'`)
4. Branch-ı push edin (`git push origin feature/YeniXususiyyet`)
5. Pull Request açın

### Commit Message Konvensiyası

```
feat: Yeni xüsusiyyət
fix: Bug düzəlişi
docs: Sənədləşdirmə dəyişikliyi
style: Kod formatı (məntiq dəyişmir)
refactor: Kod refactoringu
test: Test əlavəsi
chore: Build və ya auxiliary əməliyyatlar
```

---

## 📞 Dəstək və Əlaqə

### Dokumentasiya
- 📖 [Texniki Sənədləşdirmə](Documentation/README.md)
- 📄 [Form Analizi](Documentation/FormAnalysis_Report.md)
- 💡 [Texniki Tövsiyələr](Documentation/FormAnalysis_TechnicalRecommendations.md)

### Problemlər
- 🐛 [Issue Tracker](../../issues)
- 💬 [Müzakirələr](../../discussions)

---

## 📜 Lisenziya

Bu layihə proprietary lisenziya altındadır. Bütün hüquqlar qorunur.

---

## 👏 Təşəkkürlər

### İstifadə Olunan Texnologiyalar

- [.NET](https://dotnet.microsoft.com/) - Microsoft tərəfindən hazırlanmış cross-platform framework
- [Entity Framework Core](https://docs.microsoft.com/ef/core/) - Modern ORM
- [MaterialSkin.2](https://github.com/leocb/MaterialSkin) - Material Design UI Library
- [Serilog](https://serilog.net/) - Structured logging library
- [BCrypt.Net](https://github.com/BcryptNet/bcrypt.net) - Password hashing library
- [EPPlus](https://epplussoftware.com/) - Excel library

---

## 📊 Statistika

```
Created: 2024-10
Last Updated: 2025-11-19
Version: 1.1.0
Language: C# 12 / .NET 8.0
Lines of Code: 50,000+
Contributors: AzAgroPOS Development Team
Status: Active Development
```

---

<div align="center">

**AzAgroPOS Development Team tarafından ❤️ ilə hazırlanmışdır**

[⬆ Başa Qayıt](#azagropos---kənd-təsərrüfatı-satış-nöqtəsi-sistemi)

</div>
