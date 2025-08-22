// Fayl: AzAgroPOS.Verilenler/Interfeysler/ISatisRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Varliglar;

/// <summary>
/// bütün satış verilənlər bazası əməliyyatları üçün interfeys.
/// diqət: Hal-hazırda xüsusi əməliyyatlar əlavə edilməyib, amma gələcəkdə əlavə edilə bilər.
/// qeyd: Bu interfeys, satış verilənlər bazası əməliyyatlarını idarə etmək üçün istifadə olunur və satış ilə əlaqəli əməliyyatları asanlaşdırır.
/// uzunluğu IRepozitori<Satis> interfeysindən miras alır və satış ilə əlaqəli xüsusi əməliyyatları əlavə etmək üçün genişləndirilə bilər.
/// </summary>
public interface ISatisRepozitori : IRepozitori<Satis> 
{
    // Burada satış ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Müəyyən bir tarixdəki satışları tapmaq, istifadəçiyə görə satışları filtrləmək və s.
}