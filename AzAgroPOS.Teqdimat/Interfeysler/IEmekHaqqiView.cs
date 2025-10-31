// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IEmekHaqqiView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

/// <summary>
/// Əmək haqqı idarəetmə forması üçün interfeys.
/// </summary>
public interface IEmekHaqqiView
{
    // Əmək haqqı parametrləri
    int? SecilenIsciId { get; }
    DateTime Dovr { get; }
    decimal ElaveOdenisler { get; }
    decimal DigerTutulmalar { get; }
    string Qeyd { get; }
    int? SecilenEmekHaqqiId { get; }

    // View metodları
    void IscileriGoster(List<IsciDto> isciler);
    void EmekHaqqilariGoster(List<EmekHaqqiDto> emekHaqqlari);
    void SonMaasGoster(string melumat);
    void MesajGoster(string mesaj, bool xetadir = false);
    void FormuTemizle();

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler IsciSecildi;
    event EventHandler Hesabla_Istek;
    event EventHandler Ode_Istek;
    event EventHandler LegvEt_Istek;
    event EventHandler Yenile_Istek;
}
