# Dependency Injection Refactoring Examples

## 1. Məhsul Presenter - Əvvəl və Sonra

### Əvvəl (Constructor Injection ilə):

```csharp
public class MehsulPresenter
{
    private readonly IMehsulIdareetmeView _view;
    private readonly MehsulManager _mehsulManager;
    private readonly KateqoriyaMeneceri _kateqoriyaMeneceri;
    private readonly BrendMeneceri _brendMeneceri;
    private readonly IServiceProvider _serviceProvider;
    private IEnumerable<MehsulDto>? _butunMehsullarCache;

    public MehsulPresenter(IMehsulIdareetmeView view, MehsulManager mehsulManager, IServiceProvider serviceProvider)
    {
        _view = view;
        _mehsulManager = mehsulManager;
        _serviceProvider = serviceProvider;
        // ...
    }
    
    private async Task FormuYukle()
    {
        // Kateqoriyaları yükləyirik
        var kateqoriyaMeneceri = _serviceProvider.GetRequiredService<KateqoriyaMeneceri>();
        var kateqoriyaNetice = await kateqoriyaMeneceri.ButunKateqoriyalariGetirAsync();
        // ...
    }
}
```

### Sonra (Tam DI ilə):

```csharp
public class MehsulPresenter
{
    private readonly IMehsulIdareetmeView _view;
    private readonly MehsulManager _mehsulManager;
    private readonly KateqoriyaMeneceri _kateqoriyaMeneceri;
    private readonly BrendMeneceri _brendMeneceri;
    private readonly TedarukcuMeneceri _tedarukcuMeneceri;
    private IEnumerable<MehsulDto>? _butunMehsullarCache;

    public MehsulPresenter(IMehsulIdareetmeView view, MehsulManager mehsulManager, 
        KateqoriyaMeneceri kateqoriyaMeneceri, BrendMeneceri brendMeneceri, TedarukcuMeneceri tedarukcuMeneceri)
    {
        _view = view;
        _mehsulManager = mehsulManager;
        _kateqoriyaMeneceri = kateqoriyaMeneceri;
        _brendMeneceri = brendMeneceri;
        _tedarukcuMeneceri = tedarukcuMeneceri;
        // ...
    }
    
    private async Task FormuYukle()
    {
        // Kateqoriyaları yükləyirik
        var kateqoriyaNetice = await _kateqoriyaMeneceri.ButunKateqoriyalariGetirAsync();
        // ...
    }
}
```

## 2. Temir Presenter - Əvvəl və Sonra

### Əvvəl (Service Locator Pattern):

```csharp
public class TemirPresenter
{
    private readonly ITemirView _view;
    private readonly TemirManager _temirManager;
    private readonly MusteriManager _musteriManager;
    private readonly IstifadeciManager _istifadeciManager;
    private readonly IServiceProvider _serviceProvider;

    public TemirPresenter(ITemirView view, TemirManager temirManager, MusteriManager musteriManager, 
        IstifadeciManager istifadeciManager, IServiceProvider serviceProvider)
    {
        _view = view;
        _temirManager = temirManager;
        _musteriManager = musteriManager;
        _istifadeciManager = istifadeciManager;
        _serviceProvider = serviceProvider;
        // ...
    }
    
    private void EhtiyatHissəsiElaveEt()
    {
        using (var form = _serviceProvider.GetRequiredService<EhtiyatHissəsiFormu>())
        {
            // ...
        }
    }
}
```

### Sonra (Tam DI ilə):

```csharp
public class TemirPresenter
{
    private readonly ITemirView _view;
    private readonly TemirManager _temirManager;
    private readonly MusteriManager _musteriManager;
    private readonly IstifadeciManager _istifadeciManager;
    private readonly EhtiyatHissəsiFormu _ehtiyatHissəsiFormu;

    public TemirPresenter(ITemirView view, TemirManager temirManager, MusteriManager musteriManager, 
        IstifadeciManager istifadeciManager, EhtiyatHissəsiFormu ehtiyatHissəsiFormu)
    {
        _view = view;
        _temirManager = temirManager;
        _musteriManager = musteriManager;
        _istifadeciManager = istifadeciManager;
        _ehtiyatHissəsiFormu = ehtiyatHissəsiFormu;
        // ...
    }
    
    private void EhtiyatHissəsiElaveEt()
    {
        // Create a new instance of the form for each use
        using (var form = new EhtiyatHissəsiFormu())
        {
            // ...
        }
    }
}
```

## 3. Formlar - Əvvəl və Sonra

### Əvvəl (new ilə yaradılma):

```csharp
// Program.cs-də factory metodları ilə
services.AddTransient<MehsulIdareetmeFormu>(provider =>
{
    var mehsulManager = provider.GetRequiredService<MehsulManager>();
    return new MehsulIdareetmeFormu(mehsulManager, provider);
});

// Formun özü
public partial class MehsulIdareetmeFormu : BazaForm, IMehsulIdareetmeView
{
    public MehsulIdareetmeFormu(MehsulManager mehsulManager, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _presenter = new MehsulPresenter(this, mehsulManager, serviceProvider);
        // ...
    }
}
```

### Sonra (Tam DI ilə):

```csharp
// Program.cs-də sadə qeydiyyat
services.AddTransient<MehsulIdareetmeFormu>();

// Formun özü
public partial class MehsulIdareetmeFormu : BazaForm, IMehsulIdareetmeView
{
    public MehsulIdareetmeFormu(MehsulManager mehsulManager, MehsulPresenter mehsulPresenter, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _presenter = mehsulPresenter;
        // ...
    }
}
```

## 4. Program.cs - Factory metodların silinməsi

### Əvvəl:

```csharp
services.AddTransient<MehsulIdareetmeFormu>(provider =>
{
    var mehsulManager = provider.GetRequiredService<MehsulManager>();
    return new MehsulIdareetmeFormu(mehsulManager, provider);
});
services.AddTransient<MusteriIdareetmeFormu>(provider =>
{
    var musteriManager = provider.GetRequiredService<MusteriManager>();
    return new MusteriIdareetmeFormu(musteriManager, provider);
});
services.AddTransient<SatisFormu>(provider =>
{
    var satisManager = provider.GetRequiredService<SatisManager>();
    var mehsulManager = provider.GetRequiredService<MehsulManager>();
    var musteriManager = provider.GetRequiredService<MusteriManager>();
    return new SatisFormu(satisManager, mehsulManager, musteriManager);
});
```

### Sonra:

```csharp
services.AddTransient<MehsulIdareetmeFormu>();
services.AddTransient<MusteriIdareetmeFormu>();
services.AddTransient<SatisFormu>();
```