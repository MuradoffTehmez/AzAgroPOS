// Fayl: AzAgroPOS.Mentiq/DTOs/KateqoriyaDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Kateqoriya məlumatlarını təmsil edən DTO.
/// </summary>
public class KateqoriyaDto
{
    /// <summary>
    /// Kateqoriyanın unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Kateqoriyanın adı.
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// Kateqoriyanın təsviri.
    /// </summary>
    public string? Tesvir { get; set; }

    /// <summary>
    /// Kateqoriyanın aktivlik statusu.
    /// </summary>
    public bool Aktivdir { get; set; } = true;
}