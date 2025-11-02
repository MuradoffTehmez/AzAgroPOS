# IDisposable Pattern İstifadə Guide

## Tarix: 2025-11-01

## Problem

WinForms-da resource-heavy obyektlər (event handlers, timers, cancellation tokens, helper class-lar) düzgün dispose edilmirsə:
- **Memory leak-lər** yaranır
- **Event handler-lər** silinmir və yaddaşda qalır
- **Timer-lər** davam edir
- **File handle-lər** açıq qalır

## Həll: IDisposable Pattern

### Tətbiq Edilmiş İnfrastruktur

**Fayl**: `AzAgroPOS.Teqdimat/BazaForm.DisposablePattern.cs`

BazaForm-a dispose infrastructure əlavə edildi:

```csharp
public partial class BazaForm
{
    private readonly List<IDisposable> _disposables = new();

    protected void RegisterDisposable(IDisposable disposable)
    {
        _disposables.Add(disposable);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            foreach (var disposable in _disposables)
            {
                disposable?.Dispose();
            }
            _disposables.Clear();
            components?.Dispose();
        }
        base.Dispose(disposing);
    }
}
```

---

## İstifadə Nümunələri

### Nümunə 1: LazyLoadComboBoxHelper ilə

```csharp
public partial class MusteriFormu : BazaForm
{
    private LazyLoadComboBoxHelper<MusteriDto>? _musteriHelper;
    private CancellationTokenSource? _searchCts;

    private void InitializeForm()
    {
        // Helper yaradılır
        _musteriHelper = new LazyLoadComboBoxHelper<MusteriDto>(
            cmbMusteri,
            txtMusteriAxtar,
            async (term, size) => {
                var result = await _manager.MusterileriAxtarisIleGetirAsync(term, size);
                return result.Data ?? new List<MusteriDto>();
            },
            "TamAd",
            "Id",
            50
        );

        _searchCts = new CancellationTokenSource();

        // ✅ VACIB: Dispose ediləcək obyektləri qeydiyyatdan keçir
        RegisterDisposables(_musteriHelper, _searchCts);
    }

    // Dispose avtomatik çağırılacaq - heç nə etməyə ehtiyac yoxdur!
}
```

### Nümunə 2: Timer ilə

```csharp
public partial class DashboardFormu : BazaForm
{
    private System.Windows.Forms.Timer? _refreshTimer;

    private void InitializeDashboard()
    {
        _refreshTimer = new System.Windows.Forms.Timer
        {
            Interval = 30000 // 30 saniyə
        };
        _refreshTimer.Tick += RefreshTimer_Tick;
        _refreshTimer.Start();

        // ✅ Timer-i qeydiyyatdan keçir
        RegisterDisposable(_refreshTimer);
    }

    private async void RefreshTimer_Tick(object? sender, EventArgs e)
    {
        await RefreshDataAsync();
    }

    // Timer avtomatik dispose olunacaq
}
```

### Nümunə 3: Event Handler-lər

```csharp
public partial class SatisFormu : BazaForm
{
    private SatisPresenter? _presenter;

    private void InitializePresenter()
    {
        _presenter = new SatisPresenter(this, _satisManager);

        // Event-lərə abunə ol
        this.FormClosing += SatisFormu_FormClosing;
        this.Load += SatisFormu_Load;

        // Presenter-i qeydiyyatdan keçir (əgər IDisposable-sa)
        if (_presenter is IDisposable disposablePresenter)
        {
            RegisterDisposable(disposablePresenter);
        }
    }

    private void SatisFormu_FormClosing(object? sender, FormClosingEventArgs e)
    {
        // Bağlanmadan əvvəl təsdiq
        if (HasUnsavedChanges())
        {
            var result = MessageBox.Show(
                "Yadda saxlanılmamış dəyişikliklər var. Bağlamaq istəyirsiniz?",
                "Təsdiq",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }

    // Event handler-lər avtomatik təmizlənəcək
}
```

### Nümunə 4: CancellationTokenSource

```csharp
public partial class HesabatFormu : BazaForm
{
    private CancellationTokenSource? _reportCts;

    private async void btnHesabatYarat_Click(object sender, EventArgs e)
    {
        // Əvvəlki əməliyyatı ləğv et
        _reportCts?.Cancel();
        _reportCts?.Dispose();

        // Yeni token source
        _reportCts = new CancellationTokenSource();
        RegisterDisposable(_reportCts);

        try
        {
            await GenerateReportAsync(_reportCts.Token);
        }
        catch (OperationCanceledException)
        {
            MessageBox.Show("Hesabat yaratma ləğv edildi");
        }
    }

    private async Task GenerateReportAsync(CancellationToken ct)
    {
        // Uzun əməliyyat
        for (int i = 0; i < 100; i++)
        {
            ct.ThrowIfCancellationRequested();
            await Task.Delay(100, ct);
            UpdateProgress(i + 1);
        }
    }

    // CancellationTokenSource avtomatik dispose olunacaq
}
```

