// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IKassaView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;

/// <summary>
/// Kassa və maliyyə idarəetmə forması üçün interfeys.
/// </summary>
public interface IKassaView
{
    // Xərc parametrləri
    int? SecilenXercId { get; }
    XercNovu XercNovu { get; }
    string XercAd { get; }
    decimal XercMebleg { get; }
    DateTime XercTarixi { get; }
    string SenedNomresi { get; }
    string XercQeyd { get; }

    // Kassa hərəkətləri filtri
    DateTime BaslangicTarixi { get; }
    DateTime BitisTarixi { get; }

    // Maliyyə hesabatı filtri
    DateTime XesabatBaslangicTarixi { get; }
    DateTime XesabatBitisTarixi { get; }

    // View metodları
    void XercleriGoster(List<XercDto> xercler);
    void KassaHareketleriniGoster(List<KassaHareketiDto> hareketler);
    void MaliyyeXulasesiniGoster(decimal umumiGelir, decimal umumiXerc, decimal menfeetZerere, decimal cariBalans);
    void MesajGoster(string mesaj, bool xetadir = false);
    void XercFormuTemizle();
    void KassaHareketleriniGoster(List<KassaHareketi> kassaHareketis);

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler XercYarat_Istek;
    event EventHandler XercYenile_Istek;
    event EventHandler XercSil_Istek;
    event EventHandler XercSecildi;
    event EventHandler XercTemizle_Istek;
    event EventHandler KassaFiltrele_Istek;
    event EventHandler HesabatGoster_Istek;
    event EventHandler Yenile_Istek;
}
public class KassaHareketiDto
{
    public int Id { get; set; }
    public DateTime Tarix { get; set; }
    public string Tesvir { get; set; }
    public decimal Mebleg { get; set; }
    public KassaHareketiNovu Novu { get; set; }
    public KassaHareketi hareketler { get; set; }
    public string SenedNomresi { get; set; }
    public string Qeyd { get; set; }
}
