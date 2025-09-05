// Fayl: AzAgroPOS.Teqdimat/Interfeysler/ITedarukcuView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

/// <summary>
/// Tədarükçü idarəetmə forması üçün interfeys.
/// </summary>
public interface ITedarukcuView
{
    // Tədarükçü məlumatları
    int TedarukcuId { get; set; }
    string Ad { get; set; }
    string? Voen { get; set; }
    string? Unvan { get; set; }
    string? Telefon { get; set; }
    string? Email { get; set; }
    string? BankHesabi { get; set; }
    bool Aktivdir { get; set; }

    // View metodları
    void TedarukculeriGoster(List<TedarukcuDto> tedarukculer);
    void MesajGoster(string mesaj, bool xetadir = false);
    void FormuTemizle();

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler TedarukcuYarat_Istek;
    event EventHandler TedarukcuYenile_Istek;
    event EventHandler TedarukcuSil_Istek;
    event EventHandler FormuTemizle_Istek;
}