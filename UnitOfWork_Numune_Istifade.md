# Unit of Work Pattern - Nümunə İstifadə

Bu faylda Unit of Work pattern-in AzAgroPOS layihəsində necə istifadə olunacağını nümayəş edəcəyik.

## Problem və Həlli

### Əvvəlki Problem:
```csharp
// ƏVVƏL - Hər service öz DbContext yaradırdı
public class SatisService
{
    private readonly AzAgroDbContext _context;
    private readonly SatisRepository _satisRepository;
    
    public SatisService()
    {
        _context = new AzAgroDbContext();  // Ayrı context
        _satisRepository = new SatisRepository(_context);
    }
    
    public void SatisYarat(Satis satis)
    {
        _satisRepository.Add(satis); // Birinci dəyişiklik
        _context.SaveChanges();      // Saxla
        
        // Başqa bir əməliyyat - ayrı context istifadə edə bilər
        var anbarService = new AnbarService(); // Yeni context!
        anbarService.MehsulCixis(...); // Yeni SaveChanges()
        
        // Problem: Əgər ikinci əməliyyat uğursuz olarsa, birinci yadda qalır!
    }
}
```

### İndi Həll:
```csharp
// İNDİ - Vahid UnitOfWork istifadə edirik
public class SatisService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public SatisService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public void SatisYarat(Satis satis, List<SatisDetali> detallar)
    {
        try
        {
            // 1. Satışı əlavə et
            _unitOfWork.Satislar.Add(satis);

            // 2. Anbar qalığını yenilə
            foreach (var detal in detallar)
            {
                var anbarQaliq = _unitOfWork.AnbarQaliqlari
                                     .GetByAnbarVeMehsul(1, detal.MehsulId);
                
                if (anbarQaliq == null || anbarQaliq.MovcudMiqdar < detal.Miqdar)
                    throw new Exception("Kifayət qədər stok yoxdur");

                anbarQaliq.MovcudMiqdar -= detal.Miqdar;
                _unitOfWork.AnbarQaliqlari.Update(anbarQaliq);
            }

            // 3. Bütün dəyişiklikləri BİR DƏFƏYƏ təsdiqlə
            _unitOfWork.Complete();  // Hamısı birlikdə saxlanır
        }
        catch (Exception)
        {
            // Xəta baş verərsə heç bir dəyişiklik olmur
            throw;
        }
    }
}
```

## Əsas Üstünlüklər

### 1. Atomarlıq (Atomicity)
```csharp
// Nümunə: Müştəri borcu yaratma
public void MusteriBorcuYarat(MusteriBorc borc, BorcOdenis ilkOdeme)
{
    try
    {
        // 1. Borcu əlavə et
        _unitOfWork.MusteriBorclari.Add(borc);
        
        // 2. İlk ödəməni qeyd et  
        _unitOfWork.BorcOdenisleri.Add(ilkOdeme);
        
        // 3. Müştərinin ümumi borcunu yenilə
        var musteri = _unitOfWork.Musteriler.GetById(borc.MusteriId);
        musteri.UmumiBorc += borc.QalanMebleg;
        _unitOfWork.Musteriler.Update(musteri);
        
        // Hamısı birlikdə təsdiqlənir - atomarlıq təmin edilir
        _unitOfWork.Complete();
    }
    catch
    {
        // Xəta olarsa heç bir dəyişiklik olmur
        throw;
    }
}
```

### 2. Tutarlılıq (Consistency)
```csharp
// Nümunə: Anbar transferi
public void AnbarTransferi(int menbAnbar, int hedefAnbar, int mehsulId, decimal miqdar)
{
    try
    {
        // 1. Mənbə anbardan çıxart
        var menbQaliq = _unitOfWork.AnbarQaliqlari.GetByAnbarVeMehsul(menbAnbar, mehsulId);
        if (menbQaliq.MovcudMiqdar < miqdar)
            throw new Exception("Kifayət qədər məhsul yoxdur");
            
        menbQaliq.MovcudMiqdar -= miqdar;
        _unitOfWork.AnbarQaliqlari.Update(menbQaliq);
        
        // 2. Hədəf anbara əlavə et
        var hedefQaliq = _unitOfWork.AnbarQaliqlari.GetByAnbarVeMehsul(hedefAnbar, mehsulId);
        hedefQaliq.MovcudMiqdar += miqdar;
        _unitOfWork.AnbarQaliqlari.Update(hedefQaliq);
        
        // 3. Transfer qeydini yarat
        var transfer = new AnbarTransfer { /* ... */ };
        _unitOfWork.AnbarTransferleri.Add(transfer);
        
        // Hamısı eyni anda - tutarlılıq təmin edilir
        _unitOfWork.Complete();
    }
    catch
    {
        // Xəta olarsa transfer yarımçıq qalmır
        throw;
    }
}
```

