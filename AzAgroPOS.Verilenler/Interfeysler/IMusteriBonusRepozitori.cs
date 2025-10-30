// Fayl: AzAgroPOS.Verilenler/Interfeysler/IMusteriBonusRepozitori.cs
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;

public interface IMusteriBonusRepozitori : IRepozitori<MusteriBonus>
{
    /// <summary>
    /// Müştərinin bonus məlumatlarını əldə edir
    /// </summary>
    Task<MusteriBonus?> MusteriUzreGetirAsync(int musteriId);
}
