# WinForms Pagination Implementation Guide

## Overview
This document provides a comprehensive guide for implementing pagination in the AzAgroPOS WinForms application. 18 out of 25 managers now have pagination methods, and the UI needs to be updated to use these methods instead of loading all data at once.

## Problem Statement
- Forms currently load ALL data using methods like `ButunMehsullariGetirAsync()`
- This causes UI freeze with 5000+ records
- Pagination methods (`SehifelenmisGetirAsync`) are available but not being used

##Pagination Architecture

### Core Classes

**SehifeParametrleri** (`AzAgroPOS.Mentiq.Uslublar.SehifeParametrleri`)
```csharp
public class SehifeParametrleri
{
    public int SehifeNomresi { get; set; } = 1;  // Page number (1-based)
    public int SehifeOlcusu { get; set; } = 20;  // Page size (max 100)
}
```

**SehifelenmisMelumat<T>** (`AzAgroPOS.Mentiq.Uslublar.SehifelenmisMelumat`)
```csharp
public class SehifelenmisMelumat<T>
{
    public int CariSehife { get; set; }           // Current page number
    public int UmumiSehifeSayi { get; set; }      // Total pages
    public int SehifeOlcusu { get; set; }         // Page size
    public int UmumiQeydSayi { get; set; }        // Total record count
    public IEnumerable<T> Melumatlar { get; set; } // Current page data
    public bool EvvelkiSehifeVar { get; }         // Has previous page
    public bool NovbetiSehifeVar { get; }         // Has next page
}
```

### Available Pagination Methods

The following managers have pagination methods:

1. **MehsulManager** - `MehsullariSehifelenmisGetirAsync(SehifeParametrleri)`
2. **MusteriManager** - `MusterileriSehifelenmisGetirAsync(SehifeParametrleri)`
3. **AlisManager** - Multiple methods:
   - `TedarukculeriSehifelenmisGetirAsync(SehifeParametrleri)`
   - `AlisSifarisleriniSehifelenmisGetirAsync(SehifeParametrleri)`
   - `AlisSenetleriniSehifelenmisGetirAsync(SehifeParametrleri)`
   - `TedarukcuOdemeleriniSehifelenmisGetirAsync(SehifeParametrleri)`
4. **IsciManager** - `IscileriSehifelenmisGetirAsync(SehifeParametrleri)`
5. **EmekHaqqiManager** - `EmekHaqqilariSehifelenmisGetirAsync(SehifeParametrleri)`
6. **TemirManager** - `TemirSifarisleriniSehifelenmisGetirAsync(SehifeParametrleri)`
7. And 11 more...

## Implementation Pattern

### Required UI Controls (Must be added to Designer files)

For each form with a DataGridView, add the following controls:

```csharp
// Bottom panel for pagination controls
private System.Windows.Forms.Panel pnlPagination;
private MaterialSkin.Controls.MaterialButton btnEvvelki;
private MaterialSkin.Controls.MaterialButton btnNovbeti;
private System.Windows.Forms.Label lblMelumat;
private System.Windows.Forms.ComboBox cmbSehifeOlcusu;
private System.Windows.Forms.Label lblSehifeOlcusu;
```

**Layout Example:**
```
[<<Əvvəlki] [Səhifə 1/45 - Ümumi: 2234] [Növbəti>>] [Səhifə ölçüsü: [▼20|50|100]]
```

### Form-Level Variables

Add these private fields to each form:

```csharp
private int _cariSehife = 1;
private int _sehifeOlcusu = 50;
private int _umumiQeydSayi = 0;
```

### Implementation Steps

#### For Forms WITH Presenters (MVP Pattern)

**Example: MehsulIdareetmeFormu**

**Step 1: Update the Presenter**

File: `AzAgroPOS.Teqdimat\Teqdimatcilar\MehsulPresenter.cs`

