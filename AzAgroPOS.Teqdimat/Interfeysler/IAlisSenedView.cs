// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IAlisSenedView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

/// <summary>
/// Alış sənədi idarəetmə forması üçün interfeys.
/// </summary>
public interface IAlisSenedView
{
    // Alış sənədi məlumatları
    int SenedId { get; set; }
    string SenedNomresi { get; set; }
    DateTime YaradilmaTarixi { get; set; }
    int TedarukcuId { get; set; }
    DateTime TehvilTarixi { get; set; }
    decimal UmumiMebleg { get; set; }
    string? Qeydler { get; set; }

    // View metodları
    void TedarukculeriGoster(List<TedarukcuDto> tedarukculer);
    void SenetleriGoster(List<AlisSenedDto> senetler);
    void SenedSetirleriniGoster(List<AlisSenedSetiriDto> setirler);
    void MehsullariGoster(List<MehsulDto> mehsullar);
    void MesajGoster(string mesaj, bool xetadir = false);
    void FormuTemizle();

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler SenedYarat_Istek;
    event EventHandler SenedYenile_Istek;
    event EventHandler SenedSil_Istek;
    event EventHandler FormuTemizle_Istek;
}