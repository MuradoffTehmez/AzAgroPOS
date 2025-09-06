// Fayl: AzAgroPOS.Verilenler/Interfeysler/INovbeRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Varliglar;
/// <summary>
/// Bütün növbə verilənlər bazası əməliyyatları üçün interfeys.
/// diqqət: Hal-hazırda xüsusi əməliyyatlar əlavə edilməyib, amma gələcəkdə əlavə edilə bilər.
/// qeyd: Bu interfeys, növbə verilənlər bazası əməliyyatlarını idarə etmək üçün istifadə olunur və növbə ilə əlaqəli əməliyyatları asanlaşdırır.
/// uzunluğu IRepozitori  interfeysindən miras alır və növbə ilə əlaqəli xüsusi əməliyyatları əlavə etmək üçün genişləndirilə bilər.
/// </summary>
public interface INovbeRepozitori : IRepozitori<Novbe> 
{
    /// <summary>
    /// Müəyyən bir işçinin aktiv növbəsini gətirir.
    /// </summary>
    /// <param name="isciId">İşçinin ID-si</param>
    /// <returns>Aktiv növbə və ya null</returns>
    Task<Novbe?> AktivNovbeniGetirAsync(int isciId);
    
    // Burada növbə ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Müəyyən bir tarixdəki növbələri tapmaq, istifadəçiyə görə növbələri filtrləmək və s.
}