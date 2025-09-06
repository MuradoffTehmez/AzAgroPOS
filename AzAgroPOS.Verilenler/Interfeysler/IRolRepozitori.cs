// Fayl: AzAgroPOS.Verilenler/Interfeysler/IRolRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Varliglar;

/// <summary>
/// bütün rol verilənlər bazası əməliyyatları üçün interfeys.
/// diqqət: Hal-hazırda xüsusi əməliyyatlar əlavə edilməyib, amma gələcəkdə əlavə edilə bilər.
/// qeyd: Bu interfeys, rol verilənlər bazası əməliyyatlarını idarə etmək üçün istifadə olunur və rol ilə əlaqəli əməliyyatları asanlaşdırır.
/// uzunluğu IRepozitori Rol interfeysindən miras alır və rol ilə əlaqəli xüsusi əməliyyatları əlavə etmək üçün genişləndirilə bilər.
/// </summary>
public interface IRolRepozitori : IRepozitori<Rol>
{
    // Burada rol ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: İstifadəçi rollarını tapmaq, müəyyən bir rola sahib istifadəçiləri filtrləmək və s.
}