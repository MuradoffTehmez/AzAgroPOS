# Code Coverage Hesabatı

## 📊 Cari Coverage Statistikası

**Tarix:** 2025-11-11
**Test Sayı:** 53
**Line Coverage:** ~2.2% (1,165 / 52,664 xətt)
**Branch Coverage:** ~6.4% (81 / 1,256 branch)

## ✅ Test edilmiş Manager-lər

| Manager | Test Sayı | Status |
|---------|-----------|--------|
| MehsulManager | 5 | ✅ Pass |
| SatisManager | 6 | ✅ Pass |
| MusteriManager | 7 | ✅ Pass |
| BazaIdareetmeManager | 17 | ✅ Pass |
| TehlukesizlikManager | 18 | ✅ Pass |

## 🎯 Coverage Hədəfi

- **Qısa müddətdə (FAZA 2):** 20% line coverage
- **Orta müddətdə (FAZA 3-5):** 40% line coverage
- **Uzun müddətdə (FAZA 6+):** 60%+ line coverage

## 🚀 Coverage Report-u Necə Çıxarmaq

### 1. Test-ləri coverage ilə run et:
```bash
dotnet test --collect:"XPlat Code Coverage" --results-directory:"./TestResults"
```

### 2. Coverage faylının yeri:
```
TestResults/{guid}/coverage.cobertura.xml
```

### 3. Human-readable report yaratmaq (Optional):
ReportGenerator tool-u quraşdırın:
```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

Report yaradın:
```bash
reportgenerator `
  -reports:"TestResults/**/coverage.cobertura.xml" `
  -targetdir:"TestResults/CoverageReport" `
  -reporttypes:"Html;HtmlSummary"
```

HTML report-u açın:
```bash
start TestResults/CoverageReport/index.html
```

## 📁 Test Strukturu

```
AzAgroPOS.Tests/
├── Unit/
│   └── Managers/
│       ├── MehsulManagerTests.cs (5 test)
│       ├── SatisManagerTests.cs (6 test)
│       └── MusteriManagerTests.cs (7 test)
├── Mentiq/
│   └── Idareciler/
│       ├── BazaIdareetmeManagerTests.cs (17 test)
│       └── TehlukesizlikManagerTests.cs (18 test)
└── TestHelpers/
    ├── MehsulMockFactory.cs
    ├── MusteriMockFactory.cs
    └── SatisMockFactory.cs
```

## 🔧 Package-lər

- **xUnit** 2.6.2 - Test framework
- **Moq** 4.20.70 - Mocking library
- **FluentAssertions** 6.12.0 - Assertion library
- **coverlet.collector** 6.0.0 - Coverage tool

## 📝 Növbəti Addımlar

1. ✅ Mock Factory classes yaradıldı
2. ✅ MehsulManager test edildi
3. ✅ SatisManager test edildi
4. ✅ MusteriManager test edildi
5. ⏳ Repository integration test-ləri
6. ⏳ Presenter test-ləri
7. ⏳ Coverage 20%+ çatdırmaq

---

**Son yenilənmə:** 2025-11-11
**Versiya:** 1.0
