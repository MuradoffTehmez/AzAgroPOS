// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IMinimumStokMehsullariView.cs

using AzAgroPOS.Mentiq.DTOs;

namespace AzAgroPOS.Teqdimat.Interfeysler;
/// <summary>
/// Minimum stok məhsulları idarəetmə forması üçün interfeys.
/// </summary>
public interface IMinimumStokMehsullariView
{
    // View metodları
    void MinimumStokMehsullariniGoster(List<MehsulDto> mehsullar);
    void MesajGoster(string mesaj, bool xetadir = false);

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler Yenile_Istek;
}