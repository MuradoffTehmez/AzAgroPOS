// Fayl: AzAgroPOS.Mentiq/Idareciler/TedarukcuMeneceri.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Tədarükçülərlə bağlı əməliyyatları idarə edən menecer.
/// </summary>
public class TedarukcuMeneceri
{
    private readonly AlisManager _alisManager;

    public TedarukcuMeneceri(AlisManager alisManager)
    {
        _alisManager = alisManager;
    }

    /// <summary>
    /// Bütün tədarükçüləri DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<TedarukcuDto>>> ButunTedarukculeriGetirAsync()
    {
        return await _alisManager.ButunTedarukculeriGetirAsync();
    }

    /// <summary>
    /// Verilmiş ID-yə görə tədarükçü məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<TedarukcuDto>> TedarukcuGetirAsync(int id)
    {
        return await _alisManager.TedarukcuGetirAsync(id);
    }

    /// <summary>
    /// Yeni tədarükçü yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> TedarukcuYaratAsync(TedarukcuDto dto)
    {
        return await _alisManager.TedarukcuYaratAsync(dto);
    }

    /// <summary>
    /// Mövcud tədarükçünün məlumatlarını yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> TedarukcuYenileAsync(TedarukcuDto dto)
    {
        return await _alisManager.TedarukcuYenileAsync(dto);
    }

    /// <summary>
    /// Tədarükçü silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> TedarukcuSilAsync(int id)
    {
        return await _alisManager.TedarukcuSilAsync(id);
    }
}