// Fayl: AzAgroPOS.Teqdimat/Yardimcilar/LazyLoadComboBoxHelper.cs
namespace AzAgroPOS.Teqdimat.Yardimcilar;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// ComboBox-lar üçün lazy loading və search-before-load funksionallığını təmin edir.
/// Bu helper performans optimallaşdırması üçün tam dataseti yükləmək əvəzinə
/// axtarış əsasında məhdud sayda məlumat yükləyir.
/// </summary>
public class LazyLoadComboBoxHelper<T>
{
    private readonly ComboBox _comboBox;
    private readonly TextBox? _searchTextBox;
    private readonly Func<string, int, Task<List<T>>> _loadDataFunc;
    private readonly string _displayMember;
    private readonly string _valueMember;
    private readonly int _pageSize;
    private CancellationTokenSource? _searchCancellationTokenSource;
    private System.Windows.Forms.Timer? _debounceTimer;
    private const int DebounceMilliseconds = 300;

    /// <summary>
    /// LazyLoadComboBoxHelper-i başlatır
    /// </summary>
    /// <param name="comboBox">Lazy loading tətbiq ediləcək ComboBox</param>
    /// <param name="searchTextBox">Axtarış üçün TextBox (optional)</param>
    /// <param name="loadDataFunc">Məlumat yükləmə funksiyası (search term, page size)</param>
    /// <param name="displayMember">ComboBox-da göstəriləcək property adı</param>
    /// <param name="valueMember">ComboBox-un value property adı</param>
    /// <param name="pageSize">İlkin yükləmə üçün səhifə ölçüsü (default: 50)</param>
    public LazyLoadComboBoxHelper(
        ComboBox comboBox,
        TextBox? searchTextBox,
        Func<string, int, Task<List<T>>> loadDataFunc,
        string displayMember,
        string valueMember,
        int pageSize = 50)
    {
        _comboBox = comboBox ?? throw new ArgumentNullException(nameof(comboBox));
        _searchTextBox = searchTextBox;
        _loadDataFunc = loadDataFunc ?? throw new ArgumentNullException(nameof(loadDataFunc));
        _displayMember = displayMember;
        _valueMember = valueMember;
        _pageSize = pageSize;

        Initialize();
    }

    /// <summary>
    /// Helper-i başlatır və event handler-ləri qeydiyyatdan keçirir
    /// </summary>
    private void Initialize()
    {
        // ComboBox autocomplete ayarları
        _comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        _comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

        // Əgər axtarış TextBox-u varsa, ona event handler əlavə edirik
        if (_searchTextBox != null)
        {
            _searchTextBox.TextChanged += SearchTextBox_TextChanged;
        }

        // ComboBox-a klaviatura dəstəyi üçün event handler
        _comboBox.KeyDown += ComboBox_KeyDown;
        _comboBox.DropDown += ComboBox_DropDown;
    }

    /// <summary>
    /// İlkin məlumatları yükləyir (ilk N qeyd)
    /// </summary>
    public async Task LoadInitialDataAsync(string initialSearchTerm = "")
    {
        try
        {
            var data = await _loadDataFunc(initialSearchTerm, _pageSize);
            UpdateComboBoxDataSource(data);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Məlumat yüklənərkən xəta: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Axtarış TextBox-unun TextChanged eventi
    /// </summary>
    private void SearchTextBox_TextChanged(object? sender, EventArgs e)
    {
        // Debounce ilə axtarış
        _debounceTimer?.Dispose();
        _debounceTimer = new Timer(_ =>
        {
            if (_searchTextBox?.InvokeRequired == true)
            {
                _searchTextBox.Invoke(new Action(async () => await PerformSearchAsync()));
            }
            else
            {
                _ = PerformSearchAsync();
            }
        }, null, DebounceMilliseconds, Timeout.Infinite);
    }

    /// <summary>
    /// ComboBox-un KeyDown eventi - klaviaturadan axtarış üçün
    /// </summary>
    private void ComboBox_KeyDown(object? sender, KeyEventArgs e)
    {
        // Əgər istifadəçi mətn yazırsa və axtarış TextBox-u yoxdursa
        if (_searchTextBox == null && char.IsLetterOrDigit((char)e.KeyCode))
        {
            // ComboBox-un özündə axtarış funksionallığı
            // AutoComplete ilə işləyir
        }
    }

    /// <summary>
    /// ComboBox açılanda məlumat yükləyir (əgər boşdursa)
    /// </summary>
    private void ComboBox_DropDown(object? sender, EventArgs e)
    {
        if (_comboBox.Items.Count == 0)
        {
            _ = LoadInitialDataAsync();
        }
    }

    /// <summary>
    /// Axtarış əməliyyatını həyata keçirir
    /// </summary>
    private async Task PerformSearchAsync()
    {
        try
        {
            // Əvvəlki axtarışı ləğv edirik
            _searchCancellationTokenSource?.Cancel();
            _searchCancellationTokenSource = new CancellationTokenSource();

            var searchTerm = _searchTextBox?.Text ?? _comboBox.Text;

            // Minimum 2 simvol tələb edirik (performans üçün)
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                await LoadInitialDataAsync();
                return;
            }

            if (searchTerm.Length < 2)
            {
                return; // Çox qısa axtarış termini
            }

            var data = await _loadDataFunc(searchTerm, _pageSize);
            UpdateComboBoxDataSource(data);
        }
        catch (OperationCanceledException)
        {
            // Axtarış ləğv edildi, heç nə etməyə ehtiyac yoxdur
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Axtarış xətası: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// ComboBox-un DataSource-unu yeniləyir
    /// </summary>
    private void UpdateComboBoxDataSource(List<T> data)
    {
        if (_comboBox.InvokeRequired)
        {
            _comboBox.Invoke(new Action(() => UpdateComboBoxDataSource(data)));
            return;
        }

        var selectedValue = _comboBox.SelectedValue;

        _comboBox.DataSource = null;
        _comboBox.DataSource = data;
        _comboBox.DisplayMember = _displayMember;
        _comboBox.ValueMember = _valueMember;

        // Əvvəlki seçimi bərpa edirik (əgər hələ də mövcuddursa)
        if (selectedValue != null && data.Any())
        {
            try
            {
                _comboBox.SelectedValue = selectedValue;
            }
            catch
            {
                // Seçim artıq mövcud deyil, xəta olmaz
            }
        }
    }

    /// <summary>
    /// Seçilmiş qiyməti qaytarır
    /// </summary>
    public T? GetSelectedItem()
    {
        return _comboBox.SelectedItem is T item ? item : default;
    }

    /// <summary>
    /// Seçilmiş ID-ni qaytarır (əgər valueMember "Id" dirsə)
    /// </summary>
    public int? GetSelectedId()
    {
        if (_comboBox.SelectedValue is int id)
            return id;
        return null;
    }

    /// <summary>
    /// ComboBox-u təmizləyir
    /// </summary>
    public void Clear()
    {
        _comboBox.DataSource = null;
        _comboBox.Items.Clear();
        _searchTextBox?.Clear();
    }

    /// <summary>
    /// Resource-ları azad edir
    /// </summary>
    public void Dispose()
    {
        _searchCancellationTokenSource?.Cancel();
        _searchCancellationTokenSource?.Dispose();
        _debounceTimer?.Dispose();

        if (_searchTextBox != null)
        {
            _searchTextBox.TextChanged -= SearchTextBox_TextChanged;
        }

        _comboBox.KeyDown -= ComboBox_KeyDown;
        _comboBox.DropDown -= ComboBox_DropDown;
    }
}
