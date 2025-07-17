# AzAgroPOS Test Layihəsi

Bu layihə AzAgroPOS sisteminin avtomatlaşdırılmış unit testlərini ehtiva edir.

## 🧪 Test Növləri

### Unit Testlər
- **SatisServiceTests**: Satış əməliyyatlarının təcrid olunmuş testləri
- **MusteriServiceTests**: Müştəri idarəetməsinin unit testləri  
- **ConfigProtectorTests**: Təhlükəsizlik konfiqurasiyasının testləri

## 🛠️ İstifadə Olunan Teknologiyalar

- **xUnit**: Test framework
- **Moq**: Mock obyektlər üçün
- **FluentAssertions**: Oxunaqlı assertion-lar
- **Microsoft.EntityFrameworkCore.InMemory**: In-memory database testləri

## ▶️ Testləri İşə Salma

### Visual Studio-da
1. Solution Explorer-də test layihəsini seçin
2. **Test > Run All Tests** menyusunu seçin
3. Test Explorer pəncərəsində nəticələri izləyin

### Komanda sətirindən
```bash
# Bütün testləri işə sal
dotnet test

# Verbose çıxış ilə
dotnet test --logger "console;verbosity=detailed"

# Təkcə müəyyən test sinifi
dotnet test --filter "ClassName=SatisServiceTests"

# Test coverage hesabla
dotnet test --collect:"XPlat Code Coverage"
```

## 📊 Test Strukturu

```
AzAgroPOS.Tests/
├── Services/
│   ├── SatisServiceTests.cs      # Satış servisi testləri
│   ├── MusteriServiceTests.cs    # Müştəri servisi testləri
│   └── ...
├── Security/
│   └── ConfigProtectorTests.cs  # Təhlükəsizlik testləri
└── AzAgroPOS.Tests.csproj       # Test layihə fayli
```

## 🎯 Test Metodologiyası

### AAA Pattern (Arrange-Act-Assert)
```csharp
[Fact]
public async Task CreateSatis_ValidData_ReturnsSuccess()
{
    // Arrange (Hazırlıq)
    var testSatis = new Satis { /* test data */ };
    
    // Act (İcra)
    var result = await _satisService.CreateSatisAsync(testSatis);
    
    // Assert (Yoxlama)
    result.Should().BeGreaterThan(0);
}
```

### Mock Obyektlər
```csharp
// Repository mock-u yaradırıq
var mockRepository = new Mock<SatisRepository>();
mockRepository.Setup(x => x.AddAsync(It.IsAny<Satis>()))
          .ReturnsAsync(123);

// Service-i mock ilə test edirik
var service = new SatisService(mockRepository.Object);
```

## 🔍 Test Senariları

### SatisService Testləri
- ✅ Valid satış yaratma
- ❌ Boş satış detalları
- ❌ Mövcud olmayan məhsul
- ❌ Kifayətsiz stok
- ❌ Null parametrlər

### MusteriService Testləri  
- ✅ Valid müştəri yaratma
- ✅ Müştəri axtarışı
- ✅ Müştəri yeniləmə/silmə
- ❌ Səhv email formatı
- ❌ Mövcud olmayan qrup

### ConfigProtector Testləri
- ✅ Backup yaratma
- ✅ Şifrələmə statusu yoxlama
- ✅ Müxtəlif connection string formatları
- ❌ Fayl mövcud olmama

## 📈 Test Coverage

İdeal test coverage səviyyələri:
- **Services**: 80%+ 
- **Business Logic**: 90%+
- **Security Components**: 95%+

Coverage report almaq üçün:
```bash
dotnet test --collect:"XPlat Code Coverage"
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:"TestResults/*/coverage.cobertura.xml" -targetdir:"TestResults/html" -reporttypes:Html
```

## 🚀 Continuous Integration

Test-lər avtomatik olaraq aşağıdakı hallarda işə düşməlidir:
- Pull Request yaradıldıqda
- Main branch-ə commit edildikdə  
- Nightly build-lərdə

## 🐛 Test Xətalarını Həll Etmə

### Mock Setup Xətaları
```csharp
// PROBLEM: Mock qaytarış dəyəri təyin edilməyib
mockRepo.Setup(x => x.GetById(1)); // ❌

// HƏLLİ: Return dəyərini təyin et
mockRepo.Setup(x => x.GetById(1)).Returns(testObject); // ✅
```

### Async Test Problemləri
```csharp
// PROBLEM: Async metodun await olunmaması
var result = service.CreateAsync(data); // ❌

// HƏLLİ: Await istifadə et
var result = await service.CreateAsync(data); // ✅
```

## 📚 Test Yazma Qaydaları

1. **Test adları açıqlayıcı olmalıdır**
   ```csharp
   // YAXŞı
   CreateSatis_ValidData_ReturnsSuccessId()
   
   // PƏŞƏKAR DEYİL
   Test1()
   ```

2. **Hər test təcrid olunmuş olmalıdır**
   - Digər testlərdən asılı olmamalı
   - Database vəziyyətindən asılı olmamalı
   
3. **Edge case-ləri test edin**
   - Null dəyərlər
   - Boş kolleksiyalar  
   - Boundary dəyərləri

4. **Test performance-ını izləyin**
   - Unit testlər sürətli olmalıdır (< 1s)
   - Integration testlər qəbul edilə bilər (< 10s)

## 🔗 Əlaqəli Sənədlər

- [Unit of Work Pattern Documentation](../UnitOfWork_Numune_Istifade.md)
- [Build Status](../Build_Status_Check.md)
- [AzAgroPOS Architecture Guide](../README.md)