### 3. Performans Artımı
```csharp
// Əvvəl: Hər repository üçün ayrı connection
var context1 = new AzAgroDbContext();  // Connection 1
var context2 = new AzAgroDbContext();  // Connection 2  
var context3 = new AzAgroDbContext();  // Connection 3

// İndi: Vahid connection
using (var unitOfWork = new UnitOfWork(new AzAgroDbContext()))
{
    // Bütün repozitorilər eyni connection istifadə edir
    var satislar = unitOfWork.Satislar.GetAll();
    var mehsullar = unitOfWork.Mehsullar.GetAll();
    var musteriler = unitOfWork.Musteriler.GetAll();
} // Avtomatik dispose
```

## Praktik İstifadə Nümunələri

### Dependency Injection ilə İstifadə
```csharp
// Startup/Program.cs
services.AddScoped<AzAgroDbContext>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<SatisService>();
services.AddScoped<AnbarService>();

// Service constructor
public class AnbarService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public AnbarService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}
```

### Form/Controller-də İstifadə
```csharp
// WinForms - Form kodunda
public partial class SatisForm : Form
{
    private readonly SatisService _satisService;
    
    public SatisForm(SatisService satisService)
    {
        _satisService = satisService;
        InitializeComponent();
    }
    
    private void btnSatisYarat_Click(object sender, EventArgs e)
    {
        try
        {
            var satis = new Satis { /* məlumatlar */ };
            var detallar = GetSatisDetallari();
            
            _satisService.SatisYarat(satis, detallar);
            
            MessageBox.Show("Satış uğurla yaradıldı!", "Uğur", 
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", 
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
```

### Test edilə bilən kod
```csharp
// Unit Test nümunəsi
[Test]
public void SatisYarat_KifayetStoktanSonra_UgurluOlur()
{
    // Arrange
    var mockUnitOfWork = new Mock<IUnitOfWork>();
    var mockAnbarQaliq = new Mock<IAnbarQalikRepository>();
    
    mockAnbarQaliq.Setup(x => x.GetByAnbarVeMehsul(1, 1))
               .Returns(new AnbarQalik { MovcudMiqdar = 100 });
               
    mockUnitOfWork.Setup(x => x.AnbarQaliqlari).Returns(mockAnbarQaliq.Object);
    
    var service = new SatisService(mockUnitOfWork.Object);
    
    // Act & Assert
    Assert.DoesNotThrow(() => service.SatisYarat(satis, detallar));
    mockUnitOfWork.Verify(x => x.Complete(), Times.Once);
}
```

## Xəta İdarəetməsi

### Try-Catch Pattern
```csharp
public async Task<bool> MurakkebEmeliyyat()
{
    try
    {
        // Çoxlu repository əməliyyatları
        _unitOfWork.Satislar.Add(satis);
        _unitOfWork.AnbarQaliqlari.Update(qalik);
        _unitOfWork.MusteriBorclari.Add(borc);
        
        // Hamısını təsdiqlə
        await _unitOfWork.CompleteAsync();
        return true;
    }
    catch (Exception ex)
    {
        // Log xətanı
        _logger.LogError(ex, "Mürəkkəb əməliyyat uğursuz oldu");
        
        // Xəta atılması ilə avtomatik rollback
        throw new BusinessException("Əməliyyat tamamlana bilmədi", ex);
    }
}
```

## Yekun

Unit of Work pattern tətbiq edilməsi ilə:
- ✅ Məlumat bütövlüyü təmin edilir
- ✅ Performans artır  
- ✅ Kod daha təmiz və test edilə bilən olur
- ✅ Xəta idarəetməsi asanlaşır
- ✅ Architecture patterns-ə uyğun həll əldə edilir

Bu pattern POS sistemləri kimi kritik tətbiqlər üçün vacib olmağa davam edəcək!