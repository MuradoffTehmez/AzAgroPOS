// Fayl: AzAgroPOS.Verilenler/Interfeysler/IMehsulRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Varliglar;
/// <summary>
/// Bütün məhsul verilənlər bazası əməliyyatları üçün interfeys.
/// Uzunluğu IRepozitori  interfeysindən miras alır və məhsul ilə əlaqəli xüsusi əməliyyatları əlavə etmək üçün genişləndirilə bilər.
/// Diqqət: Hal-hazırda xüsusi əməliyyatlar əlavə edilməyib, amma gələcəkdə əlavə edilə bilər.
/// Qeyd: Bu interfeys, məhsul verilənlər bazası əməliyyatlarını idarə etmək üçün istifadə olunur və məhsul ilə əlaqəli əməliyyatları asanlaşdırır.
/// </summary>
public interface IMehsulRepozitori : IRepozitori<Mehsul> 
{
    // Burada məhsul ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Stoka görə məhsulları tapmaq, kateqoriyaya görə məhsulları filtrləmək və s.
}