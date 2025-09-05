// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ITedarukcuOdemeView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

/// <summary>
/// Tədarükçü ödənişi idarəetmə forması üçün interfeys.
/// </summary>
public interface ITedarukcuOdemeView
{
    // Tədarükçü ödənişi məlumatları
    int OdemeId { get; set; }
    string OdemeNomresi { get; set; }
    DateTime YaradilmaTarixi { get; set; }
    int TedarukcuId { get; set; }
    int? AlisSenedId { get; set; }
    DateTime OdemeTarixi { get; set; }
    decimal Mebleg { get; set; }
    string? Qeydler { get; set; }
    string? BankMelumatlari { get; set; }

    // View metodları
    void TedarukculeriGoster(List<TedarukcuDto> tedarukculer);
    void SenetleriGoster(List<AlisSenedDto> senetler);
    void OdemeleriGoster(List<TedarukcuOdemeDto> odemeler);
    void MesajGoster(string mesaj, bool xetadir = false);
    void FormuTemizle();

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler OdemeYarat_Istek;
    event EventHandler OdemeYenile_Istek;
    event EventHandler OdemeSil_Istek;
    event EventHandler FormuTemizle_Istek;
}