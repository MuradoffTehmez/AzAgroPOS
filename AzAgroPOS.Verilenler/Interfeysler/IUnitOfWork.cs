// Fayl: AzAgroPOS.Verilenler/Interfeysler/IUnitOfWork.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

/// <summary>
/// Verilənlər bazası ilə bütün əməliyyatları vahid bir tranzaksiya altında idarə edir.
/// Repozitorilərə müraciəti təmin edir və dəyişiklikləri yaddaşa yazır.
/// </summary>
public interface IUnitOfWork : IAsyncDisposable
{
    // Hər bir varlıq üçün repozitori interfeysləri burada elan edilir.
    IMehsulRepozitori Mehsullar { get; }
    IMusteriRepozitori Musteriler { get; }
    ISatisRepozitori Satislar { get; }
    IIstifadeciRepozitori Istifadeciler { get; }
    IRolRepozitori Rollar { get; }

    /// <summary>
    /// Edilmiş bütün dəyişiklikləri vahid bir tranzaksiya kimi verilənlər bazasına tətbiq edir.
    /// </summary>
    /// <returns>Təsirlənən sətirlərin sayı.</returns>
    Task<int> EmeliyyatiTesdiqleAsync();
}