```csharp
public class MehsulPresenter
{
    private IMehsulIdareetmeView _view;
    private readonly MehsulManager _mehsulManager;

    // Add pagination state
    private int _cariSehife = 1;
    private int _sehifeOlcusu = 50;
    private IEnumerable<MehsulDto>? _cariSehifeCache; // For search

    // Update FormuYukle to use pagination
    private async Task FormuYukle()
    {
        await MehsullariYukle();
        // ... other initialization
    }

    private async Task MehsullariYukle()
    {
        var parametrler = new SehifeParametrleri
        {
            SehifeNomresi = _cariSehife,
            SehifeOlcusu = _sehifeOlcusu
        };

        var netice = await _mehsulManager.MehsullariSehifelenmisGetirAsync(parametrler);

        if (netice.UgurluDur && netice.Data != null)
        {
            var sehifelenmis = netice.Data;
            _cariSehifeCache = sehifelenmis.Melumatlar;

            // Display data
            _view.MehsullariGoster(sehifelenmis.Melumatlar);

            // Update pagination info
            _view.PaginationMelumatiniYenile(
                _cariSehife,
                sehifelenmis.UmumiSehifeSayi,
                sehifelenmis.UmumiQeydSayi,
                sehifelenmis.EvvelkiSehifeVar,
                sehifelenmis.NovbetiSehifeVar
            );
        }
    }

    // Add pagination navigation methods
    public async Task EvvelkiSehife()
    {
        if (_cariSehife > 1)
        {
            _cariSehife--;
            await MehsullariYukle();
        }
    }

    public async Task NovbetiSehife()
    {
        _cariSehife++;
        await MehsullariYukle();
    }

    public async Task SehifeOlcusunuDeyis(int yeniOlcu)
    {
        _sehifeOlcusu = yeniOlcu;
        _cariSehife = 1; // Reset to first page
        await MehsullariYukle();
    }

    // Update search to work with current page
    private void AxtarisEt()
    {
        if (_cariSehifeCache == null) return;

        var axtarisMetni = _view.AxtarisMetni.ToLower();
        var filterlenmis = string.IsNullOrWhiteSpace(axtarisMetni)
            ? _cariSehifeCache
            : _cariSehifeCache.Where(m =>
                m.Ad.ToLower().Contains(axtarisMetni) ||
                m.StokKodu.ToLower().Contains(axtarisMetni) ||
                m.Barkod.ToLower().Contains(axtarisMetni));

        _view.MehsullariGoster(filterlenmis);
    }
}
```

**Step 2: Update the View Interface**

File: `AzAgroPOS.Teqdimat\Interfeysler\IMehsulIdareetmeView.cs`

```csharp
public interface IMehsulIdareetmeView
{
    // Existing properties...

    // Add pagination events
    event EventHandler EvvelkiSehife_Istek;
    event EventHandler NovbetiSehife_Istek;
    event EventHandler<int> SehifeOlcusunuDeyis_Istek;

    // Add pagination update method
    void PaginationMelumatiniYenile(
        int cariSehife,
        int umumiSehifeSayi,
        int umumiQeydSayi,
        bool evvelkiVar,
        bool novbetiVar);
}
```

**Step 3: Update the Form**

File: `AzAgroPOS.Teqdimat\MehsulIdareetmeFormu.cs`

```csharp
public partial class MehsulIdareetmeFormu : BazaForm, IMehsulIdareetmeView
{
    private readonly MehsulPresenter _presenter;

    // Implement new interface members
    public event EventHandler EvvelkiSehife_Istek;
    public event EventHandler NovbetiSehife_Istek;
    public event EventHandler<int> SehifeOlcusunuDeyis_Istek;

    public MehsulIdareetmeFormu(/* ... */)
    {
        InitializeComponent();
        // ... existing code ...

        // Wire up pagination events
        btnEvvelki.Click += (s, e) => EvvelkiSehife_Istek?.Invoke(s, e);
        btnNovbeti.Click += (s, e) => NovbetiSehife_Istek?.Invoke(s, e);
        cmbSehifeOlcusu.SelectedIndexChanged += (s, e) =>
        {
            if (int.TryParse(cmbSehifeOlcusu.SelectedItem?.ToString(), out int olcu))
            {
                SehifeOlcusunuDeyis_Istek?.Invoke(this, olcu);
            }
        };

        // Initialize page size combo
        cmbSehifeOlcusu.Items.AddRange(new object[] { 20, 50, 100 });
        cmbSehifeOlcusu.SelectedItem = 50;
    }

    public void PaginationMelumatiniYenile(
        int cariSehife,
        int umumiSehifeSayi,
        int umumiQeydSayi,
        bool evvelkiVar,
        bool novbetiVar)
    {
        lblMelumat.Text = $"Səhifə {cariSehife}/{umumiSehifeSayi} - Ümumi: {umumiQeydSayi}";
        btnEvvelki.Enabled = evvelkiVar;
        btnNovbeti.Enabled = novbetiVar;
    }
}
```

**Step 4: Update Presenter Event Subscriptions**

In `MehsulPresenter.SubscribeToViewEvents()`:

```csharp
private void SubscribeToViewEvents()
{
    // ... existing events ...
    _view.EvvelkiSehife_Istek += async (s, e) => await EvvelkiSehife();
    _view.NovbetiSehife_Istek += async (s, e) => await NovbetiSehife();
    _view.SehifeOlcusunuDeyis_Istek += async (s, e) => await SehifeOlcusunuDeyis(e);
}
```

#### For Forms WITHOUT Presenters (Direct Manager Access)

**Example: EmekHaqqiFormu**

File: `AzAgroPOS.Teqdimat\EmekHaqqiFormu.cs`

