<div align="center">

<!-- Animasiyalı SVG Header -->
<svg width="800" height="120" viewBox="0 0 800 120" xmlns="http://www.w3.org/2000/svg">
  <defs>
    <linearGradient id="grad" x1="0%" y1="0%" x2="100%" y2="0%">
      <stop offset="0%" style="stop-color:#60a5fa"/>
      <stop offset="50%" style="stop-color:#a78fff"/>
      <stop offset="100%" style="stop-color:#34d399"/>
    </linearGradient>
    <style>
      .title { animation: fadeIn 1s ease both; }
      .sub { animation: fadeIn 1s ease 0.3s both; opacity: 0; }
      @keyframes fadeIn {
        from { opacity: 0; transform: translateY(-8px); }
        to   { opacity: 1; transform: translateY(0); }
      }
    </style>
  </defs>
  <rect width="800" height="120" rx="12" fill="#0d1117"/>
  <text class="title" x="400" y="52" text-anchor="middle"
        font-family="Segoe UI,system-ui,sans-serif" font-size="36"
        font-weight="700" fill="url(#grad)">AzAgroPOS</text>
  <text class="sub" x="400" y="82" text-anchor="middle"
        font-family="Segoe UI,system-ui,sans-serif" font-size="14"
        fill="#8b949e">Azərbaycan dili üçün hazırlanmış tam funksional ERP / POS sistemi</text>
  <text x="400" y="106" text-anchor="middle"
        font-family="Segoe UI,system-ui,sans-serif" font-size="12"
        fill="#484f58">Layered Architecture · MVP · Repository Pattern · Dependency Injection</text>
</svg>

<br/>

