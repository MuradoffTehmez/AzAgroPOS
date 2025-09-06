// AzAgroPOS.Verilenler/Interfeysler/IKonfiqurasiyaRepozitori.cs
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;

public interface IKonfiqurasiyaRepozitori : IRepozitori<Konfiqurasiya>
{
    /// <summary>
    /// Açar adı ilə konfiqurasiya parametrini götürür
    /// </summary>
    /// <param name="acar">Konfiqurasiya açarı</param>
    /// <returns>Konfiqurasiya obyekti</returns>
    Task<Konfiqurasiya?> AcarlaGetirAsync(string acar);

    /// <summary>
    /// Qrupa görə konfiqurasiya parametrlərini götürür
    /// </summary>
    /// <param name="qrup">Konfiqurasiya qrupu</param>
    /// <returns>Konfiqurasiya parametrlərinin siyahısı</returns>
    Task<IEnumerable<Konfiqurasiya>> QruplaGetirAsync(string qrup);
}