```csharp
public partial class EmekHaqqiFormu : BazaForm
{
    private readonly EmekHaqqiManager _emekHaqqiManager;

    // Add pagination state
    private int _cariSehife = 1;
    private int _sehifeOlcusu = 50;
    private int _umumiQeydSayi = 0;

    public EmekHaqqiFormu(EmekHaqqiManager emekHaqqiManager, /* ... */)
    {
        InitializeComponent();
        _emekHaqqiManager = emekHaqqiManager;

        // Initialize pagination controls
        InitializePaginationControls();
    }

    private void InitializePaginationControls()
    {
        // Wire up events
        btnEvvelki.Click += async (s, e) => await EvvelkiSehife();
        btnNovbeti.Click += async (s, e) => await NovbetiSehife();
        cmbSehifeOlcusu.SelectedIndexChanged += async (s, e) =>
        {
            if (int.TryParse(cmbSehifeOlcusu.SelectedItem?.ToString(), out int olcu))
            {
                _sehifeOlcusu = olcu;
                _cariSehife = 1;
                await EmekHaqqiTarixcesiniYukle();
            }
        };

        // Initialize combo
        cmbSehifeOlcusu.Items.AddRange(new object[] { 20, 50, 100 });
        cmbSehifeOlcusu.SelectedItem = 50;
    }

    /// <summary>
    /// Əmək haqqı tarixçəsini səhifələnmiş şəkildə yüklə
    /// </summary>
    private async Task EmekHaqqiTarixcesiniYukle()
    {
        try
        {
            var parametrler = new SehifeParametrleri
            {
                SehifeNomresi = _cariSehife,
                SehifeOlcusu = _sehifeOlcusu
            };

            var netice = await _emekHaqqiManager.EmekHaqqilariSehifelenmisGetirAsync(parametrler);

            if (netice.UgurluDur && netice.Data != null)
            {
                var sehifelenmis = netice.Data;

                // Display data
                dgvEmekHaqqlari.DataSource = sehifelenmis.Melumatlar.ToList();
                FormatGrid();

                // Update pagination info
                _umumiQeydSayi = sehifelenmis.UmumiQeydSayi;
                lblMelumat.Text = $"Səhifə {_cariSehife}/{sehifelenmis.UmumiSehifeSayi} - Ümumi: {_umumiQeydSayi}";

                btnEvvelki.Enabled = sehifelenmis.EvvelkiSehifeVar;
                btnNovbeti.Enabled = sehifelenmis.NovbetiSehifeVar;
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Əmək Haqqı Tarixçəsi");
        }
    }

    private async Task EvvelkiSehife()
    {
        if (_cariSehife > 1)
        {
            _cariSehife--;
            await EmekHaqqiTarixcesiniYukle();
        }
    }

    private async Task NovbetiSehife()
    {
        _cariSehife++;
        await EmekHaqqiTarixcesiniYukle();
    }
}
```

## Critical Forms to Update (Priority Order)

### High Priority (10 forms)

1. **MehsulIdareetmeFormu.cs** (HAS PRESENTER)
   - Manager: `MehsulManager.MehsullariSehifelenmisGetirAsync()`
   - Presenter: `MehsulPresenter`
   - Impact: CRITICAL - Most used form, 5000+ products

2. **SatisFormu.cs** (HAS PRESENTER)
   - Manager: `MehsulManager.MehsullariSehifelenmisGetirAsync()`
   - Presenter: `SatisPresenter`
   - Use case: Product search during sales
   - Note: Only paginate product search, not cart

3. **MusteriIdareetmeFormu.cs** (HAS PRESENTER)
   - Manager: `MusteriManager.MusterileriSehifelenmisGetirAsync()`
   - Presenter: `MusteriPresenter`

4. **TedarukcuIdareetmeFormu.cs** (HAS PRESENTER)
   - Manager: `AlisManager.TedarukculeriSehifelenmisGetirAsync()`
   - Presenter: `TedarukcuPresenter`

5. **IsciIdareetmeFormu.cs** (HAS PRESENTER)
   - Manager: `IsciManager.IscileriSehifelenmisGetirAsync()`
   - Presenter: `IsciPresenter`

6. **EmekHaqqiFormu.cs** (NO PRESENTER - DIRECT ACCESS)
   - Manager: `EmekHaqqiManager.EmekHaqqilariSehifelenmisGetirAsync()`
   - Note: No presenter, update form directly

7. **AlisSifarisFormu.cs** (HAS PRESENTER)
   - Manager: `AlisManager.AlisSifarisleriniSehifelenmisGetirAsync()`
   - Presenter: `AlisSifarisPresenter`

8. **AlisSenedFormu.cs** (HAS PRESENTER)
   - Manager: `AlisManager.AlisSenetleriniSehifelenmisGetirAsync()`
   - Presenter: `AlisSenedPresenter`

