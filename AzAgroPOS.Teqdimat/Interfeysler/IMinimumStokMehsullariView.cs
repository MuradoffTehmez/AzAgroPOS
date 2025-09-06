// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IMinimumStokMehsullariView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Collections.Generic;

/// <summary>
/// Minimum stok məhsulları idarəetmə forması üçün interfeys.
/// </summary>
public interface IMinimumStokMehsullariView
{
    // View metodları
    void MinimumStokMehsullariniGoster(List<MehsulDto> mehsullar);
    void MesajGoster(string mesaj, bool xetadir = false);

    // Hadisələr
    event EventHandler FormYuklendi;
    event EventHandler Yenile_Istek;
}