// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IIsciIzniView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;

/// <summary>
/// İşçi izni idarəetmə forması üçün interfeys.
/// </summary>
public interface IIsciIzniView
{
    // İzin parametrləri
    int? SecilenIsciId { get; }
    IzinNovu IzinNovu { get; }
    DateTime BaslamaTarixi { get; }
    DateTime BitmeTarixi { get; }
    string Sebeb { get; }
    string Qeydler { get; }
    int SecilenIzinId { get; }

    // View metodları
    void IscileriGoster(List<IsciDto> isciler);
    void IzinleriGoster(List<IsciIzniDto> izinler);
    void FormatlaGrid();
    void MesajGoster(string mesaj, bool xetadir = false);
    void FormuTemizle();
    void StatusMelumatGoster(string melumat, System.Drawing.Color reng);
    void IsciIzinMelumatGoster(string melumat);

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler IsciSecildi;
    event EventHandler Yarat_Istek;
    event EventHandler Yenile_Istek;
    event EventHandler Sil_Istek;
    event EventHandler Tesdiqle_Istek;
    event EventHandler ReddEt_Istek;
    event EventHandler LegvEt_Istek;
    event EventHandler StatusFiltre_Deyisdi;
    event EventHandler YenileHamisi_Istek;
}