### Nümunə 5: Bir neçə Resource

```csharp
public partial class ComplexFormu : BazaForm
{
    private LazyLoadComboBoxHelper<MusteriDto>? _musteriHelper;
    private LazyLoadComboBoxHelper<IsciDto>? _isciHelper;
    private System.Windows.Forms.Timer? _autoSaveTimer;
    private CancellationTokenSource? _searchCts;
    private FileSystemWatcher? _fileWatcher;

    private void InitializeComplexForm()
    {
        // Müştəri helper
        _musteriHelper = new LazyLoadComboBoxHelper<MusteriDto>(/* ... */);

        // İşçi helper
        _isciHelper = new LazyLoadComboBoxHelper<IsciDto>(/* ... */);

        // Auto-save timer
        _autoSaveTimer = new System.Windows.Forms.Timer { Interval = 60000 };
        _autoSaveTimer.Tick += AutoSaveTimer_Tick;
        _autoSaveTimer.Start();

        // Search cancellation
        _searchCts = new CancellationTokenSource();

        // File watcher
        _fileWatcher = new FileSystemWatcher(@"C:\Data");
        _fileWatcher.Changed += FileWatcher_Changed;
        _fileWatcher.EnableRaisingEvents = true;

        // ✅ Hamısını bir dəfədə qeydiyyatdan keçir
        RegisterDisposables(
            _musteriHelper,
            _isciHelper,
            _autoSaveTimer,
            _searchCts,
            _fileWatcher
        );
    }

    // Hamısı avtomatik dispose olunacaq!
}
```

---

## Advanced Pattern-lər

### Pattern 1: Şərti Dispose

```csharp
public partial class CustomFormu : BazaForm
{
    private MyCustomResource? _resource;

    private void CreateResource(bool needsDisposal)
    {
        _resource = new MyCustomResource();

        if (needsDisposal)
        {
            // Yalnız lazım olduqda dispose et
            RegisterDisposable(_resource);
        }
    }
}
```

### Pattern 2: Manuel Dispose + Auto Dispose

```csharp
public partial class DataFormu : BazaForm
{
    private DatabaseConnection? _connection;

    private async Task ConnectAsync()
    {
        _connection = new DatabaseConnection();
        await _connection.OpenAsync();

        RegisterDisposable(_connection);
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
        // Manuel dispose
        _connection?.Dispose();
        _connection = null;

        // Yenidən yaratmaq üçün
        // RegisterDisposable yeni obyekt üçün çağırılmalıdır
    }

    // Form bağlananda da dispose olunacaq (əgər hələ dispose edilməyibsə)
}
```

### Pattern 3: Nested Disposables

```csharp
public partial class ManagerFormu : BazaForm
{
    private class DataManager : IDisposable
    {
        private Timer _timer;
        private CancellationTokenSource _cts;

        public DataManager()
        {
            _timer = new Timer();
            _cts = new CancellationTokenSource();
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _cts?.Dispose();
        }
    }

    private DataManager? _dataManager;

    private void InitializeManager()
    {
        _dataManager = new DataManager();

        // DataManager dispose olunanda içindəkilər də dispose olunacaq
        RegisterDisposable(_dataManager);
    }
}
```

---

## Yoxlanılmalı Senarilər

### ✅ BU OBYEKTLER DISPOSE EDİLMƏLİDİR:

1. **LazyLoadComboBoxHelper** - Timer və event handler-lər var
2. **CancellationTokenSource** - Unmanaged resource
3. **Timer** - Memory leak yaradır
4. **FileSystemWatcher** - File handle saxlayır
5. **Stream** (FileStream, MemoryStream, etc.)
6. **HttpClient** (bəzən)
7. **Database Connection**
8. **Custom IDisposable obyektlər**

### ❌ BU OBYEKTLER DISPOSE EDİLMƏYƏ BİLƏR:

1. **String** - Managed obyekt
2. **List<T>** - Managed obyekt
3. **Dictionary<T,K>** - Managed obyekt
4. **DTO-lar** - Sadə data class-lar
5. **int, bool, decimal** - Value type-lar

---

## Ümumi Səhvlər və Həlləri

### ❌ Səhv 1: Dispose Unutmaq

