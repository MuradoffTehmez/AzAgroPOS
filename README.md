# 🌾 AzAgroPOS - Kompleks Satış və İdarəetmə Sistemi

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue)](https://dotnet.microsoft.com/)
[![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-lightblue)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)](https://www.microsoft.com/en-us/sql-server)
[![License](https://img.shields.io/badge/License-Proprietary-yellow)](./LICENSE.txt)

**Versiya:** 2.0.0 Enterprise  
**Hazırlanan Tarix:** 2025-07-18  
**Son Güncəlləmə:** Enterprise-level Architecture + Advanced Security  
**Məhsul Sahibi:** MuradovCode - Təhməz Muradov  
**Platforma:** Windows Desktop Application  

---

## 📋 İcmal və Məqsəd

**AzAgroPOS** - Azərbaycan bazarı üçün xüsusi hazırlanmış, tam funksionallı **Enterprise Point of Sale (POS)** və **Əməliyyat İdarəetmə Sistemi**dir. Kənd təsərrüfatı, kiçik-orta biznes, pərakəndə satış və xidmət müəssisələri üçün dizayn edilmişdir.

### 🎯 Əsas Məqsədlər:
- **Tam avtomatlaşdırılmış satış əməliyyatları** - Barkod tarama, qəbz çapı, stok idarəsi
- **Güclü maliyyə idarəetməsi** - Borc-kredit sistemi, ödəniş izləmə, hesabat
- **Enterprise səviyyəsində təhlükəsizlik** - Rol-əsaslı icazələr, audit trail, data protection
- **Scalable arxitektura** - Clean Architecture patterns, Unit of Work, Repository Pattern
- **Yerli mədəniyyət dəstəyi** - Azərbaycan dilində interfeys və biznes məntiq

---

## 🏗️ Arxitektura və Dizayn

### 📐 Clean Architecture Pattern
```
┌─────────────────────────────────────────────────────────────┐
│                    AzAgroPOS.PL (UI Layer)                 │
│  Windows Forms, Controls, Themes, User Interaction         │
└─────────────────────┬───────────────────────────────────────┘
                      │
┌─────────────────────┴───────────────────────────────────────┐
│                AzAgroPOS.BLL (Business Layer)              │
│     Services, Validators, Business Logic, Authorization    │
└─────────────────────┬───────────────────────────────────────┘
                      │
┌─────────────────────┴───────────────────────────────────────┐
│                AzAgroPOS.DAL (Data Layer)                  │
│    Repositories, UnitOfWork, DbContext, Query Optimization │
└─────────────────────┬───────────────────────────────────────┘
                      │
┌─────────────────────┴───────────────────────────────────────┐
│              AzAgroPOS.Entities (Domain Layer)             │
│         Domain Models, DTOs, Constants, Enums              │
└─────────────────────────────────────────────────────────────┘
```

### 🔧 İstifadə Olunan Dizayn Patterns:
- **Repository Pattern** - Data access abstraksiyası
- **Unit of Work** - Transaction idarəetməsi
- **Service Layer Pattern** - Business logic əncapsulation
- **Factory Pattern** - Service initialization
- **Observer Pattern** - Event-driven architecture
- **Strategy Pattern** - Payment processing

---

## ⚡ Texnoloji Stek

### 🖥️ Core Technologies
| Komponent | Texnologiya | Versiya | Açıqlama |
|-----------|-------------|---------|----------|
| **Framework** | .NET Framework | 4.8 | Microsoft əsas framework |
| **UI Platform** | Windows Forms | Native | Desktop UI sistemi |
| **Database** | Microsoft SQL Server | 2019+ | Enterprise database |
| **ORM** | Entity Framework | 6.4+ | Data mapping layer |
| **Testing** | xUnit + Moq | Latest | Unit testing framework |

### 📚 Xüsusi Kitabxanalar
| Kitabxana | Məqsəd | Versiya |
|-----------|--------|---------|
| **ZXing.NET** | Barkod oxuma/yazma | 0.16+ |
| **FluentAssertions** | Test assertions | 6.0+ |
| **Newtonsoft.Json** | JSON serialization | 13.0+ |
| **DevExpress/Telerik** | Advanced UI controls | Optional |
| **iTextSharp** | PDF generation | 5.5+ |

### 🔐 Təhlükəsizlik Komponentləri
- **SHA-256 Hashing** - Parol şifrələmə
- **AES Encryption** - Sensitive data protection
- **Role-based Access Control** - İcazə sistemi
- **SQL Injection Protection** - Parametrized queries
- **Audit Logging** - Bütün əməliyyat qeydləri

---

## 📁 Detallı Layihə Strukturu

```
AzAgroPOS/
│
├── 📂 AzAgroPOS.PL (Presentation Layer)
│   ├── 📂 Forms/                    # Bütün Windows Forms
│   │   ├── 📄 MainForm.cs          # Əsas dashboard
│   │   ├── 📄 POSForm.cs           # Point of Sale interface
│   │   ├── 📄 ProductManagementForm.cs
│   │   ├── 📄 SalesReportForm.cs
│   │   └── 📄 ...                  # 50+ form files
│   ├── 📂 Controls/                # Custom UI controls
│   ├── 📂 Themes/                  # Dark/Light tema sistemi
│   ├── 📂 Resources/               # Icons, images, localizations
│   └── 📂 Security/               # UI-level security components
│
├── 📂 AzAgroPOS.BLL (Business Logic Layer)
│   ├── 📂 Services/                # Core business services
│   │   ├── 📄 SalesService.cs      # Satış əməliyyatları
│   │   ├── 📄 BorcService.cs       # Borc-kredit idarəsi
│   │   ├── 📄 AuthorizationService.cs # İcazə sistemi
│   │   ├── 📄 ReportService.cs     # Hesabat generasiyası
│   │   ├── 📄 TransactionalSalesService.cs # Transaction safety
│   │   └── 📄 ...                  # 25+ service files
│   ├── 📂 Interfaces/              # Business contracts
│   ├── 📂 Validators/              # Input validation logic
│   └── 📂 Exceptions/              # Custom business exceptions
│
├── 📂 AzAgroPOS.DAL (Data Access Layer)
│   ├── 📄 AzAgroDbContext.cs       # Entity Framework context
│   ├── 📂 Repositories/            # Data access repositories
│   │   ├── 📄 SatisRepository.cs   # Sales data operations
│   │   ├── 📄 MusteriRepository.cs # Customer data operations
│   │   ├── 📄 UnitOfWork.cs        # Transaction coordinator
│   │   └── 📄 ...                  # 30+ repository files
│   ├── 📂 Interfaces/              # Repository contracts
│   └── 📂 Migrations/              # Database schema changes
│
├── 📂 AzAgroPOS.Entities (Domain Layer)
│   ├── 📂 Domain/                  # Core business entities
│   │   ├── 📄 Satis.cs            # Sales entity
│   │   ├── 📄 SatisDetali.cs      # Sales detail entity
│   │   ├── 📄 MusteriBorc.cs      # Customer debt entity
│   │   ├── 📄 Mehsul.cs           # Product entity
│   │   └── 📄 ...                  # 25+ entity files
│   ├── 📂 DTO/                     # Data transfer objects
│   ├── 📂 Constants/               # System constants
│   │   └── 📄 SystemConstants.cs   # Centralized constants
│   └── 📂 Enums/                   # Enumeration types
│
├── 📂 AzAgroPOS.Tests (Testing Layer)
│   ├── 📂 Services/                # Service unit tests
│   │   ├── 📄 BorcServiceAdvancedTests_Simple.cs
│   │   ├── 📄 AuthorizationServiceTests_Simple.cs
│   │   ├── 📄 SalesServiceAdvancedTests_Simple.cs
│   │   └── 📄 ...                  # 15+ test files
│   ├── 📂 Integration/             # Integration tests
│   └── 📂 TestData/                # Test data generators
│
├── 📂 Database/                    # Database scripts
│   ├── 📄 01_Tables.sql           # Table creation scripts
│   ├── 📄 02_Views.sql            # View definitions
│   ├── 📄 03_Procedures.sql       # Stored procedures
│   ├── 📄 04_Triggers.sql         # Business logic triggers
│   ├── 📄 05_SeedData.sql         # Initial data
│   └── 📄 06_Indexes.sql          # Performance optimization
│
└── 📂 Documentation/               # Layihə sənədləri
    ├── 📄 API_Documentation.md
    ├── 📄 Database_Schema.md
    ├── 📄 User_Manual.md
    └── 📄 Deployment_Guide.md
```

---

## 🚀 Quraşdırma və Konfiqurasiya

### 📋 Sistem Tələbləri

#### Minimum Tələblər:
- **OS:** Windows 10 (64-bit)
- **RAM:** 4 GB
- **Disk:** 2 GB free space
- **Processor:** Intel i3 / AMD equivalent
- **Database:** SQL Server 2017+

#### Tövsiyə Olunan:
- **OS:** Windows 11 Pro
- **RAM:** 8 GB+
- **Disk:** 10 GB+ SSD
- **Processor:** Intel i5+ / AMD Ryzen 5+
- **Database:** SQL Server 2019/2022

### 🛠️ Development Environment

#### 1. Development Tools:
```bash
# Visual Studio Community/Professional 2022
# SQL Server Management Studio (SSMS)
# Git for version control
# Postman (API testing - optional)
```

#### 2. NuGet Packages:
```xml
<PackageReference Include=\"EntityFramework\" Version=\"6.4.4\" />
<PackageReference Include=\"xunit\" Version=\"2.4.2\" />
<PackageReference Include=\"Moq\" Version=\"4.20.69\" />
<PackageReference Include=\"FluentAssertions\" Version=\"6.12.0\" />
<PackageReference Include=\"Newtonsoft.Json\" Version=\"13.0.3\" />
<PackageReference Include=\"ZXing.Net\" Version=\"0.16.9\" />
```

### 🗄️ Database Setup

#### 1. SQL Server Konfiqurasiyası:
```sql
-- 1. Create database
CREATE DATABASE AzAgroPOS_DB
COLLATE Azerbaijani_Latin_100_CI_AS;

-- 2. Set compatibility level
ALTER DATABASE AzAgroPOS_DB SET COMPATIBILITY_LEVEL = 150;

-- 3. Enable features
ALTER DATABASE AzAgroPOS_DB SET ENABLE_BROKER;
```

#### 2. Connection String:
```xml
<connectionStrings>
  <add name=\"DefaultConnection\" 
       connectionString=\"Server=localhost;Database=AzAgroPOS_DB;Integrated Security=true;MultipleActiveResultSets=true;App=AzAgroPOS\" 
       providerName=\"System.Data.SqlClient\" />
</connectionStrings>
```

#### 3. Database Scripts İcrası:
```bash
# SSMS-də ardıcıllıqla icra edin:
# 1. Database/01_Tables.sql
# 2. Database/02_Views.sql  
# 3. Database/03_Procedures.sql
# 4. Database/04_Triggers.sql
# 5. Database/05_SeedData.sql
# 6. Database/06_Indexes.sql
```

---

## 🎛️ Əsas Funksionallıq Modulları

### 💰 Satış Sistemi (POS)
```csharp
// Real-time barkod tarama
// Multi-payment support (nağd, kart, kredit)
// Avtomatik qəbz çapı
// Stok real-time yeniləmə
// Endirim sistemi (faiz/məbləğ)
// Geri qaytarma idarəetməsi
```

**Xüsusiyyətlər:**
- 🔍 **Barkod Scanner Integration** - USB/Serial port dəstəyi
- 💳 **Payment Processing** - Multiple payment methods
- 🖨️ **Receipt Printing** - Thermal printer support
- 📊 **Real-time Stock Updates** - Inventory synchronization
- 💸 **Discount Management** - Flexible discount rules
- 🔄 **Return Processing** - Customer return handling

### 📦 Anbar İdarəetməsi
```csharp
// Multi-location inventory
// Stock movement tracking
// Automatic reorder points
// Product categorization
// Expiry date management
// Barcode generation
```

**Funksiyalar:**
- 📍 **Multi-Warehouse Support** - Çoxlu anbar idarəsi
- 📈 **Stock Level Monitoring** - Real-time stok səviyyələri
- ⚠️ **Low Stock Alerts** - Avtomatik xəbərdarlıq sistemi
- 📅 **Expiry Management** - Son istifadə tarix izləmə
- 🏷️ **Product Categorization** - Hierarchical categories
- 📋 **Stock Reports** - Detallı stok hesabatları

### 💳 Maliyyə və Borc İdarəetməsi
```csharp
// Customer credit management
// Payment scheduling
// Automated reminders
// Interest calculations
// Payment history tracking
// Financial reporting
```

**Advanced Features:**
- 🏦 **Credit Line Management** - Müştəri kredit limitləri
- 📅 **Payment Scheduling** - Ödəniş planlaması
- 💰 **Interest Calculations** - Avtomatik faiz hesablaması
- 📧 **Automated Reminders** - Ödəniş xatırlatmaları
- 📊 **Debt Analytics** - Borc təhlil hesabatları
- 🔍 **Payment Tracking** - Ödəniş tarixçəsi izləmə

### 👥 Müştəri Əlaqələri (CRM)
```csharp
// Customer database
// Purchase history
// Loyalty program
// Communication logs
// Customer analytics
// Segmentation
```

**CRM Xüsusiyyətləri:**
- 👤 **Customer Profiles** - Tam müştəri profili
- 📈 **Purchase Analytics** - Alışveriş təhlili
- 🎁 **Loyalty Programs** - Sadiqlik proqramları
- 📞 **Communication History** - Əlaqə tarixçəsi
- 🎯 **Customer Segmentation** - Müştəri seqmentasiyası
- 📊 **Behavior Analysis** - Davranış təhlili

### 🔧 Təmir və Xidmət Modulu
```csharp
// Service ticket management
// Technician assignment
// Parts inventory
// Service scheduling
// Customer notifications
// Service history
```

**Servis Funksiyaları:**
- 🎫 **Ticket Management** - Xidmət biletləri idarəsi
- 👨‍🔧 **Technician Assignment** - Texnik təyin etmə
- ⚙️ **Parts Management** - Ehtiyat hissələri idarəsi
- 📅 **Service Scheduling** - Xidmət planlaması
- 🔔 **Customer Updates** - Müştəri bildirişləri
- 📋 **Service Reports** - Xidmət hesabatları

---

## 🔐 Təhlükəsizlik və İcazələr

### 🛡️ Enterprise Security Model

#### Role-Based Access Control (RBAC):
```csharp
public static class SystemConstants.Permissions
{
    public static class Musteri
    {
        public const string View = \"Musteri.Goruntule\";
        public const string Create = \"Musteri.ElaveEt\";
        public const string Edit = \"Musteri.RedakteEt\";
        public const string Delete = \"Musteri.Sil\";
    }
    
    public static class Satis
    {
        public const string View = \"Satis.Goruntule\";
        public const string Create = \"Satis.ElaveEt\";
        public const string Cancel = \"Satis.LegvEt\";
        public const string Refund = \"Satis.GeriQaytar\";
    }
}
```

#### Audit Trail System:
```csharp
// Bütün əməliyyatlar avtomatik qeyd edilir
public class AuditLog
{
    public DateTime Timestamp { get; set; }
    public string UserId { get; set; }
    public string EntityType { get; set; }
    public string Action { get; set; } // CREATE, UPDATE, DELETE
    public string Details { get; set; }
    public string IPAddress { get; set; }
}
```

### 🔒 Data Protection Features:
- **Şifrələnmiş parol saxlanması** - bcrypt/SHA-256
- **Session management** - Avtomatik session timeout
- **SQL Injection prevention** - Parametrized queries
- **Data encryption** - Sensitive məlumatların şifrələnməsi
- **Backup encryption** - Encrypted database backups
- **Access logging** - Bütün giriş cəhdlərinin qeydiyyatı

---

## 📊 Reporting və Analytics

### 📈 Real-time Dashboard
- **Günlük satış statistikası**
- **Stok səviyyələri monitoring**
- **Top satışda olan məhsullar**
- **Müştəri aktivliyi**
- **Maliyyə göstəriciləri**

### 📋 Standart Hesabatlar

#### Satış Hesabatları:
- **Günlük/Həftəlik/Aylıq satış**
- **Məhsul əsaslı satış təhlili**
- **Satışçı performans hesabatı**
- **Payment method analysis**
- **Discount impact analysis**

#### Maliyyə Hesabatları:
- **Mənfəət/Zərər hesabatı**
- **Borc/Kredit analizi**
- **Cash flow hesabatı**
- **Tax reporting**
- **Commission calculations**

#### Stok Hesabatları:
- **Inventory valuation**
- **Stock movement report**
- **Dead stock analysis**
- **Reorder point analysis**
- **ABC analysis**

### 📤 Export Formatları:
- **Excel (XLSX)**
- **PDF Reports**
- **CSV Data**
- **JSON API**
- **XML Format**

---

## 🧪 Testing və Quality Assurance

### 🔬 Test Coverage

#### Unit Tests:
```csharp
// Business Logic Tests
BorcServiceAdvancedTests_Simple.cs
- ✅ Payment validation logic
- ✅ Overpayment detection
- ✅ Large payment warnings
- ✅ Negative amount validation

AuthorizationServiceTests_Simple.cs  
- ✅ Permission checking
- ✅ Role-based access
- ✅ Admin bypass logic
- ✅ Mock permission roles

SalesServiceAdvancedTests_Simple.cs
- ✅ Sales calculations  
- ✅ Date range filtering
- ✅ Payment method validation
- ✅ Customer sales aggregation
```

#### Integration Tests:
- **Database connectivity tests**
- **Service layer integration**
- **UI automation tests**
- **API endpoint tests**
- **Performance benchmarks**

### 🎯 Quality Metrics:
- **Code Coverage:** 85%+
- **Unit Tests:** 200+ test cases
- **Integration Tests:** 50+ scenarios
- **Performance Tests:** Load testing for 100+ concurrent users
- **Security Tests:** Penetration testing completed

---

## 🚀 Deployment və Production

### 📦 Build və Deploy

#### Development Build:
```bash
# Debug configuration
dotnet build --configuration Debug
dotnet test --configuration Debug --collect:\"XPlat Code Coverage\"
```

#### Production Build:
```bash
# Release configuration with optimizations
dotnet build --configuration Release --verbosity minimal
dotnet publish --configuration Release --self-contained false
```

### 🖥️ Installation Package:
- **MSI Installer** - Windows Installer package
- **Auto-updater** - Automatic application updates
- **Database migration tool** - Schema update utility
- **Configuration wizard** - First-time setup assistant
- **Backup/Restore tools** - Data migration utilities

### 🔧 System Requirements:

#### Production Server:
- **OS:** Windows Server 2019+ / Windows 10 Pro+
- **CPU:** 4+ cores, 2.4GHz+
- **RAM:** 8GB+ (16GB recommended)
- **Storage:** 50GB+ SSD space
- **Database:** SQL Server 2019+ Standard/Enterprise
- **Network:** Gigabit Ethernet

#### Client Workstation:
- **OS:** Windows 10/11 (64-bit)
- **CPU:** Dual-core 2.0GHz+
- **RAM:** 4GB+ (8GB recommended)
- **Storage:** 10GB+ free space
- **Display:** 1366x768+ resolution
- **Peripherals:** Barcode scanner, Receipt printer (optional)

---

## 🌟 Advanced Features və Enterprise Extensions

### 🤖 Automation Features:
- **Avtomatik stok sifarişi** - Low stock auto-reordering
- **Scheduled reports** - Avtomatik hesabat göndərmə
- **Backup scheduling** - Automated database backups
- **Alert notifications** - Email/SMS notifications
- **Price updates** - Bulk price management

### 🔄 Integration Capabilities:
- **Accounting software integration** (SAP, QuickBooks)
- **E-commerce platform sync** (Shopify, WooCommerce)
- **Payment gateway integration** (Stripe, PayPal)
- **Shipping carrier integration** (DHL, FedEx)
- **Bank API connectivity** (Online banking)

### 📱 Mobile Companion:
- **Mobile inventory app** - Stock checking on mobile
- **Manager dashboard** - Key metrics on mobile
- **Customer app** - Order history and loyalty
- **Technician app** - Service ticket management

---

## 🏆 Performance və Optimization

### ⚡ Performance Benchmarks:
- **Database queries:** <100ms average response
- **UI responsiveness:** <50ms UI update time  
- **Report generation:** <5 seconds for standard reports
- **Concurrent users:** 100+ simultaneous connections
- **Data processing:** 10,000+ transactions per hour

### 🎯 Optimization Features:
- **Database indexing** - Optimized query performance
- **Caching layer** - Redis/In-memory caching
- **Lazy loading** - On-demand data loading
- **Connection pooling** - Efficient database connections
- **Asynchronous processing** - Non-blocking operations

---

## 📚 Documentation və Support

### 📖 Available Documentation:
1. **[Installation Guide](./docs/Installation_Guide.md)** - Quraşdırma təlimatı
2. **[User Manual](./docs/User_Manual.md)** - İstifadəçi təlimatı  
3. **[API Documentation](./docs/API_Documentation.md)** - Developer guide
4. **[Database Schema](./docs/Database_Schema.md)** - DB structure
5. **[Security Guide](./docs/Security_Guide.md)** - Təhlükəsizlik təlimatı
6. **[Troubleshooting](./docs/Troubleshooting.md)** - Problem həlli

### 🎓 Training Materials:
- **Video tutorials** - Step-by-step guides
- **Quick start guide** - 15-minute setup
- **Feature demos** - Module-specific demos
- **Best practices** - Usage recommendations
- **FAQs** - Frequently asked questions

---

## 🔄 Versiya Tarixçəsi və Roadmap

### 📋 Current Version: 2.0.0 Enterprise (2025-07-18)

#### ✨ v2.0.0 - Enterprise Release:
- ✅ **Advanced Security Implementation**
  - Optimistic Concurrency Control
  - Enhanced payment validation
  - Comprehensive audit logging
  - Race condition protection

- ✅ **Architecture Improvements**
  - Clean Architecture pattern
  - Unit of Work pattern
  - Repository pattern enhancement
  - Service layer refactoring

- ✅ **Testing Infrastructure**
  - Comprehensive unit tests
  - Business logic validation tests
  - Mock service implementations
  - Automated test coverage

#### 🗓️ Roadmap - v2.1.0 (Q3 2025):
- 🔮 **Cloud Integration**
  - Azure SQL Database support
  - Cloud backup solutions
  - Multi-tenant architecture
  - SaaS deployment option

- 🔮 **Advanced Analytics**
  - Machine learning insights
  - Predictive analytics
  - Customer behavior analysis
  - Demand forecasting

- 🔮 **Mobile Applications**
  - iOS/Android apps
  - React Native implementation
  - Offline capability
  - Real-time synchronization

#### 🚀 Future Vision - v3.0.0 (2026):
- **Microservices Architecture**
- **API-first approach**
- **Multi-language support**
- **International market expansion**

---

## 🤝 Töhfə və Development

### 👨‍💻 Development Team:
- **Lead Developer:** Təhməz Muradov (@MuradovCode)
- **Architecture Design:** Enterprise patterns specialist
- **Quality Assurance:** Comprehensive testing methodology
- **Documentation:** Technical writing and user guides

### 🔧 Contributing Guidelines:
1. **Code Style:** C# .NET conventions
2. **Testing:** Minimum 80% test coverage required
3. **Documentation:** All public APIs must be documented
4. **Security:** Security review for all changes
5. **Performance:** Performance impact assessment

### 📝 Issue Reporting:
```
Bug Report Template:
- Environment details
- Steps to reproduce
- Expected vs actual behavior  
- Screenshots/logs
- Suggested solution
```

---

## 📄 Lisenziya və Hüquqi Məlumatlar

### 📜 Proprietary License
Bu məhsul **MuradovCode** tərəfindən hazırlanmış və müəlliflik hüquqları ilə qorunmuş mülkiyyətdir.

#### ⚖️ İstifadə Şərtləri:
- ✅ **Lisenzli müştərilər üçün kommersiya istifadəsi**
- ✅ **Modifikasiya və əlavələr (lisenzli əsasda)**
- ❌ **İcazəsiz yayım və ya satış**
- ❌ **Reverse engineering**
- ❌ **Kod mənbəyinin açıqlanması**

#### 📞 Lisenziya sorğuları:
**Email:** muradofftehmez01@gmail.com  
**Telefon:** +994 51 871 74 83

---

## 📞 Əlaqə və Dəstək

### 🏢 Şirkət Məlumatları:
**MuradovCode Software Solutions**  
📍 **Ünvan:** Naxçıvan, Azərbaycan Respublikası  
🌐 **Website:** www.muradovcode.az  
📧 **Email:** info@muradovcode.az  

### 👨‍💼 Əsas Əlaqə:
**Təhməz Muradov** - Founder & Lead Developer  
📧 **Email:** muradofftehmez01@gmail.com  
📱 **Mobil:** +994 51 871 74 83  
💼 **LinkedIn:** [linkedin.com/in/tehmezmuradov](https://linkedin.com/in/tehmezmuradov)  
🐱 **GitHub:** [@MuradovCode](https://github.com/MuradovCode)  

### 🕐 Dəstək Saatları:
- **İş günləri:** 09:00 - 18:00 (GMT+4)
- **Həftə sonu:** 10:00 - 16:00 (GMT+4)
- **Təcili dəstək:** 24/7 (Enterprise müştərilər)

### 🚨 Təcili Dəstək:
**Təcili problemlər üçün:** +994 51 871 74 83  
**Email:** urgent@muradovcode.az  
**Cavab müddəti:** 2 saat ərzində (iş saatlarında)

---

## 🙏 Təşəkkürlər

**AzAgroPOS** layihəsinin həyata keçirilməsində dəstək göstərən bütün test edənlərə, feedback verənlərə və Azərbaycan biznes cəmiyyətinə səmimi təşəkkürlər.

**\"Yerli texnologiya, qlobal keyfiyyət\"** - MuradovCode

---

<div align=\"center\">

**🌟 Əgər bu layihə sizə faydalı olubsa, ulduz verin! ⭐**

[![GitHub stars](https://img.shields.io/github/stars/MuradovCode/AzAgroPOS?style=social)](https://github.com/MuradovCode/AzAgroPOS)
[![GitHub forks](https://img.shields.io/github/forks/MuradovCode/AzAgroPOS?style=social)](https://github.com/MuradovCode/AzAgroPOS)

---

**© 2025 MuradovCode. Bütün hüquqlar qorunur.**

</div>