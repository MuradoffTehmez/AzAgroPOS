<div align="center">

<img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/C%23-ERP%20%2F%20POS-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
<img src="https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white"/>
<img src="https://img.shields.io/badge/EF_Core-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/WinForms-MVP_Architecture-0078D4?style=for-the-badge&logo=windows&logoColor=white"/>

<br/><br/>

# AzAgroPOS

**Azərbaycan dili üçün hazırlanmış tam funksional ERP / POS sistemi**

*Layered Architecture · MVP Pattern · Repository Pattern · Dependency Injection*

</div>

---

## 📋 Mündəricat

- [Ümumi miqyas](#-ümumi-miqyas)
- [Kod həcmi](#-kod-həcmi)
- [OOP strukturu](#-oop-strukturu)
- [Arxitektura komponentləri](#-arxitektura-komponentləri)
- [Metod statistikası](#-metod-statistikası)
- [Müasir C# xüsusiyyətləri](#-müasir-c-xüsusiyyətləri)
- [Etibarlılıq](#-etibarlılıq-və-resurs-idarəetməsi)
- [Ən böyük fayllar](#-ən-böyük-fayllar--top-10)
- [Layihə strukturu](#-layihə-strukturu)
- [Texnologiya yığımı](#-texnologiya-yığımı)
- [Güclü tərəflər](#-güclü-tərəflər)

---

## 📊 Ümumi miqyas

<div align="center">

| 📁 Layihə sayı | 📄 Ümumi fayl | 🔵 C# faylı | 🗂️ Namespace |
|:-:|:-:|:-:|:-:|
| **6** | **1,261** | **483** | **432** |

</div>

---

## 📝 Kod həcmi

<div align="center">

```
Əl ilə yazılmış C# kodu     ████████████████████████░░░░░  45,660 sətir  (47.2%)
Designer tərəfindən          █████████████████████████████  51,002 sətir  (52.8%)
─────────────────────────────────────────────────────────────────────────────────
Ümumi C# kodu                                               96,662 sətir
```

</div>

| Kateqoriya | Sətir sayı | Pay |
|:--|--:|--:|
| Əl ilə yazılmış C# kodu | **45,660** | 47.2% |
| Designer tərəfindən yaradılan | **51,002** | 52.8% |
| **Ümumi C# kodu** | **96,662** | **100%** |

---

## 🧬 OOP strukturu

<div align="center">

| Tip | Say | | Tip | Say |
|:--|--:|---|:--|--:|
| `class` | **332** | | `partial class` | **128** |
| `interface` | **66** | | `generic class` | **36** |
| `abstract class` | **3** | | `enum` | **26** |
| `record` | **0** | | | |

</div>

**OOP paylanması:**

```
class            ████████████████████████████████████████  332
interface        ████████                                   66
partial class    ███████████████                           128
generic class    ████                                       36
enum             ███                                        26
abstract         ░                                           3
```

---

## 🏗️ Arxitektura komponentləri

<table>
<tr>
<td>

**🔵 Verilənlər qatı**

| Komponent | Say |
|:--|--:|
| Entity | **60** |
| DbSet | **35** |
| Migration | **32** |
| DbContext | **1** |

</td>
<td>

**🟢 Məntiqi qat**

| Komponent | Say |
|:--|--:|
| Repository | **65** |
| DTO | **38** |
| Presenter | **30** |
| Manager | **22** |

</td>
<td>

**🟣 DI & Konfiqurasiya**

| Komponent | Say |
|:--|--:|
| DI qeydiyyatı | **84** |
| `using` direktivi | **1,086** |

</td>
</tr>
</table>

---

## ⚙️ Metod statistikası

```
Public metod     ██████████████████████████████████████░░  903   ← əsas interfeys
Private metod    ████████████████████████████░░░░░░░░░░░░  696
Async metod      █████████████████████████░░░░░░░░░░░░░░░  611   ← 68% async nisbəti
Event Handler    ███████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  276
Property         ████████████████████████████████████████  934
Static           ███████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  186
Protected        ██████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  150
Override         █████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  135
Task<T>          █████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░  246
Virtual          ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░    7
```

> **68% async nisbəti** — WinForms tətbiqləri üçün mükəmməl göstəricidir. UI donması minimuma endirilmişdir.

---

## 🚀 Müasir C# xüsusiyyətləri

<div align="center">

| Xüsusiyyət | Say | Qeyd |
|:--|--:|:--|
| Lambda / `=>` | **2,779** | Expression-bodied members |
| Nullable `?` | **2,021** | Null-safety gücləndirilmişdir |
| `using` direktivi | **1,086** | Namespace idarəetməsi |
| LINQ | **261** | Deklarativ sorğular |
| `Task<T>` | **246** | Async pipeline |
| DI qeydiyyatı | **84** | IoC container |

</div>

```
Lambda =>        ██████████████████████████████████████  2,779
Nullable ?       ██████████████████████████████          2,021
using            ████████████████                        1,086
LINQ             ████                                      261
Task<T>          ████                                      246
DI               █                                          84
```

---

## 🛡️ Etibarlılıq və resurs idarəetməsi

<div align="center">

| Göstərici | Say | Status |
|:--|--:|:--|
| `try-catch` bloku | **381** | ✅ Geniş əhatə |
| `IDisposable` | **11** | ✅ Resurs azad etmə |
| Logger istifadəsi | **2** | ⚠️ Genişləndirilməli |
| `TODO` | **0** | ✅ Kod borcu yoxdur |
| `FIXME` | **0** | ✅ Açıq problem yoxdur |

</div>

> ⚠️ **Tövsiyə:** Logger sayı cəmi 2-dir. `Serilog` və ya `Microsoft.Extensions.Logging` inteqrasiyası güclü tövsiyə olunur.

---

## 🖥️ WinForms statistikası

<div align="center">

| Forma sayı | Designer faylı | Event Handler |
|:-:|:-:|:-:|
| **33** | **63** | **276** |

</div>

> Ortalama hər formaya **8.4 event handler** düşür — yüksək əməliyyat intensivliyi.

---

## 📐 Ən böyük fayllar — Top 10

### WinForms formaları

| # | Forma | Sətir | Bar |
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

### Məntiq faylları

| # | Fayl | Sətir | Kateqoriya |
|:-:|:--|--:|:--|
| 🥇 | `SatisFormu.cs` | **1,008** | `WinForms` |
| 🥈 | `AlisManager.cs` | **937** | `Manager` |
| 🥉 | `AzAgroPOSDbContext.cs` | **729** | `DbContext` |
| 4 | `MehsulIdareetmeFormu.cs` | **610** | `WinForms` |
| 5 | `IsciIzniFormu.cs` | **610** | `WinForms` |
| 6 | `Program.cs` | **600** | `Entry Point` |
| 7 | `AnaMenuFormu.cs` | **592** | `WinForms` |
| 8 | `MaliyyeManager.cs` | **550** | `Manager` |
| 9 | `AnbarFormu.cs` | **541** | `WinForms` |
| 10 | `KonfiqurasiyaFormu.cs` | **504** | `WinForms` |

---

## 🗂️ Layihə strukturu

```
AzAgroPOS/
│
├── 🖥️  AzAgroPOS.Teqdimat/          # Presentation Layer
│   ├── Forms/                        # 33 WinForms forması
│   ├── Presenters/                   # 30 MVP Presenter
│   └── Program.cs                    # Entry point — 600 sətir
│
├── 🧠  AzAgroPOS.Mentiq/             # Business Logic Layer
│   ├── Managers/                     # 22 Manager sinfi
│   └── DTOs/                         # 38 Data Transfer Object
│
├── 🗄️  AzAgroPOS.Verilenler/         # Data Access Layer
│   ├── Repositories/                 # 65 Repository + Interface
│   ├── Migrations/                   # 32 EF Core Migration
│   └── AzAgroPOSDbContext.cs         # 729 sətir
│
├── 📦  AzAgroPOS.Varliglar/           # Domain Layer
│   └── Entities/                     # 60 Entity sinfi
│
├── 🧪  AzAgroPOS.Tests/              # Test Layer
│
└── 🔐  PasswordHasher/               # Utility — şifrə hash
```

---

## 🔧 Texnologiya yığımı

<div align="center">

![.NET](https://img.shields.io/badge/.NET_8-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core_9-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![MaterialSkin](https://img.shields.io/badge/MaterialSkin_2-757575?style=flat-square&logo=materialdesign&logoColor=white)
![EPPlus](https://img.shields.io/badge/EPPlus-Excel-217346?style=flat-square&logo=microsoftexcel&logoColor=white)

</div>

| Kateqoriya | Texnologiyalar |
|:--|:--|
| **Platforma** | .NET 8, Windows Forms, C# |
| **Verilənlər bazası** | Microsoft SQL Server, EF Core 9, Code First |
| **DI** | `Microsoft.Extensions.DependencyInjection` |
| **Konfiqurasiya** | `Microsoft.Extensions.Configuration` + `appsettings.json` |
| **Excel** | EPPlus |
| **UI** | MaterialSkin 2 (Material Design) |
| **Arxitektura** | Layered, MVP, Repository Pattern, DI |

---

## 🏆 Güclü tərəflər

| # | Güclü tərəf | Detal |
|:-:|:--|:--|
| ✅ | **Repository Pattern** | 65 repository — verilənlər qatı tam abstraksiyalaşdırılıb |
| ✅ | **MVP Arxitekturası** | 30 Presenter — UI loqikası formalardan ayrılıb |
| ✅ | **Async/Await** | 611 async metod (68%) — UI donması sıfıra yaxındır |
| ✅ | **Dependency Injection** | 84 DI qeydiyyatı — loosely coupled komponentlər |
| ✅ | **Modern C#** | 2,779 lambda, 2,021 nullable — qısa, təhlükəsiz kod |
| ✅ | **Code First** | 32 migration — schema versiyalanmışdır |
| ✅ | **Sıfır kod borcu** | TODO=0, FIXME=0 |
| ⚠️ | **Logging** | Yalnız 2 — Serilog inteqrasiyası tövsiyə olunur |

---

## 📊 Xülasə

<div align="center">

| Göstərici | Nəticə |
|:--|:--|
| **Layihə miqyası** | Orta–Böyük *(Medium-Large Scale)* |
| **Arxitektura** | Layered + MVP |
| **OOP səviyyəsi** | Yüksək |
| **Async əhatəsi** | Geniş — 611 metod, 68% |
| **EF Core** | Code First · 32 Migration |
| **Kod borcu** | Sıfır |
| **Məqsəd** | ERP / POS / Anbar / Maliyyə |

</div>

---

<div align="center">

*AzAgroPOS · Naxçıvan, Azərbaycan · .NET 8 · C# · WinForms*

![Made with C#](https://img.shields.io/badge/Made%20with-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white)

</div>