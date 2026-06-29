using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;
/// <summary>
/// bütün satış verilənlər bazası əməliyyatları üçün interfeys.
/// diqət: Hal-hazırda xüsusi əməliyyatlar əlavə edilməyib, amma gələcəkdə əlavə edilə bilər.
/// qeyd: Bu interfeys, satış verilənlər bazası əməliyyatlarını idarə etmək üçün istifadə olunur və satış ilə əlaqəli əməliyyatları asanlaşdırır.
/// </summary>
public interface ISatisRepozitori : IRepozitori<Satis>
{
    /// <summary>
    /// Satışı SatisDetallari + Mehsul nested-include ilə gətirir.
    /// Include(s => s.SatisDetallari).ThenInclude(d => d.Mehsul) EF Core zənciri istifadə edir.
    /// </summary>
    Task<Satis?> SatisDetallariIleBirlikdeGetirAsync(int satisId);
}