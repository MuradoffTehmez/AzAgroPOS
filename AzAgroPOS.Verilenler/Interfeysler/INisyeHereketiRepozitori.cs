// Fayl: AzAgroPOS.Verilenler/Interfeysler/INisyeHereketiRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Varliglar;
/// <summary>
/// Bütün nisyə hərəkəti verilənlər bazası əməliyyatları üçün interfeys.
/// Diqqət: Hal-hazırda xüsusi əməliyyatlar əlavə edilməyib, amma gələcəkdə əlavə edilə bilər.
/// Qeyd: Bu interfeys, nisyə hərəkəti verilənlər bazası əməliyyatlarını idarə etmək üçün istifadə olunur və nisyə hərəkəti ilə əlaqəli əməliyyatları asanlaşdırır.
/// Uzunluğu IRepozitori interfeysindən miras alır və nisyə hərəkəti ilə əlaqəli xüsusi əməliyyatları əlavə etmək üçün genişləndirilə bilər.
/// </summary>
public interface INisyeHereketiRepozitori : IRepozitori<NisyeHereketi>
{
    // Burada nisyə hərəkəti ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Müəyyən bir müştərinin nisyə hərəkətlərini tapmaq, tarix aralığında nisyə hərəkətlərini filtrləmək və s.
}