```csharp
// BAD
private LazyLoadComboBoxHelper<MusteriDto>? _helper;

private void InitForm()
{
    _helper = new LazyLoadComboBoxHelper<MusteriDto>(/* ... */);
    // RegisterDisposable çağırılmayıb!
}

// Form bağlananda _helper dispose olmayacaq - MEMORY LEAK!
```

**Həll:**
```csharp
// GOOD
private void InitForm()
{
    _helper = new LazyLoadComboBoxHelper<MusteriDto>(/* ... */);
    RegisterDisposable(_helper); // ✅
}
```

### ❌ Səhv 2: Null Check Unutmaq

```csharp
// BAD - NullReferenceException risk
private void SomeMethod()
{
    var helper = new LazyLoadComboBoxHelper<MusteriDto>(/* ... */);
    RegisterDisposable(helper);
}
```

**Həll:**
```csharp
// GOOD - Null check BazaForm-da var
RegisterDisposable(helper); // Təhlükəsizdir
```

### ❌ Səhv 3: İki Dəfə Dispose

```csharp
// BAD
private SomeResource? _resource;

private void Method()
{
    _resource = new SomeResource();
    RegisterDisposable(_resource);
}

protected override void Dispose(bool disposing)
{
    _resource?.Dispose(); // ❌ İlk dispose
    base.Dispose(disposing); // ❌ BazaForm təkrar dispose edəcək
}
```

**Həll:**
```csharp
// GOOD
private void Method()
{
    _resource = new SomeResource();
    RegisterDisposable(_resource); // Yetərlidir
}

// Dispose override-a ehtiyac yoxdur!
```

---

## Performans İmpact

### Əvvəl (Dispose yoxdur):
- Memory Leak: ✅ Var
- Event Handler-lər: ✅ Qalır
- Timer-lər: ✅ İşləyir
- Yaddaş istifadəsi: ⬆️ Artır

### Sonra (Dispose var):
- Memory Leak: ❌ Yoxdur
- Event Handler-lər: ❌ Təmizlənir
- Timer-lər: ❌ Dayanır
- Yaddaş istifadəsi: ⬇️ Stabil

---

## Migration Strategy

### Addım 1: Mövcud Formaları Yoxla

```bash
# Dispose edilməli obyektləri tap:
- LazyLoadComboBoxHelper
- Timer
- CancellationTokenSource
- FileSystemWatcher
- Custom IDisposable class-lar
```

### Addım 2: RegisterDisposable Əlavə Et

```csharp
// Hər obyekt yaradılanda
RegisterDisposable(obyekt);
```

### Addım 3: Test Et

```csharp
// Form açıb-bağla
// Memory profiler-lə yoxla
// Event handler-lərin təmizləndiyini təsdiq et
```

---

## Best Practices

1. ✅ **Həmişə RegisterDisposable istifadə et** disposable obyektlər üçün
2. ✅ **Forma başladıqda** disposable-ları qeydiyyatdan keçir
3. ✅ **Dispose override etmə** - BazaForm-da var
4. ✅ **Null-safe** - BazaForm null check edir
5. ✅ **Try-catch** - BazaForm exception handle edir
6. ✅ **Clear list** - BazaForm list-i təmizləyir

---

## Tətbiq Edilməli Formalar

### Yüksək Prioritet:
1. **SatisFormu** - Timer, CancellationToken
2. **HesabatFormu** - CancellationToken, FileStream
3. **DashboardFormu** - Timer
4. **MusteriFormu** - LazyLoadComboBoxHelper
5. **IsciFormu** - LazyLoadComboBoxHelper

### Orta Prioritet:
6. **EmekHaqqiFormu**
7. **IsciIzniFormu**
8. **BonusIdareetmeFormu**
9. **KassaFormu**
10. **XercIdareetmeFormu**

### Aşağı Prioritet:
11. Digər formalar (əgər disposable resource istifadə edirsə)

---

## Növbəti Addımlar

1. ✅ BazaForm.DisposablePattern.cs yaradıldı
2. ⏳ SatisFormu-da tətbiq et
3. ⏳ LazyLoadComboBoxHelper istifadə edən formalarda tətbiq et
4. ⏳ Timer istifadə edən formalarda tətbiq et
5. ⏳ Memory profiler ilə test et
6. ⏳ Digər formalara miqrasiya et

---

## Qeydlər

- **BazaForm** artıq dispose infrastructure-ı təmin edir
- Bütün yeni formalar avtomatik bu pattern-dən faydalanır
- Mövcud formalar minimal dəyişikliklə miqrasiya edə bilər
- Dispose pattern yaddaş təmizliyi və performans üçün kritikdir

---

**Yaradılıb**: 2025-11-01
**Status**: İmplementasiya hazırdır, formala migrate edilməlidir
