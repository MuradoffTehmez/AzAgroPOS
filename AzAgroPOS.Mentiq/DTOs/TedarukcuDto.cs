// Fayl: AzAgroPOS.Mentiq/DTOs/TedarukcuDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System;

/// <summary>
/// Tədarükçü məlumatlarını təqdimat qatına ötürmək üçün istifadə olunan DTO.
/// </summary>
public class TedarukcuDto
{
    /// <summary>
    /// Tədarükçünün unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Tədarükçünün adı.
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// Tədarükçünün VÖEN nömrəsi.
    /// </summary>
    public string? Voen { get; set; }

    /// <summary>
    /// Tədarükçünün ünvanı.
    /// </summary>
    public string? Unvan { get; set; }

    /// <summary>
    /// Tədarükçünün telefon nömrəsi.
    /// </summary>
    public string? Telefon { get; set; }

    /// <summary>
    /// Tədarükçünün email ünvanı.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Tədarükçünün bank hesabı.
    /// </summary>
    public string? BankHesabi { get; set; }

    /// <summary>
    /// Tədarükçünün statusu (Aktiv, Passiv).
    /// </summary>
    public bool Aktivdir { get; set; } = true;
}