![.NET](https://img.shields.io/badge/.NET_8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core_9-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![WinForms](https://img.shields.io/badge/WinForms-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![MaterialSkin](https://img.shields.io/badge/MaterialSkin_2-757575?style=for-the-badge&logo=materialdesign&logoColor=white)

![Lines](https://img.shields.io/badge/Əl_ilə_yazılmış_kod-45%2C660_sətir-brightgreen?style=flat-square)
![Files](https://img.shields.io/badge/C%23_faylı-483-blue?style=flat-square)
![Async](https://img.shields.io/badge/Async_nisbəti-68%25-purple?style=flat-square)
![Tech Debt](https://img.shields.io/badge/Kod_borcu-Sıfır-success?style=flat-square)

</div>

---

## 📋 Mündəricat

<details>
<summary>Bölmələri göstər / gizlət</summary>

- [📊 Ümumi miqyas](#-ümumi-miqyas)
- [📝 Kod həcmi](#-kod-həcmi)
- [🧬 OOP strukturu](#-oop-strukturu)
- [🏗️ Arxitektura komponentləri](#️-arxitektura-komponentləri)
- [⚙️ Metod statistikası](#️-metod-statistikası)
- [🚀 Müasir C# xüsusiyyətləri](#-müasir-c-xüsusiyyətləri)
- [🛡️ Etibarlılıq](#️-etibarlılıq-və-resurs-idarəetməsi)
- [📐 Top 10 fayllar](#-ən-böyük-fayllar--top-10)
- [🗂️ Layihə strukturu](#️-layihə-strukturu)
- [🔧 Texnologiya yığımı](#-texnologiya-yığımı)
- [🏆 Güclü tərəflər](#-güclü-tərəflər-və-tövsiyələr)
- [📋 Ümumi qiymət](#-ümumi-qiymətləndirmə)

</details>

---

## 📊 Ümumi miqyas

<div align="center">

| 📁 Layihə | 📄 Ümumi fayl | 🔵 C# faylı | 🖼️ Designer | 🖥️ WinForms | 🗂️ Namespace |
|:-:|:-:|:-:|:-:|:-:|:-:|
| **6** | **1,261** | **483** | **63** | **33** | **432** |

</div>

> **Analiz:** 1,261 fayl, 6 project — orta-böyük enterprise miqyası. 483 C# faylının 432 namespace-ə paylanması
> hər namespace-ə **1.12 fayl** deməkdir. Bu SRP (Single Responsibility Principle) prinsipinə
> uyğun modullaşdırmanın göstəricisidir.

---

## 📝 Kod həcmi

<!-- Animasiyalı SVG Progress Barlar -->
<div align="center">

```
Əl ilə yazılmış    [████████████████████████░░░░░░░░░░] 45,660 sətir (47.2%)
Designer kodu      [█████████████████████████████░░░░░] 51,002 sətir (52.8%)
──────────────────────────────────────────────────────
Ümumi C# kodu                                          96,662 sətir
```

</div>

| Kateqoriya | Sətir sayı | Pay | Qeyd |
|:--|--:|--:|:--|
| Əl ilə yazılmış C# | **45,660** | 47.2% | Real biznes məntiqi |
| Designer tərəfindən | **51,002** | 52.8% | WinForms UI kodu |
| **Ümumi C# kodu** | **96,662** | **100%** | |

> **Analiz:** 10k sətirdən az — kiçik; 10–50k — orta; 50k+ — böyük enterprise.
> AzAgroPOS 45,660 əl ilə yazılmış sətiri ilə **orta-böyük** kateqoriyasındadır.
> Designer fayllarının 51k sətir olması 33 forma, 63 designer faylının zənginliyini göstərir.

---

## 🧬 OOP strukturu

```
class            [████████████████████████████████████] 332   ← əsas tikinti bloku
partial class    [██████████████░░░░░░░░░░░░░░░░░░░░░] 128   ← designer/code ayrımı
interface        [███████░░░░░░░░░░░░░░░░░░░░░░░░░░░░]  66   ← abstraksiya müqavilələri
generic class    [████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░]  36   ← tip-təhlükəsiz yenidən istifadə
enum             [███░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░]  26   ← sabit dəyər domenləri
abstract class   [░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░]   3   ← baza şablonları
record           [░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░]   0   ← istifadə edilməyib
```

> **Analiz:** Interface/Class nisbəti **19.8%** — hər 5 class-a 1 interface düşür.
> Bu DIP (Dependency Inversion Principle) prinsipinə uyğun abstraksiya səviyyəsidir.
> `record` sıfırdır — DTO-larda immutable `record` tipinin istifadəsi düşünülə bilər (C# 9+).

---

## 🏗️ Arxitektura komponentləri

<table>
<tr>
<td width="25%">

**🔵 Verilənlər qatı**

| Komponent | Say |
|:--|--:|
| Entity | **60** |
| DbSet | **35** |
| Migration | **32** |
| DbContext | **1** |

</td>
<td width="25%">

**🟢 Məntiqi qat**

| Komponent | Say |
|:--|--:|
| Repository | **65** |
| DTO | **38** |
| Presenter | **30** |
| Manager | **22** |

</td>
<td width="25%">

**🟣 DI & Konfiq.**

| Komponent | Say |
|:--|--:|
| DI qeydiyyatı | **84** |
| `using` direktivi | **1,086** |

</td>
<td width="25%">

**🟡 Nisbətlər**

| Nisbət | Dəyər |
|:--|--:|
| Repo/Entity | **1.08** |
| Presenter/Form | **0.91** |
| DTO/Entity | **0.63** |
| Interface/Class | **0.20** |

</td>
</tr>
</table>

> **Analiz:** Repository/Entity = **1.08** — hər entity üçün ayrı repository (tam Repository Pattern).
> Presenter/Form = **0.91** — demək olar ki, hər formanın öz Presenter-i var (MVP əhatəsi 91%).
> 25 Entity üçün DbSet yoxdur — bunlar view entity-ləri və ya lookup cədvəlləri ola bilər.

---

## ⚙️ Metod statistikası

```
Property (get/set)  [████████████████████████████████████] 934   ← güclü encapsulation
Public metod        [███████████████████████████████████░] 903
Private metod       [██████████████████████████░░░░░░░░░] 696
Async metod         [████████████████████████░░░░░░░░░░░] 611   ← 68% async nisbəti ★
Event Handler       [██████████░░░░░░░░░░░░░░░░░░░░░░░░░] 276
Task<T>             [█████████░░░░░░░░░░░░░░░░░░░░░░░░░░] 246
Static metod        [███████░░░░░░░░░░░░░░░░░░░░░░░░░░░░] 186
Protected metod     [█████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░] 150
Override            [█████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░] 135
Virtual metod       [░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░]   7
```

> **Analiz:** Async nisbəti **68%** — WinForms üçün mükəmməl göstərici; UI thread bloklanmır.
> Public/Private nisbəti **903/696 = 1.30** — bir qədər yüksəkdir; idealda private > public olmalıdır.
> Hər formaya ortalama **8.4 Event Handler** düşür — yüksək interaktivlik.
> 934 property güclü encapsulation mədəniyyətini göstərir.

---

## 🚀 Müasir C# xüsusiyyətləri

```
Lambda =>        [████████████████████████████████████] 2,779  ← hər fayla 5.75 lambda
Nullable ?       [██████████████████████████░░░░░░░░░] 2,021  ← NRT tam aktiv
using direktivi  [███████████████░░░░░░░░░░░░░░░░░░░░] 1,086
LINQ             [████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░]   261  ← artırıla bilər
Task<T>          [████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░]   246
DI qeydiyyatı   [██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░]    84
```

> **Analiz:** **2,779 lambda** — hər C# faylına 5.75 lambda; expression-bodied members
> geniş istifadə olunur. **2,021 nullable** annotasiyası C# 8+ NRT-nin tam aktiv olduğunu
> göstərir — `NullReferenceException` riski kompilyasiya zamanı aşkarlanır. LINQ-un 261
> olması potensial böyümə sahəsidir — verilənlər emalında LINQ istifadəsi artırıla bilər.

---

## 🛡️ Etibarlılıq və resurs idarəetməsi

<div align="center">

| Göstərici | Say | Status | Qeyd |
|:--|--:|:--|:--|
| `try-catch` bloku | **381** | ✅ Geniş əhatə | Hər fayla 0.79 blok |
| `IDisposable` | **11** | ✅ Mövcud | Resurs azad etmə |
| Logger istifadəsi | **2** | ⚠️ Kritik zəiflik | Serilog tövsiyə olunur |
| `TODO` | **0** | ✅ Sıfır borc | Aktiv texniki borc yox |
| `FIXME` | **0** | ✅ Sıfır problem | Açıq problem yox |

</div>

> **Analiz:** 381 try-catch hər fayla **0.79 blok** — geniş xəta əhatəsi.
> Lakin **logger sayı cəmi 2** — istehsal mühitində xətaların izlənilməsi üçün
> **Serilog + File/Seq sink** inteqrasiyası mütləq tövsiyə olunur.
> `IDisposable`-ın 11 olması azdır — EF Core `DbContext`-lər `using` bloku ilə idarə edilməlidir.
> **TODO=0, FIXME=0** — aktiv inkişafdakı layihə üçün nadir və əla göstərici.

---

## 📐 Ən böyük fayllar — Top 10

### WinForms formaları

| Sıra | Forma | Sətir | Vizual |
|:-:|:--|--:|:--|
| 🥇 | `SatisFormu.cs` | **1,008** | `████████████████████` |
| 🥈 | `IsciIzniFormu.cs` | **610** | `████████████` |
| 🥉 | `MehsulIdareetmeFormu.cs` | **610** | `████████████` |
| 4 | `AnaMenuFormu.cs` | **592** | `████████████` |
| 5 | `AnbarFormu.cs` | **541** | `███████████` |
| 6 | `KonfiqurasiyaFormu.cs` | **504** | `██████████` |
| 7 | `KassaFormu.cs` | **501** | `██████████` |
| 8 | `BonusIdareetmeFormu.cs` | **490** | `██████████` |
| 9 | `EmekHaqqiFormu.cs` | **457** | `█████████` |
| 10 | `AlisSifarisFormu.cs` | **433** | `█████████` |

### Bütün məntiq faylları (birləşdirilmiş)

| Sıra | Fayl | Sətir | Kateqoriya | Vizual |
|:-:|:--|--:|:--|:--|
| 🥇 | `SatisFormu.cs` | **1,008** | `WinForms` | `████████████████████` |
| 🥈 | `AlisManager.cs` | **937** | `Manager` | `██████████████████░` |
| 🥉 | `AzAgroPOSDbContext.cs` | **729** | `DbContext` | `██████████████░░░░░` |
| 4 | `MehsulIdareetmeFormu.cs` | **610** | `WinForms` | `████████████░░░░░░░` |
| 5 | `IsciIzniFormu.cs` | **610** | `WinForms` | `████████████░░░░░░░` |
| 6 | `Program.cs` | **600** | `Entry Point` | `████████████░░░░░░░` |
| 7 | `AnaMenuFormu.cs` | **592** | `WinForms` | `████████████░░░░░░░` |
| 8 | `MaliyyeManager.cs` | **550** | `Manager` | `███████████░░░░░░░░` |
| 9 | `AnbarFormu.cs` | **541** | `WinForms` | `███████████░░░░░░░░` |
| 10 | `KonfiqurasiyaFormu.cs` | **504** | `WinForms` | `██████████░░░░░░░░░` |

> **Analiz:** `SatisFormu.cs` 1,008 sətir ilə ən böyük fayldır — satış axını
> kompleks biznes məntiqi ehtiva edir. `AlisManager.cs` 937 sətir — bölünməsi düşünülə bilər.
> `Program.cs`-in **600 sətir** olması diqqəti çəkir — DI bootstrap + konfigurasiya
> ayrı siniflərə köçürülməlidir.

---

## 🗂️ Layihə strukturu

```
AzAgroPOS.sln
│
├── 🖥️  AzAgroPOS.Teqdimat/          ← Presentation Layer
│   ├── Forms/                        33 forma · 276 event handler
│   ├── Presenters/                   30 MVP Presenter
│   └── Program.cs                    Entry point — 600 sətir · DI bootstrap
│
├── 🧠  AzAgroPOS.Mentiq/             ← Business Logic Layer
│   ├── Managers/                     22 Manager sinfi
│   └── DTOs/                         38 Data Transfer Object
│
├── 🗄️  AzAgroPOS.Verilenler/         ← Data Access Layer
│   ├── Repositories/                 65 Repository + Interface cütü
│   ├── Migrations/                   32 EF Core Migration
│   └── AzAgroPOSDbContext.cs         729 sətir · 35 DbSet
│
├── 📦  AzAgroPOS.Varliglar/           ← Domain Layer
│   └── Entities/                     60 Entity · 26 Enum
│
├── 🧪  AzAgroPOS.Tests/              ← Test Layer
│
└── 🔐  PasswordHasher/               ← Utility: şifrə hash alətı
```

---

## 🔧 Texnologiya yığımı

<div align="center">

| Kateqoriya | Texnologiyalar |
|:--|:--|
| **Platforma** | .NET 8 · C# · Windows Forms · Windows |
| **Verilənlər bazası** | Microsoft SQL Server · EF Core 9 · Code First Migrations |
| **DI & Konfiqurasiya** | `Microsoft.Extensions.DependencyInjection` · `appsettings.json` |
| **Excel** | EPPlus |
| **UI / Dizayn** | MaterialSkin 2 (Material Design) |
| **Arxitektura** | Layered Architecture · MVP · Repository Pattern · DI |

</div>

---

## 🏆 Güclü tərəflər və tövsiyələr

### ✅ Güclü tərəflər

| # | Tərəf | Detal | Göstərici |
|:-:|:--|:--|:--|
| 1 | **Repository Pattern** | Verilənlərə giriş tam abstraksiyalaşdırılıb | 65 repo / 66 interface |
| 2 | **MVP Arxitekturası** | UI loqikası formalardan ayrılıb | 30/33 = 91% əhatə |
| 3 | **Async/Await** | UI thread heç vaxt bloklanmır | 611 async, 68% nisbət |
| 4 | **Dependency Injection** | Loosely coupled komponentlər | 84 DI qeydiyyatı |
| 5 | **Nullable Reference Types** | NullReferenceException riski minimaldır | 2,021 annotasiya |
| 6 | **Sıfır kod borcu** | Aktiv texniki borc yoxdur | TODO=0, FIXME=0 |
| 7 | **Code First Migrations** | Schema versiyalanmışdır | 32 migration |
| 8 | **Modern C# sintaksisi** | Expression-bodied, lambda, LINQ | 2,779 lambda |

### ⚠️ Tövsiyələr

| # | Sahə | Problem | Həll |
|:-:|:--|:--|:--|
| 1 | **Logging** | Cəmi 2 logger — istehsalda xəta izlənilmir | Serilog + File/Seq sink |
| 2 | **Program.cs** | 600 sətir — çox böyük entry point | Ayrı konfiqurasiya sinifləri |
| 3 | **record tipi** | DTO-larda `record` istifadə edilməyib | C# 9+ `record` DTO-ları |
| 4 | **LINQ** | 261 — artırıla bilər | Verilənlər emalında LINQ |

---

## 📋 Ümumi qiymətləndirmə

<div align="center">

| Göstərici | Nəticə |
|:--|:--|
| **Layihə miqyası** | 🔵 Orta–Böyük *(Medium-Large Scale)* |
| **Arxitektura** | 🟣 Layered + MVP |
| **OOP səviyyəsi** | 🟢 Yüksək |
| **Async əhatəsi** | 🟢 68% — Geniş |
| **EF Core** | 🔵 Code First · 32 Migration |
| **Müasir C#** | 🟢 Aktiv — Lambda, Nullable, LINQ |
| **Kod borcu** | 🟢 Sıfır |
| **Logging** | 🟡 ⚠️ Artırılmalı |
| **Ümumi qiymət** | ⭐⭐⭐⭐½ |

</div>

> AzAgroPOS **45,660 sətir** əl ilə yazılmış kod, **332 sinif**, **65 repository**,
> **611 async metod**, **2,779 lambda** ifadəsi və **sıfır texniki borc** ilə
> peşəkar səviyyəli enterprise tətbiqdir. Arxitektura, OOP dizaynı və müasir C#
> istifadəsi baxımından nümunəvi layihədir. Logging infrastrukturunun gücləndirilməsi
> ilə tam production-ready statusa çatacaq.

---

<div align="center">

*AzAgroPOS · Naxçıvan, Azərbaycan*

![Made with C#](https://img.shields.io/badge/Made_with-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-MVP_+_Layered-7c3aed?style=for-the-badge)

</div>