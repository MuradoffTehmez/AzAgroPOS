// Fayl: AzAgroPOS.Mentiq/DTOs/MenfeetZererHesabatDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using System;

/// <summary>
/// Mənfəət və Zərər (P&L - Profit & Loss) hesabatı üçün məlumatları daşıyan DTO.
/// </summary>
public class MenfeetZererHesabatDto
{
    /// <summary>
    /// Hesabatın başlanğıc tarixi
    /// </summary>
    public DateTime BaslangicTarixi { get; set; }

    /// <summary>
    /// Hesabatın bitmə tarixi
    /// </summary>
    public DateTime BitisTarixi { get; set; }

    /// <summary>
    /// Ümumi satış gəliri (brüt gəlir)
    /// </summary>
    public decimal UmumiSatisGeliri { get; set; }

    /// <summary>
    /// Satılan malların maya dəyəri (COGS - Cost of Goods Sold)
    /// </summary>
    public decimal SatilanMallarinMayaDeyeri { get; set; }

    /// <summary>
    /// Xalis mənfəət (Satış Gəliri - COGS)
    /// </summary>
    public decimal XalisMenfeet => UmumiSatisGeliri - SatilanMallarinMayaDeyeri;

    /// <summary>
    /// Əməliyyat xərcləri (Xerc cədvəlindən)
    /// </summary>
    public decimal EmeliyyatXercleri { get; set; }

    /// <summary>
    /// Əmək haqqı xərcləri
    /// </summary>
    public decimal EmekHaqqiXercleri { get; set; }

    /// <summary>
    /// Ümumi xərclər (Əməliyyat xərcləri + Əmək haqqı xərcləri)
    /// </summary>
    public decimal UmumiXercler => EmeliyyatXercleri + EmekHaqqiXercleri;

    /// <summary>
    /// Yekun mənfəət/zərər (Xalis Mənfəət - Ümumi Xərclər)
    /// </summary>
    public decimal YekunMenfeetZerer => XalisMenfeet - UmumiXercler;

    /// <summary>
    /// Mənfəət marjası (%) = (Yekun Mənfəət / Satış Gəliri) * 100
    /// </summary>
    public decimal MenfeetMarjasi => UmumiSatisGeliri > 0
        ? Math.Round((YekunMenfeetZerer / UmumiSatisGeliri) * 100, 2)
        : 0;

    /// <summary>
    /// Hesabatın mənfəət və ya zərər olduğunu göstərir
    /// </summary>
    public string Status => YekunMenfeetZerer >= 0 ? "Mənfəət" : "Zərər";
}
