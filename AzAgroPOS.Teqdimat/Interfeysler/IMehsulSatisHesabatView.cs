// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IMehsulSatisHesabatView.cs

using AzAgroPOS.Mentiq.DTOs;

namespace AzAgroPOS.Teqdimat.Interfeysler;
/// <summary>
/// Məhsul üzrə satış hesabatı formu üçün "müqavilə".
/// </summary>
public interface IMehsulSatisHesabatView
{
    // View-dan məlumat oxumaq
    DateTime BaslangicTarix { get; }
    DateTime BitisTarix { get; }

    // Hadisələr
    event EventHandler HesabatiGosterIstek;

    // View-a məlumat göndərmək
    void HesabatiGoster(List<MehsulUzreSatisDetayDto> hesabat);
    void MesajGoster(string mesaj);
}