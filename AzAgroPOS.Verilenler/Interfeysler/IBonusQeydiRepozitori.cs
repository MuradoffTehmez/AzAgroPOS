// Fayl: AzAgroPOS.Verilenler/Interfeysler/IBonusQeydiRepozitori.cs
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;

public interface IBonusQeydiRepozitori : IRepozitori<BonusQeydi>
{
    /// <summary>
    /// Müştərinin bonus tarixçəsini əldə edir
    /// </summary>
    Task<IEnumerable<BonusQeydi>> MusteriTarixcesiniGetirAsync(int musteriBonusId);
}