9. **TedarukcuOdemeFormu.cs** (HAS PRESENTER)
   - Manager: `AlisManager.TedarukcuOdemeleriniSehifelenmisGetirAsync()`
   - Presenter: `TedarukcuOdemePresenter`

10. **TemirIdareetmeFormu.cs** (HAS PRESENTER)
    - Manager: `TemirManager.TemirSifarisleriniSehifelenmisGetirAsync()`
    - Presenter: `TemirPresenter`

## UI Design Recommendations

### MaterialSkin Theme

Use MaterialButton for navigation:

```csharp
// Previous button
var btnEvvelki = new MaterialButton
{
    Text = "❮❮ Əvvəlki",
    Type = MaterialButton.MaterialButtonType.Contained,
    AutoSize = false,
    Size = new Size(120, 36),
    UseAccentColor = false
};

// Next button
var btnNovbeti = new MaterialButton
{
    Text = "Növbəti ❯❯",
    Type = MaterialButton.MaterialButtonType.Contained,
    AutoSize = false,
    Size = new Size(120, 36),
    UseAccentColor = false
};

// Info label
var lblMelumat = new Label
{
    Text = "Səhifə 1/1 - Ümumi: 0",
    AutoSize = true,
    Font = new Font("Roboto", 10F),
    Margin = new Padding(10, 0, 10, 0)
};

// Page size selector
var cmbSehifeOlcusu = new ComboBox
{
    DropDownStyle = ComboBoxStyle.DropDownList,
    Width = 80
};
cmbSehifeOlcusu.Items.AddRange(new object[] { 20, 50, 100 });
cmbSehifeOlcusu.SelectedItem = 50;
```

### Layout

Place pagination controls at the bottom of the DataGridView:

```
┌─────────────────────────────────────────┐
│          DataGridView (dgv...)          │
│                                         │
│         [Data rows here...]             │
│                                         │
├─────────────────────────────────────────┤
│ [❮❮ Əvvəlki] [Səhifə 1/45 - Ümumi:     │
│  2234] [Növbəti ❯❯] [Səhifə ölçüsü: 50▼]│
└─────────────────────────────────────────┘
```

## Testing Checklist

After implementing pagination for each form:

- [ ] Form loads first page correctly
- [ ] "Previous" button is disabled on page 1
- [ ] "Next" button is disabled on last page
- [ ] Page info label shows correct information
- [ ] Changing page size resets to page 1
- [ ] Search works on current page
- [ ] Navigation between pages works smoothly
- [ ] UI doesn't freeze with large datasets
- [ ] Memory usage is reduced

## Performance Benefits

Expected improvements after implementation:

- **Load time**: From 5-10 seconds → 0.5-1 second
- **Memory usage**: From 200MB+ → 20-30MB
- **UI responsiveness**: No freezing
- **User experience**: Immediate feedback

## Common Pitfalls to Avoid

1. **Don't forget to reset page to 1 when:**
   - Changing page size
   - Applying new filters
   - Performing search

2. **Search/Filter handling:**
   - Option A: Search within current page only (simple)
   - Option B: Search across all pages (requires server-side search support)

3. **State management:**
   - Keep track of current page and page size
   - Update pagination info after every data load
   - Handle edge cases (empty results, single page)

4. **Event handling:**
   - Unsubscribe from DataGridView events before updating data source
   - Re-subscribe after updating
   - This prevents duplicate event firing

## Files That Need UI Designer Changes

The following `.Designer.cs` files need pagination controls added:

1. `MehsulIdareetmeFormu.Designer.cs`
2. `SatisFormu.Designer.cs` (for product search panel)
3. `MusteriIdareetmeFormu.Designer.cs`
4. `TedarukcuIdareetmeFormu.Designer.cs`
5. `IsciIdareetmeFormu.Designer.cs`
6. `EmekHaqqiFormu.Designer.cs`
7. `AlisSifarisFormu.Designer.cs`
8. `AlisSenedFormu.Designer.cs`
9. `TedarukcuOdemeFormu.Designer.cs`
10. `TemirIdareetmeFormu.Designer.cs`

**Note:** Designer files must be edited using Visual Studio's Form Designer. Manual editing is not recommended.

## Next Steps

1. **Phase 1:** Add pagination UI controls to all 10 critical forms using Visual Studio Designer
2. **Phase 2:** Update presenter classes with pagination logic
3. **Phase 3:** Update form code-behind to implement pagination interface
4. **Phase 4:** Test each form thoroughly
5. **Phase 5:** Update remaining 15 forms (medium/low priority)

## Questions & Support

If you encounter issues:

1. Check that the Manager has a `SehifelenmisGetirAsync` method
2. Verify `SehifeParametrleri` is being passed correctly
3. Ensure UI controls are properly wired to events
4. Test with small page sizes (10-20) first

---

**Generated:** 2025-11-01
**Last Updated:** 2025-11-01
**Status:** Ready for implementation
