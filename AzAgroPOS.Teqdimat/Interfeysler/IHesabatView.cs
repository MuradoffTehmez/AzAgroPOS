// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IHesabatView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;

/// <summary>
/// Hesabatlar formu üçün "müqavilə".
/// </summary>
public interface IHesabatView
{
    // View-dan məlumat oxumaq
    DateTime SecilmisTarix { get; }

    // Hadisələr
    event EventHandler HesabatiGosterIstek;

    // View-a məlumat göndərmək
    void HesabatiGoster(GunlukSatisHesabatDto hesabat);
    void XetaMesajiGoster(string mesaj);
    void PanelləriSıfırla();
}