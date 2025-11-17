// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IAlisSifarisView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

/// <summary>
/// Alış sifarişi idarəetmə forması üçün interfeys.   mnc
/// </summary>
public interface IAlisSifarisView
{
    // Alış sifarişi məlumatları
    int SifarisId { get; set; }
    string SifarisNomresi { get; set; }
    DateTime YaradilmaTarixi { get; set; }
    DateTime? TesdiqTarixi { get; set; }
    DateTime? GozlenilenTehvilTarixi { get; set; }
    int TedarukcuId { get; set; }
    decimal UmumiMebleg { get; set; }
    string? Qeydler { get; set; }

    // View metodları
    void TedarukculeriGoster(List<TedarukcuDto> tedarukculer);
    void SifarisleriGoster(List<AlisSifarisDto> sifarisler);
    void SifarisSetirleriniGoster(List<AlisSifarisSetiriDto> setirler);
    void MehsullariGoster(List<MehsulDto> mehsullar);
    void MesajGoster(string mesaj, bool xetadir = false);
    void FormuTemizle();

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler SifarisYarat_Istek;
    event EventHandler SifarisYenile_Istek;
    event EventHandler SifarisSil_Istek;
    event EventHandler SifarisTesdiqle_Istek;
    event EventHandler FormuTemizle_Istek;
}